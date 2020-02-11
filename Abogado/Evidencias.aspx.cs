using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

public partial class Evidencias : System.Web.UI.Page
{
    private CNX conn = new CNX();
    string editar;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                DtgArchivos.DataSource = conn.ObtenerDatoSicad("select * from archivosevidencia");
                DtgArchivos.DataBind();

                DataTable dtbuscarid = conn.ObtenerDatoSicad("SELECT * From Pagos WHERE IDPago ='" + Request.QueryString["IDPago"] + "'");

            if (dtbuscarid.Rows.Count > 0)
            {

                editar = "Editar";
                DataRow row = dtbuscarid.Rows[0];
                //TxtFecha.Text = Convert.ToDateTime(row["fecha"]).ToString("yyyy-MM-dd");
                
                TxtNotas.Value = row["notas"].ToString();
                
                Session["editar"] = editar;

            }
            else
            {
                editar = "Agregar";
                Session["editar"] = editar;
            }


            DataTable dtbuscaridx = conn.ObtenerDatoSicad("SELECT Cliente.IDCliente, Cliente.nombre, Cliente.apellidopaterno, Cliente.apellidomaterno, Tramites.IDAsunto, Tramites.costo, Tramites.fechainicio, Tramites.fechatermino, Asunto.asunto, Tramites.IDTramite FROM  Tramites INNER JOIN Cliente ON Tramites.IDCliente = Cliente.IDCliente INNER JOIN Asunto ON Tramites.IDAsunto = Asunto.IDAsunto WHERE Tramites.IDTramite='" + Request.QueryString["IDTramite"] + "'");

            if (dtbuscaridx.Rows.Count > 0)
            {


                DataRow row = dtbuscaridx.Rows[0];
                TxtCliente.Text = row["nombre"].ToString() + ' ' + row["apellidopaterno"].ToString() + ' ' + row["apellidomaterno"].ToString();
                TxtAsunto.Text = row["asunto"].ToString();
                TxtFechaInicio.Text = Convert.ToDateTime(row["fechainicio"]).ToString("yyyy-MM-dd");
                TxtFechaTermino.Text = Convert.ToDateTime(row["fechatermino"]).ToString("yyyy-MM-dd");
                TxtTotal.Text = row["Costo"].ToString();

            }
            else
            {

            }


            DataTable dtpagos = conn.ObtenerDatoSicad("SELECT ISNULL(SUM(Pagos.pago), 0) AS pago FROM  Pagos INNER JOIN Tramites ON Pagos.IDTramite = Tramites.IDTramite INNER JOIN Cliente ON Tramites.IDCliente = Cliente.IDCliente where  Pagos.IDTramite='" + Request.QueryString["IDTramite"] + "'");

            if (dtpagos.Rows.Count > 0)
            {


                DataRow row = dtpagos.Rows[0];


                TxtDebe.Text = row["pago"].ToString();

                int total;

                total = int.Parse(TxtTotal.Text) - int.Parse(TxtDebe.Text);

                TxtDebe.Text = total.ToString();
            }
            else
            {

            }


            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }

    }

    protected void btnAgregarEvidencia_Click(object sender, EventArgs e)
    {
        try
        {
            int idtramit = int.Parse(Request.QueryString["idtramite"]);

            if (TxtNotas.Value.Trim()=="")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe escribir una nota', 'warning') </script>", false);
                return;
            }

            if (FileUpload1.HasFile)
                {

                Guardar(idtramit, FileUpload1.FileName, TxtNotas.Value);

                DataTable dtarchivos = conn.ObtenerDatoSicad("select top 1 * from archivosevidencia where idtramite = '" + idtramit + "' order by fecha desc");
                DataRow row = dtarchivos.Rows[0];
                int idarchivo = int.Parse(row["Idarchivoevidencia"].ToString());


                String nombre = Path.GetExtension(FileUpload1.PostedFile.FileName);

                string ruta1 = Server.MapPath("\\evidenciatramites\\");

                if (!Directory.Exists(ruta1))
                {
                    Directory.CreateDirectory(ruta1);
                }
                   
                if (FileUpload1.HasFile)
                {
                    String ruta = Server.MapPath("\\evidenciatramites\\" + idtramit + "-" + idarchivo + nombre + "");
                    FileUpload1.SaveAs(ruta);

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Se guardó exitosamente', 'success') </script>", false);

                    RegularExpressionValidator1.Text = "";
                    TxtNotas.Value = "";
                }

                String renombrado = idtramit + "-" + idarchivo + nombre;

                conn.ObtenerDatoSicad("update archivosevidencia set renombrado = '" + renombrado + "' where  Idarchivoevidencia= '" + idarchivo + "'");

                DtgArchivos.DataSource = conn.ObtenerDatoSicad("select * from archivosevidencia");
                DtgArchivos.DataBind();

            }
            else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe seleccionar un archivo', 'warning') </script>", false);
                    return;
                }
        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);
        }
    }


    public void Guardar(int idtramite, string nombrearchivo,string comentario)
    {

        // Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("default").ToString())
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cnx"].ToString())) 
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            string query = "INSERT INTO archivosevidencia (idtramite,fecha,nombrearchivo,comentario) VALUES (@idtramite,getDate(),@name,@comentario)";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@idtramite", idtramite);
            cmd.Parameters.AddWithValue("@name", nombrearchivo);
            cmd.Parameters.AddWithValue("@comentario", comentario);
            // cmd.Parameters.AddWithValue("@renombrado", renombrado)
            // cmd.Parameters.AddWithValue("@length", length)

            // Dim archParam As SqlParameter = cmd.Parameters.Add("@archivo", System.Data.SqlDbType.VarBinary)
            // archParam.Value = Archivo

            cmd.ExecuteNonQuery();

            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
    }



    protected void DownloadFile(object sender, EventArgs e)
    {
        
        LinkButton btn = (LinkButton)(sender);
        // Dim bytes As Byte()
        string Renombrado;
        string nombreoriginal;
        string ruta;

        try
        {

       
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Cnx"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from archivosevidencia where  idarchivoevidencia=@Id";
                cmd.Parameters.AddWithValue("@Id", btn.CommandArgument);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    // bytes = DirectCast(sdr("archivo"), Byte())
                    // contentType = sdr("ContentType").ToString()
                    Renombrado = sdr["renombrado"].ToString();
                    nombreoriginal = sdr["nombrearchivo"].ToString();
                }

                ruta = Server.MapPath(@"\\evidenciatramites\\" + Renombrado);

                con.Close();
            }
        }

        // Descargar el archivo
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        // Response.ContentType = contentType
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombreoriginal);
        // Response.BinaryWrite(bytes)
        Response.TransmitFile(ruta);
        Response.Flush();
        Response.End();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Se descargo exitosamente', 'success') </script>", false);
            
        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);
        }
    }

    protected void btnEliminarArchivo(object sender, EventArgs e)
    {

        LinkButton btn = (LinkButton)(sender);
        // Dim bytes As Byte()
        string Renombrado;
        string nombreoriginal;
        string ruta;

        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Cnx"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from archivosevidencia where  idarchivoevidencia=@Id";
                    cmd.Parameters.AddWithValue("@Id", btn.CommandArgument);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        // bytes = DirectCast(sdr("archivo"), Byte())
                        // contentType = sdr("ContentType").ToString()
                        Renombrado = sdr["renombrado"].ToString();
//                        nombreoriginal = sdr["nombrearchivo"].ToString();
                    }

                    ruta = Server.MapPath(@"\\evidenciatramites\\" + Renombrado);

                    con.Close();
                }
            }

            if (File.Exists(ruta))
            {
                File.Delete(ruta);
                conn.ObtenerDatoSicad("delete from archivosevidencia where idarchivoevidencia= '" + btn.CommandArgument + "' ");
                DtgArchivos.DataSource = conn.ObtenerDatoSicad("select * from archivosevidencia");
                DtgArchivos.DataBind();

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Se eliminó exitosamente', 'success') </script>", false);
            }
            else
            {
                conn.ObtenerDatoSicad("delete from archivosevidencia where idarchivoevidencia= '" + btn.CommandArgument + "' ");
                DtgArchivos.DataSource = conn.ObtenerDatoSicad("select * from archivosevidencia");
                DtgArchivos.DataBind();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Ocurrió un error inesperado, intente de nuevo', 'warning') </script>", false);
            }
        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);
        }
    }


}


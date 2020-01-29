using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PagosVer : System.Web.UI.Page
{

    private CNX conn = new CNX();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {
                DataTable dtbuscarid = conn.ObtenerDatoSicad("SELECT Cliente.IDCliente, Cliente.nombre, Cliente.apellidopaterno, Cliente.apellidomaterno, Tramites.IDAsunto, Tramites.costo, Tramites.fechainicio, Tramites.fechatermino, Asunto.asunto, Tramites.IDTramite FROM  Tramites INNER JOIN Cliente ON Tramites.IDCliente = Cliente.IDCliente INNER JOIN Asunto ON Tramites.IDAsunto = Asunto.IDAsunto WHERE Tramites.IDTramite='" + Request.QueryString["IDTramite"] + "'");
                if (dtbuscarid.Rows.Count > 0)
                {
                    DataRow row = dtbuscarid.Rows[0];
                    TxtCliente.Text = row["nombre"].ToString() + ' ' + row["apellidopaterno"].ToString() + ' ' + row["apellidomaterno"].ToString();
                    TxtAsunto.Text = row["asunto"].ToString();
                    TxtFechaInicio.Text = Convert.ToDateTime(row["fechainicio"]).ToString("yyyy-MM-dd");
                    TxtFechaTermino.Text = Convert.ToDateTime(row["fechatermino"]).ToString("yyyy-MM-dd");
                    TxtTotal.Text = row["Costo"].ToString();
                }
                else
                {

                }

                DtgJuzgados.DataSource = conn.ObtenerDatoSicad("SELECT Pagos.IDPago, Pagos.IDTramite, Pagos.fecha, Pagos.pago, Pagos.notas, Pagos.tipopago, Cliente.nombre, Cliente.apellidopaterno, Cliente.apellidomaterno, Tramites.IDAsunto, Tramites.costo, Tramites.fechainicio, Tramites.fechatermino FROM  Pagos INNER JOIN Tramites ON Pagos.IDTramite = Tramites.IDTramite INNER JOIN Cliente ON Tramites.IDCliente = Cliente.IDCliente where  Pagos.IDTramite='" + Request.QueryString["IDTramite"] + "'");
                DtgJuzgados.DataBind();
            }

            catch (Exception ex)
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

    }

    protected void btnEliminarJuzgado_Click(object sender, EventArgs e)
    {

        LinkButton btn = (LinkButton)(sender);

        conn.ObtenerDatoSicad("delete from Pagos where IDPago = '" + btn.CommandArgument + "'");

        DtgJuzgados.DataSource = conn.ObtenerDatoSicad("SELECT Pagos.IDPago, Pagos.IDTramite, Pagos.fecha, Pagos.pago, Pagos.notas, Pagos.tipopago, Cliente.nombre, Cliente.apellidopaterno, Cliente.apellidomaterno, Tramites.IDAsunto, Tramites.costo, Tramites.fechainicio, Tramites.fechatermino FROM  Pagos INNER JOIN Tramites ON Pagos.IDTramite = Tramites.IDTramite INNER JOIN Cliente ON Tramites.IDCliente = Cliente.IDCliente where  Pagos.IDTramite='" + Request.QueryString["IDTramite"] + "'");
        DtgJuzgados.DataBind();


        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Se ha eliminado exitosamente', '', 'success') </script>", false);


    }


    protected void btnEditarJuzgado_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        Response.Redirect("Pagos.aspx?IDPago= " + btn.CommandArgument + "&IDTramite=" + Request.QueryString["IDTramite"] + "");
    }

    protected void btnAgregarPago_Click(object sender, EventArgs e)
    {

        Response.Redirect("Pagos.aspx?IDTramite=" + Request.QueryString["IDTramite"] + "");

    }





    


}
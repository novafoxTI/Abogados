using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clientes : System.Web.UI.Page
{
    private CNX conn = new CNX();
    string editar;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                DataTable dtbuscarid = conn.ObtenerDatoSicad("SELECT * From Cliente WHERE IDCliente ='" + Request.QueryString["IDCliente"] + "'");

                if (dtbuscarid.Rows.Count > 0)
                {
                    
                    editar = "Editar";
                    DataRow row = dtbuscarid.Rows[0];
                    TxtNombre.Text = row["nombre"].ToString();
                    TxtApellidoPaterno.Text = row["apellidopaterno"].ToString();
                    TxtApellidoMaterno.Text = row["apellidomaterno"].ToString();
                    TxtCurp.Text = row["curp"].ToString();
                    TxtRfc.Text = row["rfc"].ToString();
                    TxtCalle.Text = row["calle"].ToString();
                    TxtNumero.Text = row["numero"].ToString();
                    TxtColonia.SelectedValue = row["colonia"].ToString();
                    TxtCP.Text = row["cp"].ToString();
                    TxtCiudad.SelectedValue = row["ciudad"].ToString();
                    TxtMunicipio.SelectedValue = row["municipio"].ToString();
                    Txttelefono.Text = row["telefono"].ToString();
                    Txtcelular.Text = row["celular"].ToString();
                    Session["editar"] = editar;

                   

                }
                else
                {
                    editar = "Agregar";
                    Session["editar"] = editar;
                }
            }
        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);
        }
    }

    protected void BtnAgregarCliente_Click(object sender, EventArgs e)
    {
        try
        {

       
        if (Session["editar"].ToString() == "Editar")
        {
            conn.ObtenerDatoSicad("Update   Cliente set nombre='" + TxtNombre.Text + "', apellidopaterno='" + TxtApellidoPaterno.Text + "', apellidomaterno='" + TxtApellidoMaterno.Text + "', curp='" + TxtCurp.Text + "', rfc='" + TxtRfc.Text + "', calle='" + TxtCalle.Text + "', numero='" + TxtNumero.Text + "', colonia='" + TxtColonia.Text.Replace('"', ' ').Trim() + "', cp='" + TxtCP.Text + "', municipio='" + TxtMunicipio.Text.Replace('"', ' ').Trim() + "', ciudad='" + TxtCiudad.Text.Replace('"', ' ').Trim() + "', telefono='" + Txttelefono.Text + "', celular='" + Txtcelular.Text + "' where  IDCliente ='" + Request.QueryString["IDCliente"] + "'");

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "Script", "<script language='JavaScript'> swal('Se ha actualizado éxitosamente', '', 'success') </script>", false);

                TxtColonia.Items.Clear();
                TxtCiudad.Items.Clear();
                TxtMunicipio.Items.Clear();

                TxtColonia.Items.Add("-Selecciona una colonia-");
                TxtCiudad.Items.Add("-Selecciona una ciudad-");
                TxtMunicipio.Items.Add("-Selecciona un municipio-");

                TxtNombre.Text = "";
            TxtApellidoPaterno.Text = "";
            TxtApellidoMaterno.Text = "";
            TxtCurp.Text = "";
            TxtRfc.Text = "";
            TxtCalle.Text = "";
            TxtNumero.Text = "";
            TxtColonia.Text = "";
            TxtCP.Text = "";
            TxtCiudad.Text = "";
            TxtMunicipio.Text = "";
            Txttelefono.Text = "";
            Txtcelular.Text = "";
            TxtNombre.Focus();
        }
        else
        {
                if (TxtNombre.Text.Trim() == "") {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un nombre', 'warning') </script>", false);
                }
                else if (TxtApellidoPaterno.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un apellido', 'warning') </script>", false);
                } else if (TxtApellidoMaterno.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un materno', 'warning') </script>", false);
                } else if (TxtCurp.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar la curp', 'warning') </script>", false);
                } else if (TxtCalle.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar la calle', 'warning') </script>", false);
                } else if (TxtNumero.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar el número de casa', 'warning') </script>", false);
                } else if (TxtColonia.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar la colonia', 'warning') </script>", false);
                } else if (TxtCP.Text.Trim()=="")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar el código postal', 'warning') </script>", false);
                }
                else if(TxtCiudad.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar la ciudad', 'warning') </script>", false);
                }
                else if (TxtMunicipio.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar el municipio', 'warning') </script>", false);
                }
                else if(Txttelefono.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un número de teléfono', 'warning') </script>", false);
                }
                else if (Txtcelular.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un número de celular', 'warning') </script>", false);
                }
                else
                {
                    conn.ObtenerDatoSicad("INSERT INTO   Cliente(nombre, apellidopaterno, apellidomaterno, curp, rfc, calle, numero, colonia, cp, municipio, ciudad, telefono, celular) VALUES('" + TxtNombre.Text + "', '" + TxtApellidoPaterno.Text + "', '" + TxtApellidoMaterno.Text + "', '" + TxtCurp.Text + "', '" + TxtRfc.Text + "', '" + TxtCalle.Text + "', '" + TxtNumero.Text + "', '" + TxtColonia.Text.Replace('"', ' ').Trim() + "', '" + TxtCP.Text + "', '" + TxtMunicipio.Text.Replace('"', ' ').Trim() + "', '" + TxtCiudad.Text.Replace('"', ' ').Trim() + "', '" + Txttelefono.Text + "', '" + Txtcelular.Text + "')");


                   
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "Script", "<script language='JavaScript'> swal('Se ha guardado éxitosamente', '', 'success') </script>", false);

                    TxtColonia.Items.Clear();
                    TxtCiudad.Items.Clear();
                    TxtMunicipio.Items.Clear();

                    TxtColonia.Items.Add("-Selecciona una colonia-");
                    TxtCiudad.Items.Add("-Selecciona una ciudad-");
                    TxtMunicipio.Items.Add("-Selecciona un municipio-");

                    TxtNombre.Text = "";
                    TxtApellidoPaterno.Text = "";
                    TxtApellidoMaterno.Text = "";
                    TxtCurp.Text = "";
                    TxtRfc.Text = "";
                    TxtCalle.Text = "";
                    TxtNumero.Text = "";
                    TxtColonia.SelectedIndex = 0;
                    TxtCP.Text = "";
                    TxtCiudad.SelectedIndex = 0;
                    TxtMunicipio.SelectedIndex = 0;
                    Txttelefono.Text = "";
                    Txtcelular.Text = "";
                    TxtNombre.Focus();
                }
                
            }
        }
        catch (Exception ex)
        {

            string error = String.Format("<script language='JavaScript'> swal('Aviso!!', 'Error: {0}', 'warning')</script>", ex.Message);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Script", error, false);
            return;
        }
    }
         

protected void BtnCancelarCliente_Click(object sender, EventArgs e)
    {

        TxtColonia.Items.Clear();
        TxtCiudad.Items.Clear();
        TxtMunicipio.Items.Clear();

        TxtColonia.Items.Add("-Selecciona una colonia-");
        TxtCiudad.Items.Add("-Selecciona una ciudad-");
        TxtMunicipio.Items.Add("-Selecciona un municipio-");

        TxtNombre.Text = "";
        TxtApellidoPaterno.Text = "";
        TxtApellidoMaterno.Text = "";
        TxtCurp.Text = "";
        TxtRfc.Text = "";
        TxtCalle.Text = "";
        TxtNumero.Text = "";
        TxtColonia.Text = "";
        TxtCP.Text = "";
        TxtCiudad.Text = "";
        TxtMunicipio.Text = "";
        Txttelefono.Text = "";
        Txtcelular.Text = "";
        TxtNombre.Focus();

    }



    protected void BtnRegresarlistaClientes_Click(object sender, EventArgs e)
    {

        Response.Redirect("Clientesver.aspx");

    }



    protected void BuscarMunicipio(object sender, EventArgs e)
    {



        // Limpia el campo cuando se busca un nuevo CP
        TxtMunicipio.Items.Clear();

        // Manejo de acentos
        WebClient client = new WebClient();
        client.Encoding = System.Text.Encoding.UTF8;

        // URL para el llamado de la API

        string consulta = string.Format("https://api-sepomex.hckdrk.mx/query/get_municipio_por_estado/{0}", TxtCiudad.Text.Replace('"', ' ').Trim());

        // "Limpia" la informacion recibida de la API
        try
        {
            var response = client.DownloadString(consulta);
            string[] parts = response.Split('[');
            string colonias = parts[parts.Length - 1];
            parts = colonias.Split(']');
            colonias = parts[0];

            List<string> coloniasList = colonias.Split(',').ToList();

            // Vacia la informacion en la lista desplegable.
            foreach (var item in coloniasList)
            {
                TxtMunicipio.Items.Add(item);
         
            }


   


        }



        catch (Exception ex)
        {
            string error = String.Format("<script language='JavaScript'> swal('Aviso!!', 'Error: {0}', 'warning')</script>", ex.Message);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Script", error, false);
            return;
        }




    }

    protected void BuscarColonia(object sender, EventArgs e)
    {
        // Limpia el campo cuando se busca un nuevo CP
        TxtColonia.Items.Clear();

        // Manejo de acentos
        WebClient client = new WebClient();
        client.Encoding = System.Text.Encoding.UTF8;

        // URL para el llamado de la API

        string consulta = string.Format("https://api-sepomex.hckdrk.mx/query/get_colonia_por_cp/{0}", TxtCP.Text);
        string consulta1 = string.Format("https://api-sepomex.hckdrk.mx/query/get_estados/");

        // "Limpia" la informacion recibida de la API
        try
        {
            var response = client.DownloadString(consulta);
            string[] parts = response.Split('[');
            string colonias = parts[parts.Length - 1];
            parts = colonias.Split(']');
            colonias = parts[0];

            List<string> coloniasList = colonias.Split(',').ToList();
            
            // Vacia la informacion en la lista desplegable.
            foreach (var item in coloniasList)
            {
                TxtColonia.Items.Add(item);
                TxtColonia.SelectedValue.Replace('"', ' ').Trim();
            }



            var response1 = client.DownloadString(consulta1);
            string[] parts1 = response1.Split('[');
            string colonias1 = parts1[parts1.Length - 1];
            parts1 = colonias1.Split(']');
            colonias1 = parts1[0];

            List<string> colonias1List = colonias1.Split(',').ToList();

            // Vacia la informacion en la lista desplegable.
            foreach (var item in colonias1List)
            {
                TxtCiudad.Items.Add(item);
               
            }


        }



        catch (Exception ex)
        {
            string error = String.Format("<script language='JavaScript'> swal('Aviso!!', 'Error: {0}', 'warning')</script>", ex.Message);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Script", error, false);
            return;
        }

    }


}
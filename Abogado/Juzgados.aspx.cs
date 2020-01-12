using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Juzgados : System.Web.UI.Page
{
    private CNX conn = new CNX();
    string editar;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack) { 
                DataTable dtbuscarid = conn.ObtenerDatoSicad("SELECT * From Juzgados WHERE IDJuzgado ='" + Request.QueryString["idjuzgado"] + "'");

                if (dtbuscarid.Rows.Count > 0)
                {
                    editar = "Editar";
                    DataRow row = dtbuscarid.Rows[0];
                    TxtNombre.Text = row["nombre"].ToString();
                    TxtCalle.Text = row["calle"].ToString();
                    TxtNumero.Text = row["numero"].ToString();
                    TxtColonia.Text = row["colonia"].ToString();
                    TxtCP.Text = row["cp"].ToString();
                    TxtCiudad.Text = row["ciudad"].ToString();
                    TxtMunicipio.Text = row["municipio"].ToString();
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

    protected void BtnAgregarjuzgado_Click(object sender, EventArgs e)
    {
        try
        {

        if (Session["editar"].ToString()=="Editar")
        {
            conn.ObtenerDatoSicad("Update   Juzgados set nombre='" + TxtNombre.Text + "', calle='" + TxtCalle.Text + "', numero='" + TxtNumero.Text + "', colonia='" + TxtColonia.Text + "', cp='" + TxtCP.Text + "', ciudad='" + TxtCiudad.Text + "', municipio='" + TxtMunicipio.Text + "' where  IDJuzgado ='" + Request.QueryString["idjuzgado"] + "'");

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Se actualizó exitosamente', '', 'success') </script>", false);

                TxtNombre.Text = "";
                TxtCalle.Text = "";
                TxtNumero.Text = "";
                TxtColonia.Text = "";
                TxtCP.Text = "";
                TxtMunicipio.Text = "";
                TxtCiudad.Text = "";
                TxtNombre.Focus();
        }
        else
        {
                if (TxtNombre.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un nombre', 'warning') </script>", false);
                }
                else if (TxtCalle.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar la calle', 'warning') </script>", false);
                }
                else if (TxtNumero.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar el número', 'warning') </script>", false);
                }
                else if (TxtColonia.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar la colonia', 'warning') </script>", false);
                }
                else if (TxtCP.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar el código postal', 'warning') </script>", false);
                }
                else if (TxtCiudad.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar la ciudad', 'warning') </script>", false);
                }
                else if (TxtMunicipio.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar el municipio', 'warning') </script>", false);
                }
                else
                {
                    conn.ObtenerDatoSicad("INSERT INTO   Juzgados(nombre, calle, numero, colonia, cp, ciudad, municipio) VALUES('" + TxtNombre.Text + "', '" + TxtCalle.Text + "', '" + TxtNumero.Text + "', '" + TxtColonia.Text + "', '" + TxtCP.Text + "', '" + TxtCiudad.Text + "', '" + TxtMunicipio.Text + "')");

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Se agregó exitosamente', 'Ya se encuentra disponible en la lista', 'success') </script>", false);

                    TxtNombre.Text = "";
                    TxtCalle.Text = "";
                    TxtNumero.Text = "";
                    TxtColonia.Text = "";
                    TxtCP.Text = "";
                    TxtMunicipio.Text = "";
                    TxtCiudad.Text = "";
                    TxtNombre.Focus();
                }
        }

        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);
        }
    }

    protected void BtnCancelarjuzgado_Click(object sender, EventArgs e)
    {
        TxtNombre.Text = "";
        TxtCalle.Text = "";
        TxtNumero.Text = "";
        TxtColonia.Text = "";
        TxtCP.Text = "";
        TxtMunicipio.Text = "";
        TxtCiudad.Text = "";
        TxtNombre.Focus();

    }

   protected void BtnRegresarlistajuzgados_Click(object sender, EventArgs e)
    {
        Response.Redirect("juzgadosver.aspx");

    }


}
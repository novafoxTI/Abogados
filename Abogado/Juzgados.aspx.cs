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

    protected void BtnAgregarjuzgado_Click(object sender, EventArgs e)
    {
        if (Session["editar"].ToString()=="Editar")
        {
            conn.ObtenerDatoSicad("Update   Juzgados set nombre='" + TxtNombre.Text + "', calle='" + TxtCalle.Text + "', numero='" + TxtNumero.Text + "', colonia='" + TxtColonia.Text + "', cp='" + TxtCP.Text + "', ciudad='" + TxtCiudad.Text + "', municipio='" + TxtMunicipio.Text + "' where  IDJuzgado ='" + Request.QueryString["idjuzgado"] + "'");

        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Oops', 'Usuario o Contraseña incorrecta!', 'error') </script>", false);

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
            conn.ObtenerDatoSicad("INSERT INTO   Juzgados(nombre, calle, numero, colonia, cp, ciudad, municipio) VALUES('" + TxtNombre.Text + "', '" + TxtCalle.Text + "', '" + TxtNumero.Text + "', '" + TxtColonia.Text + "', '" + TxtCP.Text + "', '" + TxtCiudad.Text + "', '" + TxtMunicipio.Text + "')");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Oops', 'Usuario o Contraseña incorrecta!', 'error') </script>", false);

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
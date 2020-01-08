using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clientes : System.Web.UI.Page
{
    private CNX conn = new CNX();
    string editar;
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BtnAgregarCliente_Click(object sender, EventArgs e)
    {
        if (Session["editar"].ToString() == "Editar")
        {
            //conn.ObtenerDatoSicad("Update   Juzgados set nombre='" + TxtNombre.Text + "', calle='" + TxtCalle.Text + "', numero='" + TxtNumero.Text + "', colonia='" + TxtColonia.Text + "', cp='" + TxtCP.Text + "', ciudad='" + TxtCiudad.Text + "', municipio='" + TxtMunicipio.Text + "' where  IDJuzgado ='" + Request.QueryString["idjuzgado"] + "'");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Oops', 'Usuario o Contraseña incorrecta!', 'error') </script>", false);

            
        }
        else
        {
            //conn.ObtenerDatoSicad("INSERT INTO   Juzgados(nombre, calle, numero, colonia, cp, ciudad, municipio) VALUES('" + TxtNombre.Text + "', '" + TxtCalle.Text + "', '" + TxtNumero.Text + "', '" + TxtColonia.Text + "', '" + TxtCP.Text + "', '" + TxtCiudad.Text + "', '" + TxtMunicipio.Text + "')");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Oops', 'Usuario o Contraseña incorrecta!', 'error') </script>", false);

            
        }
    }

    protected void BtnCancelarCliente_Click(object sender, EventArgs e)
    {
       

    }

    protected void BtnRegresarlistaClientes_Click(object sender, EventArgs e)
    {
        Response.Redirect("Clientesver.aspx");

    }
}
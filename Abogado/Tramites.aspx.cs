using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tramites : System.Web.UI.Page
{
    private CNX conn = new CNX();
    string editar;
    protected void Page_Load(object sender, EventArgs e)
    {

        CmbCliente.DataValueField = "IDCliente";
        CmbCliente.DataTextField = "nombre";
        CmbCliente.DataSource = conn.ObtenerDatoSicad("SELECT * FROM Cliente");
        CmbCliente.DataBind();

        CmbAsunto.DataValueField = "IDAsunto";
        CmbAsunto.DataTextField = "asunto";
        CmbAsunto.DataSource = conn.ObtenerDatoSicad("SELECT * FROM Asunto");
        CmbAsunto.DataBind();

    }

    protected void BtnAgregarCliente_Click(object sender, EventArgs e)
    {

        conn.ObtenerDatoSicad("INSERT INTO   Tramites( IDCliente, IDAsunto, fechainicio, fechatermino, costo, tipopago) VALUES('" + CmbCliente.SelectedValue + "', '" + CmbAsunto.SelectedValue + "', '" + TxtFechaInicio.Text + "', '" + TxtFechaTermino.Text + "', '" + TxtCosto.Text + "', '" + CmbTipoPago.SelectedValue + "')");

        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Oops', 'Usuario o Contraseña incorrecta!', 'error') </script>", false);



    }

    protected void BtnCancelarCliente_Click(object sender, EventArgs e)
    {

        
    }



    protected void BtnRegresarlistaClientes_Click(object sender, EventArgs e)
    {

        Response.Redirect("Asuntosver.aspx");

    }
}
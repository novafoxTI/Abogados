using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Asuntos : System.Web.UI.Page
{
    private CNX conn = new CNX();
    string editar;
    protected void Page_Load(object sender, EventArgs e)
    {

        DataTable dtbuscarid = conn.ObtenerDatoSicad("SELECT * From Asunto WHERE IDAsunto ='" + Request.QueryString["IDAsunto"] + "'");

        if (dtbuscarid.Rows.Count > 0)
        {

            editar = "Editar";
            DataRow row = dtbuscarid.Rows[0];
            TxtNombre.Text = row["asunto"].ToString();
        
            Session["editar"] = editar;

        }
        else
        {
            editar = "Agregar";
            Session["editar"] = editar;
        }

    }

    protected void BtnAgregarCliente_Click(object sender, EventArgs e)
    {
        if (Session["editar"].ToString() == "Editar")
        {
            conn.ObtenerDatoSicad("Update   Asunto set asunto='" + TxtNombre.Text + "' where  IDAsunto ='" + Request.QueryString["IDAsunto"] + "'");

            TxtNombre.Text = "";

            TxtNombre.Focus();
        }
        else
        {
            conn.ObtenerDatoSicad("INSERT INTO   Asunto(asunto) VALUES('" + TxtNombre.Text + "')");

            TxtNombre.Text = "";
        
            TxtNombre.Focus();

        }
    }

    protected void BtnCancelarCliente_Click(object sender, EventArgs e)
    {

        TxtNombre.Text = "";
   
        TxtNombre.Focus();

    }



    protected void BtnRegresarlistaClientes_Click(object sender, EventArgs e)
    {

        Response.Redirect("Asuntosver.aspx");

    }
}
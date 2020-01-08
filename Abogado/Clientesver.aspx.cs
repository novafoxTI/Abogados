using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clientesver : System.Web.UI.Page
{
    private CNX conn = new CNX();
    string editar;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                DtgClientes.DataSource = conn.ObtenerDatoSicad("select * from Cliente");
                DtgClientes.DataBind();

            }

            catch (Exception ex)
            {

            }

        }
    }

    protected void btnAgregarClientes_Click(object sender, EventArgs e)
    {

        Response.Redirect("clientes.aspx");


    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Login : System.Web.UI.Page
{
    CNX modelo = new CNX();
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnIngresar_Click(object sender, EventArgs e)
    {
        DataTable buscarU = new DataTable();
        buscarU = modelo.ObtenerDatoSicad("Select * from usuario where email= '" + usuario.Value + "' and password='" + pass.Value + "'");

        if (buscarU.Rows.Count > 0)
        {
            Response.Redirect("Clientes.aspx");
        }
        else {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Oops', 'Usuario o Contraseña incorrecta!', 'error') </script>", false);
            usuario.Value = "";
            pass.Value = "";
        }
    }


}
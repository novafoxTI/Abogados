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
            TxtColonia.Text = row["colonia"].ToString();
            TxtCP.Text = row["cp"].ToString();
            TxtCiudad.Text = row["ciudad"].ToString();
            TxtMunicipio.Text = row["municipio"].ToString();
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

    protected void BtnAgregarCliente_Click(object sender, EventArgs e)
    {
        if (Session["editar"].ToString() == "Editar")
        {
            conn.ObtenerDatoSicad("Update   Cliente set nombre='" + TxtNombre.Text + "', apellidopaterno='" + TxtApellidoPaterno.Text + "', apellidomaterno='" + TxtApellidoMaterno.Text + "', curp='" + TxtCurp.Text + "', rfc='" + TxtRfc.Text + "', calle='" + TxtCalle.Text + "', numero='" + TxtNumero.Text + "', colonia='" + TxtColonia.Text + "', cp='" + TxtCP.Text + "', municipio='" + TxtMunicipio.Text + "', ciudad='" + TxtCiudad.Text + "', telefono='" + Txttelefono.Text + "', celular='" + Txtcelular.Text + "' where  IDCliente ='" + Request.QueryString["IDCliente"] + "'");

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
            conn.ObtenerDatoSicad("INSERT INTO   Cliente(nombre, apellidopaterno, apellidomaterno, curp, rfc, calle, numero, colonia, cp, municipio, ciudad, telefono, celular) VALUES('" + TxtNombre.Text + "', '" + TxtApellidoPaterno.Text + "', '" + TxtApellidoMaterno.Text + "', '" + TxtCurp.Text + "', '" + TxtRfc.Text + "', '" + TxtCalle.Text + "', '" + TxtNumero.Text + "', '" + TxtColonia.Text + "', '" + TxtCP.Text + "', '" + TxtMunicipio.Text + "', '" + TxtCiudad.Text + "', '" + Txttelefono.Text + "', '" + Txtcelular.Text + "')");

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
    }

    protected void BtnCancelarCliente_Click(object sender, EventArgs e)
    {

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
}
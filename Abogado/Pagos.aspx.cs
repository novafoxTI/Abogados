using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pagos : System.Web.UI.Page
{
    private CNX conn = new CNX();
    string editar;
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dtbuscarid = conn.ObtenerDatoSicad("SELECT * From Pagos WHERE IDPago ='" + Request.QueryString["IDPago"] + "'");

        if (dtbuscarid.Rows.Count > 0)
        {
            editar = "Editar";
            DataRow row = dtbuscarid.Rows[0];
            TxtPago.Text = row["fecha"].ToString();
            TxtFecha.Text = row["pago"].ToString();
            TxtPago.Text = row["notas"].ToString();
            CmbTipoPago.SelectedValue = row["Tipopago"].ToString();
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
        if (Session["editar"].ToString() == "Editar")
        {
            conn.ObtenerDatoSicad("Update   Pagos set fecha='" + TxtFecha.Text + "', Pago='" + TxtPago.Text + "', notas='" + TxtNotas.Value + "', tipopago='" + CmbTipoPago.SelectedValue + "' where  IDPago ='" + Request.QueryString["idjuzgado"] + "'");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Oops', 'Usuario o Contraseña incorrecta!', 'error') </script>", false);

            TxtFecha.Text = "";
            TxtPago.Text = "";
            TxtNotas.Value = "";
            CmbTipoPago.SelectedIndex = 0;
            TxtFecha.Focus();
        }
        else
        {
            conn.ObtenerDatoSicad("INSERT INTO   Pagos(fecha, pago, notas, tipopago) VALUES('" + TxtFecha.Text + "', '" + TxtPago.Text + "', '" + TxtNotas.Value + "', '" + CmbTipoPago.SelectedValue+ "')");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Oops', 'Usuario o Contraseña incorrecta!', 'error') </script>", false);

            TxtFecha.Text = "";
            TxtPago.Text = "";
            TxtNotas.Value = "";
            CmbTipoPago.SelectedIndex = 0;
            TxtFecha.Focus();
        }
    }

    protected void BtnCancelarjuzgado_Click(object sender, EventArgs e)
    {
        TxtFecha.Text = "";
        TxtPago.Text = "";
        TxtNotas.Value = "";
        CmbTipoPago.SelectedIndex = 0;
        TxtFecha.Focus();

    }

    protected void BtnRegresarlistajuzgados_Click(object sender, EventArgs e)
    {
        Response.Redirect("juzgadosver.aspx");

    }
}
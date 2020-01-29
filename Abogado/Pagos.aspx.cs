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

        if (!IsPostBack)
        {

            DataTable dtbuscarid = conn.ObtenerDatoSicad("SELECT * From Pagos WHERE IDPago ='" + Request.QueryString["IDPago"] + "'");

        if (dtbuscarid.Rows.Count > 0)
        {
   
            editar = "Editar";
            DataRow row = dtbuscarid.Rows[0];
            TxtFecha.Text = Convert.ToDateTime(row["fecha"]).ToString("yyyy-MM-dd");
            TxtPago.Text = row["pago"].ToString();
            TxtNotas.Value = row["notas"].ToString();
            CmbTipoPago.SelectedValue = row["Tipopago"].ToString();
            Session["editar"] = editar;

        }
        else
        {
            editar = "Agregar";
            Session["editar"] = editar;
        }


        DataTable dtbuscaridx = conn.ObtenerDatoSicad("SELECT Cliente.IDCliente, Cliente.nombre, Cliente.apellidopaterno, Cliente.apellidomaterno, Tramites.IDAsunto, Tramites.costo, Tramites.fechainicio, Tramites.fechatermino, Asunto.asunto, Tramites.IDTramite FROM  Tramites INNER JOIN Cliente ON Tramites.IDCliente = Cliente.IDCliente INNER JOIN Asunto ON Tramites.IDAsunto = Asunto.IDAsunto WHERE Tramites.IDTramite='" + Request.QueryString["IDTramite"] + "'");

        if (dtbuscaridx.Rows.Count > 0)
        {


            DataRow row = dtbuscaridx.Rows[0];
            TxtCliente.Text = row["nombre"].ToString() + ' ' + row["apellidopaterno"].ToString() + ' ' + row["apellidomaterno"].ToString();
            TxtAsunto.Text = row["asunto"].ToString();
            TxtFechaInicio.Text =  Convert.ToDateTime(row["fechainicio"]).ToString("yyyy-MM-dd");
                TxtFechaTermino.Text =  Convert.ToDateTime(row["fechatermino"]).ToString("yyyy-MM-dd");
                TxtTotal.Text = row["Costo"].ToString();
        }
        else
        {

        }


        DataTable dtpagos = conn.ObtenerDatoSicad("SELECT ISNULL(SUM(Pagos.pago), 0) AS pago FROM  Pagos INNER JOIN Tramites ON Pagos.IDTramite = Tramites.IDTramite INNER JOIN Cliente ON Tramites.IDCliente = Cliente.IDCliente where  Pagos.IDTramite='" + Request.QueryString["IDTramite"] + "'");

        if (dtpagos.Rows.Count > 0)
        {


            DataRow row = dtpagos.Rows[0];

   
            TxtDebe.Text = row["pago"].ToString();

            int total;

            total = int.Parse(TxtTotal.Text) - int.Parse(TxtDebe.Text) ;

            TxtDebe.Text = total.ToString();
        }
        else
        {

        }

        }

    }

    protected void BtnAgregarjuzgado_Click(object sender, EventArgs e)
    {
        if (Session["editar"].ToString() == "Editar")
        {
            if (TxtFecha.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar fecha de pago', 'warning') </script>", false);
            }
            else if (TxtPago.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un pago', 'warning') </script>", false);
            }
            else if (CmbTipoPago.SelectedIndex == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un tipo de pago', 'warning') </script>", false);
            }
            else if (TxtNotas.Value == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar una nota', 'warning') </script>", false);
            }
            else
            {

                conn.ObtenerDatoSicad("Update   Pagos set fecha='" + TxtFecha.Text + "', Pago='" + TxtPago.Text + "', notas='" + TxtNotas.Value + "', tipopago='" + CmbTipoPago.SelectedValue + "' where  IDPago ='" + Request.QueryString["IDPago"] + "'");


            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Se edito pago exitosamente', '', 'success') </script>", false);

            TxtFecha.Text = "";
            TxtPago.Text = "";
            TxtNotas.Value = "";
            CmbTipoPago.SelectedIndex = 0;
            TxtFecha.Focus();
            }
        }
        else
        {

            if (TxtFecha.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar fecha de pago', 'warning') </script>", false);
            }
            else if (TxtPago.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un pago', 'warning') </script>", false);
            }
            else if (CmbTipoPago.SelectedIndex == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un tipo de pago', 'warning') </script>", false);
            }
            else if (TxtNotas.Value == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar una nota', 'warning') </script>", false);
            }
            else
            {

                conn.ObtenerDatoSicad("INSERT INTO   Pagos(IDTramite,fecha, pago, notas, tipopago) VALUES('" + Request.QueryString["IDTramite"] + "','" + TxtFecha.Text + "', '" + TxtPago.Text + "', '" + TxtNotas.Value + "', '" + CmbTipoPago.SelectedValue+ "')");

    

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Se agrego pago exitosamente', '', 'success') </script>", false);


            TxtFecha.Text = "";
            TxtPago.Text = "";
            TxtNotas.Value = "";
            CmbTipoPago.SelectedIndex = 0;
            TxtFecha.Focus();


            }
        }


        DataTable dtpagos = conn.ObtenerDatoSicad("SELECT ISNULL(SUM(Pagos.pago), 0) AS pago FROM  Pagos INNER JOIN Tramites ON Pagos.IDTramite = Tramites.IDTramite INNER JOIN Cliente ON Tramites.IDCliente = Cliente.IDCliente where  Pagos.IDTramite='" + Request.QueryString["IDTramite"] + "'");

        if (dtpagos.Rows.Count > 0)
        {


            DataRow row = dtpagos.Rows[0];


            TxtDebe.Text = row["pago"].ToString();

            int total;

            total = int.Parse(TxtTotal.Text) - int.Parse(TxtDebe.Text);

            TxtDebe.Text = total.ToString();
        }
        else
        {

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

    protected void BtnRegresarlistaPagos_Click(object sender, EventArgs e)
    {

        Response.Redirect("Pagosver.aspx?IDTramite=" + Request.QueryString["IDTramite"] + "");


    }

}
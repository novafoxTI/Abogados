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
        try
        {

            if (!IsPostBack)
            {
                DataTable dtbuscarid = conn.ObtenerDatoSicad("SELECT asunto.idasunto,Cliente.IDCliente, Tramites.fechainicio, Tramites.fechatermino, Tramites.costo, Tramites.tipopago, Tramites.estatus, Asunto.asunto, Cliente.nombre + ' ' + Cliente.apellidopaterno + ' ' + Cliente.apellidomaterno AS nombre FROM Tramites INNER JOIN Cliente ON Tramites.IDCliente = Cliente.IDCliente INNER JOIN Asunto ON Tramites.IDAsunto = Asunto.IDAsunto where tramites.idtramite = '" + Request.QueryString["IDTramite"] + "'");
                if (dtbuscarid.Rows.Count > 0)
                {


                    editar = "Editar";
                    DataRow row = dtbuscarid.Rows[0];
                    CmbCliente.Text = row["idcliente"].ToString();
                    CmbAsunto.Text = row["idasunto"].ToString();

                    DateTime dti = Convert.ToDateTime(row["fechainicio"].ToString());
                    TxtFechaInicio.Text = String.Format("{0:yyyy-MM-dd}", dti).ToString();

                    DateTime dtf = Convert.ToDateTime(row["fechatermino"].ToString());
                    TxtFechaTermino.Text = String.Format("{0:yyyy-MM-dd}", dtf).ToString();

                    TxtCosto.Text = row["costo"].ToString();
                    CmbTipoPago.Text = row["tipopago"].ToString();
                    CmbEstatus.Text = row["estatus"].ToString();

                    Session["editar"] = editar;

                }
                else
                {
                    editar = "Agregar";
                    Session["editar"] = editar;
                }

                CmbCliente.DataValueField = "IDCliente";
                CmbCliente.DataTextField = "nombre";
                CmbCliente.DataSource = conn.ObtenerDatoSicad("SELECT IDCliente,nombre + ' ' + apellidopaterno + ' ' + apellidomaterno AS nombre, curp, rfc, calle, numero, colonia, cp, municipio, ciudad, telefono, celular FROM Cliente");
                CmbCliente.DataBind();

                CmbAsunto.DataValueField = "IDAsunto";
                CmbAsunto.DataTextField = "asunto";
                CmbAsunto.DataSource = conn.ObtenerDatoSicad("SELECT * FROM Asunto");
                CmbAsunto.DataBind();

            }
        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);
        }
    }

    protected void BtnAgregarTramite_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["editar"].ToString() == "Editar")
            {
                conn.ObtenerDatoSicad("Update   tramites set idcliente='" + CmbCliente.SelectedValue + "', idasunto='" + CmbAsunto.SelectedValue + "', fechainicio='" + TxtFechaInicio.Text + "', fechatermino='" + TxtFechaTermino.Text + "', costo='" + TxtCosto.Text + "', tipopago='" + CmbTipoPago.SelectedValue + "', estatus='" + CmbEstatus.SelectedValue + "' where  IDtramite='" + Request.QueryString["IDTramite"] + "'");

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Se actualizó exitosamente', '', 'success') </script>", false);

                CmbCliente.SelectedValue = "-1";
                CmbAsunto.SelectedValue = "-1";
                TxtFechaInicio.Text = "";
                TxtFechaTermino.Text = "";
                TxtCosto.Text = "";
                CmbTipoPago.SelectedValue = "-1";
                CmbEstatus.SelectedValue = "Pendiente";
            }
            else {

            

            if (CmbCliente.SelectedValue == "-1")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe seleccionar un cliente', 'warning') </script>", false);
            }
            else if (CmbAsunto.SelectedValue == "-1")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe seleccionar un asunto', 'warning') </script>", false);
            }
            else if (TxtFechaInicio.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe seleccionar una fecha inicial', 'warning') </script>", false);
            }
            else if (TxtFechaTermino.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe seleccionar una fecha final', 'warning') </script>", false);
            }
            else if (TxtCosto.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un costo', 'warning') </script>", false);
            }
            else if (CmbTipoPago.SelectedValue == "-1")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe seleccionar un tipo de pago', 'warning') </script>", false);
            }
            else if (CmbEstatus.SelectedValue=="-1")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe seleccionar un estatus', 'warning') </script>", false);
            }
            else
            {
                conn.ObtenerDatoSicad("INSERT INTO   Tramites( IDCliente, IDAsunto, fechainicio, fechatermino, costo, tipopago,estatus) VALUES('" + CmbCliente.SelectedValue + "', '" + CmbAsunto.SelectedValue + "', '" + TxtFechaInicio.Text + "', '" + TxtFechaTermino.Text + "', '" + TxtCosto.Text + "', '" + CmbTipoPago.SelectedValue + "', '" + CmbEstatus.SelectedValue + "')");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Se guardó exitosamente', '', 'success') </script>", false);

                CmbCliente.SelectedValue = "-1";
                CmbAsunto.SelectedValue = "-1";
                TxtFechaInicio.Text = "";
                TxtFechaTermino.Text = "";
                TxtCosto.Text = "";
                CmbTipoPago.SelectedValue = "-1";
                CmbEstatus.SelectedValue = "Pendiente";


            }
            }

        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);
        }

    }

    protected void BtnCancelarCliente_Click(object sender, EventArgs e)
    {

        
    }



    protected void BtnRegresarlistaTramite_Click(object sender, EventArgs e)
    {

        Response.Redirect("Tramitesver.aspx");

    }
}

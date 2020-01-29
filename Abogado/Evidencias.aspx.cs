using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Evidencias : System.Web.UI.Page
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
                
                TxtNotas.Value = row["notas"].ToString();
                
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
                TxtFechaInicio.Text = Convert.ToDateTime(row["fechainicio"]).ToString("yyyy-MM-dd");
                TxtFechaTermino.Text = Convert.ToDateTime(row["fechatermino"]).ToString("yyyy-MM-dd");
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

                total = int.Parse(TxtTotal.Text) - int.Parse(TxtDebe.Text);

                TxtDebe.Text = total.ToString();
            }
            else
            {

            }

        }

    }
}
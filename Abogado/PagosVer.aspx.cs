using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PagosVer : System.Web.UI.Page
{

    private CNX conn = new CNX();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {




                DataTable dtbuscarid = conn.ObtenerDatoSicad("SELECT Cliente.IDCliente,Pagos.IDPago, Pagos.IDTramite, Pagos.fecha, Pagos.pago, Pagos.notas, Pagos.tipopago, Cliente.nombre, Cliente.apellidopaterno, Cliente.apellidomaterno, Tramites.IDAsunto, Tramites.costo, Tramites.fechainicio, Tramites.fechatermino, Asunto.asunto FROM Pagos INNER JOIN Tramites ON Pagos.IDTramite = Tramites.IDTramite INNER JOIN Cliente ON Tramites.IDCliente = Cliente.IDCliente INNER JOIN Asunto ON Tramites.IDAsunto = Asunto.IDAsunto WHERE Cliente.IDCliente ='10'");

                if (dtbuscarid.Rows.Count > 0)
                {

            
                    DataRow row = dtbuscarid.Rows[0];
                    TxtCliente.Text = row["nombre"].ToString() + ' ' + row["apellidopaterno"].ToString() + ' ' + row["apellidomaterno"].ToString();
                    TxtAsunto.Text = row["asunto"].ToString();
                    TxtFechaInicio.Text = row["fechainicio"].ToString();
                    TxtFechaTermino.Text = row["fechatermino"].ToString();

                }
                else
                {
                  
                }


                DtgJuzgados.DataSource = conn.ObtenerDatoSicad("SELECT Pagos.IDPago, Pagos.IDTramite, Pagos.fecha, Pagos.pago, Pagos.notas, Pagos.tipopago, Cliente.nombre, Cliente.apellidopaterno, Cliente.apellidomaterno, Tramites.IDAsunto, Tramites.costo, Tramites.fechainicio, Tramites.fechatermino FROM  Pagos INNER JOIN Tramites ON Pagos.IDTramite = Tramites.IDTramite INNER JOIN Cliente ON Tramites.IDCliente = Cliente.IDCliente where  Pagos.IDTramite='" + Request.QueryString["IDTramite"] + "'");
                DtgJuzgados.DataBind();

            }

            catch (Exception ex)
            {

            }

        }

    }

    protected void btnEliminarJuzgado_Click(object sender, EventArgs e)
    {

        LinkButton btn = (LinkButton)(sender);

        conn.ObtenerDatoSicad("delete from Cliente where IDCliente = '" + btn.CommandArgument + "'");

        DtgJuzgados.DataSource = conn.ObtenerDatoSicad("select * from Cliente");
        DtgJuzgados.DataBind();


    }


    protected void btnEditarJuzgado_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        Response.Redirect("Clientes.aspx?IDCliente= " + btn.CommandArgument + "");


    }

    protected void btnAgregarJuzgado_Click(object sender, EventArgs e)
    {

        Response.Redirect("Tramites.aspx");


    }

}
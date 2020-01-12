using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tramitesver : System.Web.UI.Page
{
    private CNX conn = new CNX();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {

                DtgJuzgados.DataSource = conn.ObtenerDatoSicad("SELECT Tramites.IDTramite, ISNULL(CONVERT(varchar, Tramites.fechainicio, 104), '') AS fechainicio,  ISNULL(CONVERT(varchar, Tramites.fechatermino, 104), '') AS fechatermino, Tramites.costo, Tramites.tipopago, Asunto.asunto, Cliente.nombre + ' ' + Cliente.apellidopaterno + ' ' + Cliente.apellidomaterno AS Nombre,Tramites.estatus FROM  Tramites INNER JOIN Cliente ON Tramites.IDCliente = Cliente.IDCliente INNER JOIN Asunto ON Tramites.IDAsunto = Asunto.IDAsunto");
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


    protected void btnPagos_Click(object sender, EventArgs e)
    {

        LinkButton btn = (LinkButton)(sender);

   
        Response.Redirect("PagosVer.aspx?IDTramite=" + btn.CommandArgument + "");




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
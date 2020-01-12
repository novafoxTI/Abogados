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

                DtgTramites.DataSource = conn.ObtenerDatoSicad("SELECT Tramites.IDTramite, ISNULL(CONVERT(varchar, Tramites.fechainicio, 104), '') AS fechainicio,  ISNULL(CONVERT(varchar, Tramites.fechatermino, 104), '') AS fechatermino, Tramites.costo, Tramites.tipopago, Asunto.asunto, Cliente.nombre + ' ' + Cliente.apellidopaterno + ' ' + Cliente.apellidomaterno AS Nombre,Tramites.estatus FROM  Tramites INNER JOIN Cliente ON Tramites.IDCliente = Cliente.IDCliente INNER JOIN Asunto ON Tramites.IDAsunto = Asunto.IDAsunto");
                DtgTramites.DataBind();

            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

    }

    protected void btnEliminarTramite_Click(object sender, EventArgs e)
    {

        LinkButton btn = (LinkButton)(sender);

        try
        {

       
        conn.ObtenerDatoSicad("delete from tramites where IDtramite = '" + btn.CommandArgument + "'");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Se eliminó exitosamente', 'success') </script>", false);

            DtgTramites.DataSource = conn.ObtenerDatoSicad("SELECT Tramites.IDTramite, ISNULL(CONVERT(varchar, Tramites.fechainicio, 104), '') AS fechainicio,  ISNULL(CONVERT(varchar, Tramites.fechatermino, 104), '') AS fechatermino, Tramites.costo, Tramites.tipopago, Asunto.asunto, Cliente.nombre + ' ' + Cliente.apellidopaterno + ' ' + Cliente.apellidomaterno AS Nombre,Tramites.estatus FROM  Tramites INNER JOIN Cliente ON Tramites.IDCliente = Cliente.IDCliente INNER JOIN Asunto ON Tramites.IDAsunto = Asunto.IDAsunto");
            DtgTramites.DataBind();
        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);
        }

    }


    protected void btnPagos_Click(object sender, EventArgs e)
    {

        LinkButton btn = (LinkButton)(sender);

   
        Response.Redirect("PagosVer.aspx?IDTramite=" + btn.CommandArgument + "");




    }


    protected void btnEditarJuzgado_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        Response.Redirect("Tramites.aspx?IDTramite= " + btn.CommandArgument + "");


    }

    protected void btnAgregarJuzgado_Click(object sender, EventArgs e)
    {

        Response.Redirect("Tramites.aspx");


    }
}
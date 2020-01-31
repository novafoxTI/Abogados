using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clientesver : System.Web.UI.Page
{
    private CNX conn = new CNX();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {

                DtgJuzgados.DataSource = conn.ObtenerDatoSicad("select IDCliente,(nombre + ' ' + apellidopaterno + ' ' + apellidomaterno) AS nombre, curp, rfc, calle, numero, colonia, cp, municipio, ciudad, telefono, celular from Cliente");
                DtgJuzgados.DataBind();

            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

    }

    protected void btnEliminarJuzgado_Click(object sender, EventArgs e)
    {
        try
        {

            LinkButton btn = (LinkButton)(sender);
            conn.ObtenerDatoSicad("delete from Cliente where IDCliente = '" + btn.CommandArgument + "'");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Se eliminó exitosamente', '', 'success') </script>", false);
            DtgJuzgados.DataSource = conn.ObtenerDatoSicad("select * from Cliente");
            DtgJuzgados.DataBind();

        }
        catch ( Exception ex)
        {
            Response.Write(ex.Message);
        }
    }


    protected void btnEditarJuzgado_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        Response.Redirect("Clientes.aspx?IDCliente= " + btn.CommandArgument + "");

    }

    protected void btnAgregarJuzgado_Click(object sender, EventArgs e)
    {
        Response.Redirect("Clientes.aspx");
    }

}
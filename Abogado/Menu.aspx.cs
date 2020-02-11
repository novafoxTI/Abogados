using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Menu : System.Web.UI.Page
{
    private CNX conn = new CNX();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {



                DtgActividades.DataSource= conn.ObtenerDatoSicad("SELECT        event.event_id, event.description, event.title, event.event_start, event.event_end, event.place, Juzgados.nombre AS Juzgado, Cliente.nombre + ' ' + Cliente.apellidopaterno + ' ' + Cliente.apellidomaterno AS Cliente, event.estatus FROM event LEFT OUTER JOIN Juzgados ON event.IDJuzgado = Juzgados.IDJuzgado LEFT OUTER JOIN Cliente ON event.IDCliente = Cliente.IDCliente where event.estatus='Pendiente' ORDER BY cliente DESC");
            DtgActividades.DataBind();

            DataTable dtbuscarid = conn.ObtenerDatoSicad("SELECT COUNT(*) AS contar  FROM Tramites");

            if (dtbuscarid.Rows.Count > 0)
            {

                DataRow row = dtbuscarid.Rows[0];
                LblContAsuntos.Text =  Convert.ToInt32(row["contar"]).ToString();

            }
            else
            {
           
            }


            DataTable dtusuario = conn.ObtenerDatoSicad("SELECT *   FROM Usuario where ID='"+ Request.QueryString["IDUsuario"]  + "'");

            if (dtusuario.Rows.Count > 0)
            {

                DataRow row = dtusuario.Rows[0];
                TxtUsuario.Text = Convert.ToString(row["nombre"]).ToString();

            }
            else
            {

            }


            DataTable dtbuscarid1 = conn.ObtenerDatoSicad("SELECT COUNT(*) AS contar  FROM Juzgados");

            if (dtbuscarid1.Rows.Count > 0)
            {

                DataRow row = dtbuscarid1.Rows[0];
                LblContarJuzgados.Text = Convert.ToInt32(row["contar"]).ToString();

            }
            else
            {

            }


            DataTable dtbuscarid2 = conn.ObtenerDatoSicad("SELECT COUNT(*) AS contar  FROM Cliente");

            if (dtbuscarid2.Rows.Count > 0)
            {

                DataRow row = dtbuscarid2.Rows[0];
                LblContarClientes.Text = Convert.ToInt32(row["contar"]).ToString();

            }
            else
            {

            }

            
            DataTable dtbuscarid3 = conn.ObtenerDatoSicad("SELECT COUNT(*) AS contar  FROM Asunto");

            if (dtbuscarid3.Rows.Count > 0)
            {

                DataRow row = dtbuscarid3.Rows[0];
                LblContarTramites.Text = Convert.ToInt32(row["contar"]).ToString();

            }
            else
            {

            }



        }

    }


    protected void btnEditarEvento(object sender, EventArgs e)
    {
      
            LinkButton btn = (LinkButton)(sender);
            Response.Redirect("actividades.aspx?IDActividad= " + btn.CommandArgument + "");
  
    }



    protected void btnEliminarevento(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        try
        {
            conn.ObtenerDatoSicad("delete from Event where event_id = '" + btn.CommandArgument + "'");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Se eliminó exitosamente', '', 'success') </script>", false);
            DtgActividades.DataSource = conn.ObtenerDatoSicad("SELECT        event.event_id, event.description, event.title, event.event_start, event.event_end, event.place, Juzgados.nombre AS Juzgado, Cliente.nombre + ' ' + Cliente.apellidopaterno + ' ' + Cliente.apellidomaterno AS Cliente, event.estatus FROM event LEFT OUTER JOIN Juzgados ON event.IDJuzgado = Juzgados.IDJuzgado LEFT OUTER JOIN Cliente ON event.IDCliente = Cliente.IDCliente where event.estatus='Pendiente' ORDER BY cliente DESC");
            DtgActividades.DataBind();
        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);
        }
    }



    protected void btnAgregarActividad_Click(object sender, EventArgs e)
    {
        try
        {

            Response.Redirect("Actividades.aspx");

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
}


}
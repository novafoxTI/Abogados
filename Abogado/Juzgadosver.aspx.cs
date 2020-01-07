using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Juzgadosver : System.Web.UI.Page
{
    private CNX conn = new CNX();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {

                DtgJuzgados.DataSource = conn.ObtenerDatoSicad("select * from Juzgados");
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

        conn.ObtenerDatoSicad("delete from Juzgados where IDJuzgado = '" + btn.CommandArgument + "'");

        DtgJuzgados.DataSource = conn.ObtenerDatoSicad("select * from Juzgados");
        DtgJuzgados.DataBind();

    
    }


    protected void btnEditarJuzgado_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        Response.Redirect("juzgados.aspx?idjuzgado= " + btn.CommandArgument + "");


    }

    protected void btnAgregarJuzgado_Click(object sender, EventArgs e)
    {

        Response.Redirect("juzgados.aspx");


    }


}
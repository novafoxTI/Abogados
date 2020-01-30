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

            DataTable dtbuscarid = conn.ObtenerDatoSicad("SELECT COUNT(*) AS contar  FROM Tramites");

            if (dtbuscarid.Rows.Count > 0)
            {

                DataRow row = dtbuscarid.Rows[0];
                LblContAsuntos.Text =  Convert.ToInt32(row["contar"]).ToString();

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
    }
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class Actividades : System.Web.UI.Page
{
  
   
    private CNX conn = new CNX();
    string editar;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {

                DataTable dtbuscarid = conn.ObtenerDatoSicad("SELECT event.IDJuzgado,event.IDCliente,event.event_id, event.description, event.title, event.event_start, event.event_end, event.place, Juzgados.nombre AS Juzgado, Cliente.nombre AS cliente, event.estatus FROM event LEFT OUTER JOIN Juzgados ON event.IDJuzgado = Juzgados.IDJuzgado LEFT OUTER JOIN Cliente ON event.IDCliente = Cliente.IDCliente  where event.event_id = '" + Request.QueryString["IDActividad"] + "'");
                if (dtbuscarid.Rows.Count > 0)
                {

                    editar = "Editar";
                    DataRow row = dtbuscarid.Rows[0];



                    if (DBNull.Value.Equals(row["IDCliente"]) == true)
                    {
                        CmbTipoActividad.SelectedValue = "Personal";
                    }
                    else
                    {
                        CmbCliente.SelectedValue = row["IDCliente"].ToString();
                        CmbTipoActividad.SelectedValue = "Cliente";
                        Mostrarcliente.Visible = true;
                    }

                    if (DBNull.Value.Equals(row["IDJuzgado"]) == true)
                    {
                    }
                    else
                    {
                        CmbJuzgados.SelectedValue = row["IDJuzgado"].ToString();
                        MostrarLugar.Visible = true;
                    }

                


                    TxtAsunto.Text = row["title"].ToString();
                    TxtNotas.Text = row["description"].ToString();

                    CmbEstatus.SelectedValue= row["estatus"].ToString();

                    DateTime dti = Convert.ToDateTime(row["event_start"].ToString());
                    TxtFechaInicio.Text = String.Format("{0:yyyy-MM-ddThh:mm}", dti).ToString();

                    DateTime dtf = Convert.ToDateTime(row["event_end"].ToString());
                    TxtFechaTermino.Text = String.Format("{0:yyyy-MM-ddThh:mm}", dtf).ToString();

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

                CmbJuzgados.DataValueField = "IDJuzgado";
                CmbJuzgados.DataTextField = "nombre";
                CmbJuzgados.DataSource = conn.ObtenerDatoSicad("SELECT * FROM Juzgados");
                CmbJuzgados.DataBind();
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
            if (CmbTipoActividad.Text=="Personal")
            { 
            if (TxtAsunto.Text == "")
            {
               ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un nombre', 'warning') </script>", false);
                TxtAsunto.Focus();
                return;
            }
            if (TxtNotas.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un nombre', 'warning') </script>", false);
                TxtNotas.Focus();
                return;
            }

            if (TxtFechaInicio.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un nombre', 'warning') </script>", false);
                TxtNotas.Focus();
                return;
            }

            if (TxtFechaTermino.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un nombre', 'warning') </script>", false);
                TxtNotas.Focus();
                return;
            }

                DateTime dti1 = Convert.ToDateTime(TxtFechaInicio.Text);
                TxtFechaInicio.Text = String.Format("{0:yyyy-MM-dd HH:mm:ss}", dti1).ToString();

                DateTime dtf1 = Convert.ToDateTime(TxtFechaTermino.Text);
                TxtFechaTermino.Text = String.Format("{0:yyyy-MM-dd HH:mm:ss}", dtf1).ToString();

                if (Session["editar"].ToString() == "Editar")
                {
                    conn.ObtenerDatoSicad("Update   event set  estatus='" + CmbEstatus.SelectedValue + "',description='" + TxtNotas.Text + "', title='" + TxtAsunto.Text + "', event_start='" + TxtFechaInicio.Text + "', event_end='" + TxtFechaTermino.Text + "', cliente='0', personal='1'  where  event_id='" + Request.QueryString["IDActividad"] + "'");

                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Se ha editado con éxito', 'success') </script>", false);
                    TxtAsunto.Text = "";
                    TxtNotas.Text = "";
                    CmbEstatus.SelectedIndex = 0;
                    TxtFechaInicio.Text = "";
                    TxtFechaTermino.Text = "";
                    CmbTipoActividad.SelectedIndex = 0;
                }
                else
                {

                    conn.ObtenerDatoSicad("INSERT INTO   event(description, title, event_start, event_end, cliente, personal,estatus) VALUES('" + TxtNotas.Text + "', '" + TxtAsunto.Text + "', '" + TxtFechaInicio.Text + "', '" + TxtFechaTermino.Text + "', '0', '1','" + CmbEstatus.SelectedValue + "')");
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Se ha guardado con éxito', 'success') </script>", false);

                    TxtAsunto.Text = "";
                    TxtNotas.Text = "";
                    CmbEstatus.SelectedIndex = 0;
                    TxtFechaInicio.Text = "";
                    TxtFechaTermino.Text = "";
                    CmbTipoActividad.SelectedIndex = 0;


                }



            }


            if (CmbTipoActividad.Text == "Cliente")
            {
                if (CmbCliente.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un nombre', 'warning') </script>", false);
                    TxtAsunto.Focus();
                    return;
                }

                if (TxtAsunto.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un nombre', 'warning') </script>", false);
                    TxtAsunto.Focus();
                    return;
                }
                if (TxtNotas.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un nombre', 'warning') </script>", false);
                    TxtNotas.Focus();
                    return;
                }
                if (CmbJuzgados.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un nombre', 'warning') </script>", false);
                    TxtAsunto.Focus();
                    return;
                }


           

                if (TxtFechaTermino.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un nombre', 'warning') </script>", false);
                    TxtNotas.Focus();
                    return;
                }


            DateTime dti = Convert.ToDateTime(TxtFechaInicio.Text);
            TxtFechaInicio.Text = String.Format("{0:yyyy-MM-dd HH:mm:ss}", dti).ToString();

            DateTime dtf = Convert.ToDateTime(TxtFechaTermino.Text);
            TxtFechaTermino.Text = String.Format("{0:yyyy-MM-dd HH:mm:ss}", dtf).ToString();

            if (Session["editar"].ToString() == "Editar")
                {
                    conn.ObtenerDatoSicad("Update   event set  IDJuzgado='" + CmbJuzgados.SelectedValue + "',IDCliente='" + CmbCliente.SelectedValue + "',estatus='" + CmbEstatus.SelectedValue  +"',description='"+ TxtNotas.Text + "', title='" + TxtAsunto.Text + "', event_start='" + TxtFechaInicio.Text + "', event_end='" + TxtFechaTermino.Text + "', cliente='0', personal='1'  where  event_id='" + Request.QueryString["IDActividad"] + "'");

                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Se ha editado con éxito', 'success') </script>", false);

                    CmbCliente.SelectedValue = "-1";

                    TxtAsunto.Text = "";
                    TxtNotas.Text = "";
                    CmbEstatus.SelectedIndex = 0;
                    TxtFechaInicio.Text = "";
                    TxtFechaTermino.Text = "";
                    CmbCliente.SelectedIndex = 0;
                    CmbJuzgados.SelectedIndex = 0;
                    CmbTipoActividad.SelectedIndex = 0;
                }
                else
                {

                   conn.ObtenerDatoSicad("INSERT INTO   event (description, title, event_start, event_end, IDCliente, cliente, personal, IDJuzgado,estatus) VALUES('" + TxtNotas.Text + "', '" + TxtAsunto.Text + "', '" + TxtFechaInicio.Text + "', '" + TxtFechaTermino.Text + "', '" + CmbCliente.SelectedValue + "', '1', '0', '" + CmbJuzgados.SelectedValue + "','" + CmbEstatus.SelectedValue + "')");
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Se ha guardado con éxito', 'success') </script>", false);

                    TxtAsunto.Text = "";
                    TxtNotas.Text = "";
                    CmbEstatus.SelectedIndex = 0;
                    TxtFechaInicio.Text = "";
                    TxtFechaTermino.Text = "";
                    CmbCliente.SelectedIndex = 0;
                    CmbJuzgados.SelectedIndex = 0;
                    CmbTipoActividad.SelectedIndex = 0;
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

    

    protected void BtnRegresarlistaActividades_Click(object sender, EventArgs e)
    {

        Response.Redirect("Menu.aspx");

    }


    protected void CmbTipoActividad_SelectedIndexChanged(object sender, EventArgs e)
    {
        

                 if (CmbTipoActividad.SelectedValue == "Personal")
        {
            Mostrarcliente.Visible = false;
            MostrarLugar.Visible = false;
        }

        if (CmbTipoActividad.SelectedValue == "Cliente")
        {
            Mostrarcliente.Visible = true;
            MostrarLugar.Visible = true;
        }




    }



}
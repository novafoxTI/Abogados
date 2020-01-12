using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clientes : System.Web.UI.Page
{
    private CNX conn = new CNX();
    string editar;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                DataTable dtbuscarid = conn.ObtenerDatoSicad("SELECT * From Cliente WHERE IDCliente ='" + Request.QueryString["IDCliente"] + "'");

                if (dtbuscarid.Rows.Count > 0)
                {
                    
                    editar = "Editar";
                    DataRow row = dtbuscarid.Rows[0];
                    TxtNombre.Text = row["nombre"].ToString();
                    TxtApellidoPaterno.Text = row["apellidopaterno"].ToString();
                    TxtApellidoMaterno.Text = row["apellidomaterno"].ToString();
                    TxtCurp.Text = row["curp"].ToString();
                    TxtRfc.Text = row["rfc"].ToString();
                    TxtCalle.Text = row["calle"].ToString();
                    TxtNumero.Text = row["numero"].ToString();
                    TxtColonia.Text = row["colonia"].ToString();
                    TxtCP.Text = row["cp"].ToString();
                    TxtCiudad.Text = row["ciudad"].ToString();
                    TxtMunicipio.Text = row["municipio"].ToString();
                    Txttelefono.Text = row["telefono"].ToString();
                    Txtcelular.Text = row["celular"].ToString();
                    Session["editar"] = editar;

                }
                else
                {
                    editar = "Agregar";
                    Session["editar"] = editar;
                }
            }
        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);
        }
    }

    protected void BtnAgregarCliente_Click(object sender, EventArgs e)
    {
        try
        {

       
        if (Session["editar"].ToString() == "Editar")
        {
            conn.ObtenerDatoSicad("Update   Cliente set nombre='" + TxtNombre.Text + "', apellidopaterno='" + TxtApellidoPaterno.Text + "', apellidomaterno='" + TxtApellidoMaterno.Text + "', curp='" + TxtCurp.Text + "', rfc='" + TxtRfc.Text + "', calle='" + TxtCalle.Text + "', numero='" + TxtNumero.Text + "', colonia='" + TxtColonia.Text + "', cp='" + TxtCP.Text + "', municipio='" + TxtMunicipio.Text + "', ciudad='" + TxtCiudad.Text + "', telefono='" + Txttelefono.Text + "', celular='" + Txtcelular.Text + "' where  IDCliente ='" + Request.QueryString["IDCliente"] + "'");

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Se actualizó exitosamente', '', 'success') </script>", false);
                TxtNombre.Text = "";
            TxtApellidoPaterno.Text = "";
            TxtApellidoMaterno.Text = "";
            TxtCurp.Text = "";
            TxtRfc.Text = "";
            TxtCalle.Text = "";
            TxtNumero.Text = "";
            TxtColonia.Text = "";
            TxtCP.Text = "";
            TxtCiudad.Text = "";
            TxtMunicipio.Text = "";
            Txttelefono.Text = "";
            Txtcelular.Text = "";
            TxtNombre.Focus();
        }
        else
        {
                if (TxtNombre.Text.Trim() == "") {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un nombre', 'warning') </script>", false);
                }
                else if (TxtApellidoPaterno.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un apellido', 'warning') </script>", false);
                } else if (TxtApellidoMaterno.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un materno', 'warning') </script>", false);
                } else if (TxtCurp.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar la curp', 'warning') </script>", false);
                } else if (TxtCalle.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar la calle', 'warning') </script>", false);
                } else if (TxtNumero.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar el número de casa', 'warning') </script>", false);
                } else if (TxtColonia.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar la colonia', 'warning') </script>", false);
                } else if (TxtCP.Text.Trim()=="")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar el código postal', 'warning') </script>", false);
                }
                else if(TxtCiudad.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar la ciudad', 'warning') </script>", false);
                }
                else if (TxtMunicipio.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar el municipio', 'warning') </script>", false);
                }
                else if(Txttelefono.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un número de teléfono', 'warning') </script>", false);
                }
                else if (Txtcelular.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Aviso!', 'Debe ingresar un número de celular', 'warning') </script>", false);
                }
                else
                {
                    conn.ObtenerDatoSicad("INSERT INTO   Cliente(nombre, apellidopaterno, apellidomaterno, curp, rfc, calle, numero, colonia, cp, municipio, ciudad, telefono, celular) VALUES('" + TxtNombre.Text + "', '" + TxtApellidoPaterno.Text + "', '" + TxtApellidoMaterno.Text + "', '" + TxtCurp.Text + "', '" + TxtRfc.Text + "', '" + TxtCalle.Text + "', '" + TxtNumero.Text + "', '" + TxtColonia.Text + "', '" + TxtCP.Text + "', '" + TxtMunicipio.Text + "', '" + TxtCiudad.Text + "', '" + Txttelefono.Text + "', '" + Txtcelular.Text + "')");

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Se agregó exitosamente', 'Ya se encuentra disponible en la lista', 'success') </script>", false);

                    TxtNombre.Text = "";
                    TxtApellidoPaterno.Text = "";
                    TxtApellidoMaterno.Text = "";
                    TxtCurp.Text = "";
                    TxtRfc.Text = "";
                    TxtCalle.Text = "";
                    TxtNumero.Text = "";
                    TxtColonia.Text = "";
                    TxtCP.Text = "";
                    TxtCiudad.Text = "";
                    TxtMunicipio.Text = "";
                    Txttelefono.Text = "";
                    Txtcelular.Text = "";
                    TxtNombre.Focus();
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

        TxtNombre.Text = "";
        TxtApellidoPaterno.Text = "";
        TxtApellidoMaterno.Text = "";
        TxtCurp.Text = "";
        TxtRfc.Text = "";
        TxtCalle.Text = "";
        TxtNumero.Text = "";
        TxtColonia.Text = "";
        TxtCP.Text = "";
        TxtCiudad.Text = "";
        TxtMunicipio.Text = "";
        Txttelefono.Text = "";
        Txtcelular.Text = "";
        TxtNombre.Focus();

    }



    protected void BtnRegresarlistaClientes_Click(object sender, EventArgs e)
    {

        Response.Redirect("Clientesver.aspx");

    }
}
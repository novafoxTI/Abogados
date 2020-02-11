using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using System.IO;


public partial class Login : System.Web.UI.Page
{
    CNX modelo = new CNX();
    string iniciodesesion;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnIngresar_Click(object sender, EventArgs e)
    {
        DataTable buscarU = new DataTable();
        buscarU = modelo.ObtenerDatoSicad("Select * from usuario where email= '" + usuario.Value + "' and password='" + pass.Value + "'");

        if (buscarU.Rows.Count > 0)
        {

            DataRow row = buscarU.Rows[0];
           string cliente = row["id"].ToString();


            //Se fija la URL sobre la que enviar la petición POST
            HttpWebRequest loHttp =
              (HttpWebRequest)WebRequest.Create("http://www.altiria.net/api/http");

            // Compone el mensaje a enviar
            // XX, YY y ZZ se corresponden con los valores de identificación del usuario en el sistema.
            string lcPostData =
              "cmd=sendsms&domainId=&login=eduardo-dm@hotmail.com&passwd=sbt4phdf&dest=528441011530&dest=528441011530" +
              "&msg=Mensaje de prueba";
            //No es posible utilizar el remitente en América pero sí en España y Europa
            //Descomentar la línea solo si se cuenta con un remitente autorizado por Altiria
            //cmd=cmd + "&senderId=remitente";

            // Se codifica en utf-8
            byte[] lbPostBuffer = System.Text.Encoding.GetEncoding("utf-8").GetBytes(lcPostData);
            loHttp.Method = "POST";
            loHttp.ContentType = "application/x-www-form-urlencoded";
            loHttp.ContentLength = lbPostBuffer.Length;

            //Fijamos tiempo de espera de respuesta = 60 seg
            loHttp.Timeout = 60000;
            String error = "";
            String response = "";
            // Envía la peticion
            
            {
                Stream loPostData = loHttp.GetRequestStream();
                loPostData.Write(lbPostBuffer, 0, lbPostBuffer.Length);
                loPostData.Close();
                // Prepara el objeto para obtener la respuesta
                HttpWebResponse loWebResponse = (HttpWebResponse)loHttp.GetResponse();
                // La respuesta vendría codificada en utf-8
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader loResponseStream =
                new StreamReader(loWebResponse.GetResponseStream(), enc);
                // Conseguimos la respuesta en una cadena de texto
                response = loResponseStream.ReadToEnd();
                loWebResponse.Close();
                loResponseStream.Close();
            }

            Response.Redirect("MenuControl.aspx?IDUsuario= " + cliente + "");
 
        }
        else {
             Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script language='JavaScript'> swal('Error', 'Usuario o Contraseña incorrecta!', 'error') </script>", false);
            usuario.Value = "";
            pass.Value = "";
        }
    }




}






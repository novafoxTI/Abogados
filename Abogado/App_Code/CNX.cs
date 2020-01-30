using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Configuration;

/// <summary>
/// Descripción breve de CNX
/// </summary>
public class CNX
{
    SqlConnection Conn;
    public  CNX() {
        
    }
        public DataTable ObtenerDatoSicad(string comando)
        {
            try
            {

            using (SqlConnection cnSql = new SqlConnection(ConfigurationManager.ConnectionStrings["Cnx"].ToString()))

         
                {
                    DataTable Dt;
                    SqlDataAdapter Da = new SqlDataAdapter();
                    SqlCommand Cmd = new SqlCommand();
                    if (cnSql.State == ConnectionState.Open)
                        cnSql.Open();
                    {
                        var withBlock = Cmd;
                        withBlock.CommandType = CommandType.Text;
                        withBlock.CommandText = comando;
                        withBlock.Connection = cnSql;
                    }
                    Da.SelectCommand = Cmd;
                    Dt = new DataTable();
                    // modelo.Configuration.ProxyCreationEnabled = False
                    Da.Fill(Dt);
                    if (cnSql.State == ConnectionState.Open)
                        cnSql.Close();
                    return Dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

/// <summary>
/// Descripción breve de CNX
/// </summary>
public class CNX
{
    SqlConnection Conn;
    public  CNX() {
        Conn = new SqlConnection(@"Data Source=BROWN;Initial Catalog=ABOGADOS; User id=admin;Password=123");
        
    }
        public DataTable ObtenerDatoSicad(string comando)
        {
            try
            {

                using (SqlConnection cnSql = new SqlConnection("Data Source = DESKTOP-KJDJCFV; initial Catalog = ABOGADOS; user = admin; password = 123456; MultipleActiveResultSets = True; App = EntityFramework"))

         
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
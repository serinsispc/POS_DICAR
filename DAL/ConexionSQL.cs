
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConexionSQL
    {
        public static String connectionString;
        public static SqlConnection connection;


        public static void ConexionBase()
        {
            connectionString = "data source =www.serinsispc.com; initial catalog = DBDicarDistribuciones; user id = emilianop; password = Ser1ns1s@2020*";
            connection = new SqlConnection(connectionString);
        }
        public static void AbrirConexion()
        {
            try
            {
                ConexionBase();
                if (connection.State != ConnectionState.Open)
                    connection.Open();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        public static void CerrarConexion()
        {
            try
            {
                if (ConexionSQL.connection.State == ConnectionState.Open)
                    ConexionSQL.connection.Close();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
    }
}

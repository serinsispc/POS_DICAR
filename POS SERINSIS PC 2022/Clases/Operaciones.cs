using sib_api_v3_sdk.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;

namespace POS_SERINSIS_PC_2022.Clases
{
    public class Operaciones
    {
        public bool CargarData(DataTable tbData)
        {
            bool resultado = true;
            using (SqlConnection cn = new SqlConnection(Configuracion.Conexion))
            {
                cn.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(cn))
                {

                    //ingresamos COLUMNAS ORIGEN | COLUMNAS DESTINOS
                    s.ColumnMappings.Add("Documento Identidad", "DocumentoIdentidad");
                    s.ColumnMappings.Add("Nombres", "Nombres");
                    s.ColumnMappings.Add("Telefono", "Telefono");
                    s.ColumnMappings.Add("Correo", "Correo");
                    s.ColumnMappings.Add("Ciudad", "Ciudad");

                    //definimos la tabla a cargar
                    s.DestinationTableName = "USUARIO";


                    s.BulkCopyTimeout = 1500;
                    try
                    {
                        s.WriteToServer(tbData);
                    }
                    catch (Exception e)
                    {
                        string st = e.Message;
                        resultado = false;
                    }


                }
            }

            return resultado;
        }
    }
}

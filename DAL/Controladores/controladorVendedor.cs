using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class controladorVendedor
    {
        // =====================================================
        // CRUD -> SP dbo.CRUD_Vendedor (JSON + funcion)
        // Boton: 0=INSERT, 1=UPDATE, 2=DELETE
        // =====================================================
        public static async Task<RespuestaCRUD> Crud(Vendedor vendedor, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(vendedor);
                return await Crud(json, Boton);
            }
            catch (Exception ex)
            {
                string error = ex.Message;

                return new RespuestaCRUD()
                {
                    estado = false,
                    idAfectado = 0,
                    mensaje = error
                };
            }
        }

        // Método base estilo tu patrón: Crud(string json, int funcion)
        public static async Task<RespuestaCRUD> Crud(string json, int funcion)
        {
            try
            {
                json = EscapeJsonForSql(json);

                var query = $"EXEC dbo.CRUD_Vendedor N'{json}', {funcion}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);

                return JsonConvert.DeserializeObject<RespuestaCRUD>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;

                return new RespuestaCRUD()
                {
                    estado = false,
                    idAfectado = 0,
                    mensaje = error
                };
            }
        }

        // =====================================================
        // LISTA COMPLETA (VIEW)
        // =====================================================
        public static async Task<List<V_Vendedor>> Lista_Completa()
        {
            try
            {
                var query = "SELECT * FROM V_Vendedor";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);

                return JsonConvert.DeserializeObject<List<V_Vendedor>>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // CONSULTAR POR ID (TABLA)
        // =====================================================
        public static async Task<Vendedor> Consultar_id(int IdVendedor)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM Vendedor WHERE id = {IdVendedor}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);

                // Normalmente devuelve JSON de tabla -> lista
                var lista = JsonConvert.DeserializeObject<List<Vendedor>>(respuesta);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // Escape JSON para SQL
        // =====================================================
        private static string EscapeJsonForSql(string json)
        {
            return string.IsNullOrEmpty(json) ? "" : json.Replace("'", "''");
        }
    }


}

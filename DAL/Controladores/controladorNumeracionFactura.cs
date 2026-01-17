using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controlador
{
    public class controladorNumeracionFactura
    {
        private const string SP_CRUD = "dbo.CRUD_ConsecutivoFactura";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // =====================================================
        // CRUD (NO lista) -> false, true
        // Boton: 0=INSERT | 1=UPDATE | 2=DELETE
        // =====================================================
        public static async Task<RespuestaCRUD> crud(ConsecutivoFactura consecutivoFactura, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(consecutivoFactura));
                var query = $"EXEC {SP_CRUD} N'{json}', {Boton}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return new RespuestaCRUD
                {
                    estado = false,
                    idAfectado = 0,
                    mensaje = error
                };
            }
        }

        // =====================================================
        // Consultar por idVenta (1 registro) -> false, true
        // =====================================================
        public static async Task<ConsecutivoFactura> Consultar_x_IdVenta(int idVenta)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM ConsecutivoFactura WITH (NOLOCK)
WHERE idVenta = {idVenta}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<ConsecutivoFactura>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

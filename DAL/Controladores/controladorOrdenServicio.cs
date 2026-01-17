using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores.Orden_Servicio
{
    public class controladorOrdenServicio
    {
        private const string SP_CRUD = "dbo.CRUD_OrdenServicio";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // =====================================================
        // CRUD (NO lista) -> false, true
        // Boton: 0=INSERT | 1=UPDATE | 2=DELETE
        // =====================================================
        public static async Task<RespuestaCRUD> CrearEditarEliminarOrden(Modelo.OrdenServicio objOrden, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(objOrden));
                var query = $"EXEC {SP_CRUD} N'{json}', {Boton}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(respuesta);
            }
            catch (Exception ex)
            {
                return new RespuestaCRUD
                {
                    estado = false,
                    idAfectado = 0,
                    mensaje = ex.Message
                };
            }
        }

        // =====================================================
        // CONSULTAR POR ID (1 registro) -> false, true
        // =====================================================
        public static async Task<Modelo.OrdenServicio> consultar_ID(int IDOrden)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM OrdenServicio WITH (NOLOCK)
WHERE id = {IDOrden}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<Modelo.OrdenServicio>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // HALLAR CONSECUTIVO (MAX(numeroOrdenServicio)+1) -> false, true
        // =====================================================
        public static async Task<int> HallarConsecutivo()
        {
            try
            {
                var query = @"
SELECT ISNULL(MAX(numeroOrdenServicio),0) + 1 AS consecutivo
FROM OrdenServicio WITH (NOLOCK);";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var row = JsonConvert.DeserializeObject<List<dynamic>>(jsonReal);
                return Convert.ToInt32(row[0].consecutivo);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
    }
}

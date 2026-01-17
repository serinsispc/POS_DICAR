using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorOrdenFabrica
    {
        private const string SP_CRUD = "dbo.CRUD_OrdenFabrica";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // =====================================================
        // CRUD (INSERT / UPDATE / DELETE) -> NO LISTA
        // Boton: 0=INSERT | 1=UPDATE | 2=DELETE
        // =====================================================
        public static async Task<RespuestaCRUD> CrearEditarElimminarOrdenFabrica(OrdenFabrica objOF, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(objOF));
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
        // CONSECUTIVO (MAX(numeroOrdenFabrica)+1) -> NO LISTA
        // =====================================================
        public static async Task<int> Consecutivo()
        {
            try
            {
                var query = @"
SELECT ISNULL(MAX(numeroOrdenFabrica),0) + 1 AS consecutivo
FROM OrdenFabrica WITH (NOLOCK);";

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

        // =====================================================
        // FILTRO POR ESTADO -> LISTA
        // =====================================================
        public static async Task<List<OrdenFabrica>> filtroEstado(string estado)
        {
            try
            {
                var e = (estado ?? string.Empty).Replace("'", "''");

                var query = $@"
SELECT *
FROM OrdenFabrica WITH (NOLOCK)
WHERE estadoOrdenFabricacion = '{e}'
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // 👈 LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<OrdenFabrica>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // CONSULTAR POR ID -> NO LISTA
        // =====================================================
        public static async Task<OrdenFabrica> consultarID(int ID)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM OrdenFabrica WITH (NOLOCK)
WHERE id = {ID}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<OrdenFabrica>>(jsonReal);
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

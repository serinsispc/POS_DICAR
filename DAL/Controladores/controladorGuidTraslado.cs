using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorGuidTraslado
    {
        private const string SP_CRUD = "dbo.CRUD_GuidTraslados";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // ==========================
        // CRUD (NO lista) -> false, true
        // Boton: 0=INSERT, 1=UPDATE, 2=DELETE
        // ==========================
        public static async Task<RespuestaCRUD> CrearEditarEliminar_GuidTraslado(GuidTraslados objGuidTraslado, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(objGuidTraslado));
                var query = $"EXEC {SP_CRUD} N'{json}', {Boton}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return new RespuestaCRUD { estado = false, idAfectado = 0, mensaje = error };
            }
        }

        // ==========================
        // Consultar por IdSede + Estado (1 registro)
        // NO lista -> false, true
        // ==========================
        public static async Task<GuidTraslados> Consultar_IdSede_Estado(int IdSede, int Estado)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM GuidTraslados WITH (NOLOCK)
WHERE idSedeTraslado = {IdSede}
  AND estadoGuidTraslado = {Estado}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<GuidTraslados>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // ==========================
        // Consultar por GuidTex (1 registro)
        // NO lista -> false, true
        // ==========================
        public static async Task<GuidTraslados> Consultar_Guid(string GuidTex)
        {
            try
            {
                var g = (GuidTex ?? string.Empty).Replace("'", "''");

                var query = $@"
SELECT TOP 1 *
FROM GuidTraslados WITH (NOLOCK)
WHERE guidTex = '{g}'
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<GuidTraslados>>(jsonReal);
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


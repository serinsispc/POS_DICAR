using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorPresentacion
    {
        private const string SP_CRUD = "dbo.CRUD_Presentacion";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // =====================================================
        // CRUD -> false, true
        // Boton: 0=INSERT | 1=UPDATE | 2=DELETE
        // Retorna RespuestaCRUD (estado, idAfectado, mensaje)
        // =====================================================
        public static async Task<RespuestaCRUD> CrearEditarEliminarPresentacion(Presentacion objPresentacion, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(objPresentacion));
                var query = $"EXEC {SP_CRUD} N'{json}', {Boton}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
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
        // LISTA (VIEW) -> true, true  (listas van true)
        // Nota: Conection_SQL devuelve string con JSON adentro
        // =====================================================
        public static async Task<List<SQL.Views.V_Presentacion>> ListaCompleta()
        {
            try
            {
                var query = "SELECT * FROM V_Presentacion WITH (NOLOCK) ORDER BY nombrePresentacion;";
                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<SQL.Views.V_Presentacion>>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // 1 registro por ID -> false, true
        // =====================================================
        public static async Task<Presentacion> ConsultarID(int IdPresentacion)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM Presentacion WITH (NOLOCK)
WHERE id = {IdPresentacion};";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                var lista = JsonConvert.DeserializeObject<List<Presentacion>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // 1 registro por nombre -> false, true
        // =====================================================
        public static async Task<Presentacion> ConsultarNombre(string nombre)
        {
            try
            {
                var n = (nombre ?? string.Empty).Replace("'", "''");

                var query = $@"
SELECT TOP 1 *
FROM Presentacion WITH (NOLOCK)
WHERE nombrePresentacion = N'{n}'
ORDER BY id DESC;";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                var lista = JsonConvert.DeserializeObject<List<Presentacion>>(jsonReal);
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

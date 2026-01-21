using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorInventario
    {
        private const string SP_CRUD = "dbo.CRUD_Inventario";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // ==========================
        // CRUD (NO lista) -> false, true
        // Boton: 0=INSERT, 1=UPDATE, 2=DELETE
        // ==========================
        public static async Task<RespuestaCRUD> CrearEditarEliminarInventario(Inventario objINventario, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(objINventario));
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
        // Consultar por ID (1 registro) -> false, true
        // ==========================
        public static async Task<Inventario> ConsultarId(int IdInventario)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM Inventario WITH (NOLOCK)
WHERE id = {IdInventario};";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<Inventario>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // ==========================
        // Consultar por Producto + Presentacion + Sede (1 registro) -> false, true
        // ==========================
        public static async Task<Inventario> ConsultarIdProducto_IdPresentacion(int IdPro, int IdPres, int IdSede)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM Inventario WITH (NOLOCK)
WHERE idProducto = {IdPro}
  AND idPresentacion = {IdPres}
  AND idSede = {IdSede}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<Inventario>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // ==========================
        // Lista completa desde V_Inventario (LISTA) -> true, true
        // ==========================
        public static async Task<List<V_Inventario>> ListaCompleta(int IdProducto, int IdSede)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_Inventario WITH (NOLOCK)
WHERE idProducto = {IdProducto}
  AND idSede = {IdSede}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // 👈 LISTA
                if (respuesta == null) return new List<V_Inventario>();
                return JsonConvert.DeserializeObject<List<V_Inventario>>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // ==========================
        // Consultar "Guid" (tu método realmente trae 1 registro por producto+sede)
        // 1 registro -> false, true
        // ==========================
        public static async Task<Inventario> ConsultarGuid(int IdProducto, int IdSede)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM Inventario WITH (NOLOCK)
WHERE idProducto = {IdProducto}
  AND idSede = {IdSede}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<Inventario>>(jsonReal);
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

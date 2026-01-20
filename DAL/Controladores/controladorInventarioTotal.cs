using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorInventarioTotal
    {
        private const string SP_CRUD = "dbo.CRUD_InventarioTotal";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // ==========================
        // CRUD (NO lista) -> false, true
        // Boton: 0=INSERT, 1=UPDATE, 2=DELETE
        // ==========================
        public static async Task<RespuestaCRUD> CrearEditarEliminarInventarioTotal(InventarioTotal inventarioTotal, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(inventarioTotal));
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
        // Consultar por Producto + Sede (1 registro) -> false, true
        // ==========================
        public static async Task<InventarioTotal> ConsultarIdProducto(int IdProducto, int IdSede)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM InventarioTotal WITH (NOLOCK)
WHERE idProducto = {IdProducto}
  AND idSede = {IdSede}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
         
                var lista = JsonConvert.DeserializeObject<InventarioTotal>(respuesta);
                return lista;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // ==========================
        // Consultar por ID (1 registro) -> false, true
        // ==========================
        public static async Task<InventarioTotal> ConsultarId(int Id)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM InventarioTotal WITH (NOLOCK)
WHERE id = {Id}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<InventarioTotal>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // ==========================
        // Filtrar V_InventarioTotal (LISTA) -> true, true
        // ==========================
        public static async Task<List<V_InventarioTotal>> Filtrar_IdSede_IdProducto(int IdSede, int IdProducto)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_InventarioTotal WITH (NOLOCK)
WHERE idSedeIT = {IdSede}
  AND idProductoIT = {IdProducto}
ORDER BY idIT DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // 👈 LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                return JsonConvert.DeserializeObject<List<V_InventarioTotal>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorPrecio
    {
        private const string SP_CRUD = "dbo.CRUD_Precios";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // =====================================================
        // CRUD -> false, true
        // Boton: 0=INSERT | 1=UPDATE | 2=DELETE
        // =====================================================
        public static async Task<RespuestaCRUD> CrearEditarEliminarCostoPrecio(Precios objCosto, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(objCosto));
                var query = $"EXEC CRUD_Precios N'{json}', {Boton}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                if(respuesta == null) return new RespuestaCRUD
                {
                    estado = false,
                    idAfectado = 0,
                    mensaje = "error"
                };
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
        // 1 registro por IdInventario -> false, true
        // (si hay varios, toma el mas reciente por id DESC)
        // =====================================================
        public static async Task<Precios> ConsultarIdInventario(int IdInventario)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM Precios WITH (NOLOCK)
WHERE idInventario = {IdInventario}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
if(respuesta==null)return null;
                var lista = JsonConvert.DeserializeObject<Precios>(respuesta);
                return lista;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // 1 registro por IdPrecio -> false, true
        // =====================================================
        public static async Task<Precios> ConsultarId(int IdPrecio)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM Precios WITH (NOLOCK)
WHERE id = {IdPrecio};";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<Precios>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // 1 registro por IdInventario + IdLista -> false, true
        // (si hay varios, toma el mas reciente por id DESC)
        // =====================================================
        public static async Task<Precios> ConsultarIdInventario_IdLista(int IdInvent, int IdLista)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM Precios WITH (NOLOCK)
WHERE idInventario = {IdInvent}
  AND idListaPrecios = {IdLista}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<Precios>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // LISTA desde VIEW -> true, true   (recuerda: listas van true)
        // =====================================================
        public static async Task<List<V_Precios>> ListaCompleta(int IdInventario, int IdSede)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_Precios WITH (NOLOCK)
WHERE idSede = {IdSede}
  AND idInventario_v = {IdInventario}
ORDER BY id_v DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // LISTA
                if (respuesta == null) return new List<V_Precios>();
                return JsonConvert.DeserializeObject<List<V_Precios>>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // 1 registro por IdProducto + IdInventario + IdLista -> false, true
        // =====================================================
        public static async Task<Precios> Consultar_IdProducto_IdINventario_IdListaPrecios(int IdProducto, int IdInventario, int IdListaPrecios)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM Precios WITH (NOLOCK)
WHERE idProducto = {IdProducto}
  AND idInventario = {IdInventario}
  AND idListaPrecios = {IdListaPrecios}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                if (respuesta == null) return null;
                var lista = JsonConvert.DeserializeObject<Precios>(respuesta);
                return lista;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

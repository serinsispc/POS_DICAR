using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorListaPrecios
    {
        private const string SP_CRUD = "dbo.CRUD_ListaPrecios";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // =====================================================
        // CRUD (INSERT / UPDATE / DELETE) -> NO LISTA
        // Boton: 0=INSERT | 1=UPDATE | 2=DELETE
        // =====================================================
        public static async Task<RespuestaCRUD> CrearEditarEliminarListaPrecios(ListaPrecios objLista, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(objLista));
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
        // LISTA COMPLETA (VIEW V_ListaPrecio) -> LISTA
        // =====================================================
        public static async Task<List<V_ListaPrecio>> ListaCompleta()
        {
            try
            {
                var query = @"
SELECT *
FROM V_ListaPrecio WITH (NOLOCK)
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // 👈 LISTA
                if (respuesta == null) return new List<V_ListaPrecio>();
                return JsonConvert.DeserializeObject<List<V_ListaPrecio>>(respuesta);
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
        public static async Task<ListaPrecios> ConsultarID(int IdLista)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM ListaPrecios WITH (NOLOCK)
WHERE id = {IdLista};";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                var lista = JsonConvert.DeserializeObject<List<ListaPrecios>>(jsonReal);

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

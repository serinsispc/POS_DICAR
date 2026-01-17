using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores.OrdenServicio
{
    public class contorladorArticuloServicio
    {

        public static async Task<bool> CrearEditarEliminarArticulo(TipoArticulo objArticulo, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objArticulo);

                // Si usas tu ajustador de JSON, déjalo como siempre:
                // json = AjustarJoson.Ajustar(json);

                // Escapar comillas simples para SQL
                json = json.Replace("'", "''");

                var query = $"EXEC dbo.CRUD_TipoArticulo N'{json}', {Boton}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true); // Respuesta unica (no lista)

                if (!string.IsNullOrEmpty(resp))
                {
                    var r = JsonConvert.DeserializeObject<RespuestaCRUD>(resp);

                    // Si tu RespuestaCRUD.estado es int: return r != null && r.estado == 1;
                    return r != null && r.estado;
                }

                return false;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
        public static async Task<List<TipoArticulo>> ListaCompleta()
        {
            try
            {
                var query = @"
            select *
            from TipoArticulo
            order by nombreTipoArticulo
        ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true); // true = lista

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<List<TipoArticulo>>(resp);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<TipoArticulo> consultarID(int IDArticulo)
        {
            try
            {
                var query = $@"
            select top 1 *
            from TipoArticulo
            where id = {IDArticulo}
        ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true); // false = objeto

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<TipoArticulo>(resp);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

    }
}

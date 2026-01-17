using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorArchivoCompra
    {
        public static async Task<bool> CrearEditarEliminar(ArchivoCompras archivoCompras, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(archivoCompras);

                // Si usas tu ajustador, déjalo como siempre:
                // json = AjustarJoson.Ajustar(json);

                json = json.Replace("'", "''");

                var query = $"EXEC dbo.CRUD_ArchivoCompras N'{json}', {Boton}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    var r = JsonConvert.DeserializeObject<RespuestaCRUD>(resp);

                    // Si estado es int: return r != null && r.estado == 1;
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

        public static async Task<ArchivoCompras> ConsultarGuidArchivo(Guid guid)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from ArchivoCompras
                    where guidArchivo = '{guid}'
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<ArchivoCompras>(resp);
                }

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<ArchivoCompras> ConsultarIdArchivo(int Id)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from ArchivoCompras
                    where id = {Id}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<ArchivoCompras>(resp);
                }

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<V_ArchivoCompras>> Listra_IdCompra(int IdCompra)
        {
            try
            {
                var query = $@"
                    select *
                    from V_ArchivoCompras
                    where idCompra = {IdCompra}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true); // true = lista

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<List<V_ArchivoCompras>>(resp);
                }

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

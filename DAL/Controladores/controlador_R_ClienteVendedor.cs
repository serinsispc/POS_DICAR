using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controlador_R_ClienteVendedor
    {
        public static async Task<bool> Crud(R_ClienteVendedor r_Cliente, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(r_Cliente);

                // Si manejas tu ajustador, úsalo como siempre:
                // json = AjustarJoson.Ajustar(json);

                // Escapar comillas simples para SQL
                json = json.Replace("'", "''");

                var query = $"EXEC dbo.CRUD_R_ClienteVendedor N'{json}', {Boton}";
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

        public static async Task<R_ClienteVendedor> Consultar_IdRutero(int IdRutero)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from R_ClienteVendedor
                    where id = {IdRutero}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<R_ClienteVendedor>(resp);
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

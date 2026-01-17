using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores.Administrador
{
    public class controladorTipoUsuario
    {
        public static async Task<List<TipoUsuario>> listaCompleta()
        {
            try
            {
                var query = @"select * from TipoUsuario";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<List<TipoUsuario>>(resp);
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

        public static async Task<TipoUsuario> consultarID(int idTipo)
        {
            try
            {
                var query = $@"
            select top 1 *
            from TipoUsuario
            where id = {idTipo}
        ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<TipoUsuario>(resp);
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

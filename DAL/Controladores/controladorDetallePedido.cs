using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorDetallePedido
    {
        public static async Task<List<V_DetallePedido>> Filtrar_guiPedido(Guid guid)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_DetallePedido WITH (NOLOCK)
WHERE guidPedido = '{guid}'";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);
if(respuesta == null)
                {
                    return null;
                }

                return JsonConvert.DeserializeObject<List<V_DetallePedido>>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorEstadoPedido
    {
        // ==========================
        // LISTA COMPLETA
        // ==========================
        public static async Task<List<EstadoPedido>> ListaCompleta()
        {
            try
            {
                var query = @"
SELECT *
FROM EstadoPedido WITH (NOLOCK)
ORDER BY id;";

                // 👈 LISTA → true, true
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);
                
                if (respuesta == null)
                {
                    return null;
                }

                return JsonConvert.DeserializeObject<List<EstadoPedido>>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

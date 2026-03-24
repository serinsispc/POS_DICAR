using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class ControladorEstadoAI
    {
        // ==========================
        // LISTA COMPLETA
        // ==========================
        public static async Task<List<EstadoAI>> listaCompleta()
        {
            try
            {
                var query = @"
SELECT *
FROM EstadoAI WITH (NOLOCK)
ORDER BY id;";

                // 👈 LISTAS → true, true
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);
                if(respuesta==null)return new List<EstadoAI>();
                return JsonConvert.DeserializeObject<List<EstadoAI>>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

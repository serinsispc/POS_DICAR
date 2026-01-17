using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class ControladorEstadoInventario
    {
        // ==========================
        // LISTA COMPLETA
        // ==========================
        public static async Task<List<EstadoInventario>> listaCompleta()
        {
            try
            {
                var query = @"
SELECT *
FROM EstadoInventario WITH (NOLOCK)
ORDER BY id;";

                // 👈 LISTA → true, true
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);

                // Tu patrón: viene JSON serializado como string
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                return JsonConvert.DeserializeObject<List<EstadoInventario>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

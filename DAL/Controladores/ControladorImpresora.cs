using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class ControladorImpresora
    {
        // ==========================
        // LISTA COMPLETA
        // ==========================
        public static async Task<List<Impresora>> listaCompleta()
        {
            try
            {
                var query = @"
SELECT *
FROM Impresora WITH (NOLOCK)
ORDER BY nombre_impresora;";

                // 👈 LISTAS → true, true
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);

                // Patrón actual: JSON serializado como string
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                return JsonConvert.DeserializeObject<List<Impresora>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorFacturaSoftware
    {
        // ==========================
        // LISTA COMPLETA
        // ==========================
        public static async Task<List<FacturaSoftware>> ListaCompleta()
        {
            try
            {
                var query = @"
SELECT *
FROM FacturaSoftware WITH (NOLOCK)
ORDER BY id;";

                // 👈 LISTAS → true, true
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);

                // Patrón actual: JSON serializado como string
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                return JsonConvert.DeserializeObject<List<FacturaSoftware>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(
                    "Ocurrió un error de conexión.",
                    "Error De conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }
    }
}

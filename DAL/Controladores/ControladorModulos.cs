using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorModulos
    {
        // 1 registro -> false, true
        public static async Task<Modulos> ConsultarModulo(string Modulo)
        {
            try
            {
                var m = (Modulo ?? string.Empty).Replace("'", "''");

                var query = $@"
SELECT TOP 1 *
FROM Modulos WITH (NOLOCK)
WHERE nombre_modumo = N'{m}'
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<Modulos>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return null;
            }
        }
    }
}

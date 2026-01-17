using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorTutoriales
    {
        // =========================================
        // LISTA COMPLETA DE TUTORIALES
        // =========================================
        public static async Task<List<Tutoriales>> ListaCompleta()
        {
            try
            {
                var query = "SELECT * FROM Tutoriales";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);

                return JsonConvert.DeserializeObject<List<Tutoriales>>(respuesta);
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

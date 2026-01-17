using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorVentaActiva
    {
        public static async Task<List<VentaActiva>> ConsultarVentasActivas(int idUsuario)
        {
            try
            {
                string query = $@"
                    SELECT *
                    FROM VentaActiva
                    WHERE idCajeroVentaActiva = {idUsuario};
                ";

                var json = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<VentaActiva>>(json);
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

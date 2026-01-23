using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorBilsillo
    {
        public static async Task<List<Bolsillo>> listaCompleta()
        {
            try
            {
                var query = @"select * from Bolsillo";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true); // true = lista
                if(resp == null)return new List<Bolsillo>();
                return JsonConvert.DeserializeObject<List<Bolsillo>>(resp);
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

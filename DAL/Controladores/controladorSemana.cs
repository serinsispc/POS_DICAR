using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorSemana
    {
        // =========================================================
        // LISTA COMPLETA (SELECT -> true, true)
        // =========================================================
        public static async Task<List<Semana>> ListaCompleta()
        {
            try
            {
                var query = "SELECT * FROM Semana";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);

                return JsonConvert.DeserializeObject<List<Semana>>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

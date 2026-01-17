using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorRutero
    {
        // =========================================================
        // LISTA COMPLETA (SELECT -> true, true)
        // =========================================================
        public static async Task<List<V_Rutero>> ListaCompleta()
        {
            try
            {
                var query = "SELECT * FROM V_Rutero";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);

                return JsonConvert.DeserializeObject<List<V_Rutero>>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

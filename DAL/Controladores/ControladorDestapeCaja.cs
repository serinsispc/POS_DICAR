using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class ControladorDestapeCaja
    {
        public static async Task<bool> CrearEditarEliminarDestapeCaja(DestapeProducto objDP, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objDP);

                // Si usas tu ajustador, déjalo como siempre:
                // json = AjustarJoson.Ajustar(json);

                json = json.Replace("'", "''");

                var query = $"EXEC dbo.CRUD_DestapeProducto N'{json}', {Boton}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    var r = JsonConvert.DeserializeObject<RespuestaCRUD>(resp);

                    // Si estado es int: return r != null && r.estado == 1;
                    return r != null && r.estado;
                }

                return false;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
    }
}

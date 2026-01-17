using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorAutorazacion_FE
    {
        public static async Task<AutorizacionFacturacionElectronica> consultarAutorizacion(int IdSede)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from AutorizacionFacturacionElectronica
                    where idEmpresa = {IdSede}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<AutorizacionFacturacionElectronica>(resp);
                }

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

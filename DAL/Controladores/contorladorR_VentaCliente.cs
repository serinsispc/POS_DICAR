using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class contorladorR_VentaCliente
    {
        public static async Task<R_VentaCliente> Consultar_ID(int IdVenta)
        {
            try
            {
                var query = $@"
            select top 1 *
            from R_VentaCliente
            where idVenta = {IdVenta}
        ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<R_VentaCliente>(resp);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

    }
}

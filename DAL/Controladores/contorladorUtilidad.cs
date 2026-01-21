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

    public class contorladorUtilidad
    {
        public static async Task<int> HallarCostoVentaDia(DateTime fecha, int IdSede)
        {
            try
            {
                var query = $@"
                select ISNULL(SUM(utilidadTotalVenta), 0) as total
                from V_TablaVentas
                where CONVERT(date, fechaVenta) = '{fecha:yyyy-MM-dd}'
                  and IdSede = {IdSede}
            ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);



                if (!string.IsNullOrEmpty(resp))
                {
                    var data = JsonConvert.DeserializeObject<ClassSumaTotal>(resp);
                    return Convert.ToInt32(data.total);
                }

                return 0;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }

        public static async Task<int> HallarCostoVentaMes(DateTime fecha, int IdSede)
        {
            try
            {
                var query = $@"
                select ISNULL(SUM(utilidadTotalVenta), 0) as total
                from V_TablaVentas
                where MONTH(fechaVenta) = {fecha.Month}
                  and YEAR(fechaVenta) = {fecha.Year}
                  and IdSede = {IdSede}
            ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (resp == null) return 0;

                if (!string.IsNullOrEmpty(resp))
                {
                    var data = JsonConvert.DeserializeObject<ClassSumaTotal>(resp);
                    return Convert.ToInt32(data.total);
                }

                return 0;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }

        public static async Task<int> HallarCostoVentaAño(DateTime fecha, int IdSede)
        {
            try
            {
                var query = $@"
                select ISNULL(SUM(utilidadTotalVenta), 0) as total
                from V_TablaVentas
                where YEAR(fechaVenta) = {fecha.Year}
                  and IdSede = {IdSede}
            ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    var data = JsonConvert.DeserializeObject<ClassSumaTotal>(resp);
                    return Convert.ToInt32(data.total);
                }

                return 0;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
    }

}

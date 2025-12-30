using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;

namespace DAL.Controladores
{
    public class contorladorUtilidad
    {
        public static int HallarCostoVentaDia(DateTime fecha,int IdSede)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    int? suma = cn.V_TablaVentas.AsNoTracking().Where(x =>
                      x.fechaVenta.Day == fecha.Day &&
                      x.fechaVenta.Month == fecha.Month &&
                      x.fechaVenta.Year == fecha.Year &&
                      x.IdSede == IdSede).Sum(x => (int?)x.utilidadTotalVenta);
                    if (suma == null)
                    {
                        suma = 0;
                    }
                    return Convert.ToInt32(suma);
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
        public static int HallarCostoVentaMes(DateTime fecha, int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    int? suma = cn.V_TablaVentas.AsNoTracking().Where(x =>
                      x.fechaVenta.Month == fecha.Month &&
                      x.fechaVenta.Year == fecha.Year &&
                      x.IdSede == IdSede).Sum(x => (int?)x.utilidadTotalVenta);
                    if (suma == null)
                    {
                        suma = 0;
                    }
                    return Convert.ToInt32(suma);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
        public static int HallarCostoVentaAño(DateTime fecha, int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    int? suma = cn.V_TablaVentas.AsNoTracking().Where(x =>
                      x.fechaVenta.Year == fecha.Year &&
                      x.IdSede == IdSede).Sum(x => (int?)x.utilidadTotalVenta);
                    if (suma == null)
                    {
                        suma = 0;
                    }
                    return Convert.ToInt32(suma);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
    }
}

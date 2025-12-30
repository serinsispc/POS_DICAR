using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorDetalleOrdenFabrica
    {
        public static bool CrearEditarEliminarDetalleOrdenFabrica(DetalleOrdenFabrica objDetalle, int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.DetalleOrdenFabrica.Add(objDetalle);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objDetalle).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objDetalle).State = System.Data.Entity.EntityState.Deleted;
                    }
                    cn.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
        public static List<DetalleOrdenFabrica> Filtro_IDOrden(int IdOrden)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.DetalleOrdenFabrica.AsNoTracking().Where(x => x.idOrdenDetalle == IdOrden).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static decimal SumaTotalDetalleINsumo(int IdOrden)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    decimal total = cn.DetalleOrdenFabrica.AsNoTracking().Where(x => x.idOrdenDetalle == IdOrden).Sum(x => (decimal)x.costoTotalInsumoOrden);
                    return total;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
        public static DetalleOrdenFabrica consultarIdDetalleOrden(int IdDetalle)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.DetalleOrdenFabrica.AsNoTracking().Where(x => x.id == IdDetalle).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

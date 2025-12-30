using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores.Orden_Servicio
{
    public class controladorOrdenServicio
    {
        public static bool CrearEditarEliminarOrden(Modelo.OrdenServicio objOrden, int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.OrdenServicio.Add(objOrden);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objOrden).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objOrden).State = System.Data.Entity.EntityState.Deleted;
                    }
                    cn.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }

        public static Modelo.OrdenServicio consultar_ID(int IDOrden)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.OrdenServicio.AsNoTracking().Where(x => x.id == IDOrden).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static int HallarConsecutivo()
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    int? numero = cn.OrdenServicio.AsNoTracking().Max(x => (int?)x.numeroOrdenServicio);
                    if (numero == null)
                    {
                        numero = 0;
                    }
                    return Convert.ToInt32(numero) + 1;
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

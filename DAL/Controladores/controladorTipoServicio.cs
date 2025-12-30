using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores.OrdenServicio
{
    public class controladorTipoServicio
    {
        public static bool CrearEditarEliminarArticulo(TipoServicio objServicio, int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.TipoServicio.Add(objServicio);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objServicio).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objServicio).State = System.Data.Entity.EntityState.Deleted;
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
        public static List<TipoServicio> ListaCompleta()
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.TipoServicio.AsNoTracking().OrderBy(x => x.nombreTipoServicio).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static TipoServicio consultarID(int IDServicio)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.TipoServicio.AsNoTracking().Where(x => x.id == IDServicio).FirstOrDefault();
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

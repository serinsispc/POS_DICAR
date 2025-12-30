using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;

namespace DAL.Controladores
{
    public class controladorResponsableOrdenFabricacion
    {
        public static bool CrearEditarEliminarResponsableOrdenFabricacion(ResponsableOrdenFabrica objROF, int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.ResponsableOrdenFabrica.Add(objROF);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objROF).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objROF).State = System.Data.Entity.EntityState.Deleted;
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
        public static List<ResponsableOrdenFabrica> filtroNombre(string Nombre)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.ResponsableOrdenFabrica.AsNoTracking().Where(x => x.nombreResponsableOrdenFabrica.Contains(Nombre)).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static ResponsableOrdenFabrica consultarNombre(string Nombre)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.ResponsableOrdenFabrica.AsNoTracking().Where(x => x.nombreResponsableOrdenFabrica==Nombre).FirstOrDefault();
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

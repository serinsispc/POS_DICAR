using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;

namespace DAL.Controladores
{
    public class controladorOrdenFabrica
    {
        public static bool CrearEditarElimminarOrdenFabrica(OrdenFabrica objOF,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.OrdenFabrica.Add(objOF);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objOF).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objOF).State = System.Data.Entity.EntityState.Deleted;
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
        public static int Consecutivo()
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    int? consecutovo = cn.OrdenFabrica.AsNoTracking().Max(x => (int?)x.numeroOrdenFabrica);
                    if (consecutovo == null)
                    {
                        consecutovo = 0;
                    }
                    return Convert.ToInt32(consecutovo)+1;
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
        public static List<OrdenFabrica> filtroEstado(string estado)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.OrdenFabrica.AsNoTracking().Where(x => x.estadoOrdenFabricacion == estado).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static OrdenFabrica consultarID(int ID)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.OrdenFabrica.AsNoTracking().Where(x => x.id == ID).FirstOrDefault();
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

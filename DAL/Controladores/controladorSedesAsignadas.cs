using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;

namespace DAL.Controladores
{
    public class controladorSedesAsignadas
    {
        public static bool CrearEditarEliminarAsignacionSede(SedesAsignadas objAsignacion, int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.SedesAsignadas.Add(objAsignacion);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objAsignacion).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objAsignacion).State = System.Data.Entity.EntityState.Deleted;
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
        public  static int SumarSedesAsignadas(int IdUsuario)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    int? suma = cn.SedesAsignadas.AsNoTracking().Where(x => x.idusuarioAsignado == IdUsuario).Sum(x => (int?)x.contadorAsignacion);
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
        public static List<V_SedesAsignadas> filtroXIdUsuario(int IdUsuario)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.V_SedesAsignadas.AsNoTracking().Where(x => x.v_idusuarioAsignado == IdUsuario).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static SedesAsignadas consultarIDUsuario(int IdUsuario)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.SedesAsignadas.AsNoTracking().Where(x => x.idusuarioAsignado == IdUsuario).FirstOrDefault();
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

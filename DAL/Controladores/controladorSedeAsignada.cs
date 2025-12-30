using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;

namespace DAL.Controladores.Administrador
{
    public class controladorSedeAsignada
    {
        public static bool CrearEditarEliminanrSedeAsignada(SedesAsignadas objSedeAsignada,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.SedesAsignadas.Add(objSedeAsignada);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objSedeAsignada).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objSedeAsignada).State = System.Data.Entity.EntityState.Deleted;
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
        public static List<V_SedesAsignadas> listaCompleta()
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.V_SedesAsignadas.AsNoTracking().ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static SedesAsignadas consultarUsuarioSede(int Idusuario,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.SedesAsignadas.AsNoTracking().Where(x => x.idusuarioAsignado == Idusuario &&
                                                                     x.idSedeAsignada == IdSede).FirstOrDefault();
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

using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorTipoMedida
    {
        public static bool CrearEditarEliminarTipoMedida(TipoMedida objTipo,int Boto)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    if (Boto == 0)
                    {
                        cn.TipoMedida.Add(objTipo);
                    }
                    if (Boto == 1)
                    {
                        cn.Entry(objTipo).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boto == 2)
                    {
                        cn.Entry(objTipo).State = System.Data.Entity.EntityState.Deleted;
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
        public static List<V_TipoMedida> listaCompleta()
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_TipoMedida.AsNoTracking().ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static TipoMedida ConsultarID(int IdTipo)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.TipoMedida.AsNoTracking().Where(x=>x.id==IdTipo).FirstOrDefault();
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

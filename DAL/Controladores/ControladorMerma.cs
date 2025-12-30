using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class ControladorMerma
    {
        public static bool Crud(Merma objMerma,int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.Merma.Add(objMerma);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objMerma).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objMerma).State = System.Data.Entity.EntityState.Deleted;
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
        public static Merma ConsultarID(int ID)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.Merma.AsNoTracking().Where(x => x.id == ID).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_Merma> listaCompleta()
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.V_Merma.AsNoTracking().ToList();
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

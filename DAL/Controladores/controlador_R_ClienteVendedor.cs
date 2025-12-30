using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controlador_R_ClienteVendedor
    {
        public static bool Crud(R_ClienteVendedor r_Cliente,int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.R_ClienteVendedor.Add(r_Cliente);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(r_Cliente).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(r_Cliente).State = System.Data.Entity.EntityState.Deleted;
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
        public static R_ClienteVendedor Consultar_IdRutero(int IdRutero)
        {
            try
            {
                using(SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.R_ClienteVendedor.AsNoTracking().Where(x => x.id == IdRutero).FirstOrDefault();
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

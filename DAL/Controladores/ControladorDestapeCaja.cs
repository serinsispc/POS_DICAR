using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;

namespace DAL.Controladores
{
    public class ControladorDestapeCaja
    {
        public static bool CrearEditarEliminarDestapeCaja(DestapeProducto objDP,int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.DestapeProducto.Add(objDP);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objDP).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objDP).State = System.Data.Entity.EntityState.Deleted;
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
    }
}

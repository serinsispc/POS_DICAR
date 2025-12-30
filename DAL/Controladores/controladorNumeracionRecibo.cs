using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controlador
{
    public class controladorNumeracionRecibo
    {
        public static bool crud(ConsecutivoRecibo consecutivoRecibo,int Boton )
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.ConsecutivoRecibo.Add(consecutivoRecibo);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(consecutivoRecibo).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(consecutivoRecibo).State = System.Data.Entity.EntityState.Deleted;
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
        public static ConsecutivoRecibo Consultar_x_IdVenta(int idVenta)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.ConsecutivoRecibo.AsNoTracking().Where(x => x.idVenta == idVenta).FirstOrDefault();
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

using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorRVentaCleinte
    {
        public static bool CrearEditarEliminar_R_VentaCleinte(R_VentaCliente objRVC,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn=new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.R_VentaCliente.Add(objRVC);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objRVC).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objRVC).State = System.Data.Entity.EntityState.Deleted;
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
        public static R_VentaCliente ConsultarRelacion(int IdVenta)
        {
            try
            {
                using (SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.R_VentaCliente.AsNoTracking().Where(x =>x.idVenta == IdVenta).FirstOrDefault();
                }

            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static R_VentaCliente Consultar_idCliente(int IdCliente)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.R_VentaCliente.AsNoTracking().Where(x => x.idCliente == IdCliente).FirstOrDefault();
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
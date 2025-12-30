using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public  class controladorR_PedidoVenta
    {
        public static bool Crud (R_PedidoVenta r_Pedido,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.R_PedidoVenta.Add(r_Pedido);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(r_Pedido).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(r_Pedido).State = System.Data.Entity.EntityState.Deleted;
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
        public static R_PedidoVenta Consultar_GuidPedido(Guid guid)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.R_PedidoVenta.AsNoTracking().Where(x=>x.guidPedido==guid).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string erro = ex.Message;
                return null;
            }
        }
        public static R_PedidoVenta Consultar_idVenta(int IdVenta)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.R_PedidoVenta.AsNoTracking().Where(x => x.idVenta == IdVenta).FirstOrDefault();
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

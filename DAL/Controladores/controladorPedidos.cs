using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public  class controladorPedidos
    {
        public static bool Crud(Pedidos pedidos,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.Pedidos.Add(pedidos);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(pedidos).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(pedidos).State = System.Data.Entity.EntityState.Deleted;
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
        public static List<V_Pedido> Filtrar_estado(int estado,int idVendedor_frm,DateTime fecha)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.V_Pedido.AsNoTracking().Where(x => 
                    x.idEstadoPedido == estado &&
                    x.idVendedor==idVendedor_frm &&
                    x.fechaPedido.Day==fecha.Day&&
                    x.fechaPedido.Month==fecha.Month&&
                    x.fechaPedido.Year==fecha.Year).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_Pedido> Filtrar_guia(string  guia)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_Pedido.AsNoTracking().Where(x => x.guiaPedido == guia).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static Pedidos Consultar_guid (Guid guid)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.Pedidos.AsNoTracking().Where(x => x.guidPedido == guid).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static int PedidosPendientes(int IdVendedor,int IdEstado,DateTime fecha)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    int? suma = cn.Pedidos.AsNoTracking().Where(x => 
                    x.idVendedor == IdVendedor && 
                    x.idEstadoPedido == IdEstado &&
                    x.fechaPedido.Month==fecha.Month &&
                    x.fechaPedido.Day==fecha.Day &&
                    x.fechaPedido.Year==fecha.Year).Sum(x => (int?)x.idEstadoPedido);
                    if (suma == null)
                    {
                        suma = 0;
                    }
                    return Convert.ToInt32(suma);
                }
            }
           catch(Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
        public static decimal sumarTotalPedido(int IdVendedor, int IdEstado, DateTime fecha)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    decimal? suma = cn.V_Pedido.AsNoTracking().Where(x =>
                    x.idVendedor == IdVendedor &&
                    x.idEstadoPedido == IdEstado &&
                    x.fechaPedido.Month == fecha.Month &&
                    x.fechaPedido.Day == fecha.Day &&
                    x.fechaPedido.Year == fecha.Year).Sum(x => (decimal?)x.totalPedido);
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

    }
}

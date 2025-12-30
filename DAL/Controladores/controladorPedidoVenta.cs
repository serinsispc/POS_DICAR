using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorPedidoVenta
    {
        public static R_PedidoVenta Consultar_IdVenta(int IdVenta)
        {
            try
            {
                using (SistemaPOSEntities cn =new SistemaPOSEntities())
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
        public static V_Pedido Consultar_giaPedido(string guia)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_Pedido.AsNoTracking().Where(x => x.guiaPedido == guia).FirstOrDefault();
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

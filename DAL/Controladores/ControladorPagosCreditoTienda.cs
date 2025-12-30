using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public  class ControladorPagosCreditoTienda
    {
        public static bool Crear_Editar_Eliminar_PagoCreditoTienda(PagosCreditoTienda objPCT,int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.PagosCreditoTienda.Add(objPCT);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objPCT).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objPCT).State = System.Data.Entity.EntityState.Deleted;
                    }
                    cn.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static List<R_PagoCredito> FiltroX_Año(DateTime Fecha, int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.R_PagoCredito.AsNoTracking().Where(x => x.idSedePagoCredito == IdSede && x.fecha_pago_credito_tienda_r_pago_credito.Value.Year == Fecha.Year).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static List<R_PagoCredito> FiltroX_Mes(DateTime Fecha, int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.R_PagoCredito.AsNoTracking().Where(x => x.idSedePagoCredito == IdSede && x.fecha_pago_credito_tienda_r_pago_credito.Value.Year == Fecha.Year &&
                    x.fecha_pago_credito_tienda_r_pago_credito.Value.Month == Fecha.Month).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static List<R_PagoCredito> FiltroX_Dia(DateTime Fecha, int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.R_PagoCredito.AsNoTracking().Where(x => x.idSedePagoCredito == IdSede && x.fecha_pago_credito_tienda_r_pago_credito.Value.Year == Fecha.Year &&
                    x.fecha_pago_credito_tienda_r_pago_credito.Value.Month == Fecha.Month &&
                    x.fecha_pago_credito_tienda_r_pago_credito.Value.Day == Fecha.Day).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static decimal SumarPagosX_Año(DateTime Fecha,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    decimal? Pago=  cn.PagosCreditoTienda.AsNoTracking().Where(x =>x.idSede==IdSede && x.fecha_pago_credito_tienda.Value.Year == Fecha.Year).Sum(y=> y.valor_pago_credito_tienda);
                    if (Pago == null)
                    {
                        Pago = 0;
                    }
                    return Convert.ToInt32(Pago);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static decimal SumarPagosX_Mes(DateTime Fecha,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    decimal? Pago = cn.PagosCreditoTienda.AsNoTracking().Where(x =>x.idSede==IdSede && x.fecha_pago_credito_tienda.Value.Year == Fecha.Year&&
                    x.fecha_pago_credito_tienda.Value.Month==Fecha.Month).Sum(y => y.valor_pago_credito_tienda);
                    if (Pago == null)
                    {
                        Pago = 0;
                    }
                    return Convert.ToDecimal(Pago);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static decimal SumarPagosX_Dia(DateTime Fecha, int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    decimal? Pago = cn.PagosCreditoTienda.AsNoTracking().Where(x => 
                    x.idSede == IdSede && x.fecha_pago_credito_tienda.Value.Year == Fecha.Year &&
                    x.fecha_pago_credito_tienda.Value.Month == Fecha.Month &&
                    x.fecha_pago_credito_tienda.Value.Day==Fecha.Day).Sum(y => y.valor_pago_credito_tienda);
                    if (Pago == null)
                    {
                        Pago = 0;
                    }
                    return Convert.ToDecimal(Pago);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static List<V_PagosCreditoTienda>FIltroXIdVenta(int IdVenta)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.V_PagosCreditoTienda.AsNoTracking().Where(x => x.idVentaPago == IdVenta).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static int pagoCCBolsilloFecha(int IdBase,int Bolsillo)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    int? pagoCC = cn.V_PagosCreditoTienda.AsNoTracking().Where(x =>                    
                       x.idBaseCaja==IdBase&&
                       x.idBolsillo==Bolsillo).Sum(x =>(int?)x.valor_pago_credito_tienda);
                    if (pagoCC == null)
                    {
                        pagoCC = 0;
                    }
                    return Convert.ToInt32(pagoCC);
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static PagosCreditoTienda ConsultarId(int Id)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.PagosCreditoTienda.AsNoTracking().Where(x => x.id_pago_credito_tienda == Id).FirstOrDefault();
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

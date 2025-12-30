using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;
using System.Windows.Forms;

namespace DAL.Controladores.Contabilidad
{
    public class ControladorPagosCompras
    {
        public static bool Crear_Editar_Eliminar_PagoCompra(PagosCompras objPagos,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.PagosCompras.Add(objPagos);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objPagos).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objPagos).State = System.Data.Entity.EntityState.Deleted;
                    }
                    cn.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public  static List<V_PagoCP> listaNumeroCompra(int idCompra)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.V_PagoCP.AsNoTracking().Where(x => x.consecutivoVPagoCompra == idCompra).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static PagosCompras ConsultarX_IdPago(int IdPago)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.PagosCompras.AsNoTracking().Where(x => x.id == IdPago).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static int hallarTotalPagoCPAño(DateTime Fecha ,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    int? PagoCP = cn.PagosCompras.AsNoTracking().Where(x =>
                    x.idSede==IdSede &&
                    x.fechaPagoCompra.Value.Year == Fecha.Year).Sum(x => (int?)x.valorPagadoCompra);
                    return Convert.ToInt32(PagoCP);
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static int hallarTotalPagoCPMes(DateTime Fecha,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    int? PagoCP = cn.PagosCompras.AsNoTracking().Where(x => 
                    x.idSede==IdSede &&
                    x.fechaPagoCompra.Value.Year == Fecha.Year&&
                    x.fechaPagoCompra.Value.Month==Fecha.Month).Sum(x => (int?)x.valorPagadoCompra);
                    return Convert.ToInt32(PagoCP);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static int hallarTotalPagoCPDia(DateTime Fecha,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    int? PagoCP = cn.PagosCompras.AsNoTracking().Where(x => 
                    x.idSede==IdSede &&
                    x.fechaPagoCompra.Value.Year == Fecha.Year && 
                    x.fechaPagoCompra.Value.Month == Fecha.Month&&
                    x.fechaPagoCompra.Value.Day==Fecha.Day).Sum(x => (int?)x.valorPagadoCompra);
                    return Convert.ToInt32(PagoCP);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static int pagoCPBolsilloFecha(int Bolsillo,int IdBase)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    int? PagoCP = cn.V_PagoCP.AsNoTracking().Where(x =>
                                                                        x.idBolsillo==Bolsillo &&
                                                                        x.idBaseCaja==IdBase)
                                                                        .Sum(x => (int?)x.pagoActualVPagoCompra);
                    if (PagoCP == null)
                    {
                        PagoCP = 0;
                    }
                    return Convert.ToInt32(PagoCP);
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}

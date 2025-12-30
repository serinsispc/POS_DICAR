using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorDetalleVenta
    {
        public static bool GuardarEditarEliminar(DetalleVenta objDetalleV, int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.DetalleVenta.Add(objDetalleV);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objDetalleV).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objDetalleV).State = System.Data.Entity.EntityState.Deleted;
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
        public static int SumarTotalVentaCosto(int NumeroVenta)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    int? Suma = cn.V_DetalleCaja.AsNoTracking().Where(x => x.idVenta == NumeroVenta).Sum(y => (int?)y.costoTotal);
                    if (Suma == null)
                    {
                        Suma = 0;
                    }
                    return Convert.ToInt32(Suma);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        public static decimal SumarTotalVenta(int NumeroVenta)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    decimal? Suma = cn.V_DetalleCaja.AsNoTracking().Where(x => x.idVenta == NumeroVenta).Sum(y => (decimal?)y.totalDetalle);
                    if (Suma == null)
                    {
                        Suma = 0;
                    }
                    return Convert.ToDecimal(Suma);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static decimal SumarTotalCosto(int NumeroVenta)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    decimal? Suma = cn.V_DetalleCaja.AsNoTracking().Where(x => x.idVenta == NumeroVenta).Sum(y => (decimal?)y.costoTotal);
                    if (Suma == null)
                    {
                        Suma = 0;
                    }
                    return Convert.ToDecimal(Suma);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static decimal SumarTotalIVA(int NumeroVenta)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    decimal? Suma = cn.V_DetalleCaja.AsNoTracking().Where(x => x.idVenta == NumeroVenta).Sum(y => (decimal?)y.valorIva);
                    if (Suma == null)
                    {
                        Suma = 0;
                    }
                    return Convert.ToDecimal(Suma);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static DetalleVenta ConsultaXNumeroVentaYidProducto(int numero, int IdPrecio,int idUsuario)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.DetalleVenta.AsNoTracking().Where(x => x.idVenta == numero &&
                                                                     x.idPrecios==IdPrecio).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public static List<R_DetalleVenta> ListaDetalleVenta(int IdVenta)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.R_DetalleVenta.AsNoTracking().Where(x => x.idVentaV == IdVenta).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public static DetalleVenta ConsultarX_IDDetalle(int IdDetalle)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.DetalleVenta.AsNoTracking().Where(x => x.id == IdDetalle).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static List<V_DetalleCaja> ListaDetalleVentaProductos(int NumeroVenta)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_DetalleCaja.AsNoTracking().Where(x => x.idVenta == NumeroVenta).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }

        }
        public static List<V_DetalleCaja> ListaDetalleCaja(int NumeroVenta)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_DetalleCaja.AsNoTracking().Where(x => x.idVenta == NumeroVenta ).OrderByDescending(x=>x.id).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }

        }
        public static List<R_DetalleVenta> FiltrarX_IdVenta(int IDVENTA)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.R_DetalleVenta.AsNoTracking().Where(x => x.idVentaV == IDVENTA).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static List<V_DetalleCaja> filtrarConsecutivo(int Consecutivo)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_DetalleCaja.AsNoTracking().Where(x => x.idVenta == Consecutivo).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static decimal SumaVentaProducto(int IdInventario, int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    decimal? suma = cn.DetalleVenta.AsNoTracking().Where(x => x.idSede == IdSede && x.idInventario == IdInventario).Sum(x => (decimal?)x.cantidadDetalle);
                    if (suma == null)
                    {
                        suma = 0;
                    }
                    return Convert.ToDecimal(suma);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
        public static decimal SumarTotalDetalles(DateTime fecha,int IdSede)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    decimal? suma = cn.V_TotalVentasDetalle.AsNoTracking().Where(x =>
                      x.idSede==IdSede &&
                      x.fechaVenta.Day == fecha.Day &&
                      x.fechaVenta.Month == fecha.Month &&
                      x.fechaVenta.Year == fecha.Year).Sum(x=>(decimal?)x.totalDetalle);
                    if (suma == null)
                    {
                        suma = 0;
                    }
                    return Convert.ToDecimal(suma);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
        public static DetalleVenta ConsultarIDVenta(int IdVenta)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.DetalleVenta.AsNoTracking().Where(x => x.idVenta == IdVenta).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static DataTable Lista_FacturaElectronica(int IdVenta)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand command = ConexionSQL.connection.CreateCommand();
                command.CommandText = "select *from V_DetalleCaja where idVenta="+IdVenta;
                DataTable table = new DataTable();
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                sqlData.Fill(table);
                if(table.Rows.Count > 0)
                {
                    return table;
                }
                else
                {
                    return null;
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

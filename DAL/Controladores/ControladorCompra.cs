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
    public class ControladorCompra
    {
        public static bool GuardarEditarEliminarCompra(Compras objCompra, int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.Compras.Add(objCompra);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objCompra).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objCompra).State = System.Data.Entity.EntityState.Deleted;
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
        public static Compras ConsultaListaX_IdCompra_Entity(int IdCompra)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.Compras.AsNoTracking().Where(x => x.id == IdCompra).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }

        }
        public static DataTable ConsultaListaX_IdCompra(int IdCompra)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from Compras where id="+IdCompra;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                ConexionSQL.CerrarConexion();
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }

        }
        public static int TotalComprasAño(DateTime Fecha)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    int? Total = cn.PagosCompras.AsNoTracking().Where(x => x.fechaPagoCompra.Value.Year == Fecha.Year).Sum(y => (int?)y.valorPagadoCompra);
                    if (Total == null)
                    {
                        Total = 0;
                    }
                    return Convert.ToInt32(Total);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }

        }
        public static int TotalComprasMes(DateTime Fecha)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    int? Total = cn.PagosCompras.AsNoTracking().Where(x => x.fechaPagoCompra.Value.Year == Fecha.Year &&
                                                                      x.fechaPagoCompra.Value.Month == Fecha.Month).Sum(y => (int?)y.valorPagadoCompra);
                    if (Total == null)
                    {
                        Total = 0;
                    }
                    return Convert.ToInt32(Total);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }

        }
        public static int TotalComprasDia(DateTime Fecha)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    int? Total = cn.PagosCompras.AsNoTracking().Where(x => x.fechaPagoCompra.Value.Year == Fecha.Year &&
                                                                      x.fechaPagoCompra.Value.Month == Fecha.Month &&
                                                                      x.fechaPagoCompra.Value.Day == Fecha.Day).Sum(y => (int?)y.valorPagadoCompra);
                    if (Total == null)
                    {
                        Total = 0;
                    }
                    return Convert.ToInt32(Total);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }

        }
        public static List<V_Compras>ListaCompleta_Sede(int IdSede,int Estado)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.V_Compras.AsNoTracking().Where(x => x.idSedeCompra == IdSede &&x.idEstadoAI==Estado).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_PagoCP> FiltroX_Año(DateTime FechaFiltro, int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_PagoCP.AsNoTracking().Where(x => x.IdSedePagoCompra == IdSede && x.FechaVPagoCompra.Value.Year == FechaFiltro.Year).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_PagoCP> FiltroX_Mes(DateTime FechaFiltro, int IdSEde)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_PagoCP.AsNoTracking().Where(x => x.IdSedePagoCompra == IdSEde && x.FechaVPagoCompra.Value.Year == FechaFiltro.Year &&
                                                                x.FechaVPagoCompra.Value.Month == FechaFiltro.Month).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_PagoCP> FiltroX_Dia(DateTime FechaFiltro, int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_PagoCP.AsNoTracking().Where(x => x.IdSedePagoCompra == IdSede && x.FechaVPagoCompra.Value.Year == FechaFiltro.Year &&
                                                                x.FechaVPagoCompra.Value.Month == FechaFiltro.Month &&
                                                                x.FechaVPagoCompra.Value.Day == FechaFiltro.Day).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<Compras> FiltrarSaldo()
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.Compras.AsNoTracking().Where(x => x.saldoCompra > 0).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_Compras> filtrarXProveedorSaldo(string Proveedor)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_Compras.AsNoTracking().Where(x => x.saldoCompraV > 0 && x.nombreProveedorV.Contains(Proveedor) && x.documentoProveedorV.Contains(Proveedor)).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_Compras> listaComprasPendientes(int IdSede,int Estado)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_Compras.AsNoTracking().Where(x => x.saldoCompraV > 0 &&
                    x.idSedeCompra == IdSede&&
                    x.idEstadoAI==Estado).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static Compras ConsultarXGuid(Guid gui)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.Compras.AsNoTracking().Where(x => x.guidCompra == gui).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static Compras Consultar_Id(int IdCompra)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.Compras.AsNoTracking().Where(x => x.id == IdCompra).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static Compras ConsultarEstadoAI(int estado,int IdSede)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.Compras.AsNoTracking().Where(x => x.idSede == IdSede && x.idEstadoAI == estado).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string Error = ex.Message;
                return null;
            }
        }
    }
}

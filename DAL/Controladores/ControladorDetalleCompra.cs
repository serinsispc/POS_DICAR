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
    public class ControladorDetalleCompra
    {
        public static DataTable ConsultarTotales(int IdCompra)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select "+
"isnull(SUM(cantidad * precioUnitario),0) as subTotal," +
"isnull(sum(cantidad * valorDescuento),0) as totalDescuento," +
"isnull(SUM(cantidad * valorIva),0) as totalIVA " +
"from DetalleCompra "+
"where idCompra = "+IdCompra;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                ConexionSQL.CerrarConexion();
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                return null;
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static bool GuardarEditarEliminarCompra(DetalleCompra objCompra, int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.DetalleCompra.Add(objCompra);
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
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool EliminarLista(int IdCompra)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand command = ConexionSQL.connection.CreateCommand();
                command.CommandText = "delete DetalleCompra where idCompra="+IdCompra;
                command.ExecuteNonQuery();
                ConexionSQL.CerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static List<DetalleVenta> ConsultaListaCompleta()
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.DetalleVenta.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public static List<DetalleCompra> Lista_XidCompra(int IdCompra)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.DetalleCompra.AsNoTracking().Where(x => x.idCompra == IdCompra).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public static DetalleCompra ConsultaXidCompra(int id)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.DetalleCompra.AsNoTracking().Where(x => x.id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public static decimal SumaSubTotalCompra(int IdCompra)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    decimal? Suma = cn.DetalleCompra.AsNoTracking().Where(X => X.idCompra == IdCompra).Sum(y => (decimal?)y.totalDetalle);
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
        public static int SumaSubTotalDescuento(int IdCompra)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    int? Suma = cn.DetalleCompra.AsNoTracking().Where(X => X.idCompra == IdCompra).Sum(y => (int?)y.valorDescuento);
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
        public static int SumaSubTotalIVA(int IdCompra)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    int? Suma = cn.DetalleCompra.AsNoTracking().Where(X => X.idCompra == IdCompra).Sum(y => (int?)y.valorIva);
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
        public static List<V_DetalleCompra> listaXIdCompra(int IdCompa)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.V_DetalleCompra.AsNoTracking().Where(x => x.idCompra == IdCompa).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DetalleCompra ConsultarIdCompra_idInventario(int IdCompra,int IdInventario)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.DetalleCompra.AsNoTracking().Where(x => x.idCompra == IdCompra && x.idInventario == IdInventario).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static decimal SumaCompras(int IdInventario,int IdSede)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    decimal? suma = cn.V_DetalleCompra.AsNoTracking().Where(x => x.idSede == IdSede && x.idInventario == IdInventario).Sum(x => (decimal?)x.cantidad);
                    if (suma == null)
                    {
                        suma = 0;
                    }
                    return Convert.ToDecimal(suma);
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
        public static DetalleCompra ConsultaX_idDetalle(int id)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.DetalleCompra.AsNoTracking().Where(x => x.id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public static List<V_DetalleCompra> Filtrar_IdCompra(int IdCompra)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_DetalleCompra.AsNoTracking().Where(x => x.idCompra == IdCompra).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
    }
}

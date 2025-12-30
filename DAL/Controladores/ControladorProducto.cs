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
    public class ControladorProducto
    {
        public static bool GuardarEditarEliminarProducto(Producto objProducto, int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.Producto.Add(objProducto);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objProducto).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objProducto).State = System.Data.Entity.EntityState.Deleted;
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
        public static Producto ConsultarGuid(Guid guidPro)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.Producto.AsNoTracking().Where(x => x.guidProducto == guidPro).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_Producto> FiltrarCodigo(string codigo)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_Producto.AsNoTracking().Where(x => x.codigoProducto == codigo).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_Producto> FiltralDescripcion(string descripcion)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_Producto.AsNoTracking().Where(x => x.descripcionProducto.Contains(descripcion)).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_Producto> FiltralCategoria(int IdCategoria)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_Producto.AsNoTracking().Where(x => x.idCategoria == IdCategoria).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_Producto> listaCompleta(int elimi)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_Producto.AsNoTracking().Where(x=>x.eliminado==elimi).OrderByDescending(x => x.id).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }

        }

        public static List<V_ListaPrecios> ListaPrecios()
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_ListaPrecios.AsNoTracking().OrderBy(x=>x.descripcionProducto).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }

        }
        public static List<V_CostoInventario> ListaCostoInventario()
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_CostoInventario.AsNoTracking().OrderBy(x => x.descripcionProducto).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }

        }

        public static decimal  TotalListaCostoInventario()
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    decimal? suma = cn.V_CostoInventario.AsNoTracking().Sum(x => (decimal)x.costoInventario);
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

        public static DataTable listaCompleta_2()
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand command = ConexionSQL.connection.CreateCommand();
                command.CommandText = "select *from Producto";
                DataTable dt = new DataTable();
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                sqlData.Fill(dt);
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
        public static List<V_Producto> ListaAgotados()
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_Producto.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static Producto consultarIdProducto(int IdProducto)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.Producto.AsNoTracking().Where(x => x.id == IdProducto).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static int UltimoID()
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    int? max = cn.Producto.AsNoTracking().Max(x => (int?)x.id);
                    if (max == null)
                    {
                        max = 0;
                    }
                    return Convert.ToInt32(max);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
        public static List<v_productoVenta> FiltroVentaProducto_codigo(string codigo, int IdSede,int elimi)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.v_productoVenta.AsNoTracking().Where(x => x.codigoProducto == codigo && x.idSede == IdSede && x.eliminado==elimi).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<v_productoVenta> FiltroVentaProducto(string codigo,int IdListaPrecios,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.v_productoVenta.AsNoTracking().Where(x => 
                    x.idSede==IdSede &&
                    x.codigoProducto == codigo && x.idListaPrecios== IdListaPrecios).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<v_productoVenta> FiltrarX_IdCategoria_IdSede_IdEstado(int IdCategoria,int IdSede,int IdEstado)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.v_productoVenta.AsNoTracking().Where(x => x.idCategoria == IdCategoria &&
                    x.idSede == IdSede && x.idEstadoAI == IdEstado).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<v_productoVenta> FiltrarX_Descripcion_IdSede_IdEstado(string descripcion, int IdSede, int IdEstado)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.v_productoVenta.AsNoTracking().Where(x => 
                    x.codigoProducto.Contains(descripcion) ||
                    x.descripcionProducto.Contains(descripcion) &&
                    x.idSede == IdSede && x.idEstadoAI == IdEstado).OrderBy(x=>x.codigoProducto).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<v_productoVenta> FiltrarX_IdSede_IdEstado( int IdSede, int IdEstado)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.v_productoVenta.AsNoTracking().Where(x => x.idSede == IdSede && x.idEstadoAI == IdEstado).OrderBy(x=>x.codigoProducto).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<v_productoVenta> FiltrarX_IdSede(int IdSede,int elimi)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.v_productoVenta.AsNoTracking().Where(x => x.idSede == IdSede && x.eliminado==elimi).OrderBy(x => x.codigoProducto).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }

        }
        public static v_productoVenta BuscarCodigo(int IdSede, int IdEstado,string codigo)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.v_productoVenta.AsNoTracking().Where(x =>x.codigoProducto==codigo && 
                    x.idSede == IdSede && x.idEstadoAI == IdEstado).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static v_productoVenta Consultar_IdInventario_IdSede(int IdInventario,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.v_productoVenta.AsNoTracking().Where(x => x.idInventario == IdInventario &&
                    x.idSede == IdSede).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static v_productoVenta Consultar_Id(int idProducto_frm)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.v_productoVenta.AsNoTracking().Where(x => x.id == idProducto_frm).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static bool ConsultarCodigo(string codigo)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    Producto producto = new Producto();
                    producto = cn.Producto.Where(x => x.codigoProducto == codigo).FirstOrDefault();
                    if (producto != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
        public static DataTable Lista(int idCategoria_frm)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand command = ConexionSQL.connection.CreateCommand();
                command.CommandText = "select *from v_productoVenta where idCategoria="+idCategoria_frm;
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                ConexionSQL.CerrarConexion();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}

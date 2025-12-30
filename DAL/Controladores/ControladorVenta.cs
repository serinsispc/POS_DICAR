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
    public class ControladorVenta
    {
        public static bool Crud(TablaVentas tablaVentas,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.TablaVentas.Add(tablaVentas);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(tablaVentas).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(tablaVentas).State = System.Data.Entity.EntityState.Deleted;
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
        public static int HallarNumeroVenta(string Tipo,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    int? Numero = cn.TablaVentas.AsNoTracking().Where(x=>x.tipoFactura==Tipo && x.IdSede==IdSede).Max(x => (int?)x.numeroVenta);
                    if (Numero == null)
                    {
                        Numero = 0;
                    }
                    return Convert.ToInt32(Numero) + 1;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }

        public static TablaVentas ConsultaX_id(int IDVenta)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.TablaVentas.AsNoTracking().Where(x => x.id == IDVenta).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static V_TablaVentas ConsultaX_V_id(int IDVenta)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_TablaVentas.AsNoTracking().Where(x => x.id == IDVenta).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static TablaVentas ConsultaX_guid(Guid guidText)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.TablaVentas.AsNoTracking().Where(x => x.guidVenta == guidText).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static decimal TotalVentasTiendaAño(DateTime Fecha,string TipoVenta,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    decimal? Total = cn.V_TablaVentas.AsNoTracking().Where(x =>x.IdSede==IdSede && 
                    x.estadoVenta!="ANULADA" && 
                    //x.tipoVenta == TipoVenta && 
                    x.fechaVenta.Year == Fecha.Year).Sum(y => (decimal?)y.totalVenta);
                    if (Total == null)
                    {
                        Total = 0;
                    }
                    return Convert.ToDecimal(Total);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        public static decimal CostoTiendaAño(DateTime Fecha, string TipoVenta, int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    decimal? Total = cn.V_TablaVentas.AsNoTracking().Where(x => x.IdSede == IdSede && 
                    x.estadoVenta != "ANULADA" && 
                    //x.tipoVenta == TipoVenta && 
                    x.fechaVenta.Year == Fecha.Year).Sum(y => (decimal?)y.costoTotalVenta);
                    if (Total == null)
                    {
                        Total = 0;
                    }
                    return Convert.ToDecimal(Total);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        public static decimal TotalVentasTiendaMes(DateTime Fecha,string TipoVenta,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    decimal? Total = cn.V_TablaVentas.AsNoTracking().Where(x =>x.IdSede==IdSede && x.estadoVenta != "ANULADA" &&
                                                                    x.tipoVenta == TipoVenta &&
                                                                    x.fechaVenta.Year == Fecha.Year &&
                                                                     x.fechaVenta.Month == Fecha.Month).Sum(y => (decimal?)y.totalVenta);
                    if (Total == null)
                    {
                        Total = 0;
                    }
                    return Convert.ToDecimal(Total);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        public static decimal CostoTiendaMes(DateTime Fecha, string TipoVenta, int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    decimal? Total = cn.V_TablaVentas.AsNoTracking().Where(x => x.IdSede == IdSede && x.estadoVenta != "ANULADA" &&
                                                                    //x.tipoVenta == TipoVenta &&
                                                                    x.fechaVenta.Year == Fecha.Year &&
                                                                     x.fechaVenta.Month == Fecha.Month).Sum(y => (decimal?)y.costoTotalVenta);
                    if (Total == null)
                    {
                        Total = 0;
                    }
                    return Convert.ToDecimal(Total);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        public static decimal TotalVentasTiendaDia(DateTime Fecha,string TipoVenta,int idSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    decimal? Total = cn.V_TablaVentas.AsNoTracking().Where(x =>
                    x.IdSede == idSede &&
                    x.estadoVenta != "ANULADA" &&
                    //x.tipoVenta == TipoVenta &&
                    x.fechaVenta.Year == Fecha.Year &&
                    x.fechaVenta.Month == Fecha.Month &&
                    x.fechaVenta.Day == Fecha.Day).Sum(y => (decimal?)y.totalVenta);
                    if (Total == null)
                    {
                        Total = 0;
                    }
                    return Convert.ToDecimal(Total);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        public static decimal CostoTiendaDia(DateTime Fecha, string TipoVenta, int idSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    decimal? Total = cn.V_TablaVentas.AsNoTracking().Where(x =>
                    x.IdSede == idSede &&
                    x.estadoVenta != "ANULADA" &&
                    //x.tipoVenta == TipoVenta &&
                    x.fechaVenta.Year == Fecha.Year &&
                    x.fechaVenta.Month == Fecha.Month &&
                    x.fechaVenta.Day == Fecha.Day).Sum(y => (decimal?)y.costoTotalVenta);
                    if (Total == null)
                    {
                        Total = 0;
                    }
                    return Convert.ToDecimal(Total);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        public static decimal HallarUltimoID()
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    decimal? UltimoID = cn.TablaVentas.AsNoTracking().Max(x => x.id);
                    if (UltimoID == null)
                    {
                        UltimoID = 0;
                    }
                    return Convert.ToDecimal(UltimoID);
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static DataTable FiltroX_H_Año(DateTime Fecha,int IdSede)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_TablaVentas where IdSede="+IdSede+" and YEAR(fechaVenta)=" + Fecha.Year;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
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
        public static DataTable FiltroX_H_Mes(DateTime Fecha,int IdSede)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_TablaVentas where IdSede=" + IdSede + " and YEAR(fechaVenta)=" + Fecha.Year + " and " +
                "MONTH(fechaVenta) = " + Fecha.Month;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
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
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable FiltroX_H_Dia(DateTime Fecha,int IdSede)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_TablaVentas where IdSede=" + IdSede + " and YEAR(fechaVenta)=" + Fecha.Year+" and "+
                "MONTH(fechaVenta) = "+Fecha.Month+" and DAY(fechaVenta) = "+Fecha.Day;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
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



        public static DataTable FiltroX_H_Año_Detalle(DateTime Fecha, int IdSede)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_InformeDetalleVenta where idSedeDetalle=" + IdSede + " and YEAR(fechaVentaDetalle)=" + Fecha.Year;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
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
        public static DataTable FiltroX_H_Mes_Detalle(DateTime Fecha, int IdSede)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_InformeDetalleVenta where idSedeDetalle=" + IdSede + " and YEAR(fechaVentaDetalle)=" + Fecha.Year + " and " +
                "MONTH(fechaVentaDetalle) = " + Fecha.Month;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
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
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable FiltroX_H_Dia_Detalle(DateTime Fecha, int IdSede)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_InformeDetalleVenta where idSedeDetalle=" + IdSede + " and YEAR(fechaVentaDetalle)=" + Fecha.Year + " and " +
                "MONTH(fechaVentaDetalle) = " + Fecha.Month + " and DAY(fechaVentaDetalle) = " + Fecha.Day;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
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



        public static DataTable FiltroX_H_Año_IdCategorias(DateTime Fecha, int IdSede,int IdCategoria)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_ListaVentaCategoria where idSede_c=" + IdSede + " and idCategoria_c="+IdCategoria+" and YEAR(fechaVenta_c)=" + Fecha.Year;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
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
        public static DataTable FiltroX_H_Mes_IdCategorias(DateTime Fecha, int IdSede,int IdCategoria)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_ListaVentaCategoria where idSede_c=" + IdSede + " and idCategoria_c=" + IdCategoria + " and YEAR(fechaVenta_c)=" + Fecha.Year + " and " +
                "MONTH(fechaVenta_c) = " + Fecha.Month;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
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
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable FiltroX_H_Dia_IdCategorias(DateTime Fecha, int IdSede,int IdCategoria)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_ListaVentaCategoria where idSede_c=" + IdSede + " and idCategoria_c=" + IdCategoria + " and YEAR(fechaVenta_c)=" + Fecha.Year + " and " +
                "MONTH(fechaVenta_c) = " + Fecha.Month + " and DAY(fechaVenta_c) = " + Fecha.Day;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
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



        public static DataTable FiltroX_H_Año_Categorias(DateTime Fecha, int IdSede)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_ListaVentaCategoria where idSede_c=" + IdSede + " and YEAR(fechaVenta_c)=" + Fecha.Year;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
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
        public static DataTable FiltroX_H_Mes_Categorias(DateTime Fecha, int IdSede)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_ListaVentaCategoria where idSede_c=" + IdSede + " and YEAR(fechaVenta_c)=" + Fecha.Year + " and " +
                "MONTH(fechaVenta_c) = " + Fecha.Month;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
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
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable FiltroX_H_Dia_Categorias(DateTime Fecha, int IdSede)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_ListaVentaCategoria where idSede_c=" + IdSede + " and YEAR(fechaVenta_c)=" + Fecha.Year + " and " +
                "MONTH(fechaVenta_c) = " + Fecha.Month + " and DAY(fechaVenta_c) = " + Fecha.Day;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
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




        public static DataTable FiltroX_H_Año_INFOCategorias(DateTime Fecha, int IdSede)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText =

                    "select c.id as id_inf,c.nombreCategoria as nombreCategoria_inf," +

                    "(select " +
                    "isnull(SUM(cantidadDetalle), 0) " +
                    "from V_DetalleCaja inner join " +
                    "TablaVentas on V_DetalleCaja.idVenta = TablaVentas.id inner join " +
                    "Precios on V_DetalleCaja.idPrecios = Precios.id inner join " +
                    "Inventario on Precios.idInventario = Inventario.id inner join " +
                    "Producto on Inventario.idProducto = Producto.id " +
                    "where Producto.idCategoria = c.id and " +
                    "TablaVentas.IdSede = "+IdSede+" and " +
                    "  YEAR(fechaVenta) = "+Fecha.Year+ ") as cantidadProductos_inf, " +

                    "(select " +
                    "isnull(SUM(totalDetalle), 0) " +
                    "from V_DetalleCaja inner join " +
                    "TablaVentas on V_DetalleCaja.idVenta = TablaVentas.id inner join " +
                    "Precios on V_DetalleCaja.idPrecios = Precios.id inner join " +
                    "Inventario on Precios.idInventario = Inventario.id inner join " +
                    "Producto on Inventario.idProducto = Producto.id " +
                    "where Producto.idCategoria = c.id and " +
                    "TablaVentas.IdSede = "+IdSede+" and " +
                    "  YEAR(fechaVenta) = "+Fecha.Year+ ") as totalVentas_inf " +

                    "from CategoriaProducto c";




                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
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
        public static DataTable FiltroX_H_Mes_INFOCategorias(DateTime Fecha, int IdSede)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText =

                    "select c.id as id_inf,c.nombreCategoria as nombreCategoria_inf," +

                    "(select " +
                    "isnull(SUM(cantidadDetalle), 0) " +
                    "from V_DetalleCaja inner join " +
                    "TablaVentas on V_DetalleCaja.idVenta = TablaVentas.id inner join " +
                    "Precios on V_DetalleCaja.idPrecios = Precios.id inner join " +
                    "Inventario on Precios.idInventario = Inventario.id inner join " +
                    "Producto on Inventario.idProducto = Producto.id " +
                    "where Producto.idCategoria = c.id and " +
                    "TablaVentas.IdSede = " + IdSede + " and " +
                    "  YEAR(fechaVenta) = " + Fecha.Year + " and " +
                    "  MONTH(fechaVenta) = " + Fecha.Month + ") as cantidadProductos_inf, " +

                    "(select " +
                    "isnull(SUM(totalDetalle), 0) " +
                    "from V_DetalleCaja inner join " +
                    "TablaVentas on V_DetalleCaja.idVenta = TablaVentas.id inner join " +
                    "Precios on V_DetalleCaja.idPrecios = Precios.id inner join " +
                    "Inventario on Precios.idInventario = Inventario.id inner join " +
                    "Producto on Inventario.idProducto = Producto.id " +
                    "where Producto.idCategoria = c.id and " +
                    "TablaVentas.IdSede = " + IdSede + " and " +
                    "  YEAR(fechaVenta) = " + Fecha.Year + " and " +
                    "  MONTH(fechaVenta) = " + Fecha.Month + ") as totalVentas_inf " +

                    "from CategoriaProducto c";




                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
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
        public static DataTable FiltroX_H_Dia_INFOCategorias(DateTime Fecha, int IdSede)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText =

                    "select c.id as id_inf,c.nombreCategoria as nombreCategoria_inf," +

                    "(select " +
                    "isnull(SUM(cantidadDetalle), 0) " +
                    "from V_DetalleCaja inner join " +
                    "TablaVentas on V_DetalleCaja.idVenta = TablaVentas.id inner join " +
                    "Precios on V_DetalleCaja.idPrecios = Precios.id inner join " +
                    "Inventario on Precios.idInventario = Inventario.id inner join " +
                    "Producto on Inventario.idProducto = Producto.id " +
                    "where Producto.idCategoria = c.id and " +
                    "TablaVentas.IdSede = " + IdSede + " and " +
                    "  YEAR(fechaVenta) = " + Fecha.Year + " and " +
                    "  MONTH(fechaVenta) = " + Fecha.Month + " and " +
                    "  DAY(fechaVenta) = " + Fecha.Day + ") as cantidadProductos_inf, " +

                    "(select " +
                    "isnull(SUM(totalDetalle), 0) " +
                    "from V_DetalleCaja inner join " +
                    "TablaVentas on V_DetalleCaja.idVenta = TablaVentas.id inner join " +
                    "Precios on V_DetalleCaja.idPrecios = Precios.id inner join " +
                    "Inventario on Precios.idInventario = Inventario.id inner join " +
                    "Producto on Inventario.idProducto = Producto.id " +
                    "where Producto.idCategoria = c.id and " +
                    "TablaVentas.IdSede = " + IdSede + " and " +
                    "  YEAR(fechaVenta) = " + Fecha.Year + " and " +
                    "  MONTH(fechaVenta) = " + Fecha.Month + " and " +
                    "  DAY(fechaVenta) = " + Fecha.Day + ") as totalVentas_inf " +

                    "from CategoriaProducto c";




                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
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



        public static List<V_TablaVentas> listaCompleta(int IdSede)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.V_TablaVentas.AsNoTracking().Where(x=>x.IdSede==IdSede && x.numeroVenta>0).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_TablaVentas> filtroNumeroVenta(int NumeroV,int IdSede)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.V_TablaVentas.AsNoTracking().Where(x => x.numeroVenta == NumeroV && x.IdSede==IdSede).ToList();
                }
            }
            catch(Exception ex)
            {
                string Error = ex.Message;
                return null;
            }
        }
        public static List<V_TablaVentas> filtroDia(DateTime Fecha,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.V_TablaVentas.AsNoTracking().Where(x => x.fechaVenta.Year == Fecha.Year &&
                                                                  x.fechaVenta.Month == Fecha.Month &&
                                                                  x.fechaVenta.Day == Fecha.Day &&
                                                                  x.IdSede==IdSede).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_TablaVentas> filtroMes(DateTime Fecha,int IDSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_TablaVentas.AsNoTracking().Where(x => x.fechaVenta.Year == Fecha.Year &&
                                                                  x.fechaVenta.Month == Fecha.Month &&
                                                                  x.IdSede==IDSede).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_TablaVentas> filtroAño(DateTime Fecha,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_TablaVentas.AsNoTracking().Where(x => x.fechaVenta.Year == Fecha.Year && x.IdSede==IdSede).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static int HallarTotalVentasEfectivo (string TipoVenta,string EstadoVenta,int IdBase)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select "+
                "isnull(SUM(totalVenta), 0) - ISNULL(SUM(abonoTarjeta), 0) as totalVentasEfectivo "+
                "from V_TablaVentas "+
                "where tipoVenta = '"+ TipoVenta + "' and "+
                "estadoVenta <> '"+ EstadoVenta + "' and "+
                "idBaseCaja = " + IdBase;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                ConexionSQL.CerrarConexion();
                if (dt.Rows.Count > 0)
                {
                    foreach(DataRow rows in dt.Rows)
                    {
                        return Convert.ToInt32(rows["totalVentasEfectivo"]);
                    }
                }
                return 0;
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
        public static int HallarTotalVentasTarjeta(string TipoVenta, string EstadoVenta, int IdBase)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select " +
                "isnull(SUM(abonoTarjeta), 0) as totalVentasTarjeta " +
                "from V_TablaVentas " +
                "where tipoVenta = '" + TipoVenta + "' and " +
                "estadoVenta <> '" + EstadoVenta + "' and " +
                "idBaseCaja = " + IdBase;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                ConexionSQL.CerrarConexion();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow rows in dt.Rows)
                    {
                        return Convert.ToInt32(rows["totalVentasTarjeta"]);
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
        public static V_R_VentaCliente ConsultarX_IdCleinte_EstadoVenta(int IdCliente,string estado)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.V_R_VentaCliente.AsNoTracking().Where(x => x.idCliente == IdCliente && x.estadoVenta == estado).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_FacturasCredito> ListaFacturasCredito(int IDCliente,int Id_Sede)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.V_FacturasCredito.AsEnumerable().Where(X=>
                    X.IdSede==Id_Sede &&
                    X.idCliente== IDCliente).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_TablaVentas> filtrarVentas_0()
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_TablaVentas.AsNoTracking().Where(x => x.totalVenta == 0).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static V_TablaVentas ConsultarVentas_0()
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_TablaVentas.AsNoTracking().Where(x =>x.totalVenta == 0).FirstOrDefault();
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

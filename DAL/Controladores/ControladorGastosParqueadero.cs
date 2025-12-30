using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorGastos
    {
        /// <summary>
        /// Prosediiento encargado de crear, editar y eliminar dependiendo el caso
        /// </summary>
        /// <param name="objGastoP"></param>
        /// <param name="Boton"></param>
        /// <returns></returns>
        public static bool Guardar_Editar_Eliminar_Gasto(Gastos objGastoP,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.Gastos.Add(objGastoP);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objGastoP).State = System.Data.Entity.EntityState.Modified;
                    }
                    if(Boton == 2)
                    {
                        cn.Entry(objGastoP).State = System.Data.Entity.EntityState.Deleted;
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
        /// <summary>
        /// Consulta Toda la lista de gastos
        /// </summary>
        /// <returns></returns>
        public static List<V_Gastos> ConsultaTodosLosGastos(int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_Gastos.AsNoTracking().Where(x=>x.idSede==IdSede).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }

        }
        /// <summary>
        /// Consulta gasto por id
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static Gastos ConsultaGastoXId(int pid)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.Gastos.AsNoTracking().Where(x => x.id == pid).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        /// <summary>
        /// Consulta gasto por fecha
        /// </summary>
        /// <param name="pFecha"></param>
        /// <returns></returns>
        public static List <V_Gastos> ConsultaGastoXFecha(DateTime pFecha)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_Gastos.AsNoTracking().Where(x => x.fecha.Year == pFecha.Year &&
                                                                         x.fecha.Month == pFecha.Month &&
                                                                         x.fecha.Day == pFecha.Day).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        /// <summary>
        /// Consulta el total de gastos del dia seleccionado 
        /// </summary>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        public static int HallarTotalGastosDia(DateTime Fecha,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    int? Total = cn.Gastos.AsNoTracking().Where(x =>x.idSede==IdSede && x.fecha.Year == Fecha.Year &&
                                                                               x.fecha.Month == Fecha.Month &&
                                                                               x.fecha.Day == Fecha.Day).Sum(y => (int?)y.valor);
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
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        public static int HallarTotalGastoFull(int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    int? Total = cn.Gastos.AsNoTracking().Where(x=>x.idSede==IdSede).Sum(y => (int?)y.valor);
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
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        /// <summary>
        /// sumar el total de gastos del mes
        /// </summary>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        public static int HallarTotalGastosMes(DateTime Fecha,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    int? Total = cn.Gastos.AsNoTracking().Where(x =>x.idSede==IdSede && x.fecha.Year == Fecha.Year &&
                                                                              x.fecha.Month == Fecha.Month).Sum(y => (int?)y.valor);
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
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        /// <summary>
        /// suma total de gastos del año
        /// </summary>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        public static int HallarTotalGastosAño(DateTime Fecha,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    int? Total = cn.Gastos.AsNoTracking().Where(x => x.idSede == IdSede && x.fecha.Year == Fecha.Year).Sum(y => (int?)y.valor);
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
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        /// <summary>
        /// Huna todo los egresos del dia actual
        /// </summary>
        /// <param name="pfecha"></param>
        /// <returns></returns>
        public static int HallarValorEgresoParqueadero(DateTime pfecha)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    int? sumaegresoparqueadero = cn.Gastos.AsNoTracking().Where(x => x.fecha.Year == pfecha.Year &&
                                                                                                x.fecha.Month == pfecha.Month &&
                                                                                                x.fecha.Day == pfecha.Day).Sum(y => (int?)y.valor);
                    if (sumaegresoparqueadero == null)
                    {
                        sumaegresoparqueadero = 0;
                    }
                    return Convert.ToInt32(sumaegresoparqueadero);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        public static List<V_Gastos>FiltrarX_Año(DateTime FechaFiltro,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.V_Gastos.AsNoTracking().Where(x =>x.idSede==IdSede && x.fecha.Year == FechaFiltro.Year).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static List<V_Gastos> FiltrarX_Mes(DateTime FechaFiltro,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_Gastos.AsNoTracking().Where(x =>x.idSede ==IdSede && x.fecha.Year == FechaFiltro.Year&&
                                                                     x.fecha.Month==FechaFiltro.Month).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static List<V_Gastos> FiltrarX_Dia(DateTime FechaFiltro,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_Gastos.AsNoTracking().Where(x =>
                    x.idSede ==IdSede && 
                    x.fecha.Year == FechaFiltro.Year &&
                    x.fecha.Month == FechaFiltro.Month&&
                    x.fecha.Day==FechaFiltro.Day).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static int TotalGastosBolsillo(int Bolsillo,int idBase)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    int? Gasto = cn.Gastos.AsNoTracking().Where(x =>
                                                                         x.idBolsillo == Bolsillo &&
                                                                         x.idBasecaja==idBase).Sum(x => (int?)x.valor);
                    if (Gasto == null)
                    {
                        Gasto = 0;
                    }
                    return Convert.ToInt32(Gasto);
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

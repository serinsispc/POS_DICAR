using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores.Contabilidad
{
    public class ControladorLibroDiario
    {
        public static bool CrearEditarEliminarLibroDiario(LibroDiario objLibro,int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.LibroDiario.Add(objLibro);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objLibro).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objLibro).State = System.Data.Entity.EntityState.Deleted;
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
        public static LibroDiario consultarID(int IDLibro)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.LibroDiario.AsNoTracking().Where(x => x.id == IDLibro).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static int hallarUltimoSaldo()
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    int? IDLibro = cn.LibroDiario.AsNoTracking().Max(x => x.id);
                    if (IDLibro == null)
                    {
                        IDLibro = 0;
                    }
                    return Convert.ToInt32(IDLibro);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static List<V_LibroDiario> listaCompleta()
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.V_LibroDiario.AsNoTracking().ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static List<V_LibroDiario> filtroAño(DateTime Fecha)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_LibroDiario.AsNoTracking().Where(x=>x.fechaMovimiento.Value.Year==Fecha.Year).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static List<V_LibroDiario> filtroMes(DateTime Fecha)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_LibroDiario.AsNoTracking().Where(x => x.fechaMovimiento.Value.Year == Fecha.Year &&
                                                                    x.fechaMovimiento.Value.Month == Fecha.Month).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static List<V_LibroDiario> filtroDia(DateTime Fecha)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_LibroDiario.AsNoTracking().Where(x => x.fechaMovimiento.Value.Year == Fecha.Year &&
                                                                    x.fechaMovimiento.Value.Month == Fecha.Month &&
                                                                    x.fechaMovimiento.Value.Day == Fecha.Day).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static LibroDiario consultaMotivoIdBolsillo(string Detalle,int IdBol)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.LibroDiario.AsNoTracking().Where(x => x.motivoMovimiento == Detalle && x.idBolsillo ==IdBol).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

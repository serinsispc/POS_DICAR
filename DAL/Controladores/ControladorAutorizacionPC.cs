using DAL.Modelo;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores.Administrador
{
    public class ControladorAutorizacionPC
    {
        public static bool Crear_Editar_Eliminar_Equipo(AutorizacionPC objAE, int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.AutorizacionPC.Add(objAE);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objAE).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objAE).State = System.Data.Entity.EntityState.Deleted;
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
        public static List<AutorizacionPC> listaCompleta()
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.AutorizacionPC.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
               //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public static AutorizacionPC ConsultarXSerial(string Serial, string Manufacture, string Producto, string Vercion, int Estado)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.AutorizacionPC.AsNoTracking().Where(x => x.serialnumber_pc == Serial &&
                                                                       x.Manufacturer_pc == Manufacture &&
                                                                       x.product_pc == Producto &&
                                                                       x.Version_pc == Vercion &&
                                                                       x.estado_equipo == Estado).FirstOrDefault();
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

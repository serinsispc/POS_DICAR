using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores.Administrador
{
    public class ControladorAdminControl
    {
        public static AdminControl Consultar()
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.AdminControl.AsNoTracking().Where(x => x.tipo_admincontrol != 0).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión." , "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public static List<AdminControl> listaCompleta()
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.AdminControl.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public static AdminControl Consultar2()
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.AdminControl.AsNoTracking().Where(x => x.id_admincontrol > 1 && x.tipo_admincontrol != 0).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public static AdminControl ConsularXId(int ID)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.AdminControl.AsNoTracking().Where(x => x.id_admincontrol > ID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public static bool Crear_Editar_Elimiar_Mensaje(AdminControl Obja, int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.AdminControl.Add(Obja);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(Obja).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(Obja).State = System.Data.Entity.EntityState.Deleted;
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
    }
}

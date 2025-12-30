using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorUsuario
    {
        /// <summary>
        /// Controlador que se encarga de guardar, editar y eliminar un usuaio.
        /// </summary>
        /// <param name="objUsuario"></param>
        /// <param name="Boton"></param>
        /// <returns></returns>
        public static bool GuardarEditarEliminar(Usuario objUsuario, int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.Usuario.Add(objUsuario);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objUsuario).State = System.Data.Entity.EntityState.Modified;
                    }
                    if(Boton == 2)
                    {
                        cn.Entry(objUsuario).State = System.Data.Entity.EntityState.Deleted;
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
        public static List<v_Usuario> listaCompleta()
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.v_Usuario.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        /// <summary>
        /// Controlador que consulta la cuenta de usuario y la clave
        /// </summary>
        /// <param name="p_usuario"></param>
        /// <param name="p_clave"></param>
        /// <returns></returns>
        public static Usuario ConsultaUsuarioYClave(string p_usuario,string p_clave)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.Usuario.AsNoTracking().Where(x => x.cuentaUsuario == p_usuario &&
                                                              x.claveUsuario == p_clave).FirstOrDefault();
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
        /// controlados que consulta el id usuario 
        /// </summary>
        /// <param name="p_isUsuario"></param>
        /// <returns></returns>
        public static Usuario ConsultaUsuarioXId(int p_isUsuario)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.Usuario.AsNoTracking().Where(x => x.id == p_isUsuario).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }

        }
        /// <summary>
        /// controlador que se encarga de llamar toda la lista
        /// </summary>
        /// <returns></returns>
        public static List<Usuario> ConsultaListaCompletaUsuario()
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.Usuario.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public static List<Usuario> FiltroX_Usuario(string Usuario)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.Usuario.AsNoTracking().Where(x => x.cuentaUsuario.Contains(Usuario)).ToList();
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

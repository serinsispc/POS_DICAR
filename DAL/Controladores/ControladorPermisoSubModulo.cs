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
    public class ControladorPermisoSubModulo
    {
        public static bool CrearEliminarPermisomodulo(PermisoSubModulo objPermiso, int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.PermisoSubModulo.Add(objPermiso);
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objPermiso).State = System.Data.Entity.EntityState.Deleted;
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
        public static List<PermisoSubModulo> filtroIdUsuario(int IdUsuario)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.PermisoSubModulo.AsNoTracking().Where(x => x.idUsuario == IdUsuario).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable consultarIdusuario(int IdUsuario)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from PermisoSubModulo where idUsuario="+IdUsuario;
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
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static PermisoSubModulo consultarIdSubModuloIdusuario(int IdUsuario,int IdSubmodulo)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.PermisoSubModulo.AsNoTracking().Where(x => x.idUsuario == IdUsuario && x.idSubModulo == IdSubmodulo).FirstOrDefault();
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

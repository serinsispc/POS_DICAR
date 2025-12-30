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
    public class ControladorPermisoModulo
    {
        public static PermisoModulo consultarIdModuloIdusuario(int IdUsuario, int IdModulo)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.PermisoModulo.AsNoTracking().Where(x => x.idUsuario == IdUsuario && x.idModulo == IdModulo).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static bool CrearEliminarPermisomodulo(PermisoModulo objPermiso,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn=new Modelo.SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.PermisoModulo.Add(objPermiso);
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objPermiso).State=System.Data.Entity.EntityState.Deleted;
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
        public static List<PermisoModulo>filtroIdUsuario(int IdUsuario)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.PermisoModulo.AsNoTracking().Where(x => x.idUsuario == IdUsuario).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable consultarIdUsuario(int IdUsuario)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from PermisoModulo where idUsuario="+IdUsuario;
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
    }
}

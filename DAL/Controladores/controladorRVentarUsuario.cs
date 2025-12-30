using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorRVentarUsuario
    {
        public static R_VentaUsuario Consultar_IdUsuario_IdVenta(int IdUser, int IdVenta, int IdEstado)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.R_VentaUsuario.AsNoTracking().Where(x => x.idUsuario == IdUser && x.idVenta == IdVenta && x.estado == IdEstado).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static bool CrearEditarEliminarR_VentaUsuario(R_VentaUsuario objR,int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.R_VentaUsuario.Add(objR);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objR).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objR).State = System.Data.Entity.EntityState.Deleted;
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
        public static R_VentaUsuario Consultar_IdUsuario_Estado(int IdUser, int estado)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.R_VentaUsuario.AsNoTracking().Where(x => x.idUsuario == IdUser && x.estado == estado).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static DataTable Lista(int IdUser, int estado)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand command = ConexionSQL.connection.CreateCommand();
                command.CommandText = "select *from R_VentaUsuario where idUsuario=" + IdUser + " and estado=" + estado;
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

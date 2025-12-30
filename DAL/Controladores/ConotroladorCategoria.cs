using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Controladores.Tienda
{
    public class ConotroladorCategoria
    {
        public static bool Crear_Editar_Eliminar_Categoria(CategoriaProducto objCategoria, int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.CategoriaProducto.Add(objCategoria);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objCategoria).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objCategoria).State = System.Data.Entity.EntityState.Deleted;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
        public static List<v_CategoriaProducto> listaCompleta()
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.v_CategoriaProducto.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static DataTable Lista()
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand command = ConexionSQL.connection.CreateCommand();
                command.CommandText = "select *from v_CategoriaProducto";
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

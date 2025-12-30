using DAL.Modelo;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorProveedor
    {
        public static bool GuardarEditarEliminar(Proveedor objProveedor,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.Proveedor.Add(objProveedor);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objProveedor).State = System.Data.Entity.EntityState.Modified;
                    }
                    if(Boton == 2)
                    {
                        cn.Entry(objProveedor).State = System.Data.Entity.EntityState.Deleted;
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
        public static async Task<List<SQL.Views.V_Proveedor>> listaCompleta()
        {
            try
            {
                var api= new ClassAPI();
                var url = $"/api/V_Proveedor/GetProveedores";
                var respuesta = await api.HttpWebRequestPostAsync(url);
                var lista=JsonConvert.DeserializeObject<List<SQL.Views.V_Proveedor>>(respuesta);
                return lista;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }

        }
        public static Proveedor ConsultaXProveedor_Nit(string Proveedor,string Nit) 
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.Proveedor.AsNoTracking().Where(X => X.nombreProveedor == Proveedor ||
                                                                X.documentoProveedor == Nit).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public static Proveedor ConsultarX_IdProveedor(int IdProveedor)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.Proveedor.AsNoTracking().Where(x => x.id== IdProveedor).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static List<Proveedor> FiltroX_Proveedor(string Proveedor)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.Proveedor.AsNoTracking().Where(x=>x.nombreProveedor.Contains(Proveedor)).OrderBy(x=>x.nombreProveedor).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public static Proveedor ConsultarX_Nit(string Nit)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.Proveedor.AsNoTracking().Where(x => x.documentoProveedor == Nit).FirstOrDefault();
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

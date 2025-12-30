using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAL.Modelo;

namespace DAL.Controladores.Administrador
{
    public class ControladorCategoriaProducto
    {
        public static bool Crear_Editar_Eliminar_Categoria(CategoriaProducto objCategoria,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    if(Boton == 0)
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
        public static List<CategoriaProducto> ListaCompleta()
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.CategoriaProducto.AsNoTracking().OrderBy(x=>x.nombreCategoria).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static CategoriaProducto ConsultarGuid(Guid guidCat)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.CategoriaProducto.AsNoTracking().Where(x => x.guidCategoria == guidCat).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static List< CategoriaProducto> FiltroX_Categoria(string Categoria)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.CategoriaProducto.AsNoTracking().Where(x => x.nombreCategoria.Contains(Categoria)).OrderBy(x=>x.nombreCategoria).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static CategoriaProducto ConsultarMayorA(int IDCategoria)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.CategoriaProducto.AsNoTracking().Where(x => x.id >= IDCategoria).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static CategoriaProducto ConsultarNombre(string nombre)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.CategoriaProducto.AsNoTracking().Where(x => x.nombreCategoria == nombre).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static CategoriaProducto ConsulatarID(int Id)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.CategoriaProducto.AsNoTracking().Where(x => x.id == Id).FirstOrDefault();
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

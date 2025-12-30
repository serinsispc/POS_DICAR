using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;
using System.Data.SqlClient;

namespace DAL.Controladores
{
    public class controladorInventario
    {
        public static bool CrearEditarEliminarInventario(Inventario objINventario,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.Inventario.Add(objINventario);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objINventario).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objINventario).State = System.Data.Entity.EntityState.Deleted;
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
        public static Inventario ConsultarId(int IdInventario)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.Inventario.AsNoTracking().Where(x => x.id == IdInventario).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static Inventario ConsultarIdProducto_IdPresentacion(int IdPro,int IdPres,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.Inventario.AsNoTracking().Where(x => x.idProducto == IdPro && 
                    x.idPresentacion==IdPres &&
                    x.idSede== IdSede).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_Inventario> ListaCompleta(int IdProducto,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_Inventario.AsNoTracking().Where(x=>x.idProducto==IdProducto && x.idSede==IdSede).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static Inventario ConsultarGuid(int IdProducto,int IdSede)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.Inventario.AsNoTracking().Where(x => x.idProducto == IdProducto && x.idSede == IdSede).FirstOrDefault();
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

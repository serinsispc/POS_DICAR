using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorInventarioTotal
    {
        public static bool CrearEditarEliminarInventarioTotal(InventarioTotal inventarioTotal,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.InventarioTotal.Add(inventarioTotal);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(inventarioTotal).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(inventarioTotal).State = System.Data.Entity.EntityState.Deleted;
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
        public static InventarioTotal ConsultarIdProducto(int IdProducto,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.InventarioTotal.AsNoTracking().Where(x => x.idProducto == IdProducto && x.idSede==IdSede).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static InventarioTotal ConsultarId(int Id)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.InventarioTotal.AsNoTracking().Where(x => x.id == Id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_InventarioTotal> Filtrar_IdSede_IdProducto(int IdSede,int IdProducto)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_InventarioTotal.AsNoTracking().Where(x => x.idSedeIT == IdSede && x.idProductoIT == IdProducto).ToList();
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

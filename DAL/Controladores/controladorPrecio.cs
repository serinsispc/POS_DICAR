using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorPrecio
    {
        public static bool CrearEditarEliminarCostoPrecio(Precios objCosto, int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.Precios.Add(objCosto);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objCosto).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objCosto).State = System.Data.Entity.EntityState.Deleted;
                    }
                    cn.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
        public static Precios ConsultarIdInventario(int IdInventario)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.Precios.AsNoTracking().Where(x => x.idInventario == IdInventario).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static Precios ConsultarId(int IdPrecio)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.Precios.AsNoTracking().Where(x => x.id == IdPrecio).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static Precios ConsultarIdInventario_IdLista(int IdInvent, int IdLista)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.Precios.AsNoTracking().Where(x => x.idInventario == IdInvent && x.idListaPrecios == IdLista).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_Precios> ListaCompleta(int IdInventario,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_Precios.AsNoTracking().Where(x =>x.idSede==IdSede && x.idInventario_v == IdInventario).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static Precios Consultar_IdProducto_IdINventario_IdListaPrecios(int IdProducto,int IdInventario,int IdListaPrecios)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.Precios.AsNoTracking().Where(x => x.idProducto == IdProducto &&
                    x.idInventario == IdInventario && x.idListaPrecios == IdListaPrecios).FirstOrDefault();
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

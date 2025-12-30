using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorArchivoCompra
    {
        public static bool CrearEditarEliminar(ArchivoCompras archivoCompras, int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.ArchivoCompras.Add(archivoCompras);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(archivoCompras).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(archivoCompras).State = System.Data.Entity.EntityState.Deleted;
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
        public static ArchivoCompras ConsultarGuidArchivo(Guid guid)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.ArchivoCompras.AsNoTracking().Where(x => x.guidArchivo == guid).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static ArchivoCompras ConsultarIdArchivo(int Id)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.ArchivoCompras.AsNoTracking().Where(x => x.id == Id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_ArchivoCompras> Listra_IdCompra(int IdCompra)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_ArchivoCompras.AsNoTracking().Where(x => x.idCompra == IdCompra).ToList();
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

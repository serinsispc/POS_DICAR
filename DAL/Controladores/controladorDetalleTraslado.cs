using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorDetalleTraslado
    {
        public static DetalleTraslado consultar_IdDetalle(int IdDetalle)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.DetalleTraslado.AsNoTracking().Where(x => x.id == IdDetalle).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static bool CrearEditarEliminar_DetalleTraslado(DetalleTraslado objDetalle,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.DetalleTraslado.Add(objDetalle);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objDetalle).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objDetalle).State = System.Data.Entity.EntityState.Deleted;
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
        public static List<V_DetalleTraslado> Filtrar_Guid(string GuidTex)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.V_DetalleTraslado.AsNoTracking().Where(x => x.v_guidDetalleTraslado == GuidTex).ToList();
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

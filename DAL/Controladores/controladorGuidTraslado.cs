using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorGuidTraslado
    {
        public static bool CrearEditarEliminar_GuidTraslado(GuidTraslados objGuidTraslado,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.GuidTraslados.Add(objGuidTraslado);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objGuidTraslado).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objGuidTraslado).State = System.Data.Entity.EntityState.Deleted;
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
        public static GuidTraslados Consultar_IdSede_Estado(int IdSede,int Estado)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.GuidTraslados.AsNoTracking().Where(x =>
                    x.idSedeTraslado == IdSede &&
                    x.estadoGuidTraslado == Estado).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static GuidTraslados Consultar_Guid(string GuidTex)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.GuidTraslados.AsNoTracking().Where(x =>
                    x.guidTex == GuidTex).FirstOrDefault();
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

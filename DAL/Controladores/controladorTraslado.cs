using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;

namespace DAL.Controladores
{
    public class controladorTraslado
    {
        public static bool CrearEditarEliminarTraslado(Traslados objTraslado, int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.Traslados.Add(objTraslado);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objTraslado).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objTraslado).State = System.Data.Entity.EntityState.Deleted;
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
        public static List<V_Traslados> listacompleta(int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_Traslados.AsNoTracking().Where(x => x.v_idSedeTraslado == IdSede).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static Traslados ConsultarGuid(string GuidTex)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.Traslados.AsNoTracking().Where(x => x.guidTraslado == GuidTex).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_Traslados> filtroFechaDIa(int IdSede, DateTime fecha)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_Traslados.AsNoTracking().Where(x =>
                    x.v_idSedeTraslado == IdSede &&
                    x.v_fechaTraslado.Year == fecha.Year &&
                    x.v_fechaTraslado.Month == fecha.Month &&
                    x.v_fechaTraslado.Day == fecha.Day).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_Traslados> filtroFechaMes(int IdSede, DateTime fecha)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.V_Traslados.AsNoTracking().Where(x =>
                    x.v_idSedeTraslado == IdSede &&
                    x.v_fechaTraslado.Year == fecha.Year &&
                    x.v_fechaTraslado.Month == fecha.Month).ToList();
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

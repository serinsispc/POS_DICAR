using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class ControladorConsecutivoVenta
    {
        public static ConsecutivoVentaUsado consultar_Consecutivo(int consecutivo)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.ConsecutivoVentaUsado.AsNoTracking().Where(x => x.numeroConsecutivoVenta == consecutivo).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static ConsecutivoVentaUsado consultar_Consecutivo_IDUsuario_NumeroCaja(int consecutivo,int usuario,int numeroCaja)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.ConsecutivoVentaUsado.AsNoTracking().Where(x => x.numeroConsecutivoVenta == consecutivo &&
                                                                            x.idUsuarioVenta == usuario &&
                                                                            x.numeroCajaActivaVenta == numeroCaja).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static ConsecutivoVentaUsado consultar_IDUsuario_NumeroCaja(int usuario, int numeroCaja,int estado)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.ConsecutivoVentaUsado.AsNoTracking().Where(x =>x.estadoConsecutivoVenta==estado &&
                                                                            x.idUsuarioVenta == usuario &&
                                                                            x.numeroCajaActivaVenta == numeroCaja).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static bool CrearEditarEliminarConsecutivo(ConsecutivoVentaUsado objconse,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.ConsecutivoVentaUsado.Add(objconse);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objconse).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objconse).State = System.Data.Entity.EntityState.Deleted;
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
    }
}

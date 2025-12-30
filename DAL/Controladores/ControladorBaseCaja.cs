using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class ControladorBaseCaja
    {
        public static bool CrearEditarEliminarBaseCaja(BaseCaja objBase,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.BaseCaja.Add(objBase);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objBase).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objBase).State = System.Data.Entity.EntityState.Deleted;
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
        public static BaseCaja consultaBaseActiva(string Estado,int IdUsuario,int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.BaseCaja.AsNoTracking().Where(x =>x.estadoBase == Estado &&
                    x.idUsuarioApertura==IdUsuario && x.idSedeBAse==IdSede).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static decimal BaseActiva()
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    decimal? Base = cn.BaseCaja.AsNoTracking().Where(x=>x.estadoBase=="ACTIVA").Sum(x => x.valorBase);
                    if (Base == null)
                    {
                        Base = 0;
                    }
                    return Convert.ToInt32(Base);
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static BaseCaja consultarID(int IDBase)
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.BaseCaja.AsNoTracking().Where(x => x.id == IDBase).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static BaseCaja HallarIdBaseActiva(int IdSede,int Idusuario)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.BaseCaja.AsNoTracking().Where(x => x.estadoBase == "ACTIVA" &&
                    x.idUsuarioApertura==Idusuario &&
                    x.idSedeBAse==IdSede).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

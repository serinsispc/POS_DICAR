using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorSede
    {
        /// <summary>
        /// Controlador que trae la lista de nombre de empresas.
        /// </summary>
        /// <returns></returns>
        public static List<Sede> listaCompleta()
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.Sede.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }

        }
        /// <summary>
        /// controlador que se encarga de traer la informacion del parqueadero segun el id de empresa.
        /// </summary>
        /// <param name="p_idEmpresa"></param>
        /// <returns></returns>
        public static Sede ConsultaXIdEmpresa(int p_idEmpresa)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.Sede.AsNoTracking().Where(x => x.id == p_idEmpresa).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;   
            }

        }
        /// <summary>
        /// controlador que se encarga de crear, editar y elimonar laconfiguracion del parqueadero
        /// </summary>
        /// <param name="objConfig"></param>
        /// <param name="Evento"></param>
        /// <returns></returns>
        public static bool CrearEditarEliminarConfiguracion(Sede objConfig,int Evento)
        {
            try
            {
                using(SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    if(Evento == 0)
                    {
                        cn.Sede.Add(objConfig);
                    }
                    if(Evento == 1)
                    {
                        cn.Entry(objConfig).State = System.Data.Entity.EntityState.Modified;
                    }
                    if(Evento == 2)
                    {
                        cn.Entry(objConfig).State = System.Data.Entity.EntityState.Deleted;
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
        public static Sede datosCompletos()
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.Sede.AsNoTracking().Where(x=>x.id==1).FirstOrDefault();
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

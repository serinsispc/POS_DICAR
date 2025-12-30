using DAL.Modelo;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorPresentacion
    {
        public static bool CrearEditarEliminarPresentacion(Presentacion objPresentacion,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn=new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.Presentacion.Add(objPresentacion);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objPresentacion).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objPresentacion).State = System.Data.Entity.EntityState.Deleted;
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
        public static async Task<List<SQL.Views.V_Presentacion>> ListaCompleta()
        {
            try
            {
                var api = new ClassAPI();
                var url = $"/api/V_Presentacion/Lista";
                var respuesta = await api.HttpWebRequestPostAsync(url);
                if (!string.IsNullOrEmpty(respuesta))
                {
                    var lista=JsonConvert.DeserializeObject<List<SQL.Views.V_Presentacion>>(respuesta);
                    return lista;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static Presentacion ConsultarID(int IdPresentacion)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.Presentacion.AsNoTracking().Where(x => x.id == IdPresentacion).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static Presentacion ConsultarNombre(string nombre)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.Presentacion.AsNoTracking().Where(x => x.nombrePresentacion == nombre).FirstOrDefault();
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

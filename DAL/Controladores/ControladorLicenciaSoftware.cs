using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;
using System.Windows.Forms;
using RunApi;

namespace DAL.Controladores
{
    public class ControladorLicenciaSoftware
    {
        public static bool Crear_Editar_Eliminar_LicenciaSoftware(Licencia objLicencia, int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    if (Boton == 0)
                    {
                        cn.Licencia.Add(objLicencia);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objLicencia).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objLicencia).State = System.Data.Entity.EntityState.Deleted;
                    }
                    cn.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static async Task<Licencia> ConsultarLicencia(string Licencia)
        {
            try
            {
                var api = new ClassAPI();
                var url = $"/api/Licencia/ValidarLicencia/{Licencia}";
                var respuesta = await api.HttpWebRequestPostAsync(url);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Licencia>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return new Licencia();
            }
        }
        public static List<Licencia> ListaCompleta()
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.Licencia.AsNoTracking().ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;
using System.Windows.Forms;
using RunApi;
using Newtonsoft.Json;

namespace DAL.Controladores.Version_Software
{
    public class ControladorRutas
    {
        public static bool Crrear_Editar_Elimiar_RutaEquipo(RutaActualizacionEquipo objRuta,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.RutaActualizacionEquipo.Add(objRuta);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objRuta).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objRuta).State = System.Data.Entity.EntityState.Deleted;
                    }
                    cn.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static async Task<RutaActualizacionEquipo> ConsultarX_NombreEquipo(string NombreEquipo)
        {
            try
            {
                var api = new ClassAPI();
                var url = $"/api/RutaActualizacionEquipo/Consultar/{NombreEquipo}";
                var respuesta = await api.HttpWebRequestPostAsync(url);
                return JsonConvert.DeserializeObject<RutaActualizacionEquipo>(respuesta);

            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static List<RutaActualizacionEquipo> listaCompleta()
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.RutaActualizacionEquipo.AsNoTracking().ToList();
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

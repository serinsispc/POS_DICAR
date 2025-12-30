using DAL.Modelo;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores.Version_Software
{
    public class ControladorReporteActualizacion
    {
        public static bool Crear_Editar_Eliminar_ReporteActualizacion(ReporteActualizacionEquipo objReporteActualizacion,int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.ReporteActualizacionEquipo.Add(objReporteActualizacion);
                    }
                    if (Boton == 1)
                    {
                        cn.Entry(objReporteActualizacion).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objReporteActualizacion).State = System.Data.Entity.EntityState.Deleted;
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
        public static async Task<ReporteActualizacionEquipo> ConsultarX_NombreEquipo_NOmbreActualizacion(
            string NombreEquipo,
            string NombreVersion)
        {
            try
            {
                var api = new ClassAPI();

                // Coincide con la ruta del controlador API
                var url = $"/api/ReporteActualizacionEquipo/Consultar/{NombreEquipo}/{NombreVersion}";

                // Si no pasas NombreDB, usa la default que tienes en ClassAPI
                var respuesta = await api.HttpWebRequestPostAsync(url);

                if (string.IsNullOrWhiteSpace(respuesta))
                    return null;

                var reporte = JsonConvert.DeserializeObject<ReporteActualizacionEquipo>(respuesta);
                return reporte;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static List<ReporteActualizacionEquipo> listaCompleta()
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.ReporteActualizacionEquipo.AsNoTracking().ToList();
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

using DAL.Modelo;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores.Version_Software
{
    public class ControladorVersionSoftware
    {
        public static async Task<VersionSoftware> ConsultarVersionSoftware(int VersionActual)
        {
            try
            {
                var api = new ClassAPI();

                // Endpoint definido en el controlador API:
                var url = $"/api/VersionSoftware/Consultar/{VersionActual}";

                // Si no pasas NombreDB, usa la default de ClassAPI (DBDicarDistribuciones)
                var respuesta = await api.HttpWebRequestPostAsync(url);

                if (string.IsNullOrWhiteSpace(respuesta))
                    return null;

                var version = JsonConvert.DeserializeObject<VersionSoftware>(respuesta);
                return version;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static async Task<int> UltimaVersion()
        {
            try
            {
                var api = new ClassAPI();

                // Endpoint que definimos en el controlador:
                var url = "/api/VersionSoftware/UltimaVersion";

                // No necesitamos cuerpo JSON, ni cambiar la DB (usa la default de ClassAPI si no pasas NombreDB)
                var respuesta = await api.HttpWebRequestPostAsync(url);

                if (string.IsNullOrWhiteSpace(respuesta))
                    return 0;

                // La API devuelve solo un número: ej. 5
                int ultima = JsonConvert.DeserializeObject<int>(respuesta);
                return ultima;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static bool Crear_Editar_Eliminar_Version(VersionSoftware objVersion,int Boton)
        {
            try
            {
                using (SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.VersionSoftware.Add(objVersion);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objVersion).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objVersion).State = System.Data.Entity.EntityState.Deleted;
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
        public static List<VersionSoftware> listaCompleta()
        {
            try
            {
                using(SistemaPOSEntities cn=new Modelo.SistemaPOSEntities())
                {
                    return cn.VersionSoftware.AsNoTracking().ToList();
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

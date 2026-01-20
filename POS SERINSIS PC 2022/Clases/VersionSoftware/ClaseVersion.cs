using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Controladores.Version_Software;
using SERINSI_PC.Clases;
using DAL.Modelo;
using DAL;

namespace Invenpol_Parqueadero_Motos.Clases.VersionSoftware
{
    class ClaseVersion
    {
        public static string NumeroVersion;
        public static string VersionActualCodigo;
        public static string IPEquipoNuevo = "";
        public static string UsuarioEquipoNuevo = "";
        public static void Consultar_IPEquipo_Usuario()
        {
            string localIP = "";
            string Usuario = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());// objeto para guardar la ip
            foreach (IPAddress ip in host.AddressList)
            {
                if (localIP == "")
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();// esta es nuestra ip
                        Usuario = SystemInformation.UserName;
                        IPEquipoNuevo = localIP;
                        UsuarioEquipoNuevo = Usuario;
                    }
                }
                else
                {
                    return;
                }
            }
        }
        /// <summary>
        /// Con esta funcion sabremos si la carpeta de la nueva vercion ya esta disponible en el equipo cliente
        /// </summary>
        public static async Task ConsultarVercion(string NombreEquipo,string NombreVercion)
        {

            string ruta =VariablesPublicas.RutaCarpetaActualizacion+NombreVercion;
            if (Directory.Exists(ruta))
            {
                ReporteActualizacionEquipo objReporte = new ReporteActualizacionEquipo();
                objReporte.id_reposte_actualizacion_equipo = 0;
                objReporte.fecha_actualizacion_equipo = DateTime.Today;
                objReporte.hora_actualizacion_equipo = DateTime.Now.TimeOfDay;
                objReporte.nombre_equipo_actualizado = NombreEquipo;
                objReporte.nombre_version_actualizado = NombreVercion;
                string sql =await ControladorReporteActualizacion.Crud(objReporte,0);
                //en esta parte la consulta nos confirma que la vercion a buscar si esta disponible
                //corremos el actualizador y serramos la aplicacion
                Process.Start(VariablesPublicas.RutaApllicacionActualizacion);
                Application.Exit();
            }
            else
            {
                try
                {
                    ReporteActualizacionEquipo objReporte = new ReporteActualizacionEquipo();
                    objReporte.id_reposte_actualizacion_equipo = 0;
                    objReporte.fecha_actualizacion_equipo = DateTime.Today;
                    objReporte.hora_actualizacion_equipo = DateTime.Now.TimeOfDay;
                    objReporte.nombre_equipo_actualizado = NombreEquipo;
                    objReporte.nombre_version_actualizado = NombreVercion;
                    string sql =await ControladorReporteActualizacion.Crud(objReporte, 0);
                    //en esta parte la consulta nos confirma que la vercion a buscar si esta disponible
                    //corremos el actualizador y serramos la aplicacion
                    Process.Start(VariablesPublicas.RutaApllicacionActualizacion);
                    Application.Exit();
                }
                catch(Exception ex)
                {
                    string error = ex.Message;
                }
                MessageBox.Show("¡Valla!"+Environment.NewLine+Environment.NewLine+
                                "Ha ocurrido un error en el proceso de la actualización." + Environment.NewLine + Environment.NewLine +
                                "Las causas del error es que no se han cargado todos los archivos necesarios para el proceso de actualización.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}

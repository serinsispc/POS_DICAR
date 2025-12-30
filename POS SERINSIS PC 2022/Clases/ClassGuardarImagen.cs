using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using System.Net;
using DAL.Controladores.Version_Software;

namespace SERINSI_PC.Clases
{
    public class ClassGuardarImagen
    {
        public static int guardarImagenDriver(byte[] Arreglo, string Ruta, string Carpeta, string Nombre)
        {
            if (File.Exists(Ruta + Carpeta + Nombre))
            {
                try
                {
                    File.Delete(Ruta + Carpeta + Nombre);
                    File.WriteAllBytes(Ruta + Carpeta + Nombre, Arreglo);
                    return 1;
                }
                catch (Exception ex)
                {
                    string erros = ex.Message;
                    return 0;
                }
            }
            else
            {
                try
                {
                    File.WriteAllBytes(Ruta + Carpeta + Nombre, Arreglo);
                    return 1;
                }
                catch (Exception ex)
                {
                    string erros = ex.Message;
                    return 0;
                }

            }
        }
        public static async Task GuardarImagenServidor(string subCarpeta,string misDocumentos,string nombreImagen)
        {
            RutaActualizacionEquipo objRuta = new RutaActualizacionEquipo();
            objRuta =await ControladorRutas.ConsultarX_NombreEquipo(VariablesPublicas.NombreEquipoLocal);

            string _FtpFilePath = objRuta.rutaImagen +subCarpeta+ "//";
            string _LocalFilePath = misDocumentos + "\\" + nombreImagen;

            WebClient FTP_Upload = new WebClient();
            FTP_Upload.Credentials = new NetworkCredential("emilianop", "Serinsis.2020*");
            FTP_Upload.UploadFile(_FtpFilePath + "/" + Path.GetFileName(_LocalFilePath), _LocalFilePath);
            FTP_Upload.Dispose();
        }
    }
}

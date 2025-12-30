using DAL.Controladores;
using DAL.Modelo;
using System;
using System.IO;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace Services
{
    public class GestionarArchivos
    {
        public static string ConvertirImagen_Texto(string Ruta)
        {
            try
            {
                byte[] Arreglo = File.ReadAllBytes(Ruta);
                string texto = Convert.ToBase64String(Arreglo);
                return texto;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static int SubirArchivo(string Ruta, string nombreArchivo, string extencionArchivo)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://158.69.249.188/TiendaAdmin/DynamicFolder/Productos/" + nombreArchivo + extencionArchivo);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("emilianop", "Serinsis.2020*");
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;
                FileStream stream = File.OpenRead(Ruta);
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Flush();
                reqStream.Close();
                return 1;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
    }
}

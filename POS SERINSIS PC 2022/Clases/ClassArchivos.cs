using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SERINSI_PC.Clases
{
    public class ClassArchivos
    {
        public static int SubirArchivo(string RutaServidor, string Usuario, string Clave, string RutaLocal, string nombreArchivo, string extencionArchivo, string carpeta)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(RutaServidor + carpeta + "/" + nombreArchivo + extencionArchivo);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(Usuario, Clave);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;
                FileStream stream = File.OpenRead(RutaLocal);
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RunApi
{
    public class ClassAPI : ClassURLAPI
    {
        public string servidorapi = string.Empty;
        public static string ErrorProsesoDian { get; private set; }
        private readonly HttpClient _httpClient;
        //conexión al servidor 
        public string UrlEndPintDIAN { get; set; } = "https://erog.apifacturacionelectronica.xyz";
        public string token_ { get; set; } = "4007005B-3F7A-4D5B-A6E3-0711DF09FA55";

        public ClassAPI()
        {
            _httpClient = new HttpClient();
        }



        public Task<string> HttpWebRequestPostAsync(string Url, [Optional] string NombreDB, [Optional] string Json, [Optional] bool dian, [Optional] string token)
        {
            string UrlEndPoint_ = URLApi;



            if (dian)
                UrlEndPoint_ = UrlEndPintDIAN;
            else
                token = token_;

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.Expect100Continue = false; // evita "Expect: 100-continue"

            return Task.Run(() =>
            {
                string Response = null;

                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(UrlEndPoint_ + Url);
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    request.KeepAlive = true;
                    request.SendChunked = false; // forzamos Content-Length
                    request.Timeout = 1000 * 60; // 60s, ajusta si necesitas

                    if (!string.IsNullOrEmpty(token))
                        request.Headers.Add("Authorization", "Bearer " + token);

                    if (!string.IsNullOrEmpty(NombreDB))
                        request.Headers.Add("X-NombreDB", NombreDB);

                    // Prepara cuerpo
                    var payload = Json ?? string.Empty; // si es null, cuerpo vacío
                    byte[] data = Encoding.UTF8.GetBytes(payload);
                    request.ContentLength = data.Length;

                    // Escribe cuerpo (aunque sea 0 bytes)
                    using (var reqStream = request.GetRequestStream())
                    {
                        if (data.Length > 0)
                            reqStream.Write(data, 0, data.Length);
                    }

                    using (var httpResponse = (HttpWebResponse)request.GetResponse())
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        if (httpResponse.StatusCode == HttpStatusCode.OK || httpResponse.StatusCode == HttpStatusCode.Created)
                            Response = streamReader.ReadToEnd();
                        else
                            Response = $"HTTP {(int)httpResponse.StatusCode} - {httpResponse.StatusDescription}";
                    }
                }
                catch (WebException ex)
                {
                    // Puede venir null si falló antes de obtener respuesta
                    if (ex.Response != null)
                    {
                        using (var resp = (HttpWebResponse)ex.Response)
                        using (var sr = new StreamReader(resp.GetResponseStream()))
                        {
                            Response = sr.ReadToEnd();
                        }
                    }
                    else
                    {
                        Response = ex.Message;
                    }
                    ErrorProsesoDian = Response;
                }
                catch (Exception ex)
                {
                    Response = ex.Message; // deja el mensaje real para depurar
                }

                return Response;
            });
        }



        public Task<string> HttpWebRequestPostAsync_noti(string Url, [Optional] string NombreDB, [Optional] string Json, [Optional] bool dian, [Optional] string token)
        {
            string UrlEndPoint_ = "https://www.serinsispc.com/ApiPOS";


            if (dian)
                UrlEndPoint_ = UrlEndPintDIAN;
            else
                token = token_;

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.Expect100Continue = false; // evita "Expect: 100-continue"

            return Task.Run(() =>
            {
                string Response = null;

                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(UrlEndPoint_ + Url);
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    request.KeepAlive = true;
                    request.SendChunked = false; // forzamos Content-Length
                    request.Timeout = 1000 * 60; // 60s, ajusta si necesitas

                    if (!string.IsNullOrEmpty(token))
                        request.Headers.Add("Authorization", "Bearer " + token);

                    if (!string.IsNullOrEmpty(NombreDB))
                        request.Headers.Add("X-NombreDB", NombreDB);

                    // Prepara cuerpo
                    var payload = Json ?? string.Empty; // si es null, cuerpo vacío
                    byte[] data = Encoding.UTF8.GetBytes(payload);
                    request.ContentLength = data.Length;

                    // Escribe cuerpo (aunque sea 0 bytes)
                    using (var reqStream = request.GetRequestStream())
                    {
                        if (data.Length > 0)
                            reqStream.Write(data, 0, data.Length);
                    }

                    using (var httpResponse = (HttpWebResponse)request.GetResponse())
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        if (httpResponse.StatusCode == HttpStatusCode.OK || httpResponse.StatusCode == HttpStatusCode.Created)
                            Response = streamReader.ReadToEnd();
                        else
                            Response = $"HTTP {(int)httpResponse.StatusCode} - {httpResponse.StatusDescription}";
                    }
                }
                catch (WebException ex)
                {
                    // Puede venir null si falló antes de obtener respuesta
                    if (ex.Response != null)
                    {
                        using (var resp = (HttpWebResponse)ex.Response)
                        using (var sr = new StreamReader(resp.GetResponseStream()))
                        {
                            Response = sr.ReadToEnd();
                        }
                    }
                    else
                    {
                        Response = ex.Message;
                    }
                    ErrorProsesoDian = Response;
                }
                catch (Exception ex)
                {
                    Response = ex.Message; // deja el mensaje real para depurar
                }

                return Response;
            });
        }




    }
}

using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SQL
{
    public class Conection_SQL
    {
        public static async Task<string> ConsultaSQLServer(string query, [Optional] bool lista, [Optional] bool directo)
        {
            var respuesta = new RespuestaSQL();
            try
            {
                var ConsultaSQL = new { query = query };
                string json = JsonConvert.SerializeObject(ConsultaSQL);
                var api = new ClassAPI();
                var url = $"/api/SQL/execute-sql";
                var resp = await api.HttpWebRequestPostAsync(url, "DBDicarDistribuciones", json);

                string data = JsonHelper.AjustarJson(resp);

                if (!lista)
                {
                    data = data.Replace("[", "").Replace("]", "");
                }

                data = JsonHelper.AjustarJson(data);

                if (data == "[]") data = null;

                if (!directo)
                {
                    respuesta.estado = true;
                    respuesta.mensaje = "Consulta realizada correctamente.";
                    respuesta.data = data;

                    return JsonConvert.SerializeObject(respuesta);
                }
                else
                {
                    return data;
                }



            }
            catch (Exception ex)
            {
                respuesta.estado = false;
                respuesta.mensaje = ex.Message;
                respuesta.data = null;
                return JsonConvert.SerializeObject(respuesta);
            }


        }

        public static async Task<string> ConsultaSQLServerURLServer(string query, [Optional] bool lista, [Optional] bool directo)
        {
            var respuesta = new RespuestaSQL();
            try
            {
                var ConsultaSQL = new { query = query };
                string json = JsonConvert.SerializeObject(ConsultaSQL);
                var api = new ClassAPI();
                var url = $"/api/SQL/execute-sql";
                var resp = await api.HttpWebRequestPostAsync_noti(url, "DBNotificacionesMovil", json);

                string data = JsonHelper.AjustarJson(resp);

                if (!lista)
                {
                    data = data.Replace("[", "").Replace("]", "");
                }

                if (data == "[]") data = null;

                if (!directo)
                {
                    respuesta.estado = true;
                    respuesta.mensaje = "Consulta realizada correctamente.";
                    respuesta.data = data;

                    return JsonConvert.SerializeObject(respuesta);
                }
                else
                {
                    return data;
                }



            }
            catch (Exception ex)
            {
                respuesta.estado = false;
                respuesta.mensaje = ex.Message;
                respuesta.data = null;
                return JsonConvert.SerializeObject(respuesta);
            }


        }
    }
}

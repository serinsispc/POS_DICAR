using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorResponsableOrdenFabricacion
    {
        // CRUD: 0=INSERT, 1=UPDATE, 2=DELETE  (NO LISTA => false,true)
        public static async Task<RespuestaCRUD> Crud(ResponsableOrdenFabrica objROF, int funcion)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objROF);
                //json = AjustarJoson.Ajustar(json);

                var query = $"EXEC dbo.CRUD_ResponsableOrdenFabrica N'{json}',{funcion}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return new RespuestaCRUD()
                {
                    estado = false,
                    mensaje = error
                };
            }
        }

        // LISTA (true,true)
        public static async Task<List<ResponsableOrdenFabrica>> filtroNombre(string nombre)
        {
            try
            {
                nombre = (nombre ?? "").Replace("'", "''");
                var query = $"SELECT * FROM ResponsableOrdenFabrica WHERE nombreResponsableOrdenFabrica LIKE N'%{nombre}%'";
                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                return JsonConvert.DeserializeObject<List<ResponsableOrdenFabrica>>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // UNICO (false,true)
        public static async Task<ResponsableOrdenFabrica> consultarNombre(string nombre)
        {
            try
            {
                nombre = (nombre ?? "").Replace("'", "''");
                var query = $"SELECT TOP 1 * FROM ResponsableOrdenFabrica WHERE nombreResponsableOrdenFabrica = N'{nombre}'";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                return JsonConvert.DeserializeObject<ResponsableOrdenFabrica>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

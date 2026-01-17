using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorSedesAsignadas
    {

public static async Task<bool> CrearEditarEliminarAsignacionSede(SedesAsignadas objAsignacion, int Boton)
    {
        try
        {
            var json = JsonConvert.SerializeObject(objAsignacion);

            // Si ya tienes tu método AjustarJson, úsalo como vienes trabajando:
            // json = AjustarJoson.Ajustar(json);

            // Importante: escapar comillas simples para SQL
            json = json.Replace("'", "''");

            var query = $"EXEC dbo.CRUD_SedesAsignadas N'{json}', {Boton}";
            var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

            // Espera un JSON como: { estado: 1/0, idAfectado: x, mensaje: "..." }
            if (!string.IsNullOrEmpty(resp))
            {
                var r = JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
                return r != null && r.estado;
            }

            return false;
        }
        catch (Exception ex)
        {
            string error = ex.Message;
            return false;
        }
    }

    public static async Task<int> SumarSedesAsignadas(int IdUsuario)
        {
            try
            {
                var query = $@"
            select ISNULL(SUM(contadorAsignacion), 0) as total
            from SedesAsignadas
            where idusuarioAsignado = {IdUsuario}
        ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    var obj = JsonConvert.DeserializeObject<dynamic>(resp);
                    int total = (int)obj.total;
                    return total;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }

        public static async Task<List<V_SedesAsignadas>> filtroXIdUsuario(int IdUsuario)
        {
            try
            {
                var query = $@"
            select *
            from V_SedesAsignadas
            where v_idusuarioAsignado = {IdUsuario}
        ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<List<V_SedesAsignadas>>(resp);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<SedesAsignadas> consultarIDUsuario(int IdUsuario)
        {
            try
            {
                var query = $@"
            select top 1 *
            from SedesAsignadas
            where idusuarioAsignado = {IdUsuario}
        ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<SedesAsignadas>(resp);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

    }
}

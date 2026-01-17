using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class ControladorConsecutivoVenta
    {
        public static async Task<ConsecutivoVentaUsado> consultar_Consecutivo(int consecutivo)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from ConsecutivoVentaUsado
                    where numeroConsecutivoVenta = {consecutivo}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<ConsecutivoVentaUsado>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<ConsecutivoVentaUsado> consultar_Consecutivo_IDUsuario_NumeroCaja(int consecutivo, int usuario, int numeroCaja)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from ConsecutivoVentaUsado
                    where numeroConsecutivoVenta = {consecutivo}
                      and idUsuarioVenta = {usuario}
                      and numeroCajaActivaVenta = {numeroCaja}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<ConsecutivoVentaUsado>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<ConsecutivoVentaUsado> consultar_IDUsuario_NumeroCaja(int usuario, int numeroCaja, int estado)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from ConsecutivoVentaUsado
                    where estadoConsecutivoVenta = {estado}
                      and idUsuarioVenta = {usuario}
                      and numeroCajaActivaVenta = {numeroCaja}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<ConsecutivoVentaUsado>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<bool> CrearEditarEliminarConsecutivo(ConsecutivoVentaUsado objconse, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objconse);

                // Si usas tu ajustador, déjalo como siempre:
                // json = AjustarJoson.Ajustar(json);

                json = json.Replace("'", "''");

                var query = $"EXEC dbo.CRUD_ConsecutivoVentaUsado N'{json}', {Boton}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    var r = JsonConvert.DeserializeObject<RespuestaCRUD>(resp);

                    // Si estado es int: return r != null && r.estado == 1;
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
    }
}

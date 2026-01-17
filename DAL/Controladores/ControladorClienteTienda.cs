using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class ControladorClienteTienda
    {
        public static async Task<bool> Crear_Editar_Elimnar_ClienteTienda(Clientes objCT, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objCT);

                // Si usas tu ajustador, déjalo como siempre:
                // json = AjustarJoson.Ajustar(json);

                json = json.Replace("'", "''");

                var query = $"EXEC dbo.CRUD_Clientes N'{json}', {Boton}";
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

        public static async Task<List<V_Cliente>> ListaCompleta()
        {
            try
            {
                var query = @"
                    select *
                    from V_Cliente
                    order by ciudadCliente
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<V_Cliente>>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<V_CuentasPC>> FiltarX_Pendiente(int IdSede)
        {
            try
            {
                var query = $@"
                    select *
                    from V_CuentasPC
                    where idSede = {IdSede}
                      and saldoCC > 0
                    order by nombreClienteCC
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<V_CuentasPC>>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<V_Cliente>> FiltarX_Nombre(string Nombre)
        {
            try
            {
                var nom = (Nombre ?? "").Replace("'", "''");

                var query = $@"
                    select *
                    from V_Cliente
                    where nombreCliente like '%{nom}%'
                    order by nombreCliente
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<V_Cliente>>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<Clientes> ConsultarX_Nombre(string Nombre)
        {
            try
            {
                var nom = (Nombre ?? "").Replace("'", "''");

                var query = $@"
                    select top 1 *
                    from Clientes
                    where nombreCliente = '{nom}'
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<Clientes>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<Clientes> ConsultarX_ID(int ID)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from Clientes
                    where id = {ID}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<Clientes>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<Clientes> ConsultarX_NIT(string NIT)
        {
            try
            {
                var nit = (NIT ?? "").Replace("'", "''");

                var query = $@"
                    select top 1 *
                    from Clientes
                    where documentoCliente = '{nit}'
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<Clientes>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<int> SumarTotalCreditosPendientes()
        {
            try
            {
                var query = @"
                    select ISNULL(SUM(saldoCC), 0) as total
                    from V_CuentasPC
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    var data = JsonConvert.DeserializeObject<List<dynamic>>(resp);
                    return Convert.ToInt32(data[0].total);
                }

                return 0;
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                return 0;
            }
        }

        public static async Task<List<V_Cliente>> BuscadorCliente(string buscar)
        {
            try
            {
                var b = (buscar ?? "").Replace("'", "''");

                var query = $@"
                    select *
                    from V_Cliente
                    where nombreCliente like '%{b}%'
                       or razonSocialCliente like '%{b}%'
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<V_Cliente>>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

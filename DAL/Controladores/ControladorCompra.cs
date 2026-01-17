using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class ControladorCompra
    {
        public static async Task<bool> GuardarEditarEliminarCompra(Compras objCompra, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objCompra);

                // Si usas tu ajustador, déjalo como siempre:
                // json = AjustarJoson.Ajustar(json);

                json = json.Replace("'", "''");

                var query = $"EXEC dbo.CRUD_Compras N'{json}', {Boton}";
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

        public static async Task<Compras> ConsultaListaX_IdCompra_Entity(int IdCompra)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from Compras
                    where id = {IdCompra}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<Compras>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // Reemplazo del DataTable (misma intención: traer la compra por id)
        public static async Task<Compras> ConsultaListaX_IdCompra(int IdCompra)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from Compras
                    where id = {IdCompra}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<Compras>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<int> TotalComprasAño(DateTime Fecha)
        {
            try
            {
                var query = $@"
                    select ISNULL(SUM(valorPagadoCompra), 0) as total
                    from PagosCompras
                    where YEAR(fechaPagoCompra) = {Fecha.Year}
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
                string error = ex.Message;
                return 0;
            }
        }

        public static async Task<int> TotalComprasMes(DateTime Fecha)
        {
            try
            {
                var query = $@"
                    select ISNULL(SUM(valorPagadoCompra), 0) as total
                    from PagosCompras
                    where YEAR(fechaPagoCompra) = {Fecha.Year}
                      and MONTH(fechaPagoCompra) = {Fecha.Month}
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
                string error = ex.Message;
                return 0;
            }
        }

        public static async Task<int> TotalComprasDia(DateTime Fecha)
        {
            try
            {
                var query = $@"
                    select ISNULL(SUM(valorPagadoCompra), 0) as total
                    from PagosCompras
                    where CONVERT(date, fechaPagoCompra) = '{Fecha:yyyy-MM-dd}'
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
                string error = ex.Message;
                return 0;
            }
        }

        public static async Task<List<V_Compras>> ListaCompleta_Sede(int IdSede, int Estado)
        {
            try
            {
                var query = $@"
                    select *
                    from V_Compras
                    where idSedeCompra = {IdSede}
                      and idEstadoAI = {Estado}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<V_Compras>>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<V_PagoCP>> FiltroX_Año(DateTime FechaFiltro, int IdSede)
        {
            try
            {
                var query = $@"
                    select *
                    from V_PagoCP
                    where IdSedePagoCompra = {IdSede}
                      and YEAR(FechaVPagoCompra) = {FechaFiltro.Year}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<V_PagoCP>>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<V_PagoCP>> FiltroX_Mes(DateTime FechaFiltro, int IdSEde)
        {
            try
            {
                var query = $@"
                    select *
                    from V_PagoCP
                    where IdSedePagoCompra = {IdSEde}
                      and YEAR(FechaVPagoCompra) = {FechaFiltro.Year}
                      and MONTH(FechaVPagoCompra) = {FechaFiltro.Month}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<V_PagoCP>>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<V_PagoCP>> FiltroX_Dia(DateTime FechaFiltro, int IdSede)
        {
            try
            {
                var query = $@"
                    select *
                    from V_PagoCP
                    where IdSedePagoCompra = {IdSede}
                      and CONVERT(date, FechaVPagoCompra) = '{FechaFiltro:yyyy-MM-dd}'
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<V_PagoCP>>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<Compras>> FiltrarSaldo()
        {
            try
            {
                var query = @"
                    select *
                    from Compras
                    where saldoCompra > 0
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<Compras>>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<V_Compras>> filtrarXProveedorSaldo(string Proveedor)
        {
            try
            {
                var p = (Proveedor ?? "").Replace("'", "''");

                // Nota: en tu EF tenías Contains(Proveedor) en ambos; acá lo replico con LIKE
                var query = $@"
                    select *
                    from V_Compras
                    where saldoCompraV > 0
                      and (nombreProveedorV like '%{p}%' or documentoProveedorV like '%{p}%')
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<V_Compras>>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<V_Compras>> listaComprasPendientes(int IdSede, int Estado)
        {
            try
            {
                var query = $@"
                    select *
                    from V_Compras
                    where saldoCompraV > 0
                      and idSedeCompra = {IdSede}
                      and idEstadoAI = {Estado}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<V_Compras>>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<Compras> ConsultarXGuid(Guid gui)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from Compras
                    where guidCompra = '{gui}'
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<Compras>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<Compras> Consultar_Id(int IdCompra)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from Compras
                    where id = {IdCompra}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<Compras>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<Compras> ConsultarEstadoAI(int estado, int IdSede)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from Compras
                    where idSede = {IdSede}
                      and idEstadoAI = {estado}
                    order by id desc
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<Compras>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                return null;
            }
        }
    }
}

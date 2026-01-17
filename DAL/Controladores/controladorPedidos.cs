using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorPedidos
    {
        private const string SP_CRUD = "dbo.CRUD_Pedidos";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // =====================================================
        // CRUD -> false, true
        // Boton: 0=INSERT | 1=UPDATE | 2=DELETE
        // =====================================================
        public static async Task<RespuestaCRUD> Crud(Pedidos pedidos, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(pedidos));
                var query = $"EXEC {SP_CRUD} N'{json}', {Boton}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(respuesta);
            }
            catch (Exception ex)
            {
                return new RespuestaCRUD
                {
                    estado = false,
                    idAfectado = 0,
                    mensaje = ex.Message
                };
            }
        }

        // =====================================================
        // FILTRAR por estado + vendedor + fecha (LISTA)
        // =====================================================
        public static async Task<List<V_Pedido>> Filtrar_estado(int estado, int idVendedor_frm, DateTime fecha)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_Pedido WITH (NOLOCK)
WHERE idEstadoPedido = {estado}
  AND idVendedor = {idVendedor_frm}
  AND CONVERT(date, fechaPedido) = CONVERT(date, '{fecha:yyyy-MM-dd}')
ORDER BY fechaPedido DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<V_Pedido>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // FILTRAR por guía (LISTA)
        // =====================================================
        public static async Task<List<V_Pedido>> Filtrar_guia(string guia)
        {
            try
            {
                var g = (guia ?? string.Empty).Replace("'", "''");

                var query = $@"
SELECT *
FROM V_Pedido WITH (NOLOCK)
WHERE guiaPedido = N'{g}'
ORDER BY fechaPedido DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<V_Pedido>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // CONSULTAR por GUID (1 registro)
        // =====================================================
        public static async Task<Pedidos> Consultar_guid(Guid guid)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM Pedidos WITH (NOLOCK)
WHERE guidPedido = '{guid}'
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<Pedidos>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // PEDIDOS PENDIENTES (ESCALAR)
        // =====================================================
        public static async Task<int> PedidosPendientes(int IdVendedor, int IdEstado, DateTime fecha)
        {
            try
            {
                var query = $@"
SELECT ISNULL(COUNT(1),0) AS total
FROM Pedidos WITH (NOLOCK)
WHERE idVendedor = {IdVendedor}
  AND idEstadoPedido = {IdEstado}
  AND CONVERT(date, fechaPedido) = CONVERT(date, '{fecha:yyyy-MM-dd}');";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                var row = JsonConvert.DeserializeObject<List<dynamic>>(jsonReal);

                return Convert.ToInt32(row[0].total);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }

        // =====================================================
        // TOTAL PEDIDOS (ESCALAR desde VIEW)
        // =====================================================
        public static async Task<decimal> sumarTotalPedido(int IdVendedor, int IdEstado, DateTime fecha)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(CAST(totalPedido AS DECIMAL(18,2))),0) AS total
FROM V_Pedido WITH (NOLOCK)
WHERE idVendedor = {IdVendedor}
  AND idEstadoPedido = {IdEstado}
  AND CONVERT(date, fechaPedido) = CONVERT(date, '{fecha:yyyy-MM-dd}');";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                var row = JsonConvert.DeserializeObject<List<dynamic>>(jsonReal);

                return Convert.ToDecimal(row[0].total);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }
    }
}

using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorR_PedidoVenta
    {
        /// <summary>
        /// 0=INSERT, 1=UPDATE, 2=DELETE
        /// Ejecuta: EXEC dbo.CRUD_R_PedidoVenta N'{json}', {funcion}
        /// </summary>
        public static async Task<RespuestaCRUD> Crud(R_PedidoVenta r_Pedido, int funcion)
        {
            try
            {
                var json = JsonConvert.SerializeObject(r_Pedido);
                json = EscapeJsonForSql(json);

                var query = $"EXEC dbo.CRUD_R_PedidoVenta N'{json}', {funcion}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return new RespuestaCRUD()
                {
                    estado = false,
                    mensaje = mensaje
                };
            }
        }

        public static async Task<R_PedidoVenta> Consultar_GuidPedido(Guid guid)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM R_PedidoVenta WHERE guidPedido = '{guid}'";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<R_PedidoVenta>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<R_PedidoVenta> Consultar_idVenta(int idVenta)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM R_PedidoVenta WHERE idVenta = {idVenta}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<R_PedidoVenta>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Escapa comillas simples para poder enviar el JSON dentro del EXEC N'...'
        /// </summary>
        private static string EscapeJsonForSql(string json)
        {
            return string.IsNullOrWhiteSpace(json) ? json : json.Replace("'", "''");
        }
    }
}

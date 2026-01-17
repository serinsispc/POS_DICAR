using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorPedidoVenta
    {
        // =====================================================
        // 1 registro por IdVenta (NO lista) -> false, true
        // =====================================================
        public static async Task<R_PedidoVenta> Consultar_IdVenta(int IdVenta)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM R_PedidoVenta WITH (NOLOCK)
WHERE idVenta = {IdVenta}
ORDER BY idVenta DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<R_PedidoVenta>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // 1 registro por guiaPedido (NO lista) -> false, true
        // =====================================================
        public static async Task<V_Pedido> Consultar_giaPedido(string guia)
        {
            try
            {
                var g = (guia ?? string.Empty).Replace("'", "''");

                var query = $@"
SELECT TOP 1 *
FROM V_Pedido WITH (NOLOCK)
WHERE guiaPedido = N'{g}'
ORDER BY fechaPedido DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<V_Pedido>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

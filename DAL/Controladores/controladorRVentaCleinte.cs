using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorRVentaCleinte
    {
        // =========================================================
        // CRUD (funcion: 0=INSERT, 1=UPDATE, 2=DELETE) -> false, true
        // Usa el SP: dbo.CRUD_R_VentaCliente (JSON)
        // =========================================================
        public static async Task<RespuestaCRUD> Crud(R_VentaCliente objRVC, int funcion)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objRVC);
                //json = AjustarJoson.Ajustar(json); // si ya la tienes en tu proyecto

                var query = $"EXEC dbo.CRUD_R_VentaCliente N'{json}', {funcion}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);

                return JsonConvert.DeserializeObject<RespuestaCRUD>(respuesta);
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

        // =========================================================
        // CONSULTAR RELACION POR IDVENTA (1 registro) -> false, true
        // =========================================================
        public static async Task<R_VentaCliente> ConsultarRelacion(int IdVenta)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM R_VentaCliente WHERE idVenta = {IdVenta}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                if(respuesta==null) return null;
                return JsonConvert.DeserializeObject<R_VentaCliente>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =========================================================
        // CONSULTAR POR IDCLIENTE (1 registro) -> false, true
        // =========================================================
        public static async Task<R_VentaCliente> Consultar_idCliente(int IdCliente)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM R_VentaCliente WHERE idCliente = {IdCliente}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);

                return JsonConvert.DeserializeObject<R_VentaCliente>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

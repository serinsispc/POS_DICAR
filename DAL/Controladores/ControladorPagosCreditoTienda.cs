using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorPagosCreditoTienda
    {
        private const string SP_CRUD = "dbo.CRUD_PagosCreditoTienda";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // =====================================================
        // CRUD (NO lista) -> false, true
        // Boton: 0=INSERT | 1=UPDATE | 2=DELETE
        // =====================================================
        public static async Task<RespuestaCRUD> Crear_Editar_Eliminar_PagoCreditoTienda(PagosCreditoTienda objPCT, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(objPCT));
                var query = $"EXEC {SP_CRUD} N'{json}', {Boton}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(respuesta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new RespuestaCRUD
                {
                    estado = false,
                    idAfectado = 0,
                    mensaje = ex.Message
                };
            }
        }

        // =====================================================
        // FILTROS (LISTAS) -> true, true
        // Nota: aquí asumo que R_PagoCredito es una VISTA/REPORTE accesible con SELECT.
        // =====================================================
        public static async Task<List<R_PagoCredito>> FiltroX_Año(DateTime Fecha, int IdSede)
        {
            try
            {
                var query = $@"
SELECT *
FROM R_PagoCredito WITH (NOLOCK)
WHERE idSedePagoCredito = {IdSede}
  AND YEAR(fecha_pago_credito_tienda_r_pago_credito) = {Fecha.Year}
ORDER BY fecha_pago_credito_tienda_r_pago_credito DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<R_PagoCredito>>(jsonReal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<R_PagoCredito>> FiltroX_Mes(DateTime Fecha, int IdSede)
        {
            try
            {
                var query = $@"
SELECT *
FROM R_PagoCredito WITH (NOLOCK)
WHERE idSedePagoCredito = {IdSede}
  AND YEAR(fecha_pago_credito_tienda_r_pago_credito) = {Fecha.Year}
  AND MONTH(fecha_pago_credito_tienda_r_pago_credito) = {Fecha.Month}
ORDER BY fecha_pago_credito_tienda_r_pago_credito DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<R_PagoCredito>>(jsonReal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<R_PagoCredito>> FiltroX_Dia(DateTime Fecha, int IdSede)
        {
            try
            {
                var query = $@"
SELECT *
FROM R_PagoCredito WITH (NOLOCK)
WHERE idSedePagoCredito = {IdSede}
  AND CONVERT(date, fecha_pago_credito_tienda_r_pago_credito) = CONVERT(date, '{Fecha:yyyy-MM-dd}')
ORDER BY fecha_pago_credito_tienda_r_pago_credito DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<R_PagoCredito>>(jsonReal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // SUMAS (ESCALAR) -> false, true
        // =====================================================
        public static async Task<decimal> SumarPagosX_Año(DateTime Fecha, int IdSede)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(CAST(valor_pago_credito_tienda AS DECIMAL(18,2))),0) AS total
FROM PagosCreditoTienda WITH (NOLOCK)
WHERE idSede = {IdSede}
  AND YEAR(fecha_pago_credito_tienda) = {Fecha.Year};";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var row = JsonConvert.DeserializeObject<List<dynamic>>(jsonReal);
                return Convert.ToDecimal(row[0].total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return 0;
            }
        }

        public static async Task<decimal> SumarPagosX_Mes(DateTime Fecha, int IdSede)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(CAST(valor_pago_credito_tienda AS DECIMAL(18,2))),0) AS total
FROM PagosCreditoTienda WITH (NOLOCK)
WHERE idSede = {IdSede}
  AND YEAR(fecha_pago_credito_tienda) = {Fecha.Year}
  AND MONTH(fecha_pago_credito_tienda) = {Fecha.Month};";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var row = JsonConvert.DeserializeObject<List<dynamic>>(jsonReal);
                return Convert.ToDecimal(row[0].total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return 0;
            }
        }

        public static async Task<decimal> SumarPagosX_Dia(DateTime Fecha, int IdSede)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(CAST(valor_pago_credito_tienda AS DECIMAL(18,2))),0) AS total
FROM PagosCreditoTienda WITH (NOLOCK)
WHERE idSede = {IdSede}
  AND CONVERT(date, fecha_pago_credito_tienda) = CONVERT(date, '{Fecha:yyyy-MM-dd}');";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var row = JsonConvert.DeserializeObject<List<dynamic>>(jsonReal);
                return Convert.ToDecimal(row[0].total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return 0;
            }
        }

        // =====================================================
        // LISTA por IdVenta (VIEW) -> true, true
        // =====================================================
        public static async Task<List<V_PagosCreditoTienda>> FIltroXIdVenta(int IdVenta)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_PagosCreditoTienda WITH (NOLOCK)
WHERE idVentaPago = {IdVenta}
ORDER BY id_pago_credito_tienda DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<V_PagosCreditoTienda>>(jsonReal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // Total por Base/Bolsillo (ESCALAR sobre VIEW) -> false, true
        // =====================================================
        public static async Task<int> pagoCCBolsilloFecha(int IdBase, int Bolsillo)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(CAST(valor_pago_credito_tienda AS INT)),0) AS total
FROM V_PagosCreditoTienda WITH (NOLOCK)
WHERE idBaseCaja = {IdBase}
  AND idBolsillo = {Bolsillo};";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var row = JsonConvert.DeserializeObject<List<dynamic>>(jsonReal);
                return Convert.ToInt32(row[0].total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return 0;
            }
        }

        // =====================================================
        // Consultar ID (1 registro) -> false, true
        // =====================================================
        public static async Task<PagosCreditoTienda> ConsultarId(int Id)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM PagosCreditoTienda WITH (NOLOCK)
WHERE id_pago_credito_tienda = {Id}
ORDER BY id_pago_credito_tienda DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<PagosCreditoTienda>>(jsonReal);
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

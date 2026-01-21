using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores.Contabilidad
{
    public class ControladorPagosCompras
    {
        private const string SP_CRUD = "dbo.CRUD_PagosCompras";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // =====================================================
        // CRUD (NO lista) -> false, true
        // Boton: 0=INSERT | 1=UPDATE | 2=DELETE
        // =====================================================
        public static async Task<RespuestaCRUD> Crear_Editar_Eliminar_PagoCompra(PagosCompras objPagos, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(objPagos));
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
        // LISTA por número de compra (VIEW) -> true, true
        // =====================================================
        public static async Task<List<V_PagoCP>> listaNumeroCompra(int idCompra)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_PagoCP WITH (NOLOCK)
WHERE consecutivoVPagoCompra = {idCompra}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // 👈 LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<V_PagoCP>>(jsonReal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // Consultar pago por ID (1 registro) -> false, true
        // =====================================================
        public static async Task<PagosCompras> ConsultarX_IdPago(int IdPago)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM PagosCompras WITH (NOLOCK)
WHERE id = {IdPago}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<PagosCompras>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // Totales (ESCALAR) -> false, true
        // =====================================================
        public static async Task<int> hallarTotalPagoCPAño(DateTime Fecha, int IdSede)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(CAST(valorPagadoCompra AS INT)),0) AS total
FROM PagosCompras WITH (NOLOCK)
WHERE idSede = {IdSede}
  AND YEAR(fechaPagoCompra) = {Fecha.Year};";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
          
                if(respuesta==null) return 0;

                var row = JsonConvert.DeserializeObject<ClassSumaTotal>(respuesta);
                return Convert.ToInt32(row.total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return 0;
            }
        }

        public static async Task<int> hallarTotalPagoCPMes(DateTime Fecha, int IdSede)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(CAST(valorPagadoCompra AS INT)),0) AS total
FROM PagosCompras WITH (NOLOCK)
WHERE idSede = {IdSede}
  AND YEAR(fechaPagoCompra) = {Fecha.Year}
  AND MONTH(fechaPagoCompra) = {Fecha.Month};";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                
                if(respuesta==null) return 0;
                var row = JsonConvert.DeserializeObject<ClassSumaTotal>(respuesta);
                return Convert.ToInt32(row.total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return 0;
            }
        }

        public static async Task<int> hallarTotalPagoCPDia(DateTime Fecha, int IdSede)
        {
            try
            {
                var query = $@"
                SELECT ISNULL(SUM(CAST(valorPagadoCompra AS INT)),0) AS total
                FROM PagosCompras WITH (NOLOCK)
                WHERE idSede = {IdSede}
                AND CONVERT(date, fechaPagoCompra) = CONVERT(date, '{Fecha:yyyy-MM-dd}');";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
               if(respuesta==null) return 0;

                var row = JsonConvert.DeserializeObject<ClassSumaTotal>(respuesta);
                return Convert.ToInt32(row.total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return 0;
            }
        }

        // =====================================================
        // Total por bolsillo/base (VIEW) (ESCALAR) -> false, true
        // =====================================================
        public static async Task<int> pagoCPBolsilloFecha(int Bolsillo, int IdBase)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(CAST(pagoActualVPagoCompra AS INT)),0) AS total
FROM V_PagoCP WITH (NOLOCK)
WHERE idBolsillo = {Bolsillo}
  AND idBaseCaja = {IdBase};";

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
    }
}

using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorDetalleVenta
    {
        private const string SP_CRUD = "dbo.CRUD_DetalleVenta";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // ======================================================
        // CRUD (INSERT / UPDATE / DELETE) 0=I 1=U 2=D
        // ======================================================
        public static async Task<RespuestaCRUD> GuardarEditarEliminar(DetalleVenta objDetalleV, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(objDetalleV));
                var query = $"EXEC {SP_CRUD} N'{json}', {Boton}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(respuesta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new RespuestaCRUD { estado = false, mensaje = ex.Message };
            }
        }

        // ======================================================
        // SUMATORIAS DESDE V_DetalleCaja
        // ======================================================
        public static async Task<int> SumarTotalVentaCosto(int NumeroVenta)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(costoTotal),0) AS total
FROM V_DetalleCaja WITH (NOLOCK)
WHERE idVenta = {NumeroVenta}";
                var r = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var json = JsonConvert.DeserializeObject<string>(r);
                return Convert.ToInt32(JsonConvert.DeserializeObject<List<dynamic>>(json)[0].total);
            }
            catch
            {
                return 0;
            }
        }

        public static async Task<decimal> SumarTotalVenta(int NumeroVenta)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(totalDetalle),0) AS total
FROM V_DetalleCaja WITH (NOLOCK)
WHERE idVenta = {NumeroVenta}";
                var r = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var json = JsonConvert.DeserializeObject<string>(r);
                return Convert.ToDecimal(JsonConvert.DeserializeObject<List<dynamic>>(json)[0].total);
            }
            catch
            {
                return 0;
            }
        }

        public static async Task<decimal> SumarTotalCosto(int NumeroVenta)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(costoTotal),0) AS total
FROM V_DetalleCaja WITH (NOLOCK)
WHERE idVenta = {NumeroVenta}";
                var r = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var json = JsonConvert.DeserializeObject<string>(r);
                return Convert.ToDecimal(JsonConvert.DeserializeObject<List<dynamic>>(json)[0].total);
            }
            catch
            {
                return 0;
            }
        }

        public static async Task<decimal> SumarTotalIVA(int NumeroVenta)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(valorIva),0) AS total
FROM V_DetalleCaja WITH (NOLOCK)
WHERE idVenta = {NumeroVenta}";
                var r = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var json = JsonConvert.DeserializeObject<string>(r);
                return Convert.ToDecimal(JsonConvert.DeserializeObject<List<dynamic>>(json)[0].total);
            }
            catch
            {
                return 0;
            }
        }

        // ======================================================
        // CONSULTAS
        // ======================================================
        public static async Task<DetalleVenta> ConsultaXNumeroVentaYidProducto(int numero, int IdPrecio)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM DetalleVenta WITH (NOLOCK)
WHERE idVenta = {numero} AND idPrecios = {IdPrecio}";
                var r = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var json = JsonConvert.DeserializeObject<string>(r);
                var lista = JsonConvert.DeserializeObject<List<DetalleVenta>>(json);
                return lista.Count > 0 ? lista[0] : null;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<DetalleVenta> ConsultarX_IDDetalle(int IdDetalle)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM DetalleVenta WHERE id={IdDetalle}";
                var r = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var json = JsonConvert.DeserializeObject<string>(r);
                var lista = JsonConvert.DeserializeObject<List<DetalleVenta>>(json);
                return lista.Count > 0 ? lista[0] : null;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<DetalleVenta> ConsultarIDVenta(int IdVenta)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM DetalleVenta WHERE idVenta={IdVenta}";
                var r = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var json = JsonConvert.DeserializeObject<string>(r);
                var lista = JsonConvert.DeserializeObject<List<DetalleVenta>>(json);
                return lista.Count > 0 ? lista[0] : null;
            }
            catch
            {
                return null;
            }
        }

        // ======================================================
        // LISTADOS
        // ======================================================
        public static async Task<List<R_DetalleVenta>> ListaDetalleVenta(int IdVenta)
        {
            var q = $"SELECT * FROM R_DetalleVenta WHERE idVentaV={IdVenta}";
            var r = await Conection_SQL.ConsultaSQLServer(q, false, true);
            var json = JsonConvert.DeserializeObject<string>(r);
            return JsonConvert.DeserializeObject<List<R_DetalleVenta>>(json);
        }

        public static async Task<List<V_DetalleCaja>> ListaDetalleCaja(int NumeroVenta)
        {
            var q = $"SELECT * FROM V_DetalleCaja WHERE idVenta={NumeroVenta} ORDER BY id DESC";
            var r = await Conection_SQL.ConsultaSQLServer(q, false, true);
            var json = JsonConvert.DeserializeObject<string>(r);
            return JsonConvert.DeserializeObject<List<V_DetalleCaja>>(json);
        }

        public static async Task<List<V_DetalleCaja>> filtrarConsecutivo(int Consecutivo)
        {
            var q = $"SELECT * FROM V_DetalleCaja WHERE idVenta={Consecutivo}";
            var r = await Conection_SQL.ConsultaSQLServer(q, false, true);
            var json = JsonConvert.DeserializeObject<string>(r);
            return JsonConvert.DeserializeObject<List<V_DetalleCaja>>(json);
        }

        public static async Task<List<R_DetalleVenta>> FiltrarX_IdVenta(int IDVENTA)
        {
            var q = $"SELECT * FROM R_DetalleVenta WHERE idVentaV={IDVENTA}";
            var r = await Conection_SQL.ConsultaSQLServer(q, false, true);
            var json = JsonConvert.DeserializeObject<string>(r);
            return JsonConvert.DeserializeObject<List<R_DetalleVenta>>(json);
        }

        // ======================================================
        // SUMAS AVANZADAS
        // ======================================================
        public static async Task<decimal> SumaVentaProducto(int IdInventario, int IdSede)
        {
            var q = $@"
SELECT ISNULL(SUM(cantidadDetalle),0) total
FROM DetalleVenta
WHERE idInventario={IdInventario} AND idSede={IdSede}";
            var r = await Conection_SQL.ConsultaSQLServer(q, false, true);
            var json = JsonConvert.DeserializeObject<string>(r);
            return Convert.ToDecimal(JsonConvert.DeserializeObject<List<dynamic>>(json)[0].total);
        }

        public static async Task<decimal> SumarTotalDetalles(DateTime fecha, int IdSede)
        {
            var q = $@"
SELECT ISNULL(SUM(totalDetalle),0) total
FROM V_TotalVentasDetalle
WHERE idSede={IdSede}
AND CAST(fechaVenta AS DATE)='{fecha:yyyy-MM-dd}'";
            var r = await Conection_SQL.ConsultaSQLServer(q, false, true);
            var json = JsonConvert.DeserializeObject<string>(r);
            return Convert.ToDecimal(JsonConvert.DeserializeObject<List<dynamic>>(json)[0].total);
        }

        // ======================================================
        // FACTURA ELECTRÓNICA (DataTable)
        // ======================================================
        //public static async Task<DataTable> Lista_FacturaElectronica(int IdVenta)
        //{
        //    try
        //    {
        //        var q = $"SELECT * FROM V_DetalleCaja WHERE idVenta={IdVenta}";
        //        return await Conection_SQL.ConsultaSQLServer_DataTable(q);
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}

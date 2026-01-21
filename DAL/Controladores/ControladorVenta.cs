using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorVenta
    {
        public static async Task<bool> Crud(TablaVentas tablaVentas, int Boton)
        {
            try
            {
                // Serializar objeto a JSON
                var json = JsonConvert.SerializeObject(tablaVentas);

                // Escapar comillas simples para SQL
                json = json.Replace("'", "''");

                // Ejecutar SP
                var query = $"EXEC dbo.CRUD_TablaVentas N'{json}', {Boton}";
                var respuesta =await Conection_SQL.ConsultaSQLServer(query, false, true);

                // Si el SP respondió algo, asumimos OK
                if (!string.IsNullOrWhiteSpace(respuesta))
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
        public static int HallarNumeroVenta(string Tipo, int IdSede)
        {
            try
            {
                // Evitar errores por comillas simples
                Tipo = (Tipo ?? "").Replace("'", "''");

                var query = $@"
SELECT ISNULL(MAX(numeroVenta), 0) AS Numero
FROM TablaVentas
WHERE tipoFactura = '{Tipo}'
  AND IdSede = {IdSede};
";

                // false = no lista | true = async
                var respuesta = Conection_SQL
                    .ConsultaSQLServer(query, false, true)
                    .GetAwaiter()
                    .GetResult();

                if (string.IsNullOrWhiteSpace(respuesta))
                    return 1;

                // El resultado viene como JSON
                var data = JsonConvert.DeserializeObject<List<dynamic>>(respuesta);

                if (data != null && data.Count > 0 && data[0].Numero != null)
                {
                    return Convert.ToInt32(data[0].Numero) + 1;
                }

                return 1;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(
                    "Ocurrió un error de conexión.",
                    "Error De conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return 0;
            }
        }

        public static async Task<TablaVentas> ConsultaX_id(int IDVenta)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM TablaVentas WHERE id = {IDVenta}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query,false,true);
                if (string.IsNullOrWhiteSpace(respuesta))
                    return null;
                return JsonConvert.DeserializeObject<TablaVentas>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }


        public static async Task<V_TablaVentas> ConsultaX_V_id(int IDVenta)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM V_TablaVentas WHERE id = {IDVenta}";
                var respuesta =await Conection_SQL.ConsultaSQLServer(query, false, true);
                if (respuesta==null)
                    return null;

                return JsonConvert.DeserializeObject<V_TablaVentas>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }


        public static async Task<TablaVentas> ConsultaX_guid(Guid guidText)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM TablaVentas WHERE guidVenta = '{guidText}'";

                var resp=await Conection_SQL.ConsultaSQLServer(query, false, true);
                if(resp==null) return null;
                return JsonConvert.DeserializeObject<TablaVentas>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static async Task<decimal> TotalVentasTiendaAño(DateTime Fecha, string TipoVenta, int IdSede)
        {
            try
            {
                var inicio = new DateTime(Fecha.Year, 1, 1);
                var fin = inicio.AddYears(1);

                var query = $@"
SELECT ISNULL(SUM(totalVenta), 0) AS Total
FROM V_TablaVentas
WHERE IdSede = {IdSede}
  AND estadoVenta <> 'ANULADA'
  AND fechaVenta >= '{inicio:yyyy-MM-dd HH:mm:ss}'
  AND fechaVenta <  '{fin:yyyy-MM-dd HH:mm:ss}'
";

                var respuesta =await Conection_SQL
                    .ConsultaSQLServer(query, false, true);

                if (string.IsNullOrWhiteSpace(respuesta))
                    return 0;

                var data = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<ClassSumaTotal>(respuesta);

                if (data != null && data.total != 0)
                    return Convert.ToDecimal(data.total);

                return 0;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(
                    "Ocurrió un error de conexión.",
                    "Error De conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return 0;
            }
        }

        public static async Task<decimal> CostoTiendaAño(DateTime Fecha, string TipoVenta, int IdSede)
        {
            try
            {
                var inicio = new DateTime(Fecha.Year, 1, 1);
                var fin = inicio.AddYears(1);

                var query = $@"
SELECT ISNULL(SUM(costoTotalVenta), 0) AS Total
FROM V_TablaVentas
WHERE IdSede = {IdSede}
  AND estadoVenta <> 'ANULADA'
  AND fechaVenta >= '{inicio:yyyy-MM-dd HH:mm:ss}'
  AND fechaVenta <  '{fin:yyyy-MM-dd HH:mm:ss}'
";

                var respuesta =await Conection_SQL
                    .ConsultaSQLServer(query, false, true);

                if (string.IsNullOrWhiteSpace(respuesta))
                    return 0;

                var data = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<ClassSumaTotal>(respuesta);

                if (data != null && data.total != 0)
                    return Convert.ToDecimal(data.total);

                return 0;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(
                    "Ocurrió un error de conexión.",
                    "Error De conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return 0;
            }
        }

        public static async Task<decimal> TotalVentasTiendaMes(DateTime Fecha, string TipoVenta, int IdSede)
        {
            try
            {
                var inicio = new DateTime(Fecha.Year, Fecha.Month, 1);
                var fin = inicio.AddMonths(1);

                // Evitar problemas con comillas
                TipoVenta = (TipoVenta ?? "").Replace("'", "''");

                var query = $@"
SELECT ISNULL(SUM(totalVenta), 0) AS Total
FROM V_TablaVentas
WHERE IdSede = {IdSede}
  AND estadoVenta <> 'ANULADA'
  AND tipoVenta = '{TipoVenta}'
  AND fechaVenta >= '{inicio:yyyy-MM-dd HH:mm:ss}'
  AND fechaVenta <  '{fin:yyyy-MM-dd HH:mm:ss}'
";

                var respuesta =await Conection_SQL
                    .ConsultaSQLServer(query, false, true);

                if (string.IsNullOrWhiteSpace(respuesta))
                    return 0;

                var data = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<ClassSumaTotal>(respuesta);

                if (data != null &&  data.total != 0)
                    return Convert.ToDecimal(data.total);

                return 0;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(
                    "Ocurrió un error de conexión.",
                    "Error De conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return 0;
            }
        }

        // ✅ Costo tienda mes (SUM costoTotalVenta) - SCALAR
        public static async Task<decimal> CostoTiendaMes(DateTime fecha, string tipoVenta, int idSede)
        {
            try
            {
                // Evita YEAR()/MONTH() para mejor rendimiento (usa rango)
                var desde = new DateTime(fecha.Year, fecha.Month, 1);
                var hasta = desde.AddMonths(1);

                string query = $@"
                SELECT ISNULL(SUM(CAST(costoTotalVenta AS decimal(18,2))), 0) AS Total
                FROM V_TablaVentas
                WHERE IdSede = {idSede}
                  AND estadoVenta <> 'ANULADA'
                  -- AND tipoVenta = '{EscapeSql(tipoVenta)}'
                  AND fechaVenta >= '{desde:yyyy-MM-ddTHH:mm:ss}'
                  AND fechaVenta <  '{hasta:yyyy-MM-ddTHH:mm:ss}';
            ";

                var json = await Conection_SQL.ConsultaSQLServer(query, false, true);
                // Esperamos que la API retorne algo como: [{"Total":12345.67}]
                var rows = JsonConvert.DeserializeObject<ScalarDecimalRow>(json);

                return rows.Total;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0m;
            }
        }

        // ✅ Total ventas tienda día (SUM totalVenta) - SCALAR
        public static async Task<decimal> TotalVentasTiendaDia(DateTime fecha, string tipoVenta, int idSede)
        {
            try
            {
                var desde = fecha.Date;
                var hasta = desde.AddDays(1);

                string query = $@"
                SELECT ISNULL(SUM(CAST(totalVenta AS decimal(18,2))), 0) AS Total
                FROM V_TablaVentas
                WHERE IdSede = {idSede}
                  AND estadoVenta <> 'ANULADA'
                  -- AND tipoVenta = '{EscapeSql(tipoVenta)}'
                  AND fechaVenta >= '{desde:yyyy-MM-ddTHH:mm:ss}'
                  AND fechaVenta <  '{hasta:yyyy-MM-ddTHH:mm:ss}';
            ";

                var json = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var rows = JsonConvert.DeserializeObject<ScalarDecimalRow>(json);

                return rows.Total;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0m;
            }
        }

        // ✅ Costo tienda día (SUM costoTotalVenta) - SCALAR
        public static async Task<decimal> CostoTiendaDia(DateTime fecha, string tipoVenta, int idSede)
        {
            try
            {
                var desde = fecha.Date;
                var hasta = desde.AddDays(1);

                string query = $@"
                SELECT ISNULL(SUM(CAST(costoTotalVenta AS decimal(18,2))), 0) AS Total
                FROM V_TablaVentas
                WHERE IdSede = {idSede}
                  AND estadoVenta <> 'ANULADA'
                  -- AND tipoVenta = '{EscapeSql(tipoVenta)}'
                  AND fechaVenta >= '{desde:yyyy-MM-ddTHH:mm:ss}'
                  AND fechaVenta <  '{hasta:yyyy-MM-ddTHH:mm:ss}';
            ";

                var json = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var rows = JsonConvert.DeserializeObject<ScalarDecimalRow>(json);

                return rows.Total;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0m;
            }
        }

        // ✅ Hallar último ID (MAX) - SCALAR
        public static async Task<decimal> HallarUltimoID()
        {
            try
            {
                string query = @"
                SELECT ISNULL(MAX(CAST(id AS decimal(18,0))), 0) AS Total
                FROM TablaVentas;
            ";

                var json = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var rows = JsonConvert.DeserializeObject<System.Collections.Generic.List<ScalarDecimalRow>>(json);

                return (rows != null && rows.Count > 0) ? rows[0].Total : 0m;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0m;
            }
        }

        // Modelo simple para leer {"Total":...}
        private class ScalarDecimalRow
        {
            public decimal Total { get; set; }
        }

        // Escape simple por si luego activas el filtro tipoVenta
        private static string EscapeSql(string input)
            => (input ?? string.Empty).Replace("'", "''");
        public static async Task<DataTable> FiltroX_H_Año(DateTime Fecha, int IdSede)
        {
            try
            {
                string query = $@"
            SELECT *
            FROM V_TablaVentas
            WHERE IdSede = {IdSede}
              AND YEAR(fechaVenta) = {Fecha.Year}
        ";

                // SELECT que retorna lista
                string json = await Conection_SQL
                    .ConsultaSQLServer(query, true, true);

                if (string.IsNullOrWhiteSpace(json) || json.Trim() == "[]")
                    return null;

                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                return (dt != null && dt.Rows.Count > 0) ? dt : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(
                    "Ocurrió un error de conexión.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }
        public static async Task<DataTable> FiltroX_H_Mes(DateTime Fecha, int IdSede)
        {
            try
            {
                string query = $@"
            SELECT *
            FROM V_TablaVentas
            WHERE IdSede = {IdSede}
              AND YEAR(fechaVenta) = {Fecha.Year}
              AND MONTH(fechaVenta) = {Fecha.Month}
        ";

                // SELECT que retorna lista
                string json = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (string.IsNullOrWhiteSpace(json) || json.Trim() == "[]")
                    return null;

                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                return (dt != null && dt.Rows.Count > 0) ? dt : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(
                    "Ocurrió un error de conexión.",
                    "Error De conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }
        public static async Task<DataTable> FiltroX_H_Dia(DateTime Fecha, int IdSede)
        {
            try
            {
                string query = $@"
            SELECT *
            FROM V_TablaVentas
            WHERE IdSede = {IdSede}
              AND YEAR(fechaVenta) = {Fecha.Year}
              AND MONTH(fechaVenta) = {Fecha.Month}
              AND DAY(fechaVenta) = {Fecha.Day}
        ";

                // SELECT que retorna lista
                string json = await Conection_SQL
                    .ConsultaSQLServer(query, true, true);

                if (string.IsNullOrWhiteSpace(json) || json.Trim() == "[]")
                    return null;

                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                return (dt != null && dt.Rows.Count > 0) ? dt : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(
                    "Ocurrió un error de conexión.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }



        public static DataTable FiltroX_H_Año_Detalle(DateTime Fecha, int IdSede)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_InformeDetalleVenta where idSedeDetalle=" + IdSede + " and YEAR(fechaVentaDetalle)=" + Fecha.Year;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static DataTable FiltroX_H_Mes_Detalle(DateTime Fecha, int IdSede)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_InformeDetalleVenta where idSedeDetalle=" + IdSede + " and YEAR(fechaVentaDetalle)=" + Fecha.Year + " and " +
                "MONTH(fechaVentaDetalle) = " + Fecha.Month;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable FiltroX_H_Dia_Detalle(DateTime Fecha, int IdSede)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_InformeDetalleVenta where idSedeDetalle=" + IdSede + " and YEAR(fechaVentaDetalle)=" + Fecha.Year + " and " +
                "MONTH(fechaVentaDetalle) = " + Fecha.Month + " and DAY(fechaVentaDetalle) = " + Fecha.Day;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }



        public static DataTable FiltroX_H_Año_IdCategorias(DateTime Fecha, int IdSede,int IdCategoria)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_ListaVentaCategoria where idSede_c=" + IdSede + " and idCategoria_c="+IdCategoria+" and YEAR(fechaVenta_c)=" + Fecha.Year;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static DataTable FiltroX_H_Mes_IdCategorias(DateTime Fecha, int IdSede,int IdCategoria)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_ListaVentaCategoria where idSede_c=" + IdSede + " and idCategoria_c=" + IdCategoria + " and YEAR(fechaVenta_c)=" + Fecha.Year + " and " +
                "MONTH(fechaVenta_c) = " + Fecha.Month;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable FiltroX_H_Dia_IdCategorias(DateTime Fecha, int IdSede,int IdCategoria)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from V_ListaVentaCategoria where idSede_c=" + IdSede + " and idCategoria_c=" + IdCategoria + " and YEAR(fechaVenta_c)=" + Fecha.Year + " and " +
                "MONTH(fechaVenta_c) = " + Fecha.Month + " and DAY(fechaVenta_c) = " + Fecha.Day;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }



        public static async Task<DataTable> FiltroX_H_Año_Categorias(DateTime Fecha, int IdSede)
        {
            try
            {
                string query = $@"
            SELECT *
            FROM V_ListaVentaCategoria
            WHERE idSede_c = {IdSede}
              AND YEAR(fechaVenta_c) = {Fecha.Year}
        ";

                // SELECT que retorna lista
                string json = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (string.IsNullOrWhiteSpace(json) || json.Trim() == "[]")
                    return null;

                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                return (dt != null && dt.Rows.Count > 0) ? dt : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(
                    "Ocurrió un error de conexión.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }
        public static async Task<DataTable> FiltroX_H_Mes_Categorias(DateTime Fecha, int IdSede)
        {
            try
            {
                string query = $@"
            SELECT *
            FROM V_ListaVentaCategoria
            WHERE idSede_c = {IdSede}
              AND YEAR(fechaVenta_c) = {Fecha.Year}
              AND MONTH(fechaVenta_c) = {Fecha.Month}
        ";

                // SELECT que retorna lista
                string json = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (string.IsNullOrWhiteSpace(json) || json.Trim() == "[]")
                    return null;

                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                return (dt != null && dt.Rows.Count > 0) ? dt : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(
                    "Ocurrió un error de conexión.",
                    "Error De conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }

        public static async Task<DataTable> FiltroX_H_Dia_Categorias(DateTime Fecha, int IdSede)
        {
            try
            {
                string query = $@"
            SELECT *
            FROM V_ListaVentaCategoria
            WHERE idSede_c = {IdSede}
              AND YEAR(fechaVenta_c) = {Fecha.Year}
              AND MONTH(fechaVenta_c) = {Fecha.Month}
              AND DAY(fechaVenta_c) = {Fecha.Day}
        ";

                // SELECT que retorna lista
                string json = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (string.IsNullOrWhiteSpace(json) || json.Trim() == "[]")
                    return null;

                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                return (dt != null && dt.Rows.Count > 0) ? dt : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(
                    "Ocurrió un error de conexión.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }




        public static async Task<DataTable> FiltroX_H_Año_INFOCategorias(DateTime Fecha, int IdSede)
        {
            try
            {
                string query = $@"
            SELECT 
                c.id AS id_inf,
                c.nombreCategoria AS nombreCategoria_inf,

                (
                    SELECT ISNULL(SUM(cantidadDetalle), 0)
                    FROM V_DetalleCaja
                    INNER JOIN TablaVentas ON V_DetalleCaja.idVenta = TablaVentas.id
                    INNER JOIN Precios ON V_DetalleCaja.idPrecios = Precios.id
                    INNER JOIN Inventario ON Precios.idInventario = Inventario.id
                    INNER JOIN Producto ON Inventario.idProducto = Producto.id
                    WHERE Producto.idCategoria = c.id
                      AND TablaVentas.IdSede = {IdSede}
                      AND YEAR(fechaVenta) = {Fecha.Year}
                ) AS cantidadProductos_inf,

                (
                    SELECT ISNULL(SUM(totalDetalle), 0)
                    FROM V_DetalleCaja
                    INNER JOIN TablaVentas ON V_DetalleCaja.idVenta = TablaVentas.id
                    INNER JOIN Precios ON V_DetalleCaja.idPrecios = Precios.id
                    INNER JOIN Inventario ON Precios.idInventario = Inventario.id
                    INNER JOIN Producto ON Inventario.idProducto = Producto.id
                    WHERE Producto.idCategoria = c.id
                      AND TablaVentas.IdSede = {IdSede}
                      AND YEAR(fechaVenta) = {Fecha.Year}
                ) AS totalVentas_inf

            FROM CategoriaProducto c
        ";

                // SELECT que retorna lista
                string json = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (string.IsNullOrWhiteSpace(json) || json.Trim() == "[]")
                    return null;

                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                return (dt != null && dt.Rows.Count > 0) ? dt : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(
                    "Ocurrió un error al consultar la información anual por categorías.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }
        public static async Task<DataTable> FiltroX_H_Mes_INFOCategorias(DateTime Fecha, int IdSede)
        {
            try
            {
                string query = $@"
            SELECT 
                c.id AS id_inf,
                c.nombreCategoria AS nombreCategoria_inf,

                (
                    SELECT ISNULL(SUM(cantidadDetalle), 0)
                    FROM V_DetalleCaja
                    INNER JOIN TablaVentas ON V_DetalleCaja.idVenta = TablaVentas.id
                    INNER JOIN Precios ON V_DetalleCaja.idPrecios = Precios.id
                    INNER JOIN Inventario ON Precios.idInventario = Inventario.id
                    INNER JOIN Producto ON Inventario.idProducto = Producto.id
                    WHERE Producto.idCategoria = c.id
                      AND TablaVentas.IdSede = {IdSede}
                      AND YEAR(fechaVenta) = {Fecha.Year}
                      AND MONTH(fechaVenta) = {Fecha.Month}
                ) AS cantidadProductos_inf,

                (
                    SELECT ISNULL(SUM(totalDetalle), 0)
                    FROM V_DetalleCaja
                    INNER JOIN TablaVentas ON V_DetalleCaja.idVenta = TablaVentas.id
                    INNER JOIN Precios ON V_DetalleCaja.idPrecios = Precios.id
                    INNER JOIN Inventario ON Precios.idInventario = Inventario.id
                    INNER JOIN Producto ON Inventario.idProducto = Producto.id
                    WHERE Producto.idCategoria = c.id
                      AND TablaVentas.IdSede = {IdSede}
                      AND YEAR(fechaVenta) = {Fecha.Year}
                      AND MONTH(fechaVenta) = {Fecha.Month}
                ) AS totalVentas_inf

            FROM CategoriaProducto c
        ";

                // SELECT que retorna lista
                string json = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (string.IsNullOrWhiteSpace(json) || json.Trim() == "[]")
                    return null;

                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                return (dt != null && dt.Rows.Count > 0) ? dt : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(
                    "Ocurrió un error al consultar la información mensual por categorías.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }
        public static async Task<DataTable> FiltroX_H_Dia_INFOCategorias(DateTime Fecha, int IdSede)
        {
            try
            {
                string query = $@"
            SELECT 
                c.id AS id_inf,
                c.nombreCategoria AS nombreCategoria_inf,

                (
                    SELECT ISNULL(SUM(cantidadDetalle), 0)
                    FROM V_DetalleCaja
                    INNER JOIN TablaVentas ON V_DetalleCaja.idVenta = TablaVentas.id
                    INNER JOIN Precios ON V_DetalleCaja.idPrecios = Precios.id
                    INNER JOIN Inventario ON Precios.idInventario = Inventario.id
                    INNER JOIN Producto ON Inventario.idProducto = Producto.id
                    WHERE Producto.idCategoria = c.id
                      AND TablaVentas.IdSede = {IdSede}
                      AND YEAR(fechaVenta) = {Fecha.Year}
                      AND MONTH(fechaVenta) = {Fecha.Month}
                      AND DAY(fechaVenta) = {Fecha.Day}
                ) AS cantidadProductos_inf,

                (
                    SELECT ISNULL(SUM(totalDetalle), 0)
                    FROM V_DetalleCaja
                    INNER JOIN TablaVentas ON V_DetalleCaja.idVenta = TablaVentas.id
                    INNER JOIN Precios ON V_DetalleCaja.idPrecios = Precios.id
                    INNER JOIN Inventario ON Precios.idInventario = Inventario.id
                    INNER JOIN Producto ON Inventario.idProducto = Producto.id
                    WHERE Producto.idCategoria = c.id
                      AND TablaVentas.IdSede = {IdSede}
                      AND YEAR(fechaVenta) = {Fecha.Year}
                      AND MONTH(fechaVenta) = {Fecha.Month}
                      AND DAY(fechaVenta) = {Fecha.Day}
                ) AS totalVentas_inf

            FROM CategoriaProducto c
        ";

                // SELECT que retorna lista
                string json = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (string.IsNullOrWhiteSpace(json) || json.Trim() == "[]")
                    return null;

                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                return (dt != null && dt.Rows.Count > 0) ? dt : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(
                    "Ocurrió un error al consultar la información por categorías.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }




        public static async Task<List<V_TablaVentas>> listaCompleta(int idSede)
        {
            try
            {
                string query = $@"
                SELECT *
                FROM V_TablaVentas
                WHERE IdSede = {idSede}
                  AND numeroVenta > 0;
            ";

                var json = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<V_TablaVentas>>(json);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<V_TablaVentas>> filtroNumeroVenta(int numeroV, int idSede)
        {
            try
            {
                string query = $@"
                SELECT *
                FROM V_TablaVentas
                WHERE numeroVenta = {numeroV}
                  AND IdSede = {idSede};
            ";

                var json = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<V_TablaVentas>>(json);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<V_TablaVentas>> filtroDia(DateTime fecha, int idSede)
        {
            try
            {
                var desde = fecha.Date;
                var hasta = desde.AddDays(1);

                string query = $@"
                SELECT *
                FROM V_TablaVentas
                WHERE IdSede = {idSede}
                  AND fechaVenta >= '{desde:yyyy-MM-ddTHH:mm:ss}'
                  AND fechaVenta <  '{hasta:yyyy-MM-ddTHH:mm:ss}';
            ";

                var json = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<V_TablaVentas>>(json);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<V_TablaVentas>> filtroMes(DateTime fecha, int idSede)
        {
            try
            {
                var desde = new DateTime(fecha.Year, fecha.Month, 1);
                var hasta = desde.AddMonths(1);

                string query = $@"
                SELECT *
                FROM V_TablaVentas
                WHERE IdSede = {idSede}
                  AND fechaVenta >= '{desde:yyyy-MM-ddTHH:mm:ss}'
                  AND fechaVenta <  '{hasta:yyyy-MM-ddTHH:mm:ss}';
            ";

                var json = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<V_TablaVentas>>(json);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<V_TablaVentas>> filtroAño(DateTime fecha, int idSede)
        {
            try
            {
                var desde = new DateTime(fecha.Year, 1, 1);
                var hasta = desde.AddYears(1);

                string query = $@"
                SELECT *
                FROM V_TablaVentas
                WHERE IdSede = {idSede}
                  AND fechaVenta >= '{desde:yyyy-MM-ddTHH:mm:ss}'
                  AND fechaVenta <  '{hasta:yyyy-MM-ddTHH:mm:ss}';
            ";

                var json = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<V_TablaVentas>>(json);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<V_TablaVentas>> filtrarVentas_0()
        {
            try
            {
                string query = @"
                SELECT *
                FROM V_TablaVentas
                WHERE totalVenta = 0;
            ";

                var json = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<V_TablaVentas>>(json);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =========================
        //  Totales (SCALAR)
        // =========================

        public static async Task<int> HallarTotalVentasEfectivo(string tipoVenta, string estadoVenta, int idBase)
        {
            try
            {
                string query = $@"
                SELECT 
                    CAST(
                        ISNULL(SUM(totalVenta), 0) - ISNULL(SUM(abonoTarjeta), 0)
                    AS int) AS Total
                FROM V_TablaVentas
                WHERE tipoVenta = '{EscapeSql(tipoVenta)}'
                  AND estadoVenta <> '{EscapeSql(estadoVenta)}'
                  AND idBaseCaja = {idBase};
            ";

                var json = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var rows = JsonConvert.DeserializeObject<List<ScalarIntRow>>(json);

                return (rows != null && rows.Count > 0) ? rows[0].Total : 0;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }

        public static async Task<int> HallarTotalVentasTarjeta(string tipoVenta, string estadoVenta, int idBase)
        {
            try
            {
                string query = $@"
                SELECT 
                    CAST(ISNULL(SUM(abonoTarjeta), 0) AS int) AS Total
                FROM V_TablaVentas
                WHERE tipoVenta = '{EscapeSql(tipoVenta)}'
                  AND estadoVenta <> '{EscapeSql(estadoVenta)}'
                  AND idBaseCaja = {idBase};
            ";

                var json = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var rows = JsonConvert.DeserializeObject<List<ScalarIntRow>>(json);

                return (rows != null && rows.Count > 0) ? rows[0].Total : 0;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }

        // =========================
        //  V_R_VentaCliente (1 item)
        // =========================

        public static async Task<V_R_VentaCliente> ConsultarX_IdCleinte_EstadoVenta(int idCliente, string estado)
        {
            try
            {
                string query = $@"
                SELECT TOP 1 *
                FROM V_R_VentaCliente
                WHERE idCliente = {idCliente}
                  AND estadoVenta = '{EscapeSql(estado)}';
            ";

                // Puede devolver lista de 1
                var json = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var rows = JsonConvert.DeserializeObject<List<V_R_VentaCliente>>(json);

                return (rows != null && rows.Count > 0) ? rows[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =========================
        //  V_FacturasCredito (LISTA)
        // =========================

        public static async Task<List<V_FacturasCredito>> ListaFacturasCredito(int idCliente, int idSede)
        {
            try
            {
                string query = $@"
                SELECT *
                FROM V_FacturasCredito
                WHERE IdSede = {idSede}
                  AND idCliente = {idCliente};
            ";

                var json = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<V_FacturasCredito>>(json);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =========================
        //  ConsultarVentas_0 (1 item)
        // =========================

        public static async Task<V_TablaVentas> ConsultarVentas_0()
        {
            try
            {
                string query = @"
                SELECT TOP 1 *
                FROM V_TablaVentas
                WHERE totalVenta = 0;
            ";

                var json = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var rows = JsonConvert.DeserializeObject<List<V_TablaVentas>>(json);

                return (rows != null && rows.Count > 0) ? rows[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =========================
        //  Helpers
        // =========================

        private class ScalarIntRow
        {
            public int Total { get; set; }
        }

    }
}

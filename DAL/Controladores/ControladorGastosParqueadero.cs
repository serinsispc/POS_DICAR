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
    public class ControladorGastos
    {
        private const string SP_CRUD = "dbo.CRUD_Gastos";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // ==========================
        // CRUD (NO lista) -> false, true
        // ==========================
        public static async Task<RespuestaCRUD> Guardar_Editar_Eliminar_Gasto(Gastos objGastoP, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(objGastoP));
                var query = $"EXEC {SP_CRUD} N'{json}', {Boton}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(respuesta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new RespuestaCRUD { estado = false, idAfectado = 0, mensaje = ex.Message };
            }
        }

        // ==========================
        // LISTA COMPLETA (V_Gastos) -> true, true
        // ==========================
        public static async Task<List<V_Gastos>> ConsultaTodosLosGastos(int IdSede)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_Gastos WITH (NOLOCK)
WHERE idSede = {IdSede}
ORDER BY fecha DESC, id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<V_Gastos>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // ==========================
        // CONSULTA POR ID (1 registro) -> false, true
        // ==========================
        public static async Task<Gastos> ConsultaGastoXId(int pid)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM Gastos WITH (NOLOCK)
WHERE id = {pid};";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                var lista = JsonConvert.DeserializeObject<List<Gastos>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ==========================
        // LISTA POR FECHA (día exacto) -> true, true
        // Nota: tu método original NO filtraba por sede.
        // ==========================
        public static async Task<List<V_Gastos>> ConsultaGastoXFecha(DateTime pFecha)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_Gastos WITH (NOLOCK)
WHERE CAST(fecha AS date) = '{pFecha:yyyy-MM-dd}'
ORDER BY fecha DESC, id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<V_Gastos>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ==========================
        // SUMAS (NO lista) -> false, true
        // ==========================
        public static async Task<int> HallarTotalGastosDia(DateTime Fecha, int IdSede)
        {
            try
            {
                var query = $@"
                SELECT ISNULL(SUM(CAST(valor AS INT)),0) AS total
                FROM Gastos WITH (NOLOCK)
                WHERE idSede = {IdSede}
                  AND CAST(fecha AS date) = '{Fecha:yyyy-MM-dd}';";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                if (respuesta == null) return 0;
                var row = JsonConvert.DeserializeObject<ClassSumaTotal>(respuesta);
                return Convert.ToInt32(row.total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static async Task<int> HallarTotalGastoFull(int IdSede)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(CAST(valor AS INT)),0) AS total
FROM Gastos WITH (NOLOCK)
WHERE idSede = {IdSede};";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                var row = JsonConvert.DeserializeObject<List<dynamic>>(jsonReal);
                return Convert.ToInt32(row[0].total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static async Task<int> HallarTotalGastosMes(DateTime Fecha, int IdSede)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(CAST(valor AS INT)),0) AS total
FROM Gastos WITH (NOLOCK)
WHERE idSede = {IdSede}
  AND YEAR(fecha) = {Fecha.Year}
  AND MONTH(fecha) = {Fecha.Month};";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                if (respuesta == null) return 0;
                var row = JsonConvert.DeserializeObject<ClassSumaTotal>(respuesta);
                return Convert.ToInt32(row.total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static async Task<int> HallarTotalGastosAño(DateTime Fecha, int IdSede)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(CAST(valor AS INT)),0) AS total
FROM Gastos WITH (NOLOCK)
WHERE idSede = {IdSede}
  AND YEAR(fecha) = {Fecha.Year};";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                if (respuesta == null) return 0;
                var row = JsonConvert.DeserializeObject<ClassSumaTotal>(respuesta);
                return Convert.ToInt32(row.total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // Igual a tu original: no filtra por sede
        public static async Task<int> HallarValorEgresoParqueadero(DateTime pfecha)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(CAST(valor AS INT)),0) AS total
FROM Gastos WITH (NOLOCK)
WHERE CAST(fecha AS date) = '{pfecha:yyyy-MM-dd}';";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                var row = JsonConvert.DeserializeObject<List<dynamic>>(jsonReal);
                return Convert.ToInt32(row[0].total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // ==========================
        // FILTROS (V_Gastos) -> true, true
        // ==========================
        public static async Task<List<V_Gastos>> FiltrarX_Año(DateTime FechaFiltro, int IdSede)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_Gastos WITH (NOLOCK)
WHERE idSede = {IdSede}
  AND YEAR(fecha) = {FechaFiltro.Year}
ORDER BY fecha DESC, id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);
                if (respuesta == null) return null;
                return JsonConvert.DeserializeObject<List<V_Gastos>>(respuesta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<List<V_Gastos>> FiltrarX_Mes(DateTime FechaFiltro, int IdSede)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_Gastos WITH (NOLOCK)
WHERE idSede = {IdSede}
  AND YEAR(fecha) = {FechaFiltro.Year}
  AND MONTH(fecha) = {FechaFiltro.Month}
ORDER BY fecha DESC, id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);
                if (respuesta == null) return null;
                return JsonConvert.DeserializeObject<List<V_Gastos>>(respuesta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<List<V_Gastos>> FiltrarX_Dia(DateTime FechaFiltro, int IdSede)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_Gastos WITH (NOLOCK)
WHERE idSede = {IdSede}
  AND CAST(fecha AS date) = '{FechaFiltro:yyyy-MM-dd}'
ORDER BY fecha DESC, id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);
                if(respuesta == null) return null;
                return JsonConvert.DeserializeObject<List<V_Gastos>>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ==========================
        // TOTAL POR BOLSILLO (NO lista) -> false, true
        // ==========================
        public static async Task<int> TotalGastosBolsillo(int Bolsillo, int idBase)
        {
            try
            {
                var query = $@"
SELECT ISNULL(SUM(CAST(valor AS INT)),0) AS total
FROM Gastos WITH (NOLOCK)
WHERE idBolsillo = {Bolsillo}
  AND idBasecaja = {idBase};";

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
    }
}

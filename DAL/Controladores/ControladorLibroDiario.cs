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
    public class ControladorLibroDiario
    {
        private const string SP_CRUD = "dbo.CRUD_LibroDiario";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // ==========================
        // CRUD (NO lista) -> false, true
        // Boton: 0=INSERT, 1=UPDATE, 2=DELETE
        // ==========================
        public static async Task<RespuestaCRUD> CrearEditarEliminarLibroDiario(LibroDiario objLibro, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(objLibro));
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
        // Consultar por ID (1 registro) -> false, true
        // ==========================
        public static async Task<LibroDiario> consultarID(int IDLibro)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM LibroDiario WITH (NOLOCK)
WHERE id = {IDLibro}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<LibroDiario>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return null;
            }
        }

        // ==========================
        // Hallar ultimo ID (NO lista) -> false, true
        // OJO: tu método se llama hallarUltimoSaldo pero devuelve el MAX(id)
        // ==========================
        public static async Task<int> hallarUltimoSaldo()
        {
            try
            {
                var query = @"
SELECT ISNULL(MAX(id),0) AS ultimo
FROM LibroDiario WITH (NOLOCK);";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var row = JsonConvert.DeserializeObject<List<dynamic>>(jsonReal);
                return Convert.ToInt32(row[0].ultimo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return 0;
            }
        }

        // ==========================
        // LISTA COMPLETA (V_LibroDiario) -> true, true
        // ==========================
        public static async Task<List<V_LibroDiario>> listaCompleta()
        {
            try
            {
                var query = @"
SELECT *
FROM V_LibroDiario WITH (NOLOCK)
ORDER BY fechaMovimiento DESC, id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // 👈 LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                return JsonConvert.DeserializeObject<List<V_LibroDiario>>(jsonReal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return null;
            }
        }

        // ==========================
        // FILTRO AÑO (V_LibroDiario) -> true, true
        // ==========================
        public static async Task<List<V_LibroDiario>> filtroAño(DateTime Fecha)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_LibroDiario WITH (NOLOCK)
WHERE YEAR(fechaMovimiento) = {Fecha.Year}
ORDER BY fechaMovimiento DESC, id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // 👈 LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                return JsonConvert.DeserializeObject<List<V_LibroDiario>>(jsonReal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return null;
            }
        }

        // ==========================
        // FILTRO MES (V_LibroDiario) -> true, true
        // ==========================
        public static async Task<List<V_LibroDiario>> filtroMes(DateTime Fecha)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_LibroDiario WITH (NOLOCK)
WHERE YEAR(fechaMovimiento) = {Fecha.Year}
  AND MONTH(fechaMovimiento) = {Fecha.Month}
ORDER BY fechaMovimiento DESC, id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // 👈 LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                return JsonConvert.DeserializeObject<List<V_LibroDiario>>(jsonReal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return null;
            }
        }

        // ==========================
        // FILTRO DIA (V_LibroDiario) -> true, true
        // ==========================
        public static async Task<List<V_LibroDiario>> filtroDia(DateTime Fecha)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_LibroDiario WITH (NOLOCK)
WHERE CAST(fechaMovimiento AS date) = '{Fecha:yyyy-MM-dd}'
ORDER BY fechaMovimiento DESC, id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // 👈 LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                return JsonConvert.DeserializeObject<List<V_LibroDiario>>(jsonReal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return null;
            }
        }

        // ==========================
        // CONSULTA por Motivo + Bolsillo (1 registro) -> false, true
        // ==========================
        public static async Task<LibroDiario> consultaMotivoIdBolsillo(string Detalle, int IdBol)
        {
            try
            {
                var d = (Detalle ?? string.Empty).Replace("'", "''");

                var query = $@"
SELECT TOP 1 *
FROM LibroDiario WITH (NOLOCK)
WHERE motivoMovimiento = '{d}'
  AND idBolsillo = {IdBol}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<LibroDiario>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string error = ex.Message;
                return null;
            }
        }
    }
}

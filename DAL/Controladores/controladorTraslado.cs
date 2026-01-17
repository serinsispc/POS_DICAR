using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class controladorTraslado
    {
        // =====================================================
        // CRUD -> SP dbo.CRUD_Traslados (JSON + funcion)
        // funcion/Boton: 0=INSERT, 1=UPDATE, 2=DELETE
        // =====================================================
        public static async Task<RespuestaCRUD> CrearEditarEliminarTraslado(Traslados objTraslado, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objTraslado);
                return await Crud(json, Boton);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new RespuestaCRUD()
                {
                    estado = false,
                    idAfectado = 0,
                    mensaje = error
                };
            }
        }

        // Método base: Crud(string json, int funcion)
        public static async Task<RespuestaCRUD> Crud(string json, int funcion)
        {
            try
            {
                json = EscapeJsonForSql(json);

                var query = $"EXEC dbo.CRUD_Traslados N'{json}', {funcion}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);

                return JsonConvert.DeserializeObject<RespuestaCRUD>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new RespuestaCRUD()
                {
                    estado = false,
                    idAfectado = 0,
                    mensaje = error
                };
            }
        }

        // =====================================================
        // LISTA COMPLETA POR SEDE (VIEW)
        // =====================================================
        public static async Task<List<V_Traslados>> listacompleta(int IdSede)
        {
            try
            {
                var query = $"SELECT * FROM V_Traslados WHERE v_idSedeTraslado = {IdSede}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);

                return JsonConvert.DeserializeObject<List<V_Traslados>>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // =====================================================
        // CONSULTAR POR GUID (TABLA Traslados)
        // =====================================================
        public static async Task<Traslados> ConsultarGuid(string GuidTex)
        {
            try
            {
                // Escapar comillas simples por seguridad
                GuidTex = (GuidTex ?? "").Replace("'", "''");

                var query = $"SELECT TOP 1 * FROM Traslados WHERE guidTraslado = '{GuidTex}'";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);

                var lista = JsonConvert.DeserializeObject<List<Traslados>>(respuesta);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // =====================================================
        // FILTRO POR DIA (VIEW)
        // =====================================================
        public static async Task<List<V_Traslados>> filtroFechaDIa(int IdSede, DateTime fecha)
        {
            try
            {
                // Evitar YEAR/MONTH/DAY (mata índices). Mejor rango [inicio, fin)
                var inicio = fecha.Date;
                var fin = inicio.AddDays(1);

                var query =
                    "SELECT * FROM V_Traslados " +
                    $"WHERE v_idSedeTraslado = {IdSede} " +
                    $"AND v_fechaTraslado >= '{inicio:yyyy-MM-dd HH:mm:ss}' " +
                    $"AND v_fechaTraslado < '{fin:yyyy-MM-dd HH:mm:ss}'";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<V_Traslados>>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // =====================================================
        // FILTRO POR MES (VIEW)
        // =====================================================
        public static async Task<List<V_Traslados>> filtroFechaMes(int IdSede, DateTime fecha)
        {
            try
            {
                var inicio = new DateTime(fecha.Year, fecha.Month, 1);
                var fin = inicio.AddMonths(1);

                var query =
                    "SELECT * FROM V_Traslados " +
                    $"WHERE v_idSedeTraslado = {IdSede} " +
                    $"AND v_fechaTraslado >= '{inicio:yyyy-MM-dd HH:mm:ss}' " +
                    $"AND v_fechaTraslado < '{fin:yyyy-MM-dd HH:mm:ss}'";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<V_Traslados>>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // =====================================================
        // Escape para JSON embebido en SQL
        // =====================================================
        private static string EscapeJsonForSql(string json)
        {
            return string.IsNullOrEmpty(json) ? "" : json.Replace("'", "''");
        }
    }


}

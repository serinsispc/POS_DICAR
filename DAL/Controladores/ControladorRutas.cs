using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores.Version_Software
{
    public class ControladorRutas
    {
        // =========================================================
        // CRUD (0=INSERT, 1=UPDATE, 2=DELETE) - SP JSON
        // =========================================================
        public static async Task<RespuestaCRUD> Crud(string json, int funcion)
        {
            try
            {
                string jsonEscapado = EscapeJsonForSql(json);
                var query = $"EXEC dbo.CRUD_RutaActualizacionEquipo N'{jsonEscapado}',{funcion}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(respuesta);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new RespuestaCRUD()
                {
                    estado = false,
                    mensaje = mensaje
                };
            }
        }

        private static string EscapeJsonForSql(string json)
        {
            if (string.IsNullOrWhiteSpace(json)) return json;
            return json.Replace("'", "''");
        }

        // =========================================================
        // CONSULTA: top 1 por nombre de equipo
        // =========================================================
        public static async Task<RutaActualizacionEquipo> ConsultarX_NombreEquipo(string nombreEquipo)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM RutaActualizacionEquipo WHERE nombre_equipo_local = N'{EscapeSql(nombreEquipo)}'";
                var resultado = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (string.IsNullOrWhiteSpace(resultado))
                    return null;

                return JsonConvert.DeserializeObject<RutaActualizacionEquipo>(resultado);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private static string EscapeSql(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            return value.Replace("'", "''");
        }

        // =========================================================
        // LISTA COMPLETA (LISTAS -> true, true)
        // =========================================================
        public static async Task<List<RutaActualizacionEquipo>> ListaCompleta()
        {
            try
            {
                var query = "SELECT * FROM RutaActualizacionEquipo";
                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<RutaActualizacionEquipo>>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores.Version_Software
{
    public class ControladorReporteActualizacion
    {
        private const string SP_CRUD = "CRUD_ReporteActualizacionEquipo";

        /// <summary>
        /// funcion: 0=INSERT, 1=UPDATE, 2=DELETE
        /// </summary>
        public static async Task<string> Crud(ReporteActualizacionEquipo objReporteActualizacion, int funcion)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objReporteActualizacion);
                json = EscapeJsonForSql(json);

                var query = $"EXEC dbo.{SP_CRUD} N'{json}', {funcion}";
                // CRUD => false, true
                return await Conection_SQL.ConsultaSQLServer(query, false, true);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<ReporteActualizacionEquipo> ConsultarX_NombreEquipo_NOmbreActualizacion(
            string NombreEquipo,
            string NombreVersion)
        {
            try
            {
                // OJO: evitar inyección/errores por comillas simples
                NombreEquipo = (NombreEquipo ?? "").Replace("'", "''");
                NombreVersion = (NombreVersion ?? "").Replace("'", "''");

                var query =
                    $"SELECT TOP 1 * " +
                    $"FROM ReporteActualizacionEquipo " +
                    $"WHERE nombre_equipo_actualizado = N'{NombreEquipo}' " +
                    $"AND nombre_version_actualizado = N'{NombreVersion}'";

                // Consulta 1 registro => false, true
                var resultado = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (string.IsNullOrWhiteSpace(resultado))
                    return null;

                return JsonConvert.DeserializeObject<ReporteActualizacionEquipo>(resultado);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<List<ReporteActualizacionEquipo>> listaCompleta()
        {
            try
            {
                var query = "SELECT * FROM ReporteActualizacionEquipo";

                // LISTAS => true, true
                var resultado = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (string.IsNullOrWhiteSpace(resultado))
                    return null;

                return JsonConvert.DeserializeObject<List<ReporteActualizacionEquipo>>(resultado);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private static string EscapeJsonForSql(string json)
        {
            if (string.IsNullOrEmpty(json)) return json;
            return json.Replace("'", "''");
        }
    }
}

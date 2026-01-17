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
    public class ControladorLicenciaSoftware
    {
        private const string SP_CRUD = "dbo.CRUD_Licencia";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // ==========================
        // CRUD (NO lista) -> false, true
        // Boton: 0=INSERT, 1=UPDATE, 2=DELETE
        // ==========================
        public static async Task<RespuestaCRUD> Crear_Editar_Eliminar_LicenciaSoftware(Licencia objLicencia, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(objLicencia));
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
        // Consultar por clave (1 registro) -> false, true
        // ==========================
        public static async Task<Licencia> ConsultarLicencia(string licencia)
        {
            try
            {
                var lic = (licencia ?? string.Empty).Replace("'", "''");

                var query = $@"
SELECT TOP 1 *
FROM Licencia WITH (NOLOCK)
WHERE clave = N'{lic}'
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);

                // respuesta viene como string JSON serializado
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                // convertimos a lista para tomar el primer registro
                var lista = JsonConvert.DeserializeObject<List<Licencia>>(jsonReal);

                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // ==========================
        // LISTA COMPLETA -> true, true
        // ==========================
        public static async Task<List<Licencia>> ListaCompleta()
        {
            try
            {
                var query = @"
SELECT *
FROM Licencia WITH (NOLOCK)
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // 👈 LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<Licencia>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

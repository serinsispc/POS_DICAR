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
    public class ControladorPermisoSubModulo
    {
        private const string SP_CRUD = "dbo.CRUD_PermisoSubModulo";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // =====================================================
        // CRUD -> false, true
        // Boton: 0=INSERT | 2=DELETE
        // =====================================================
        public static async Task<RespuestaCRUD> CrearEliminarPermisomodulo(PermisoSubModulo objPermiso, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(objPermiso));
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
        // LISTA -> true, true
        // =====================================================
        public static async Task<List<PermisoSubModulo>> filtroIdUsuario(int IdUsuario)
        {
            try
            {
                var query = $@"
SELECT *
FROM PermisoSubModulo WITH (NOLOCK)
WHERE idUsuario = {IdUsuario}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<PermisoSubModulo>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // =====================================================
        // Antes devolvía DataTable.
        // Ahora devolvemos LISTA (tu estándar) -> true, true
        // =====================================================
        public static async Task<List<PermisoSubModulo>> consultarIdusuario(int IdUsuario)
        {
            try
            {
                var query = $@"
SELECT *
FROM PermisoSubModulo WITH (NOLOCK)
WHERE idUsuario = {IdUsuario}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<PermisoSubModulo>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // =====================================================
        // 1 registro -> false, true
        // =====================================================
        public static async Task<PermisoSubModulo> consultarIdSubModuloIdusuario(int IdUsuario, int IdSubmodulo)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM PermisoSubModulo WITH (NOLOCK)
WHERE idUsuario = {IdUsuario}
  AND idSubModulo = {IdSubmodulo}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<PermisoSubModulo>>(jsonReal);
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

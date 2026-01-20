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
    public class ControladorPermisoModulo
    {
        private const string SP_CRUD = "dbo.CRUD_PermisoModulo";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // =====================================================
        // 1 registro -> false, true
        // =====================================================
        public static async Task<PermisoModulo> consultarIdModuloIdusuario(int IdUsuario, int IdModulo)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM PermisoModulo WITH (NOLOCK)
WHERE idUsuario = {IdUsuario}
  AND idModulo = {IdModulo}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<PermisoModulo>(respuesta);
                if (jsonReal != null)
                {
                    return jsonReal;
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

        // =====================================================
        // CRUD -> false, true
        // Boton: 0=INSERT | 2=DELETE
        // =====================================================
        public static async Task<RespuestaCRUD> CrearEliminarPermisomodulo(PermisoModulo objPermiso, int Boton)
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
        public static async Task<List<PermisoModulo>> filtroIdUsuario(int IdUsuario)
        {
            try
            {
                var query = $@"
SELECT *
FROM PermisoModulo WITH (NOLOCK)
WHERE idUsuario = {IdUsuario}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                return JsonConvert.DeserializeObject<List<PermisoModulo>>(jsonReal);
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
        public static async Task<List<PermisoModulo>> consultarIdUsuario(int IdUsuario)
        {
            try
            {
                var query = $@"
SELECT *
FROM PermisoModulo WITH (NOLOCK)
WHERE idUsuario = {IdUsuario}
ORDER BY id DESC;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true); // LISTA
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                return JsonConvert.DeserializeObject<List<PermisoModulo>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

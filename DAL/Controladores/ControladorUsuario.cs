using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorUsuario
    {
        // ============================
        // CRUD (INSERT/UPDATE/DELETE)
        // Boton: 0=INSERT, 1=UPDATE, 2=DELETE
        // ============================
        public static async Task<RespuestaCRUD> GuardarEditarEliminar(Usuario objUsuario, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objUsuario);
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

        // Método base con tu patrón: Crud(string json, int funcion)
        public static async Task<RespuestaCRUD> Crud(string json, int funcion)
        {
            try
            {
                json = EscapeJsonForSql(json);

                var query = $"EXEC dbo.CRUD_Usuario N'{json}', {funcion}";
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

        // ============================
        // LISTA COMPLETA (VIEW v_Usuario)
        // ============================
        public static async Task<List<v_Usuario>> listaCompleta()
        {
            try
            {
                var query = "SELECT * FROM v_Usuario";
                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                return JsonConvert.DeserializeObject<List<v_Usuario>>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ============================
        // CONSULTA POR CUENTA Y CLAVE
        // ============================
        public static async Task<Usuario> ConsultaUsuarioYClave(string p_usuario, string p_clave)
        {
            try
            {
                // Escapar comillas simples
                p_usuario = (p_usuario ?? "").Replace("'", "''");
                p_clave = (p_clave ?? "").Replace("'", "''");

                var query = $@"
SELECT TOP 1 *
FROM Usuario
WHERE cuentaUsuario = '{p_usuario}'
  AND claveUsuario  = '{p_clave}'";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                // Normalmente viene como JSON de tabla -> lista
                var lista = JsonConvert.DeserializeObject<List<Usuario>>(resp);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ============================
        // CONSULTAR USUARIO POR ID
        // ============================
        public static async Task<Usuario> ConsultaUsuarioXId(int p_isUsuario)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM Usuario WHERE id = {p_isUsuario}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                var lista = JsonConvert.DeserializeObject<List<Usuario>>(resp);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // ============================
        // LISTA COMPLETA (TABLA Usuario)
        // ============================
        public static async Task<List<Usuario>> ConsultaListaCompletaUsuario()
        {
            try
            {
                var query = "SELECT * FROM Usuario";
                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                return JsonConvert.DeserializeObject<List<Usuario>>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ============================
        // FILTRO POR CUENTA (LIKE)
        // ============================
        public static async Task<List<Usuario>> FiltroX_Usuario(string Usuario)
        {
            try
            {
                Usuario = (Usuario ?? "").Replace("'", "''");

                var query = $"SELECT * FROM Usuario WHERE cuentaUsuario LIKE '%{Usuario}%'";
                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                return JsonConvert.DeserializeObject<List<Usuario>>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ============================
        // Escape JSON para SQL
        // ============================
        private static string EscapeJsonForSql(string json)
        {
            return string.IsNullOrEmpty(json) ? "" : json.Replace("'", "''");
        }
    }
}

using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorTipoMedida
    {
        // ============================
        // CRUD (INSERT/UPDATE/DELETE)
        // funcion: 0=INSERT, 1=UPDATE, 2=DELETE
        // ============================
        public static async Task<RespuestaCRUD> Crud(string json, int funcion)
        {
            try
            {
                // Escapar comillas simples para SQL
                json = EscapeJsonForSql(json);

                var query = $"EXEC dbo.CRUD_TipoMedida N'{json}', {funcion}";
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

        // Helper: serializa el objeto y llama Crud(json, funcion)
        public static async Task<RespuestaCRUD> CrearEditarEliminarTipoMedida(TipoMedida objTipo, int Boto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objTipo);
                return await Crud(json, Boto);
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

        // ============================
        // LISTA COMPLETA (VIEW)
        // ============================
        public static async Task<List<V_TipoMedida>> ListaCompleta()
        {
            try
            {
                var query = "SELECT * FROM V_TipoMedida";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);
                if (respuesta == null) return new List<V_TipoMedida>();
                return JsonConvert.DeserializeObject<List<V_TipoMedida>>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ============================
        // CONSULTAR POR ID (TABLA)
        // ============================
        public static async Task<DAL.Controladores.TipoMedida> ConsultarID(int IdTipo)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM TipoMedida WHERE id = {IdTipo}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);

                // Si ConsultaSQLServer retorna JSON de lista/tabla, lo más seguro es deserializar a lista y tomar 1
                var lista = JsonConvert.DeserializeObject<List<TipoMedida>>(respuesta);
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
        // Escape para JSON embebido en SQL
        // ============================
        private static string EscapeJsonForSql(string json)
        {
            return string.IsNullOrEmpty(json) ? "" : json.Replace("'", "''");
        }
    }


    // Ajusta estos modelos a los tuyos (normalmente ya existen en DAL.Modelo)
    public class TipoMedida
    {
        public int id { get; set; }
        public string nombreTipoMedida { get; set; }
        public string letraTipoMedida { get; set; }
    }

    public class V_TipoMedida
    {
        public int id { get; set; }
        public string nombreTipoMedida { get; set; }
        public string letraTipoMedida { get; set; }
    }
}

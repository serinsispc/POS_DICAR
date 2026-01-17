using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorTipoMerma
    {
        // =====================================================
        // CRUD -> llama SP dbo.CRUD_TipoMerma (JSON + funcion)
        // funcion/Boton: 0=INSERT, 1=UPDATE, 2=DELETE
        // =====================================================
        public static async Task<RespuestaCRUD> Crud(TipoMerma tipoMerma, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(tipoMerma);
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

        // Método base que tu ya vienes usando: Crud(string json, int funcion)
        public static async Task<RespuestaCRUD> Crud(string json, int funcion)
        {
            try
            {
                json = EscapeJsonForSql(json);

                var query = $"EXEC dbo.CRUD_TipoMerma N'{json}', {funcion}";
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
        // LISTA COMPLETA (VIEW)
        // =====================================================
        public static async Task<List<V_TipoMerma>> ListaCompleta()
        {
            try
            {
                var query = "SELECT * FROM V_TipoMerma";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);

                return JsonConvert.DeserializeObject<List<V_TipoMerma>>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // =====================================================
        // CONSULTAR POR ID (TABLA)
        // =====================================================
        public static async Task<TipoMerma> Consultar_id(int IdTipoMerma)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM TipoMerma WHERE id = {IdTipoMerma}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);

                // ConsultaSQLServer suele devolver JSON de tabla -> lista
                var lista = JsonConvert.DeserializeObject<List<TipoMerma>>(respuesta);
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
        // Escape para JSON embebido en SQL
        // =====================================================
        private static string EscapeJsonForSql(string json)
        {
            return string.IsNullOrEmpty(json) ? "" : json.Replace("'", "''");
        }
    }

}

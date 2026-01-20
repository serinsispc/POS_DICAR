using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores.OrdenServicio
{
    public class controladorTipoServicio
    {
        // =====================================================
        // CRUD -> SP dbo.CRUD_TipoServicio (JSON + funcion)
        // funcion/Boton: 0=INSERT, 1=UPDATE, 2=DELETE
        // =====================================================
        public static async Task<RespuestaCRUD> CrearEditarEliminarArticulo(TipoServicio objServicio, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objServicio);
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

        // Método base estilo tu patrón: Crud(string json, int funcion)
        public static async Task<RespuestaCRUD> Crud(string json, int funcion)
        {
            try
            {
                json = EscapeJsonForSql(json);

                var query = $"EXEC dbo.CRUD_TipoServicio N'{json}', {funcion}";
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
        // LISTA COMPLETA (tabla TipoServicio) ordenada por nombre
        // =====================================================
        public static async Task<List<TipoServicio>> ListaCompleta()
        {
            try
            {
                var query = "SELECT * FROM TipoServicio ORDER BY nombreTipoServicio";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, true, true);

                return JsonConvert.DeserializeObject<List<TipoServicio>>(respuesta);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // =====================================================
        // CONSULTAR POR ID (tabla TipoServicio)
        // =====================================================
        public static async Task<TipoServicio> consultarID(int IDServicio)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM TipoServicio WHERE id = {IDServicio}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);

                // Normalmente devuelve JSON de tabla -> lista
                var lista = JsonConvert.DeserializeObject<List<TipoServicio>>(respuesta);
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

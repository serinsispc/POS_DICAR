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
    public class controladorDetalleTraslado
    {
        private const string SP_CRUD = "dbo.CRUD_DetalleTraslado";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // ==========================
        // CRUD por JSON (0/1/2)
        // ==========================
        public static async Task<RespuestaCRUD> Crud(string json, int funcion)
        {
            try
            {
                json = EscapeJsonForSql(json);
                var query = $"EXEC {SP_CRUD} N'{json}', {funcion}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(respuesta);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new RespuestaCRUD() { estado = false, idAfectado = 0, mensaje = mensaje };
            }
        }

        // ==========================
        // Consultar por ID (tabla)
        // ==========================
        public static async Task<DetalleTraslado> consultar_IdDetalle(int IdDetalle)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM DetalleTraslado WITH (NOLOCK)
WHERE id = {IdDetalle};";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                var lista = JsonConvert.DeserializeObject<List<DetalleTraslado>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // ==========================
        // Crear / Editar / Eliminar (SP JSON)
        // ==========================
        public static async Task<RespuestaCRUD> CrearEditarEliminar_DetalleTraslado(DetalleTraslado objDetalle, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objDetalle);
                return await Crud(json, Boton);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new RespuestaCRUD() { estado = false, idAfectado = 0, mensaje = mensaje };
            }
        }

        // ==========================
        // Filtrar por Guid (vista)
        // ==========================
        public static async Task<List<V_DetalleTraslado>> Filtrar_Guid(string GuidTex)
        {
            try
            {
                var guidEsc = (GuidTex ?? string.Empty).Replace("'", "''");

                var query = $@"
SELECT *
FROM V_DetalleTraslado WITH (NOLOCK)
WHERE v_guidDetalleTraslado = '{guidEsc}';";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                return JsonConvert.DeserializeObject<List<V_DetalleTraslado>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

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
    public class controladorDetalleOrdenFabrica
    {
        private const string SP_CRUD = "dbo.CRUD_DetalleOrdenFabrica";

        // ==========================
        // Util: escapar JSON para SQL
        // ==========================
        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // ==========================
        // CRUD (0=Insert,1=Update,2=Delete)
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
        // Crear / Editar / Eliminar
        // ==========================
        public static async Task<RespuestaCRUD> CrearEditarEliminarDetalleOrdenFabrica(DetalleOrdenFabrica objDetalle, int Boton)
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
        // Filtro por idOrdenDetalle
        // ==========================
        public static async Task<List<DetalleOrdenFabrica>> Filtro_IDOrden(int IdOrden)
        {
            try
            {
                var query = $"SELECT * FROM DetalleOrdenFabrica WITH (NOLOCK) WHERE idOrdenDetalle = {IdOrden}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);

                // Tu API suele devolver JSON serializado como string; por eso doble deserialize
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<DetalleOrdenFabrica>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ==========================
        // Suma Total costoTotalInsumoOrden
        // ==========================
        public static async Task<decimal> SumaTotalDetalleINsumo(int IdOrden)
        {
            try
            {
                var query = $@"
SELECT 
    ISNULL(SUM(CAST(costoTotalInsumoOrden AS DECIMAL(18,2))), 0) AS total
FROM DetalleOrdenFabrica WITH (NOLOCK)
WHERE idOrdenDetalle = {IdOrden};";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);

                // jsonReal puede venir como: [{"total":12345.00}]
                var lista = JsonConvert.DeserializeObject<List<dynamic>>(jsonReal);
                if (lista == null || lista.Count == 0) return 0;

                decimal total = Convert.ToDecimal(lista[0].total);
                return total;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }

        // ==========================
        // Consultar por id
        // ==========================
        public static async Task<DetalleOrdenFabrica> consultarIdDetalleOrden(int IdDetalle)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM DetalleOrdenFabrica WITH (NOLOCK) WHERE id = {IdDetalle}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);

                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                var lista = JsonConvert.DeserializeObject<List<DetalleOrdenFabrica>>(jsonReal);

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

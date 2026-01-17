using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores.Tienda
{
    public class ControladorBodega
    {
        private const string SP_CRUD = "dbo.CRUD_Bodega";

        private static string EscapeJsonForSql(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }

        // ==========================
        // CRUD por JSON (0=I,1=U,2=D)
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
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new RespuestaCRUD
                {
                    estado = false,
                    idAfectado = 0,
                    mensaje = ex.Message
                };
            }
        }

        // ==========================
        // Crear / Editar / Eliminar
        // ==========================
        public static async Task<RespuestaCRUD> Crear_Editar_Eliminar_DivisionInventario(Bodega objDivisionInventario, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objDivisionInventario);
                return await Crud(json, Boton); // 0 insert, 1 update, 2 delete
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new RespuestaCRUD
                {
                    estado = false,
                    idAfectado = 0,
                    mensaje = ex.Message
                };
            }
        }

        // ==========================
        // Lista completa
        // ==========================
        public static async Task<List<Bodega>> listaCompleta()
        {
            try
            {
                var query = "SELECT * FROM Bodega WITH (NOLOCK) ORDER BY nombreBodega";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);

                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<Bodega>>(jsonReal);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        // ==========================
        // Consultar por ID
        // ==========================
        public static async Task<Bodega> ConsultarX_IdVidision(int IdDivision)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM Bodega WITH (NOLOCK) WHERE id = {IdDivision}";
                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);

                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                var lista = JsonConvert.DeserializeObject<List<Bodega>>(jsonReal);

                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ==========================
        // Filtro por nombre (LIKE)
        // ==========================
        public static async Task<List<Bodega>> FiltroX_Division(string Division)
        {
            try
            {
                var divEsc = (Division ?? string.Empty).Replace("'", "''");

                var query = $@"
SELECT *
FROM Bodega WITH (NOLOCK)
WHERE nombreBodega LIKE '%{divEsc}%'
ORDER BY nombreBodega;";

                var respuesta = await Conection_SQL.ConsultaSQLServer(query, false, true);

                var jsonReal = JsonConvert.DeserializeObject<string>(respuesta);
                return JsonConvert.DeserializeObject<List<Bodega>>(jsonReal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

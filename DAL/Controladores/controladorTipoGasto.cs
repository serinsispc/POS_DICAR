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
    public class controladorTipoGasto
    {
        // 0=INSERT, 1=UPDATE, 2=DELETE
        public static async Task<RespuestaCRUD> Crud(TipoGasto tipoGasto, int funcion)
        {
            try
            {
                var json = JsonConvert.SerializeObject(tipoGasto);
                json = EscapeJsonForSql(json);

                var query = $"EXEC dbo.CRUD_TipoGasto N'{json}', {funcion}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new RespuestaCRUD()
                {
                    estado = false,
                    mensaje = error
                };
            }
        }

        public static async Task<List<V_TipoGasto>> ListaCompleta()
        {
            try
            {
                var query = "SELECT * FROM V_TipoGasto";
                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                return JsonConvert.DeserializeObject<List<V_TipoGasto>>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<TipoGasto> Consultar_id(int idTipoGasto)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM TipoGasto WHERE id = {idTipoGasto}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                return JsonConvert.DeserializeObject<TipoGasto>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        private static string EscapeJsonForSql(string json)
        {
            if (string.IsNullOrEmpty(json)) return json;
            return json.Replace("'", "''");
        }
    }
}

using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores.Administrador
{
    public class controladorSedeAsignada
    {
        /// <summary>
        /// 0=INSERT, 1=UPDATE, 2=DELETE
        /// </summary>
        public static async Task<RespuestaCRUD> Crud(SedesAsignadas objSedeAsignada, int funcion)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objSedeAsignada);
                json = json.Replace("'", "''"); // EscapeJsonForSql básico (tu patrón)

                var query = $"EXEC dbo.CRUD_SedesAsignadas N'{json}', {funcion}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new RespuestaCRUD()
                {
                    estado = false,
                    mensaje = error
                };
            }
        }

        public static async Task<List<V_SedesAsignadas>> listaCompleta()
        {
            try
            {
                var query = "SELECT * FROM V_SedesAsignadas";
                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true); // LISTA = true
                return JsonConvert.DeserializeObject<List<V_SedesAsignadas>>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<SedesAsignadas> consultarUsuarioSede(int Idusuario, int IdSede)
        {
            try
            {
                var query =
                    $"SELECT TOP 1 * FROM SedesAsignadas " +
                    $"WHERE idusuarioAsignado = {Idusuario} AND idSedeAsignada = {IdSede}";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true); // single = false
                return JsonConvert.DeserializeObject<SedesAsignadas>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

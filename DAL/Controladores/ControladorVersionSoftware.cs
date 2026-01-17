using DAL.Controladores.OrdenServicio;
using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores.Version_Software
{
    public class ControladorVersionSoftware
    {
        public static async Task<VersionSoftware> ConsultarVersionSoftware(int VersionActual)
        {
            try
            {
                var query = $"select top 1  *from VersionSoftware where id_versionsoftware={VersionActual}";
                var resultado = await Conection_SQL.ConsultaSQLServer(query,false,true);
                return JsonConvert.DeserializeObject<VersionSoftware>(resultado);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static async Task<int> UltimaVersion()
        {
            try
            {
                var query = $"select MAX(id_versionsoftware) from VersionSoftware";
                var resultado = await Conection_SQL.ConsultaSQLServer(query,false,true);
                var obj = JsonConvert.DeserializeObject<dynamic>(resultado);
                int numero = obj.Column1;
                return numero;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // Escape de comillas simples para SQL
        private static string EscapeJsonForSql(string json)
            => (json ?? string.Empty).Replace("'", "''");

        // =========================
        // CRUD (INSERT/UPDATE/DELETE)
        // Boton: 0=INSERT, 1=UPDATE, 2=DELETE
        // =========================
        public static async Task<bool> Crear_Editar_Eliminar_Version(VersionSoftware objVersion, int boton)
        {
            try
            {
                // Serializa el objeto a JSON
                var json = JsonConvert.SerializeObject(objVersion);
                json = EscapeJsonForSql(json);

                // Ejecuta SP (no-lista)
                var query = $"EXEC dbo.CRUD_VersionSoftware N'{json}', {boton}";
                var respJson = await Conection_SQL.ConsultaSQLServer(query, false, true);

                // El SP normalmente retorna algo tipo [{"estado":true,"idAfectado":1,"mensaje":"..."}]
                var respList = JsonConvert.DeserializeObject<List<RespuestaCRUD>>(respJson);
                var resp = (respList != null && respList.Count > 0) ? respList[0] : null;

                return resp.estado;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // =========================
        // LISTA COMPLETA (SELECT lista)
        // =========================
        public static async Task<List<VersionSoftware>> listaCompleta()
        {
            try
            {
                string query = "SELECT * FROM dbo.VersionSoftware;";
                var json = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<VersionSoftware>>(json);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

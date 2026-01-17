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

namespace DAL.Controladores.Administrador
{
    public class ControladorAutorizacionPC
    {
        public static async Task<bool> Crear_Editar_Eliminar_Equipo(AutorizacionPC objAE, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objAE);

                // Si usas tu ajustador, déjalo como siempre:
                // json = AjustarJoson.Ajustar(json);

                // Escapar comillas simples para SQL
                json = json.Replace("'", "''");

                var query = $"EXEC dbo.CRUD_AutorizacionPC N'{json}', {Boton}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true); // respuesta unica

                if (!string.IsNullOrEmpty(resp))
                {
                    var r = JsonConvert.DeserializeObject<RespuestaCRUD>(resp);

                    // Si estado es int: return r != null && r.estado == 1;
                    return r != null && r.estado;
                }

                return false;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static async Task<List<AutorizacionPC>> listaCompleta()
        {
            try
            {
                var query = @"select * from AutorizacionPC";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true); // true = lista

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<List<AutorizacionPC>>(resp);
                }

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                // MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<AutorizacionPC> ConsultarXSerial(string Serial, string Manufacture, string Producto, string Vercion, int Estado)
        {
            try
            {
                var query = $"select top 1 *from AutorizacionPC where serialnumber_pc='{Serial}' and Manufacturer_pc='{Manufacture}' and product_pc='{Producto}' and Version_pc='{Vercion}' and estado_equipo='{Estado}'";
                var resp=await Conection_SQL.ConsultaSQLServer(query, false, true);
                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<AutorizacionPC>(resp);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
    }
}

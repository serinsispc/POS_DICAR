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
    public class ControladorAdminControl
    {
        public static async Task<AdminControl> Consultar()
        {
            try
            {
                var query = $"select top 1 *from AdminControl where tipo_admincontrol<>0";
                var resp = await Conection_SQL.ConsultaSQLServer(query,false,true);
                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<AdminControl>(resp);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión." , "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public static async Task<List<AdminControl>> listaCompleta()
        {
            try
            {
                var query = @"select * from AdminControl";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<List<AdminControl>>(resp);
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

        public static async Task<AdminControl> Consultar2()
        {
            try
            {
                var query = @"
            select top 1 *
            from AdminControl
            where id_admincontrol > 1
              and tipo_admincontrol <> 0
        ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<AdminControl>(resp);
                }

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<AdminControl> ConsularXId(int ID)
        {
            try
            {
                var query = $@"
            select top 1 *
            from AdminControl
            where id_admincontrol > {ID}
        ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<AdminControl>(resp);
                }

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<bool> Crear_Editar_Elimiar_Mensaje(AdminControl Obja, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(Obja);

                // Si usas tu ajustador, déjalo como siempre:
                // json = AjustarJoson.Ajustar(json);

                json = json.Replace("'", "''");

                var query = $"EXEC dbo.CRUD_AdminControl N'{json}', {Boton}";
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

    }
}

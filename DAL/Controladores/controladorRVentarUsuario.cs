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
    public class controladorRVentarUsuario
    {
        public static async Task<R_VentaUsuario> Consultar_IdUsuario_IdVenta(int IdUser, int IdVenta, int IdEstado)
        {
            try
            {
                var query = $@"
select top 1 *
from R_VentaUsuario
where idUsuario = {IdUser}
  and idVenta = {IdVenta}
  and estado = {IdEstado};";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                if (resp == null) return null;

                return JsonConvert.DeserializeObject<R_VentaUsuario>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<RespuestaCRUD> Crud(string json, int funcion)
        {
            try
            {
                json = json.Replace("'", "''"); // EscapeJsonForSql (tu patrón)
                var query = $"EXEC dbo.CRUD_R_VentaUsuario N'{json}', {funcion}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new RespuestaCRUD()
                {
                    estado = false,
                    mensaje = mensaje
                };
            }
        }

        public static async Task<RespuestaCRUD> CrearEditarEliminarR_VentaUsuario(R_VentaUsuario objR, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objR);
                // si tú tienes AjustarJoson.Ajustar(json) úsalo aquí:
                // json = AjustarJoson.Ajustar(json);

                return await Crud(json, Boton);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new RespuestaCRUD()
                {
                    estado = false,
                    mensaje = mensaje
                };
            }
        }

        public static async Task<R_VentaUsuario> Consultar_IdUsuario_Estado(int IdUser, int estado)
        {
            try
            {
                var query = $@"
select top 1 *
from R_VentaUsuario
where idUsuario = {IdUser}
  and estado = {estado};";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<R_VentaUsuario>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<List<R_VentaUsuario>> Lista(int IdUser, int estado)
        {
            try
            {
                var query = $@"
select *
from R_VentaUsuario
where idUsuario = {IdUser}
  and estado = {estado};";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<R_VentaUsuario>>(resp);
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

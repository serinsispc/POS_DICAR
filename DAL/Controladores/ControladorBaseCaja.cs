using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class ControladorBaseCaja
    {
        public static async Task<bool> CrearEditarEliminarBaseCaja(BaseCaja objBase, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objBase);

                // Si usas tu ajustador, déjalo como siempre:
                // json = AjustarJoson.Ajustar(json);

                // Escapar comillas simples para SQL
                json = json.Replace("'", "''");

                var query = $"EXEC dbo.CRUD_BaseCaja N'{json}', {Boton}";
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
                return false;
            }
        }
        public static async Task<BaseCaja> consultaBaseActiva(string Estado, int IdUsuario, int IdSede)
        {
            try
            {
                var query = $@"
            select top 1 *
            from BaseCaja
            where estadoBase = '{Estado}'
              and idUsuarioApertura = {IdUsuario}
              and idSedeBAse = {IdSede}
        ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<BaseCaja>(resp);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                // MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<decimal> BaseActiva()
        {
            try
            {
                var query = @"
            select ISNULL(SUM(valorBase), 0) as total
            from BaseCaja
            where estadoBase = 'ACTIVA'
        ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    var data = JsonConvert.DeserializeObject<List<dynamic>>(resp);
                    return Convert.ToDecimal(data[0].total);
                }

                return 0;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                // MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static async Task<BaseCaja> consultarID(int IDBase)
        {
            try
            {
                var query = $@"
            select top 1 *
            from BaseCaja
            where id = {IDBase}
        ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<BaseCaja>(resp);
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

        public static async Task<BaseCaja> HallarIdBaseActiva(int IdSede, int Idusuario)
        {
            try
            {
                var query = $@"
            select top 1 *
            from BaseCaja
            where estadoBase = 'ACTIVA'
              and idUsuarioApertura = {Idusuario}
              and idSedeBAse = {IdSede}
        ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<BaseCaja>(resp);
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

    }
}

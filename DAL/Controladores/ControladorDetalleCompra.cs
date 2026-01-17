using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorDetalleCompra
    {
        public static DataTable ConsultarTotales(int IdCompra)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select "+
"isnull(SUM(cantidad * precioUnitario),0) as subTotal," +
"isnull(sum(cantidad * valorDescuento),0) as totalDescuento," +
"isnull(SUM(cantidad * valorIva),0) as totalIVA " +
"from DetalleCompra "+
"where idCompra = "+IdCompra;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                ConexionSQL.CerrarConexion();
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                return null;
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<bool> GuardarEditarEliminarCompra(DetalleCompra objCompra, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objCompra);

                // Si usas tu ajustador, déjalo como siempre:
                // json = AjustarJoson.Ajustar(json);

                json = json.Replace("'", "''");

                var query = $"EXEC dbo.CRUD_DetalleCompra N'{json}', {Boton}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

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

        public static async Task<bool> EliminarLista(int IdCompra)
        {
            try
            {
                var query = $@"
            DELETE FROM DetalleCompra
            WHERE idCompra = {IdCompra}
        ";

                // No necesitamos resultado, solo ejecutar
                await Conection_SQL.ConsultaSQLServer(query, false, true);

                return true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
        public static async Task<List<DetalleVenta>> ConsultaListaCompleta()
        {
            try
            {
                var query = @"select * from DetalleVenta";
                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<DetalleVenta>>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<List<DetalleCompra>> Lista_XidCompra(int IdCompra)
        {
            try
            {
                var query = $@"select * from DetalleCompra where idCompra = {IdCompra}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<DetalleCompra>>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<DetalleCompra> ConsultaXidCompra(int id)
        {
            try
            {
                var query = $@"select top 1 * from DetalleCompra where id = {id}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<DetalleCompra>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<decimal> SumaSubTotalCompra(int IdCompra)
        {
            try
            {
                var query = $@"
                select ISNULL(SUM(totalDetalle), 0) as total
                from DetalleCompra
                where idCompra = {IdCompra}
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
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static async Task<int> SumaSubTotalDescuento(int IdCompra)
        {
            try
            {
                var query = $@"
                select ISNULL(SUM(valorDescuento), 0) as total
                from DetalleCompra
                where idCompra = {IdCompra}
            ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    var data = JsonConvert.DeserializeObject<List<dynamic>>(resp);
                    return Convert.ToInt32(data[0].total);
                }

                return 0;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static async Task<int> SumaSubTotalIVA(int IdCompra)
        {
            try
            {
                var query = $@"
                select ISNULL(SUM(valorIva), 0) as total
                from DetalleCompra
                where idCompra = {IdCompra}
            ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    var data = JsonConvert.DeserializeObject<List<dynamic>>(resp);
                    return Convert.ToInt32(data[0].total);
                }

                return 0;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static async Task<List<V_DetalleCompra>> listaXIdCompra(int IdCompa)
        {
            try
            {
                var query = $@"select * from V_DetalleCompra where idCompra = {IdCompa}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<V_DetalleCompra>>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<DetalleCompra> ConsultarIdCompra_idInventario(int IdCompra, int IdInventario)
        {
            try
            {
                var query = $@"
                select top 1 *
                from DetalleCompra
                where idCompra = {IdCompra}
                  and idInventario = {IdInventario}
            ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<DetalleCompra>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<decimal> SumaCompras(int IdInventario, int IdSede)
        {
            try
            {
                var query = $@"
                select ISNULL(SUM(cantidad), 0) as total
                from V_DetalleCompra
                where idSede = {IdSede}
                  and idInventario = {IdInventario}
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
                return 0;
            }
        }

        public static async Task<DetalleCompra> ConsultaX_idDetalle(int id)
        {
            try
            {
                var query = $@"select top 1 * from DetalleCompra where id = {id}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<DetalleCompra>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<List<V_DetalleCompra>> Filtrar_IdCompra(int IdCompra)
        {
            try
            {
                var query = $@"select * from V_DetalleCompra where idCompra = {IdCompra}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<V_DetalleCompra>>(resp);

                return null;
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

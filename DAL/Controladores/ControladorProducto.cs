using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorProducto
    {
       
        private const string SP_CRUD = "dbo.CRUD_Producto";

        private static string EscapeJsonForSql(string json)
            => (json ?? string.Empty).Replace("'", "''");

        // =========================
        // CRUD (0=INSERT,1=UPDATE,2=DELETE) -> false,true
        // Retorna RespuestaCRUD (estado, idAfectado, mensaje)
        // =========================
        public static async Task<RespuestaCRUD> GuardarEditarEliminarProducto(Producto objProducto, int Boton)
        {
            try
            {
                var json = EscapeJsonForSql(JsonConvert.SerializeObject(objProducto));
                var query = $"EXEC {SP_CRUD} N'{json}', {Boton}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
            }
            catch (Exception ex)
            {
                return new RespuestaCRUD
                {
                    estado = false,
                    idAfectado = 0,
                    mensaje = ex.Message
                };
            }
        }

        // =========================
        // 1 registro -> false,true
        // =========================
        public static async Task<Producto> ConsultarGuid(Guid guidPro)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM Producto WITH (NOLOCK)
WHERE guidProducto = '{guidPro}';";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                var lista = JsonConvert.DeserializeObject<List<Producto>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch
            {
                return null;
            }
        }

        // =========================
        // LISTAS -> true,true
        // =========================
        public static async Task<List<V_Producto>> FiltrarCodigo(string codigo)
        {
            try
            {
                var c = (codigo ?? string.Empty).Replace("'", "''");
                var query = $@"
SELECT *
FROM V_Producto WITH (NOLOCK)
WHERE codigoProducto = N'{c}';";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                return JsonConvert.DeserializeObject<List<V_Producto>>(jsonReal);
            }
            catch
            {
                return null;
            }
        }

        public static async Task<List<V_Producto>> FiltralDescripcion(string descripcion)
        {
            try
            {
                var d = (descripcion ?? string.Empty).Replace("'", "''");
                var query = $@"
SELECT *
FROM V_Producto WITH (NOLOCK)
WHERE descripcionProducto LIKE N'%{d}%';";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                return JsonConvert.DeserializeObject<List<V_Producto>>(jsonReal);
            }
            catch
            {
                return null;
            }
        }

        public static async Task<List<V_Producto>> FiltralCategoria(int IdCategoria)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_Producto WITH (NOLOCK)
WHERE idCategoria = {IdCategoria};";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                return JsonConvert.DeserializeObject<List<V_Producto>>(jsonReal);
            }
            catch
            {
                return null;
            }
        }

        public static async Task<List<V_Producto>> listaCompleta(int elimi)
        {
            try
            {
                var query = $@"
SELECT *
FROM V_Producto WITH (NOLOCK)
WHERE eliminado = {elimi}
ORDER BY id DESC;";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                return JsonConvert.DeserializeObject<List<V_Producto>>(jsonReal);
            }
            catch
            {
                return null;
            }
        }

        public static async Task<List<V_ListaPrecios>> ListaPrecios()
        {
            try
            {
                var query = @"
SELECT *
FROM V_ListaPrecios WITH (NOLOCK)
ORDER BY descripcionProducto;";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                return JsonConvert.DeserializeObject<List<V_ListaPrecios>>(jsonReal);
            }
            catch
            {
                return null;
            }
        }

        public static async Task<List<V_CostoInventario>> ListaCostoInventario()
        {
            try
            {
                var query = @"
SELECT *
FROM V_CostoInventario WITH (NOLOCK)
ORDER BY descripcionProducto;";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                return JsonConvert.DeserializeObject<List<V_CostoInventario>>(jsonReal);
            }
            catch
            {
                return null;
            }
        }

        // 1 valor -> false,true
        public static async Task<decimal> TotalListaCostoInventario()
        {
            try
            {
                var query = "SELECT ISNULL(SUM(costoInventario),0) AS total FROM V_CostoInventario WITH (NOLOCK);";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                var dt = JsonConvert.DeserializeObject<List<dynamic>>(jsonReal);

                if (dt != null && dt.Count > 0 && dt[0].total != null)
                    return Convert.ToDecimal(dt[0].total);

                return 0;
            }
            catch
            {
                return 0;
            }
        }

        // DataTable (se deja así como lo tenías)
        public static DataTable listaCompleta_2()
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand command = ConexionSQL.connection.CreateCommand();
                command.CommandText = "select *from Producto";
                DataTable dt = new DataTable();
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                sqlData.Fill(dt);
                ConexionSQL.CerrarConexion();
                return (dt.Rows.Count > 0) ? dt : null;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<List<V_Producto>> ListaAgotados()
        {
            try
            {
                var query = "SELECT * FROM V_Producto WITH (NOLOCK);";
                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                return JsonConvert.DeserializeObject<List<V_Producto>>(jsonReal);
            }
            catch
            {
                return null;
            }
        }

        public static async Task<Producto> consultarIdProducto(int IdProducto)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM Producto WITH (NOLOCK)
WHERE id = {IdProducto};";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                var lista = JsonConvert.DeserializeObject<List<Producto>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<int> UltimoID()
        {
            try
            {
                var query = "SELECT ISNULL(MAX(id),0) AS maxId FROM Producto WITH (NOLOCK);";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                var dt = JsonConvert.DeserializeObject<List<dynamic>>(jsonReal);

                if (dt != null && dt.Count > 0 && dt[0].maxId != null)
                    return Convert.ToInt32(dt[0].maxId);

                return 0;
            }
            catch
            {
                return 0;
            }
        }

        // =========================
        // v_productoVenta (LISTAS) -> true,true
        // =========================
        public static async Task<List<v_productoVenta>> FiltroVentaProducto_codigo(string codigo, int IdSede, int elimi)
        {
            try
            {
                var c = (codigo ?? string.Empty).Replace("'", "''");
                var query = $@"
SELECT *
FROM v_productoVenta WITH (NOLOCK)
WHERE codigoProducto = N'{c}'
  AND idSede = {IdSede}
  AND eliminado = {elimi};";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                return JsonConvert.DeserializeObject<List<v_productoVenta>>(jsonReal);
            }
            catch
            {
                return null;
            }
        }

        public static async Task<List<v_productoVenta>> FiltroVentaProducto(string codigo, int IdListaPrecios, int IdSede)
        {
            try
            {
                var c = (codigo ?? string.Empty).Replace("'", "''");
                var query = $@"
SELECT *
FROM v_productoVenta WITH (NOLOCK)
WHERE idSede = {IdSede}
  AND codigoProducto = N'{c}'
  AND idListaPrecios = {IdListaPrecios};";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                return JsonConvert.DeserializeObject<List<v_productoVenta>>(jsonReal);
            }
            catch
            {
                return null;
            }
        }

        public static async Task<List<v_productoVenta>> FiltrarX_IdCategoria_IdSede_IdEstado(int IdCategoria, int IdSede, int IdEstado)
        {
            try
            {
                var query = $@"
SELECT *
FROM v_productoVenta WITH (NOLOCK)
WHERE idCategoria = {IdCategoria}
  AND idSede = {IdSede}
  AND idEstadoAI = {IdEstado};";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                return JsonConvert.DeserializeObject<List<v_productoVenta>>(jsonReal);
            }
            catch
            {
                return null;
            }
        }

        // OJO: corregí precedencia lógica con paréntesis
        public static async Task<List<v_productoVenta>> FiltrarX_Descripcion_IdSede_IdEstado(string descripcion, int IdSede, int IdEstado)
        {
            try
            {
                var d = (descripcion ?? string.Empty).Replace("'", "''");

                var query = $@"
SELECT *
FROM v_productoVenta WITH (NOLOCK)
WHERE (
        codigoProducto LIKE N'%{d}%'
        OR descripcionProducto LIKE N'%{d}%'
      )
  AND idSede = {IdSede}
  AND idEstadoAI = {IdEstado}
ORDER BY codigoProducto;";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                return JsonConvert.DeserializeObject<List<v_productoVenta>>(jsonReal);
            }
            catch
            {
                return null;
            }
        }

        public static async Task<List<v_productoVenta>> FiltrarX_IdSede_IdEstado(int IdSede, int IdEstado)
        {
            try
            {
                var query = $@"
SELECT *
FROM v_productoVenta WITH (NOLOCK)
WHERE idSede = {IdSede}
  AND idEstadoAI = {IdEstado}
ORDER BY codigoProducto;";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                return JsonConvert.DeserializeObject<List<v_productoVenta>>(resp);
            }
            catch
            {
                return null;
            }
        }

        public static async Task<List<v_productoVenta>> FiltrarX_IdSede(int IdSede, int elimi)
        {
            try
            {
                var query = $@"
SELECT *
FROM v_productoVenta WITH (NOLOCK)
WHERE idSede = {IdSede}
  AND eliminado = {elimi}
ORDER BY codigoProducto;";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                return JsonConvert.DeserializeObject<List<v_productoVenta>>(jsonReal);
            }
            catch
            {
                return null;
            }
        }

        // 1 registro -> false,true
        public static async Task<v_productoVenta> BuscarCodigo(int IdSede, int IdEstado, string codigo)
        {
            try
            {
                var c = (codigo ?? string.Empty).Replace("'", "''");

                var query = $@"
SELECT TOP 1 *
FROM v_productoVenta WITH (NOLOCK)
WHERE codigoProducto = N'{c}'
  AND idSede = {IdSede}
  AND idEstadoAI = {IdEstado}
ORDER BY id DESC;";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                var lista = JsonConvert.DeserializeObject<List<v_productoVenta>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<v_productoVenta> Consultar_IdInventario_IdSede(int IdInventario, int IdSede)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM v_productoVenta WITH (NOLOCK)
WHERE idInventario = {IdInventario}
  AND idSede = {IdSede};";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                var lista = JsonConvert.DeserializeObject<List<v_productoVenta>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<v_productoVenta> Consultar_Id(int idProducto_frm)
        {
            try
            {
                var query = $@"
SELECT TOP 1 *
FROM v_productoVenta WITH (NOLOCK)
WHERE id = {idProducto_frm};";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                var lista = JsonConvert.DeserializeObject<List<v_productoVenta>>(jsonReal);
                return (lista != null && lista.Count > 0) ? lista[0] : null;
            }
            catch
            {
                return null;
            }
        }

        // bool -> false,true
        public static async Task<bool> ConsultarCodigo(string codigo)
        {
            try
            {
                var c = (codigo ?? string.Empty).Replace("'", "''");

                var query = $@"
SELECT TOP 1 1 AS existe
FROM Producto WITH (NOLOCK)
WHERE codigoProducto = N'{c}';";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                var jsonReal = JsonConvert.DeserializeObject<string>(resp);
                var lista = JsonConvert.DeserializeObject<List<dynamic>>(jsonReal);

                return (lista != null && lista.Count > 0);
            }
            catch
            {
                return false;
            }
        }

        // DataTable (igual que original)
        public static DataTable Lista(int idCategoria_frm)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand command = ConexionSQL.connection.CreateCommand();
                command.CommandText = "select *from v_productoVenta where idCategoria=" + idCategoria_frm;
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
                ConexionSQL.CerrarConexion();
                return dataTable;
            }
            catch
            {
                return null;
            }
        }
    }
}

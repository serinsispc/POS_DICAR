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
    public class ControladorProveedor
    {
        // =========================
        // CRUD (0=INSERT,1=UPDATE,2=DELETE)
        // =========================
        public static async Task<RespuestaCRUD> Crud(Proveedor objProveedor, int funcion)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objProveedor);
                json = EscapeJsonForSql(json);

                var query = $"EXEC dbo.CRUD_Proveedor N'{json}', {funcion}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new RespuestaCRUD()
                {
                    estado = false,
                    mensaje = ex.Message
                };
            }
        }

        // Variante: si ya tienes el JSON listo
        public static async Task<RespuestaCRUD> Crud(string json, int funcion)
        {
            try
            {
                json = EscapeJsonForSql(json);
                var query = $"EXEC dbo.CRUD_Proveedor N'{json}', {funcion}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new RespuestaCRUD()
                {
                    estado = false,
                    mensaje = ex.Message
                };
            }
        }

        private static string EscapeJsonForSql(string json)
        {
            return string.IsNullOrEmpty(json) ? json : json.Replace("'", "''");
        }

        // =========================
        // LISTA COMPLETA (V_Proveedor)  --> LISTA = true
        // =========================
        public static async Task<List<SQL.Views.V_Proveedor>> ListaCompleta()
        {
            try
            {
                var query = "SELECT * FROM V_Proveedor";
                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<SQL.Views.V_Proveedor>>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // =========================
        // Consulta por Proveedor o NIT (tabla Proveedor)
        // =========================
        public static async Task<Proveedor> ConsultaXProveedor_Nit(string proveedor, string nit)
        {
            try
            {
                proveedor = (proveedor ?? "").Replace("'", "''");
                nit = (nit ?? "").Replace("'", "''");

                var query = $@"
SELECT TOP 1 *
FROM Proveedor
WHERE nombreProveedor = N'{proveedor}'
   OR documentoProveedor = N'{nit}'";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<Proveedor>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // =========================
        // Consultar por ID
        // =========================
        public static async Task<Proveedor> ConsultarX_IdProveedor(int idProveedor)
        {
            try
            {
                var query = $"SELECT TOP 1 * FROM Proveedor WHERE id = {idProveedor}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<Proveedor>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // =========================
        // Filtro por nombre (LISTA = true)
        // =========================
        public static async Task<List<Proveedor>> FiltroX_Proveedor(string proveedor)
        {
            try
            {
                proveedor = (proveedor ?? "").Replace("'", "''");

                var query = $@"
SELECT *
FROM Proveedor
WHERE nombreProveedor LIKE N'%{proveedor}%'
ORDER BY nombreProveedor";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                return JsonConvert.DeserializeObject<List<Proveedor>>(resp);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // =========================
        // Consultar por NIT
        // =========================
        public static async Task<Proveedor> ConsultarX_Nit(string nit)
        {
            try
            {
                nit = (nit ?? "").Replace("'", "''");

                var query = $@"SELECT TOP 1 * FROM Proveedor WHERE documentoProveedor = N'{nit}'";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);
                return JsonConvert.DeserializeObject<Proveedor>(resp);
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

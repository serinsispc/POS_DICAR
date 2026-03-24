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

namespace DAL.Controladores.Tienda
{
    public class ConotroladorCategoria
    {
        public static async Task<bool> Crear_Editar_Eliminar_Categoria(CategoriaProducto objCategoria, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objCategoria);

                // Si estás usando tu ajustador, déjalo como siempre:
                // json = AjustarJoson.Ajustar(json);

                // Escapar comillas simples para SQL
                json = json.Replace("'", "''");

                var query = $"EXEC dbo.CRUD_CategoriaProducto N'{json}', {Boton}";
                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true); // respuesta unica

                if (!string.IsNullOrEmpty(resp))
                {
                    var r = JsonConvert.DeserializeObject<RespuestaCRUD>(resp);

                    // Si en tu RespuestaCRUD "estado" es int, usa: r.estado == 1
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
        public static async Task<List<v_CategoriaProducto>> listaCompleta()
        {
            try
            {
                var query = @"select * from v_CategoriaProducto";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true); // true = lista
                if (resp == null) return new List<v_CategoriaProducto>();
                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<List<v_CategoriaProducto>>(resp);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<List<v_CategoriaProducto>> Lista()
        {
            try
            {
                var query = @"select * from v_CategoriaProducto";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true); // true = lista

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<List<v_CategoriaProducto>>(resp);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

    }
}

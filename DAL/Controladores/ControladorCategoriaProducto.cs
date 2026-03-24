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
    public class ControladorCategoriaProducto
    {
        public static async Task<bool> Crear_Editar_Eliminar_Categoria(CategoriaProducto objCategoria, int Boton)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objCategoria);

                // Si usas tu ajustador, déjalo como siempre:
                // json = AjustarJoson.Ajustar(json);

                json = json.Replace("'", "''");

                var query = $"EXEC dbo.CRUD_CategoriaProducto N'{json}', {Boton}";
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
                return false;
            }
        }

        public static async Task<List<CategoriaProducto>> ListaCompleta()
        {
            try
            {
                var query = @"
                    select *
                    from CategoriaProducto
                    order by nombreCategoria
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);
                if (resp == null) return new List<CategoriaProducto>();
                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<List<CategoriaProducto>>(resp);
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

        public static async Task<CategoriaProducto> ConsultarGuid(Guid guidCat)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from CategoriaProducto
                    where guidCategoria = '{guidCat}'
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<CategoriaProducto>(resp);
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

        public static async Task<List<CategoriaProducto>> FiltroX_Categoria(string Categoria)
        {
            try
            {
                // Escape simple para LIKE (comillas)
                var cat = (Categoria ?? "").Replace("'", "''");

                var query = $@"
                    select *
                    from CategoriaProducto
                    where nombreCategoria like '%{cat}%'
                    order by nombreCategoria
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<List<CategoriaProducto>>(resp);
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

        public static async Task<CategoriaProducto> ConsultarMayorA(int IDCategoria)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from CategoriaProducto
                    where id >= {IDCategoria}
                    order by id
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<CategoriaProducto>(resp);
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

        public static async Task<CategoriaProducto> ConsultarNombre(string nombre)
        {
            try
            {
                var nom = (nombre ?? "").Replace("'", "''");

                var query = $@"
                    select top 1 *
                    from CategoriaProducto
                    where nombreCategoria = '{nom}'
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<CategoriaProducto>(resp);
                }

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static async Task<CategoriaProducto> ConsulatarID(int Id)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from CategoriaProducto
                    where id = {Id}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                {
                    return JsonConvert.DeserializeObject<CategoriaProducto>(resp);
                }

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
using RunApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class ControladorSede
    {
        /// <summary>
        /// Controlador que trae la lista de nombre de empresas.
        /// </summary>
        public static async Task<List<Sede>> listaCompleta()
        {
            try
            {
                var query = @"select * from Sede";

                var resp = await Conection_SQL.ConsultaSQLServer(query, true, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<List<Sede>>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// controlador que se encarga de traer la informacion del parqueadero segun el id de empresa.
        /// </summary>
        public static async Task<Sede> ConsultaXIdEmpresa(int p_idEmpresa)
        {
            try
            {
                var query = $@"
                    select top 1 *
                    from Sede
                    where id = {p_idEmpresa}
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<Sede>(resp);

                return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// controlador que se encarga de crear, editar y elimonar la configuracion del parqueadero
        /// </summary>
        public static async Task<bool> CrearEditarEliminarConfiguracion(Sede objConfig, int Evento)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objConfig);

                // Si usas tu ajustador, déjalo como siempre:
                // json = AjustarJoson.Ajustar(json);

                json = json.Replace("'", "''");

                var query = $"EXEC dbo.CRUD_Sede N'{json}', {Evento}";
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

        public static async Task<Sede> datosCompletos()
        {
            try
            {
                var query = @"
                    select top 1 *
                    from Sede
                    where id = 1
                ";

                var resp = await Conection_SQL.ConsultaSQLServer(query, false, true);

                if (!string.IsNullOrEmpty(resp))
                    return JsonConvert.DeserializeObject<Sede>(resp);

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

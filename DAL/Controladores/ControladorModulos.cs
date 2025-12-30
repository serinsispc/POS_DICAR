using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorModulos
    {
        public static Modulos ConsultarModulo(string Modulo)
        {
            try
            {
                using (SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.Modulos.AsNoTracking().Where(x=>x.nombre_modumo==Modulo).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

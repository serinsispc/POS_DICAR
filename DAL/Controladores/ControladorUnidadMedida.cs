using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorUnidadMedida
    {
        public static List<TipoMedida> ListaCompleta()
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.TipoMedida.AsNoTracking().ToList();
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

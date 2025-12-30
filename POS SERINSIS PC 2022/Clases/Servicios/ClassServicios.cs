using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_PADRE_ARTURO.Servicios
{
    public class ClassServicios
    {
        public static void AbrirArchovo(string Ruta, string NombreArchivo)
        {
            try
            {
                Process.Start(Ruta + NombreArchivo);
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_POS.Clases
{
    public class VerificarFormulario
    {
        public static bool FormularioActivo(string NombreFormulario)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == NombreFormulario).SingleOrDefault<Form>();
            if (existe != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

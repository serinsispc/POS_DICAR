using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERINSI_PC.Clases
{

    public class ClassRuta
    {
        public static Image CargarLogo(string Ruta, string Carpeta, string Nombre)
        {
            if (File.Exists(Ruta + Carpeta + Nombre))
            {
                StreamReader sr = new StreamReader(Ruta + Carpeta + Nombre);
                Image xx = Image.FromStream(sr.BaseStream);
                sr.Close();
                return xx;
            }
            else
            {
                return POS_SERINSIS_PC_2022.Properties.Resources.logo;
            }
        }
        public static Image CargarProductoCategoria(string Ruta, string Carpeta, string Nombre)
        {
            if (File.Exists(Ruta + Carpeta + Nombre))
            {
                StreamReader sr = new StreamReader(Ruta + Carpeta + Nombre);
                Image xx = Image.FromStream(sr.BaseStream);
                sr.Close();
                return xx;
            }
            else
            {
                return POS_SERINSIS_PC_2022.Properties.Resources.Producto1;
            }
        }
    }
}

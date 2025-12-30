using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invenpol_Parqueadero_Motos.Clases.Servicios
{
    public class Class_EsteEquipo
    {
        public static void GuardarImagen_en_Equipo(byte[] Arreglo)
        {
            //en este momento lo guardamos en el computador
            string Ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            File.WriteAllBytes(Ruta + "\\" + "TiketEntrada.jpg", Arreglo);
        }
        public static void GardarLogoEnEquipo()
        {
            try
            {
                if (VariablesPublicas.RutaImagenes != "")
                {
                    //ahora abrimos el archivo
                    byte[] Arreglo = Convert.FromBase64String(VariablesPublicas.RutaImagenes);
                    string Ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    File.WriteAllBytes(Ruta + "\\" + "LogoFactura.jpg", Arreglo);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invenpol_Parqueadero_Motos.Clases
{
    public class CrearCodigoBarra
    {
        public static Image GenerarCodigoBarra(string Texto)
        {
            try
            {
                //primero generamos el codigo de barra
                BarcodeLib.Barcode Codigo = new BarcodeLib.Barcode();
                Codigo.IncludeLabel = true;
                Image ImagenBarra = Codigo.Encode(BarcodeLib.TYPE.CODE128, Texto, Color.Black, Color.White, 229, 75);
                return ImagenBarra;
            }
            catch(Exception ex)
            {
                string Error = ex.Message;
                return null;
            }
        }
    }
}

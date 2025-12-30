using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Invenpol_Parqueadero_Motos.Clases
{
    public class Convertir_Imagen
    {
        public static byte[] Image2Bytes(Image pImagen)
        {
            byte[] mImage;
            try
            {
                if (pImagen != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        pImagen.Save(ms, pImagen.RawFormat);
                        mImage = ms.GetBuffer();
                        ms.Close();
                    }
                }
                else { mImage = null; }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return mImage;
        }


        public static Image Bytes2Image(byte[] bytes)
        {
            if (bytes == null) return null;
            //
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Bitmap bm = null;
                try
                {
                    bm = new Bitmap(ms);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                return bm;
            }
        }



        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public static byte[] ConvertirImagenA_Byte(Image ImagenA_Comvertir)
        {
            try
            {
                //convertimos la imagen a byte
                MemoryStream ms = new MemoryStream();
                ImagenA_Comvertir.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] Imagen_Byte = ms.GetBuffer();
                return Imagen_Byte;
            }
            catch(Exception ex)
            {
                string Error = ex.Message;
                return null;
            }
        }

    }
}

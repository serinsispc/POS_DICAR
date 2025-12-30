using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//agregamos las libreriar que utilizaremos
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;


namespace Invenpol_Parqueadero_Motos.Clases
{
    //esta es la clase para crear el ticket de venta.
    public class CrearTiket
    {
        //creamos un objeto de la calse stringBuider, en este objeto agregaremos la limeas del ticket
        StringBuilder linea = new StringBuilder();
        //creamos una variable para almecenar el numero maximo de caracteres que permitiremos en el ticket
        public int maxCar = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.TamañaPapel;
        public int cortar; //para una impresora ticketera que imprima a 40 columnas.la variable contar cortara el texto cuando reabase el limite
        
        //creamos el primer metodo, este diujara lineas guion.
        public string lineasGio()
        {
            string lineasGuion = "";
            for(int i = 0; i < maxCar; i++)
            {
                lineasGuion += "=";//Agregara un guion hasta llegar al numero maximo de caracteres
            }
            return linea.AppendLine(lineasGuion).ToString();//devolvemos la lineaGuion
        }
        //creamos el ancabezado para los articulos
        public void EncavesadoVenta(string Producto,string CantPrecio)
        {
            //lo primero que hacemos es hallar los campos que le corresponde al producto
            int CamposProducto =maxCar - CantPrecio.Length;
            //ahora hallamos los campos de los extremos para centrarlo
            int CamposCentro = CamposProducto - Producto.Length;
            CamposCentro = CamposCentro / 2;
            //ahora generamos un espacio con las cantidades de los campos hallados
            string Espacio = "";
            for(int i = 1; i <= CamposCentro; i++)
            {
                Espacio = Espacio + " ";
            }
            string TituloLista = Espacio + Producto +Espacio+ CantPrecio;
            //ahora agregamos la linea de texto
            linea.AppendLine(TituloLista);
        }
        //creamos un metodo para poner el txto a la izquierda
        public void TextoIzquierda(string texto)
        {
            //si la longitud del texto es mayor alnumero maximo de caracteres permitidos, realizar el siguiente prosedimiento.
            if (texto.Length > maxCar)
            {
                int caracterActual = 0;//nos indicara en que caracter se quedo al bajar el texto a la siguiente linea.
                for(int longitudTexto=texto.Length; longitudTexto > maxCar; longitudTexto -=maxCar)
                {
                    //agregamos los fragmentos que salgan del texto
                    linea.AppendLine(texto.Substring(caracterActual,maxCar));
                    caracterActual += maxCar;
                }
                //agregamos el fragmento restante
                linea.AppendLine(texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {

                //si no es mayor solo agregarlo.
                linea.AppendLine(texto);
            }
        }
        //creamos un metodo para poner texto a la derecha.
        public void TextoDerecha(string texto)
        {
            //si la longitud del texto es mayor alnumero maximo de caracteres permitidos, realizar el siguiente prosedimiento.
            if (texto.Length > maxCar)
            {
                int caracterActual = 0;//nos indicara en que caracter se quedo al bajar el texto a la siguiente linea.
                for (int longitudTexto = texto.Length; longitudTexto > maxCar; longitudTexto -= maxCar)
                {
                    //agregamos los fragmentos que salgan del texto
                    linea.AppendLine(texto.Substring(caracterActual, maxCar));
                    caracterActual += maxCar;
                }
                //variables para poner espacios restantes.
                string espacios = "";
                //obtenemos la longitud del texto restante
                for (int i=0;i<(maxCar-texto.Substring(caracterActual,texto.Length - caracterActual).Length);i++)
                {
                    espacios += " ";//agregamos espacios para alinear a la derecha 
                }
                //agregamos el fragmento restante, agregamos antes del texto los espacios
                linea.AppendLine(espacios + texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                //variables para poner espacios restantes.
                string espacios = "";
                //obtenemos la longitud del texto restante
                for (int i = 0; i < (maxCar + texto.Length); i++)
                {
                    espacios += " ";//agregamos espacios para alinear a la derecha 
                }
                //si no es mayor solo agregarlo.
                linea.AppendLine(espacios + texto);
            }
        }
        public void AgregarArticulo(string PRODUCTO, string CANT, string PRECIO)
        {
            //lo primero que hasemos es ingrezar la cantidad y el precio
            string CantPrec = " " + CANT + " " + PRECIO;
            //ahora hallamos el espacio que le coresponde a la descripcion
            int EspacioDescripcion = maxCar - CantPrec.Length;
            int EspaciosDerecha = 0;
            string EspaciosBlanco = "";
            string TextoDescripcion = "";
            string TextoCortado = "";
            string TextoCortado2 = "";
            //ahora preguntamos si la longitud de la descripcion es superios al espacio hallado
            if (PRODUCTO.Length <= EspacioDescripcion)
            {
                //hallamos los espacios de la derecha
                EspaciosDerecha = EspacioDescripcion - PRODUCTO.Length;
                if (EspaciosDerecha > 0)
                {
                    //hallamo creamos los espacios
                    for (int i = 1; i <= EspaciosDerecha; i++)
                    {
                        EspaciosBlanco = EspaciosBlanco + " ";
                    }
                }
                TextoDescripcion = PRODUCTO + EspaciosBlanco + CantPrec;
                linea.AppendLine(TextoDescripcion);
            }
            else
            {
                TextoCortado = PRODUCTO.Substring(0, EspacioDescripcion);
                linea.AppendLine(TextoCortado + CantPrec);


                TextoCortado = PRODUCTO.Substring(EspacioDescripcion, PRODUCTO.Length - EspacioDescripcion);
                if (TextoCortado.Length > EspacioDescripcion)
                {
                    for (; TextoCortado.Length > EspacioDescripcion;)
                    {
                        TextoCortado2 = TextoCortado.Substring(0, EspacioDescripcion);
                        linea.AppendLine(TextoCortado2);
                        TextoCortado2 = TextoCortado.Substring(EspacioDescripcion, TextoCortado.Length - EspacioDescripcion);
                        TextoCortado = TextoCortado2;
                    }
                    //ahora hallamos los espacios
                    EspaciosDerecha = EspacioDescripcion - TextoCortado.Length;
                    EspaciosBlanco = "";
                    for (int i = 1; i <= EspaciosDerecha; i++)
                    {
                        EspaciosBlanco = EspaciosBlanco + " ";
                    }
                    linea.AppendLine(TextoCortado + EspaciosBlanco);
                }
                else
                {
                    //ahora hallamos los espacios
                    EspaciosDerecha = EspacioDescripcion - TextoCortado2.Length;
                    EspaciosBlanco = "";
                    for (int i = 1; i <= EspaciosDerecha; i++)
                    {
                        EspaciosBlanco = EspaciosBlanco + " ";
                    }
                    linea.AppendLine(TextoCortado2 + EspaciosBlanco);
                }

            }

        }
        //metodo para centrar el texto
        public void TextoCentro(string texto)
        {
            string TextoCortado = "";
            string TextoCortado2 = "";
            int EspaciosDerecha = 0;
            int EspacioTexto = 0;
            string EspaciosBlanco = "";
            //si la longitud del texto es mayor al numero maximo de caracteres permitidos, realizar el siguiente prosedimiento.
            if (texto.Length > maxCar)
            {
                TextoCortado = texto.Substring(0, maxCar);
                linea.AppendLine(TextoCortado);


                TextoCortado = texto.Substring(maxCar, texto.Length - maxCar);
                if (TextoCortado.Length > maxCar)
                {
                    for (; TextoCortado.Length > maxCar;)
                    {
                        TextoCortado2 = TextoCortado.Substring(0, maxCar);
                        linea.AppendLine(TextoCortado2);
                        TextoCortado2 = TextoCortado.Substring(maxCar, TextoCortado.Length - maxCar);
                        TextoCortado = TextoCortado2;
                    }
                    //ahora hallamos los espacios
                    EspaciosDerecha = EspacioTexto - TextoCortado.Length;
                    EspaciosDerecha = EspaciosDerecha / 2;
                    EspaciosBlanco = "";
                    for (int i = 1; i <= EspaciosDerecha; i++)
                    {
                        EspaciosBlanco = EspaciosBlanco + " ";
                    }
                    linea.AppendLine(TextoCortado + EspaciosBlanco);
                }
                else
                {
                    //ahora hallamos los espacios
                    EspaciosDerecha = maxCar - TextoCortado.Length;
                    EspaciosDerecha = EspaciosDerecha / 2;
                    EspaciosBlanco = "";
                    for (int i = 1; i <= EspaciosDerecha; i++)
                    {
                        EspaciosBlanco = EspaciosBlanco + " ";
                    }
                    linea.AppendLine(EspaciosBlanco + TextoCortado);
                }
            }
            else
            {
                //variables para poner espacios restantes.
                string espacios = "";
                //sacamos la cantidad de espacios libres y el resultado lo dividimos entre dos.
                int centrar = (maxCar - texto.Length)/2;
                //obtenemos la longitud del texto restante
                for (int i = 0; i < centrar; i++)
                {
                    espacios += " ";//agregamos espacios para centrar
                }
                //agregamos el fragmento restante, agregamos antes del texto los espacios
                linea.AppendLine(espacios + texto);
            }
            
        }
        //metodo para poner texto en los extremos
        public void TextoExtremos(string textoIzquierdo, string textoDerecho)
        {
            //variables que utilizamos.
            string textoIzq, textoDer, textoCompleto = "";
            int MitadTex = maxCar / 2;
            int Espacio = 0;
            string Vacio = "";
            //si el texto que va a la izquierda es mayor a 18, cortamos eltexto.
            if(textoIzquierdo.Length > MitadTex)
            {
                cortar = textoIzquierdo.Length - 18;
                textoIzq = textoIzquierdo.Remove(18, cortar);
            }
            else
            {
                Vacio = "";
                Espacio = MitadTex - textoIzquierdo.Length;
                for(int i = 1; i <= Espacio; i++)
                {
                    Vacio = Vacio + " ";
                }
                textoIzq =Vacio + textoIzquierdo;
                int cc = textoIzq.Length;
            }
            textoCompleto = textoIzq;//agregamos el primer texto

            if (textoDerecho.Length > MitadTex)//si es mayor a 20 lo cortamos
            {
                cortar = textoDerecho.Length - 20;
                textoDer = textoDerecho.Remove(20, cortar);
            }
            else
            {
                textoDer = textoDerecho;
            }

            textoCompleto = textoCompleto + textoDerecho;//agregamos elsegundotexto para alinearlo a la derecha.
            linea.AppendLine(textoCompleto);//agregamos la linea al ticket, al objeto en si.
        }
        //metodo para agregar los totales a la venta
        public void AgregarTotales(string texto, string total)
        {
            int Mitad = 0;
            int Espacio = 0;
            string EspacioBlanco = "";
            string textoCompleto = "";
            //hallamos la mitad del tiket
            Mitad = maxCar / 2;
            //ahora hallamos los espacios del texto
            Espacio = Mitad - texto.Length;
            //ahora hallamos los espacion
            for(int i = 1; i <= Espacio; i++)
            {
                EspacioBlanco = EspacioBlanco + " ";
            }
            //ahora agregamos el texto completo
            textoCompleto = EspacioBlanco + texto + total;
            linea.AppendLine(textoCompleto);
        }
        //metodo para agregar articulos al ticket de venta

        //metodo para enviar secuencia de escape a la impresora
        /// <summary>
        /// para cortar el ticket
        /// </summary>
        public void CortaTicket()
        {
            linea.AppendLine("\x1B" + "m");//caracteres de corte.estos comando varian segun el tipo de impresora
            linea.AppendLine("\x1B" + "d" + "\0");//avanza 9renglones,  tambien varian
        }
        /// <summary>
        /// para abrir el cajon
        /// </summary>
        public void AbreCajon(int codigo)
        {
            if(codigo == 1)
            {
                linea.AppendLine("\x1B" + "p" + "\x00" + "\x0F" + "\x96");//caracteres de apertura cajon 0
            }
            else
            {
                linea.AppendLine("\x1B" + "p" + "\x01" + "\x0F" + "\x96");//caracteres de apertura cajon 1
            }
            //este tambien varian, tienen que ve el manual de la impresora para poner los carrectos.
           

        }
        /// <summary>
        /// para mandara a imprimir el texto a la impresora que le indiquemos.
        /// </summary>
        /// <param name="imprisora"></param>
        public void ImprimirTicket(string imprisora)
        {
            //este metodo recibe el nombre de la impresora a la cual se mandara a imprimir y eltexto que se imrprima
            RawPrinterHelper.SendStringToPrinter(imprisora, linea.ToString());
            linea.Clear();
        }
    }

    //clase que mandara a imprimir texto plano al aimpresora
    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "Ticket de venta";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }


        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }
    //
}

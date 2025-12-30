using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing.Printing;
using System.Drawing;
using System.Drawing.Imaging;
using Invenpol_Parqueadero_Motos.Clases;
using Microsoft.Reporting.WinForms;

namespace winRdlc2
{
    public class Impresor : IDisposable
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        // Creamos el stream con el que vamos a trabajar y en el que meteremos el report
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        // Exporta el report indicado a un archivo EMF (Enhanced Metafile).
        private void Export(LocalReport report,int AbrirC)
        {
            string deviceInfo;
            //if (VariablesPublicas.TipoImpresora == "POS 58mm")
            //{

            //    if (VariablesPublicas.TipoCodigoImpresora == 1)
            //    {
            //        deviceInfo = @"<DeviceInfo>
            //    <OutputFormat>EMF</OutputFormat>
            //      <PageWidth>1.98346in</PageWidth>
            //    <PageHeight>150in</PageHeight>
            //    <MarginTop>0in</MarginTop>
            //    <MarginLeft>0in</MarginLeft>
            //    <MarginRight>0in</MarginRight>
            //    <MarginBottom>0in</MarginBottom>
            //    </DeviceInfo>";
            //    }
            //    else
            //    {
            //        deviceInfo =
            //            @"<DeviceInfo>
            //            <OutputFormat>EMF</OutputFormat>
            //          <PageWidth>2.3in</PageWidth>
            //            <PageHeight>12in</PageHeight>
            //            <MarginTop>0.1in</MarginTop>
            //            <MarginLeft>0.1in</MarginLeft>
            //            <MarginRight>0.1in</MarginRight>
            //            <MarginBottom>0in</MarginBottom>
            //        </DeviceInfo>";
            //    }

            //}
            //else
            //{
            //    if (VariablesPublicas.TipoCodigoImpresora == 1)
            //    {
            //        deviceInfo = @"<DeviceInfo>
            //                      <OutputFormat>EMF</OutputFormat>
            //                      <PageWidth>2.95000in</PageWidth>
            //                      <PageHeight>150in</PageHeight>
            //                      <MarginTop>0.10in</MarginTop>
            //                      <MarginLeft>0.1in</MarginLeft>
            //                      <MarginRight>0.1in</MarginRight>
            //                      <MarginBottom>0in</MarginBottom>
            //                  </DeviceInfo>";


            //    }
            //    else
            //    {
            //        deviceInfo = @"<DeviceInfo>
            //                      <OutputFormat>EMF</OutputFormat>
            //                      <PageWidth>2.95000in</PageWidth>
            //                      <PageHeight>11in</PageHeight>
            //                      <MarginTop>0.10in</MarginTop>
            //                      <MarginLeft>0.1in</MarginLeft>
            //                      <MarginRight>0.1in</MarginRight>
            //                      <MarginBottom>0in</MarginBottom>
            //                  </DeviceInfo>";
            //    }

            //}

            deviceInfo = @"<DeviceInfo>
                                  <OutputFormat>EMF</OutputFormat>
                                  <PageWidth>8.95000in</PageWidth>
                                  <PageHeight>11in</PageHeight>
                                  <MarginTop>0.10in</MarginTop>
                                  <MarginLeft>0.55000in</MarginLeft>
                                  <MarginRight>0.1in</MarginRight>
                                  <MarginBottom>0in</MarginBottom>
                              </DeviceInfo>";

            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
            { stream.Position = 0; }
        }
        // Handler para los eventos PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);

            //Crea un marco que contiene el documento (No es necesario)
            // Adjust rectangular area with printer margins.
               Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);


            // Dibuja un fondo blanco para el report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Dibuja el contenido del report
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Lo prepara para la siguiente página y comprueba que no llegado al final
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print(string Impresora)
        {
            PrintDocument printDoc;

            String printerName = Impresora;

            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: No hay datos que imprimir.");

            printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception(String.Format("No puedo encontrar la impresora \"{0}\".", printerName));
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        public static string ImpresoraPredeterminada()
        {
            for (Int32 i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                PrinterSettings a = new PrinterSettings();
                a.PrinterName = PrinterSettings.InstalledPrinters[i].ToString();
                if (a.IsDefaultPrinter)
                { return PrinterSettings.InstalledPrinters[i].ToString(); }
            }
            return "";
        }

        // Exporta el report a un archivo .emf y lo imprime
        public void Imprime(LocalReport rdlc, int AbrirC, string Impresora)
        {
           Export(rdlc,AbrirC);
            Print(Impresora);
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
    }
}


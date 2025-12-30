using POS_SERINSIS_PC_2022.Reportes;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Inventario
{
    public partial class frmCodigoBarra : Form
    {
        public decimal PrecioCodigo;
        public string DescripcionCodigo;
        byte[] Arreglo;
        public frmCodigoBarra()
        {
            InitializeComponent();
        }

        private void frmCodigoBarra_Load(object sender, EventArgs e)
        {

        }

        private void btnIMprimir_Click(object sender, EventArgs e)
        {
            Arreglo = ConvertirImagenA_Byte(pbCodigo.Image);
            string Ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            File.WriteAllBytes(Ruta + "\\" + "Codigo.jpg", Arreglo);

            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            frm.DescripcionCodigo = DescripcionCodigo;
            frm.PrecioCodigo = PrecioCodigo;
            frm.ReporteAImprimir = "ImprimirCodigo";
            frm.ShowDialog();
        }
        private static byte[] ConvertirImagenA_Byte(Image ImagenA_Comvertir)
        {
            try
            {
                //convertimos la imagen a byte
                MemoryStream ms = new MemoryStream();
                ImagenA_Comvertir.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] Imagen_Byte = ms.GetBuffer();
                return Imagen_Byte;
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                return null;
            }
        }
    }
}

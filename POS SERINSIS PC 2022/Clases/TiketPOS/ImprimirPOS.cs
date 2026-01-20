using DAL.Controladores;
using DAL.Modelo;
using Microsoft.Reporting.WinForms;
using System;
using winRdlc2;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace Invenpol_Parqueadero_Motos.Clases.TiketPOS
{
    public class ImprimirPOS
    {
        public static Form MdiParent { get; private set; }
        private static async Task CargarVarialesDatosEmpresa()
        {
            Sede objCS = new Sede();
            objCS =await ControladorSede.ConsultaXIdEmpresa(VariablesPublicas.IdEmpresaLogueada);
            if (objCS != null)
            {
                VariablesPublicas.NombreEmpresa =objCS.nombreSede;
                VariablesPublicas.CC_NIT = "NIT : " + objCS.nit;
                VariablesPublicas.RepresentanteLegal = objCS.reprecentante;
                VariablesPublicas.Regimen = "REGIMEN " + objCS.regimen;
                VariablesPublicas.Direccion = "DIR.: " + objCS.direccion;
                VariablesPublicas.Telefono = "TEL.: " + objCS.telefono;
            }
        }
        public static void FacturaVentaPOS(int AbrirC)
        {
            try
            {
                //CargarVarialesDatosEmpresa();
                LocalReport LRT = new LocalReport();
                //en esta parte cargamos el reporte
                LRT.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_FacturaVentaPOS58mm.rdlc";
                //ahora le avilitamos la imagen
                LRT.EnableExternalImages = true;
                //ahora creamos los parametros de la cabezera
                string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                ReportParameter myPar = new ReportParameter("P_NombreEmpresa", VariablesPublicas.NombreEmpresa);
                LRT.SetParameters(myPar);
                ReportParameter myPar2 = new ReportParameter("P_NIT", VariablesPublicas.CC_NIT);
                LRT.SetParameters(myPar2);
                ReportParameter myPar3 = new ReportParameter("P_Reprecentante", VariablesPublicas.RepresentanteLegal);
                LRT.SetParameters(myPar3);
                ReportParameter myPar4 = new ReportParameter("P_Direccion",  VariablesPublicas.Direccion);
                LRT.SetParameters(myPar4);
                ReportParameter myPar5 = new ReportParameter("P_Telefono", "Tels: " + VariablesPublicas.Telefono);
                LRT.SetParameters(myPar5);
                ReportParameter myPar6 = new ReportParameter("P_Regimen", "REGIMEN " + VariablesPublicas.Regimen);
                LRT.SetParameters(myPar6);
                ReportParameter myPar7 = new ReportParameter("P_FacturaRecibo",  VariablesPublicas.FacturaRecibo);
                LRT.SetParameters(myPar7);
                ReportParameter myPar8 = new ReportParameter("P_HoraImprecion", "IMP.: " + DateTime.Now.ToShortDateString() + " HRA,: " + DateTime.Now.ToShortTimeString());
                LRT.SetParameters(myPar8);
                ReportParameter myPar9 = new ReportParameter("P_Cliente",VariablesPublicas.NombreCliente);
                LRT.SetParameters(myPar9);
                ReportParameter myPar10 = new ReportParameter("P_DocumentoCliente", VariablesPublicas.DocumentoCliente);
                LRT.SetParameters(myPar10);
                ReportParameter myPar11 = new ReportParameter("P_DireccionCliente", VariablesPublicas.DireccionCliente);
                LRT.SetParameters(myPar11);
                ReportParameter myPar12 = new ReportParameter("P_TelefonoCliente", VariablesPublicas.TelefonoCliente);
                LRT.SetParameters(myPar12);
                ReportParameter myPar13 = new ReportParameter("P_SubTotal", VariablesPublicas.SubTotal);
                LRT.SetParameters(myPar13);
                ReportParameter myPar14 = new ReportParameter("P_Descuento", VariablesPublicas.Descuento);
                LRT.SetParameters(myPar14);
                ReportParameter myPar15 = new ReportParameter("P_Total", VariablesPublicas.Total);
                LRT.SetParameters(myPar15);
                ReportParameter myPar16 = new ReportParameter("P_FormaDePago", VariablesPublicas.EfectivoTarjeta);
                LRT.SetParameters(myPar16);
                ReportParameter myPar17 = new ReportParameter("P_Efectivo", VariablesPublicas.Efectivo);
                LRT.SetParameters(myPar17);
                ReportParameter myPar18 = new ReportParameter("P_Cambio", VariablesPublicas.Cambio);
                LRT.SetParameters(myPar18);
                ReportParameter myPar19 = new ReportParameter("P_Logo", new Uri(mdoc + "\\LogoFactura.jpg").AbsoluteUri);
                LRT.SetParameters(myPar19);

                //Imprime el report
                Impresor imp = new winRdlc2.Impresor();
                String printerName = Impresor.ImpresoraPredeterminada();
                imp.Imprime(LRT, 0, printerName);
                CrearTiket cc = new CrearTiket();

                cc.ImprimirTicket(printerName);

                File.Delete(mdoc + "\\LogoFactura.jpg");
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                MessageBox.Show("Erros en proceso de imprecion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

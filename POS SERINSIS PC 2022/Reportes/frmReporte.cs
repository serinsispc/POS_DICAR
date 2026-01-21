using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;
using Microsoft.Reporting.WinForms;
using SERINSI_PC.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winRdlc2;

namespace POS_SERINSIS_PC_2022.Reportes
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }
        public string DescripcionCodigo;
        public decimal PrecioCodigo;
        public string ReporteAImprimir;
        public DateTime FechaReporte;
        //Variables factura
        public int IdVenta;
        public string FechaFactura;
        public int NumeroFactura;
        public string FacturaRecibo;
        public string ContadoCredito;
        public string NombreCliente;
        public string DocumentoCliente;
        public string DireccionCliente;
        public string TelefonoCliente;
        public decimal SubTotal;
        public decimal Descuento;
        public decimal Total;
        public string EfectivoTarjeta;
        public decimal Efectivo;
        public decimal Cambio;
        //variables Reporte General
        public string TipoInforme;
        public decimal IngresosTienda;
        public int EgresosTienda;
        public decimal PagoCC;
        public int UtilidadTienda;
        public int Gastos;
        public int TotalINgresos;
        public decimal TotalEgresos;
        public int TotalUtilidad;
        public decimal UtilidadVentas;
        public string FechaVencimientoCredito;
        public string DiasCredito;
        public string GuidTexto;
        private void frmReporte_Load(object sender, EventArgs e)
        {
            if (ReporteAImprimir == "OrdenTraslado")
            {
                OrdenTraslado();
            }
            if (ReporteAImprimir == "OrdenServicio")
            {
                OrdenServicio();
            }
            if (ReporteAImprimir == "ImprimirCodigo")
            {
                ImprimirCodigo();
            }
            if (ReporteAImprimir == "InformeGeneral")
            {
                ReporteInformeGeneral();
                MostrarReporte();
            }
            if (ReporteAImprimir == "PagosCP")
            {
                PagosCP();
                MostrarReporte();
            }
            if (ReporteAImprimir == "ListaGastos")
            {
                R_ListaGastos();
                MostrarReporte();
            }
        }
        public void ImprimirReporteCierreCaja(decimal baseCaja,
                                      decimal gastos,
                                      decimal compras,
                                      decimal pagoCredito,
                                      decimal ventasEfectivo,
                                      decimal ventasTarjeta,
                                      decimal totalTienda,
                                      decimal producido,
                                      DateTime apertura,
                                      DateTime cierre,
                                      string usuario)
        {
            try
            {
                //en esta parte cargamos el reporte
                this.reportViewer1.LocalReport.ReportPath = Environment.CurrentDirectory + "\\Reportes\\Report_CierreCaja.rdlc";
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                //ahora creamos los parametros de la cabezera 
                string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                ReportParameter myPar = new ReportParameter("P_Usuario", usuario);
                this.reportViewer1.LocalReport.SetParameters(myPar);

                ReportParameter myPar1 = new ReportParameter("P_Apertura", Convert.ToString(apertura));
                this.reportViewer1.LocalReport.SetParameters(myPar1);

                ReportParameter myPar2 = new ReportParameter("P_Cierre", Convert.ToString(cierre));
                this.reportViewer1.LocalReport.SetParameters(myPar2);

                ReportParameter myPar3 = new ReportParameter("P_BaseCaja", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(baseCaja)));
                this.reportViewer1.LocalReport.SetParameters(myPar3);

                ReportParameter myPar12 = new ReportParameter("P_Gastos", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(gastos)));
                this.reportViewer1.LocalReport.SetParameters(myPar12);

                ReportParameter myPar8 = new ReportParameter("P_Compras", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(compras)));
                this.reportViewer1.LocalReport.SetParameters(myPar8);

                ReportParameter myPar6 = new ReportParameter("P_PagoCreditos", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(pagoCredito)));
                this.reportViewer1.LocalReport.SetParameters(myPar6);

                ReportParameter myPar5 = new ReportParameter("P_VentasTienda", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(ventasEfectivo)));
                this.reportViewer1.LocalReport.SetParameters(myPar5);

                ReportParameter myPar9 = new ReportParameter("P_VentasTarjeta", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(ventasTarjeta)));
                this.reportViewer1.LocalReport.SetParameters(myPar9);

                ReportParameter myPar7 = new ReportParameter("P_TotalTienda", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(totalTienda)));
                this.reportViewer1.LocalReport.SetParameters(myPar7);

                ReportParameter myPar4 = new ReportParameter("P_Producido", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(producido)));
                this.reportViewer1.LocalReport.SetParameters(myPar4);

                ReportParameter myPar15 = new ReportParameter("P_Producido", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(producido)));
                this.reportViewer1.LocalReport.SetParameters(myPar15);

                MostrarReporte();
            }
            catch (Exception EX)
            {
                string Error = EX.Message;
                MessageBox.Show("Erros en proceso de imprecion." + Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarReporte()
        {
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            reportViewer1.ZoomPercent = 100;
            this.reportViewer1.RefreshReport();
        }
        private async Task OrdenTraslado()
        {
            try
            {
                List<V_DetalleTraslado> ctx = new List<V_DetalleTraslado>();
                ctx =await controladorDetalleTraslado.Filtrar_Guid(GuidTexto);
                dynamic dataSource = ctx;
                //en esta parte cargamos el reporte
                if (VariablesPublicas.TipoImpresora == "Carta")
                {
                    this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_Traslado.rdlc";
                }

                //en esta parte cargamos el reporte
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSettRASLADO", dataSource));
                //ahora le avilitamos la imagen
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                //ahora creamos los parametros de la cabezera
                string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                ReportParameter myPar = new ReportParameter("P_NombreEmpresa", VariablesPublicas.NombreEmpresa);
                this.reportViewer1.LocalReport.SetParameters(myPar);

                ReportParameter myPar2 = new ReportParameter("P_NIT", VariablesPublicas.CC_NIT);
                this.reportViewer1.LocalReport.SetParameters(myPar2);

                ReportParameter myPar3 = new ReportParameter("P_Reprecentante", VariablesPublicas.RepresentanteLegal);
                this.reportViewer1.LocalReport.SetParameters(myPar3);

                ReportParameter myPar4 = new ReportParameter("P_Direccion", VariablesPublicas.Direccion);
                this.reportViewer1.LocalReport.SetParameters(myPar4);

                ReportParameter myPar5 = new ReportParameter("P_Telefono", "Tels: " + VariablesPublicas.Telefono);
                this.reportViewer1.LocalReport.SetParameters(myPar5);

                ReportParameter myPar6 = new ReportParameter("P_Regimen", "REGIMEN " + VariablesPublicas.Regimen);
                this.reportViewer1.LocalReport.SetParameters(myPar6);

                ReportParameter myPar7 = new ReportParameter("P_Orden", VariablesPublicas.OrdenTraslado);
                this.reportViewer1.LocalReport.SetParameters(myPar7);

                ReportParameter myPar8 = new ReportParameter("P_Fecha", Convert.ToString(DateTime.Now));
                this.reportViewer1.LocalReport.SetParameters(myPar8);

                ReportParameter myPar9 = new ReportParameter("P_Enviado", VariablesPublicas.EnvioTraslado);
                this.reportViewer1.LocalReport.SetParameters(myPar9);

                ReportParameter myPar10 = new ReportParameter("P_Recibido", VariablesPublicas.RecibidoTraslado);
                this.reportViewer1.LocalReport.SetParameters(myPar10);

                ReportParameter myPar11 = new ReportParameter("P_Descipcion", VariablesPublicas.DesciopcionTraslado);
                this.reportViewer1.LocalReport.SetParameters(myPar11);

                ReportParameter myPar19 = new ReportParameter("P_Logo", new Uri(VariablesPublicas.RutaImagenes + "\\Logo\\Logo" + VariablesPublicas.IdEmpresaLogueada + ".png").AbsoluteUri);
                this.reportViewer1.LocalReport.SetParameters(myPar19);

                //MessageBox.Show(VariablesPublicas.RutaImagenes);

                MostrarReporte();
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OrdenServicio()
        {
            try
            {
                //en esta parte cargamos el reporte
                if (VariablesPublicas.TipoImpresora == "Carta")
                {
                    this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\ReportOrdenServicioCarta.rdlc";
                }
                else
                {
                    this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\ReportOrdenServicio.rdlc";
                }



                //ahora le avilitamos la imagen
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                //ahora creamos los parametros de la cabezera
                string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                ReportParameter myPar = new ReportParameter("P_NombreEmpresa", VariablesPublicas.NombreEmpresa);
                this.reportViewer1.LocalReport.SetParameters(myPar);

                ReportParameter myPar2 = new ReportParameter("P_NIT", VariablesPublicas.CC_NIT);
                this.reportViewer1.LocalReport.SetParameters(myPar2);

                ReportParameter myPar3 = new ReportParameter("P_Reprecentante", VariablesPublicas.RepresentanteLegal);
                this.reportViewer1.LocalReport.SetParameters(myPar3);

                ReportParameter myPar4 = new ReportParameter("P_Direccion", VariablesPublicas.Direccion);
                this.reportViewer1.LocalReport.SetParameters(myPar4);

                ReportParameter myPar5 = new ReportParameter("P_Telefono", "Tels: " + VariablesPublicas.Telefono);
                this.reportViewer1.LocalReport.SetParameters(myPar5);

                ReportParameter myPar6 = new ReportParameter("P_Regimen", "REGIMEN " + VariablesPublicas.Regimen);
                this.reportViewer1.LocalReport.SetParameters(myPar6);

                ReportParameter myPar7 = new ReportParameter("P_NumeroOrden", VariablesPublicas.NumeroOrdenServicio);
                this.reportViewer1.LocalReport.SetParameters(myPar7);

                ReportParameter myPar8 = new ReportParameter("P_Fecha", Convert.ToString(DateTime.Now));
                this.reportViewer1.LocalReport.SetParameters(myPar8);

                ReportParameter myPar9 = new ReportParameter("P_NombreCliente", VariablesPublicas.NombreCliente);
                this.reportViewer1.LocalReport.SetParameters(myPar9);

                ReportParameter myPar10 = new ReportParameter("P_TelefonoCliente", VariablesPublicas.TelefonoCliente);
                this.reportViewer1.LocalReport.SetParameters(myPar10);

                ReportParameter myPar11 = new ReportParameter("P_TipoServicio", VariablesPublicas.TipoServicio);
                this.reportViewer1.LocalReport.SetParameters(myPar11);

                ReportParameter myPar12 = new ReportParameter("P_TipoArticulo", VariablesPublicas.TipoArticulo);
                this.reportViewer1.LocalReport.SetParameters(myPar12);

                ReportParameter myPar13 = new ReportParameter("P_Modelo", VariablesPublicas.Modelo);
                this.reportViewer1.LocalReport.SetParameters(myPar13);

                ReportParameter myPar14 = new ReportParameter("P_Serial", VariablesPublicas.Serial);
                this.reportViewer1.LocalReport.SetParameters(myPar14);

                ReportParameter myPar15 = new ReportParameter("P_ObservacionIngreso", VariablesPublicas.ObservacionIngreso);
                this.reportViewer1.LocalReport.SetParameters(myPar15);

                ReportParameter myPar19 = new ReportParameter("P_Logo", new Uri(VariablesPublicas.RutaImagenes + "\\Logo\\Logo" + VariablesPublicas.IdEmpresaLogueada + ".png").AbsoluteUri);
                this.reportViewer1.LocalReport.SetParameters(myPar19);

                //MessageBox.Show(VariablesPublicas.RutaImagenes);

                MostrarReporte();
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ImprimirCodigo()
        {
            try
            {
                this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_ImprimirCodigo.rdlc";


                //ahora le avilitamos la imagen
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                //ahora creamos los parametros de la cabezera
                string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                ReportParameter myPar1 = new ReportParameter("P_Codigo", new Uri(mdoc + "\\" + "Codigo.jpg").AbsoluteUri);
                this.reportViewer1.LocalReport.SetParameters(myPar1);
                ReportParameter myPar2 = new ReportParameter("P_Descripcion", DescripcionCodigo);
                this.reportViewer1.LocalReport.SetParameters(myPar2);
                ReportParameter myPar3 = new ReportParameter("P_Precio", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(PrecioCodigo)));
                this.reportViewer1.LocalReport.SetParameters(myPar3);


                MostrarReporte();
                //File.Delete(mdoc + "\\Codigo.jpg");
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReporteInformeGeneral()
        {

            this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_Informe_General.rdlc";
            string TI = "";
            if (TipoInforme == "Año")
            {
                TI = "Año " + FechaReporte.Year;
            }
            if (TipoInforme == "Mes")
            {
                TI = "Mes " + FechaReporte.Month + " del Año " + FechaReporte.Year;
            }
            if (TipoInforme == "Dia")
            {
                TI = "Dia " + FechaReporte.ToShortDateString();
            }
            ReportParameter myPar = new ReportParameter("P_TipoInforme", TI);
            this.reportViewer1.LocalReport.SetParameters(myPar);

            ReportParameter myPar1 = new ReportParameter("P_FechaImpresion", DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
            this.reportViewer1.LocalReport.SetParameters(myPar1);

            ReportParameter myPar2 = new ReportParameter("P_IngresosTienda", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(IngresosTienda)));
            this.reportViewer1.LocalReport.SetParameters(myPar2);

            ReportParameter myPar3 = new ReportParameter("P_EgresosTienda", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(EgresosTienda)));
            this.reportViewer1.LocalReport.SetParameters(myPar3);

            ReportParameter myPar4 = new ReportParameter("P_TotalPagosCredito", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(PagoCC)));
            this.reportViewer1.LocalReport.SetParameters(myPar4);

            ReportParameter myPar5 = new ReportParameter("P_UtilidadTienda", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(UtilidadTienda)));
            this.reportViewer1.LocalReport.SetParameters(myPar5);

            ReportParameter myPar6 = new ReportParameter("P_Gastos", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(Gastos)));
            this.reportViewer1.LocalReport.SetParameters(myPar6);

            ReportParameter myPar7 = new ReportParameter("P_TotalIngresos", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(TotalINgresos)));
            this.reportViewer1.LocalReport.SetParameters(myPar7);

            ReportParameter myPar8 = new ReportParameter("P_TotalEgresos", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(TotalEgresos)));
            this.reportViewer1.LocalReport.SetParameters(myPar8);

            ReportParameter myPar9 = new ReportParameter("P_TotalUtilidad", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(TotalUtilidad)));
            this.reportViewer1.LocalReport.SetParameters(myPar9);

            ReportParameter myPar10 = new ReportParameter("P_UtilidadVentas", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(UtilidadVentas)));
            this.reportViewer1.LocalReport.SetParameters(myPar10);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            reportViewer1.ZoomPercent = 100;
            this.reportViewer1.RefreshReport();
        }
        private async Task PagosCP()
        {
            List<V_PagoCP> ctx = new List<V_PagoCP>();
            if (TipoInforme == "Año")
            {
                ctx =await ControladorCompra.FiltroX_Año(FechaReporte, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoInforme == "Mes")
            {
                ctx =await ControladorCompra.FiltroX_Mes(FechaReporte, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoInforme == "Dia")
            {
                ctx =await ControladorCompra.FiltroX_Dia(FechaReporte, VariablesPublicas.IdEmpresaLogueada);
            }


            if (ctx != null)
            {
                dynamic dataSource = ctx;

                this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_PagosCP.rdlc";
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetReportes", dataSource));

                string TI = "";
                if (TipoInforme == "Año")
                {
                    TI = "Año " + FechaReporte.Year;
                }
                if (TipoInforme == "Mes")
                {
                    TI = "Mes " + FechaReporte.Month + " del Año " + FechaReporte.Year;
                }
                if (TipoInforme == "Dia")
                {
                    TI = "Dia " + FechaReporte.ToShortDateString();
                }
                ReportParameter myPar = new ReportParameter("P_TipoInforme", TI);
                this.reportViewer1.LocalReport.SetParameters(myPar);

                ReportParameter myPar1 = new ReportParameter("P_FechaImpresion", DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                this.reportViewer1.LocalReport.SetParameters(myPar1);

                ReportParameter myPar2 = new ReportParameter("P_EgresosTienda", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(EgresosTienda)));
                this.reportViewer1.LocalReport.SetParameters(myPar2);

            }
            else
            {
                MessageBox.Show("La vista del reporte no se encontro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task R_ListaGastos()
        {
            List<V_Gastos> ctx = new List<V_Gastos>();
            if (TipoInforme == "Año")
            {
                ctx =await ControladorGastos.FiltrarX_Año(FechaReporte, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoInforme == "Mes")
            {
                ctx =await ControladorGastos.FiltrarX_Mes(FechaReporte, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoInforme == "Dia")
            {
                ctx =await ControladorGastos.FiltrarX_Dia(FechaReporte, VariablesPublicas.IdEmpresaLogueada);
            }


            if (ctx != null)

            {
                dynamic dataSource = ctx;

                this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_Lista_Gastos.rdlc";
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetReportes", dataSource));

                string TI = "";
                if (TipoInforme == "Año")
                {
                    TI = "Año " + FechaReporte.Year;
                }
                if (TipoInforme == "Mes")
                {
                    TI = "Mes " + FechaReporte.Month + " del Año " + FechaReporte.Year;
                }
                if (TipoInforme == "Dia")
                {
                    TI = "Dia " + FechaReporte.ToShortDateString();
                }
                ReportParameter myPar = new ReportParameter("P_TipoInforme", TI);
                this.reportViewer1.LocalReport.SetParameters(myPar);

                ReportParameter myPar1 = new ReportParameter("P_FechaImpresion", DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                this.reportViewer1.LocalReport.SetParameters(myPar1);

                ReportParameter myPar2 = new ReportParameter("P_Gastos", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(Gastos)));
                this.reportViewer1.LocalReport.SetParameters(myPar2);
            }
            else
            {
                MessageBox.Show("La vista del reporte no se encontro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task ListaVentaTienda()
        {
            DataTable ctx = new DataTable();
            if (TipoInforme == "Año")
            {
                ctx =await ControladorVenta.FiltroX_H_Año(FechaReporte, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoInforme == "Mes")
            {
                ctx =await ControladorVenta.FiltroX_H_Mes(FechaReporte, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoInforme == "Dia")
            {
                ctx =await ControladorVenta.FiltroX_H_Dia(FechaReporte, VariablesPublicas.IdEmpresaLogueada);
            }

            if (ctx != null)
            {
                dynamic dataSource = ctx;
                decimal total = 0;
                foreach (DataRow rows in ctx.Rows)
                {
                    total = total +Convert.ToDecimal(rows["totalVenta"]);
                }

                this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_Lista_Ventas_Tienda.rdlc";
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetReportes", dataSource));
                string TI = "";
                if (TipoInforme == "Año")
                {
                    TI = "Año " + FechaReporte.Year;
                }
                if (TipoInforme == "Mes")
                {
                    TI = "Mes " + FechaReporte.Month + " del Año " + FechaReporte.Year;
                }
                if (TipoInforme == "Dia")
                {
                    TI = "Dia " + FechaReporte.ToShortDateString();
                }
                ReportParameter myPar = new ReportParameter("P_TipoInforme", TI);
                this.reportViewer1.LocalReport.SetParameters(myPar);

                ReportParameter myPar1 = new ReportParameter("P_FechaImpresion", DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                this.reportViewer1.LocalReport.SetParameters(myPar1);

                ReportParameter myPar2 = new ReportParameter("P_Total", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(total)));
                this.reportViewer1.LocalReport.SetParameters(myPar2);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
                reportViewer1.ZoomPercent = 75;
                this.reportViewer1.RefreshReport();

            }
            else
            {
                MessageBox.Show("La vista del reporte no se encontro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ListaVentaTiendaProducto()
        {
            DataTable ctx = new DataTable();
            if (TipoInforme == "Año")
            {
                ctx = ControladorVenta.FiltroX_H_Año_Detalle(FechaReporte, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoInforme == "Mes")
            {
                ctx = ControladorVenta.FiltroX_H_Mes_Detalle(FechaReporte, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoInforme == "Dia")
            {
                ctx = ControladorVenta.FiltroX_H_Dia_Detalle(FechaReporte, VariablesPublicas.IdEmpresaLogueada);
            }

            if (ctx != null)
            {
                dynamic dataSource = ctx;
                decimal total = 0;
                foreach (DataRow rows in ctx.Rows)
                {
                    total = total + Convert.ToDecimal(rows["totalDetalleVentaV"]);
                }

                this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_InformeVentasProducto.rdlc";
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetInformeDetalleVenta", dataSource));
                string TI = "";
                if (TipoInforme == "Año")
                {
                    TI = "Año " + FechaReporte.Year;
                }
                if (TipoInforme == "Mes")
                {
                    TI = "Mes " + FechaReporte.Month + " del Año " + FechaReporte.Year;
                }
                if (TipoInforme == "Dia")
                {
                    TI = "Dia " + FechaReporte.ToShortDateString();
                }
                ReportParameter myPar = new ReportParameter("P_TipoInforme", TI);
                this.reportViewer1.LocalReport.SetParameters(myPar);

                ReportParameter myPar1 = new ReportParameter("P_FechaImpresion", DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                this.reportViewer1.LocalReport.SetParameters(myPar1);

                ReportParameter myPar2 = new ReportParameter("P_Total", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(total)));
                this.reportViewer1.LocalReport.SetParameters(myPar2);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
                reportViewer1.ZoomPercent = 75;
                this.reportViewer1.RefreshReport();

            }
            else
            {
                MessageBox.Show("La vista del reporte no se encontro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task Inventario_RP(int elimi)
        {

            try
            {
                //lógica de generación de reporte

                List<v_productoVenta> ctx = new List<v_productoVenta>();
                ctx =await ControladorProducto.FiltrarX_IdSede(VariablesPublicas.IdEmpresaLogueada, elimi);

                if (ctx != null)
                {
                    dynamic dataSource = ctx;
                    // Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\Reportes")
                    this.reportViewer1.LocalReport.ReportPath = "G:\\Mi unidad\\app" + "\\Inventario_report.rdlc";
                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DS_Inventario", dataSource));


                    this.reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Informe: nombreInforme, Exception: {ex.Message} {Environment.NewLine} Inner Exception: {ex.InnerException.Message}");
            }



        }
        public async Task ReporteInventario(int elimi)
        {
            List<v_productoVenta> ctx = new List<v_productoVenta>();

            ctx =await ControladorProducto.FiltrarX_IdSede(VariablesPublicas.IdEmpresaLogueada, elimi);



            if (ctx != null)

            {
                dynamic dataSource = ctx;
                //Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\Reportes")
                this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_Inventario.rdlc";
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_ImprimirInventario", dataSource));

                MostrarReporte();
            }
            else
            {
                MessageBox.Show("La vista del reporte no se encontro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task ListaPrecios()
        {
            List<V_ListaPrecios> ctx = new List<V_ListaPrecios>();

            ctx =await ControladorProducto.ListaPrecios();



            if (ctx != null)

            {
                dynamic dataSource = ctx;
                //Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\Reportes")
                this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_ListaPrecios.rdlc";
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_ListaPrecios", dataSource));

                MostrarReporte();
            }
            else
            {
                MessageBox.Show("La vista del reporte no se encontro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task ListaCostoIventario()
        {
            List<V_CostoInventario> ctx = new List<V_CostoInventario>();

            ctx =await ControladorProducto.ListaCostoInventario();

            decimal costoTotal =await ControladorProducto.TotalListaCostoInventario();



            if (ctx != null)

            {
                dynamic dataSource = ctx;
                //Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\Reportes")
                this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_CostoInventario.rdlc";
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_CostoInventario", dataSource));

                ReportParameter myPar = new ReportParameter("p_TotalCostoInventario", costoTotal.ToString("C")); ;
                this.reportViewer1.LocalReport.SetParameters(myPar);


                MostrarReporte();
            }
            else
            {
                MessageBox.Show("La vista del reporte no se encontro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task FacturaVentaCarta(int AbrirC, int IdVenta)
        {
            try
            {
                V_TablaVentas v_TablaVentas = new V_TablaVentas();
                v_TablaVentas =await ControladorVenta.ConsultaX_V_id(IdVenta);
                if (v_TablaVentas == null)
                {
                    return;
                }


                int iva = Convert.ToInt32(v_TablaVentas.ivaVenta);

                List<R_DetalleVenta> ctx = new List<R_DetalleVenta>();
                ctx =await ControladorDetalleVenta.FiltrarX_IdVenta(IdVenta);

                dynamic dataSource = ctx;
                await CargarVarialesDatosEmpresa();
                LocalReport LRT = new LocalReport();
                //en esta parte cargamos el reporte 
                //System.Environment.CurrentDirectory 
                LRT.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_FacturaCarta.rdlc";

                LRT.DataSources.Add(new ReportDataSource("DataSetFacturaVenta", dataSource));


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
                ReportParameter myPar4 = new ReportParameter("P_Direccion", VariablesPublicas.Direccion);
                LRT.SetParameters(myPar4);
                ReportParameter myPar5 = new ReportParameter("P_Telefono", VariablesPublicas.Telefono);
                LRT.SetParameters(myPar5);
                ReportParameter myPar6 = new ReportParameter("P_Regimen", VariablesPublicas.Regimen);
                LRT.SetParameters(myPar6);
                ReportParameter myPar7 = new ReportParameter("P_FacturaRecibo", VariablesPublicas.PrefijoResolucion + "-" + v_TablaVentas.numeroVenta);
                LRT.SetParameters(myPar7);
                ReportParameter myPar8 = new ReportParameter("P_Fecha", Convert.ToDateTime(v_TablaVentas.fechaVenta).ToShortDateString());
                LRT.SetParameters(myPar8);

                Clientes cliente = new Clientes();
                string nombreCliente = " ";
                string documentoCliente = " ";
                string telfonoCliente = " ";
                string direccionCliente = " ";
                string barrio = " ";
                if (VariablesPublicas.IdCliente >0)
                {
                    cliente =await ControladorClienteTienda.ConsultarX_ID(VariablesPublicas.IdCliente);
                    if (cliente != null)
                    {
                        nombreCliente = cliente.nombreCliente;
                        documentoCliente = cliente.documentoCliente;
                        telfonoCliente = cliente.telefonoCliente;
                        direccionCliente = cliente.direccionCliente;
                        barrio = cliente.barrioCliente;
                    }
                }

                ReportParameter myPar9 = new ReportParameter("P_Cliente", nombreCliente);
                LRT.SetParameters(myPar9);

                ReportParameter myPar10 = new ReportParameter("P_DocumentoCliente", documentoCliente);
                LRT.SetParameters(myPar10);

                ReportParameter myPar11 = new ReportParameter("P_DireccionCliente", direccionCliente);
                LRT.SetParameters(myPar11);

                ReportParameter myPar12 = new ReportParameter("P_TelefonoCliente", Convert.ToString(telfonoCliente));
                LRT.SetParameters(myPar12);

                ReportParameter myPar40 = new ReportParameter("p_Barrio", Convert.ToString(barrio));
                LRT.SetParameters(myPar40);

                ReportParameter myPar13 = new ReportParameter("P_SubTotal", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.subtotalVenta - v_TablaVentas.ivaVenta)));
                LRT.SetParameters(myPar13);
                ReportParameter myPar14 = new ReportParameter("P_Descuento", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.descuentoVenta)));
                LRT.SetParameters(myPar14);
                ReportParameter myPar15 = new ReportParameter("P_Total", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.totalVenta)));
                LRT.SetParameters(myPar15);
                ReportParameter myPar16 = new ReportParameter("P_FormaDePago", v_TablaVentas.tipoPago);
                LRT.SetParameters(myPar16);
                ReportParameter myPar17 = new ReportParameter("P_Efectivo", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.efectivoVenta)));
                LRT.SetParameters(myPar17);
                ReportParameter myPar18 = new ReportParameter("P_Cambio", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.cambioVenta)));
                LRT.SetParameters(myPar18);
                ReportParameter myPar19 = new ReportParameter("P_Logo", new Uri("C:\\Imagenes\\Logo\\Logo.png").AbsoluteUri);
                LRT.SetParameters(myPar19);
                ReportParameter myPar20 = new ReportParameter("P_TipoVenta", v_TablaVentas.tipoVenta);
                LRT.SetParameters(myPar20);
                ReportParameter myPar21 = new ReportParameter("P_Leyenda", v_TablaVentas.observacionVenta);
                LRT.SetParameters(myPar21);
                ReportParameter myPar22 = new ReportParameter("P_AbonoTarjeta", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.abonoTarjeta)));
                LRT.SetParameters(myPar22);

                ReportParameter myPar23 = new ReportParameter("pResolucion", "Valor Número Autorización " + VariablesPublicas.Resolucion);
                LRT.SetParameters(myPar23);

                ReportParameter myPar24 = new ReportParameter("pFechaResolucion", "Autorizada el " + VariablesPublicas.FechaResolucion);
                LRT.SetParameters(myPar24);

                ReportParameter myPar25 = new ReportParameter("pPrefijoResolucion", "Prefijo " + VariablesPublicas.PrefijoResolucion + " Del: " + VariablesPublicas.RangoResolucion);
                LRT.SetParameters(myPar25);

                string valorLetras = Conversores.NumeroALetras(Convert.ToDecimal(v_TablaVentas.totalVenta));

                ReportParameter myPar26 = new ReportParameter("pValorLetras", valorLetras.Replace("00 /100", "m/cte"));
                LRT.SetParameters(myPar26);

                ReportParameter myPar27 = new ReportParameter("pTotalItems", Convert.ToString(ctx.Count));
                LRT.SetParameters(myPar27);

                ReportParameter myPar28 = new ReportParameter();
                if (VariablesPublicas.nombreVendedor != "")
                {
                   myPar28 = new ReportParameter("pVendedor", VariablesPublicas.nombreVendedor);
                }
                else
                {
                    myPar28 = new ReportParameter("pVendedor", VariablesPublicas.NombreUsuarioActivo);
                }
                
                LRT.SetParameters(myPar28);

                if (VariablesPublicas.Mensualidad == true)
                {
                    ReportParameter myPar31 = new ReportParameter("pF1", "Fecha límite de pago:");
                    LRT.SetParameters(myPar31);

                    ReportParameter myPar29 = new ReportParameter("P_FechaVencimiento", Convert.ToDateTime(v_TablaVentas.fechaVencimiento).ToShortDateString());
                    LRT.SetParameters(myPar29);

                    ReportParameter myPar32 = new ReportParameter("pF2", "Fecha suspensión:");
                    LRT.SetParameters(myPar32);

                    ReportParameter myPar33 = new ReportParameter("pFechaSuspencion", Convert.ToDateTime(v_TablaVentas.fechaVencimiento).AddDays(5).ToShortDateString());
                    LRT.SetParameters(myPar33);
                }
                else
                {
                    ReportParameter myPar31 = new ReportParameter("pF1", "Fecha Vencimiento:");
                    LRT.SetParameters(myPar31);

                    ReportParameter myPar29 = new ReportParameter("P_FechaVencimiento", Convert.ToDateTime(v_TablaVentas.fechaVenta).AddDays(30).ToShortDateString());
                    LRT.SetParameters(myPar29);

                    ReportParameter myPar32 = new ReportParameter("pF2", " ");
                    LRT.SetParameters(myPar32);

                    ReportParameter myPar33 = new ReportParameter("pFechaSuspencion", " ");
                    LRT.SetParameters(myPar33);
                }


                ReportParameter myPar30 = new ReportParameter("P_CorreoElectronico", VariablesPublicas.CorreoAdmin1);
                LRT.SetParameters(myPar30);

                ReportParameter myPar34 = new ReportParameter("pIVA", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(iva)));
                LRT.SetParameters(myPar34);

                ReportParameter myPar35 = new ReportParameter("p_QR", new Uri("C:\\QR\\" + IdVenta+".png").AbsoluteUri);
                LRT.SetParameters(myPar35);

                if (VariablesPublicas.FacturarPedido == true)
                {
                    //Imprime el report
                    Impresor imp = new winRdlc2.Impresor();
                    String printerName = Impresor.ImpresoraPredeterminada();
                    imp.Imprime(LRT, 0, printerName);
                    CrearTiket cc = new CrearTiket();

                    cc.ImprimirTicket(printerName);

                    //Imprime el report
                    Impresor imp2 = new winRdlc2.Impresor();
                    String printerName2 = Impresor.ImpresoraPredeterminada();
                    imp2.Imprime(LRT, 0, printerName2);
                    CrearTiket cc2 = new CrearTiket();

                    cc2.ImprimirTicket(printerName2);
                }
                else
                {
                    //Imprime el report
                    Impresor imp2 = new winRdlc2.Impresor();
                    String printerName2 = Impresor.ImpresoraPredeterminada();
                    imp2.Imprime(LRT, 0, printerName2);
                    CrearTiket cc2 = new CrearTiket();

                    cc2.ImprimirTicket(printerName2);

                    this.Close();

                }


            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static async Task CargarVarialesDatosEmpresa()
        {
            Sede objCS = new Sede();
            objCS =await ControladorSede.ConsultaXIdEmpresa(VariablesPublicas.IdEmpresaLogueada);
            if (objCS != null)
            {
                VariablesPublicas.NombreEmpresa = objCS.nombreSede;
                VariablesPublicas.CC_NIT = "NIT : " + objCS.nit;
                VariablesPublicas.RepresentanteLegal = objCS.reprecentante;
                VariablesPublicas.Regimen = "REGIMEN " + objCS.regimen;
                VariablesPublicas.Direccion = objCS.direccion;
                VariablesPublicas.Telefono = objCS.telefono;
            }
        }
        public  async Task FacturaVentaPOS(int IdVenta)
        {
            try
            {
                List<R_DetalleVenta> ctx = new List<R_DetalleVenta>();
                ctx =await ControladorDetalleVenta.FiltrarX_IdVenta(IdVenta);

                V_TablaVentas v_TablaVentas = new V_TablaVentas();
                v_TablaVentas =await ControladorVenta.ConsultaX_V_id(IdVenta);
                if (v_TablaVentas == null) return;

                int iva = Convert.ToInt32(v_TablaVentas.ivaVenta);

                dynamic dataSource = ctx;
                await CargarVarialesDatosEmpresa();
                ReportParameter myPar35 = new ReportParameter();
                if (VariablesPublicas.cufeFE != "")
                {
                    //en esta parte consultamos la autorizafion de la dian en facturacionelectronica
                    AutorizacionFacturacionElectronica autorizacion = new AutorizacionFacturacionElectronica();
                    autorizacion =await controladorAutorazacion_FE.consultarAutorizacion(VariablesPublicas.IdEmpresaLogueada);
                    if (autorizacion != null)
                    {
                        VariablesPublicas.PrefijoResolucion = autorizacion.prefijo;
                        VariablesPublicas.Resolucion = autorizacion.resolucion;
                        VariablesPublicas.FechaResolucion = autorizacion.fechaAvilitacion;
                        VariablesPublicas.RangoResolucion = autorizacion.rango;
                    }

                    string CUFE = "CUFE: " + VariablesPublicas.cufeFE;

                    VariablesPublicas.cufeFE = CUFE;

                    myPar35 = new ReportParameter("p_QR", new Uri("C:\\QR\\" + IdVenta + ".png").AbsoluteUri);



                }
                else
                {
                    myPar35 = new ReportParameter("p_QR", new Uri(VariablesPublicas.RutaImagenes + "\\Logo\\Logo.png").AbsoluteUri);

                    VariablesPublicas.cufeFE = "";
                }

                //LocalReport LRT = new LocalReport();
                //en esta parte cargamos el reporte
                if (VariablesPublicas.TipoImpresora == "POS 80mm")
                {
                    this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_FacturaVentaPOS80mm.rdlc";
                }
                if (VariablesPublicas.TipoImpresora == "POS 58mm")
                {
                    this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_FacturaVentaPOS58mm.rdlc";
                }
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetFacturaVenta", dataSource));
                //ahora le avilitamos la imagen
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                //ahora creamos los parametros de la cabezera
                string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                ReportParameter myPar = new ReportParameter("P_NombreEmpresa", VariablesPublicas.NombreEmpresa);
                this.reportViewer1.LocalReport.SetParameters(myPar);
                ReportParameter myPar2 = new ReportParameter("P_NIT", VariablesPublicas.CC_NIT);
                this.reportViewer1.LocalReport.SetParameters(myPar2);
                ReportParameter myPar3 = new ReportParameter("P_Reprecentante", "");
                this.reportViewer1.LocalReport.SetParameters(myPar3);
                ReportParameter myPar4 = new ReportParameter("P_Direccion", VariablesPublicas.Direccion);
                this.reportViewer1.LocalReport.SetParameters(myPar4);
                ReportParameter myPar5 = new ReportParameter("P_Telefono", VariablesPublicas.Telefono);
                this.reportViewer1.LocalReport.SetParameters(myPar5);
                ReportParameter myPar6 = new ReportParameter("P_Regimen", ""/*VariablesPublicas.Regimen*/);
                this.reportViewer1.LocalReport.SetParameters(myPar6);
                ReportParameter myPar7 = new ReportParameter("P_FacturaRecibo", /*v_TablaVentas.tipoFactura+  " " +VariablesPublicas.PrefijoResolucion+"-"*/"Orden Pedido N° " + v_TablaVentas.numeroVenta);
                this.reportViewer1.LocalReport.SetParameters(myPar7);
                ReportParameter myPar8 = new ReportParameter("P_Fecha", DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                this.reportViewer1.LocalReport.SetParameters(myPar8);


                string NombreCliente = "";
                string DocumentoCliente = "";
                string DireccionCliente = "";
                string TelefonoCliente = "";
                if (v_TablaVentas.nombreCliente != "--")
                {
                    Clientes cliente = new Clientes();
                    cliente =await ControladorClienteTienda.ConsultarX_Nombre(v_TablaVentas.nombreCliente);
                    if (cliente != null)
                    {
                        DocumentoCliente = cliente.documentoCliente;
                        DireccionCliente = cliente.direccionCliente;
                        TelefonoCliente = cliente.telefonoCliente;
                    }
                }
                else
                {
                    NombreCliente = "";
                    DocumentoCliente = "";
                    DireccionCliente = "";
                    TelefonoCliente = "";
                }
                ReportParameter myPar9 = new ReportParameter("P_Cliente", NombreCliente);
                this.reportViewer1.LocalReport.SetParameters(myPar9);
                ReportParameter myPar10 = new ReportParameter("P_DocumentoCliente", DocumentoCliente);
                this.reportViewer1.LocalReport.SetParameters(myPar10);
                ReportParameter myPar11 = new ReportParameter("P_DireccionCliente", DireccionCliente);
                this.reportViewer1.LocalReport.SetParameters(myPar11);

                //ReportParameter myPar12 = new ReportParameter("P_TelefonoCliente", TelefonoCliente);
                //LRT.SetParameters(myPar12);
                ReportParameter myPar13 = new ReportParameter("P_SubTotal", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.subtotalVenta)));
                this.reportViewer1.LocalReport.SetParameters(myPar13);
                ReportParameter myPar14 = new ReportParameter("P_Descuento", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.descuentoVenta)));
                this.reportViewer1.LocalReport.SetParameters(myPar14);
                ReportParameter myPar15 = new ReportParameter("P_Total", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.totalVenta)));
                this.reportViewer1.LocalReport.SetParameters(myPar15);
                ReportParameter myPar16 = new ReportParameter("P_FormaDePago", v_TablaVentas.tipoPago);
                this.reportViewer1.LocalReport.SetParameters(myPar16);
                ReportParameter myPar17 = new ReportParameter("P_Efectivo", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.efectivoVenta)));
                this.reportViewer1.LocalReport.SetParameters(myPar17);
                ReportParameter myPar18 = new ReportParameter("P_Cambio", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.cambioVenta)));
                this.reportViewer1.LocalReport.SetParameters(myPar18);
                //ReportParameter myPar19 = new ReportParameter("P_Logo", new Uri(VariablesPublicas.RutaImagenes + "\\Logo\\Logo.png").AbsoluteUri);
                //LRT.SetParameters(myPar19);
                ReportParameter myPar20 = new ReportParameter("P_TipoVenta", "Venta " + v_TablaVentas.tipoVenta);
                this.reportViewer1.LocalReport.SetParameters(myPar20);
                ReportParameter myPar21 = new ReportParameter("P_Leyenda", VariablesPublicas.LeyendaTiketPOS + " NOTA: " + VariablesPublicas.ObservacionFactura);
                this.reportViewer1.LocalReport.SetParameters(myPar21);
                ReportParameter myPar22 = new ReportParameter("P_AbonoTarjeta", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.abonoTarjeta)));
                this.reportViewer1.LocalReport.SetParameters(myPar22);

                ReportParameter myPar23 = new ReportParameter("pResolucion",/*"Resolución DIAN "+ VariablesPublicas.Resolucion)*/"");
                this.reportViewer1.LocalReport.SetParameters(myPar23);

                ReportParameter myPar24 = new ReportParameter("pFechaResolucion", ""/*"Autorizada el " +VariablesPublicas.FechaResolucion*/);
                this.reportViewer1.LocalReport.SetParameters(myPar24);

                ReportParameter myPar25 = new ReportParameter("pPrefijoResolucion", ""/*"Prefijo "+ VariablesPublicas.PrefijoResolucion+" Del: "+VariablesPublicas.RangoResolucion*/);
                this.reportViewer1.LocalReport.SetParameters(myPar25);

                ReportParameter myPar26 = new ReportParameter("pIVA", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(iva)));
                this.reportViewer1.LocalReport.SetParameters(myPar26);

                this.reportViewer1.LocalReport.SetParameters(myPar35);


                ReportParameter myPar36 = new ReportParameter("p_CUFE", VariablesPublicas.cufeFE);
                this.reportViewer1.LocalReport.SetParameters(myPar36);


                MostrarReporte();


            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Rutero(string vendedor, string dia,List<V_Rutero> rutero)
        {
            try
            {
                if (rutero == null)
                {
                    return;
                }



                dynamic dataSource = rutero;
                CargarVarialesDatosEmpresa();
                //en esta parte cargamos el reporte 

                //System.Environment.CurrentDirectory 
                //"G:\\Mi unidad\\app"
                this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_Rutero.rdlc";

                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Rutero", dataSource));


                //ahora le avilitamos la imagen
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                //ahora creamos los parametros de la cabezera
                string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                ReportParameter myPar = new ReportParameter("p_nombreVendedor", vendedor);
                this.reportViewer1.LocalReport.SetParameters(myPar);
                ReportParameter myPar2 = new ReportParameter("p_diaRutero", dia);
                this.reportViewer1.LocalReport.SetParameters(myPar2);

                MostrarReporte();

            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task Alistamiento(List<SelectAlistamiento_Result> lista ,int idVentadedor,int idEstado,string vendedor,DateTime fecha,string total)
        {
            try
            {
                dynamic dataSource = lista;
                await CargarVarialesDatosEmpresa();
                //en esta parte cargamos el reporte 

                this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_Alistamiento.rdlc";

                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_ConsolidadoPedido", dataSource));

                //ahora le avilitamos la imagen
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                //ahora creamos los parametros de la cabezera
                string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                ReportParameter myPar = new ReportParameter("p_vendedor", vendedor);
                this.reportViewer1.LocalReport.SetParameters(myPar);

                ReportParameter myPar1 = new ReportParameter("p_fecha", fecha.ToLongDateString());
                this.reportViewer1.LocalReport.SetParameters(myPar1);

                ReportParameter myPar2 = new ReportParameter("p_total", total);
                this.reportViewer1.LocalReport.SetParameters(myPar2);

                MostrarReporte();

            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task ListaPedidos(int estado, int idVendedor_frm, string vendedor, DateTime fecha, string total)
        {
            try
            {
                List<V_Pedido> list = new List<V_Pedido>();
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    list =await controladorPedidos.Filtrar_estado(estado, idVendedor_frm, fecha);
                }
                dynamic dataSource = list;
                //en esta parte cargamos el reporte 

                this.reportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_ListaPedidos.rdlc";

                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Pedidos", dataSource));

                //ahora le avilitamos la imagen
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                //ahora creamos los parametros de la cabezera
                string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                ReportParameter myPar = new ReportParameter("p_vendedor", vendedor);
                this.reportViewer1.LocalReport.SetParameters(myPar);

                ReportParameter myPar1 = new ReportParameter("p_fecha", fecha.ToLongDateString());
                this.reportViewer1.LocalReport.SetParameters(myPar1);

                ReportParameter myPar2 = new ReportParameter("p_total", total);
                this.reportViewer1.LocalReport.SetParameters(myPar2);

                MostrarReporte();

            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

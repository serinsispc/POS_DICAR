using DAL.Controladores;
using DAL.Modelo;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using winRdlc2;
using System.Windows.Forms;
using Invenpol_Parqueadero_Motos.Clases;
using System.Threading.Tasks;

namespace SERINSI_PC.Clases.TiketPOS
{
    public class ClassImprimirDirecto
    {
        public static Form MdiParent { get; private set; }
        public  static async Task CargarVarialesDatosEmpresa()
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
                VariablesPublicas.Telefono = "TEL.: " + objCS.telefono+" - "+objCS.celular;
                VariablesPublicas.PrefijoResolucion = objCS.prefijoFectura;
            }
        }
        public static async Task FacturaVentaPOS(int IdVenta)
        {
            try
            {
                List<R_DetalleVenta> ctx = new List<R_DetalleVenta>();
                ctx =await ControladorDetalleVenta.FiltrarX_IdVenta(IdVenta);

                V_TablaVentas v_TablaVentas = new V_TablaVentas();
                v_TablaVentas =await ControladorVenta.ConsultaX_V_id(IdVenta);
                if (v_TablaVentas == null) return;

                int iva =Convert.ToInt32(v_TablaVentas.ivaVenta);

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

                LocalReport LRT = new LocalReport();
                //en esta parte cargamos el reporte
                if (VariablesPublicas.TipoImpresora == "POS 80mm")
                {
                    LRT.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_FacturaVentaPOS80mm.rdlc";
                }
                if (VariablesPublicas.TipoImpresora == "POS 58mm")
                {
                    LRT.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_FacturaVentaPOS58mm.rdlc";
                }
                LRT.DataSources.Add(new ReportDataSource("DataSetFacturaVenta", dataSource));
                //ahora le avilitamos la imagen
                LRT.EnableExternalImages = true;
                //ahora creamos los parametros de la cabezera
                string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                ReportParameter myPar = new ReportParameter("P_NombreEmpresa", VariablesPublicas.NombreEmpresa);
                LRT.SetParameters(myPar);
                ReportParameter myPar2 = new ReportParameter("P_NIT", VariablesPublicas.CC_NIT);
                LRT.SetParameters(myPar2);
                ReportParameter myPar3 = new ReportParameter("P_Reprecentante", "");
                LRT.SetParameters(myPar3);
                ReportParameter myPar4 = new ReportParameter("P_Direccion", VariablesPublicas.Direccion);
                LRT.SetParameters(myPar4);
                ReportParameter myPar5 = new ReportParameter("P_Telefono", VariablesPublicas.Telefono);
                LRT.SetParameters(myPar5);
                ReportParameter myPar6 = new ReportParameter("P_Regimen",  ""/*VariablesPublicas.Regimen*/);
                LRT.SetParameters(myPar6);
                ReportParameter myPar7 = new ReportParameter("P_FacturaRecibo", /*v_TablaVentas.tipoFactura+  " " +VariablesPublicas.PrefijoResolucion+"-"*/"Orden Pedido N° "+v_TablaVentas.numeroVenta);
                LRT.SetParameters(myPar7);
                ReportParameter myPar8 = new ReportParameter("P_Fecha", DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                LRT.SetParameters(myPar8);


                string NombreCliente = "";
                string DocumentoCliente = "";
                string DireccionCliente = "";
                string TelefonoCliente = "";
                if (v_TablaVentas.nombreCliente!= "--")
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
                LRT.SetParameters(myPar9);
                ReportParameter myPar10 = new ReportParameter("P_DocumentoCliente", DocumentoCliente);
                LRT.SetParameters(myPar10);
                ReportParameter myPar11 = new ReportParameter("P_DireccionCliente", DireccionCliente);
                LRT.SetParameters(myPar11);

                //ReportParameter myPar12 = new ReportParameter("P_TelefonoCliente", TelefonoCliente);
                //LRT.SetParameters(myPar12);
                ReportParameter myPar13 = new ReportParameter("P_SubTotal", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.subtotalVenta)));
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
                //ReportParameter myPar19 = new ReportParameter("P_Logo", new Uri(VariablesPublicas.RutaImagenes + "\\Logo\\Logo.png").AbsoluteUri);
                //LRT.SetParameters(myPar19);
                ReportParameter myPar20 = new ReportParameter("P_TipoVenta", "Venta " + v_TablaVentas.tipoVenta);
                LRT.SetParameters(myPar20);
                ReportParameter myPar21 = new ReportParameter("P_Leyenda", VariablesPublicas.LeyendaTiketPOS+" NOTA: "+VariablesPublicas.ObservacionFactura);
                LRT.SetParameters(myPar21);
                ReportParameter myPar22 = new ReportParameter("P_AbonoTarjeta", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.abonoTarjeta)));
                LRT.SetParameters(myPar22);

                ReportParameter myPar23 = new ReportParameter("pResolucion",/*"Resolución DIAN "+ VariablesPublicas.Resolucion)*/"");
                LRT.SetParameters(myPar23);

                ReportParameter myPar24 = new ReportParameter("pFechaResolucion",""/*"Autorizada el " +VariablesPublicas.FechaResolucion*/);
                LRT.SetParameters(myPar24);

                ReportParameter myPar25 = new ReportParameter("pPrefijoResolucion",""/*"Prefijo "+ VariablesPublicas.PrefijoResolucion+" Del: "+VariablesPublicas.RangoResolucion*/);
                LRT.SetParameters(myPar25);

                ReportParameter myPar26 = new ReportParameter("pIVA", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(iva)));
                LRT.SetParameters(myPar26);

               LRT.SetParameters(myPar35);

  
                ReportParameter myPar36 = new ReportParameter("p_CUFE", VariablesPublicas.cufeFE);
                LRT.SetParameters(myPar36);


                //Imprime el report
                Impresor imp = new winRdlc2.Impresor();
                String printerName = Impresor.ImpresoraPredeterminada();
                imp.Imprime(LRT, 0, printerName);
                CrearTiket cc = new CrearTiket();

                cc.ImprimirTicket(printerName);


            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task<bool> FacturaVentaCarta(int Copias, int IdVenta)
        {
            try
            {
                V_TablaVentas v_TablaVentas = new V_TablaVentas();
                v_TablaVentas =await ControladorVenta.ConsultaX_V_id(IdVenta);
                if (v_TablaVentas == null)
                {
                    return false;
                }


                int iva = Convert.ToInt32(v_TablaVentas.ivaVenta);

                List<R_DetalleVenta> ctx = new List<R_DetalleVenta>();
                ctx =await ControladorDetalleVenta.FiltrarX_IdVenta(IdVenta);

                dynamic dataSource = ctx;
                await CargarVarialesDatosEmpresa();
                LocalReport LRT = new LocalReport();
                //en esta parte cargamos el reporte 
                //System.Environment.CurrentDirectory 
                LRT.ReportPath = Environment.CurrentDirectory + "\\Reportes\\Report_FacturaCarta.rdlc";

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
                ReportParameter myPar8 = new ReportParameter("pFechaFacturacion", Convert.ToDateTime(v_TablaVentas.fechaVenta).ToShortDateString());
                LRT.SetParameters(myPar8);

                Clientes cliente = new Clientes();
                string nombreCliente = " ";
                string documentoCliente = " ";
                string telfonoCliente = " ";
                string direccionCliente = " ";
                string barrio = " ";
                if (v_TablaVentas.idCliente > 0)
                {
                    cliente =await ControladorClienteTienda.ConsultarX_ID(v_TablaVentas.idCliente);
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
                    //ReportParameter myPar31 = new ReportParameter("pF1", "Fecha Vencimiento:");
                    //LRT.SetParameters(myPar31);

                    ReportParameter myPar29 = new ReportParameter("P_FechaVencimiento", Convert.ToDateTime(v_TablaVentas.fechaVenta).AddDays(30).ToShortDateString());
                    LRT.SetParameters(myPar29);

                    //ReportParameter myPar32 = new ReportParameter("pF2", " ");
                    //LRT.SetParameters(myPar32);

                    ReportParameter myPar33 = new ReportParameter("pFechaSuspencion", " ");
                    LRT.SetParameters(myPar33);
                }


                ReportParameter myPar30 = new ReportParameter("P_CorreoElectronico", VariablesPublicas.CorreoAdmin1);
                LRT.SetParameters(myPar30);

                ReportParameter myPar34 = new ReportParameter("pIVA", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(iva)));
                LRT.SetParameters(myPar34);

                //ReportParameter myPar35 = new ReportParameter("p_QR", new Uri("C:\\QR\\" + IdVenta + ".png").AbsoluteUri);
                //LRT.SetParameters(myPar35);


                for(int i = 0; i < Copias; i++)
                {
                    Impresor imp = new winRdlc2.Impresor();
                    String printerName = Impresor.ImpresoraPredeterminada();
                    imp.Imprime(LRT, 0, printerName);
                    CrearTiket cc = new CrearTiket();

                    cc.ImprimirTicket(printerName);
                }
                return true;    
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void AbrirCajon(int AbrirC)
        {
            try
            {
                LocalReport LRT = new LocalReport();
                //en esta parte cargamos el reporte
                LRT.ReportPath = System.Environment.CurrentDirectory + "\\Reportes\\Report_AbrirCajon.rdlc";
                //Imprime el report
                Impresor imp = new winRdlc2.Impresor();
                String printerName = Impresor.ImpresoraPredeterminada();
                imp.Imprime(LRT, 0, printerName);
                CrearTiket cc = new CrearTiket();

                cc.ImprimirTicket(printerName);
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

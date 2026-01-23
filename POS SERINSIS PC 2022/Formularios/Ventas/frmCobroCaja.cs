using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Modelo;
using DAL.Controladores;
using Invenpol_Parqueadero_Motos.Clases;
using DAPOS_Tienda.Clases;
using POS_SERINSIS_PC_2022.Reportes;
using Invenpol_Parqueadero_Motos.Formularios.Tiemda;
using Invenpol_Parqueadero_Motos.Clases.Servicios;
using SERINSI_PC.Clases.TiketPOS;
using Invenpol_Parqueadero_Motos.Procesos;
using System.Drawing.Drawing2D;
using winRdlc2;
using SERINSI_PC.Clases;
using System.Globalization;
using SERINSI_PC.Formularios.Orden_de_Servicio;
using DAL.Controlador;
using System.Management.Instrumentation;
using System.Security.Policy;
using QRCoder;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.WinForms;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;
using Warning = Microsoft.Reporting.Map.WebForms.BingMaps.Warning;
using System.IO.Compression;
using Newtonsoft.Json.Linq;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Model;
using System.Net;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using POS_SERINSIS_PC_2022.Formularios.Ventas;
using DAL;
using Task = System.Threading.Tasks.Task;

namespace SERINSI_PC.Formularios.Ventas
{
    public partial class frmCobroCaja : Form
    {
        public decimal SubTotalCosto;
        public int LLamado = 0;
        DateTime Fecha;
        public int IdVenta_frm;
        public int IdCliente;
        public string IdentificacionCliente;
        public string NombreCliente;
        public string DireccionCliente;
        public string TelefonoCliente;
        public int NumeroFacturaRecibo;
        public int ConsecutivoVenta;
        public decimal SubTotal;
        public decimal Descuento = 0;
        public decimal Domicilio = 0;
        public decimal Total;
        public decimal Saldo = 0;
        decimal AbonoTarjeta = 0;
        public decimal Efectivo = 0;
        public decimal ValorIva = 0;
        decimal Cambio = 0;
        int IdCredito;
        public int CajaMadre;
        string FacturaRecibo;
        string ContadoCreditoDomicilio;
        string EfectivoTargeta;
        DateTime FechaVencimeinto;
        string FechaVo;

        public decimal costoTotalVenta_frm = 0;
        decimal utilidadTotalVenta_frm = 0;
        public object NumeroRecibo { get; private set; }

        public frmCobroCaja()
        {
            InitializeComponent();
        }

        private void frmCobroCaja_Load(object sender, EventArgs e)
        {
            //FacturaElectronica();

            //decimal subTotalIva = Convert.ToDecimal(SubTotal);
            //subTotalIva = subTotalIva / Convert.ToDecimal("1,19");
            //SubTotal = subTotalIva;
            //ValorIva = subTotalIva * Convert.ToDecimal("0,19");

            cmbMedioDePago.Items.Add("EFECTIVO");
            cmbMedioDePago.Items.Add("TARJETA");
            cmbMedioDePago.Items.Add("MIXTO");

            Saldo = SubTotal;

            MostrarValoresEnFormulario();
            VariablesPublicas.TipoFactura = "RECIBO";
            FacturaRecibo = "RECIBO";
            VariablesPublicas.FacturaRecibo = FacturaRecibo;
            btnImprimirRecibo.BackColor = Color.Green;
            btnImprimirFactura.BackColor = Color.Transparent;


            btnBorrarEfectivo.PerformClick();

            cmbMedioDePago.SelectedIndex = 0;

            cmbMedioDePago.Focus();
            IdCliente = VariablesPublicas.IdCliente;

            if (VariablesPublicas.FacturarPedido == true)
            {
                txtEfectivo.Text = Convert.ToString(Total);
                MostrarValoresEnFormulario();
                Guardar();
            }
        }
        private void MostrarValoresEnFormulario()
        {
            txtSubTotal.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToInt32(SubTotal));
            txtIVA.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToInt32(ValorIva));
            txtDescuento.Text = Convert.ToString(Descuento);
            txtDomicilio.Text = Convert.ToString(Domicilio);
            txtTotal.Text = "$ " + string.Format("{0:#,##0.##}", Total);
            txtAbonoTarjeta.Text = Convert.ToString(AbonoTarjeta);
            txtSaldo.Text = Convert.ToString(Convert.ToInt32(Saldo));
            txtEfectivo.Text = Convert.ToString(Efectivo);
            txtCambio.Text = "$ " + string.Format("{0:#,##0.##}", Cambio);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (txtDescuento.Text != "")
            {
                Descuento = Convert.ToInt32(txtDescuento.Text);
            }
            else
            {
                Descuento = 0;
            }
            Total = SubTotal - Descuento + ValorIva;
            Saldo = Total;
            Cambio = Efectivo - Saldo;
            MostrarValoresEnFormulario();
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            if (txtEfectivo.Text != "")
            {
                Efectivo = Convert.ToInt32(txtEfectivo.Text);
            }
            else
            {
                Efectivo = 0;
            }
            if (Efectivo >= Saldo)
            {
                Cambio = Efectivo - Saldo;
                MostrarValoresEnFormulario();
            }
        }
        private async Task Guardar()
        {
            if (cbMensualidad.Checked == true)
            {
                VariablesPublicas.Mensualidad = true;
            }
            else
            {
                VariablesPublicas.Mensualidad = false;
            }
            //en esta parte preguntamos si es un domiculio
            if (ContadoCreditoDomicilio == "DOMICILIO")
            {
                if (Domicilio == 0)
                {
                    if (MessageBox.Show("No sé a especificado el valor del domicilio." + Environment.NewLine
                        + Environment.NewLine + "¿Desea agregar un valor al domicilio?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        txtDomicilio.Focus();
                        return;
                    }
                }
            }


            if (cmbMedioDePago.Text == "TARJETA" && txtReferencia.Text == "")
            {
                if (cbContado.Checked == true)
                {
                    MessageBox.Show("No se a encontrado el número de referencia de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (cmbMedioDePago.Text == "MIXTO" && txtReferencia.Text == "")
            {
                if (cbContado.Checked == true)
                {
                    MessageBox.Show("No se a encontrado el número de referencia de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (cbContado.Checked == true)
            {
                if (Saldo > Convert.ToInt32(txtEfectivo.Text))
                {
                    MessageBox.Show("El efectivo no puede ser menos al total de la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (IdCliente == 0 && VariablesPublicas.FacturaRecibo=="FACTURA")
            {

                frmClienteTienda frm = new frmClienteTienda();
                AddOwnedForm(frm);
                frm.FormularioMadre = "cobroCaja";
                frm.IdVenta = IdVenta_frm;
                frm.ShowDialog();

            }
            if(IdCliente!=0)
            {
                int Boton;
                int IdRelacion;
                //en esta parte creamos la relacion de venta cliente
                R_VentaCliente objRVC = new R_VentaCliente();
                objRVC =await controladorRVentaCleinte.ConsultarRelacion(IdVenta_frm);
                if (objRVC != null)
                {
                    Boton = 1;
                    IdRelacion = objRVC.id;
                }
                else
                {
                    Boton = 0;
                    IdRelacion = 0;
                }
                //ahora creamos la relacion
                objRVC = new R_VentaCliente();
                objRVC.id = IdRelacion;
                objRVC.idVenta = IdVenta_frm;
                objRVC.idCliente = IdCliente;
                objRVC.idSede = VariablesPublicas.IdEmpresaLogueada;
                RespuestaCRUD sqlRelacion =await controladorRVentaCleinte.Crud(objRVC, Boton);
            }

            if (FacturaRecibo == "FACTURA")
            {
                if (IdCliente == 0)
                {
                    frmClienteTienda frm = new frmClienteTienda();
                    AddOwnedForm(frm);
                    frm.FormularioMadre = "cobroCaja";
                    frm.IdVenta = IdVenta_frm;
                    frm.ShowDialog();
                }
                //en esta parte hallamos el consecutivo de factura
                NumeroFacturaRecibo =await HallarConsecutivoFactura();
                if (NumeroFacturaRecibo == 0)
                {
                    NumeroFacturaRecibo =await HallarConsecutivoFactura();
                }
            }
            else
            {
                //en esta parte hallamos el consecutivo de recivo
                NumeroFacturaRecibo =await HallarConsecutivoRecibo();
                if (NumeroFacturaRecibo == 0)
                {
                    NumeroFacturaRecibo =await HallarConsecutivoRecibo();
                }
            }
            //creamos un objeto para la tabla venta
            TablaVentas objVenta = new TablaVentas();
            objVenta = await ControladorVenta.ConsultaX_id(IdVenta_frm);
            if (objVenta != null)
            {
                objVenta.fechaVenta = DateTime.Now;
                objVenta.tipoFactura = FacturaRecibo;
                objVenta.numeroVenta = NumeroFacturaRecibo;
                objVenta.descuentoVenta = Descuento;
                objVenta.ivaVenta = ValorIva;
                objVenta.abonoTarjeta = AbonoTarjeta;

                if (ContadoCreditoDomicilio == "CREDITO" || ContadoCreditoDomicilio == "DOMICILIO")
                {
                    if (ContadoCreditoDomicilio == "CREDITO")
                    {
                        if (txtDiasCredito.Text == "")
                        {
                            MessageBox.Show("Debe de especificar la cantidad de días para el crédito", "Dias Credito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        FechaVencimeinto = DateTime.Today.AddDays(Convert.ToInt32(txtDiasCredito.Text));
                        objVenta.diasCredito = Convert.ToInt32(txtDiasCredito.Text);
                        objVenta.fechaVencimiento = Convert.ToString(FechaVencimeinto);
                        FechaVo = FechaVencimeinto.ToShortDateString();
                    }
                    else
                    {
                        txtDiasCredito.Text = "0";
                        FechaVo = "";
                    }

                    Cambio = 0;
                    objVenta.efectivoVenta = 0;
                    objVenta.cambioVenta = 0;
                    objVenta.estadoVenta = "PENDIENTE";
                }
                else
                {
                    objVenta.efectivoVenta = Efectivo;
                    objVenta.cambioVenta = Cambio;
                    objVenta.estadoVenta = "CANCELADO";
                    objVenta.diasCredito = 0;

                    txtDiasCredito.Text = "";
                    FechaVo = "";
                }

                objVenta.tipoVenta = ContadoCreditoDomicilio;
                objVenta.tipoPago = EfectivoTargeta;
                if (txtReferencia.Text != "")
                {
                    objVenta.numeroReferenciaPago = txtReferencia.Text;
                }
                else
                {
                    objVenta.numeroReferenciaPago = "0";
                }
                if (objVenta.diasCredito == 0)
                {
                    objVenta.fechaVencimiento = Convert.ToDateTime(objVenta.fechaVenta).AddDays(30).ToShortDateString();
                }
                else
                {
                    int dias = Convert.ToInt32(objVenta.diasCredito);
                    DateTime fve = Convert.ToDateTime(objVenta.fechaVenta);
                    fve = fve.AddDays(dias);
                    objVenta.fechaVencimiento = fve.ToShortDateString();
                }
                objVenta.idBaseCaja = VariablesPublicas.IdBaseActiva;
                objVenta.IdSede = VariablesPublicas.IdEmpresaLogueada;
                objVenta.observacionVenta = VariablesPublicas.ObservacionFactura;
                //enbiamos el objeto al controlador
                bool Respuesta =await ControladorVenta.Crud(objVenta, 1);
                if (Respuesta == true)
                {
                    await FinalizarVenta();
                }
            }

        }
        private async Task FinalizarVenta()
        {
            //cambiamos el estado de la relacion venta usuario
            R_VentaUsuario objRVU = new R_VentaUsuario();
            objRVU =await controladorRVentarUsuario.Consultar_IdUsuario_IdVenta(VariablesPublicas.IdUsuarioLogueado, IdVenta_frm, 1);
            if (objRVU != null)
            {
                objRVU.estado = 0;
                RespuestaCRUD sqlRVU =await controladorRVentarUsuario.CrearEditarEliminarR_VentaUsuario(objRVU, 1);
            }


            if (VariablesPublicas.FacturarPedido == true)
            {
                V_TablaVentas objVentas = new V_TablaVentas();
                objVentas =await ControladorVenta.ConsultaX_V_id(IdVenta_frm);
                if (objVentas != null)
                {
                    IdVenta_frm = objVentas.id;
                    if (VariablesPublicas.TipoImpresora == "Carta")
                    {
                        if (cbMensualidad.Checked == true) VariablesPublicas.Mensualidad = true;
                        await SeleccionarVenta(IdVenta_frm);
                        await ClassImprimirDirecto.FacturaVentaCarta(2,IdVenta_frm);
                    }
                    else
                    {
                         await ClassImprimirDirecto.FacturaVentaPOS(IdVenta_frm);
                    }
                }
            }
            else
            {

                if (VariablesPublicas.FacturaRecibo == "FACTURA")
                {
                    if (VariablesPublicas.FE_Enviada == true)
                    {
                        if (MessageBox.Show("Desea Imprimir el factura?...", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            V_TablaVentas objVentas = new V_TablaVentas();
                            objVentas =await ControladorVenta.ConsultaX_V_id(IdVenta_frm);
                            if (objVentas != null)
                            {
                                IdVenta_frm = objVentas.id;
                                if (VariablesPublicas.TipoImpresora == "Carta")
                                {
                                    if (cbMensualidad.Checked == true) VariablesPublicas.Mensualidad = true;
                                    await SeleccionarVenta(IdVenta_frm);
                                    frmReporte frm = new frmReporte();
                                    AddOwnedForm(frm);
                                    await frm.FacturaVentaCarta(0, IdVenta_frm);
                                    frm.ShowDialog();
                                }
                                else
                                {
                                    await ClassImprimirDirecto.FacturaVentaPOS(IdVenta_frm);
                                }
                            }
                        }
                        else
                        {
                            if (VariablesPublicas.CajonMonedero == true)
                            {
                                ProcesosGlobal.AbreCajon(Convert.ToInt32(VariablesPublicas.CodigoCajonMonesero));
                            }
                        }
                    }
                }
                else
                {
                    
                    if (MessageBox.Show("Desea Imprimir el factura?...", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        V_TablaVentas objVentas = new V_TablaVentas();
                        objVentas =await ControladorVenta.ConsultaX_V_id(IdVenta_frm);
                        if (objVentas != null)
                        {
                            IdVenta_frm = objVentas.id;
                            if (VariablesPublicas.TipoImpresora == "Carta")
                            {
                                if (cbMensualidad.Checked == true) VariablesPublicas.Mensualidad = true;
                                await SeleccionarVenta(IdVenta_frm);
                                frmReporte frm = new frmReporte();
                                AddOwnedForm(frm);
                                await frm.FacturaVentaCarta(0, IdVenta_frm);
                                //frm.ShowDialog();
                            }
                            else
                            {
                                await ClassImprimirDirecto.FacturaVentaPOS(IdVenta_frm);
                            }
                        }
                    }
                    else
                    {
                        if (VariablesPublicas.CajonMonedero == true)
                        {
                            ProcesosGlobal.AbreCajon(Convert.ToInt32(VariablesPublicas.CodigoCajonMonesero));
                        }
                    }
                }
            }



            MessageBox.Show("Venta finalizada.", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //en esta parte cambiamos el estado del pedido
            R_PedidoVenta r_PedidoVenta = new R_PedidoVenta();
            r_PedidoVenta =await controladorR_PedidoVenta.Consultar_idVenta(IdVenta_frm);
            if (r_PedidoVenta != null)
            {
                Pedidos pedidos = new Pedidos();
                pedidos =await controladorPedidos.Consultar_guid(r_PedidoVenta.guidPedido);
                if (pedidos != null)
                {
                    pedidos.idEstadoPedido = 2;
                    RespuestaCRUD crud =await controladorPedidos.Crud(pedidos, 1);
                }
            }
            frmCajaTouch frm_caja = Owner as frmCajaTouch;
            frm_caja.txtGuidPedido.Text = "";
            IdCliente = 0;
            VariablesPublicas.IdCliente = 0;
            VariablesPublicas.cufeFE = "";
            VariablesPublicas.prefijoFE = "";
            VariablesPublicas.PrefijoResolucion = "";
            this.Close();
        }
        private async Task Enviar_correo(string factura, string nombre, string nit, string nombreCliente, string totalFactura, string correo, string rutaArchivo)
        {
            JObject Params = new JObject();
            Params.Add("FACTURA", factura);
            Params.Add("NOMBRE", nombre);
            Params.Add("NIT", nit);
            Params.Add("NOMBRECLIENTE", nombreCliente);
            Params.Add("TOTALFACTURA", totalFactura);

            bool gmail = SendEmail(Params, nit + ";" + nombre + ";" + factura + ";" + nombre, correo, nombre, rutaArchivo);
            if (gmail == true)
            {
                MessageBox.Show("Reporte enviado a " + correo);
                VariablesPublicas.FE_Enviada=true;
                await FinalizarVenta();
            }
        }
        public bool SendEmail(JObject Params, string titulo, string correo, string nombreRecector, string rutaArchivo)
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var apiInstance = new TransactionalEmailsApi();
                string SenderName = titulo;
                string SenderEmail = "sistemas@serinsispc.com";
                SendSmtpEmailSender Email = new SendSmtpEmailSender(SenderName, SenderEmail);
                string ToEmail = correo;
                string ToName = nombreRecector;
                SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);
                List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
                To.Add(smtpEmailTo);

                long? TemplateId = 9; // se coloca el id de la plantilla
                apiInstance.Configuration.ApiKey.Clear();
                var sibKey = Environment.GetEnvironmentVariable("SENDINBLUE_API_KEY");
if (string.IsNullOrWhiteSpace(sibKey))
    throw new Exception("Falta configurar la variable de entorno SENDINBLUE_API_KEY");

apiInstance.Configuration.ApiKey.Clear();
apiInstance.Configuration.ApiKey.Add("api-key", sibKey);

                string AttachmentUrl = null;
                string AttachmentName = System.IO.Path.GetFileName(rutaArchivo);

                Byte[] bytes = File.ReadAllBytes(rutaArchivo);
                String file = Convert.ToBase64String(bytes);

                string stringInBase64 = file;
                byte[] Content = System.Convert.FromBase64String(stringInBase64);

                SendSmtpEmailAttachment AttachmentContent = new SendSmtpEmailAttachment(url: AttachmentUrl, content: Content, name: AttachmentName);
                List<SendSmtpEmailAttachment> Attachment = new List<SendSmtpEmailAttachment>();
                Attachment.Add(AttachmentContent);

                var sendSmtpEmail = new SendSmtpEmail(Email, To, null, null, null, null, null, null, Attachment, null, TemplateId, Params, null);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
                return true;

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
              
            }
        }
        private void Crear_carpete(string nombreCarpeta)
        {
            string folderPath = @"c:\QR\" + nombreCarpeta;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine(folderPath);

            }
        }
        private string Crear_zip(string carpeta)
        {
            string folder = @"c:\QR\" + carpeta;
            string folderZip = @"c:\QR\" + carpeta + ".zip";

            ZipFile.CreateFromDirectory(folder, folderZip);

            return folderZip;
        }
        private void PDF(string data64,string carpeta,string nombre_pdf)
        {
            Arreglo = Convert.FromBase64String(data64);
            File.WriteAllBytes("C:\\QR\\" + carpeta + "\\" + nombre_pdf + ".pdf", Arreglo);
        }
        private async void Crear_pdf(string name_pdf, string carpeta)
        {
            try
            {
                V_TablaVentas v_TablaVentas = new V_TablaVentas();
                v_TablaVentas =await ControladorVenta.ConsultaX_V_id(IdVenta_frm);
                if (v_TablaVentas == null)
                {
                    return;
                }


                int iva = Convert.ToInt32(v_TablaVentas.ivaVenta);

                List<R_DetalleVenta> ctx = new List<R_DetalleVenta>();
                ctx =await ControladorDetalleVenta.FiltrarX_IdVenta(IdVenta_frm);

                dynamic dataSource = ctx;
                await CargarVarialesDatosEmpresa();
                //en esta parte cargamos el reporte 
                //System.Environment.CurrentDirectory 
                string nameReport = System.Environment.CurrentDirectory + "\\Reportes\\Report_FacturaCarta.rdlc";
                //LocalReport report = new LocalReport();

                var report = new LocalReport();

                report.ReportPath = nameReport;

                ReportParameter myPar = new ReportParameter("P_NombreEmpresa", VariablesPublicas.NombreEmpresa);
                ReportParameter myPar2 = new ReportParameter("P_NIT", VariablesPublicas.CC_NIT);
                ReportParameter myPar3 = new ReportParameter("P_Reprecentante", VariablesPublicas.RepresentanteLegal);
                ReportParameter myPar4 = new ReportParameter("P_Direccion", VariablesPublicas.Direccion);
                ReportParameter myPar5 = new ReportParameter("P_Telefono", VariablesPublicas.Telefono);
                ReportParameter myPar6 = new ReportParameter("P_Regimen", VariablesPublicas.Regimen);
                ReportParameter myPar7 = new ReportParameter("P_FacturaRecibo", VariablesPublicas.PrefijoResolucion + "-" + v_TablaVentas.numeroVenta);
                ReportParameter myPar8 = new ReportParameter("P_Fecha", Convert.ToDateTime(v_TablaVentas.fechaVenta).ToShortDateString());

                Clientes cliente = new Clientes();
                string nombreCliente = " ";
                string documentoCliente = " ";
                string telfonoCliente = " ";
                string direccionCliente = " ";
                string barrio = " ";
                if (VariablesPublicas.IdCliente > 0)
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
                ReportParameter myPar10 = new ReportParameter("P_DocumentoCliente", documentoCliente);
                ReportParameter myPar11 = new ReportParameter("P_DireccionCliente", direccionCliente);
                ReportParameter myPar12 = new ReportParameter("P_TelefonoCliente", Convert.ToString(telfonoCliente));
                ReportParameter myPar40 = new ReportParameter("p_Barrio", Convert.ToString(barrio));
                ReportParameter myPar13 = new ReportParameter("P_SubTotal", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.subtotalVenta - v_TablaVentas.ivaVenta)));
                ReportParameter myPar14 = new ReportParameter("P_Descuento", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.descuentoVenta)));
                ReportParameter myPar15 = new ReportParameter("P_Total", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.totalVenta)));
                ReportParameter myPar16 = new ReportParameter("P_FormaDePago", v_TablaVentas.tipoPago);
                ReportParameter myPar17 = new ReportParameter("P_Efectivo", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.efectivoVenta)));
                ReportParameter myPar18 = new ReportParameter("P_Cambio", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.cambioVenta)));
                ReportParameter myPar19 = new ReportParameter("P_Logo", new Uri(VariablesPublicas.RutaImagenes + "\\Logo\\Logo.png").AbsoluteUri);
                ReportParameter myPar20 = new ReportParameter("P_TipoVenta", v_TablaVentas.tipoVenta);
                ReportParameter myPar21 = new ReportParameter("P_Leyenda", v_TablaVentas.observacionVenta);
                ReportParameter myPar22 = new ReportParameter("P_AbonoTarjeta", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(v_TablaVentas.abonoTarjeta)));
                ReportParameter myPar23 = new ReportParameter("pResolucion", "Valor Número Autorización " + VariablesPublicas.Resolucion);
                ReportParameter myPar24 = new ReportParameter("pFechaResolucion", "Autorizada el " + VariablesPublicas.FechaResolucion);
                ReportParameter myPar25 = new ReportParameter("pPrefijoResolucion", "Prefijo " + VariablesPublicas.PrefijoResolucion + " Del: " + VariablesPublicas.RangoResolucion);
                string valorLetras = Conversores.NumeroALetras(Convert.ToDecimal(v_TablaVentas.totalVenta));
                ReportParameter myPar26 = new ReportParameter("pValorLetras", valorLetras.Replace("00 /100", "m/cte"));
                ReportParameter myPar27 = new ReportParameter("pTotalItems", Convert.ToString(ctx.Count));
                ReportParameter myPar28 = new ReportParameter("pVendedor", VariablesPublicas.NombreUsuarioActivo);




                report.DataSources.Add(new ReportDataSource("DataSetFacturaVenta", dataSource));


                //ahora le avilitamos la imagen
                report.EnableExternalImages = true;
                //ahora creamos los parametros de la cabezera
                string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


                report.SetParameters(myPar);
                report.SetParameters(myPar2);
                report.SetParameters(myPar3);
                report.SetParameters(myPar4);
                report.SetParameters(myPar5);
                report.SetParameters(myPar6);
                report.SetParameters(myPar7);
                report.SetParameters(myPar8);
                report.SetParameters(myPar9);
                report.SetParameters(myPar10);
                report.SetParameters(myPar11);
                report.SetParameters(myPar12);
                report.SetParameters(myPar40);
                report.SetParameters(myPar13);
                report.SetParameters(myPar14);
                report.SetParameters(myPar15);
                report.SetParameters(myPar16);
                report.SetParameters(myPar17);
                report.SetParameters(myPar18);
                report.SetParameters(myPar19);
                report.SetParameters(myPar20);
                report.SetParameters(myPar21);
                report.SetParameters(myPar22);
                report.SetParameters(myPar23);
                report.SetParameters(myPar24);
                report.SetParameters(myPar25);
                report.SetParameters(myPar26);
                report.SetParameters(myPar27);
                report.SetParameters(myPar28);

                if (VariablesPublicas.Mensualidad == true)
                {
                    ReportParameter myPar31 = new ReportParameter("pF1", "Fecha límite de pago:");
                    report.SetParameters(myPar31);

                    ReportParameter myPar29 = new ReportParameter("P_FechaVencimiento", Convert.ToDateTime(v_TablaVentas.fechaVencimiento).ToShortDateString());
                    report.SetParameters(myPar29);

                    ReportParameter myPar32 = new ReportParameter("pF2", "Fecha suspensión:");
                    report.SetParameters(myPar32);

                    ReportParameter myPar33 = new ReportParameter("pFechaSuspencion", Convert.ToDateTime(v_TablaVentas.fechaVencimiento).AddDays(5).ToShortDateString());
                    report.SetParameters(myPar33);
                }
                else
                {
                    ReportParameter myPar31 = new ReportParameter("pF1", "Fecha Vencimiento:");
                    report.SetParameters(myPar31);

                    ReportParameter myPar29 = new ReportParameter("P_FechaVencimiento", Convert.ToDateTime(v_TablaVentas.fechaVenta).AddDays(30).ToShortDateString());
                    report.SetParameters(myPar29);

                    ReportParameter myPar32 = new ReportParameter("pF2", " ");
                    report.SetParameters(myPar32);

                    ReportParameter myPar33 = new ReportParameter("pFechaSuspencion", " ");
                    report.SetParameters(myPar33);
                }


                ReportParameter myPar30 = new ReportParameter("P_CorreoElectronico", VariablesPublicas.CorreoAdmin1);
                report.SetParameters(myPar30);

                ReportParameter myPar34 = new ReportParameter("pIVA", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(iva)));
                report.SetParameters(myPar34);

                ReportParameter myPar35 = new ReportParameter("p_QR", new Uri("C:\\QR\\" + IdVenta_frm + ".png").AbsoluteUri);
                report.SetParameters(myPar35);



                string deviceInfo = @"<DeviceInfo>
                      <OutputFormat>PDF</OutputFormat>                      
                      <EmbedFonts>None</EmbedFonts>
                    </DeviceInfo>";

                byte[] bytes = report.Render("PDF", deviceInfo);

                string nameFileGenerate = name_pdf + ".pdf";
                //Creatr PDF file on disk 

                File.WriteAllBytes("C:\\QR\\" + carpeta + "\\" + nameFileGenerate, bytes);

            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task CargarVarialesDatosEmpresa()
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
        private void Crear_xml(string data64, string nombre_xml, string carpeta)
        {
            Arreglo = Convert.FromBase64String(data64);
            File.WriteAllBytes("C:\\QR\\" + carpeta + "\\" + nombre_xml + ".xml", Arreglo);
        }
        byte[] Arreglo;
        string ArchivoTexto;
        private void General_qr(string qr)
        {
            QRCodeGenerator qRGenerator = new QRCodeGenerator();
            QRCodeData qrDatos = qRGenerator.CreateQrCode(qr, QRCodeGenerator.ECCLevel.H);
            QRCode qrCodigo = new QRCode(qrDatos);

            Bitmap qrImagen = qrCodigo.GetGraphic(10, Color.Black, Color.White, null);
            pbImagen.Image = qrImagen;

            MemoryStream ms = new MemoryStream();
            pbImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            Arreglo = ms.GetBuffer();
            ArchivoTexto = Convert.ToBase64String(Arreglo);

            guardarImagenCategoria(Arreglo, "C:\\QR\\", "", IdVenta_frm + ".png");

        }
        private void guardarImagenCategoria(byte[] Arreglo, string Ruta, string Carpeta, string Nombre)
        {
            if (File.Exists(Ruta + Carpeta + Nombre))
            {
                try
                {
                    File.Delete(Ruta + Carpeta + Nombre);
                    File.WriteAllBytes(Ruta + Carpeta + Nombre, Arreglo);
                }
                catch (Exception ex)
                {
                    string erros = ex.Message;
                }
            }
            else
            {
                try
                {
                    File.WriteAllBytes(Ruta + Carpeta + Nombre, Arreglo);
                }
                catch (Exception ex)
                {
                    string erros = ex.Message;
                }

            }
        }
        private async Task<int> HallarConsecutivoFactura()
        {
            //en esta parte hallamos el consecutivo de recivo
            ConsecutivoFactura consecutivoFactura = new ConsecutivoFactura();
            consecutivoFactura =await controladorNumeracionFactura.Consultar_x_IdVenta(IdVenta_frm);
            if (consecutivoFactura != null)
            {
                return consecutivoFactura.id;
            }
            else
            {
                consecutivoFactura = new ConsecutivoFactura();
                consecutivoFactura.id = 0;
                consecutivoFactura.idVenta = IdVenta_frm;
                RespuestaCRUD crud =await controladorNumeracionFactura.crud(consecutivoFactura, 0);
                if (crud.estado == true)
                {
                    return 0;
                }
                return 0;
            }
        }
        private async Task<int> HallarConsecutivoRecibo()
        {
            //en esta parte hallamos el consecutivo de recivo
            ConsecutivoRecibo consecutivoRecibo = new ConsecutivoRecibo();
            consecutivoRecibo =await controladorNumeracionRecibo.Consultar_x_IdVenta(IdVenta_frm);
            if (consecutivoRecibo != null)
            {
                return consecutivoRecibo.id;
            }
            else
            {
                consecutivoRecibo = new ConsecutivoRecibo();
                consecutivoRecibo.id = 0;
                consecutivoRecibo.idVenta = IdVenta_frm;
                RespuestaCRUD crud =await controladorNumeracionRecibo.crud(consecutivoRecibo, 0);
                if (crud.estado == true)
                {
                    return 0;
                }
                return 0;
            }
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            await Guardar();
        }
        private async Task SeleccionarVenta(int Consecutivo)
        {
            V_TablaVentas objTV = new V_TablaVentas();
            objTV =await ControladorVenta.ConsultaX_V_id(IdVenta_frm);
            if (objTV != null)
            {

                IdVenta_frm = objTV.id;
                Fecha = Convert.ToDateTime(objTV.fechaVenta);
                FacturaRecibo = objTV.tipoFactura;
                ContadoCreditoDomicilio = objTV.tipoVenta;
                NumeroFacturaRecibo = Convert.ToInt32(objTV.numeroVenta);
                SubTotal = Convert.ToInt32(objTV.subtotalVenta);
                Descuento = Convert.ToInt32(objTV.descuentoVenta);
                Total = Convert.ToInt32(objTV.totalVenta);
                EfectivoTargeta = objTV.tipoPago;
                Efectivo = Convert.ToInt32(objTV.efectivoVenta);
                Cambio = Convert.ToInt32(objTV.cambioVenta);

                if (ContadoCreditoDomicilio != "CONTADO" || FacturaRecibo == "FACTURA")
                {
                    R_VentaCliente objRVC = new R_VentaCliente();
                    objRVC =await controladorRVentaCleinte.ConsultarRelacion(IdVenta_frm);
                    if (objRVC != null)
                    {
                        IdCliente = objRVC.idCliente;
                    }

                    Clientes objCliente = new Clientes();
                    objCliente = await ControladorClienteTienda.ConsultarX_ID(IdCliente);
                    if (objCliente != null)
                    {
                        NombreCliente = objCliente.nombreCliente;
                        IdentificacionCliente = objCliente.documentoCliente;
                        TelefonoCliente = objCliente.telefonoCliente;
                        DireccionCliente = objCliente.direccionCliente;
                    }
                }
            }
        }
        private void btnVillete100mil_Click(object sender, EventArgs e)
        {
            Efectivo = Efectivo + 100000;
            txtEfectivo.Text = Convert.ToString(Efectivo);
        }
        private void btnVillete50mil_Click(object sender, EventArgs e)
        {
            Efectivo = Efectivo + 50000;
            txtEfectivo.Text = Convert.ToString(Efectivo);
        }
        private void btnVillete20mil_Click(object sender, EventArgs e)
        {
            Efectivo = Efectivo + 20000;
            txtEfectivo.Text = Convert.ToString(Efectivo);
        }
        private void btnVillete10mil_Click(object sender, EventArgs e)
        {
            Efectivo = Efectivo + 10000;
            txtEfectivo.Text = Convert.ToString(Efectivo);
        }
        private void btnVillete5mil_Click(object sender, EventArgs e)
        {
            Efectivo = Efectivo + 5000;
            txtEfectivo.Text = Convert.ToString(Efectivo);
        }
        private void btnVillete2mil_Click(object sender, EventArgs e)
        {
            Efectivo = Efectivo + 2000;
            txtEfectivo.Text = Convert.ToString(Efectivo);
        }
        private void btnVilleteMil_Click(object sender, EventArgs e)
        {
            Efectivo = Efectivo + 1000;
            txtEfectivo.Text = Convert.ToString(Efectivo);
        }
        private void btnMonedaMil_Click(object sender, EventArgs e)
        {
            Efectivo = Efectivo + 1000;
            txtEfectivo.Text = Convert.ToString(Efectivo);
        }
        private void btnMoneda500_Click(object sender, EventArgs e)
        {
            Efectivo = Efectivo + 500;
            txtEfectivo.Text = Convert.ToString(Efectivo);
        }
        private void btnMoneda200_Click(object sender, EventArgs e)
        {
            Efectivo = Efectivo + 200;
            txtEfectivo.Text = Convert.ToString(Efectivo);
        }
        private void btnMoneda100_Click(object sender, EventArgs e)
        {
            Efectivo = Efectivo + 100;
            txtEfectivo.Text = Convert.ToString(Efectivo);
        }
        private void btnMoneda50_Click(object sender, EventArgs e)
        {
            Efectivo = Efectivo + 50;
            txtEfectivo.Text = Convert.ToString(Efectivo);
        }
        private void btnBorrarEfectivo_Click(object sender, EventArgs e)
        {
            Efectivo = 0;
            txtEfectivo.Text = Convert.ToString(Efectivo);
            Cambio = Efectivo - Saldo;
            MostrarValoresEnFormulario();
            txtEfectivo.Focus();
        }
        private void cbContado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbContado.Checked == true)
            {
                panelVilletes.Enabled = true;
                cbCredito.Checked = false;
                cbDomicilio.Checked = false;
                txtDomicilio.Enabled = false;
                Domicilio = 0;
                ContadoCreditoDomicilio = "CONTADO";
            }
        }
        private void cbCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCredito.Checked == true)
            {
                txtDiasCredito.Visible = true;
                TexDiasCreditos.Visible = true;
                txtEfectivo.Text = Convert.ToString(0);
                panelVilletes.Enabled = false;
                cbContado.Checked = false;
                cbDomicilio.Checked = false;
                txtEfectivo.Enabled = false;
                txtDomicilio.Enabled = false;
                Domicilio = 0;
                if (IdCliente == 0)
                {
                    frmClienteTienda frm = new frmClienteTienda();
                    AddOwnedForm(frm);
                    frm.FormularioMadre = "cobroCaja";
                    frm.IdVenta = IdVenta_frm;
                    frm.ShowDialog();
                    Efectivo = 0;
                    ContadoCreditoDomicilio = "CREDITO";
                }
            }
        }
        private void btnImprimirRecibo_Click(object sender, EventArgs e)
        {
            VariablesPublicas.TipoFactura = "RECIBO";
            FacturaRecibo = VariablesPublicas.TipoFactura;
            btnImprimirRecibo.BackColor = Color.Green;
            btnImprimirFactura.BackColor = Color.Transparent;
            btnGuardar.Focus();
        }
        private void btnImprimirFactura_Click(object sender, EventArgs e)
        {
            VariablesPublicas.TipoFactura = "FACTURA";
            FacturaRecibo = VariablesPublicas.TipoFactura;
            btnImprimirFactura.BackColor = Color.Green;
            btnImprimirRecibo.BackColor = Color.Transparent;
            btnGuardar.Focus();
        }
        private void txtDescuento_Enter(object sender, EventArgs e)
        {
            frmTecladoNumericoDescuento frm = new frmTecladoNumericoDescuento();
            AddOwnedForm(frm);
            frm.Titulo.Text = "Descuento";
            frm.Numero = Descuento;
            frm.ShowDialog();
            txtEfectivo.Focus();
        }
        private void cbDomicilio_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDomicilio.Checked == true)
            {
                txtEfectivo.Text = Convert.ToString(0);
                panelVilletes.Enabled = false;
                cbContado.Checked = false;
                cbCredito.Checked = false;
                txtEfectivo.Enabled = false;
                txtDomicilio.Enabled = true;
                if (IdCliente == 0)
                {
                    //EN ESTA PARTE llamamos el formulario de recopila el valordel domicilio
                    frmClienteTienda frm = new frmClienteTienda();
                    AddOwnedForm(frm);
                    frm.FormularioMadre = "cobroCaja";
                    frm.ShowDialog();
                    Efectivo = 0;
                    ContadoCreditoDomicilio = "DOMICILIO";
                }
                else
                {
                    Efectivo = 0;
                    ContadoCreditoDomicilio = "DOMICILIO";
                }
            }
        }
        private void txtDomicilio_TextChanged(object sender, EventArgs e)
        {
            if (txtDomicilio.Text != "")
            {
                Domicilio = Convert.ToInt32(txtDomicilio.Text);
            }
            else
            {
                Domicilio = 0;
            }
            SubTotal = SubTotal + Domicilio;
            Total = SubTotal - Descuento + ValorIva;
            Cambio = Efectivo - Total;
            MostrarValoresEnFormulario();
        }

        private void txtDomicilio_Enter(object sender, EventArgs e)
        {
            frmTecladoNumericoDescuento frm = new frmTecladoNumericoDescuento();
            AddOwnedForm(frm);
            frm.Titulo.Text = "Domicilio";
            frm.Numero = Domicilio;
            frm.ShowDialog();
            txtEfectivo.Focus();
        }
        private void cmbMedioDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMedioDePago.Text != "")
            {
                if (cmbMedioDePago.Text == "EFECTIVO")
                {
                    EfectivoTargeta = "EFECTIVO";
                    txtAbonoTarjeta.Enabled = false;
                    txtReferencia.Enabled = false;
                    txtEfectivo.Enabled = true;
                    txtCambio.Enabled = true;

                    txtEfectivo.Focus();
                }
                if (cmbMedioDePago.Text == "TARJETA")
                {
                    EfectivoTargeta = "TARJETA";
                    txtAbonoTarjeta.Enabled = true;
                    txtReferencia.Enabled = true;
                    txtEfectivo.Enabled = false;
                    txtCambio.Enabled = false;

                    txtAbonoTarjeta.Text = Convert.ToString(Total);
                    txtReferencia.Focus();
                }
                if (cmbMedioDePago.Text == "MIXTO")
                {
                    EfectivoTargeta = "MIXTO";
                    txtAbonoTarjeta.Enabled = true;
                    txtReferencia.Enabled = true;
                    txtEfectivo.Enabled = true;
                    txtCambio.Enabled = true;

                    txtAbonoTarjeta.Focus();
                }
            }
        }
        private void txtAbonoTarjeta_TextChanged(object sender, EventArgs e)
        {
            if (txtAbonoTarjeta.Text != "")
            {
                AbonoTarjeta = Convert.ToDecimal(txtAbonoTarjeta.Text);
                if (AbonoTarjeta <= Total)
                {
                    Saldo = Total - AbonoTarjeta;
                    if (Saldo == 0)
                    {
                        txtEfectivo.Text = "0";
                        Cambio = 0;
                        txtCambio.Text = "0";
                    }
                    MostrarValoresEnFormulario();
                }
                else
                {
                    MessageBox.Show("al valor abono tarjena no puede ser mayor al total..", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void frmCobroCaja_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F1)
            {
                txtEfectivo.Focus();
            }
            if (e.KeyCode == Keys.F9)
            {
                frmTecladoNumericoDescuento frm = new frmTecladoNumericoDescuento();
                AddOwnedForm(frm);
                frm.Titulo.Text = "Descuento";
                frm.Numero = Descuento;
                frm.ShowDialog();
                txtEfectivo.Focus();
            }
            if (e.KeyCode == Keys.F12)
            {
                await Guardar();
            }
        }

        private void txtDescuento_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEfectivo.Focus();
            }
        }

        private async void txtEfectivo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtEfectivo.Text != "")
                {
                    Efectivo = Convert.ToInt32(txtEfectivo.Text);
                }
                else
                {
                    Efectivo = 0;
                }
                if (Efectivo >= Total)
                {
                    Cambio = Efectivo - Total;
                    MostrarValoresEnFormulario();
                    await Guardar();
                }
            }
        }
    }
}

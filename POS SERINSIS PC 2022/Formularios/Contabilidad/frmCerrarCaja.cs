using DAL.Controladores;
using DAL.Controladores.Contabilidad;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using Newtonsoft.Json.Linq;
using SERINSI_PC.Clases.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Model;
using POS_SERINSIS_PC_2022.Reportes;

namespace SERINSI_PC.Formularios.Contabilidad
{
    public partial class frmCerrarCaja : Form
    {
        int IdBaseCaja = 0;

        decimal valorBaseCaja = 0;
        decimal valorVentasTarjeta = 0;
        decimal valorVentasEfectivo = 0;
        decimal valorPagoCreditoTarjeta = 0;
        decimal valorPagoCreditoEfectivo = 0;

        decimal valorComprasEfectivo = 0;
        decimal valorComprasTarjeta=0;

        decimal valorGastosEfectivo = 0;
        decimal valorGastosTarjeta = 0;
        decimal valorProducido = 0;
        decimal valorTotalCaja = 0;
        decimal valorIngresosEfectivo = 0;
        decimal valorIngresosTarjeta = 0;
        decimal valorEgresosEfectivo = 0;
        decimal valorEgresoTargeta = 0;
        DateTime Apertura;
        DateTime Cierre;
        public bool Copia=false;
        public int UsuarioLogueado;
        public frmCerrarCaja()
        {
            InitializeComponent();
        }
        private void frmCerrarCaja_Load(object sender, EventArgs e)
        {
            BaseCaja objBase = new BaseCaja();
            objBase = ControladorBaseCaja.consultaBaseActiva("ACTIVA",VariablesPublicas.IdUsuarioLogueado,VariablesPublicas.IdEmpresaLogueada);
            if (objBase != null)
            {
                IdBaseCaja = objBase.id;
                Apertura = Convert.ToDateTime(objBase.fechaApertura);
                valorBaseCaja =Convert.ToInt32(objBase.valorBase);
                btnCerrarCaja.Enabled = true;
            }
            else
            {
                valorBaseCaja = 0;
                Apertura = DateTime.Now;
                MessageBox.Show("Aun no tiene una base activa.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtBaseCaja.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorBaseCaja));

            cargarPagoCC();
            cargarGastos();
            cargarVentas();
            cargarPagoCP();

            valorIngresosEfectivo = valorVentasEfectivo  + valorPagoCreditoEfectivo  ;
            valorIngresosTarjeta = valorVentasTarjeta + valorPagoCreditoTarjeta;
            valorEgresosEfectivo = valorComprasEfectivo  + valorGastosEfectivo ;
            valorEgresoTargeta = valorComprasTarjeta + valorGastosTarjeta;

            valorProducido = valorIngresosEfectivo - valorEgresosEfectivo;

            valorTotalCaja = valorBaseCaja + valorProducido;

            txtTotalIngresos.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorIngresosEfectivo));
            txtTotalEgresos.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorEgresosEfectivo));
            txtProducidoTotal.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorProducido));

            txtTotalEfectivoCaja.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorTotalCaja));
        }
        private void cargarGastos()
        {
            valorGastosEfectivo = ControladorGastos.TotalGastosBolsillo(1,VariablesPublicas.IdBaseActiva);
            txtGastosEfectivo.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorGastosEfectivo));
            valorGastosTarjeta = ControladorGastos.TotalGastosBolsillo(2, VariablesPublicas.IdBaseActiva);
            txtGastosTarjeta.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorGastosTarjeta));
        }
        private void cargarPagoCP()
        {
            valorComprasEfectivo = ControladorPagosCompras.pagoCPBolsilloFecha(1, VariablesPublicas.IdBaseActiva);
            txtComprasEfectivo.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorComprasEfectivo));
            valorComprasTarjeta = ControladorPagosCompras.pagoCPBolsilloFecha(2, VariablesPublicas.IdBaseActiva);
            txtComprasTarjeta.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorComprasTarjeta));

        }
        private void cargarPagoCC()
        {
            valorPagoCreditoEfectivo = ControladorPagosCreditoTienda.pagoCCBolsilloFecha( VariablesPublicas.IdBaseActiva,1);
            txtPagosCreditosEfectivo.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorPagoCreditoEfectivo));
            valorPagoCreditoTarjeta = ControladorPagosCreditoTienda.pagoCCBolsilloFecha(VariablesPublicas.IdBaseActiva, 2);
            txtPagosCreditoTarjeta.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorPagoCreditoTarjeta));
        }
        private void cargarVentas()
        {
            valorVentasEfectivo = ControladorVenta.HallarTotalVentasEfectivo("CONTADO",   "ANULADA",VariablesPublicas.IdBaseActiva);
            txtVentasEfectivo.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorVentasEfectivo));

            valorVentasTarjeta = ControladorVenta.HallarTotalVentasTarjeta("CONTADO", "ANULADA", VariablesPublicas.IdBaseActiva);
            txtVentasTarjeta.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorVentasTarjeta));
        }
        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de hacer el cierre de la caja.?", "Cerrar Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (IdBaseCaja > 0)
                {
                    BaseCaja objBase = new BaseCaja();
                    objBase = ControladorBaseCaja.consultarID(IdBaseCaja);
                    if (objBase != null)
                    {
                        Cierre = DateTime.Now;
                        objBase.fechaCierre = DateTime.Now;
                        objBase.estadoBase = "CERRADA";
                        bool sql = ControladorBaseCaja.CrearEditarEliminarBaseCaja(objBase, 1);
                        if (sql == true)
                        {

                            JObject Params = new JObject();

                            Params.Add("NOMBREEMPRESA",VariablesPublicas.NombreEmpresa);
                            Params.Add("CAJERO", VariablesPublicas.NombreUsuarioActivo);
                            Params.Add("APERTURACAJA",Convert.ToString(Apertura));
                            Params.Add("CIERRECAJA", Convert.ToString(Cierre));

                            Params.Add("BASECAJA", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorBaseCaja)));

                            Params.Add("PAGOSCREDITOSTARJETA", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorPagoCreditoTarjeta)));
                            Params.Add("PAGOSCREDITOSEFECTIVO", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorPagoCreditoEfectivo)));
                            Params.Add("VENTASTARJETA", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorVentasTarjeta)));
                            Params.Add("VENTASEFECTIVO", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorVentasEfectivo)));
                            Params.Add("COMPRASEFECTIVO", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorComprasEfectivo)));
                            Params.Add("COMPRASTARJETA", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorComprasTarjeta)));
                            Params.Add("GASTOSEFECTIVO", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorGastosEfectivo)));
                            Params.Add("GASTOSTARJETA", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorGastosTarjeta)));

                            Params.Add("TOTALINGRESOS", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorIngresosEfectivo)));
                            Params.Add("TOTALEGRESOS", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorEgresosEfectivo)));
                            Params.Add("PRODUCIDO", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorProducido)));

                            Params.Add("TOTALCAJA", "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(valorTotalCaja)));

                            if (VariablesPublicas.CorreoAdmin1 != "")
                            {
                                bool gmail = SendEmail(Params, "Cierre de caja", VariablesPublicas.CorreoAdmin1, VariablesPublicas.NombreEmpresa);
                                if (gmail == true)
                                {
                                    MessageBox.Show("Reporte enviado a " + VariablesPublicas.CorreoAdmin1);
                                }
                            }
                            if (VariablesPublicas.CorreoAdmin2 != "")
                            {
                                bool gmail = SendEmail(Params, "Cierre de caja", VariablesPublicas.CorreoAdmin2, VariablesPublicas.NombreEmpresa);
                                if (gmail == true)
                                {
                                    //MessageBox.Show("Reporte enviado a " + VariablesPublicas.CorreoAdmin2);
                                }
                            }
                            VariablesPublicas.ReporteImprimir = "";
                            frmReporte frm = new frmReporte();
                            AddOwnedForm(frm);

                            frm.ImprimirReporteCierreCaja(valorBaseCaja,
                                                          valorGastosEfectivo,
                                                          valorComprasEfectivo,
                                                          valorPagoCreditoEfectivo,
                                                          valorVentasEfectivo,
                                                          valorVentasTarjeta,
                                                          valorProducido,                                              
                                                          valorProducido,                                                          
                                                          Apertura,                                    
                                                          Cierre,       
                                                          VariablesPublicas.NombreUsuarioActivo);

                            frm.ShowDialog();
                            VariablesPublicas.IdBaseActiva = 0;
                            this.Close();

                            //en esta parte hallamos los movimientos de banco
                            movimientosBanco();
                            //en esta parte hallamos los movimientos de caja menor
                            movimientosCajaMejor();

                            btnCerrarCaja.Enabled = false;
                            VariablesPublicas.IdBaseActiva = 0;
                            this.Close();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Procesar Email
        /// </summary>
        /// <param name="emailEntry"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        public bool SendEmail(JObject Params, string titulo, string correo, string nombreRecector)
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

                long? TemplateId = 5; // se coloca el id de la plantilla
                apiInstance.Configuration.ApiKey.Clear();
                var sibKey = Environment.GetEnvironmentVariable("SENDINBLUE_API_KEY");
                if (string.IsNullOrWhiteSpace(sibKey))
                    throw new Exception("Falta configurar la variable de entorno SENDINBLUE_API_KEY");

                apiInstance.Configuration.ApiKey.Clear();
                apiInstance.Configuration.ApiKey.Add("api-key", sibKey);


                var sendSmtpEmail = new SendSmtpEmail(Email, To, null, null, null, null, null, null, null, null, TemplateId, Params, null);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void movimientosCajaMejor()
        {
            decimal comprasCajaMejor = ControladorPagosCompras.pagoCPBolsilloFecha(3,  VariablesPublicas.IdBaseActiva);
            decimal gastosCajaMenor = ControladorGastos.TotalGastosBolsillo(3, VariablesPublicas.IdBaseActiva);

            decimal egresoCajaMenor = comprasCajaMejor + gastosCajaMenor;

            GestionarLibroDiario(3, "cierre de caja", 0, egresoCajaMenor);
        }
        private void movimientosBanco()
        {
            decimal ventasBando = ControladorVenta.HallarTotalVentasTarjeta("CONTADO", "ANULADA",VariablesPublicas.IdBaseActiva);
            decimal creditosBanco = ControladorPagosCreditoTienda.pagoCCBolsilloFecha(VariablesPublicas.IdBaseActiva,2);
            decimal comprasBanco = ControladorPagosCompras.pagoCPBolsilloFecha(2, VariablesPublicas.IdBaseActiva);
            decimal gastosBanco = ControladorGastos.TotalGastosBolsillo(2,VariablesPublicas.IdBaseActiva);

            decimal ingresoBanco = ventasBando + creditosBanco;
            decimal egresoBanco = comprasBanco + gastosBanco;

            GestionarLibroDiario(2,"cierre de caja",ingresoBanco,0);
            GestionarLibroDiario(2, "cierre de caja", 0, egresoBanco);
        }
        private void GestionarLibroDiario(int Bolsillo,string Motivo,decimal Debe,decimal Haber)
        {
            //en esta parte agregamos el movimiento a la tabla libro diario
            LibroDiario objLibro = new LibroDiario();
            objLibro.id = 0;
            objLibro.fechaMovimiento = DateTime.Now;
            objLibro.idBolsillo = Bolsillo;
            objLibro.motivoMovimiento = Motivo;
            objLibro.debe = Debe;
            objLibro.haber = Haber;
            objLibro.idUsuario = VariablesPublicas.IdUsuarioLogueado;
            //en esta parte llamamos la funcion que nos trae el untimo saldo
            ClassSaldosLibroDiario.hallasUltimoSaldoLibro();
            if (Bolsillo == 1)
            {
                objLibro.saldoCaja = VariablesPublicas.SaldoCaja + Debe - Haber;
                objLibro.saldoBanco = VariablesPublicas.SaldoBanco;
                objLibro.saldoCajaMenor = VariablesPublicas.SaldoCajaMenor;
                objLibro.saldoTotal = VariablesPublicas.SaldoTotal + Debe - Haber;
            }
            if (Bolsillo == 2)
            {
                objLibro.saldoCaja = VariablesPublicas.SaldoCaja;
                objLibro.saldoBanco = VariablesPublicas.SaldoBanco + Debe - Haber;
                objLibro.saldoCajaMenor = VariablesPublicas.SaldoCajaMenor;
                objLibro.saldoTotal = VariablesPublicas.SaldoTotal + Debe - Haber;
            }
            if (Bolsillo == 3)
            {
                objLibro.saldoCaja = VariablesPublicas.SaldoCaja;
                objLibro.saldoBanco = VariablesPublicas.SaldoBanco;
                objLibro.saldoCajaMenor = VariablesPublicas.SaldoCajaMenor + Debe - Haber;
                objLibro.saldoTotal = VariablesPublicas.SaldoTotal + Debe - Haber;
            }
            bool sql2 = ControladorLibroDiario.CrearEditarEliminarLibroDiario(objLibro, 0);
            if (sql2 == true)
            {

               // this.Close();
            }
        }
    }
}

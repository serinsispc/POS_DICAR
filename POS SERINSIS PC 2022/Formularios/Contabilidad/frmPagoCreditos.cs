using DAL.Controladores;
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
using SERINSI_PC.Formularios.Ventas;
using SERINSI_PC.Formularios.Contabilidad;
using Invenpol_Parqueadero_Motos.Clases;
using System.Security.Cryptography;
using DAL;

namespace Invenpol_Parqueadero_Motos.Formularios.Tiemda
{
    public partial class frmPagoCreditos : Form
    {
        public frmPagoCreditos()
        {
            InitializeComponent();
        }
        int Cambio = 0;
        int Efectivo = 0;
        int TotalAPagar = 0;
        int IdCliente_frm = 0;
        int IdDetalle = 0;
        string NombreCliente = "";
        string TelefonoCliente = "";
        int TotalCredito = 0;
        int TotalPagado = 0;
        int TotalPendiente = 0;
        int NumeroFactura = 0;
        int Saldo = 0;
        int TotalCreditosPendientes;
        decimal Sobrante = 0;
        int IdVenta_frm = 0;
        public string ReferenciaVenta = "";
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void frmPagoCreditos_Load(object sender, EventArgs e)
        {
            cargarBolsillo();
            await hallarTotalPendiente();
            LlenarDGCompleto();
            txtBuscadorCliente.Focus();
        }
        private void cargarBolsillo()
        {
            cmbBolsillo.ValueMember = "id";
            cmbBolsillo.DisplayMember = "nombreBolsillo";
            cmbBolsillo.DataSource = ControladorBilsillo.listaCompleta();
        }
        private async Task hallarTotalPendiente()
        {
            //en esta parte llenamos el total de los creditos pendientes
            TotalCreditosPendientes =await ControladorClienteTienda.SumarTotalCreditosPendientes();
            txtTotalCreditoPendiente.Text = "Total Pendiente: $ " + string.Format("{0:#,##0.##}", TotalCreditosPendientes);
        }
        private void LlenarDGCompleto()
        {
            dgBuscadroCliente.DataSource = ControladorClienteTienda.FiltarX_Pendiente(VariablesPublicas.IdEmpresaLogueada);
        }

        private void txtBuscadorCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscadorCliente.Text != "")
            {
                //dgBuscadroCliente.DataSource = ControladorClienteTienda.FiltarX_Pendiente_X_Nombre(txtBuscadorCliente.Text);
            }
        }

        private void txtBuscadorCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBuscadorCliente.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SeleccionarCliente();
                }
            }
        }
        private void SeleccionarCliente()
        {
            if (dgBuscadroCliente.RowCount > 0 && dgBuscadroCliente.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgBuscadroCliente.Rows[dgBuscadroCliente.CurrentRow.Index];
                IdCliente_frm = Convert.ToInt32(fila.Cells["idClienteCC"].Value);
                NombreCliente = Convert.ToString(fila.Cells["nombreClienteCC"].Value);
                TelefonoCliente = Convert.ToString(fila.Cells["telefonoClienteCC"].Value);
                TotalCredito = Convert.ToInt32(fila.Cells["TotalCC"].Value);
                TotalPagado = Convert.ToInt32(fila.Cells["pagadoCC"].Value);
                TotalPendiente = Convert.ToInt32(fila.Cells["saldoCC"].Value);

                //ahora cargamos los txt
                txtNombreCliente.Text = NombreCliente;
                txtTotalCredito.Text = "$ " + string.Format("{0:#,##0.##}",Convert.ToDouble(TotalCredito));
                txtTotalPagado.Text = "$ " + string.Format("{0:#,##0.##}",Convert.ToDouble(TotalPagado));
                txtTotalPendiente.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(TotalPendiente));

                //en est parte llenamos el dg de productos cargados
                LlenarFacturas();

                txtValorAPagar.Focus();
            }
        }
        private void LlenarFacturas()
        {
            dgFacturasCargadas.DataSource = ControladorVenta.ListaFacturasCredito(IdCliente_frm,VariablesPublicas.IdEmpresaLogueada);
        }
        private void dgBuscadroCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarCliente();
        }

        private void dgBuscadroCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarCliente();
            }
        }

        private void dgProductosCargados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarFactura();
        }
        private void SeleccionarFactura()
        {
            if (dgFacturasCargadas.RowCount > 0 && dgFacturasCargadas.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgFacturasCargadas.Rows[dgFacturasCargadas.CurrentRow.Index];
                IdVenta_frm = Convert.ToInt32(fila.Cells["idVenta"].Value);
                //NumeroFactura = Convert.ToInt32(fila.Cells["numeroVenta"].Value);
            }
        }
        private async void btnPagar_Click(object sender, EventArgs e)
        {
            await Trasladar();
        }
        private async Task Trasladar()
        {
            DetalleVenta objDV = new DetalleVenta();
            objDV =await ControladorDetalleVenta.ConsultarX_IDDetalle(IdDetalle);
            if (objDV != null)
            {
                RespuestaCRUD sql =await ControladorDetalleVenta.GuardarEditarEliminar(objDV, 1);
                if (sql.estado == true)
                {
                    LlenarFacturas();
                }
            }
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            await Trasladar();
        }
        private void txtEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtEfectivo.Text != "")
            {
                Efectivo = Convert.ToInt32(txtEfectivo.Text);
                if (Efectivo >= TotalAPagar)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnPagarCredito.Enabled = true;
                        btnPagarCredito.Focus();
                    }
                }
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private async void btnPagarCredito_Click(object sender, EventArgs e)
        {
            if (txtValorAPagar.Text != "")
            {
                if (Convert.ToInt32(txtValorAPagar.Text) > TotalPendiente)
                {
                    MessageBox.Show("El valor a pagar ingresado no puede ser mayor al total pendiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //lo primero que hacemos es verificar que el valor a pagar sea mayor a 0
                if (Convert.ToInt32(txtValorAPagar.Text) <= 0)
                {
                    MessageBox.Show("El campo de valor a pagar no puede ser igual o menor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //En esta parte actualizamos el pago en la tabla de ventas.
                await ActualizarPagoVentas(Convert.ToInt32(txtValorAPagar.Text));
                ActualizarCredito();
                //ahora cargamos los txt
                txtNombreCliente.Text = "";
                txtTotalCredito.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(0));
                txtTotalPagado.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(0));
                txtTotalPendiente.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(0));
                txtSaldo.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(0));
                //en est parte llenamos el dg de productos cargados
                LlenarFacturas();
                //en esta otra parte llenamos el dg de productos a pagar
                LlenarDGCompleto();
                SeleccionarCliente();
                txtEfectivo.Text = "";
                txtValorAPagar.Text = "";
                txtBuscadorCliente.Focus();
                await hallarTotalPendiente();
            }
        }
        int IdVenta = 0;
        private async Task ActualizarPagoVentas(decimal ValorAPagar)
        {
            IdVenta = 0;
            if (MessageBox.Show("¿Está seguro de agregar el dinero de bolsillo "+ cmbBolsillo.Text +"?", "Bolsillo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //primero consultamos el id del cliente en la table ventas si tiene cargado una venta en estado pendiente, y traemos el valor pendiente.

            int fin = 1;
            for (int i = 0; i < fin; ++i)
            {
                decimal ValorIngresado = ValorAPagar;

                V_R_VentaCliente v_R_VentaCliente = new V_R_VentaCliente();
                v_R_VentaCliente = await ControladorVenta.ConsultarX_IdCleinte_EstadoVenta(IdCliente_frm, "PENDIENTE");
                if (v_R_VentaCliente != null)
                {
                    IdVenta = v_R_VentaCliente.id;
                    V_TablaVentas v_TablaVentas = new V_TablaVentas();
                    v_TablaVentas =await ControladorVenta.ConsultaX_V_id(IdVenta);
                    if (v_TablaVentas != null)
                    {
                       
                        if (v_TablaVentas.tipoPago == "TARJETA")
                        {
                            frmReferenciaTargeta frm = new frmReferenciaTargeta();
                            AddOwnedForm(frm);
                            frm.ShowDialog();
                            v_TablaVentas.numeroReferenciaPago = ReferenciaVenta;
                        }

                        if (v_TablaVentas.totalPendienteVenta <= ValorAPagar)
                        {
                            Sobrante = Convert.ToDecimal(ValorAPagar) - Convert.ToDecimal(v_TablaVentas.totalPendienteVenta);
                            ValorAPagar = ValorAPagar - Sobrante;
                        }
                        else
                        {
                            Sobrante = 0;
                        }
                        //lo primeo que hacemnos es agregar el pago a la tabla de pagos creditos
                        PagosCreditoTienda objPCT = new PagosCreditoTienda();
                        objPCT.id_pago_credito_tienda = 0;
                        objPCT.fecha_pago_credito_tienda = DateTime.Now;
                        objPCT.id_cliente_pago_credito_tienda = IdCliente_frm;
                        objPCT.idVentaPago = v_TablaVentas.id;
                        objPCT.valor_pago_credito_tienda = ValorAPagar;
                        objPCT.idBasecaja = VariablesPublicas.IdBaseActiva;
                        objPCT.idBolsillo = Convert.ToInt32(cmbBolsillo.SelectedValue);
                        objPCT.idSede = VariablesPublicas.IdEmpresaLogueada;
                        RespuestaCRUD sqlPago =await ControladorPagosCreditoTienda.Crear_Editar_Eliminar_PagoCreditoTienda(objPCT, 0);
                        if (sqlPago.estado == true)
                        {
                            //consultar si la venta queda con saldo pendiente
                            V_TablaVentas tv = new V_TablaVentas();
                            tv =await ControladorVenta.ConsultaX_V_id(IdVenta);
                            if (tv != null)
                            {
                                if (tv.totalPendienteVenta == 0)
                                {
                                    R_PedidoVenta r_PedidoVenta = new R_PedidoVenta();
                                    r_PedidoVenta = await controladorR_PedidoVenta.Consultar_idVenta(tv.id);
                                    if (r_PedidoVenta != null)
                                    {
                                        Pedidos pedidos = new Pedidos();
                                        pedidos =await controladorPedidos.Consultar_guid(r_PedidoVenta.guidPedido);
                                        if (pedidos != null)
                                        {
                                            pedidos.idEstadoPedido = 3;
                                            RespuestaCRUD crud =await controladorPedidos.Crud(pedidos, 1);
                                            if (crud.estado == true)
                                            {
                                                //cambiamos estado venta
                                                TablaVentas tablaVentas = new TablaVentas();
                                                tablaVentas =await ControladorVenta.ConsultaX_id(tv.id);
                                                if (tablaVentas != null)
                                                {
                                                    tablaVentas.estadoVenta = "CANCELADO";
                                                    bool crud_venta =await ControladorVenta.Crud(tablaVentas, 1);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            try
                            {
                                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                                {
                                    cn.EstadoVentaCancelado();
                                    cn.EstadoVentaPendiente();
                                    cn.EstadoVentaAnulado();
                                }
                            }
                            catch(Exception ex)
                            {
                                string error = ex.Message;
                            }
                        }
                    }
                }
                if (Sobrante > 0)
                {
                    ValorAPagar = Sobrante;
                    fin++;
                }
                else
                {
                    ValorAPagar = 0;
                }
            }            
        }
        private void ActualizarCredito()
        {
            TotalAPagar = Convert.ToInt32(txtValorAPagar.Text);
            TotalPagado = TotalPagado + TotalAPagar;
            TotalPendiente = TotalCredito - TotalPagado;
            txtTotalPagado.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(TotalPagado));
            txtTotalPendiente.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(TotalPendiente));
        }
        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            if (txtEfectivo.Text != "")
            {
                Efectivo = Convert.ToInt32(txtEfectivo.Text);
                Cambio = Efectivo - Convert.ToInt32(txtValorAPagar.Text);
            }
            else
            {
                Cambio = 0;
            }
            txtCambio.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(Cambio));
        }
        private void txtValorAPagar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtValorAPagar.Text != "")
                {
                    if (Convert.ToInt32(txtValorAPagar.Text) > 0)
                    {
                        txtEfectivo.Focus();
                    }
                }
            }
        }

        private void txtValorAPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void txtValorAPagar_TextChanged(object sender, EventArgs e)
        {
            if (txtValorAPagar.Text != "")
            {
                Saldo = TotalPendiente - Convert.ToInt32(txtValorAPagar.Text);
            }
            else
            {
                Saldo = 0;
            }
            txtSaldo.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(Saldo));
        }

        private async void label10_Click(object sender, EventArgs e)
        {
            SeleccionarFactura();
            frmVerPagosCredito frm = new frmVerPagosCredito();
            AddOwnedForm(frm);
            frm.dgVerPagos.DataSource = ControladorPagosCreditoTienda.FIltroXIdVenta(IdVenta_frm);
            frm.ShowDialog();

            cargarBolsillo();
            await hallarTotalPendiente();
            LlenarDGCompleto();
            txtBuscadorCliente.Focus();
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dgFacturasCargadas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarFactura();
            frmDetalleFacturaCredito frm = new SERINSI_PC.Formularios.Ventas.frmDetalleFacturaCredito();
            frm.IDVenta_frm = IdVenta_frm;
            frm.ShowDialog();
        }
    }
}

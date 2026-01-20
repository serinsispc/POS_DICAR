using DAL;
using DAL.Controladores;
using DAL.Controladores.Contabilidad;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using SERINSI_PC.Clases;
using SERINSI_PC.Formularios.Contabilidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Inventario
{
    public partial class frmCompraProveedor : Form
    {
        public frmCompraProveedor()
        {
            InitializeComponent();
        }
        int IdCompra_frm = 0;
        int TotalCompra = 0;
        int ValorPagado = 0;
        int Saldo = 0;
        int NumeroCompra = 0;
        int SaldoFinal = 0;
        int IdPago = 0;
        private void frmCompraProveedor_Load(object sender, EventArgs e)
        {
            CargarCMB();
            cargarDGCompras();
            seleccionarCompra();
        }
        private void PosicionDG()
        {
            try
            {
                dgListaCompras.Columns["idV"].DisplayIndex = 0;
                dgListaCompras.Columns["facturaCompraV"].DisplayIndex = 1;
                dgListaCompras.Columns["fechaCompraV"].DisplayIndex = 2;
                dgListaCompras.Columns["idProveedorV"].DisplayIndex = 3;
                dgListaCompras.Columns["documentoProveedorV"].DisplayIndex = 4;
                dgListaCompras.Columns["idSedeCompra"].DisplayIndex = 5;
                dgListaCompras.Columns["nombreProveedorV"].DisplayIndex = 6;
                dgListaCompras.Columns["subtotalCompraV"].DisplayIndex = 7;
                dgListaCompras.Columns["ivaCompraV"].DisplayIndex = 8;
                dgListaCompras.Columns["totalCompraV"].DisplayIndex = 9;
                dgListaCompras.Columns["valorPagadoCompraV"].DisplayIndex = 10;
                dgListaCompras.Columns["saldoCompraV"].DisplayIndex = 11;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        private void CargarCMB()
        {
            cmbTipoBosillo.ValueMember = "id";
            cmbTipoBosillo.DisplayMember = "nombreBolsillo";
            cmbTipoBosillo.DataSource = ControladorBilsillo.listaCompleta();
        }
        private void cargarDGCompras()
        {
            dgListaCompras.DataSource = ControladorCompra.listaComprasPendientes(VariablesPublicas.IdEmpresaLogueada,2);
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscador.Text != "")
            {
                dgListaCompras.DataSource = ControladorCompra.filtrarXProveedorSaldo(txtBuscador.Text);
            }
        }

        private void txtBuscador_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBuscador.Text != "")
            {
                if (e.KeyCode == Keys.Down)
                {
                    dgListaCompras.Focus();
                }
            }
        }
        private void seleccionarCompra()
        {
            if (dgListaCompras.RowCount > 0 && dgListaCompras.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgListaCompras.Rows[dgListaCompras.CurrentRow.Index];
                IdCompra_frm = Convert.ToInt32(fila.Cells["idV"].Value);
                TotalCompra = Convert.ToInt32(fila.Cells["totalCompraV"].Value);
                ValorPagado= Convert.ToInt32(fila.Cells["valorPagadoCompraV"].Value);
                Saldo = Convert.ToInt32(fila.Cells["saldoCompraV"].Value);
                cargarDgPagos(IdCompra_frm);
                txtSaldo.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(Saldo));
                txtValorAPagar.Focus();
            }
        }
        private void cargarDgPagos(int NC)
        {
            dgPagos.DataSource = ControladorPagosCompras.listaNumeroCompra(NC);
        }

        private void txtValorAPagar_TextChanged(object sender, EventArgs e)
        {
            if (txtValorAPagar.Text != "")
            {
                if (Convert.ToInt32(txtValorAPagar.Text) > 0)
                {
                    SaldoFinal = Saldo - Convert.ToInt32(txtValorAPagar.Text);
                    txtSaldo.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(SaldoFinal));
                }
                else
                {
                    txtValorAPagar.Text = "0";
                    txtSaldo.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(Saldo));
                }
            }
            else
            {
                txtSaldo.Text = Convert.ToString(Saldo);
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

        private void txtValorAPagar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtValorAPagar.Text) > 0)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnPagar.Focus();
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private async void btnPagar_Click(object sender, EventArgs e)
        {
            if (dgListaCompras.RowCount > 0 && dgListaCompras.CurrentRow.Index >= 0)
            {
                if (Convert.ToInt32(txtValorAPagar.Text) > 0)
                {
                    if (cmbTipoBosillo.Text != "")
                    {
                        if (MessageBox.Show("esta seguro de agregar el pago del bolsillo " + cmbTipoBosillo.Text, "Agregar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            //agragamos el pago
                            await GestionarPago(0);
                        }
                    }
                }
            }
        }
        private async Task GestionarPago(int Boton)
        {
            PagosCompras objPago = new PagosCompras();
            objPago =await ControladorPagosCompras.ConsultarX_IdPago(IdPago);
            if (objPago != null)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("El pago ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (Boton == 0)
            {
                objPago = new PagosCompras();
                IdPago = 0;
            }
            objPago.id = IdPago;
            objPago.idCompra = IdCompra_frm;
            objPago.fechaPagoCompra = DateTime.Now;
            objPago.valorPagadoCompra = Convert.ToInt32(txtValorAPagar.Text);
            objPago.saldoActualCompra = SaldoFinal;
            objPago.idBolsillo = Convert.ToInt32(cmbTipoBosillo.SelectedValue);
            objPago.idBaseCaja = VariablesPublicas.IdBaseActiva;
            objPago.idSede = VariablesPublicas.IdEmpresaLogueada;
            RespuestaCRUD sql =await ControladorPagosCompras.Crear_Editar_Eliminar_PagoCompra(objPago, Boton);
            if (sql.estado == true)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("El pago fue agregado correctamente.", "Pago agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Boton == 2)
                {
                    MessageBox.Show("El pago fue eliminado correctamente.", "Pago eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //ahora actualizamos la cueta
                Compras objCompra = new Compras();
                objCompra =await ControladorCompra.ConsultaListaX_IdCompra_Entity(IdCompra_frm);
                if (objCompra != null)
                {
                    if (Boton == 0)
                    {
                        objCompra.valorPagadoCompra = ValorPagado + Convert.ToInt32(txtValorAPagar.Text);
                        objCompra.saldoCompra = SaldoFinal;
                    }
                    if (Boton == 2)
                    {
                        objCompra.valorPagadoCompra = ValorPagado - Convert.ToInt32(txtValorAPagar.Text);
                        objCompra.saldoCompra = Saldo + Convert.ToInt32(txtValorAPagar.Text);
                    }
                    bool sqlCompra =await ControladorCompra.GuardarEditarEliminarCompra(objCompra, 1);
                    if (sqlCompra == true)
                    {
                        MessageBox.Show("La cuenta N° " + NumeroCompra + " fue actualizada correctamente.", "Pago agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    IdCompra_frm = 0;
                    IdPago = 0;
                    NumeroCompra = 0;
                    TotalCompra = 0;
                    ValorPagado = 0;
                    Saldo = 0;
                    SaldoFinal = 0;
                    txtValorAPagar.Text = "0";
                    txtSaldo.Text = "0";
                    cargarDGCompras();
                    seleccionarCompra();
                }
            }
        }

        private void dgListaCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarCompra();
        }

        private void txtSaldo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            frmVerDetalleCompra frm = new frmVerDetalleCompra();
            AddOwnedForm(frm);
            frm.dgDetalleCompra.DataSource = ControladorDetalleCompra.listaXIdCompra(IdCompra_frm);
            frm.ShowDialog();
        }
    }
}

using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
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
    public partial class frmCostoPrecios : Form
    {
        public frmCostoPrecios()
        {
            InitializeComponent();
        }
        int IdCostoPrecio = 0;
        public int IdInvent = 0;
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmCostoPrecios_Load(object sender, EventArgs e)
        {
            CargarDG();
            CargarListaPrecio();
            GestionarBotones(0);


            dgCostos.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            // Ajustar tamaño de columnas y celdas.
            dgCostos.AutoResizeColumns();
            dgCostos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // para que divida el texto de las celdas en varias líneas
            dgCostos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
        private void CargarDG()
        {
            dgCostos.DataSource = controladorPrecio.ListaCompleta(IdInvent,VariablesPublicas.IdEmpresaLogueada);
        }
        private void GestionarBotones(int Boton)
        {
            cbAproxomar.Checked = false;
            if (Boton == 0)
            {
                btnGuardar.Text = "Crear";
                btnEliminar.Enabled = false;
            }
            else
            {
                btnGuardar.Text = "Editar";
                btnEliminar.Enabled = true;
            }
        }
        private void CargarListaPrecio()
        {
            cmbListaPrecios.DataSource = null;
            cmbListaPrecios.ValueMember = "id";
            cmbListaPrecios.DisplayMember = "nombreLista";
            cmbListaPrecios.DataSource = controladorListaPrecios.ListaCompleta();
        }
        private void lbAgregarLista_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmListaPrecios frm = new frmListaPrecios();
            AddOwnedForm(frm);
            frm.tituloFormulario.Text = "Gestionar Lista de Precios";
            frm.ShowDialog();
            CargarListaPrecio();
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtCosto.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtPOrcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtPOrcentaje.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtProducido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtProducido.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtPrecio.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }
        private bool ValidarCampos()
        {
            if (cmbListaPrecios.Text != "" &&
               txtCosto.Text != "" &&
               txtPOrcentaje.Text != "" &&
               txtProducido.Text != "" &&
               txtPrecio.Text != "" &&
               txtIva.Text!="")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void GestionarCosto(int Boton)
        {
            Precios objCosto = new Precios();
            objCosto = controladorPrecio.ConsultarIdInventario_IdLista(IdInvent, Convert.ToInt32(cmbListaPrecios.SelectedValue));
            if (objCosto != null)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("El producto " + tituloFormulario.Text + " ya cuenta con la lista " + cmbListaPrecios.Text + ".", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (Boton == 0)
            {
                IdCostoPrecio = 0;
                objCosto = new Precios();
            }
            objCosto.id = IdCostoPrecio;
            objCosto.idInventario = IdInvent;
            objCosto.idListaPrecios = Convert.ToInt32(cmbListaPrecios.SelectedValue);
            objCosto.PrecioVenta = Convert.ToDecimal(txtPrecio.Text);
            objCosto.utilidad = Convert.ToDecimal(txtProducido.Text);
            bool sqlCosto = controladorPrecio.CrearEditarEliminarCostoPrecio(objCosto, Boton);
            if (sqlCosto == true)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("la lista de precios "+cmbListaPrecios.Text+" fue creado correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Boton == 1)
                {
                    MessageBox.Show("la lista de precios "+cmbListaPrecios.Text+" fue editado correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Boton == 2)
                {
                    MessageBox.Show("la lista de precios " + cmbListaPrecios.Text + " fue eliminado correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CargarDG();
                GestionarBotones(0);
                LimpiarFormulario();
            }
        }
        private void LimpiarFormulario()
        {
            txtCosto.Text = "";
            txtPOrcentaje.Text = "";
            txtProducido.Text = "";
            txtPrecio.Text = "";
            IdCostoPrecio = 0;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool campos = ValidarCampos();
            if (campos == true)
            {
                if (btnGuardar.Text == "Editar")
                {
                    GestionarCosto(1);
                }
                else
                {
                    GestionarCosto(0);
                }
            }
        }

        decimal costoproducto=0;
        decimal producidoProducto=0;
        decimal precioProducto=0;
        decimal porcentajeproducto = 0;
        int PrecioEntero = 0;
        int ProducidoEntero = 0;
        private void txtPOrcentaje_TextChanged(object sender, EventArgs e)
        {


        }

        private void cbAproxomar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAproxomar.Checked == true)
            {
                if (precioProducto > 10)
                {
                    PrecioEntero = (int)Math.Round(precioProducto);
                    string x2 = Convert.ToString(PrecioEntero);
                    int cantidad = x2.Length;
                    cantidad = cantidad - 2;
                    x2 = x2.Substring(cantidad);
                    if (Convert.ToInt32(x2) < 50)
                    {
                        int xx2 = 50 - Convert.ToInt32(x2);
                        PrecioEntero = PrecioEntero + xx2;
                    }
                    else
                    {
                        int xx2 = 100 - Convert.ToInt32(x2);
                        PrecioEntero = PrecioEntero + xx2;
                    }
                    txtPrecio.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(PrecioEntero));
                }
            }
            else
            {
                txtPrecio.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(precioProducto));
            }
        }

        private void txtIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtIva.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }
        private void SeleccionarCosto()
        {
            if (dgCostos.RowCount > 0 && dgCostos.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgCostos.Rows[dgCostos.CurrentRow.Index];
                IdCostoPrecio = Convert.ToInt32(fila.Cells["id"].Value);
                cmbListaPrecios.SelectedValue = Convert.ToInt32(fila.Cells["idListaPrecio"].Value);
                txtCosto.Text = Convert.ToString(fila.Cells["costo"].Value);
                txtPOrcentaje.Text = Convert.ToString(fila.Cells["porcentaje"].Value);
                txtProducido.Text = Convert.ToString(fila.Cells["precio"].Value);
                txtPrecio.Text = Convert.ToString(fila.Cells["producido"].Value);
                txtIva.Text = Convert.ToString(fila.Cells["porcentajeIva"].Value);



                GestionarBotones(1);

                if (Convert.ToInt32(fila.Cells["aproximado"].Value) == 0)
                {
                    cbAproxomar.Checked = false;
                }
                else
                {
                    cbAproxomar.Checked = true;
                }

                txtCosto.Focus();
            }
        }
        private void dgCostos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarCosto();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SeleccionarCosto();
            GestionarCosto(2);
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalcularPorcentage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtPOrcentaje.Text != "")
                {
                    porcentajeproducto = Convert.ToDecimal(txtPOrcentaje.Text);
                    if (txtCosto.Text != "")
                    {
                        costoproducto = Convert.ToDecimal(txtCosto.Text);
                        producidoProducto = (costoproducto * porcentajeproducto) / 100;
                       
                        precioProducto = costoproducto + producidoProducto;
                        int entero = Convert.ToInt32(precioProducto);
                        precioProducto = Convert.ToDecimal(entero);
                    }
                }
                else
                {
                    porcentajeproducto = 0;
                    costoproducto = 0;
                    producidoProducto = costoproducto * porcentajeproducto;
                    precioProducto = costoproducto + producidoProducto;
                }
                txtProducido.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(producidoProducto));
                txtPrecio.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(precioProducto));
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        private void btnCancularPrecio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCosto.Text == "") txtCosto.Text = "0";
            if (txtPrecio.Text != "")
            {
                costoproducto= Convert.ToInt32(txtCosto.Text);
                precioProducto = Convert.ToInt32(txtPrecio.Text);
                producidoProducto = precioProducto - costoproducto;
                porcentajeproducto = 0;
                if (costoproducto == 0)
                {
                    porcentajeproducto = 100;
                }
                else
                {
                    porcentajeproducto = (producidoProducto * 100) / costoproducto;
                }
                txtPOrcentaje.Text = Convert.ToString(porcentajeproducto);
                txtProducido.Text = Convert.ToString(producidoProducto);
            }
        }
    }
}

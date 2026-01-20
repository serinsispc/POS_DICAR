using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using Invenpol_Parqueadero_Motos.Formularios.Tiemda;
using POS_SERINSIS_PC_2022.Formularios;
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
    public partial class frmBuscarProductoCompra : Form
    {
        public frmBuscarProductoCompra()
        {
            InitializeComponent();
        }
        List<v_productoVenta> listaProductos = new List<v_productoVenta>();
        private async void frmBuscarProductoCompra_Load(object sender, EventArgs e)
        {
            FrmLoading loading = null;
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    loading = FrmLoading.ShowLoading(this, "Cargarndo...");
                    // inicio

                    listaProductos = await ControladorProducto.FiltrarX_IdSede_IdEstado(VariablesPublicas.IdEmpresaLogueada, 1);
                    //cargamos el dg
                    await CargarDG();


                    // fin
                    FrmLoading.CloseLoading(this, loading);
                }
            }
            catch (Exception ex)
            {
                FrmLoading.CloseLoading(this, loading);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async Task CargarDG()
        {
            dgProductos.DataSource = listaProductos;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }
        private void AgregarProducto()
        {
            SeleccionarProducto();
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgProductos.RowCount > 0)
            {
                if (e.KeyCode == Keys.Down)
                {
                    dgProductos.Focus();
                }
                if (e.KeyCode == Keys.Enter)
                {
                    AgregarProducto();
                }
            }
        }

        private async void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != "")
            {
                dgProductos.DataSource = listaProductos.Where(x=>x.descripcionProducto.Contains(txtDescripcion.Text)).ToList();
            }
            else
            {
                await CargarDG();
            }
        }
        private void SeleccionarProducto()
        {
            if (dgProductos.RowCount > 0 && dgProductos.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgProductos.Rows[dgProductos.CurrentRow.Index];

                frmCompras frm = Owner as frmCompras;
                frm.IdProducto_frm = Convert.ToInt32(fila.Cells["id"].Value);
                frm.IdPrecios_frm= Convert.ToInt32(fila.Cells["idPrecios"].Value);
                frm.IdInventarioTotal_frm= Convert.ToInt32(fila.Cells["idInventarioTotal"].Value);
                frm.IdInventario_frm = Convert.ToInt32(fila.Cells["idInventario"].Value);
                frm.contenidoPresentacion_frm=Convert.ToDecimal(fila.Cells["contenidoPresentacion"].Value); 
                frm.txtDescripcion.Text= Convert.ToString(fila.Cells["descripcionProducto"].Value);
                frm.costoAnterior_frm= Convert.ToDecimal(fila.Cells["costoUnidadIT"].Value)* Convert.ToDecimal(fila.Cells["contenidoPresentacion"].Value);
                frm.txtCostoAnterior.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(frm.costoAnterior_frm));
                int porIVA= Convert.ToInt32(fila.Cells["porcentajeIVAIT"].Value);
                frm.txtPorcentajeIVA.Text = Convert.ToString(porIVA);
                frm.txtCodigo.Text= Convert.ToString(fila.Cells["codigoProducto"].Value);
                frm.cmbPresentacion.SelectedValue = Convert.ToInt32(fila.Cells["idPresentacion"].Value);
                int porUtilidad = Convert.ToInt32(fila.Cells["porcentajeUtilidad"].Value);
                frm.txtPorcentajeDescuento.Text= Convert.ToString(fila.Cells["porcentajeDescuento"].Value);
                frm.txtPorcentajeUtilidad.Text= Convert.ToString(porUtilidad);
                int costo= Convert.ToInt32(fila.Cells["costoUnidadIT"].Value);
                frm.txtPrecioUnitario.Text= Convert.ToString(costo* frm.contenidoPresentacion_frm);
                int precio= Convert.ToInt32(fila.Cells["PrecioVenta"].Value);
                frm.txtPrecioPublico.Text = Convert.ToString(precio);
                int valorUtil = Convert.ToInt32(fila.Cells["Utilidad"].Value);
                frm.txtValorUtilidad.Text = Convert.ToString(valorUtil);
                frm.cantidadAnterior = Convert.ToDecimal(fila.Cells["inventarioActual"].Value);
       

                this.Close();
            }
        }
        private void dgProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarProducto();
            }
        }
    }
}

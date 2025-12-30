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

namespace SERINSI_PC.Formularios.Fabrica
{
    public partial class frmInsumoOrden : Form
    {
        SistemaPOSEntities cn = new SistemaPOSEntities();

        public int IdOrdenFabrica;
        int IdInsumo;
        string DescripcionInsumo;
        decimal CostoInsumo;
        decimal TotalInsumos;
        int IdDetalle;

        public object detalleordenfabrica
        {
            get;
            private set;
        }

        public frmInsumoOrden()
        {
            InitializeComponent();
        }


        private void txtBuscadorInsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBuscadorInsumo.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SeleccionarInsumoBuscador();
                }
                if (e.KeyCode == Keys.Down)
                {
                    dgListaBuscadorImsumo.Focus();
                }
            }
        }
        private void SeleccionarInsumoBuscador()
        {
            if(dgListaBuscadorImsumo.RowCount>0 && dgListaBuscadorImsumo.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgListaBuscadorImsumo.Rows[dgListaBuscadorImsumo.CurrentRow.Index];

                IdInsumo = Convert.ToInt32(fila.Cells["idVistaProducto"].Value);
                DescripcionInsumo = Convert.ToString(fila.Cells["descripcionProducto_v"].Value);
                CostoInsumo = Convert.ToInt32(fila.Cells["costoProducto"].Value);
                txtCodigoINsumo.Text = Convert.ToString(fila.Cells["codigoProducto"].Value);
                txtCantidadActualInsumo.Text= Convert.ToString(fila.Cells["inventarioActual"].Value);
                txtCostoInsumo.Text = Convert.ToString(CostoInsumo);
                txtDescripcionInsumo.Text = DescripcionInsumo;
                dgListaBuscadorImsumo.Visible = false;
                txtCostoInsumo.Focus();
            }
        }

        private void dgListaBuscadorImsumo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarInsumoBuscador();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInsumoOrden_Load(object sender, EventArgs e)
        {
            CargarDG();
            SumarTotal();
        }
        private void SumarTotal()
        {
            TotalInsumos = controladorDetalleOrdenFabrica.SumaTotalDetalleINsumo(IdOrdenFabrica);
            totalText.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(TotalInsumos));
        }
        private void CargarDG()
        {
            dgDetalleOrden.DataSource = controladorDetalleOrdenFabrica.Filtro_IDOrden(IdOrdenFabrica);
        }

        private void btnAgregarINsumo_Click(object sender, EventArgs e)
        {
            if(txtCodigoINsumo.Text!="" &&
               txtCantidadActualInsumo.Text!=""&&
               txtCostoInsumo.Text!=""&&
               txtDescripcionInsumo.Text!=""&&
               txtCantidad.Text!=""&&
               txtCostoTotalINsumo.Text != "")
            {
                GestionarInsumo();
            }
            else
            {
                MessageBox.Show("Aún hay campos vacíos ", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void GestionarInsumo()
        {
            int Boton;
            DetalleOrdenFabrica objDetalle = new DetalleOrdenFabrica();
            objDetalle = controladorDetalleOrdenFabrica.consultarIdDetalleOrden(IdDetalle);
            if (objDetalle != null)
            {
                Boton = 2;
                IdDetalle = objDetalle.id;
            }
            else
            {
                Boton = 0;
            }
            if(Boton == 0)
            {
                objDetalle = new DetalleOrdenFabrica();
                IdDetalle = 0;
                objDetalle.id = IdDetalle;
                objDetalle.idOrdenDetalle = IdOrdenFabrica;
                objDetalle.idInsumoOrden = IdInsumo;
                objDetalle.descripcionInsumoOrden = txtDescripcionInsumo.Text;
                objDetalle.cantidadInsumoOrden = Convert.ToDecimal(txtCantidad.Text);
                objDetalle.costoInsumoUnidad = Convert.ToDecimal(txtCostoInsumo.Text);
                objDetalle.costoTotalInsumoOrden = Convert.ToDecimal(txtCostoTotalINsumo.Text);
            }
            bool sql = controladorDetalleOrdenFabrica.CrearEditarEliminarDetalleOrdenFabrica(objDetalle,Boton);
            if (sql == true)
            {
                //en esta parte actualizamos la cantidad del insumo
                ActualizarCantidadINsumo(Boton);
                //en esta parte actualizamos el total de la orden
                SumarTotal();
                ActualizarOrden();
                limpiarFormulario();
            }
            else
            {
                MessageBox.Show("A ocurrido un error en el proceso de agregar el insumo.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void ActualizarCantidadINsumo(int Boton)
        {
            //DAL.Modelo.Inventario objInventario = new DAL.Modelo.Inventario();
            //objInventario = controladorInventario.consultarXIdProductoInventario(IdInsumo,);
            //if (objInventario != null)
            //{
            //    if(Boton == 0)
            //    {
            //        objInventario.inventarioActual -= Convert.ToDecimal(txtCantidad.Text);

            //    }
            //    else
            //    {
            //        objInventario.inventarioActual += Convert.ToDecimal(txtCantidad.Text);
            //    }
            //    bool sql = controladorInventario.CrearEditarEliminarInventario(objInventario,1);
            //}
        }
        private void ActualizarOrden()
        {
            OrdenFabrica objOrden = new OrdenFabrica();
            objOrden = controladorOrdenFabrica.consultarID(IdOrdenFabrica);
            if (objOrden != null)
            {
                objOrden.costoOrdenInsumo = TotalInsumos;
                objOrden.totalConstoOren = TotalInsumos +Convert.ToDecimal(objOrden.costoOrdenManoObra);
                objOrden.Producido = objOrden.ValorFinalOrden - objOrden.totalConstoOren;
                bool sql = controladorOrdenFabrica.CrearEditarElimminarOrdenFabrica(objOrden,1);
                if (sql == false)
                {
                    MessageBox.Show("Se fue posible actualizar los valores de la orden.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    frmFabrica frm = Owner as frmFabrica;
                    frm.llenarDGCOmpleta();
                }
            }
        }
        private void limpiarFormulario()
        {
            IdInsumo = 0;
            DescripcionInsumo = "";
            CostoInsumo = 0;
            TotalInsumos=0;
            IdDetalle=0;

            txtBuscadorInsumo.Text = "";
            txtCodigoINsumo.Text = "";
            txtCantidadActualInsumo.Text = "";
            txtCostoInsumo.Text = "";
            txtDescripcionInsumo.Text = "";
            txtCantidad.Text = "";
            txtCostoTotalINsumo.Text = "";

            CargarDG();
            SumarTotal();

            txtBuscadorInsumo.Focus();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                try
                {
                    CostoInsumo = Convert.ToDecimal(txtCostoInsumo.Text);
                    decimal costo = CostoInsumo * Convert.ToDecimal(txtCantidad.Text);
                    txtCostoTotalINsumo.Text = Convert.ToString(costo);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                txtCostoTotalINsumo.Text = "";
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtCantidad.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAgregarINsumo.PerformClick();
            }
        }

        private void dgListaBuscadorImsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarInsumoBuscador();
            }
        }

        private void btnEliminarOrden_Click(object sender, EventArgs e)
        {
            if (dgDetalleOrden.RowCount > 0 && dgDetalleOrden.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgDetalleOrden.Rows[dgDetalleOrden.CurrentRow.Index];
                IdDetalle = Convert.ToInt32(fila.Cells["id"].Value);
                IdInsumo = Convert.ToInt32(fila.Cells["idInsumoOrden"].Value);
                CostoInsumo = Convert.ToDecimal(fila.Cells["costoInsumoUnidad"].Value);
                txtCostoInsumo.Text = Convert.ToString(fila.Cells["costoInsumoUnidad"].Value);
                txtCantidad.Text = Convert.ToString(fila.Cells["cantidadInsumoOrden"].Value);
                GestionarInsumo();
            }
        }

        private void txtCostoInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtCantidad.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtCostoInsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCantidad.Focus();
            }
        }
    }
}

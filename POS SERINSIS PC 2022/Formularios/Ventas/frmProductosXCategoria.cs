using DAL.Controladores;
using Invenpol_Parqueadero_Motos.Clases;
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

namespace SERINSI_PC.Formularios.Ventas
{
    public partial class frmProductosXCategoria : Form
    {
        decimal iva_frm = 0;
        int idInventario_frm = 0;
        int IdInventarioTotal_frm = 0;
        int IdCosto_frm = 0;
        decimal costoProducto_frm = 0;
        decimal contenidoPresentacion_frm = 0;
        int IdProducto;
        public decimal PrecioProducto;
        public int Llamado = 0;
        public string descripcionProducto_frm = "";
        int IdTipoM = 0;

        public frmProductosXCategoria()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void frmProductosXCategoria_Load(object sender, EventArgs e)
        {
            dgProductosXCategoria.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 17);
            if (Llamado == 0)
            {
                dgProductosXCategoria.Focus();
            }
            else
            {
                txtDescripcion.Focus();
            }
            txtDescripcion.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgProductosXCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarProducto();
        }
        string estadoInv="";
        decimal cantidadT = 0;
        decimal porcentajeIva_frm = 0;
        int Gramera = 0;
        private void SeleccionarProducto()
        {
            if (dgProductosXCategoria.RowCount > 0 && dgProductosXCategoria.CurrentRow.Index >= 0)
            {
                DataGridViewRow Fila = dgProductosXCategoria.Rows[dgProductosXCategoria.CurrentRow.Index];
                IdProducto = Convert.ToInt32(Fila.Cells["id"].Value);
                IdTipoM = Convert.ToInt32(Fila.Cells["idTipoMedida"].Value);
                descripcionProducto_frm = Convert.ToString(Fila.Cells["descripcionProducto"].Value);
                PrecioProducto = Convert.ToDecimal(Fila.Cells["PrecioVenta"].Value);
                IdCosto_frm = Convert.ToInt32(Fila.Cells["idPrecios"].Value);
                idInventario_frm = Convert.ToInt32(Fila.Cells["idInventario"].Value);
                costoProducto_frm = Convert.ToDecimal(Fila.Cells["costoUnidadIT"].Value);
                contenidoPresentacion_frm= Convert.ToDecimal(Fila.Cells["contenidoPresentacion"].Value);
                IdInventarioTotal_frm = Convert.ToInt32(Fila.Cells["idInventarioTotal"].Value);
                estadoInv = Convert.ToString(Fila.Cells["estadoInventario"].Value);
                cantidadT = Convert.ToDecimal(Fila.Cells["inventarioActual"].Value);
                porcentajeIva_frm = Convert.ToDecimal(Fila.Cells["porcentajeIVAIT"].Value);
                Gramera =Convert.ToInt32(Fila.Cells["gramera"].Value);

                pbImagen.Image = ClassRuta.CargarProductoCategoria(VariablesPublicas.RutaImagenes , "\\Productos\\", Convert.ToString(Fila.Cells["guidProducto"].Value) + ".png");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgProductosXCategoria.RowCount > 0 && dgProductosXCategoria.CurrentRow.Index >= 0)
            {
                DataGridViewRow Fila = dgProductosXCategoria.Rows[dgProductosXCategoria.CurrentRow.Index];
                frmCajaTouch frm = Owner as frmCajaTouch;
         
                if (PrecioProducto == Convert.ToDecimal(1))
                {
                    frmPrecioProducto frmp = new frmPrecioProducto();
                    AddOwnedForm(frmp);
                    frmp.txtDescripcion.Text = descripcionProducto_frm;
                    frmp.ShowDialog();

                }

                //if (VariablesPublicas.VentasEnNegativo == 0)
                //{
                //    if (estadoInv == "agotado")
                //    {
                //        if (cantidadT <= 0)
                //        {
                //            MessageBox.Show("El producto esta agotado", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return;
                //        }
                //        else
                //        {
                //            int Cant = Convert.ToInt32(cantidadT) / Convert.ToInt32(contenidoPresentacion_frm);
                //            MessageBox.Show("El producto esta por debajo del stock." + Environment.NewLine +
                //                Environment.NewLine +
                //                "La cantidad actual es " + Cant, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        }
                //    }
                //}

                ////en esta parte agregamos la cantidad en kg
                //if (IdTipoM > 1)
                //{
                //    frmEditarCantidad frm_cantidad = new frmEditarCantidad();
                //    AddOwnedForm(frm_cantidad);
                //    frm_cantidad.frmPadre = "caja";
                //    frm_cantidad.ShowDialog();
                //}
                //else
                //{
                //    VariablesPublicas.cantidadKilogramo = 1;
                //}

                frmCajaTouch frm2 = Owner as frmCajaTouch;
                frm2.BuscarProducto_id(IdProducto);
                //bool agregar = frm2.AgregarDetalleVenta(IdCosto_frm, descripcionProducto_frm, VariablesPublicas.cantidadKilogramo, costoProducto_frm, PrecioProducto, iva_frm, idInventario_frm, contenidoPresentacion_frm, IdInventarioTotal_frm, porcentajeIva_frm, Gramera);
                //if (agregar == true)
                //{
                //    this.Close();
                //}
                this.Close();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

        }

        private void dgProductosXCategoria_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarProducto();
        }

        private void dgProductosXCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAgregar.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmProductosXCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != "")
            {
                dgProductosXCategoria.DataSource = ControladorProducto.FiltrarX_Descripcion_IdSede_IdEstado(txtDescripcion.Text,VariablesPublicas.IdEmpresaLogueada,1);
            }
            else
            {
                dgProductosXCategoria.DataSource = ControladorProducto.FiltrarX_IdSede_IdEstado(VariablesPublicas.IdEmpresaLogueada,1);
            }
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarProducto();
                if (dgProductosXCategoria.RowCount > 0)
                {
                    btnAgregar.PerformClick();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Down)
            {
                dgProductosXCategoria.Focus();
            }
        }
    }
}

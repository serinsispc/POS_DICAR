using DAL.Controladores;
using Invenpol_Parqueadero_Motos.Clases;
using SERINSI_PC.Clases;
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
    public partial class frmBuscadorProducto : Form
    {
        public frmBuscadorProducto()
        {
            InitializeComponent();
        }
        public int Foco = 0;
        int idInventarioTotal_frm = 0;
        int idInventario_frm = 0;
        string codigoProducto_frm = "";
        string descripcionProducto_frm = "";
        private void frmBuscadorProducto_Load(object sender, EventArgs e)
        {
            if (Foco == 0)
            {
                txtDescripcion.Focus();
            }
            else
            {
                dgProducto.Focus();
            }
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgProducto.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarProducto();
            }
        }
        private void SeleccionarProducto()
        {
            if (dgProducto.RowCount > 0 && dgProducto.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgProducto.Rows[dgProducto.CurrentRow.Index];
                idInventarioTotal_frm = Convert.ToInt32(fila.Cells["idInventarioTotal"].Value);
                idInventario_frm= Convert.ToInt32(fila.Cells["idInventario"].Value);
                codigoProducto_frm = Convert.ToString(fila.Cells["codigoProducto"].Value);
                descripcionProducto_frm= Convert.ToString(fila.Cells["descripcionProducto"].Value);

                frmMerma frm = Owner as frmMerma;
                frm.idInventarioTotal_frm = idInventarioTotal_frm;
                frm.idInventario_frm = idInventario_frm;
                frm.txtBuscarCodigo.Text = codigoProducto_frm;
                frm.txtDescripcionProducto.Text = descripcionProducto_frm;
                this.Close();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            SeleccionarProducto();
        }

        private void dgProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarProducto();
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != "")
            {
                dgProducto.DataSource = ControladorProducto.FiltrarX_Descripcion_IdSede_IdEstado(txtDescripcion.Text,VariablesPublicas.IdEmpresaLogueada,1);
            }
            else
            {
                dgProducto.DataSource = ControladorProducto.FiltrarX_IdSede(VariablesPublicas.IdEmpresaLogueada,0);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

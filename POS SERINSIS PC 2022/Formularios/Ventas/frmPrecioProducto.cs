using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Ventas
{
    public partial class frmPrecioProducto : Form
    {
        public frmPrecioProducto()
        {
            InitializeComponent();
        }

        private void btnAgregarPrecio_Click(object sender, EventArgs e)
        {
            if (txtPrecio.Text != "")
            {
                frmProductosXCategoria frm = Owner as frmProductosXCategoria;
                frm.PrecioProducto = Convert.ToDecimal(txtPrecio.Text);
                frm.descripcionProducto_frm = txtDescripcion.Text;
                this.Close();
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAgregarPrecio.PerformClick();
            }
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrecio.Focus();
            }
        }
    }
}

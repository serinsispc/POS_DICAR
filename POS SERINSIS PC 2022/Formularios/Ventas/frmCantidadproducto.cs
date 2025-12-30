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
    public partial class frmCantidadproducto : Form
    {
        public decimal canti;
        public frmCantidadproducto()
        {
            InitializeComponent();
        }

        private void frmCantidadproducto_Load(object sender, EventArgs e)
        {
            txtCantidad.Text = Convert.ToString(canti);
            txtCantidad.Focus();
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
            if (txtCantidad.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    canti = Convert.ToDecimal(txtCantidad.Text);
                    frmCajaTouch frm = Owner as frmCajaTouch;
                    this.Close();
                }
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

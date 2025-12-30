using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Ventas
{
    public partial class frmEditarPrecion : Form
    {
        public int IdDetalle_frm = 0;
        public decimal Cantidad_frm = 0;
        decimal TotalDetalle_frm = 0;
        public frmEditarPrecion()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtModificarPrecio.Text != "")
                {
                    TotalDetalle_frm = Cantidad_frm * Convert.ToDecimal(txtModificarPrecio.Text);

                    ConexionSQL.AbrirConexion();
                    SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                    cmd.CommandText = "update DetalleVenta set precioVenta=" + Convert.ToDecimal(txtModificarPrecio.Text) + " where id=" + IdDetalle_frm;
                    cmd.ExecuteNonQuery();
                    ConexionSQL.CerrarConexion();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("El precio no se pudo editar.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtModificarPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtModificarPrecio.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtModificarPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtModificarPrecio.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnModificar.PerformClick();
                }
            }
        }

        private void frmEditarPrecion_Load(object sender, EventArgs e)
        {

        }

        private void AgregarNumero(int numero)
        {
            if (txtModificarPrecio.Text != "")
            {
                txtModificarPrecio.Text = txtModificarPrecio.Text + numero;
            }
            else
            {
                txtModificarPrecio.Text = Convert.ToString(numero);
            }
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            AgregarNumero(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            AgregarNumero(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AgregarNumero(9);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AgregarNumero(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AgregarNumero(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AgregarNumero(6);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            AgregarNumero(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            AgregarNumero(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            AgregarNumero(3);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            AgregarNumero(0);
        }

        private void btnPumto_Click(object sender, EventArgs e)
        {
            if (txtModificarPrecio.Text != "" &&
                txtModificarPrecio.Text.Contains(",") == false)
            {
                txtModificarPrecio.Text = txtModificarPrecio.Text + ",";
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtModificarPrecio.Text = "";
        }
    }
}

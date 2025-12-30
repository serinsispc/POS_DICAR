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

namespace SERINSI_PC.Formularios.Ventas
{
    public partial class frmEditarCantidad : Form
    {
        public frmEditarCantidad()
        {
            InitializeComponent();
        }
        public string frmPadre = "";
        public int IdDetalle = 0;
        public int IdInventario = 0;
        public decimal cantidadAnterior = 0;
        public decimal contenido = 0;
        public int IdInventarioTotal_frm;
        public bool RegistoAutomatico = false;
        private void frmEditarCantidad_Load(object sender, EventArgs e)
        {
            txtNumero.Focus();
        }
        private void AgregarNumero(int numero)
        {
            if (txtNumero.Text != "")
            {
                txtNumero.Text = txtNumero.Text +  numero;
            }
            else
            {
                txtNumero.Text =Convert.ToString(numero);
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtNumero.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
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

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtNumero.Text = "";
        }
        private void cerrar()
        {
            if(txtNumero.Text!="")
                VariablesPublicas.cantidadKilogramo = Convert.ToDecimal(txtNumero.Text);


            this.Close();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            cerrar();
        }

        private void frmEditarCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNumero.Text == "")
            {
                txtNumero.Focus();
            }

        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cerrar();
            }
        }

        private void txtPumpo_Click(object sender, EventArgs e)
        {
            if (txtNumero.Text != ""&&
                txtNumero.Text.Contains(",")==false)
            {
                txtNumero.Text = txtNumero.Text + ",";
            }
        }
    }
}

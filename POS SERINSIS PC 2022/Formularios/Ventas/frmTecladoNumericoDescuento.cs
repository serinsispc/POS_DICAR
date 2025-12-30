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
    public partial class frmTecladoNumericoDescuento : Form
    {
        public frmTecladoNumericoDescuento()
        {
            InitializeComponent();
        }
        public decimal Numero=0;
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (Titulo.Text == "Descuento")
            {
                decimal descuento = 0;
                frmCobroCaja frm = Owner as frmCobroCaja;
                if (Numero > 0)
                {
                    descuento = frm.SubTotal - Numero;
                }
                frm.Descuento = descuento;
                frm.txtDescuento.Text = Convert.ToString(Convert.ToInt32(descuento));
            }
            else if (Titulo.Text == "Domicilio")
            {
                decimal domicilio = 0;
                frmCobroCaja frm = Owner as frmCobroCaja;
                if (Numero > 0)
                {
                    domicilio =  Numero;
                }
                frm.Domicilio = domicilio;
                frm.txtDomicilio.Text = Convert.ToString(domicilio);
            }
            this.Close();
        }

        private void frmTecladoNumericoDescuento_Load(object sender, EventArgs e)
        {
            txtNumero.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(Numero));
        }
        private void GestionarNumero(string tecla)
        {
            try
            {
                string xx;
                if (Numero > 0)
                {
                    xx = Convert.ToString(Numero + tecla);
                }
                else
                {
                    xx = tecla;
                }
                Numero = Convert.ToInt32(xx);
                txtNumero.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(Numero));
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            GestionarNumero("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            GestionarNumero("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            GestionarNumero("9");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            GestionarNumero("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            GestionarNumero("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            GestionarNumero("6");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            GestionarNumero("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            GestionarNumero("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            GestionarNumero("3");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (Numero > 0)
            {
                GestionarNumero("0");
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            return;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Numero = 0;
            txtNumero.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(Numero));
        }

        private void frmTecladoNumericoDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmTecladoNumericoDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnCerrar.PerformClick();
            }
            if (e.KeyCode == Keys.Delete)
            {
                btnBorrar.PerformClick();
            }
            if (e.KeyCode == Keys.Back)
            {
                btnBorrar.PerformClick();
            }
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
            {
                btn0.PerformClick();
            }
            if (e.KeyCode == Keys.D1 || e.KeyCode==Keys.NumPad1)
            {
                btn1.PerformClick();
            }
            if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                btn2.PerformClick();
            }
            if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            {
                btn3.PerformClick();
            }
            if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
            {
                btn4.PerformClick();
            }
            if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
            {
                btn5.PerformClick();
            }
            if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
            {
                btn6.PerformClick();
            }
            if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
            {
                btn7.PerformClick();
            }
            if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
            {
                btn8.PerformClick();
            }
            if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
            {
                btn9.PerformClick();
            }
        }

        private void txtNumero_Click(object sender, EventArgs e)
        {

        }
    }
}

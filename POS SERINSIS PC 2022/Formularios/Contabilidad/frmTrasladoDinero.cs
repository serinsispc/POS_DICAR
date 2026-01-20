using DAL;
using DAL.Controladores;
using DAL.Controladores.Contabilidad;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using SERINSI_PC.Clases.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Contabilidad
{
    public partial class frmTrasladoDinero : Form
    {
        public frmTrasladoDinero()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmTrasladoDinero_Load(object sender, EventArgs e)
        {
            cmbBolsilloDesde.ValueMember = "id";
            cmbBolsilloDesde.DisplayMember = "nombreBolsillo";
            cmbBolsilloDesde.DataSource = ControladorBilsillo.listaCompleta();
            cmbBolsilloDesde.SelectedIndex = -1;

            cmbBolsilloHacia.ValueMember = "id";
            cmbBolsilloHacia.DisplayMember = "nombreBolsillo";
            cmbBolsilloHacia.DataSource = ControladorBilsillo.listaCompleta();
            cmbBolsilloHacia.SelectedIndex = -1;
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtValor.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMotivo.Focus();
                }
            }
        }

        private void txtMotivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtMotivo.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnGuardar.PerformClick();
                }
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if(cmbBolsilloDesde.Text!=""&&
               cmbBolsilloHacia.Text!=""&&
               txtValor.Text!=""&&
               txtMotivo.Text != "")
            {
                if (cmbBolsilloDesde.Text != cmbBolsilloHacia.Text)
                {
                    await GestionarLibroDiario(Convert.ToInt32(cmbBolsilloDesde.SelectedValue),txtMotivo.Text,0,Convert.ToInt32(txtValor.Text));
                    await GestionarLibroDiario(Convert.ToInt32(cmbBolsilloHacia.SelectedValue), txtMotivo.Text, Convert.ToInt32(txtValor.Text),0);
                    MessageBox.Show("El trastlado se completo correctamente.","Traslado",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    frmLibroDiario frm = Owner as frmLibroDiario;
                    frm.cargarDG();
                    this.Close();
                }
            }
        }
        private async Task GestionarLibroDiario(int Bolsillo, string Motivo, decimal Debe, decimal Haber)
        {
            //en esta parte agregamos el movimiento a la tabla libro diario
            LibroDiario objLibro = new LibroDiario();
            objLibro.id = 0;
            objLibro.fechaMovimiento = DateTime.Now;
            objLibro.idBolsillo = Bolsillo;
            objLibro.motivoMovimiento = Motivo;
            objLibro.debe = Debe;
            objLibro.haber = Haber;
            objLibro.idUsuario = VariablesPublicas.IdUsuarioLogueado;
            //en esta parte llamamos la funcion que nos trae el untimo saldo
            ClassSaldosLibroDiario.hallasUltimoSaldoLibro();
            if (Bolsillo == 1)
            {
                objLibro.saldoCaja = VariablesPublicas.SaldoCaja + Debe - Haber;
                objLibro.saldoBanco = VariablesPublicas.SaldoBanco;
                objLibro.saldoCajaMenor = VariablesPublicas.SaldoCajaMenor;
                objLibro.saldoTotal = VariablesPublicas.SaldoTotal + Debe - Haber;
            }
            if (Bolsillo == 2)
            {
                objLibro.saldoCaja = VariablesPublicas.SaldoCaja;
                objLibro.saldoBanco = VariablesPublicas.SaldoBanco + Debe - Haber;
                objLibro.saldoCajaMenor = VariablesPublicas.SaldoCajaMenor;
                objLibro.saldoTotal = VariablesPublicas.SaldoTotal + Debe - Haber;
            }
            if (Bolsillo == 3)
            {
                objLibro.saldoCaja = VariablesPublicas.SaldoCaja;
                objLibro.saldoBanco = VariablesPublicas.SaldoBanco;
                objLibro.saldoCajaMenor = VariablesPublicas.SaldoCajaMenor + Debe - Haber;
                objLibro.saldoTotal = VariablesPublicas.SaldoTotal + Debe - Haber;
            }
            RespuestaCRUD sql2 =await ControladorLibroDiario.CrearEditarEliminarLibroDiario(objLibro, 0);
            if (sql2.estado == true)
            {

                // this.Close();
            }
        }

        private void cmbBolsilloDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            //en esta parte llamamos la funcion que nos trae el untimo saldo
            ClassSaldosLibroDiario.hallasUltimoSaldoLibro();
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            if (txtValor.Text != "")
            {
                if (Convert.ToInt32(cmbBolsilloDesde.SelectedValue) == 1)
                {
                    if (VariablesPublicas.SaldoCaja < Convert.ToInt32(txtValor.Text))
                    {
                        MessageBox.Show("Saldo insuficiente.", "Saldo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValor.Text = "0";
                        return;
                    }
                }
                if (Convert.ToInt32(cmbBolsilloDesde.SelectedValue) == 2)
                {
                    if (VariablesPublicas.SaldoBanco < Convert.ToInt32(txtValor.Text))
                    {
                        MessageBox.Show("Saldo insuficiente.", "Saldo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValor.Text = "0";
                        return;
                    }
                }
                if (Convert.ToInt32(cmbBolsilloDesde.SelectedValue) == 3)
                {
                    if (VariablesPublicas.SaldoCajaMenor < Convert.ToInt32(txtValor.Text))
                    {
                        MessageBox.Show("Saldo insuficiente.", "Saldo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValor.Text = "0";
                        return;
                    }
                }
            }
        }
    }
}

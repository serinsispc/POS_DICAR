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
    public partial class frmBaseCaja : Form
    {
        public frmBaseCaja()
        {
            InitializeComponent();
        }

        private void frmBaseCaja_Load(object sender, EventArgs e)
        {
            cmbBolsillo.Items.Add("Caja Menor");
            cmbBolsillo.Items.Add("Banco");
            cmbBolsillo.SelectedIndex = 0;
            //en esta parte consultamos si hay una base de caja activa
            BaseCaja objBase = new BaseCaja();
            objBase = ControladorBaseCaja.consultaBaseActiva("ACTIVA",VariablesPublicas.IdUsuarioLogueado,VariablesPublicas.IdEmpresaLogueada);
            if (objBase != null)
            {
                MessageBox.Show("Serinsis PC le informa que ya hay una base activa por lo tanto no es posible crear una base nueva.", "Base Activa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Text = Convert.ToString(objBase.valorBase);
                txtEstado.Text = objBase.estadoBase;

                txtValor.Enabled = false;
                btnGuardar.Enabled = false;
            }
            else
            {
                txtEstado.Text = "ACTIVA";
            }
            txtValor.Focus();
        }
        private void GestionarLibroDiario(int Bolsillo, string Motivo, decimal Debe, decimal Haber)
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
            bool sql2 = ControladorLibroDiario.CrearEditarEliminarLibroDiario(objLibro, 0);
            if (sql2 == true)
            {

                // this.Close();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtValor.Text != "")
            {
                BaseCaja objBase = new BaseCaja();
                objBase.id = 0;
                objBase.fechaApertura = DateTime.Now;
                objBase.fechaCierre = DateTime.Now;
                objBase.idUsuarioApertura = VariablesPublicas.IdUsuarioLogueado;
                objBase.valorBase = Convert.ToDecimal(txtValor.Text);
                objBase.estadoBase = txtEstado.Text;
                objBase.idSedeBAse = VariablesPublicas.IdEmpresaLogueada;
                bool sql = ControladorBaseCaja.CrearEditarEliminarBaseCaja(objBase,0);
                if (sql == true)
                {
                    if (cmbBolsillo.Text == "BANCO")
                    {
                        GestionarLibroDiario(2,"apertura de caja",0,Convert.ToInt32(txtValor.Text));
                        GestionarLibroDiario(1,"apertura de caja", Convert.ToInt32(txtValor.Text),0);
                    }
                    else
                    {
                        GestionarLibroDiario(3, "apertura de caja", 0, Convert.ToInt32(txtValor.Text));
                        GestionarLibroDiario(1, "apertura de caja", Convert.ToInt32(txtValor.Text), 0);
                    }
                    MessageBox.Show("Base creada correctamente.", "Base creda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BaseCaja objBaseCaja = new BaseCaja();
                    objBaseCaja= ControladorBaseCaja.HallarIdBaseActiva(VariablesPublicas.IdEmpresaLogueada, VariablesPublicas.IdUsuarioLogueado);
                    if (objBaseCaja != null)
                    {
                        VariablesPublicas.IdBaseActiva = objBaseCaja.id;
                       
                    }
                    this.Close();
                }
            }
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
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar.PerformClick();
            }
        }
        TextBox textBoxActivo;
        private void txtValor_Enter(object sender, EventArgs e)
        {
            textBoxActivo = (TextBox)sender;
        }
        private void GestionarTecla(string tecla)
        {
            try
            {
                string texto = "";
                if (textBoxActivo.Text != "")
                {
                    texto = textBoxActivo.Text;
                }
                texto = texto + tecla;
                textBoxActivo.Text = texto;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            textBoxActivo.Text = "";
        }
    }
}

using DAL.Controladores.Contabilidad;
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

namespace SERINSI_PC.Formularios.Contabilidad
{
    public partial class frmBaseLibroDiario : Form
    {
        public frmBaseLibroDiario()
        {
            InitializeComponent();
        }
        int Base = 0;
        private void txtBaseCajaMenor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBaseBanco_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCargarBAse_Click(object sender, EventArgs e)
        {
            if(txtBaseBanco.Text!=""&&
               txtBaseCajaMenor.Text != "")
            {
               bool xx= GestionarLibro("Base inicio software",3,Convert.ToDecimal(txtBaseCajaMenor.Text),0,0,Convert.ToDecimal(txtBaseCajaMenor.Text));
               bool xxx= GestionarLibro("Base inicio software",2,Convert.ToDecimal(txtBaseBanco.Text),0,Convert.ToDecimal(txtBaseBanco.Text),Convert.ToDecimal(txtBaseCajaMenor.Text));
                if (xx == true && xxx == true)
                {
                    MessageBox.Show("La base de agrego correctamente.", "Base", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLibroDiario frm = Owner as frmLibroDiario;
                    frm.cargarDG();
                    this.Close();
                }
            }
        }
        private bool GestionarLibro(string Detalle, int IDBolsillo, decimal ingreso, decimal egreso,decimal Banco,decimal CajaMejor)
        {
            int IdLibro = 0;
            int Boton = 0;
            LibroDiario objLibro = new LibroDiario();
            objLibro = ControladorLibroDiario.consultaMotivoIdBolsillo(Detalle, IDBolsillo);
            if (objLibro != null)
            {
                IdLibro = objLibro.id;
                Boton = 1;
            }
            else
            {
                objLibro = new LibroDiario();
                Boton = 0;
                IdLibro = 0;
            }
            objLibro.id = IdLibro;
            objLibro.fechaMovimiento = DateTime.Today;
            objLibro.idBolsillo = IDBolsillo;
            objLibro.motivoMovimiento = Detalle;
            objLibro.debe = ingreso;
            objLibro.haber = egreso;
            objLibro.saldoCaja = 0;
            objLibro.saldoBanco = Banco;
            objLibro.saldoCajaMenor = CajaMejor;
            objLibro.saldoTotal = Banco + CajaMejor;
            objLibro.idUsuario = VariablesPublicas.IdUsuarioLogueado;
            bool sql = ControladorLibroDiario.CrearEditarEliminarLibroDiario(objLibro,Boton);
            if (sql == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void frmBaseLibroDiario_Load(object sender, EventArgs e)
        {
            ConsultarBase(2);
            ConsultarBase(3);
        }
        private void ConsultarBase(int TipoBol)
        {
            LibroDiario objLibro = new LibroDiario();
            objLibro = ControladorLibroDiario.consultaMotivoIdBolsillo("Base inicio software", TipoBol);
            if (objLibro != null)
            {
                if (TipoBol == 2)
                {
                    txtBaseBanco.Text = Convert.ToString(objLibro.debe);
                }
                if (TipoBol == 3)
                {
                    txtBaseCajaMenor.Text = Convert.ToString(objLibro.debe);
                }

            }
        }
    }
}

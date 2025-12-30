using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using Invenpol_Parqueadero_Motos.Formularios.Tiemda;
using SERINSI_PC.Clases;
using SERINSI_PC.Formularios.Ventas;
using Sistema_POS.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Orden_de_Servicio
{
    public partial class frmCierreOrdenServicio : Form
    {
        public frmCierreOrdenServicio()
        {
            InitializeComponent();
        }

        private void btnRetirarArticulo_Click(object sender, EventArgs e)
        {
            frmOrdenServicio frm =Owner as frmOrdenServicio;
            frm.FactuarOrden = "no";
            this.Close();
        }
        private bool VerificarPermisoSubModulo(int IdSubModulo)
        {
            DataTable objPermisoSubModulo = new DataTable();
            objPermisoSubModulo = ControladorPermisoSubModulo.consultarIdusuario(VariablesPublicas.IdUsuarioLogueado);
            if (objPermisoSubModulo != null)
            {
                foreach(DataRow rows1 in objPermisoSubModulo.Rows)
                {
                    if (Convert.ToInt32(rows1["idSubModulo"]) == IdSubModulo)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        private void btnFacturarOrden_Click(object sender, EventArgs e)
        {
            if (VariablesPublicas.IdBaseActiva == 0)
            {
                MessageBox.Show("Para poder continuar debe activar la base de la caja.", "Base Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool permiso = VerificarPermisoSubModulo(11);
            if (permiso == true)
            {

                    bool Formulario = VerificarFormulario.FormularioActivo("frmCajaTouch");
                if (Formulario == true)
                {
                    if (MessageBox.Show("¿Usar precios al por mayor?", "Tipo de Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        VariablesPublicas.AlPorMayor = true;
                    }
                    else
                    {
                        VariablesPublicas.AlPorMayor = false;
                    }
                    frmCajaTouch frm = new frmCajaTouch();
                    VariablesPublicas.UltimaCajaActiva = 1;
                    frm.Show();
                } 
            }
            this.Close();
        }

        private void frmCierreOrdenServicio_Load(object sender, EventArgs e)
        {
            
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
    }
}

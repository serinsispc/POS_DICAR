using DAL.Controladores;
using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_SERINSIS_PC_2022.Formularios.Configuracion
{
    public partial class frmBuscadorVendedor : Form
    {
        public frmBuscadorVendedor()
        {
            InitializeComponent();
        }

        //declaramos el objeto lista para la tabla de los cleintes
        public List<V_Vendedor> ListaVendedor = new List<V_Vendedor>();
        int IdVendedor = 0;
        string NombreVendedore = "";
        string Telefono = "";
        private void SeleccionarDG()
        {
            if (dgBuscarVendedor.RowCount > 0 && dgBuscarVendedor.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgBuscarVendedor.Rows[dgBuscarVendedor.CurrentRow.Index];
                IdVendedor = Convert.ToInt32(fila.Cells["id"].Value);
                NombreVendedore = Convert.ToString(fila.Cells["nombreVendedor"].Value);
                Telefono = Convert.ToString(fila.Cells["telefonoVEndedor"].Value);
            }
        }
        private void CerrarFormulario()
        {
            frmRutero frm = Owner as frmRutero;
            frm.txtVendedor.Text = NombreVendedore;
            frm.txtTelefonoVendedor.Text = Telefono;
            frm.IdVendedor_frm = IdVendedor;
            this.Close();
        }
        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            SeleccionarDG();
            CerrarFormulario();
        }

        private void txtVendedor_TextChanged(object sender, EventArgs e)
        {
            if (txtVendedor.Text != "")
            {
                dgBuscarVendedor.DataSource = ListaVendedor.Where(x =>
                x.nombreVendedor.Contains(txtVendedor.Text) ||
                x.telefonoVendedor.Contains(txtVendedor.Text)).ToList();
            }
        }

        private void txtVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtVendedor.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //dgBuscarCliente.DataSource = ControladorClienteTienda.BuscadorCliente(txtCliente.Text);
                    SeleccionarDG();
                    CerrarFormulario();
                }
            }
        }

        private void frmBuscadorVendedor_Load(object sender, EventArgs e)
        {
            dgBuscarVendedor.DataSource = ListaVendedor;
        }
    }
}

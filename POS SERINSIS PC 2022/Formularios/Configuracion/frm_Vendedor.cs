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

namespace SERINSI_PC.Formularios.Configuracion
{
    public partial class frm_Vendedor : Form
    {
        int IdVendedor = 0;
        public frm_Vendedor()
        {
            InitializeComponent();
        }

        private void frm_Vendedor_Load(object sender, EventArgs e)
        {
            Cargar_DG();
        }
        private void Cargar_DG()
        {
            dgVendedores.DataSource = controladorVendedor.Lista_Completa();
        }
        private void SeleccionarVEndedor()
        {
            if (dgVendedores.RowCount > 0 && dgVendedores.CurrentRow.Index>=0)
            {
                DataGridViewRow fila = dgVendedores.Rows[dgVendedores.CurrentRow.Index];

                IdVendedor = Convert.ToInt32(fila.Cells["id"].Value);
                txtNombreVendedor.Text = Convert.ToString(fila.Cells["nombreVendedor"].Value);
                txtCelular.Text = Convert.ToString(fila.Cells["telefonoVendedor"].Value);
                txtClave.Text = Convert.ToString(fila.Cells["calveVendedor"].Value);

                GestionarBotones(1);
                txtNombreVendedor.Focus();
            }
        }
        private void GestionarBotones(int Boton)
        {
            if (Boton == 0)
            {
                btnNuevo.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                btnNuevo.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }
        private bool GestionarVEndedor(int Boton)
        {
            Vendedor vendedor = new Vendedor();
            vendedor = controladorVendedor.Consultar_id(IdVendedor);
            if(vendedor != null)
            {
                if (Boton == 0) return false;
            }
            if(Boton == 0)
            {
                vendedor = new Vendedor();
                IdVendedor = 0;
            }
            vendedor.id = IdVendedor;
            vendedor.nombreVendedor = txtNombreVendedor.Text;
            vendedor.telefonoVendedor =txtCelular.Text;
            vendedor.calveVendedor = txtClave.Text;
            bool crud = controladorVendedor.Crud(vendedor,Boton);
            return crud;
        }
        private bool ValidarCampos()
        {
            if(txtNombreVendedor.Text!=""&&
                txtClave.Text!=""&&
                txtCelular.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void RefrescarFormulario()
        {
            GestionarBotones(0);
            txtCelular.Text = "";
            txtClave.Text = "";
            txtNombreVendedor.Text = "";
            Cargar_DG();
            txtNombreVendedor.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bool campos = ValidarCampos();
            if (campos == true)
            {
                bool gestionar = GestionarVEndedor(0);
                if (gestionar == true)
                {
                    MessageBox.Show("¡Vendedor creado correctamente...!","¡Ok!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    RefrescarFormulario();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            bool campos = ValidarCampos();
            if (campos == true)
            {
                bool gestionar = GestionarVEndedor(1);
                if (gestionar == true)
                {
                    MessageBox.Show("¡Vendedor editado correctamente...!", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    RefrescarFormulario();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool campos = ValidarCampos();
            if (campos == true)
            {
                bool gestionar = GestionarVEndedor(2);
                if (gestionar == true)
                {
                    MessageBox.Show("¡Vendedor eliminado correctamente...!", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    RefrescarFormulario();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarFormulario();
        }

        private void dgVendedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarVEndedor();
        }
    }
}

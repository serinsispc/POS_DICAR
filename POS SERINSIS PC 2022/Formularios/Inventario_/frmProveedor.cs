using DAL.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Modelo;
using SERINSI_PC.Formularios.Inventario;
using SERINSI_PC.Clases;

namespace SERINSI_PC.Formularios.Ventas
{
    public partial class frmProveedor : Form
    {
        public Form FormularioLlamado = null;
        int IdProveedor = 0;
        public frmProveedor()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (FormularioLlamado != null)
            {
                frmGestionarProducto frm =Owner as frmGestionarProducto;

                this.Close();
            }
            else
            {
                this.Close();
            }

        }

        private void frmProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar.PerformClick();
            }
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            cmbEstadoProveedor.ValueMember = "id";
            cmbEstadoProveedor.DisplayMember = "nombreEstadoAi";
            cmbEstadoProveedor.DataSource = ControladorEstadoAI.listaCompleta();

            if (FormularioLlamado != null)
            {
                panelTitulo.Visible = true;
            }
            GestionarBotones(0);
            CargarDG();
            txtNit.Focus();
        }
        private void CargarDG()
        {
            dgProveedor.DataSource = ControladorProveedor.listaCompleta();
        }
        private void GestionarBotones(int Boton)
        {
            if(Boton == 0)
            {
                btnGuardar.Text = "Crear";
                btnEliminar.Enabled = false;
            }
            else
            {
                btnGuardar.Text = "Editar";
                btnEliminar.Enabled = true;
            }
        }

        private void txtNit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNombre.Focus();
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar.PerformClick();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNit.Text != ""&&
                txtNombre.Text!=""&&
                txtTelefono.Text!=""&&
                txtDireccion.Text!=""&&
                txtEmail.Text!="")
            {
                if (btnGuardar.Text == "Crear")
                {
                    GestionarProveedor(0);
                }
                else
                {
                    GestionarProveedor(1);
                }
            }
            else
            {
                MessageBox.Show("Aún hay campos vacíos.", "Campos vacíos.", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void GestionarProveedor(int Boton)
        {
            Proveedor objproveedor = new Proveedor();
            objproveedor = ControladorProveedor.ConsultarX_IdProveedor(IdProveedor);
            if (objproveedor != null)
            {
                if(Boton == 0)
                {
                    MessageBox.Show("El proveedor que desea crear ya existe.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            if(Boton == 0)
            {
                IdProveedor = 0;
                objproveedor = new Proveedor();
            }
            objproveedor.id = IdProveedor;
            objproveedor.documentoProveedor = txtNit.Text;
            objproveedor.nombreProveedor = txtNombre.Text;
            objproveedor.telefonoProveedor = txtTelefono.Text;
            objproveedor.direccionProveedor = txtDireccion.Text;
            objproveedor.emailProveedor = txtEmail.Text;
            objproveedor.idEstado = Convert.ToInt32(cmbEstadoProveedor.SelectedValue);
            bool SQL = ControladorProveedor.GuardarEditarEliminar(objproveedor,Boton);
            if(SQL == true)
            {
                if(Boton == 0)
                {
                    MessageBox.Show("Proveedor creado correctamente.","Creado",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                if (Boton == 1)
                {
                    MessageBox.Show("Proveedor editado correctamente.", "Editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Boton == 2)
                {
                    MessageBox.Show("Proveedor eliminado correctamente.", "Elimminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ActualizarFormulario();
            }
        }
        private void ActualizarFormulario()
        {
            IdProveedor = 0;
            txtNit.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            CargarDG();
            txtNit.Focus();
            GestionarBotones(0);
            cmbEstadoProveedor.SelectedIndex = -1;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarFormulario();
        }

        private void dgProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgProveedor.RowCount > 0 && e.RowIndex >= 0)
            {
                DataGridViewRow Fila = dgProveedor.Rows[e.RowIndex];
                IdProveedor = Convert.ToInt32(Fila.Cells["id"].Value);
                txtNit.Text = Convert.ToString(Fila.Cells["documentoProveedor"].Value);
                txtNombre.Text = Convert.ToString(Fila.Cells["nombreProveedor"].Value);
                txtDireccion.Text = Convert.ToString(Fila.Cells["direccionProveedor"].Value);
                txtTelefono.Text = Convert.ToString(Fila.Cells["telefonoProveedor"].Value);
                txtEmail.Text = Convert.ToString(Fila.Cells["emailProveedor"].Value);
                if (Fila.Cells["idEstado"].Value != null)
                {
                    cmbEstadoProveedor.SelectedValue = Convert.ToInt32(Fila.Cells["idEstado"].Value);
                }
                else
                {
                    cmbEstadoProveedor.SelectedIndex = 0;
                }
                GestionarBotones(1);
                txtNit.Focus();
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtNit.Text != "" &&
    txtNombre.Text != "" &&
    txtTelefono.Text != "" &&
    txtDireccion.Text != "" &&
    txtEmail.Text != "")
            {
                GestionarProveedor(2);
            }
            else
            {
                MessageBox.Show("Aún hay campos vacíos.", "Campos vacíos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

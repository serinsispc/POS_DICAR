using DAL;
using DAL.Controladores;
using DAL.Controladores.Administrador;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using SERINSI_PC.Clases;
using SERINSI_PC.Formularios;
using SERINSI_PC.Formularios.Configuracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invenpol_Parqueadero_Motos.Formularios
{
    public partial class frmRegistrarUsuario : Form
    {
        public frmRegistrarUsuario()
        {
            InitializeComponent();
        }
        //creamos las variables para usar en el formulario
        int boto = 0;
        int IdUsuario = 0;
        int IdTipo = 0;
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            //llamamos la funcion que gestiona las condciones 
            bool Respuesta = Condiciones();
            if (Respuesta == true)
            {
                //llamamos la funcion que se encarga de gestionar el usuario
                await Gestionarusuario(0);
            }
            else
            {
                MessageBox.Show("Hay campos vacíos o la clave no coincide.",
                                "ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }
        public async Task Gestionarusuario(int Boton)
        {
            //creamos el objeto para consultar el id usuario
            Usuario objUsuario = new Usuario();
            objUsuario =await ControladorUsuario.ConsultaUsuarioXId(IdUsuario);
            if(objUsuario != null)
            {
                if(Boton == 0)
                {
                    MessageBox.Show("El usuario que va a crear ya está registrado.",
                                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if(Boton == 0)
            {
                objUsuario = new Usuario();
            }
            objUsuario.id = IdUsuario;
            objUsuario.identificacionUsuario = txtIdentificacion.Text;
            objUsuario.nombreUsuario = txtNombreUsuario.Text;
            objUsuario.telefonoUsuario = txtTelefono.Text;
            objUsuario.cuentaUsuario = txtUsuario.Text;
            objUsuario.claveUsuario = txtClave.Text;
            objUsuario.idTipoUsuario = Convert.ToInt32(cmbTipoUsuario.SelectedValue);
            objUsuario.idEstadoAI = Convert.ToInt32(cmbEstado.SelectedValue);
            objUsuario.estado_usuario = "1";
            //enviamos elobjeto al controlador
            RespuestaCRUD Respuesta =await ControladorUsuario.GuardarEditarEliminar(objUsuario, Boton);
            if (Respuesta.estado == true)
            {
                if(Boton == 0)
                {
                    MessageBox.Show("Usuario creado correctamente.","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                if (Boton == 1)
                {
                    MessageBox.Show("Usuario editado correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if(Boton == 2)
                {
                    MessageBox.Show("Usuario eliminado correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LimpiarFormulario();
                await LLenardataGrid();
                GestionarBotones(0);
               
            }
        }

        public bool Condiciones()
        {
            if(txtNombreUsuario.Text =="" ||
               txtTelefono.Text == "" ||
               cmbTipoUsuario.Text =="" ||
               txtIdentificacion.Text ==""||
               txtUsuario.Text ==""||
               txtClave.Text ==""||
               txtConfirmarClave.Text ==""||
               cmbTipoUsuario.Text ==""||
               txtClave.Text != txtConfirmarClave.Text)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void frmRegistrarUsuario_Load(object sender, EventArgs e)
        {
            dgUsuario.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            //llamamos la funcion que llenan los cmb
            await LLenarCmb();
            //llenar la datagrid
            await LLenardataGrid();
            //llamamos la funcion que gestiona los botones
            GestionarBotones(0);
        }
        public void GestionarBotones(int Boton)
        {
            if (Boton == 0)
            {
                btnCrear.Enabled = true;
                btnEditar.Enabled = false;
                btnBorrar.Enabled = false;

                cmbTipoUsuario.Enabled = true;
                cmbEstado.Enabled = true;
            }
            else
            {
                btnCrear.Enabled = false; 
                btnEditar.Enabled = true;
                btnBorrar.Enabled = true;

                if (IdTipo == 1)
                {
                    cmbTipoUsuario.Enabled = false;
                    cmbEstado.Enabled = false;
                }
                else
                {
                    cmbTipoUsuario.Enabled = true;
                    cmbEstado.Enabled = true;
                }
            }
        }

        public async Task LLenardataGrid()
        {
            dgUsuario.DataSource =await ControladorUsuario.listaCompleta();
        }

        private async Task LLenarCmb()
        {
            cmbTipoUsuario.ValueMember = "id";
            cmbTipoUsuario.DisplayMember = "nombreTipoUsuario";
            cmbTipoUsuario.DataSource =await controladorTipoUsuario.listaCompleta();

            cmbEstado.ValueMember = "id";
            cmbEstado.DisplayMember = "nombreEstadoAi";
            cmbEstado.DataSource =await ControladorEstadoAI.listaCompleta();
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //llamamos la funcion que limpia el formulario
            LimpiarFormulario();
            GestionarBotones(0);
        }
        public void LimpiarFormulario()
        {
            txtNombreUsuario.Text = "";
            txtTelefono.Text = "";
            cmbTipoUsuario.SelectedIndex = 0;
            txtIdentificacion.Text = "";
            txtUsuario.Text = "";
            cmbEstado.SelectedIndex = 0;
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            //vaciamos las variables
            boto = 0;
            IdUsuario = 0;
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            //llamamos la funcion que gestiona las condciones 
            bool Respuesta = Condiciones();
            if (Respuesta == true)
            {
                //llamamos la funcion que se encarga de gestionar el usuario
                await Gestionarusuario(1);
            }
            else
            {
                MessageBox.Show("Hay campos vacíos o la clave no coincide.",
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (IdTipo == 1)
            {
                MessageBox.Show("El usuario super administrador no se puede eliminar.",
                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IdUsuario != 0)
            {
                //llamamos la funcion que se encarga de gestionar el usuario
                await Gestionarusuario(2);
            }
            else
            {
                MessageBox.Show("No hay un usuario seleccionado.",
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmRegistrarUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar.PerformClick();
            }
        }

        private void txtNombreUsuario_KeyDown(object sender, KeyEventArgs e)
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
                cmbTipoUsuario.Focus();
            }

        }

        private void cmbTipoUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtIdentificacion.Focus();
            }
        }

        private void txtIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbEstado.Focus();
            }
        }

        private void cmbEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUsuario.Focus();
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtClave.Focus();
            }
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtConfirmarClave.Focus();
            }
        }

        private void txtConfirmarClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnCrear.Enabled == true)
                {
                    btnCrear.Focus();
                }
                else
                {
                    btnEditar.Focus();
                }

            }
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            frmPermisos frm = new frmPermisos();
            AddOwnedForm(frm);
            frm.IdusuarioGestion = IdUsuario;
            frm.ShowDialog();
        }

        private void dgUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgUsuario.RowCount > 0 && e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgUsuario.Rows[e.RowIndex];
                //llenamos las cajas de texto
                IdUsuario = Convert.ToInt32(fila.Cells["id"].Value);
                IdTipo = Convert.ToInt32(fila.Cells["idTipoUsuario"].Value);
                cmbTipoUsuario.SelectedValue = IdTipo;
                txtNombreUsuario.Text = Convert.ToString(fila.Cells["nombreUsuario"].Value);
                txtTelefono.Text = Convert.ToString(fila.Cells["telefonoUsuario"].Value);
                txtIdentificacion.Text = Convert.ToString(fila.Cells["identificacionUsuario"].Value);
                txtUsuario.Text = Convert.ToString(fila.Cells["cuentaUsuario"].Value);
                cmbEstado.SelectedValue = Convert.ToInt32(fila.Cells["idEstadoAI"].Value);
                txtClave.Text = Convert.ToString(fila.Cells["claveUsuario"].Value);
                txtConfirmarClave.Text = Convert.ToString(fila.Cells["claveUsuario"].Value);
                //ahora se gestiona los botones para editar
                GestionarBotones(1);

                if (IdTipo == 1)
                {
                    btnBorrar.Enabled = false;
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

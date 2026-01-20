using DAL;
using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using Invenpol_Parqueadero_Motos.Formularios.Tiemda;
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
    public partial class frmClienteTienda : Form
    {
        public int IdVenta = 0;
        public int CajaMadre=0;
        int IdCliente = 0;
        string ContadoCredito = "";
        public string FormularioMadre = "";
        public frmClienteTienda()
        {
            InitializeComponent();
        }

        private void frmClienteTienda_Load(object sender, EventArgs e)
        {
            LLenarDGClientes();
            GestionarBotones(0);
            txtNombreCliente.Focus();
        }

        private async void   txtNIT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNIT.Text != "")
                {
                    //en esta parte buscamos al cliente por el nit
                    Clientes objCliente = new Clientes();
                    objCliente =await ControladorClienteTienda.ConsultarX_NIT(txtNIT.Text);
                    if (objCliente != null)
                    {
                        IdCliente = objCliente.id;
                        txtNombreCliente.Text = objCliente.nombreCliente;
                        txtTelefono.Text = objCliente.telefonoCliente;
                        txtDireccion.Text = objCliente.direccionCliente;

                        btnAgregarCliente.Visible = true;
                        btnAgregarCliente.Focus();
                        return;
                    }
                }
                txtRazonSocial.Focus();
            }
        }
        private void txtNombreCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNombreCliente.Text != "")
                {
                    if (dgClienteVenta.RowCount > 0)
                    {
                        SeleccionarCliente();
                        btnAgregarCliente.PerformClick();
                    }
                    else
                    {
                        txtNIT.Focus();
                    }
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                dgClienteVenta.Focus();
            }
        }
        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {

        }
        private void LLenarDGClientes()
        {
            dgClienteVenta.DataSource = ControladorClienteTienda.ListaCompleta();
        }
        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCrear.PerformClick();
            }
        }
        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelefono.Focus();
            }
        }
        private async void btnCrear_Click(object sender, EventArgs e)
        {
            //Lo primero que debemos hacer es verificar los campos 
            bool Campos = EvaluarCampos();
            if (Campos == true)
            {
                await GestionarCliente(0);
            }
            else
            {
                MessageBox.Show("Hay campos vacíos ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool EvaluarCampos()
        {
            if (txtNombreCliente.Text != "" &&
                txtTelefono.Text != ""&&
                txtNIT.Text!=""&&
                txtCorrero.Text!="")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private async Task GestionarCliente(int Boton)
        {
            Clientes objCT = new Clientes();
            objCT =await ControladorClienteTienda.ConsultarX_ID(IdCliente);
            if (objCT != null)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("El cliente que desea ingresar ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (Boton == 0)
            {
                Clientes objCT2 = new Clientes();
                objCT =await ControladorClienteTienda.ConsultarX_Nombre(txtNombreCliente.Text);
                if (objCT != null)
                {
                    if (Boton == 0)
                    {
                        MessageBox.Show("El cliente que desea ingresar ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            if (Boton == 0)
            {
                IdCliente = 0;
                objCT = new Clientes();
            }
            objCT.id = IdCliente;
            objCT.nombreCliente = txtNombreCliente.Text;
            objCT.razonSocialCliente = txtRazonSocial.Text;
            objCT.documentoCliente = txtNIT.Text;
            objCT.direccionCliente = txtDireccion.Text;
            objCT.telefonoCliente = txtTelefono.Text;
            objCT.ciudadCliente=txtCiudad.Text;
            objCT.barrioCliente = txtBarrio.Text;
            objCT.idSede = VariablesPublicas.IdEmpresaLogueada;
            objCT.codigoCliente = txtCodigo.Text;
            objCT.correo = txtCorrero.Text;
            bool SQL =await ControladorClienteTienda.Crear_Editar_Elimnar_ClienteTienda(objCT, Boton);
            if (SQL == true)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("El cliente fue creado correctamente", "Cliente Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Boton == 1)
                {
                    MessageBox.Show("El cliente fue editado correctamente", "Cliente Editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LLenarDGClientes();
                LimpiarFormulario();
                GestionarBotones(0);
                txtNombreCliente.Focus();
            }

        }
        private void LimpiarFormulario()
        {
            txtNombreCliente.Text = "";
            txtNIT.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            IdCliente = 0;
        }
        private void GestionarBotones(int Boton)
        {
            if (Boton == 0)
            {
                //btnCerrar.Enabled = true;
                btnEditar.Enabled = false;
            }
            else
            {
                //btnCerrar.Enabled = false;
                btnEditar.Enabled = true;
            }
        }
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            //Lo primero que debemos hacer es verificar los campos 
            bool Campos = EvaluarCampos();
            if (Campos == true)
            {
                await GestionarCliente(1);
            }
            else
            {
                MessageBox.Show("Hay campos vacíos ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LLenarDGClientes();
            LimpiarFormulario();
            GestionarBotones(0);
            txtNombreCliente.Focus();
        }
        private void dgClienteVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarCliente();
        }
        private void SeleccionarCliente()
        {
            if (dgClienteVenta.RowCount > 0 && dgClienteVenta.CurrentRow.Index >= 0)
            {
                DataGridViewRow Fila = dgClienteVenta.Rows[dgClienteVenta.CurrentRow.Index];

                IdCliente = Convert.ToInt32(Fila.Cells["id"].Value);
                
                txtRazonSocial.Text = Convert.ToString(Fila.Cells["razonSocialCliente"].Value);
                txtNIT.Text = Convert.ToString(Fila.Cells["documentoCliente"].Value);
                txtTelefono.Text = Convert.ToString(Fila.Cells["telefonoCliente"].Value);
                txtDireccion.Text = Convert.ToString(Fila.Cells["direccionCliente"].Value);
                txtRazonSocial.Text = Convert.ToString(Fila.Cells["razonSocialCliente"].Value);
                txtNombreCliente.Text = Convert.ToString(Fila.Cells["nombreCliente"].Value);
                txtCiudad.Text = Convert.ToString(Fila.Cells["ciudadCliente"].Value);
                txtBarrio.Text = Convert.ToString(Fila.Cells["barrioCliente"].Value);
                txtCodigo.Text = Convert.ToString(Fila.Cells["codigoCliente"].Value);
                txtCorrero.Text = Convert.ToString(Fila.Cells["correo"].Value);

                btnAgregarCliente.Enabled = true;
                GestionarBotones(1);
            }
            else
            {
                txtNombreCliente.Focus();
            }
            txtNombreCliente.Focus();
        }
        private async void btnCredito_Click(object sender, EventArgs e)
        {
            int Boton = 0;
            int IdRelacion = 0;
            if (FormularioMadre == "cobroCaja")
            {
                //en esta parte creamos la relacion de venta cliente
                R_VentaCliente objRVC = new R_VentaCliente();
                objRVC =await controladorRVentaCleinte.ConsultarRelacion(IdVenta);
                if (objRVC != null)
                {
                    Boton = 1;
                    IdRelacion = objRVC.id;
                }
                else
                {
                    Boton = 0;
                    IdRelacion = 0;
                }
                //ahora creamos la relacion
                objRVC = new R_VentaCliente();
                objRVC.id = IdRelacion;
                objRVC.idVenta = IdVenta;
                objRVC.idCliente = IdCliente;
                objRVC.idSede = VariablesPublicas.IdEmpresaLogueada;
                RespuestaCRUD sqlRelacion =await controladorRVentaCleinte.Crud(objRVC, Boton);
                if (sqlRelacion.estado == true)
                {
                    VariablesPublicas.IdCliente = IdCliente;
                    frmCobroCaja frm2 = Owner as frmCobroCaja;
                    frm2.IdCliente = IdCliente;
                    frm2.IdentificacionCliente = txtNIT.Text;
                    frm2.NombreCliente = txtNombreCliente.Text;
                    frm2.DireccionCliente = txtDireccion.Text;
                    frm2.TelefonoCliente =txtTelefono.Text;
                    btnCerrar.PerformClick();
                }
                else
                {
                    MessageBox.Show("No se puede agregar el cliente.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                GestionarBotones(1);
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgClienteVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarCliente();
                btnAgregarCliente.PerformClick();
            }
        }

        private void frmClienteTienda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar.PerformClick();
            }
        }

        private void txtNumeroLocal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDireccion.Focus();
            }
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarCliente.Text != "")
            {
                dgClienteVenta.DataSource = ControladorClienteTienda.FiltarX_Nombre(txtBuscarCliente.Text);
            }
            else
            {
                LLenarDGClientes();
            }
        }
    }
}

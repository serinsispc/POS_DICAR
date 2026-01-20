using DAL;
using DAL.Controladores;
using DAL.Controladores.Tienda;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using SERINSI_PC.Clases;
using SERINSI_PC.Formularios.Inventario_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Inventario
{
    public partial class frmMerma : Form
    {
        public frmMerma()
        {
            InitializeComponent();
        }
        public int idInventarioTotal_frm = 0;
        public int idInventario_frm = 0;
        int idmerma_frm = 0;
        int cantidadPresentacion_frm = 0;
        private async void frmMerma_Load(object sender, EventArgs e)
        {
            await LLenarCMB();
            CargarDG();
            txtBuscarCodigo.Focus();
        }
        private void CargarDG()
        {
            dgMerma.DataSource = ControladorMerma.listaCompleta();
        }
        public async Task LLenarCMB()
        {
            cmbTipoMerma.DataSource = null;
            cmbTipoMerma.ValueMember = "id";
            cmbTipoMerma.DisplayMember = "nombreTipoMerma";
            cmbTipoMerma.DataSource =await ControladorTipoMerma.ListaCompleta();
        }


        private void txtMorivoMerma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCantidad.Focus();
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbTipoMerma.Text != "" &&
               txtBuscarCodigo.Text != "" &&
               txtDescripcionProducto.Text != "" &&
               txtCantidad.Text != ""&&
               txtObservacion.Text!="")
            {
                cantidadPresentacion_frm = Convert.ToInt32(txtCantidad.Text);
                await GestionarMerma(0);
            }
        }
        private async Task GestionarMerma(int Boton)
        {
            Merma objMerma = new Merma();
            objMerma =await ControladorMerma.ConsultarID(idmerma_frm);
            if (objMerma != null)
            {
                if (Boton == 0)
                {
                    return;
                }
            }
            if (Boton == 0)
            {
                idmerma_frm = 0;
                objMerma = new Merma();
            }
            objMerma.id = idmerma_frm;
            objMerma.idTipoMerma = Convert.ToInt32(cmbTipoMerma.SelectedValue);
            objMerma.idUsuario = VariablesPublicas.IdUsuarioLogueado;
            objMerma.idInventarioTotal = idInventarioTotal_frm;
            objMerma.idInventario = idInventario_frm;
            objMerma.fechaMerma = dtFechaMerma.Value;
            objMerma.cantidadMerma = cantidadPresentacion_frm;
            objMerma.observacion =txtObservacion.Text;
            RespuestaCRUD sql =await ControladorMerma.Crud(objMerma, Boton);
            if (sql.estado == true)
            {
                MessageBox.Show("producto descontado correctamente.", "Merma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDG();
                txtBuscarCodigo.Text = "";
                txtDescripcionProducto.Text = "";
                txtObservacion.Text = "";
                idmerma_frm = 0;
                idInventarioTotal_frm = 0;
                idInventario_frm = 0;
                txtBuscarCodigo.Focus();
            }
        }
        private bool RetornarInventario(int cantidad)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "Update Inventario set inventarioActual = inventarioActual - " + cantidad + " where idProducto=" + idInventarioTotal_frm;
                cmd.ExecuteNonQuery();
                ConexionSQL.CerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            SeleccionarMerma();
            await GestionarMerma(2);
        }
        private void SeleccionarMerma()
        {
            if (dgMerma.RowCount > 0 && dgMerma.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgMerma.Rows[dgMerma.CurrentRow.Index];
                idmerma_frm= Convert.ToInt32(fila.Cells["id"].Value);
                txtBuscarCodigo.Text = Convert.ToString(fila.Cells["codigoProducto"].Value);
                txtDescripcionProducto.Text = Convert.ToString(fila.Cells["descripcionProducto"].Value);
                txtObservacion.Text = Convert.ToString(fila.Cells["observacion"].Value);
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmBuscadorProducto frm = new Inventario.frmBuscadorProducto();
            AddOwnedForm(frm);
            frm.dgProducto.DataSource = ControladorProducto.FiltrarX_IdSede(VariablesPublicas.IdEmpresaLogueada,0);
            frm.Foco = 0;
            frm.ShowDialog();
            txtObservacion.Focus();
        }

        private void btnGuardar_Enter(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.Gray;
        }

        private void btnGuardar_Leave(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.Transparent;
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar.Focus();
            }
        }

        private void btnEliminar_Enter(object sender, EventArgs e)
        {
            btnEliminar.BackColor = Color.Gray;
        }

        private void btnEliminar_Leave(object sender, EventArgs e)
        {
            btnEliminar.BackColor = Color.Transparent;
        }

        private async void txtBuscarCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBuscarCodigo.Text != "")
                {
                    v_productoVenta objBuscador = new v_productoVenta();
                    objBuscador =await ControladorProducto.BuscarCodigo(VariablesPublicas.IdEmpresaLogueada, 1, txtBuscarCodigo.Text);
                    if (objBuscador != null)
                    {
                        idInventario_frm = objBuscador.idInventario;
                        txtDescripcionProducto.Text = objBuscador.descripcionProducto;
                        idInventarioTotal_frm = objBuscador.id;
                        txtObservacion.Focus();
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_TipoMerma frm = new frm_TipoMerma();
            AddOwnedForm(frm);
            frm.ShowDialog();
            LLenarCMB();
        }
    }
}

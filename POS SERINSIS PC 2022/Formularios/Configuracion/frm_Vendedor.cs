using DAL;
using DAL.Controladores;
using DAL.Modelo;
using POS_SERINSIS_PC_2022.Formularios;
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
        public List<V_Vendedor> ListaVendedor { get; set; }
        private async void frm_Vendedor_Load(object sender, EventArgs e)
        {
            FrmLoading loading = null;
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    loading = FrmLoading.ShowLoading(this, "Cargarndo...");
                    // inicio

                    ListaVendedor= await controladorVendedor.Lista_Completa();

                    await Cargar_DG();


                    // fin
                    FrmLoading.CloseLoading(this, loading);
                }
            }
            catch (Exception ex)
            {
                FrmLoading.CloseLoading(this, loading);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async Task Cargar_DG()
        {
            dgVendedores.DataSource = ListaVendedor;
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
        private async Task<bool> GestionarVEndedor(int Boton)
        {
            Vendedor vendedor = new Vendedor();
            vendedor =await controladorVendedor.Consultar_id(IdVendedor);
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
            RespuestaCRUD crud =await controladorVendedor.Crud(vendedor,Boton);
            return crud.estado;
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
        private async Task RefrescarFormulario()
        {
            GestionarBotones(0);
            txtCelular.Text = "";
            txtClave.Text = "";
            txtNombreVendedor.Text = "";
            await Cargar_DG();
            txtNombreVendedor.Focus();
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            bool campos = ValidarCampos();
            if (campos == true)
            {
                bool gestionar =await GestionarVEndedor(0);
                if (gestionar == true)
                {
                    MessageBox.Show("¡Vendedor creado correctamente...!","¡Ok!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    await RefrescarFormulario();
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            bool campos = ValidarCampos();
            if (campos == true)
            {
                bool gestionar =await GestionarVEndedor(1);
                if (gestionar == true)
                {
                    MessageBox.Show("¡Vendedor editado correctamente...!", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    await RefrescarFormulario();
                }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            bool campos = ValidarCampos();
            if (campos == true)
            {
                bool gestionar =await GestionarVEndedor(2);
                if (gestionar == true)
                {
                    MessageBox.Show("¡Vendedor eliminado correctamente...!", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    await RefrescarFormulario();
                }
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await RefrescarFormulario();
        }

        private void dgVendedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarVEndedor();
        }
    }
}

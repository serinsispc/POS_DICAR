using DAL;
using DAL.Controladores;
using DAL.Modelo;
using POS_SERINSIS_PC_2022.Reportes;
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

namespace POS_SERINSIS_PC_2022.Formularios.Configuracion
{
    public partial class frmRutero : Form
    {
        //declaramos las listas
        List<V_Rutero> ListaRutero = new List<V_Rutero>();
        List<V_Cliente>ListaCliente=new List<V_Cliente>();
        List<V_Vendedor>ListaVendedor=new List<V_Vendedor>();

        public int IdCliente_frm = 0;
        public int IdVendedor_frm = 0;
        public frmRutero()
        {
            InitializeComponent();
        }

        private async void frmRutero_Load(object sender, EventArgs e)
        {
            FrmLoading loading = null;
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    loading = FrmLoading.ShowLoading(this, "Cargarndo...");

                    //en esta aprte cargamos todas las listas
                    await CargarListaRutero();
                    ListaCliente = await ControladorClienteTienda.ListaCompleta();
                    ListaVendedor = await controladorVendedor.Lista_Completa();

                    await Cargar_CB_Dias();
                    GestionarBotones(0);

                    await Cargar_cbVendedor();

                    FrmLoading.CloseLoading(this, loading);
                }
            }
            catch (Exception ex)
            {
                FrmLoading.CloseLoading(this, loading);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async Task Cargar_cbVendedor()
        {
            cbVendedor.ValueMember = "id";
            cbVendedor.DisplayMember = "nombreVendedor";
            cbVendedor.DataSource =await controladorVendedor.Lista_Completa();
            cbVendedor.SelectedIndex = -1;
        }
        private async Task CargarListaRutero()
        {
            ListaRutero =await controladorRutero.ListaCompleta();
        }
        private async Task Cargar_CB_Dias()
        {
            cbDia.ValueMember = "id";
            cbDia.DisplayMember = "diaSemana";
            cbDia.DataSource =await controladorSemana.ListaCompleta();
            cbDia.SelectedIndex= - 1;

            cbFiltrarDia.ValueMember = "id";
            cbFiltrarDia.DisplayMember = "diaSemana";
            cbFiltrarDia.DataSource =await controladorSemana.ListaCompleta();
            cbFiltrarDia.SelectedIndex = -1;
        }
        private void RefrescarFormulario()
        {
            txtCliente.Text = "";
            txtDocumento.Text = "";
            txtTelefonoCliente.Text = "";

            txtVendedor.Text = "";
            txtTelefonoVendedor.Text = "";
        }
        public void GestionarBotones(int Boton)
        {
            if (Boton == 0)
            {
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscardorCliente frm = new frmBuscardorCliente();
            AddOwnedForm(frm);
            frm.ListaCliente = ListaCliente;
            if (IdVendedor_frm > 0 && Convert.ToInt32(cbDia.SelectedValue) > 0)
            {
                frm.idVendedor_frm = IdVendedor_frm;
                frm.idSemana_frm = Convert.ToInt32(cbDia.SelectedValue);
            }
            frm.ShowDialog();
        }

        private void btnBuscarVendedor_Click(object sender, EventArgs e)
        {
            frmBuscadorVendedor frm = new frmBuscadorVendedor();
            AddOwnedForm(frm);
            frm.ListaVendedor = ListaVendedor;
            frm.ShowDialog();
        }

        private void txtFiltrarRutero_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltrarRutero.Text != "")
            {
                dgRutas.DataSource = ListaRutero.Where(x =>
                x.nombreCliente.Contains(txtFiltrarRutero.Text) ||
                x.ciudadCliente.Contains(txtFiltrarRutero.Text)||
                x.barrioCliente.Contains(txtFiltrarRutero.Text)).ToList();
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            IdRutero = 0;
            IdCliente_frm = 0;
            IdVendedor_frm = 0;
            txtCliente.Text = "";
            txtDocumento.Text = "";
            txtTelefonoCliente.Text = "";
            txtVendedor.Text = "";
            txtTelefonoVendedor.Text = "";
            txtFiltrarRutero.Text = "";
            GestionarBotones(0);
            CargarListaRutero();
        }
        int IdRutero = 0;
        private void SeleccionarRuta()
        {
            if (dgRutas.RowCount >=0 && dgRutas.CurrentCell.RowIndex >= 0)
            {
                DataGridViewRow fila = dgRutas.Rows[dgRutas.CurrentRow.Index];
                IdRutero = Convert.ToInt32(fila.Cells["id"].Value);
                IdCliente_frm = Convert.ToInt32(fila.Cells["idCliente"].Value);
                IdVendedor_frm = Convert.ToInt32(fila.Cells["idVendedor"].Value);

                txtCliente.Text = Convert.ToString(fila.Cells["nombreCliente"].Value);
                txtDocumento.Text = Convert.ToString(fila.Cells["documentoCliente"].Value);
                txtTelefonoCliente.Text = Convert.ToString(fila.Cells["telefonoCliente"].Value);

                txtVendedor.Text = Convert.ToString(fila.Cells["nombreVendedor"].Value);
                txtTelefonoVendedor.Text = Convert.ToString(fila.Cells["telefonoVendedor"].Value);

                cbDia.SelectedValue = Convert.ToInt32(fila.Cells["idSemana"].Value);

                GestionarBotones(1);
            }
        }
        private void dgRutas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarRuta();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            bool validar = ValidarCampos();
            if (validar == true)
            {
                bool gestionar =await GestionarRutero(0);
                if (gestionar == true)
                {
                    await CargarListaRutero();
                    MessageBox.Show("¡Rutero Guardado correctamente...!","¡OK!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    btnRefrescar.PerformClick();
                }
            }
        }
        private async Task<bool> GestionarRutero(int Boton)
        {
            R_ClienteVendedor r_Cliente = new R_ClienteVendedor();
            r_Cliente =await controlador_R_ClienteVendedor.Consultar_IdRutero(IdRutero);
            if (r_Cliente != null)
            {
                if (Boton == 0)
                {
                    return false;
                }
            }
            if (Boton == 0)
            {
                r_Cliente = new R_ClienteVendedor();
                IdRutero = 0;
            }
            r_Cliente.id = IdRutero;
            r_Cliente.idCliente = IdCliente_frm;
            r_Cliente.idVendedor = IdVendedor_frm;
            r_Cliente.idSemana = Convert.ToInt32(cbDia.SelectedValue);
            return await controlador_R_ClienteVendedor.Crud(r_Cliente,Boton);     
        }
        private bool ValidarCampos()
        {
            if (IdCliente_frm > 0 && IdVendedor_frm > 0 && cbDia.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            bool validar = ValidarCampos();
            if (validar == true)
            {
                bool gestionar =await GestionarRutero(1);
                if (gestionar == true)
                {
                    await CargarListaRutero();
                    MessageBox.Show("¡Rutero Editado correctamente...!", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnRefrescar.PerformClick();
                }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {


            bool validar = ValidarCampos();
            if (validar == true)
            {
                bool gestionar =await GestionarRutero(2);
                if (gestionar == true)
                {
                    await CargarListaRutero();
                    MessageBox.Show("¡Rutero Eliminado correctamente...!", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnRefrescar.PerformClick();
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (cbVendedor.Text != "" && cbFiltrarDia.Text != "")
            {
                dgRutas.DataSource = ListaRutero.Where(x =>
                x.idVendedor == Convert.ToInt32(cbVendedor.SelectedValue) &&
                x.idSemana == Convert.ToInt32(cbFiltrarDia.SelectedValue)).ToList();
                int cantidadClientes = dgRutas.Rows.Count;
                txtCantidadCleintes.Text = cantidadClientes.ToString();
            }
        }

        private void txtFiltrarVendedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (cbVendedor.Text != "" && cbFiltrarDia.Text != "")
            {
                frmReporte frm = new frmReporte();
                AddOwnedForm(frm);
                frm.Rutero(cbVendedor.Text,cbFiltrarDia.Text, ListaRutero.Where(x =>
                x.idVendedor == Convert.ToInt32(cbVendedor.SelectedValue) &&
                x.idSemana == Convert.ToInt32(cbFiltrarDia.SelectedValue)).ToList());
                frm.ShowDialog();
            }
        }

        private void frmRutero_KeyDown(object sender, KeyEventArgs e)
        {
            if (cbFiltrarDia.Text != "" && cbVendedor.Text != "")
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar la ruta que corresponde al vendedor " + cbVendedor.Text + " del día " + cbFiltrarDia.Text + "?", "¿Eliminar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        try
                        {
                            ConexionSQL.AbrirConexion();
                            SqlCommand command = ConexionSQL.connection.CreateCommand();
                            command.CommandText = "delete R_ClienteVendedor  where R_ClienteVendedor.idVendedor="+Convert.ToInt32(cbVendedor.SelectedValue)+ " and idSemana="+Convert.ToInt32(cbFiltrarDia.SelectedValue);
                            command.ExecuteNonQuery();
                            ConexionSQL.CerrarConexion();
                            CargarListaRutero();
                            MessageBox.Show("¡Rutero Eliminado correctamente...!", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            btnRefrescar.PerformClick();
                        }
                        catch(Exception ex)
                        {
                            string error = ex.Message;
                        }
                    }
                }
            }
        }

        private void btnEliminarRutero_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = "";
                ConexionSQL.AbrirConexion();
                SqlCommand commandon = ConexionSQL.connection.CreateCommand();
                consulta = "delete R_ClienteVendedor where idvendedor = " + Convert.ToInt32(cbVendedor.SelectedValue) + " and idSemana = " + Convert.ToInt32(cbFiltrarDia.SelectedValue);

                commandon.CommandText = consulta;

                commandon.ExecuteNonQuery();
                ConexionSQL.CerrarConexion();
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
        }
    }
}

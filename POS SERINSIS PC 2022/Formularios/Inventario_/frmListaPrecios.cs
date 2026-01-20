using DAL;
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

namespace SERINSI_PC.Formularios.Inventario
{
    public partial class frmListaPrecios : Form
    {
        public frmListaPrecios()
        {
            InitializeComponent();
        }
        int IdListaPrecios = 0;
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmListaPrecios_Load(object sender, EventArgs e)
        {
            //cargarmos los datos de la lista
            CargarDG();
            btnGuardar.Text = "Crear";
            txtLista.Focus();
        }
        private void CargarDG()
        {
            dgListaPrecios.DataSource = controladorListaPrecios.ListaCompleta();
        }
        private void SeleccionarLista()
        {
            if (dgListaPrecios.RowCount > 0 && dgListaPrecios.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgListaPrecios.Rows[dgListaPrecios.CurrentRow.Index];
                IdListaPrecios = Convert.ToInt32(fila.Cells["id"].Value);
                txtLista.Text = Convert.ToString(fila.Cells["nombreLista"].Value);
                btnGuardar.Text = "Editar";
                txtLista.Focus();
            }
        }
        private void dgListaPrecios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarLista();
        }
        private async Task GestionarListaPrecios(int Boton)
        {
            ListaPrecios objLista = new ListaPrecios();
            objLista =await controladorListaPrecios.ConsultarID(IdListaPrecios);
            if (objLista != null)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("La lista " + txtLista.Text + " ya existe.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (Boton == 0)
            {
                objLista = new ListaPrecios();
                IdListaPrecios = 0;
            }
            objLista.id = IdListaPrecios;
            objLista.nombreLista = txtLista.Text;
            RespuestaCRUD sqlLista =await controladorListaPrecios.CrearEditarEliminarListaPrecios(objLista, Boton);
            if (sqlLista.estado == true)
            {
                if (Boton == 2)
                {
                    MessageBox.Show("La lista " + txtLista.Text + " fue eliminada correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Boton == 1)
                {
                    MessageBox.Show("La lista " + txtLista.Text + " fue editada correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Boton == 0)
                {
                    MessageBox.Show("La lista " + txtLista.Text + " fue creada correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CargarDG();
                btnGuardar.Text = "Crear";
                txtLista.Text = "";
                txtLista.Focus();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtLista.Text != "")
            {
                if (btnGuardar.Text == "Crear")
                {
                    GestionarListaPrecios(0);
                }
                else
                {
                    GestionarListaPrecios(1);
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SeleccionarLista();
            GestionarListaPrecios(2);
        }
    }
}

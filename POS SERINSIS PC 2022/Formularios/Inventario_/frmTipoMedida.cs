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
    public partial class frmTipoMedida : Form
    {
        public frmTipoMedida()
        {
            InitializeComponent();
        }
        int IdTipoMedida = 0;
        private void frmTipoMedida_Load(object sender, EventArgs e)
        {
            //cargarmos los datos de la lista
            CargarDG();
            btnGuardar.Text = "Crear";
            txtTipoMedida.Focus();
        }
        private void CargarDG()
        {
            dgTipoMedida.DataSource = ControladorTipoMedida.listaCompleta();
        }
        private void SeleccionarTipoMedida()
        {
            if (dgTipoMedida.RowCount > 0 && dgTipoMedida.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgTipoMedida.Rows[dgTipoMedida.CurrentRow.Index];
                IdTipoMedida = Convert.ToInt32(fila.Cells["id"].Value);
                txtTipoMedida.Text = Convert.ToString(fila.Cells["nombreTipoMedida"].Value);
                txtSiglas.Text = Convert.ToString(fila.Cells["letraTipoMedida"].Value);
                btnGuardar.Text = "Editar";
                txtTipoMedida.Focus();
            }
        }

        private void dgTipoMedida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarTipoMedida();
        }
        private void GestionarTipoMedida(int Boton)
        {
            TipoMedida objTipoMedida = new TipoMedida();
            objTipoMedida = ControladorTipoMedida.ConsultarID(IdTipoMedida);
            if (objTipoMedida != null)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("La presentación " + txtTipoMedida.Text + " ya existe.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (Boton == 0)
            {
                objTipoMedida = new TipoMedida();
                IdTipoMedida = 0;
            }
            objTipoMedida.id = IdTipoMedida;
            objTipoMedida.nombreTipoMedida = txtTipoMedida.Text;
            objTipoMedida.letraTipoMedida = txtSiglas.Text;
            bool sqlTipo = ControladorTipoMedida.CrearEditarEliminarTipoMedida(objTipoMedida, Boton);
            if (sqlTipo == true)
            {
                if (Boton == 2)
                {
                    MessageBox.Show("El tipo de medida " + txtTipoMedida.Text + " fue eliminada correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Boton == 1)
                {
                    MessageBox.Show("El tipo de medida " + txtTipoMedida.Text + " fue editada correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Boton == 0)
                {
                    MessageBox.Show("El tipo de medida " + txtTipoMedida.Text + " fue creada correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CargarDG();
                btnGuardar.Text = "Crear";
                txtTipoMedida.Text = "";
                txtSiglas.Text = "";
                IdTipoMedida = 0;
                txtTipoMedida.Focus();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SeleccionarTipoMedida();
            GestionarTipoMedida(2);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtTipoMedida.Text != "" &&
                txtSiglas.Text!="")
            {
                if (btnGuardar.Text == "Crear")
                {
                    GestionarTipoMedida(0);
                }
                else
                {
                    GestionarTipoMedida(1);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

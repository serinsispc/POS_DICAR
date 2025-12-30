using DAL.Controladores.OrdenServicio;
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

namespace SERINSI_PC.Formularios.Orden_de_Servicio
{
    public partial class frmTipoServicio : Form
    {
        int IdServicio = 0;
        public frmTipoServicio()
        {
            InitializeComponent();
        }
        private void GestionarServicio(int Boton)
        {
            TipoServicio objServicio = new TipoServicio();
            objServicio = controladorTipoServicio.consultarID(IdServicio);
            if (objServicio != null)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("El Servicio que sedea crear ya existe ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (Boton == 0)
            {
                objServicio = new TipoServicio();
                IdServicio = 0;
            }
            objServicio.id = IdServicio;
            objServicio.nombreTipoServicio = txtNombreServicio.Text;
            bool sql = controladorTipoServicio.CrearEditarEliminarArticulo(objServicio, Boton);
            if (sql == true)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("El articulo fue guardado correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Boton == 1)
                {
                    MessageBox.Show("El articulo fue editado correctamente", "Editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Boton == 2)
                {
                    MessageBox.Show("El articulo fue eliminado correctamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtNombreServicio.Text = "";
                IdServicio = 0;
                cargarDGCompleto();
                GestionarBotones(0);
                txtNombreServicio.Focus();
            }
        }
        private void frmTipoServicio_Load(object sender, EventArgs e)
        {
            GestionarBotones(0);
            cargarDGCompleto();
        }
        private void cargarDGCompleto()
        {
            dgTipoServicio.DataSource = controladorTipoServicio.ListaCompleta();
        }
        private void GestionarBotones(int boton)
        {
            if (boton == 0)
            {
                btnGuardar.Text = "Guardar";
            }
            else
            {
                btnGuardar.Text = "Editar";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreServicio.Text != "")
            {
                if (btnGuardar.Text == "Guardar")
                {
                    GestionarServicio(0);
                }
                else
                {
                    GestionarServicio(1);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtNombreServicio.Text != "")
            {
                GestionarServicio(2);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void dgTipoServicio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgTipoServicio.RowCount > 0 && e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgTipoServicio.Rows[e.RowIndex];
                IdServicio = Convert.ToInt32(fila.Cells["id"].Value);
                txtNombreServicio.Text = Convert.ToString(fila.Cells["nombreTipoServicio"].Value);

                GestionarBotones(1);
                txtNombreServicio.Focus();
            }
        }

        private void txtNombreServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNombreServicio.Text != "")
                {
                    btnGuardar.Focus();
                }
            }
        }
    }
}

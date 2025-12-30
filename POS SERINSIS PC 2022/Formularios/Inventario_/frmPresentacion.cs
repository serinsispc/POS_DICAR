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
    public partial class frmPresentacion : Form
    {
        public frmPresentacion()
        {
            InitializeComponent();
        }
        int IdPresentacion = 0;
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmPresentacion_Load(object sender, EventArgs e)
        {
            //cargarmos los datos de la lista
            CargarDG();
            btnGuardar.Text = "Crear";
            txtPresentacion.Focus();
        }
        private void CargarDG()
        {
            dgPresentacion.DataSource = controladorPresentacion.ListaCompleta();
        }
        private void dgPresentacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarPresentacion();
        }
        private void SeleccionarPresentacion()
        {
            if (dgPresentacion.RowCount > 0 && dgPresentacion.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgPresentacion.Rows[dgPresentacion.CurrentRow.Index];
                IdPresentacion = Convert.ToInt32(fila.Cells["id"].Value);
                txtPresentacion.Text = Convert.ToString(fila.Cells["nombrePresentacion"].Value);
                btnGuardar.Text = "Editar";
                txtPresentacion.Focus();
            }
        }
        private void GestionarPresentacion(int Boton)
        {
            Presentacion objPresentacion = new Presentacion();
            objPresentacion = controladorPresentacion.ConsultarID(IdPresentacion);
            if (objPresentacion != null)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("La presentación "+txtPresentacion.Text+" ya existe.","¡Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            if (Boton == 0)
            {
                objPresentacion = new Presentacion();
                IdPresentacion = 0;
            }
            objPresentacion.id = IdPresentacion;
            objPresentacion.nombrePresentacion = txtPresentacion.Text;
            bool sqlPresentacion = controladorPresentacion.CrearEditarEliminarPresentacion(objPresentacion,Boton);
            if (sqlPresentacion == true)
            {
                if (Boton == 2)
                {
                    MessageBox.Show("La presentación " + txtPresentacion.Text + " fue eliminada correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(Boton==1)
                {
                    MessageBox.Show("La presentación " + txtPresentacion.Text + " fue editada correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Boton == 0)
                {
                    MessageBox.Show("La presentación " + txtPresentacion.Text + " fue creada correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CargarDG();
                btnGuardar.Text = "Crear";
                txtPresentacion.Text = "";
                txtPresentacion.Focus();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPresentacion.Text != "")
            {
                if (btnGuardar.Text == "Crear")
                {
                    GestionarPresentacion(0);
                }
                else
                {
                    GestionarPresentacion(1);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SeleccionarPresentacion();
            GestionarPresentacion(2);
        }
    }
}

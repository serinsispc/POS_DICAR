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
    public partial class frmArticuloServicios : Form
    {
        int IdArticulo = 0;
        public frmArticuloServicios()
        {
            InitializeComponent();
        }

        private void frmArticuloServicios_Load(object sender, EventArgs e)
        {
            GestionarBotones(0);
            cargarDGCompleto();
        }
        private void cargarDGCompleto()
        {
            dgArticulosServicios.DataSource = contorladorArticuloServicio.ListaCompleta();
        }
        private void GestionarBotones(int boton)
        {
            if(boton == 0)
            {
                btnGuardar.Text = "Guardar";
            }
            else
            {
                btnGuardar.Text = "Editar";
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreArticulo.Text != "")
            {
                if (btnGuardar.Text == "Guardar")
                {
                    await GestionarArticulo(0);
                }
                else
                {
                    await GestionarArticulo(1);
                }
            }
        }
        private async Task GestionarArticulo(int Boton)
        {
            TipoArticulo objArticulo = new TipoArticulo();
            objArticulo =await contorladorArticuloServicio.consultarID(IdArticulo);
            if (objArticulo != null)
            {
                if(Boton == 0)
                {
                    MessageBox.Show("El articulo que sedea crear ya existe ", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            if(Boton == 0)
            {
                objArticulo = new TipoArticulo();
                IdArticulo =0;
            }
            objArticulo.id = IdArticulo;
            objArticulo.nombreTipoArticulo = txtNombreArticulo.Text;
            bool sql =await contorladorArticuloServicio.CrearEditarEliminarArticulo(objArticulo,Boton);
            if (sql == true)
            {
                if(Boton == 0)
                {
                    MessageBox.Show("El articulo fue guardado correctamente","Guardado",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                if (Boton == 1)
                {
                    MessageBox.Show("El articulo fue editado correctamente", "Editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Boton == 2)
                {
                    MessageBox.Show("El articulo fue eliminado correctamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtNombreArticulo.Text = "";
                IdArticulo = 0;
                cargarDGCompleto();
                GestionarBotones(0);
                txtNombreArticulo.Focus();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtNombreArticulo.Text != "")
            {
                await GestionarArticulo(2);
            }
        }

        private void dgArticulosServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgArticulosServicios.RowCount>0 && e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgArticulosServicios.Rows[e.RowIndex];
                IdArticulo = Convert.ToInt32(fila.Cells["id"].Value);
                txtNombreArticulo.Text = Convert.ToString(fila.Cells["nombreTipoArticulo"].Value);

                GestionarBotones(1);
                txtNombreArticulo.Focus();
            }
        }

        private void txtNombreArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNombreArticulo.Text != "")
                {
                    btnGuardar.Focus();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}

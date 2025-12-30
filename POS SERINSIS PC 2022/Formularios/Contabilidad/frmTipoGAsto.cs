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

namespace SERINSI_PC.Formularios.Contabilidad
{
    public partial class frmTipoGAsto : Form
    {
        public frmTipoGAsto()
        {
            InitializeComponent();
        }
        int IdTipoGasto_frm = 0;
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTipoGAsto_Load(object sender, EventArgs e)
        {
            CargarDG();
            GestionarBotones(0);
            txtTipoGasto.Focus();
        }
        private void GestionarBotones(int Boton)
        {
            if (Boton == 0)
            {
                btnGuardar.Text = "Guardar";
                btnEliminar.Enabled = false;
            }
            else
            {
                btnGuardar.Text = "Editar";
                btnEliminar.Enabled = true;
            }
        }
        private void CargarDG()
        {
            dgTipoGAsto.DataSource = controladorTipoGasto.listaCompleta();
        }
        private void GestionarTipoGasto(int Boton)
        {
            TipoGasto tipoGasto = new TipoGasto();
            tipoGasto = controladorTipoGasto.Consultar_id(IdTipoGasto_frm);
            if (tipoGasto != null)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("¡El tipo de gasto ya se encuentra registrado...!", "¡Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            if (Boton == 0)
            {
                IdTipoGasto_frm = 0;
                tipoGasto = new TipoGasto();
            }
            tipoGasto.id = IdTipoGasto_frm;
            tipoGasto.nombreTipoGasto = txtTipoGasto.Text;
            bool crud = controladorTipoGasto.Crud(tipoGasto,Boton);
            if (crud == true)
            {
                if (Boton == 2)
                {
                    MessageBox.Show("¡El tipo de gasto fue eliminado correctamente...!", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if(Boton==0)
                {
                    MessageBox.Show("¡El tipo de gasto fue creado correctamente...!", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Boton == 1)
                {
                    MessageBox.Show("¡El tipo de gasto fue editado correctamente...!", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CargarDG();
                GestionarBotones(0);
                txtTipoGasto.Text = "";
                IdTipoGasto_frm = 0;
                txtTipoGasto.Focus();
            }
        }
        private void SeleccionarTipoGasto()
        {
            if (dgTipoGAsto.RowCount > 0 && dgTipoGAsto.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgTipoGAsto.Rows[dgTipoGAsto.CurrentRow.Index];

                IdTipoGasto_frm = Convert.ToInt32(fila.Cells["id"].Value);
                txtTipoGasto.Text = Convert.ToString(fila.Cells["nombreTipoGasto"].Value);
            }
        }

        private void dgTipoGAsto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarTipoGasto();
            GestionarBotones(1);
            txtTipoGasto.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtTipoGasto.Text != "")
            {
                if (btnGuardar.Text == "Guardar")
                {
                    GestionarTipoGasto(0);
                }
                else
                {
                    GestionarTipoGasto(1);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtTipoGasto.Text != "")
            {
                GestionarTipoGasto(2);
            }
        }
    }
}

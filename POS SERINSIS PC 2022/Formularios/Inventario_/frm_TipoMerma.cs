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

namespace SERINSI_PC.Formularios.Inventario_
{
    public partial class frm_TipoMerma : Form
    {
        public frm_TipoMerma()
        {
            InitializeComponent();
        }
        int idTipoMerma_frm = 0;
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_TipoMerma_Load(object sender, EventArgs e)
        {
            Cargardg();
            GestionarBoton(0);
            txtNombreTipoMerma.Focus();
        }
        private void Cargardg()
        {
            dgTipoMerma.DataSource = ControladorTipoMerma.listaCompleta();
        }
        private void GestionarBoton(int Boton)
        {
            if (Boton == 0)
            {
                btnGuardar.Text = "Guardar";
            }
            else
            {
                btnGuardar.Text = "Editar";
            }
        }
        private void dgTipoMerma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarTipoMerma();
            GestionarBoton(1);
            btnEliminar.Enabled = true;
            txtNombreTipoMerma.Focus();
        }
        private void SeleccionarTipoMerma()
        {
            if (dgTipoMerma.Rows.Count > 0 && dgTipoMerma.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgTipoMerma.Rows[dgTipoMerma.CurrentRow.Index];

                idTipoMerma_frm = Convert.ToInt32(fila.Cells["id"].Value);
                txtNombreTipoMerma.Text =Convert.ToString(fila.Cells["nombreTipoMerma"].Value);

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreTipoMerma.Text != "")
            {
                if (btnGuardar.Text == "Guardar")
                {
                    GestionarTipoMerma(0);
                    idTipoMerma_frm = 0;
                }
                else
                {
                    GestionarTipoMerma(1);
                    idTipoMerma_frm = 0;
                }
            }
        }
        private void GestionarTipoMerma(int Boton)
        {
            TipoMerma tipoMerma = new TipoMerma();
            tipoMerma = ControladorTipoMerma.Consultar_id(idTipoMerma_frm);
            if (tipoMerma != null)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("¡El tipo de merma ya existe...!","¡Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            if (Boton == 0)
            {
                idTipoMerma_frm = 0;
                tipoMerma = new TipoMerma();
            }
            tipoMerma.id = idTipoMerma_frm;
            tipoMerma.nombreTipoMerma = txtNombreTipoMerma.Text;
            bool crud = ControladorTipoMerma.Crud(tipoMerma,Boton);
            if (crud == true)
            {
                MessageBox.Show("¡Tipo de Merma creada correctamente...!", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cargardg();
                txtNombreTipoMerma.Text = "";
                GestionarBoton(0);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtNombreTipoMerma.Text != "")
            {
                GestionarTipoMerma(2);
                idTipoMerma_frm = 0;
            }
        }
    }
}

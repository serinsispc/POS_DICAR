using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Controladores.Tienda;
using DAL.Modelo;
using SERINSI_PC.Formularios.Inventario;
using SERINSI_PC.Clases;

namespace SERINSI_PC.Formularios.Ventas
{
    public partial class frmBodega : Form
    {
        public string FormularioLlamado = "";
        int IdDivision = 0;
        public frmBodega()
        {
            InitializeComponent();
        }

        private void frmDivision_Load(object sender, EventArgs e)
        {
            dgDivision.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 16);
            if (FormularioLlamado != null)
            {
                panelTitulo.Visible = true;
            }
            //lo primero que hacemos es gestionar los botones
            GEstionarBotones(0);
            //ahora llamamos la funcion que se encarga de llenar el dg
            CargarDG();
            txtDivision.Focus();
        }
        private void CargarDG()
        {
            dgDivision.DataSource=ControladorBodega.listaCompleta();
        }
        private void GEstionarBotones(int Boton)
        {
            if (Boton == 0)
            {
                btnGuardar.Text = "Crear";
            }
            else
            {
                btnGuardar.Text = "Editar";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            {
                if (btnGuardar.Text == "Crear")
                {
                    GestionarDivision(0);
                }
                else
                {
                    GestionarDivision(1);
                }
            }
        }
        private void GestionarDivision(int Boton)
        {
            Bodega objBodega = new Bodega();
            objBodega = ControladorBodega.ConsultarX_IdVidision(IdDivision);
            if (objBodega != null)
            {
                if(Boton == 0)
                {
                    MessageBox.Show("La división que desea crear ya se encuentra creada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if(Boton == 0)
            {
                IdDivision = 0;
                objBodega = new Bodega();
            }
            objBodega.id = IdDivision;
            objBodega.nombreBodega = txtDivision.Text;
            bool sql = ControladorBodega.Crear_Editar_Eliminar_DivisionInventario(objBodega,Boton);
            if (sql == true)
            {
                if(Boton == 0)
                {
                    MessageBox.Show("La división ha sido creada correctamente ", "Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Boton == 1)
                {
                    MessageBox.Show("La división ha sido editada correctamente ", "Editada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Boton == 2)
                {
                    MessageBox.Show("La división ha sido eliminada correctamente ", "Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LimpiarFormulario();
            }
        }
        private void LimpiarFormulario()
        {
            IdDivision = 0;
            txtDivision.Text = "";
            CargarDG();
            GEstionarBotones(0);
            txtDivision.Focus();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void dgDivision_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDivision.RowCount > 0 && e.RowIndex >= 0)
            {
                DataGridViewRow Fila = dgDivision.Rows[e.RowIndex];

                IdDivision = Convert.ToInt32(Fila.Cells["id"].Value);
                txtDivision.Text = Convert.ToString(Fila.Cells["nombreBodega"].Value);

                GEstionarBotones(1);
                txtDivision.Focus();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

            
                this.Close();
            

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

using DAL.Controladores;
using DAL.Controladores.Version_Software;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios
{
    public partial class frmTutoriales : Form
    {
        public frmTutoriales()
        {
            InitializeComponent();
        }

        private void frmTutoriales_Load(object sender, EventArgs e)
        {
            CargarDG();
            var button = new DataGridViewButtonColumn();
            button.Name = "Play";
            button.HeaderText = "Play";
            button.Text = ">";
            button.UseColumnTextForButtonValue = true;

            this.dgTutoriales.Columns.Add(button);
        }
        private void ReproducirVideo()
        {
            try
            {
                if (dgTutoriales.RowCount > 0 && dgTutoriales.CurrentRow.Index >= 0)
                {
                    DataGridViewRow Fila = dgTutoriales.Rows[dgTutoriales.CurrentRow.Index];
                    Process.Start(VariablesPublicas.RutaTutoriales+Convert.ToString(Fila.Cells["nombre_tutorial"].Value));
                }
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                MessageBox.Show("No es posible reproducir el video.", "Error Play", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarDG()
        {
            dgTutoriales.DataSource = ControladorTutoriales.ListaCompleta();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgTutoriales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgTutoriales.Columns[e.ColumnIndex].Name == "Play")
            {
                ReproducirVideo();
            }
        }
    }
}

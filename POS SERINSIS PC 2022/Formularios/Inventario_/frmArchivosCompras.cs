using DAL.Controladores;
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

namespace SERINSI_PC.Formularios.Inventario_
{
    public partial class frmArchivosCompras : Form
    {
        public frmArchivosCompras()
        {
            InitializeComponent();
        }
        public int IdCompra_frm = 0;
        private void btnAbrirArchivo_Click(object sender, EventArgs e)
        {
            if (dgArchivosCompras.RowCount > 0 && dgArchivosCompras.CurrentRow.Index >= 0)
            {
                try
                {
                    DataGridViewRow fila = dgArchivosCompras.Rows[dgArchivosCompras.CurrentRow.Index];

                    string guidFrm = Convert.ToString(fila.Cells["guidArchivo"].Value);
                    string extencion = Convert.ToString(fila.Cells["extencion"].Value);

                    Process p = new Process();
                    p.StartInfo.FileName = VariablesPublicas.RutaImagenes + "\\FacturasCompras\\" + guidFrm + extencion;
                    p.Start();
                }
                catch(Exception ex)
                {
                    string error = ex.Message;
                    MessageBox.Show("¡No se encontro el archivo...!","¡Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
        }

        private void frmArchivosCompras_Load(object sender, EventArgs e)
        {
            dgArchivosCompras.DataSource = controladorArchivoCompra.Listra_IdCompra(IdCompra_frm);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgArchivosCompras.RowCount > 0 && dgArchivosCompras.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgArchivosCompras.Rows[dgArchivosCompras.CurrentRow.Index];

                int id_frm = Convert.ToInt32(fila.Cells["id"].Value);
                string guidFrm = Convert.ToString(fila.Cells["guidArchivo"].Value);
                string extencion = Convert.ToString(fila.Cells["extencion"].Value);


                ArchivoCompras archivoCompras = new ArchivoCompras();
                archivoCompras =await controladorArchivoCompra.ConsultarIdArchivo(id_frm);
                if (archivoCompras != null)
                {
                    bool delete =await controladorArchivoCompra.CrearEditarEliminar(archivoCompras,2);
                    if (delete == true)
                    {
                        dgArchivosCompras.DataSource = controladorArchivoCompra.Listra_IdCompra(IdCompra_frm);
                    }
                }
            }
        }
    }
}

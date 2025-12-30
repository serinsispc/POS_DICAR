using DAL.Controladores;
using Invenpol_Parqueadero_Motos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Ventas
{
    public partial class frmProductosPresentacion : Form
    {
        public frmProductosPresentacion()
        {
            InitializeComponent();
        }
        public string codigo = "";
        private void frmProductosPresentacion_Load(object sender, EventArgs e)
        {
            dgProductosPresentacion.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 20);
            // Ajustar tamaño de columnas y celdas.
            dgProductosPresentacion.AutoResizeColumns();
            dgProductosPresentacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // para que divida el texto de las celdas en varias líneas
            dgProductosPresentacion.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            CargarGD();

            //en esta parte configuracmos los botones

            var btnAgregar = new DataGridViewButtonColumn();
            btnAgregar.Name = "btnAgregar";
            btnAgregar.HeaderText = "Agregar";
            btnAgregar.Text = ">>";
            btnAgregar.UseColumnTextForButtonValue = true;
            this.dgProductosPresentacion.Columns.Add(btnAgregar);
        }
        public void CargarGD()
        {
            dgProductosPresentacion.DataSource = ControladorProducto.FiltroVentaProducto(codigo,1,VariablesPublicas.IdEmpresaLogueada);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgProductosPresentacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgProductosPresentacion.RowCount>0 && e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgProductosPresentacion.Rows[e.RowIndex];

                if (dgProductosPresentacion.Columns[e.ColumnIndex].Name == "btnAgregar")
                {
                    frmCajaTouch frm = Owner as frmCajaTouch;
                    bool agregar=frm.AgregarDetalleVenta(Convert.ToInt32(fila.Cells["idCostoPrecio"].Value),
                        Convert.ToString(fila.Cells["descripcionProducto"].Value),
                        1,
                        Convert.ToDecimal(fila.Cells["costo"].Value),
                         Convert.ToDecimal(fila.Cells["precio"].Value),
                         Convert.ToDecimal(fila.Cells["porcentajeIva"].Value),
                         Convert.ToInt32(fila.Cells["idInventario"].Value),0,0,
                         Convert.ToDecimal(fila.Cells["porcentajeIva"].Value),
                         Convert.ToInt32(fila.Cells["gramera"].Value));
                    if (agregar == true)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }

        }
    }
}

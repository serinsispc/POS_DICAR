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

namespace SERINSI_PC.Formularios.Ventas
{
    public partial class frmVerPagosCredito : Form
    {
        public int IdCliente;
        public frmVerPagosCredito()
        {
            InitializeComponent();
        }
        public int NumeroFactura;
        private void frmVerPagosCredito_Load(object sender, EventArgs e)
        {
  
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVerPagosCredito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar.PerformClick();
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgVerPagos.RowCount>0&& dgVerPagos.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgVerPagos.Rows[dgVerPagos.CurrentRow.Index];

                int idPago = Convert.ToInt32(fila.Cells["id_pago_credito_tienda"].Value);

                PagosCreditoTienda pagosCreditoTienda = new PagosCreditoTienda();
                pagosCreditoTienda = ControladorPagosCreditoTienda.ConsultarId(idPago);
                if (pagosCreditoTienda != null)
                {
                    bool crud = ControladorPagosCreditoTienda.Crear_Editar_Eliminar_PagoCreditoTienda(pagosCreditoTienda,2);
                    this.Close();
                }
            }
        }
    }
}

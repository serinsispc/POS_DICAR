using DAL.Controladores;
using Invenpol_Parqueadero_Motos.Clases;
using POS_SERINSIS_PC_2022.Reportes;
using System;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Inventario
{
    public partial class frm_H_traslados : Form
    {
        public frm_H_traslados()
        {
            InitializeComponent();
        }
        string GUIdTrastado = "";
        private void frm_H_traslados_Load(object sender, EventArgs e)
        {
            CargarDGCompleto();
        }
        private void CargarDGCompleto()
        {
            dgHTraslados.DataSource = controladorTraslado.listacompleta(VariablesPublicas.IdEmpresaLogueada);
        }
        private void SeleccionarTraslado()
        {
            if(dgHTraslados.RowCount>0 && dgHTraslados.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgHTraslados.Rows[dgHTraslados.CurrentRow.Index];

                GUIdTrastado = Convert.ToString(fila.Cells["v_guidTraslado"].Value);
                Descripcion= Convert.ToString(fila.Cells["v_descripcionTraslado"].Value);
                EnvioDesde= Convert.ToString(fila.Cells["v_SedeEnvio"].Value);
                RecibidoEn= Convert.ToString(fila.Cells["v_SedeRecibido"].Value);
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            SeleccionarTraslado();
            frmDetalleTraslado frm = new frmDetalleTraslado();
            AddOwnedForm(frm);
            frm.dgDetalleVenta.DataSource = controladorDetalleTraslado.Filtrar_Guid(GUIdTrastado);
            frm.ShowDialog();
        }
        string Descripcion = "";
        string EnvioDesde = "";
        string RecibidoEn = "";
        private void btnImrpimir_Click(object sender, EventArgs e)
        {
            SeleccionarTraslado();
            string guidCorto = GUIdTrastado.Substring(0, 5);
            VariablesPublicas.OrdenTraslado = guidCorto;
            VariablesPublicas.DesciopcionTraslado = Descripcion;
            VariablesPublicas.EnvioTraslado = EnvioDesde;
            VariablesPublicas.RecibidoTraslado = RecibidoEn;
            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            frm.GuidTexto = GUIdTrastado;
            frm.ReporteAImprimir = "OrdenTraslado";
            frm.ShowDialog();
        }

        private void rbDia_CheckedChanged(object sender, EventArgs e)
        {
            dgHTraslados.DataSource = controladorTraslado.filtroFechaDIa(VariablesPublicas.IdEmpresaLogueada,dtFecha.Value);
        }

        private void rbMes_CheckedChanged(object sender, EventArgs e)
        {
            dgHTraslados.DataSource = controladorTraslado.filtroFechaMes(VariablesPublicas.IdEmpresaLogueada, dtFecha.Value);
        }

        private void btnEliminarFiltro_Click(object sender, EventArgs e)
        {
            CargarDGCompleto();
            rbDia.Checked = false;
            rbMes.Checked = false;
        }
    }
}

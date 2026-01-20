using DAL;
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

namespace SERINSI_PC.Formularios.Fabrica
{
    public partial class frmFabrica : Form
    {
        int Consecutivo;
        int IdOrdenFabrica;
        int Dias;
        DateTime fechaInicio;
        DateTime fechaFin;
        string NombreResponsableOrden;
        decimal precioOrden;
        decimal namoObra;
        string NombreClienteOrden;
        string DescripcionOrden;
        string EstadoOrden;
        public frmFabrica()
        {
            InitializeComponent();
        }

        private void frmFabrica_Load(object sender, EventArgs e)
        {
            llenarDGCOmpleta();
        }
        private void btnCrearOrden_Click(object sender, EventArgs e)
        {
            frmGestionOrdenFabrica frm = new frmGestionOrdenFabrica();
            AddOwnedForm(frm);
            frm.txtTituloFormulario.Text = "Crear Orden de Fabricación";
            frm.ShowDialog();
        }
        public void llenarDGCOmpleta()
        {
            dgOrdenes.DataSource = controladorOrdenFabrica.filtroEstado("Fabricación");
        }

        private void btnEditarOrden_Click(object sender, EventArgs e)
        {
            SeleccionarOrden();
            frmGestionOrdenFabrica frm =new frmGestionOrdenFabrica();
            AddOwnedForm(frm);
            frm.IdOrdenFabricacion = IdOrdenFabrica;
            frm.dtFechaInicio.Value = fechaInicio;
            frm.dtFechaEntrega.Value = fechaFin;
            frm.txtDias.Text = Convert.ToString(Dias);
            frm.txtResponsable.Text = NombreResponsableOrden;
            frm.txtValorOrden.Text = Convert.ToString(precioOrden);
            frm.txtManoObra.Text = Convert.ToString(namoObra);
            frm.txtDescripcionOrden.Text = DescripcionOrden;
            frm.txtClienteOrden.Text = NombreClienteOrden;
            frm.EstadoOrden = EstadoOrden;
            frm.NumeroOrden = Consecutivo;
            frm.txtTituloFormulario.Text = "Editar Orden";
            frm.btnGuardar.Text = "Editar";
            frm.ShowDialog();
        }
        private void SeleccionarOrden()
        {
            if (dgOrdenes.RowCount > 0 && dgOrdenes.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgOrdenes.Rows[dgOrdenes.CurrentRow.Index];
                IdOrdenFabrica = Convert.ToInt32(fila.Cells["id"].Value);
                fechaInicio = Convert.ToDateTime(fila.Cells["fechaInicioOrden"].Value);
                fechaFin = Convert.ToDateTime(fila.Cells["fechaEntregaIrden"].Value);
                Dias = Convert.ToInt32(fila.Cells["diasOrden"].Value);
                NombreResponsableOrden = Convert.ToString(fila.Cells["responsableOrden"].Value);
                NombreClienteOrden = Convert.ToString(fila.Cells["clienteOrden"].Value);
                DescripcionOrden = Convert.ToString(fila.Cells["descripcionProductoOrden"].Value);
                namoObra = Convert.ToInt32(fila.Cells["costoOrdenManoObra"].Value);
                precioOrden = Convert.ToInt32(fila.Cells["ValorFinalOrden"].Value);
                Consecutivo= Convert.ToInt32(fila.Cells["numeroOrdenFabrica"].Value);
                EstadoOrden = Convert.ToString(fila.Cells["estadoOrdenFabricacion"].Value);
            }
        }

        private void btnListaInsumos_Click(object sender, EventArgs e)
        {
            SeleccionarOrden();
            frmInsumoOrden frm = new Fabrica.frmInsumoOrden();
            AddOwnedForm(frm);
            frm.IdOrdenFabrica = IdOrdenFabrica;
            frm.ShowDialog();
        }

        private async void btnEliminarOrden_Click(object sender, EventArgs e)
        {
            SeleccionarOrden();
            //en esta parte lo primero es consultar si la orden tiene cargado algun producto
            List<DetalleOrdenFabrica> objListaDetalleOrden = new List<DetalleOrdenFabrica>();
            objListaDetalleOrden =await controladorDetalleOrdenFabrica.Filtro_IDOrden(IdOrdenFabrica);
            if (objListaDetalleOrden.Count > 0)
            {
                MessageBox.Show(" Se a detectado que la orden seleccionada tiene cargado insumos,"+Environment.NewLine+
                    "Para poder eliminarla primero debe de ingresar al listado de insumos de la orden y eliminarlos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                OrdenFabrica objOrden = new OrdenFabrica();
                objOrden =await controladorOrdenFabrica.consultarID(IdOrdenFabrica);
                if (objOrden != null)
                {
                    RespuestaCRUD sql =await controladorOrdenFabrica.CrearEditarElimminarOrdenFabrica(objOrden,2);
                    if (sql.estado == true)
                    {
                        llenarDGCOmpleta();
                    }
                }
            }
        }
    }
}

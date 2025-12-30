using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using POS_SERINSIS_PC_2022.Reportes;
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
    public partial class frmHistorialVentas : Form
    {
        public frmHistorialVentas()
        {
            InitializeComponent();
        }
        string Fecha = "";
        int IDVenta = 0;
        int Consecutivo = 0;
        string FacturaRecibo = " ";
        string ContadoCreditoDomicilio = " ";
        int NumeroFacturaRecibo = 0;
        int IdCliente = 0;
        string NombreCliente_frm = " ";
        string IdentificacionCliente = " ";
        string DireccionCliente = " ";
        string TelefonoCliente=" ";
        int SubTotal = 0;
        int Descuento = 0;
        decimal AbonoTarjeta_frm = 0;
        int Total = 0;
        string EfectivoTargeta = " ";
        int Efectivo = 0;
        int Cambio = 0;
        public int IdProducto = 0;
        string FechaVT;
        string DiasC;
        private void btnImrpimir_Click(object sender, EventArgs e)
        {
            SeleccionarVenta();
            //consultamos si la venta tiene relacion con un cliente
            VariablesPublicas.IdCliente = IdCliente;
            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            if (VariablesPublicas.TipoImpresora == "Carta")
            {
                frm.FacturaVentaCarta(0, IDVenta);
            }
            else
            {
                frm.FacturaVentaPOS(IDVenta);
            }
            //frm.ShowDialog();
        }
        private void VerificarCliente()
        {
            R_VentaCliente r_VentaCliente = new R_VentaCliente();
            r_VentaCliente = controladorRVentaCleinte.ConsultarRelacion(IDVenta);
            if(r_VentaCliente == null)
            {
                VariablesPublicas.IdCliente = r_VentaCliente.idCliente;
            }

        }
        private void SeleccionarVenta()
        {
            if (dgVentas.RowCount > 0 && dgVentas.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgVentas.Rows[dgVentas.CurrentRow.Index];
                IDVenta = Convert.ToInt32(fila.Cells["id"].Value);
                Fecha = Convert.ToString(fila.Cells["fechaVenta"].Value);
                FacturaRecibo = Convert.ToString(fila.Cells["tipoFactura"].Value);
                ContadoCreditoDomicilio = Convert.ToString(fila.Cells["tipoVenta"].Value);
                NumeroFacturaRecibo = Convert.ToInt32(fila.Cells["numeroVenta"].Value);
                SubTotal = Convert.ToInt32(fila.Cells["subtotalVenta"].Value);
                Descuento = Convert.ToInt32(fila.Cells["descuentoVenta"].Value);
                AbonoTarjeta_frm = Convert.ToDecimal(fila.Cells["abonoTarjeta"].Value);
                Total = Convert.ToInt32(fila.Cells["totalVenta"].Value);
                EfectivoTargeta = Convert.ToString(fila.Cells["tipoPago"].Value);
                Efectivo = Convert.ToInt32(fila.Cells["efectivoVenta"].Value);
                Cambio = Convert.ToInt32(fila.Cells["cambioVenta"].Value);
                if (Convert.ToString(fila.Cells["fechaVencimiento"].Value) != "" &&
                    fila.Cells["fechaVencimiento"].Value!=null)
                {
                    FechaVT = Convert.ToString(fila.Cells["fechaVencimiento"].Value);
                }
                if (Convert.ToString(fila.Cells["diasCredito"].Value) != null)
                {
                    DiasC = Convert.ToString(fila.Cells["diasCredito"].Value);
                }

                //en esta parte devemos consultar la relacion de venta cleinte
                R_VentaCliente objRCleinte = new R_VentaCliente();
                objRCleinte = contorladorR_VentaCliente.Consultar_ID(IDVenta);
                if (objRCleinte != null)
                {
                    IdCliente = objRCleinte.idCliente;

                    Clientes objCliente = new Clientes();
                    objCliente = ControladorClienteTienda.ConsultarX_ID(IdCliente);
                    if (objCliente != null)
                    {
                        NombreCliente_frm = objCliente.nombreCliente;
                        IdentificacionCliente = objCliente.documentoCliente;
                        TelefonoCliente = objCliente.telefonoCliente;
                        DireccionCliente = objCliente.direccionCliente;
                    }
                    else
                    {
                        NombreCliente_frm = "";
                        IdentificacionCliente = "";
                        TelefonoCliente = "";
                        DireccionCliente = "";
                    }
                }
            }
        }

        private void frmHistorialVentas_Load(object sender, EventArgs e)
        {
            dgVentas.DataSource = ControladorVenta.filtroDia(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
        }
        public void CargarDGCompleto()
        {
            dgVentas.DataSource = ControladorVenta.FiltroX_H_Dia(DateTime.Now,VariablesPublicas.IdEmpresaLogueada);
        }
        private void dgVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarVenta();
        }

        private void txtNumeroVenta_TextChanged(object sender, EventArgs e)
        {
            if (txtNumeroVenta.Text != "")
            {
                dgVentas.DataSource = ControladorVenta.filtroNumeroVenta(Convert.ToInt32(txtNumeroVenta.Text),VariablesPublicas.IdEmpresaLogueada);
            }
            else
            {
                CargarDGCompleto();
            }
        }

        private void txtNumeroVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void btnEliminarFiltro_Click(object sender, EventArgs e)
        {
            txtNumeroVenta.Text = "";
            rbAño.Checked = false;
            rbDia.Checked = false;
            rbMes.Checked = false;
            CargarDGCompleto();
        }

        private void rbDia_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDia.Checked == true)
            {
                dgVentas.DataSource = ControladorVenta.filtroDia(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
            }
        }

        private void rbMes_CheckedChanged(object sender, EventArgs e)
        {
            dgVentas.DataSource = ControladorVenta.filtroMes(dtFecha.Value,VariablesPublicas.IdEmpresaLogueada);
        }

        private void rbAño_CheckedChanged(object sender, EventArgs e)
        {
            dgVentas.DataSource = ControladorVenta.filtroAño(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            SeleccionarVenta();
            frmDetalleFacturaCredito frm = new Ventas.frmDetalleFacturaCredito();
            AddOwnedForm(frm);
            frm.HistorialVentas = true;
            frm.IDVenta_frm = IDVenta;
            frm.NumeroVenta = Consecutivo;
            frm.ShowDialog();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            SeleccionarVenta();
            decimal TotalDetalle = ControladorDetalleVenta.SumarTotalVenta(Consecutivo);
            if (TotalDetalle > 0)
            {
                MessageBox.Show("Para poder anular la venta primero debe de retornar los productos cargados.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                frmDetalleFacturaCredito frm = new Ventas.frmDetalleFacturaCredito();
                AddOwnedForm(frm);
                frm.HistorialVentas = true;
                frm.IDVenta_frm = IDVenta;
                frm.NumeroVenta = Consecutivo;
                frm.ShowDialog();
            }
            else
            {
                TablaVentas objVentas = new TablaVentas();
                objVentas = ControladorVenta.ConsultaX_id(IDVenta);
                if (objVentas != null)
                {
                    objVentas.estadoVenta = "ANULADA";
                    bool sql = ControladorVenta.Crud(objVentas,1);
                    if (sql == true)
                    {
                        MessageBox.Show("Venta anulada correctamente.", "Anulada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDGCompleto();
                    }
                }
            }
        }

        private void dgVentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgVentas.Columns[e.ColumnIndex].Name == "estadoVenta")
            {
                if (Convert.ToString(e.Value) == "ANULADA")
                {
                    dgVentas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;

                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
                if (Convert.ToString(e.Value) == "CANCELADO")
                {
                    dgVentas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;

                    e.CellStyle.BackColor = Color.White;
                    e.CellStyle.ForeColor = Color.Black;
                }
                if (Convert.ToString(e.Value) == "PENDIENTE")
                {
                    dgVentas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;

                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeleccionarVenta();
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    cn.EliminarVenta_app(IDVenta);
                }
                CargarDGCompleto();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
    }
}

using DAL.Controladores;
using DAL.Controladores.Contabilidad;
using DAL.Controladores.Tienda;
using DAL.Modelo;
using DAL.SQL;
using Invenpol_Parqueadero_Motos.Clases;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using POS_SERINSIS_PC_2022.Reportes;
using SERINSI_PC.Formularios.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Invenpol_Parqueadero_Motos.Formularios
{
    public partial class frmreporteDiario : Form
    {
        public frmreporteDiario()
        {
            InitializeComponent();
        }
        //variables
        int PagoCP = 0;
        decimal Ventas = 0;
        decimal PagoCC = 0;
        int Ganancia = 0;
        int Gastos = 0;
        decimal Costo = 0;
        int Producido = 0;
        int Ingresos = 0;

        string TipoFiltro = "";

        int ConsecutivoVenta = 0;

        int Utilidad_frm;

        private async void rbAño_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAño.Checked == true)
            {
                TipoFiltro = "Año";
                await FiltrarReporte();
            }
        }

        private async void rbMes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMes.Checked == true)
            {
                TipoFiltro = "Mes";
                await FiltrarReporte();
            }
        }

        private async void rbDia_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDia.Checked == true)
            {
                TipoFiltro = "Dia";
                await FiltrarReporte();
            }
        }
        private async Task FiltrarReporte()
        {
            await CargarVentasVendedor();
            await FiltrarReporteGeneral();
            await FiltrarVentas();
            await FiltrarPagosCC();
            await FiltrarPagosCP();
            await FiltrarGastos();
            await FiltrarVentasCategorias();
        }

private async Task CargarVentasVendedor()
    {
        try
        {
            DateTime fecha = dtFecha.Value;

            string query = string.Empty;

            if (TipoFiltro == "Dia")
            {
                query = $@"
                EXEC dbo.InformeVentasVendedor_dia 
                    {fecha.Month},
                    {fecha.Day},
                    {fecha.Year};
            ";
            }
            else if (TipoFiltro == "Mes")
            {
                query = $@"
                EXEC dbo.InformeVentasVendedor_mes
                    {fecha.Month},
                   {fecha.Year};
            ";
            }
            else if (TipoFiltro == "Año")
            {
                query = $@"
                EXEC dbo.InformeVentasVendedor_year
                    {fecha.Year};
            ";
            }
            else
            {
                dgVentasVendedor.DataSource = null;
                text_TotalVentas.Text = "Venta: $0";
                text_TotalUtilidad.Text = "Utilidad: $0";
                return;
            }

            // SELECT que retorna lista => (true, true)
            string json = await Conection_SQL.ConsultaSQLServer(query, true, true);

            DataTable dt = new DataTable();

            if (!string.IsNullOrWhiteSpace(json) && json.Trim() != "[]")
            {
                dt = JsonConvert.DeserializeObject<DataTable>(json) ?? new DataTable();
            }

            dgVentasVendedor.AutoGenerateColumns = true;
            dgVentasVendedor.DataSource = dt;

            // Totales (mejor desde DataTable para evitar filas "nuevas" del grid)
            decimal totalVentasVendedor = 0m;
            decimal totalUtilidadVendedor = 0m;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    totalVentasVendedor += ToDecimalSafe(r, "total_iv");
                    totalUtilidadVendedor += ToDecimalSafe(r, "utilidad");
                }
            }

            text_TotalVentas.Text = "Venta: " + totalVentasVendedor.ToString("C", CultureInfo.CurrentCulture);
            text_TotalUtilidad.Text = "Utilidad: " + totalUtilidadVendedor.ToString("C", CultureInfo.CurrentCulture);
        }
        catch (Exception ex)
        {
            string error = ex.Message;
            MessageBox.Show(
                "Ocurrió un error al cargar las ventas del vendedor.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }

    private decimal ToDecimalSafe(DataRow row, string colName)
    {
        try
        {
            if (row == null || row.Table == null || !row.Table.Columns.Contains(colName))
                return 0m;

            object val = row[colName];

            if (val == null || val == DBNull.Value)
                return 0m;

            if (val is decimal d) return d;
            if (val is double db) return Convert.ToDecimal(db);
            if (val is float f) return Convert.ToDecimal(f);
            if (val is int i) return i;
            if (val is long l) return l;

            string s = val.ToString();
            if (string.IsNullOrWhiteSpace(s)) return 0m;

            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal parsed))
                return parsed;

            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out parsed))
                return parsed;

            return 0m;
        }
        catch
        {
            return 0m;
        }
    }

    private async Task HallarUtilidad()
        {
            if (TipoFiltro == "Año")
            {
                Utilidad_frm =await contorladorUtilidad.HallarCostoVentaAño(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Mes")
            {
                Utilidad_frm =await contorladorUtilidad.HallarCostoVentaMes(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Dia")
            {
                Utilidad_frm =await contorladorUtilidad.HallarCostoVentaDia(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
            }
        }
        private async Task FiltrarGastos()
        {
            if (TipoFiltro == "Año")
            {
                dgGastos.DataSource =await ControladorGastos.FiltrarX_Año(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Mes")
            {
                dgGastos.DataSource =await ControladorGastos.FiltrarX_Mes(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Dia")
            {
                dgGastos.DataSource =await ControladorGastos.FiltrarX_Dia(dtFecha.Value,VariablesPublicas.IdEmpresaLogueada);
            }
        }
        private async Task FiltrarPagosCP()
        {
            if (TipoFiltro == "Año")
            {
                dgCP.DataSource =await ControladorCompra.FiltroX_Año(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Mes")
            {
                dgCP.DataSource =await ControladorCompra.FiltroX_Mes(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Dia")
            {
                dgCP.DataSource =await ControladorCompra.FiltroX_Dia(dtFecha.Value,VariablesPublicas.IdEmpresaLogueada);
            }
        }
        private async Task FiltrarPagosCC()
        {
            if (TipoFiltro == "Año")
            {
                dgPagosCC.DataSource =await ControladorPagosCreditoTienda.FiltroX_Año(dtFecha.Value,VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Mes")
            {
                dgPagosCC.DataSource =await ControladorPagosCreditoTienda.FiltroX_Mes(dtFecha.Value,VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Dia")
            {
                 dgPagosCC.DataSource =await ControladorPagosCreditoTienda.FiltroX_Dia(dtFecha.Value,VariablesPublicas.IdEmpresaLogueada);
            }
        }
        private async Task FiltrarVentasCategorias()
        {
            if (TipoFiltro == "Año")
            {
                dgListaVentasCategorias.DataSource =await ControladorVenta.FiltroX_H_Año_Categorias(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
                dgInformeCategorias.DataSource=await ControladorVenta.FiltroX_H_Año_INFOCategorias(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Mes")
            {
                dgListaVentasCategorias.DataSource =await ControladorVenta.FiltroX_H_Mes_Categorias(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
                dgInformeCategorias.DataSource =await ControladorVenta.FiltroX_H_Mes_INFOCategorias(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Dia")
            {
                dgListaVentasCategorias.DataSource =await ControladorVenta.FiltroX_H_Dia_Categorias(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
                dgInformeCategorias.DataSource =await ControladorVenta.FiltroX_H_Dia_INFOCategorias(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
            }
        }
        private async Task FiltrarVentas()
        {
            if (TipoFiltro == "Año")
            {
                dglistaVentas.DataSource =await ControladorVenta.FiltroX_H_Año(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Mes")
            {
                dglistaVentas.DataSource =await ControladorVenta.FiltroX_H_Mes(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Dia")
            {
                dglistaVentas.DataSource =await ControladorVenta.FiltroX_H_Dia(dtFecha.Value,VariablesPublicas.IdEmpresaLogueada);
            }
        }
        private async Task FiltrarReporteGeneral()
        {
            await hallarPagoCP();

            await hallarVentas();
            await hallarCosto();
            await HallarUtilidad();
            await hallarGastos();

       
            await hallarPagoCC();

            Ganancia = Utilidad_frm - Gastos;
            //Costo = Gastos + PagoCP;
            //Ingresos = Ventas + PagoCC;
            //Producido = Ingresos - Costo;
            //ahora mostramos en el formulario
            txtPagosCP.Text= "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(PagoCP));
            //txtVentasTienda.Text= "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(Ventas));
            //txtPagosCC.Text= "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(PagoCC));
            //txtProducidoTienda.Text= "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(Ganancia));
            txtGastos.Text= "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(Gastos));
            txtCostoTotal.Text= "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(Costo));
            txtVentaTotal.Text= "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(Ventas));
            txtGanancia.Text= "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(Ganancia));
            txtUtilidad.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(Utilidad_frm));
        }
        private async Task hallarGastos()
        {
            if (TipoFiltro == "Año")
            {
                Gastos =await ControladorGastos.HallarTotalGastosAño(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Mes")
            {
                Gastos =await ControladorGastos.HallarTotalGastosMes(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Dia")
            {
                Gastos =await ControladorGastos.HallarTotalGastosDia(dtFecha.Value,VariablesPublicas.IdEmpresaLogueada);
            }
        }
        private async Task hallarPagoCC()
        {
            if (TipoFiltro == "Año")
            {
                PagoCC =await ControladorPagosCreditoTienda.SumarPagosX_Año(dtFecha.Value,VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Mes")
            {
                PagoCC =await ControladorPagosCreditoTienda.SumarPagosX_Mes(dtFecha.Value,VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Dia")
            {
                PagoCC =await ControladorPagosCreditoTienda.SumarPagosX_Dia(dtFecha.Value,VariablesPublicas.IdEmpresaLogueada);
            }
        }
        private async Task hallarVentas()
        {
            if (TipoFiltro == "Año")
            {
                Ventas =await ControladorVenta.TotalVentasTiendaAño(dtFecha.Value,"CONTADO", VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Mes")
            {
                Ventas =await ControladorVenta.TotalVentasTiendaMes(dtFecha.Value, "CONTADO", VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Dia")
            {
                Ventas =await ControladorVenta.TotalVentasTiendaDia(dtFecha.Value, "CONTADO",VariablesPublicas.IdEmpresaLogueada);
            }
        }
        private async Task hallarCosto()
        {
            if (TipoFiltro == "Año")
            {
                Costo =await ControladorVenta.CostoTiendaAño(dtFecha.Value, "CONTADO", VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Mes")
            {
                Costo =await ControladorVenta.CostoTiendaMes(dtFecha.Value, "CONTADO", VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Dia")
            {
                Costo =await ControladorVenta.CostoTiendaDia(dtFecha.Value, "CONTADO", VariablesPublicas.IdEmpresaLogueada);
            }
        }
        private async Task hallarPagoCP()
        {
            if (TipoFiltro == "Año")
            {
                PagoCP =await ControladorPagosCompras.hallarTotalPagoCPAño(dtFecha.Value,VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Mes")
            {
                PagoCP =await ControladorPagosCompras.hallarTotalPagoCPMes(dtFecha.Value,VariablesPublicas.IdEmpresaLogueada);
            }
            if (TipoFiltro == "Dia")
            {
                PagoCP =await ControladorPagosCompras.hallarTotalPagoCPDia(dtFecha.Value,VariablesPublicas.IdEmpresaLogueada);
            }
        }

        private void btnImprimirRGeneral_Click(object sender, EventArgs e)
        {
            frmReporte frm = new POS_SERINSIS_PC_2022.Reportes.frmReporte();
            AddOwnedForm(frm);
            frm.ReporteAImprimir = "InformeGeneral";
            frm.FechaReporte = dtFecha.Value;
            frm.TipoInforme = TipoFiltro;
            frm.IngresosTienda = Ventas;
            frm.EgresosTienda = PagoCP;
            frm.PagoCC = PagoCC;
            frm.UtilidadTienda = Ganancia;
            frm.Gastos = Gastos;
            frm.TotalINgresos = Ingresos;
            frm.TotalEgresos = Costo;
            frm.TotalUtilidad = Producido;
            frm.UtilidadVentas = Utilidad_frm;
            frm.ShowDialog();
        }

        private void btnImprimirFactura_Click(object sender, EventArgs e)
        {
            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            frm.TipoInforme = TipoFiltro;
            frm.FechaReporte = dtFecha.Value;
            frm.ListaVentaTienda();
            frm.ShowDialog();
        }

        private void dglistaVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            frm.TipoInforme = TipoFiltro;
            frm.FechaReporte = dtFecha.Value;
            frm.ReporteAImprimir = "PagosCredito";
            frm.PagoCC = PagoCC;
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            frm.TipoInforme = TipoFiltro;
            frm.FechaReporte = dtFecha.Value;
            frm.ReporteAImprimir = "PagosCP";
            frm.EgresosTienda = PagoCP;
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            frm.TipoInforme = TipoFiltro;
            frm.FechaReporte = dtFecha.Value;
            frm.ReporteAImprimir = "ListaGastos";
            frm.Gastos = Gastos;
            frm.ShowDialog();
        }

        private async void frmreporteDiario_Load(object sender, EventArgs e)
        {
            using(SistemaPOSEntities cn =new SistemaPOSEntities())
            {
                await CargarCategorias();
            }
        }
        private async Task CargarCategorias()
        {
            cmbCategorias.DataSource = null;
            cmbCategorias.ValueMember = "id";
            cmbCategorias.DisplayMember = "nombreCategoria";
            cmbCategorias.DataSource =await ConotroladorCategoria.listaCompleta();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            frm.TipoInforme = TipoFiltro;
            frm.FechaReporte = dtFecha.Value;
            frm.ListaVentaTiendaProducto();
            frm.ShowDialog();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        DataTable dt1 = new DataTable();
        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

            int cantidad = 0;
            decimal total = 0;
            if (TipoFiltro == "Año")
            {
                dt1= ControladorVenta.FiltroX_H_Año_IdCategorias(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada, Convert.ToInt32(cmbCategorias.SelectedValue));
                if (dt1 != null)
                {
                    dgListaVentasCategorias.DataSource = dt1;
                }
                else
                {
                    MessageBox.Show("¡No se encontraron ventas de la categoría "+cmbCategorias.Text+"...!", "¡Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            if (TipoFiltro == "Mes")
            {
                dt1 = ControladorVenta.FiltroX_H_Mes_IdCategorias(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada, Convert.ToInt32(cmbCategorias.SelectedValue));
                if (dt1 != null)
                {
                    dgListaVentasCategorias.DataSource = dt1;
                }
                else
                {
                    MessageBox.Show("¡No se encontraron ventas de la categoría " + cmbCategorias.Text + "...!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            if (TipoFiltro == "Dia")
            {
                dt1 = ControladorVenta.FiltroX_H_Dia_IdCategorias(dtFecha.Value, VariablesPublicas.IdEmpresaLogueada, Convert.ToInt32(cmbCategorias.SelectedValue));
                if (dt1 != null)
                {
                    dgListaVentasCategorias.DataSource = dt1;
                }
                else
                {
                    MessageBox.Show("¡No se encontraron ventas de la categoría " + cmbCategorias.Text + "...!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if(TipoFiltro!="")
            {
                if (dt1 != null)
                {
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow rows in dt1.Rows)
                        {
                            cantidad = cantidad + Convert.ToInt32(rows["cantidadDetalleVenta_c"]);
                            total = total + Convert.ToDecimal(rows["totalDetalleVenta_c"]);
                        }
                        txtCantidadCantidadVendida.Text = Convert.ToString(cantidad);
                        txtTotalVentaCategoria.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToInt32(total));
                    }
                }
            }

        }

        private void dglistaVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dglistaVentas.RowCount > 0 && e.RowIndex >= 0)
            {
                DataGridViewRow fila = dglistaVentas.Rows[e.RowIndex];
                ConsecutivoVenta = Convert.ToInt32(fila.Cells["id"].Value);


                frmDetalleFacturaCredito frm = new frmDetalleFacturaCredito();
                AddOwnedForm(frm);
                frm.HistorialVentas = true;
                frm.IDVenta_frm = ConsecutivoVenta;
                frm.NumeroVenta = Convert.ToInt32(fila.Cells["numeroVenta"].Value); ;
                frm.ShowDialog();
            }
        }
    }
  }


using DAL;
using DAL.Controladores;
using DAL.Controladores.Tienda;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using POS_SERINSIS_PC_2022.Formularios;
using SERINSI_PC.Clases;
using SERINSI_PC.Formularios.Inventario;
using SERINSI_PC.Formularios.Inventario_;
using SERINSI_PC.Formularios.Ventas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invenpol_Parqueadero_Motos.Formularios.Tiemda
{
    public partial class frmCompras : Form
    {
        public decimal costoAnterior_frm = 0;
        public int IdInventario_frm = 0;
        public int IdInventarioTotal_frm = 0;
        public int IdCompra_frm = 0;
        int IdDetalleCompra_frm = 0;
        public int IdProducto_frm = 0;
        decimal cantidadPresentacion_frm = 0;
        public decimal contenidoPresentacion_frm = 0;
        public decimal cantidadUnidad_frm = 0;
        decimal costoUnidad_frm = 0;
        decimal costoTotal_frm = 0;
        decimal porcentajeIvaDetalle_frm = 0;
        decimal porcentajeDescuento_frm = 0;
        decimal valorDescuento_frm = 0;

        public string tipoMedida_frm = "";

        decimal porcentajeUtilidad_frm = 0;
        decimal porcentajeIVA_frm = 0;
        decimal valorIVA_frm = 0;
        decimal precioPublico_frm = 0;
        decimal valorUtilidad_frm = 0;
        decimal valorUnitario_frm = 0;

        decimal Total = 0;
        decimal Iva = 0;
        decimal Descuento = 0;
        decimal SubTotal = 0;

        int IdEstadoCompra_frm = 1;

        decimal sumaCompras = 0;
        decimal sumaVentas = 0;
        decimal rango1_frm = 0;
        decimal rango2_frm=0;
        public int IdPrecios_frm = 0;
        public decimal cantidadAnterior = 0;

        List<V_DetalleCompra> listaDetalle = new List<V_DetalleCompra>();

        Guid guidCompra_Frm;
        public frmCompras()
        {
            InitializeComponent();
          
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private async Task CargarPresentacion()
        {
            cmbPresentacion.DataSource = null;
            cmbPresentacion.ValueMember = "id";
            cmbPresentacion.DisplayMember = "nombrePresentacion";
            cmbPresentacion.DataSource =await controladorPresentacion.ListaCompleta();
        }
        private async void frmCompras_Load(object sender, EventArgs e)
        {

            FrmLoading loading = null;
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    loading = FrmLoading.ShowLoading(this, "Cargarndo...");
                    // inicio


                    await Load_frm();


                    // fin
                    FrmLoading.CloseLoading(this, loading);
                }
            }
            catch (Exception ex)
            {
                FrmLoading.CloseLoading(this, loading);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        private async Task Load_frm()
        {
            await CargarPresentacion();
            await CargarProveedor();

            /* en esta parte verificamos si hay una compra con el estado AI en 1 */
            Compras compras = new Compras();
            compras =await ControladorCompra.ConsultarEstadoAI(1,VariablesPublicas.IdEmpresaLogueada);
            if (compras != null)
            {
                IdCompra_frm = compras.id;
                string guidT = Convert.ToString(compras.guidCompra);
                guidCompra_Frm =Guid.Parse(guidT);
                txtFacturaCompra.Text = compras.facturaCompra;
                IdEstadoCompra_frm =Convert.ToInt32(compras.idEstadoAI);
            }
            else
            {
                IdCompra_frm = 0;
                guidCompra_Frm = Guid.NewGuid(); 
                txtFacturaCompra.Text = "0";
                IdEstadoCompra_frm = 1;
                /*en esta parte gestionamos la compra nueva*/
                await GestionarCompra(0);
                /*consultamos el id de la compra*/
                compras = new Compras();
                compras =await ControladorCompra.ConsultarXGuid(guidCompra_Frm);
                if (compras != null)
                {
                    IdCompra_frm = compras.id;
                    string guidT = Convert.ToString(compras.guidCompra);
                    guidCompra_Frm = Guid.Parse(guidT);
                    txtFacturaCompra.Text = compras.facturaCompra;
                    IdEstadoCompra_frm = Convert.ToInt32(compras.idEstadoAI);
                }
            }
            await CargarDGDetalle();
            labelTitulo.Text = "Compra # " + IdCompra_frm;
            txtFacturaCompra.Focus();
        }
        private async Task CargarDGDetalle()
        {
            listaDetalle=await ControladorDetalleCompra.listaXIdCompra(IdCompra_frm);
            if(listaDetalle==null)
            {
                listaDetalle = new List<V_DetalleCompra>();
            }
            dgDetalleCompra.DataSource = listaDetalle;

            ClassTotales totalesCompra = new ClassTotales();
            totalesCompra =await ControladorDetalleCompra.ConsultarTotalesAsync(IdCompra_frm);
            if (totalesCompra != null)
            {
                SubTotal = totalesCompra.subTotal;
                Descuento = totalesCompra.totalDescuento;
                Iva = totalesCompra.totalIVA;
            }

            Total = (SubTotal - Descuento) + Iva;

            Total =await ControladorDetalleCompra.SumaSubTotalCompra(IdCompra_frm);

            txtSubTotal.Text= "$ " + string.Format("{0:#,##0.##}", SubTotal);
            textDescuento.Text = "$ " + string.Format("{0:#,##0.##}", Descuento);
            txtIva.Text = "$ " + string.Format("{0:#,##0.##}", Iva);
            txtTotal.Text = "$ " + string.Format("{0:#,##0.##}", Total);
        }
        private async Task CrearNuevaCompra()
        {
            Compras objCompras = new Compras();
            objCompras =await ControladorCompra.ConsultarXGuid(guidCompra_Frm);
            if (objCompras != null)
            {
                IdCompra_frm = objCompras.id;
            }
            else
            {
                objCompras = new Compras();
                IdCompra_frm = 0;
                objCompras.id = IdCompra_frm;
                objCompras.guidCompra = guidCompra_Frm;
                objCompras.idSede = VariablesPublicas.IdEmpresaLogueada;
                objCompras.idProveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
                objCompras.fechaCompra = DateTime.Now;
                objCompras.facturaCompra = "--";
                objCompras.subtotalCompra = 0;
                objCompras.ivaCompra = 0;
                objCompras.totalCompra = 0;
                objCompras.totalCompra = 0;
                objCompras.valorPagadoCompra = 0;
                objCompras.saldoCompra = 0;
                objCompras.extencionArchivo = "--";
                objCompras.totalDescuento = 0;
                bool sql =await ControladorCompra.GuardarEditarEliminarCompra(objCompras,0);
                if (sql == false)
                {
                    MessageBox.Show("Ha ocurrido un error inesperado.", "¡Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                else
                {
                    await HallarIdCompra();
                }
            }
        }
        private async Task HallarIdCompra()
        {
            Compras objCompras = new Compras();
            objCompras =await ControladorCompra.ConsultarXGuid(guidCompra_Frm);
            if (objCompras != null)
            {
                IdCompra_frm = objCompras.id;
            }
        }
        private async void linkAgregarProveedor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmProveedor frmProV = new frmProveedor();
            AddOwnedForm(frmProV);
            frmProV.panelTitulo.Visible = true;
            frmProV.ShowDialog();
            await CargarProveedor();  
        }

        private void Mensaje_txtFactura()
        {
            this.ttMensaje.SetToolTip(txtFacturaCompra, "Ingresa el NIT del proveedor y presiona la tecla enter para buscar el proveedor por el NIT.");
        }
        private async Task CargarProveedor()
        {
            cmbProveedor.DataSource = null;
            cmbProveedor.ValueMember = "id";
            cmbProveedor.DisplayMember = "nombreProveedor";
            cmbProveedor.DataSource =await ControladorProveedor.ListaCompleta();
        }

        private void txtFacturaCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode==Keys.Tab)
            {
                cmbProveedor.Focus();
            }
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtCodigo.Focus();
        }

        private void linkAgregarProveedor_MouseEnter(object sender, EventArgs e)
        {
            this.ttMensaje.SetToolTip(linkAgregarProveedor, "Si el proveedor no se encuentra en la lista presione este link para agregarlo.");
        }

        private void txtCodigo_MouseEnter(object sender, EventArgs e)
        {
            this.ttMensaje.SetToolTip(txtCodigo, "ingrese el codigo del producto a buscar y presione la tecla enter.");
        }

        private void txtCostoUnidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPorcentajeIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtPorcentajeIVA.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtCostoUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtPrecioUnitario.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtPorcentajeDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtPorcentajeDescuento.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtCantidad.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtCostoTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtCostoTotal.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void cmbProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtCodigo.Focus();
            }
        }

        private void BuscarProducto()
        {
            frmBuscarProductoCompra frm = new frmBuscarProductoCompra();
            AddOwnedForm(frm);
            frm.ShowDialog();
        }
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            BuscarProducto();

            txtCantidad.Focus();
        }

        private void btnCalcularCantidad_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(txtPrecioUnitario.Text!="" && txtCantidad.Text != "")
            {
                costoUnidad_frm =Convert.ToDecimal(txtPrecioUnitario.Text);
                cantidadPresentacion_frm = Convert.ToDecimal(txtCantidad.Text);
                costoTotal_frm = costoUnidad_frm * cantidadPresentacion_frm;
                costoTotal_frm= decimal.Round(costoTotal_frm, 0);
                txtCostoTotal.Text = Convert.ToString(costoTotal_frm);
            }
            else
            {
                MessageBox.Show("¡Para poder calcular debe de ingresar el costo unidad y la cantidad del producto.!", "¡Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnCalcularCosto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCostoTotal.Text != "" && txtCantidad.Text != "")
            {
                cantidadPresentacion_frm = Convert.ToDecimal(txtCantidad.Text);
                costoTotal_frm = Convert.ToDecimal(txtCostoTotal.Text);
                costoUnidad_frm = costoTotal_frm / cantidadPresentacion_frm;
                costoUnidad_frm= decimal.Round(costoUnidad_frm, 0);
                txtPrecioUnitario.Text = Convert.ToString(costoUnidad_frm);
            }
            else
            {
                MessageBox.Show("¡Para poder calcular debe de ingresar el costo total y la cantidad del producto.!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCostoUnidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode==Keys.Tab)
            {
                txtCantidad.Focus();
            }
        }
        string Ruta, NombreArchivo, Extencion="**";
        byte[] Arreglo;
        Guid guidArchivo_frm;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Process p = new Process();
            //p.StartInfo.FileName = VariablesPublicas.RutaImagenes+ "\\FacturasCompras\\"+guidFrm+".pdf";
            //p.Start();

            frmArchivosCompras frm = new frmArchivosCompras();
            AddOwnedForm(frm);
            frm.IdCompra_frm = IdCompra_frm;
            frm.ShowDialog();
        }

        private void btnCalcularPorcentageIVA_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCostoUnidad.Text != "")
            {
                if (txtPorcentajeUtilidad.Text != "")
                {
                    porcentajeUtilidad_frm = Convert.ToDecimal(txtPorcentajeUtilidad.Text);
                    valorUtilidad_frm = (porcentajeUtilidad_frm * valorUnitario_frm) / 100;
                    int entero = Convert.ToInt32(valorUtilidad_frm);
                    valorUtilidad_frm = Convert.ToDecimal(entero);
                    txtValorUtilidad.Text = Convert.ToString(entero);

                    precioPublico_frm = valorUnitario_frm + valorUtilidad_frm;
                    int entero2 = Convert.ToInt32(precioPublico_frm);
                    precioPublico_frm = Convert.ToDecimal(entero2);
                    txtPrecioPublico.Text = Convert.ToString(entero2);
                }
                else
                {
                    MessageBox.Show("Para poder calcular el porcentaje utilidad debe de ingresar el porsentaje iva", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPorcentajeUtilidad.Focus();
                }
            }
            else
            {
                MessageBox.Show("Para poder calcular el porcentaje utilidad debe de ingresar el costo unidad", "¡Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void MostarValores()
        {
            int p_Utilidad = Convert.ToInt32(porcentajeUtilidad_frm);
            int p_iva = Convert.ToInt32(porcentajeIVA_frm);
            int costo = Convert.ToInt32(costoUnidad_frm);
            int precioPublico = Convert.ToInt32(precioPublico_frm);
            int valorUtilidad = Convert.ToInt32(valorUtilidad_frm);

            txtPorcentajeUtilidad.Text = Convert.ToString(p_Utilidad);
            txtPorcentajeIVA.Text = Convert.ToString(p_iva);
            txtPrecioUnitario.Text = Convert.ToString(costo);
            txtPrecioPublico.Text = Convert.ToString(precioPublico);
            txtValorUtilidad.Text = Convert.ToString(valorUtilidad);

        }

        private void btnCalcularPrecioPublico_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCostoUnidad.Text != "")
            {
                if (txtPrecioPublico.Text != "")
                {
                    precioPublico_frm = Convert.ToDecimal(txtPrecioPublico.Text.Replace(".",","));
                    valorUtilidad_frm = precioPublico_frm - Convert.ToDecimal(txtCostoPresentacion.Text.Replace(".", ","));
                    if (Convert.ToDecimal(txtCostoPresentacion.Text) > 0)
                    {
                        porcentajeUtilidad_frm = (valorUtilidad_frm * 100) / Convert.ToDecimal(txtCostoPresentacion.Text.Replace(".", ","));
                    }
                    else
                    {
                        porcentajeUtilidad_frm =0;
                    }

                    int utilidadEntero = Convert.ToInt32(valorUtilidad_frm);
                    valorUtilidad_frm = Convert.ToDecimal(utilidadEntero);
                    txtValorUtilidad.Text = Convert.ToString(utilidadEntero);

                    int porcentajeUtilidadEntero = Convert.ToInt32(porcentajeUtilidad_frm);
                    porcentajeUtilidad_frm = Convert.ToDecimal(porcentajeUtilidadEntero);
                    txtPorcentajeUtilidad.Text = Convert.ToString(porcentajeUtilidadEntero);
                }
                else
                {
                    MessageBox.Show("Para poder calcular el valor utilidad debe de ingresar el precio publico", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrecioPublico.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Para poder calcular el valor utilidad debe de ingresar el costo unidad", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool verificarCamposCompra()
        {
            if (txtFacturaCompra.Text != "" &&
                cmbProveedor.Text != "" &&
                dgDetalleCompra.RowCount>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool verificarCampos()
        {
            if (cmbPresentacion.Text!=""&&
                txtCostoAnterior.Text!=""&&
                txtDescripcion.Text!=""&&
                txtCodigo.Text!=""&&
                txtCantidad.Text != "" &&
               txtPrecioUnitario.Text != "" &&
               txtPorcentajeDescuento.Text != "" &&
               txtValorDescuento.Text != "" &&
               txtPorcentajeIVA.Text != "" &&
               txtValorIva.Text != ""&&
               txtCostoTotal.Text!=""&&
               txtCostoUnidad.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private async void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            //verificamos los campos obligatorios
            bool campos = verificarCampos();
            if (campos == false)
            {
                MessageBox.Show("para poder agregar el producto los campos con el signo (*) no puedes estar vacíos.", "¡Error!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }


            sumaCompras =await ControladorDetalleCompra.SumaCompras(IdInventario_frm, VariablesPublicas.IdEmpresaLogueada);
            sumaVentas =await ControladorDetalleVenta.SumaVentaProducto(IdInventario_frm,VariablesPublicas.IdEmpresaLogueada);
            int Boton = 0;
            //lo primero es agragar el producto a la lista de detalle compra
            DetalleCompra objDetalleCompra =await ControladorDetalleCompra.ConsultarIdCompra_idInventario(IdCompra_frm,IdInventario_frm);
            if (objDetalleCompra != null)
            {
                //    MessageBox.Show("¡el producto "+txtDescripcion.Text+" ya se encuentra agregado!", "¡Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //    btnLimpiar.PerformClick();
                //    return;
                objDetalleCompra = new DetalleCompra();
                objDetalleCompra.id = 0;
                objDetalleCompra.idCompra = IdCompra_frm;
                objDetalleCompra.idInventario = IdInventario_frm;
                objDetalleCompra.cantidad = Convert.ToDecimal(txtCantidad.Text);
                objDetalleCompra.precioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
                objDetalleCompra.porcentajeDescuento = Convert.ToDecimal(txtPorcentajeDescuento.Text);
                objDetalleCompra.valorDescuento = Convert.ToDecimal(txtValorDescuento.Text);
                objDetalleCompra.porcentajeIva = Convert.ToDecimal(txtPorcentajeIVA.Text);
                objDetalleCompra.valorIva = Convert.ToDecimal(txtValorIva.Text);
                objDetalleCompra.totalDetalle = Convert.ToDecimal(txtCostoTotal.Text);
                objDetalleCompra.costoUnidad = Convert.ToDecimal(txtCostoUnidad.Text);
                objDetalleCompra.rango1 = sumaCompras;
                objDetalleCompra.rango2 = sumaCompras + Convert.ToDecimal(txtCantidad.Text);
                if (sumaVentas < rango1_frm)
                {
                    objDetalleCompra.estadoCosto = 0;
                }
                else if (sumaVentas > rango1_frm && sumaVentas <= rango2_frm)
                {
                    objDetalleCompra.estadoCosto = 1;
                }
                else if (sumaVentas > rango2_frm)
                {
                    objDetalleCompra.estadoCosto = 2;
                }
                objDetalleCompra.idProducto = IdProducto_frm;
                objDetalleCompra.idInventarioTotal = IdInventarioTotal_frm;
            }
            else
            {
                objDetalleCompra = new DetalleCompra();
                objDetalleCompra.id = 0;
                objDetalleCompra.idCompra = IdCompra_frm;
                objDetalleCompra.idInventario = IdInventario_frm;
                objDetalleCompra.cantidad = Convert.ToDecimal(txtCantidad.Text);
                objDetalleCompra.precioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text); 
                objDetalleCompra.porcentajeDescuento = Convert.ToDecimal(txtPorcentajeDescuento.Text);
                objDetalleCompra.valorDescuento = Convert.ToDecimal(txtValorDescuento.Text);
                objDetalleCompra.porcentajeIva = Convert.ToDecimal(txtPorcentajeIVA.Text);
                objDetalleCompra.valorIva = Convert.ToDecimal(txtValorIva.Text);
                objDetalleCompra.totalDetalle = Convert.ToDecimal(txtCostoTotal.Text);
                objDetalleCompra.costoUnidad = Convert.ToDecimal(txtCostoUnidad.Text);
                objDetalleCompra.rango1 = sumaCompras;
                objDetalleCompra.rango2 = sumaCompras + Convert.ToDecimal(txtCantidad.Text);
                if (sumaVentas < rango1_frm)
                {
                    objDetalleCompra.estadoCosto = 0;
                }
                else if (sumaVentas > rango1_frm && sumaVentas <= rango2_frm)
                {
                    objDetalleCompra.estadoCosto = 1;
                }
                else if (sumaVentas > rango2_frm)
                {
                    objDetalleCompra.estadoCosto = 2;
                }
                objDetalleCompra.idProducto = IdProducto_frm;
                objDetalleCompra.idInventarioTotal = IdInventarioTotal_frm;
            }
            bool sqlDetalleCompra =await ControladorDetalleCompra.GuardarEditarEliminarCompra(objDetalleCompra,Boton);
            if (sqlDetalleCompra == true)
            {
                InventarioTotal inventarioTotal = new InventarioTotal();
                inventarioTotal =await controladorInventarioTotal.ConsultarIdProducto(IdProducto_frm,VariablesPublicas.IdEmpresaLogueada);
                if (inventarioTotal != null)
                {
                    inventarioTotal.costoUnidad = Convert.ToDecimal(txtCostoUnidad.Text);
                    RespuestaCRUD crud =await controladorInventarioTotal.CrearEditarEliminarInventarioTotal(inventarioTotal, 1);
                    if (crud.estado == true)
                    {
                        MessageBox.Show("¡Inventario actualizado correctamente...!", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        await Load_frm();
                    }
                }
            }
        }

        private void ActivarCosto(int IdDetalle,int IdInventario)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "update DetalleCompra set estadoCosto=0 where idInventario="+IdInventario;
                cmd.ExecuteNonQuery();
                ConexionSQL.CerrarConexion();

                ConexionSQL.AbrirConexion();
                SqlCommand cmd1 = ConexionSQL.connection.CreateCommand();
                cmd1.CommandText = "update DetalleCompra set estadoCosto=1 where id=" + IdDetalle;
                cmd1.ExecuteNonQuery();
                ConexionSQL.CerrarConexion();

                ConexionSQL.AbrirConexion();
                SqlCommand cmd2 = ConexionSQL.connection.CreateCommand();
                cmd2.CommandText = "update Precios set utilidad="+valorUtilidad_frm+",PrecioVenta="+precioPublico_frm+",porcentajeUtilidad="+porcentajeUtilidad_frm+" where id=" +IdPrecios_frm;
                cmd2.ExecuteNonQuery();
                ConexionSQL.CerrarConexion();
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
        }
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgDetalleCompra.RowCount > 0 && dgDetalleCompra.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgDetalleCompra.Rows[dgDetalleCompra.CurrentRow.Index];
                IdDetalleCompra_frm = Convert.ToInt32(fila.Cells["id"].Value);
                IdInventarioTotal_frm= Convert.ToInt32(fila.Cells["idInventarioTotal"].Value);
                cantidadPresentacion_frm = Convert.ToInt32(fila.Cells["cantidad"].Value);
                contenidoPresentacion_frm = Convert.ToInt32(fila.Cells["contenidoPresentacion"].Value);

                if (MessageBox.Show("¿Está seguro de eliminar el producto "+Convert.ToString(fila.Cells["descripcionProducto"].Value)+" "+Convert.ToString(fila.Cells["nombrePresentacion"].Value)+" ?", "¡Eliminar!",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DetalleCompra objDetalleCompra = new DetalleCompra();
                    objDetalleCompra =await ControladorDetalleCompra.ConsultaX_idDetalle(IdDetalleCompra_frm);
                    if (objDetalleCompra != null)
                    {
                        bool eliminar =await ControladorDetalleCompra.GuardarEditarEliminarCompra(objDetalleCompra,2);
                        if (eliminar == true)
                        {
                            btnLimpiar.PerformClick();
                        }
                    }
                }
            }
        }

        private void btnCalcularValorUnitario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                cantidadPresentacion_frm = Convert.ToDecimal(txtCantidad.Text);
                if (txtCostoTotal.Text != "")
                {
                    costoTotal_frm = Convert.ToDecimal(txtCostoTotal.Text);
                    valorUnitario_frm = costoTotal_frm / cantidadPresentacion_frm;
                    int entero = Convert.ToInt32(valorUnitario_frm);
                    valorUnitario_frm = Convert.ToDecimal(entero);
                    txtPrecioUnitario.Text = Convert.ToString(entero);
                }
                else
                {
                    MessageBox.Show("Para poder calcular el valor unitario debe de ingresar el costo total", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCostoTotal.Focus();
                }
            }
            else
            {
                MessageBox.Show("Para poder calcular el valor unitario debe de ingresar la cantidad ", "¡Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtCantidad.Focus();
            }
        }

        private void btnCalcularCostoTotal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                cantidadPresentacion_frm = Convert.ToDecimal(txtCantidad.Text);
                if (txtPrecioUnitario.Text != "")
                {
                    valorUnitario_frm = Convert.ToDecimal(txtPrecioUnitario.Text);
                    costoTotal_frm = valorUnitario_frm * cantidadPresentacion_frm;
                    int entero = Convert.ToInt32(costoTotal_frm);
                    costoTotal_frm = Convert.ToDecimal(entero);
                    txtCostoTotal.Text = Convert.ToString(entero);
                }
                else
                {
                    MessageBox.Show("Para poder calcular el valor unitario debe de ingresar el valor unitario", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrecioUnitario.Focus();
                }
            }
            else
            {
                MessageBox.Show("Para poder calcular el valor unitario debe de ingresar la cantidad ", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCantidad.Focus();
            }
        }

        private void btnCalcularValorDescuento_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtPrecioUnitario.Text != "")
            {
                valorUnitario_frm = Convert.ToDecimal(txtPrecioUnitario.Text);
                if (txtPorcentajeDescuento.Text != "")
                {
                    porcentajeDescuento_frm = Convert.ToDecimal(txtPorcentajeDescuento.Text);
                    valorDescuento_frm = (porcentajeDescuento_frm * valorUnitario_frm) / 100;
                    int entero = Convert.ToInt32(valorDescuento_frm);
                    valorDescuento_frm = Convert.ToDecimal(entero);
                    txtValorDescuento.Text = Convert.ToString(entero);
                }
                else
                {
                    MessageBox.Show("Para poder calcular el valor descuento debe de ingresar el % descuento", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPorcentajeDescuento.Focus();
                }
            }
            else
            {
                MessageBox.Show("Para poder calcular el valor descuento debe de ingresar el valor unitario", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioUnitario.Focus();
            }
        }

        private void btnCalcularValorIVA_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtPrecioUnitario.Text != "")
            {
                valorUnitario_frm = Convert.ToDecimal(txtPrecioUnitario.Text);
                if (txtPorcentajeIVA.Text != "")
                {
                    porcentajeIVA_frm = Convert.ToDecimal(txtPorcentajeIVA.Text);
                    valorIVA_frm = (porcentajeIVA_frm * valorUnitario_frm) / 100;
                    int entero = Convert.ToInt32(valorIVA_frm);
                    valorIVA_frm = Convert.ToDecimal(entero);
                    txtValorIva.Text = Convert.ToString(entero);
                }
                else
                {
                    MessageBox.Show("Para poder calcular el valor IVA debe de ingresar el % IVA", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPorcentajeIVA.Focus();
                }
            }
            else
            {
                MessageBox.Show("Para poder calcular el valor IVA debe de ingresar el valor unitario", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioUnitario.Focus();
            }
        }

        private void btnCalcularCostoUnidad_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtPrecioUnitario.Text != "")
            {
                valorUnitario_frm = Convert.ToDecimal(txtPrecioUnitario.Text);
                costoUnidad_frm = (valorUnitario_frm - valorDescuento_frm) + valorIVA_frm;
                int entero = Convert.ToInt32(costoUnidad_frm);
                costoUnidad_frm = Convert.ToDecimal(entero);
                costoUnidad_frm = costoUnidad_frm / contenidoPresentacion_frm;
                txtCostoUnidad.Text = Convert.ToString(costoUnidad_frm);
                txtCostoPresentacion.Text= Convert.ToString(entero);
            }
            else
            {
                MessageBox.Show("Para poder calcular el costo unidad debe de ingresar el valor unitario", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioUnitario.Focus();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            costoAnterior_frm = 0;
            IdInventario_frm = 0;
            IdProducto_frm = 0;
            cantidadPresentacion_frm = 0;
            costoUnidad_frm = 0;
            costoTotal_frm = 0;
            porcentajeIvaDetalle_frm = 0;
            porcentajeDescuento_frm = 0;
            valorDescuento_frm = 0;
            tipoMedida_frm = "";
            porcentajeUtilidad_frm = 0;
            porcentajeIVA_frm = 0;
            valorIVA_frm = 0;
            precioPublico_frm = 0;
            valorUtilidad_frm = 0;
            valorUnitario_frm = 0;
            sumaCompras = 0;
            sumaVentas = 0;
            rango1_frm = 0;
            rango2_frm = 0;
            cantidadAnterior = 0;

            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtCostoAnterior.Text = "";
            cmbPresentacion.SelectedIndex = -1;
            txtCantidad.Text = "";
            txtPrecioUnitario.Text = "";
            txtPorcentajeDescuento.Text = "";
            txtValorDescuento.Text = "";
            txtPorcentajeIVA.Text = "";
            txtValorIva.Text = "";
            txtCostoTotal.Text = "";
            txtCostoUnidad.Text = "";
            txtPorcentajeUtilidad.Text = "";
            txtValorUtilidad.Text = "";
            txtPrecioPublico.Text = "";

            CargarDGDetalle();
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtPrecioUnitario.Focus();
            }
        }

        private void txtPrecioUnitario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtPorcentajeDescuento.Focus();
            }
        }

        private void txtPorcentajeDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtPorcentajeIVA.Focus();
            }
        }

        private void txtPorcentajeIVA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtPrecioPublico.Focus();
            }
        }

        private void txtCantidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtCantidad.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtPrecioUnitario.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtPorcentajeIVA_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtPorcentajeIVA.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtCostoTotal_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtCostoTotal.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtPorcentajeUtilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtPorcentajeUtilidad.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtPrecioPublico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtPrecioPublico.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }
        private async Task<bool> GestionarCompra(int Boton)
        {
            Compras objCompras = new Compras();
            objCompras =await ControladorCompra.ConsultaListaX_IdCompra_Entity(IdCompra_frm);
            if (objCompras != null)
            {
                if(Boton == 0)
                {
                    return false;
                }
            }
            if (Boton == 0)
            {
                objCompras = new Compras();
                IdCompra_frm = 0;
            }
            objCompras.id = IdCompra_frm;
            objCompras.guidCompra = guidCompra_Frm;
            objCompras.idSede = VariablesPublicas.IdEmpresaLogueada;
            objCompras.idProveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
            objCompras.fechaCompra = dtFecha.Value;
            objCompras.facturaCompra = txtFacturaCompra.Text;
            objCompras.subtotalCompra = SubTotal;
            objCompras.ivaCompra = Iva;
            objCompras.totalCompra = Total;
            objCompras.valorPagadoCompra = 0;
            objCompras.saldoCompra = Total;
            objCompras.extencionArchivo = Extencion;
            objCompras.totalDescuento = Descuento;
            objCompras.idEstadoAI = IdEstadoCompra_frm;
            bool sqlCompra =await ControladorCompra.GuardarEditarEliminarCompra(objCompras, Boton);
            if (sqlCompra == true)
            {
                return true;
            }
            return false;
        }
        private async void btnGuardarCompra_Click(object sender, EventArgs e)
        {
            //verificamos los campos obligatorios
            bool campos = verificarCamposCompra();
            if (campos == false)
            {
                MessageBox.Show("para poder guardar la compra, los campos; fecha, Factura de compra, nombre y la lista de productos no puedes estar vacíos.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IdEstadoCompra_frm = 2;
            bool gcompra=await GestionarCompra(1);
            if (gcompra == true)
            {
                MessageBox.Show("¡La compra fue guardada correctamente...!", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                IdCompra_frm = 0;
                SubTotal = 0;
                Iva = 0;
                Total = 0;
                await Load_frm();
            }
        }

        private void btnCerrarCompra_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string ArchivoTExto;
        private async void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "Todos los archivos (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Ruta = openFileDialog1.FileName;
                    NombreArchivo = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    Extencion = Path.GetExtension(openFileDialog1.FileName);
                    guidArchivo_frm = Guid.NewGuid();
                }
                //convertimos nuestro archivo en byte[]
                Arreglo = File.ReadAllBytes(Ruta);
                //convertimos nuestro arreglo a texto
                ArchivoTExto = System.Text.Encoding.UTF8.GetString(Arreglo);
                //en esta parte enviamos a guardar el archivo a la carpeta de las facturas de compra
                //File.WriteAllBytes(VariablesPublicas.RutaImagenes+ "\\FacturasCompras\\" + guidArchivo_frm+Extencion,Arreglo);
                int Cargar = ClassGuardarImagen.guardarImagenDriver(Arreglo, VariablesPublicas.RutaImagenes, "\\FacturasCompras\\", guidArchivo_frm + Extencion);
                int CargarServidor=ClassArchivos.SubirArchivo(ClassRutas.ServidorImagenes, ClassRutas.UsuarioServidor, ClassRutas.ClaveServidor, VariablesPublicas.RutaImagenes + "\\FacturasCompras\\" + guidArchivo_frm + Extencion, Convert.ToString(guidArchivo_frm), Extencion, "FacturasCompras");
                
                if (Cargar == 1)
                {
                    //en esta parte insertamos el registro del archivo a la bae de datos 
                    ArchivoCompras archivoCompras = new ArchivoCompras();
                    archivoCompras =await controladorArchivoCompra.ConsultarGuidArchivo(guidArchivo_frm);
                    if (archivoCompras != null)
                    {
                        MessageBox.Show("El archivo ya existe.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        archivoCompras = new ArchivoCompras();
                        archivoCompras.id = 0;
                        archivoCompras.idCompra = IdCompra_frm;
                        archivoCompras.guidArchivo = guidArchivo_frm;
                        archivoCompras.extencion = Extencion;
                        bool insert =await controladorArchivoCompra.CrearEditarEliminar(archivoCompras,0);
                        if (insert == true)
                        {
                            MessageBox.Show("El archivo fue cargado correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El archivo no se puedo cargar.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
    }
}

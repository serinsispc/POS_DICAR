using DAL.Controladores;
using DAL.Controladores.Administrador;
using DAL.Controladores.Tienda;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using Invenpol_Parqueadero_Motos.Formularios.Tiemda;
using POS_SERINSIS_PC_2022.Formularios;
using SERINSI_PC.Clases;
using SERINSI_PC.Formularios.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Ventas
{
    public partial class frmCajaTouch : Form
    {
        public bool Cotizacion = false;
        int IdInevntario_frm = 0;
        int IdVenta_Frm = 0;
        int IdDetalle_frm = 0;
        decimal cantidad_frm = 0;
        public decimal cantidadEditada_frm = 0;
        Guid guidVenta_frm;
        decimal SubTotal_frm = 0;
        decimal costoTotalVenta_frm = 0;
        decimal valorIvaTotalVenta_frm = 0;
        decimal utilidadTotalVenta_frm = 0;
        public decimal contenidoPresentacion_frm = 0;
        int idInventarioTotal_frm = 0;
        public frmCajaTouch()
        {
            InitializeComponent();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void CrearGuid()
        {
            guidVenta_frm = Guid.NewGuid();
        }
        private bool NuevaVenta()
        {
            try
            {
                TablaVentas objventa = new TablaVentas();
                objventa.id = 0;
                objventa.fechaVenta = DateTime.Now;
                objventa.tipoFactura = "--";
                objventa.numeroVenta = 0;
                objventa.descuentoVenta = 0;

                objventa.ivaVenta = 0;

                objventa.efectivoVenta = 0;
                objventa.cambioVenta = 0;
                objventa.tipoVenta = "--";
                objventa.estadoVenta = "--";
                objventa.tipoPago = "--";
                objventa.numeroReferenciaPago = "--";
                objventa.idBaseCaja = VariablesPublicas.IdBaseActiva;
                objventa.diasCredito = 0;
                objventa.fechaVencimiento = "--";
                objventa.IdSede = VariablesPublicas.IdEmpresaLogueada;
                objventa.observacionVenta = "--";

                objventa.guidVenta = guidVenta_frm;
                objventa.abonoTarjeta =0;
                bool sqlNueva = ControladorVenta.Crud(objventa, 0);
                if (sqlNueva == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
        private bool CrearR_VentaUsuario()
        {
            try
            {
                R_VentaUsuario objRVU = new R_VentaUsuario();
                objRVU.id = 0;
                objRVU.idVenta = IdVenta_Frm;
                objRVU.idUsuario = VariablesPublicas.IdUsuarioLogueado;
                objRVU.estado = 1;
                bool sqlR = controladorRVentarUsuario.CrearEditarEliminarR_VentaUsuario(objRVU, 0);
                if (sqlR == true)
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return false;
            }

        }
        private void HallarIDVenta()
        {
            TablaVentas objventas = new TablaVentas();
            objventas = ControladorVenta.ConsultaX_guid(guidVenta_frm);
            if (objventas != null)
            {
                IdVenta_Frm = objventas.id;
            }
        }
        private bool ConsultarVentaActiva()
        {
            try
            {
                R_VentaUsuario objR = new R_VentaUsuario();
                objR = controladorRVentarUsuario.Consultar_IdUsuario_Estado(VariablesPublicas.IdUsuarioLogueado,1);
                if (objR != null)
                {
                    IdVenta_Frm =objR.idVenta;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
        private void frmCajaTouch_Load(object sender, EventArgs e)
        {
            dgListaDetalleCompra.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 16);
            // Ajustar tamaño de columnas y celdas.
            dgListaDetalleCompra.AutoResizeColumns();
            dgListaDetalleCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // para que divida el texto de las celdas en varias líneas
            dgListaDetalleCompra.DefaultCellStyle.WrapMode = DataGridViewTriState.True;


            //consultamos si el usuario tiene una venta activa
            bool activa = ConsultarVentaActiva();
            if (activa == true)
            {
                CargarDG();
                CargarCategorias();             
                CrearBotones();
                CargarCajas();
                txtCodigoBarra.Focus();
            }
            else
            {
                CargarCategorias();
                NuevaCaja();
                CrearBotones();
                txtCodigoBarra.Focus();
            }


            if (VariablesPublicas.FacturarPedido == true)
            {
                txtGuidPedido.Text = VariablesPublicas.giaPedido;
                BuscarPedido();
                Vender();
                this.Close();
            }
        }

        private void CrearBotones()
        {
            //en esta parte configuracmos los botones

            var btnEditarCantidad = new DataGridViewButtonColumn();
            btnEditarCantidad.Name = "btnEditarCantidad";
            btnEditarCantidad.HeaderText = "CANT";
            btnEditarCantidad.Text = "Editar";
            btnEditarCantidad.UseColumnTextForButtonValue = true;
            this.dgListaDetalleCompra.Columns.Add(btnEditarCantidad);

            var btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.Name = "btnEliminar";
            btnEliminar.HeaderText = "DELETE";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            this.dgListaDetalleCompra.Columns.Add(btnEliminar);

            var btnEditarPrecio = new DataGridViewButtonColumn();
            btnEditarPrecio.Name = "btnEditarPrecio";
            btnEditarPrecio.HeaderText = "Editar Precio";
            btnEditarPrecio.Text = "Editar Precio";
            btnEditarPrecio.UseColumnTextForButtonValue = true;
            this.dgListaDetalleCompra.Columns.Add(btnEditarPrecio);

            PosicionDG();

        }
        private void PosicionDG()
        {
            try
            {
                dgListaDetalleCompra.Columns["id"].DisplayIndex = 0;
                dgListaDetalleCompra.Columns["idVenta"].DisplayIndex = 1;
                dgListaDetalleCompra.Columns["idPrecios"].DisplayIndex = 2;
                dgListaDetalleCompra.Columns["idInventario"].DisplayIndex = 3;
                dgListaDetalleCompra.Columns["idSede"].DisplayIndex = 4;
                dgListaDetalleCompra.Columns["descripcionProducto"].DisplayIndex = 5;
                dgListaDetalleCompra.Columns["nombrePresentacion"].DisplayIndex = 6;
                dgListaDetalleCompra.Columns["cantidadDetalle"].DisplayIndex = 7;
                dgListaDetalleCompra.Columns["costoUnidad"].DisplayIndex = 8;
                dgListaDetalleCompra.Columns["costoTotal"].DisplayIndex = 9;
                dgListaDetalleCompra.Columns["precioDetalleVentaV"].DisplayIndex = 10;
                dgListaDetalleCompra.Columns["totalDetalle"].DisplayIndex = 11;
                dgListaDetalleCompra.Columns["porcentageIVA"].DisplayIndex = 12;
                dgListaDetalleCompra.Columns["btnEditarCantidad"].DisplayIndex = 13;
                dgListaDetalleCompra.Columns["btnEditarPrecio"].DisplayIndex = 14;
                dgListaDetalleCompra.Columns["btnEliminar"].DisplayIndex = 15;
                
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }

        }
        private void CargarDG()
        {
            dgListaDetalleCompra.DataSource = ControladorDetalleVenta.ListaDetalleCaja(IdVenta_Frm);
            SumarSubTotal();
            txtCodigoBarra.Text = "";

            this.Text = "Venta # " + IdVenta_Frm;
        }
        private void SumarSubTotal()
        {
            SubTotal_frm = ControladorDetalleVenta.SumarTotalVenta(IdVenta_Frm);
            costoTotalVenta_frm= ControladorDetalleVenta.SumarTotalCosto(IdVenta_Frm);
            valorIvaTotalVenta_frm= ControladorDetalleVenta.SumarTotalIVA(IdVenta_Frm);

            txtSubTotal.Text = "$ " + string.Format("{0:#,##0.##}", Convert.ToDouble(SubTotal_frm));
        }
        private void CargarCategorias()
        {
            try
            {
                //lo primero es contar cuantas categorias hay
                DataTable objCP = new DataTable();
                objCP = ConotroladorCategoria.Lista();

                if (objCP == null) return;

                if (VariablesPublicas.TipoCajaRegistradora == 1)
                {
                    foreach (DataRow row in objCP.Rows)
                    {
                        Panel panel = new Panel();
                        string nombrePanel = "panelid" + Convert.ToString(Convert.ToString(row["id"]));
                        panel.Name = nombrePanel;
                        panel.Width = Convert.ToInt16(130);
                        panel.Height = Convert.ToInt16(140);
                        flPanel.Controls.Add(panel);

                        Button button = new Button();
                        button.Text = Convert.ToString(Convert.ToString(row["id"]));
                        button.Width = Convert.ToInt16(130);
                        button.Height = Convert.ToInt16(118);
                        button.BackgroundImage = TraerImagen(Convert.ToString(row["guidCategoria"]), "Categorias");
                        button.BackColor = Color.Transparent;
                        button.BackgroundImageLayout = ImageLayout.Stretch;
                        button.ForeColor = Color.Transparent;
                        button.Font = new Font("French Script MT", 1);

                        button.Click += Button_Click;

                        panel.Controls.Add(button);

                        Label label = new Label();
                        label.Text = Convert.ToString(row["nombreCategoria"]);
                        label.Dock = DockStyle.Bottom;
                        label.AutoSize = false;
                        label.TextAlign = ContentAlignment.MiddleCenter;
                        label.Font = new Font(label.Font, FontStyle.Bold);

                        panel.Controls.Add(label);

                    
                    }
                    cboCategoria.Enabled = false;
                }
                else
                {
                    cboCategoria.ValueMember = "id";
                    cboCategoria.DisplayMember = "nombreCategoria";
                    cboCategoria.DataSource = objCP;
                    cboCategoria.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                string Error = ex.Message;
            }
        }
        private void CargarProductos(int idCategoria_frm)
        {
            try
            {
                //lo primero es contar cuantas categorias hay
                DataTable objCP = new DataTable();
                objCP = ControladorProducto.Lista(idCategoria_frm);

                if (objCP == null) return;

                flPanel.Controls.Clear();

                foreach (DataRow row in objCP.Rows)
                {
                    Panel panel = new Panel();
                    string nombrePanel = "panelid" + Convert.ToString(Convert.ToString(row["id"]));
                    panel.Name = nombrePanel;
                    panel.Width = Convert.ToInt16(130);
                    panel.Height = Convert.ToInt16(160);
                    flPanel.Controls.Add(panel);

                    Button button = new Button();
                    button.Text = Convert.ToString(Convert.ToString(row["id"]));
                    button.Width = Convert.ToInt16(130);
                    button.Height = Convert.ToInt16(118);
                    button.BackgroundImage = TraerImagen(Convert.ToString(row["guidProducto"]), "Productos");
                    button.BackColor = Color.Transparent;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.ForeColor = Color.Transparent;
                    button.Font = new Font("French Script MT", 1);

                    button.Click += ButtonProducto_Click;

                    panel.Controls.Add(button);

                    Label label = new Label();
                    label.Text = Convert.ToString(row["descripcionProducto"]);
                    label.Dock = DockStyle.Bottom;
                    label.AutoSize = false;
                    label.Height = Convert.ToInt16(42);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Font = new Font(label.Font, FontStyle.Bold);

                    panel.Controls.Add(label);
                }
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
            }
        }
        private void ButtonProducto_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackgroundImage != null)
            {
                BuscarProducto_id(Convert.ToInt32(btn.Text));
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackgroundImage != null)
            {
                LLamarCategoria(Convert.ToInt32(btn.Text));
            }
        }
        private static Image TraerImagen(string IDCate,string Carpeta)
        {
            try
            {
                return ClassRuta.CargarProductoCategoria(VariablesPublicas.RutaImagenes, "\\"+Carpeta+"\\", IDCate + ".png");
            }
            catch(Exception ex)
            {
                 return POS_SERINSIS_PC_2022.Properties.Resources.Producto1;
            }
        }
        private void LLamarCategoria(int IDCategoria)
        {
            if (txtCodigoBarra.Text == "")
            {
                frmProductosXCategoria frm = new Ventas.frmProductosXCategoria();
                AddOwnedForm(frm);
                frm.dgProductosXCategoria.DataSource = ControladorProducto.FiltrarX_IdCategoria_IdSede_IdEstado(IDCategoria, VariablesPublicas.IdEmpresaLogueada,1);
                frm.ShowDialog();
                txtCodigoBarra.Focus();
            }
        }
        private void frmCajaTouch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtCodigoBarra.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {
                frmProductosXCategoria frm = new Ventas.frmProductosXCategoria();
                AddOwnedForm(frm);
                frm.dgProductosXCategoria.DataSource = ControladorProducto.FiltrarX_IdSede_IdEstado( VariablesPublicas.IdEmpresaLogueada, 1);
                frm.ShowDialog();
                txtCodigoBarra.Focus();
            }
            if (e.KeyCode == Keys.F11)
            {
                NuevaCaja();
            }
            if (e.KeyCode == Keys.F12)
            {
                Vender();
            }
        }
        public decimal CantidadGramos = 0;
        public void BuscarCodigo()
        {
            //procedemos a buscar el codigo
            List<v_productoVenta> objLista = new List<v_productoVenta>();
            objLista = ControladorProducto.FiltroVentaProducto(txtCodigoBarra.Text, 1,VariablesPublicas.IdEmpresaLogueada);
            if (objLista != null)
            {
                if (objLista.Count > 1)
                {
                    frmProductosXCategoria frm = new Ventas.frmProductosXCategoria();
                    AddOwnedForm(frm);
                    frm.dgProductosXCategoria.DataSource = ControladorProducto.FiltroVentaProducto_codigo(txtCodigoBarra.Text, VariablesPublicas.IdEmpresaLogueada,0);
                    frm.ShowDialog();
                    txtCodigoBarra.Focus();
                }
                else if (objLista.Count == 1)
                {
                    v_productoVenta objPro = new v_productoVenta();
                    objPro = objLista.Where(x => x.codigoProducto == txtCodigoBarra.Text).FirstOrDefault();
                    if (objPro != null)
                    {
                        BuscarProducto_id(objPro.id);
                    }
                }
            }
        }
        public void BuscarProducto_id(int idProducto_frm)
        {
            //procedemos a buscar el codigo
            v_productoVenta objLista = new v_productoVenta();
            objLista = ControladorProducto.Consultar_Id(idProducto_frm);
            if (objLista != null)
            {
                if (VariablesPublicas.VentasEnNegativo == 0)
                {
                    if (objLista.estadoInventario == "agotado")
                    {
                        if (objLista.inventarioActual <= 0)
                        {
                            MessageBox.Show("El producto esta agotado", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("El producto esta por debajo del stock." + Environment.NewLine +
                                Environment.NewLine +
                                "La cantidad actual es " + objLista.inventarioActual, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                //en esta parte agregamos la cantidad en kg
                if (objLista.idTipoMedida > 1)
                {
                    if (VariablesPublicas.Gramera == true)
                    {
                        frm_prueba_balanza frm_balanza = new frm_prueba_balanza();
                        AddOwnedForm(frm_balanza);
                        frm_balanza.precioUnidad =Convert.ToDecimal(objLista.PrecioVenta);
                        frm_balanza.ShowDialog();
                    }
                    else
                    {
                        frmEditarCantidad frm_cantidad = new frmEditarCantidad();
                        AddOwnedForm(frm_cantidad);
                        frm_cantidad.frmPadre = "caja";
                        frm_cantidad.ShowDialog();
                    }
                }
                else
                {
                    VariablesPublicas.cantidadKilogramo = 1;
                }


                AgregarDetalleVenta(Convert.ToInt32(objLista.idPrecios), objLista.descripcionProducto, VariablesPublicas.cantidadKilogramo, Convert.ToDecimal(objLista.costoUnidadIT), Convert.ToDecimal(objLista.PrecioVenta), Convert.ToDecimal(objLista.porcentajeIVAIT), Convert.ToInt32(objLista.idInventario), Convert.ToDecimal(objLista.contenidoPresentacion), Convert.ToInt32(objLista.idInventarioTotal), Convert.ToDecimal(objLista.porcentajeIVAIT),
                    Convert.ToInt32(objLista.gramera));

               // MessageBox.Show("Agregado correctamente");

            }
        }
        private void txtCodigoBarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCodigoBarra.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {

                    BuscarCodigo();
                }
            }
        }
        public bool AgregarDetalleVenta(int IdPrecios,string descripcion,decimal cantidad,decimal costo,decimal precio,decimal Iva,int IdInventario,decimal contenido,int IdInventarioTotal,decimal IVA,int Gramera)
        {
            try
            {
                if (Gramera == 1)
                {
                    frmEditarCantidad frm = new frmEditarCantidad();
                    AddOwnedForm(frm);
                    frm.RegistoAutomatico = true;
                    frm.ShowDialog();
                    cantidad = CantidadGramos;
                }


               costo = costo * contenido;
                DetalleVenta objDetalle = new DetalleVenta();
                objDetalle.id = 0;
                objDetalle.idVenta = IdVenta_Frm;
                objDetalle.idPrecios = IdPrecios;
                objDetalle.idInventario = IdInventario;
                objDetalle.idSede = VariablesPublicas.IdEmpresaLogueada;
                objDetalle.descripcionProducto = descripcion;
                objDetalle.cantidadDetalle = cantidad;
                objDetalle.costoUnidad = costo;
                objDetalle.precioVenta = precio;
                objDetalle.idInventarioTotal = IdInventarioTotal;
                objDetalle.porcentageIVA = IVA;
                bool sqlDetalle = ControladorDetalleVenta.GuardarEditarEliminar(objDetalle, 0);
                if (sqlDetalle == false)
                {
                    return false;
                }
                else
                {
                    CargarDG();
                    PosicionDG();
                    return true;
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return false;
            }

        }
        private void SeleccionarDetalle()
        {
            if (dgListaDetalleCompra.RowCount > 0 && dgListaDetalleCompra.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgListaDetalleCompra.Rows[dgListaDetalleCompra.CurrentRow.Index];

                IdDetalle_frm = Convert.ToInt32(fila.Cells["id"].Value);
                IdInevntario_frm = Convert.ToInt32(fila.Cells["idInventario"].Value);
                cantidad_frm = Convert.ToDecimal(fila.Cells["cantidadDetalle"].Value);
                idInventarioTotal_frm= Convert.ToInt32(fila.Cells["idInventarioTotal"].Value);
                contenidoPresentacion_frm= Convert.ToDecimal(fila.Cells["contenidoPresentacion"].Value);
            }
        }
        private void dgListaDetalleCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarDetalle();
            if (dgListaDetalleCompra.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                EliminarDetalle(IdDetalle_frm);
                PosicionDG();
            }

            if (dgListaDetalleCompra.Columns[e.ColumnIndex].Name == "btnEditarCantidad")
            {
                //llamamos el formulario para editar la cantidad
                frmEditarCantidad frm = new frmEditarCantidad();
                AddOwnedForm(frm);
                frm.ShowDialog();

                EditarCantidadDetalle(IdDetalle_frm,VariablesPublicas.cantidadKilogramo);

                CargarDG();
                PosicionDG();
            }

            if (dgListaDetalleCompra.Columns[e.ColumnIndex].Name == "btnEditarPrecio")
            {
                if (VariablesPublicas.EditarPrecioVentaProducto == 1)
                {
                    //llamamos el formulario para editar la cantidad
                    frmEditarPrecion frm = new frmEditarPrecion();
                    AddOwnedForm(frm);
                    frm.IdDetalle_frm = IdDetalle_frm;
                    frm.Cantidad_frm = cantidad_frm;
                    frm.ShowDialog();
                    CargarDG();
                    PosicionDG();
                }
                else
                {
                    MessageBox.Show("¡Su usuario no está autorizado para editar el valor de los productos…!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void EliminarDetalle(int IdDetalle)
        {
            DetalleVenta objdetalle = new DetalleVenta();
            objdetalle = ControladorDetalleVenta.ConsultarX_IDDetalle(IdDetalle);
            if (objdetalle != null)
            {
                bool sql = ControladorDetalleVenta.GuardarEditarEliminar(objdetalle,2);
                if (sql == true)
                {
                    CargarDG();
                }
            }
        }
        public void EditarCantidadDetalle(int IdDetalle,decimal cantidad)
        {
            DetalleVenta objdetalle = new DetalleVenta();
            objdetalle = ControladorDetalleVenta.ConsultarX_IDDetalle(IdDetalle);
            if (objdetalle != null)
            {
                v_productoVenta venta = new v_productoVenta();
                venta = ControladorProducto.Consultar_IdInventario_IdSede(IdInevntario_frm,VariablesPublicas.IdEmpresaLogueada);
                if (venta != null)
                {
                    if (venta.inventarioActual/contenidoPresentacion_frm >= cantidad)
                    {
                        objdetalle.cantidadDetalle = cantidad;
                        bool sql = ControladorDetalleVenta.GuardarEditarEliminar(objdetalle, 1);
                    }
                    else
                    {
                        if (VariablesPublicas.VentasEnNegativo == 1)
                        {
                            objdetalle.cantidadDetalle = cantidad;
                            bool sql = ControladorDetalleVenta.GuardarEditarEliminar(objdetalle, 1);
                        }
                        else
                        {
                            int cant = Convert.ToInt32(venta.inventarioActual) / Convert.ToInt32(contenidoPresentacion_frm);
                            MessageBox.Show("¡La cantidad requerida no esta disponible..!" + Environment.NewLine +
                                "la cantidad disponible es " + cant, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
        }
        private void btnNuevaCaja_Click(object sender, EventArgs e)
        {
            NuevaCaja();
        }
        private void NuevaCaja()
        {
            //generamos el guid de la venta a usar
            CrearGuid();
            //creamos un nuevo registro en la table ventas con el guid generado
            bool nuevo = NuevaVenta();
            if (nuevo == false)
            {
                return;
            }
            //hallamos el idde la venta
            HallarIDVenta();
            //ahora creamos la relacion de la venta con el cajero
            bool relacion = CrearR_VentaUsuario();
            if (relacion == false)
            {
                return;
            }
            CargarDG();
            CargarCajas();
            PosicionDG();
            txtCodigoBarra.Focus();
        }
        private void CargarCajas()
        {
            try
            {
                flPanelCajas.Controls.Clear();

                //lo primero es contar cuantas categorias hay
                DataTable objCP = new DataTable();
                objCP = controladorRVentarUsuario.Lista(VariablesPublicas.IdUsuarioLogueado, 1);

                if (objCP == null) return;

                foreach (DataRow row in objCP.Rows)
                {
                    Panel panel = new Panel();
                    string nombrePanel = "panelCajas" + Convert.ToString(Convert.ToString(row["id"]));
                    panel.Name = nombrePanel;
                    panel.Width = Convert.ToInt16(60);
                    panel.Height = Convert.ToInt16(58);
                    flPanelCajas.Controls.Add(panel);

                    Label labelCaja = new Label();
                    //label.Text = Convert.ToString(row["nombreCategoria"]);
                    labelCaja.Text = "Cuenta #";
                    labelCaja.Dock = DockStyle.Top;
                    labelCaja.AutoSize = false;
                    labelCaja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    labelCaja.Font = new Font(labelCaja.Font, FontStyle.Bold);

                    panel.Controls.Add(labelCaja);

                    Button buttonCajas = new Button();
                    buttonCajas.Text = Convert.ToString(Convert.ToString(row["idVenta"]));
                    //buttonCajas.Width = Convert.ToInt16(60);
                    buttonCajas.Height = Convert.ToInt16(35);
                    buttonCajas.Dock = DockStyle.Bottom;
                    //button.BackgroundImage = TraerImagen(Convert.ToString(row["guidCategoria"]));
                    buttonCajas.BackColor = Color.Transparent;
                    buttonCajas.BackgroundImageLayout = ImageLayout.Stretch;
                    buttonCajas.ForeColor = Color.Black;
                    buttonCajas.Font = new Font("French Script MT", 14);

                    buttonCajas.Click += ButtonCajas_Click;

                    panel.Controls.Add(buttonCajas);


                }
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
            }
        }
        private void ButtonCajas_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text != "")
            {
                IdVenta_Frm = Convert.ToInt32(btn.Text);
                CargarDG();
                PosicionDG();
                txtCodigoBarra.Focus();
            }
        }
        private void Vender()
        {
            //if (MessageBox.Show("¿Desea agregar una observación a la venta?", "¡Obserbacion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //{
            //    frmObservacionFactura frmO = new frmObservacionFactura();
            //    AddOwnedForm(frmO);
            //    frmO.ShowDialog();
            //    VariablesPublicas.IdCliente = 0;
            //}
            //else
            //{
            //    VariablesPublicas.ObservacionFactura = "--";
            //}
            VariablesPublicas.ObservacionFactura = "...";
            frmCobroCaja frm = new frmCobroCaja();
            AddOwnedForm(frm);
            frm.SubTotal = SubTotal_frm;
            frm.cbContado.Checked = true;
            frm.IdVenta_frm = IdVenta_Frm;
            frm.costoTotalVenta_frm = costoTotalVenta_frm;
            frm.ShowDialog();


            //consultamos si el usuario tiene una venta activa
            bool activa = ConsultarVentaActiva();
            if (activa == true)
            {
                CargarDG();
                CargarCajas();
                PosicionDG();
                txtCodigoBarra.Focus();
                return;
            }
            NuevaCaja();

        }
        private void btnVender_Click(object sender, EventArgs e)
        {
            Vender();
        }
        private void BuscarPedido()
        {
            //lo primero que devemos hacer es crear la relacion entre el id de la venta con el guid del pedido
            //para eso consultamos el id de la venta y guid del pedido en la table de V_Pedidos
            V_Pedido v_Pedido = new V_Pedido();
            v_Pedido = controladorPedidoVenta.Consultar_giaPedido(txtGuidPedido.Text);
            if (v_Pedido != null)
            {
                VariablesPublicas.IdCliente = v_Pedido.idCliente;

                VariablesPublicas.GuidPedido = v_Pedido.guidPedido;
                VariablesPublicas.giaPedido = v_Pedido.guiaPedido;

                R_PedidoVenta r_Pedido = new R_PedidoVenta();
                r_Pedido = controladorPedidoVenta.Consultar_IdVenta(IdVenta_Frm);
                if (r_Pedido == null)
                {
                    //abtes de crear la relacion verificamos que el guid del pedido tambien este libre
                    R_PedidoVenta pedidoVenta=new R_PedidoVenta();
                    pedidoVenta = controladorR_PedidoVenta.Consultar_GuidPedido(v_Pedido.guidPedido);
                    if (pedidoVenta == null)
                    {
                        r_Pedido = new R_PedidoVenta();
                        r_Pedido.id = 0;
                        r_Pedido.idVenta = IdVenta_Frm;
                        r_Pedido.guidPedido = v_Pedido.guidPedido;
                        bool crud = controladorR_PedidoVenta.Crud(r_Pedido, 0);
                        if (crud == true)
                        {
                            bool cargar = CargarDetallePedido();
                            if (cargar == true)
                            {
                                //MessageBox.Show("¡Pedido Cargado correctamente...!", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                CargarDG();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("¡El pedido con la guía " + v_Pedido.guiaPedido + " ya se encuentra facturado....!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (r_Pedido.guidPedido == v_Pedido.guidPedido)
                    {
                        try
                        {
                            using (SistemaPOSEntities cn = new SistemaPOSEntities())
                            {
                                cn.EliminarDetalleVEnta(IdVenta_Frm);
                            }
                        }
                        catch (Exception ex)
                        {
                            string error = ex.Message;
                        }
                        bool cargar = CargarDetallePedido();
                        if (cargar == true)
                        {
                            //MessageBox.Show("¡Pedido Cargado correctamente...!", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            CargarDG();
                        }
                    }
                    else
                    {
                        MessageBox.Show("¡Para caragar el pedido debe de crear una nueva caja...!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            BuscarCodigo();
        }

        private bool CargarDetallePedido()
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    cn.FacturarPedido(IdVenta_Frm, VariablesPublicas.GuidPedido);
                }
                return true;
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return false;
            }

        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoria.Text != "")
            {
                CargarProductos(Convert.ToInt32(cboCategoria.SelectedValue));
            }
        }

        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

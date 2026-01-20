using DAL;
using DAL.Controlador;
using DAL.Controladores;
using DAL.Modelo;
using DAL.SQL;
using Invenpol_Parqueadero_Motos.Clases;
using Invenpol_Parqueadero_Motos.Procesos;
using Newtonsoft.Json;
using POS_SERINSIS_PC_2022.Formularios;
using POS_SERINSIS_PC_2022.Formularios.Ventas;
using POS_SERINSIS_PC_2022.Reportes;
using SERINSI_PC.Clases.TiketPOS;
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
    public partial class frm_pedidos : Form
    {
        List<V_Pedido> FiltroPedidos =new List<V_Pedido>();
        public frm_pedidos()
        {
            InitializeComponent();
        }

        private async void frm_pedidos_Load(object sender, EventArgs e)
        {
            //Cargar_dgPedidos(1);
            await CargarEstado();
            await Cargar_cbVendedor();
            txtPedidosPendientes.Text = "0";
            btnAlistamiento.Enabled = false;
        }
        private async Task Cargar_cbVendedor()
        {
            cbVendedor.ValueMember = "id";
            cbVendedor.DisplayMember = "nombreVendedor";
            cbVendedor.DataSource =await controladorVendedor.Lista_Completa();
            cbVendedor.SelectedIndex = -1;
        }
        private async Task Cargar_dgPedidos(int estado,int idVendedor_frm,DateTime fecha)
        {
            FiltroPedidos=await controladorPedidos.Filtrar_estado(estado, idVendedor_frm, fecha);
            dgPedidos.DataSource = FiltroPedidos;
        }
        private async Task CargarEstado()
        {
            cbEstado.ValueMember = "id";
            cbEstado.DisplayMember = "nombreEstadoPedido";
            cbEstado.DataSource =await controladorEstadoPedido.ListaCompleta();
            cbEstado.SelectedIndex = 0;
        }

        private async void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEstado.Text != "")
            {
                await Cargar_dgPedidos(1,Convert.ToInt32(cbEstado.SelectedValue),dtDia.Value) ;
            }
        }

        private void txtBuscarGuia_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBuscarGuia.Text != "")
            {
                dgPedidos.DataSource = controladorPedidos.Filtrar_guia(txtBuscarGuia.Text);
            }
        }
        Guid GuidPedido;
        string GuiaPedido = "";
        private void SeleccionarPedido()
        {
            if (dgPedidos.RowCount > 0 && dgPedidos.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgPedidos.Rows[dgPedidos.CurrentRow.Index];
                string guid=Convert.ToString(fila.Cells["guidPedido"].Value);
                GuidPedido = Guid.Parse(guid);
                GuiaPedido = Convert.ToString(fila.Cells["guiaPedido"].Value);
                VariablesPublicas.IdCliente= Convert.ToInt32(fila.Cells["idCliente"].Value);
                VariablesPublicas.nombreVendedor = Convert.ToString(fila.Cells["nombreVendedor"].Value);
            }
        }
        private async void btnVerDetalle_Click(object sender, EventArgs e)
        {
            SeleccionarPedido();
            frmListaDetallePedido frm = new frmListaDetallePedido();
            AddOwnedForm(frm);
            frm.dgDetallePedido.DataSource =await controladorDetallePedido.Filtrar_guiPedido(GuidPedido);
            frm.ShowDialog();
        }

        private async void btnFacturar_Click(object sender, EventArgs e)
        {
            int contador = 0;

            FrmLoading loading = null;
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    loading = FrmLoading.ShowLoading(this, "Cargarndo...");
                    // inicio


                    var pedidosSeleccionados = new List<V_Pedido>();
                    foreach (DataGridViewRow row in dgPedidos.SelectedRows)
                    {
                        if (row.IsNewRow) continue;

                        if (row.DataBoundItem is V_Pedido pedido)
                        {
                            pedidosSeleccionados.Add(pedido);
                        }
                    }

                    if (pedidosSeleccionados.Count == 0)
                    {
                        MessageBox.Show("No se han seleccionado pedidos para facturar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                  
                    foreach (var obj in pedidosSeleccionados)
                    {
                        contador++;
                        await Facturar(obj.idCliente, obj.guidPedido, obj.guiaPedido, obj.nombreVendedor);
                    }

                    // fin
                    FrmLoading.CloseLoading(this, loading);
                }
            }
            catch (Exception ex)
            {
                FrmLoading.CloseLoading(this, loading);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                FrmLoading.CloseLoading(this, loading);
                MessageBox.Show($"se facturaron {contador} pedidos con éxito.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnFiltrar.PerformClick();
            }

        }
        private async Task<bool> Facturar(int idcliente,Guid guidPedido,string guiaPedido,string nombreVendedor)
        {
           
            IdCliente = idcliente;
            VariablesPublicas.IdCliente = idcliente;
            VariablesPublicas.GuidPedido = guidPedido;
            VariablesPublicas.giaPedido = guiaPedido;
            GuidPedido = guidPedido;
            GuiaPedido = guiaPedido;

            /* lo primero es verificar si el gud del pedido tiene relacion con alguventa */
            R_PedidoVenta pedidoVenta = new R_PedidoVenta();
            pedidoVenta = await controladorR_PedidoVenta.Consultar_GuidPedido(guidPedido);
            if (pedidoVenta != null)
            {
                /* aca hallamos que el pevido ya tiene una relacion con el id de una venta 
                 ahora verificamos si esa venta existe */
                TablaVentas tablaVentas = new TablaVentas();
                tablaVentas =await ControladorVenta.ConsultaX_id(pedidoVenta.idVenta);
                if (tablaVentas != null)
                {
                    guidVenta_frm = tablaVentas.guidVenta;
                    IdVenta_Frm = tablaVentas.id;

                    try
                    {
                        var query = $"exec EliminarDetalleVEnta {IdVenta_Frm}";
                        var respuesta= await Conection_SQL.ConsultaSQLServer(query,false,true);
                        if (respuesta != null)
                        {
                            var respuestasql = JsonConvert.DeserializeObject<RespuestaCRUD>(respuesta);
                        }
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                    }
                    await CargarDetallePedido();

                    if (tablaVentas.numeroVenta > 0)
                    {
                        int boton_ventaCliente;
                        int idr;
                        /* verificamos si la venta tiene ralacion con el cleinte del pedido */
                        R_VentaCliente ventaCliente = new R_VentaCliente();
                        ventaCliente =await controladorRVentaCleinte.ConsultarRelacion(pedidoVenta.idVenta);
                        if (ventaCliente != null)
                        {
                            idr = ventaCliente.id;
                            boton_ventaCliente = 1;
                        }
                        else
                        {
                            ventaCliente = new R_VentaCliente();
                            boton_ventaCliente = 0;
                            idr = 0;
                        }
                        ventaCliente.id = idr;
                        ventaCliente.idVenta = pedidoVenta.idVenta;
                        ventaCliente.idCliente = idcliente;
                        ventaCliente.idSede = VariablesPublicas.IdEmpresaLogueada;
                        RespuestaCRUD respuestaCRUD = await controladorRVentaCleinte.Crud(ventaCliente, boton_ventaCliente);
                        if (respuestaCRUD.estado)
                        {
                            /* en esta parte cambiemos el estado del pedido */
                            Pedidos pedidos = new Pedidos();
                            pedidos = await controladorPedidos.Consultar_guid(guidPedido);
                            if (pedidos != null)
                            {
                                pedidos.idEstadoPedido = 2;
                                var resosql = await controladorPedidos.Crud(pedidos, 1);
                                if (resosql.estado == false)
                                {
                                    return false;
                                }
                                else
                                {
                                    VariablesPublicas.nombreVendedor = nombreVendedor;
                                    return await ClassImprimirDirecto.FacturaVentaCarta(2, IdVenta_Frm);
                                }
                            }
                        }
                    }
                    else
                    {
                        Vender();
                        if (await Guardar())
                        {
                            /* en esta parte cambiemos el estado del pedido */
                            Pedidos pedidos = new Pedidos();
                            pedidos = await controladorPedidos.Consultar_guid(guidPedido);
                            if (pedidos != null)
                            {
                                pedidos.idEstadoPedido = 2;
                                var resosql = await controladorPedidos.Crud(pedidos, 1);
                                if (resosql.estado == false)
                                {
                                    return false;
                                }
                                else
                                {
                                    VariablesPublicas.nombreVendedor = nombreVendedor;
                                    return await ClassImprimirDirecto.FacturaVentaCarta(2, IdVenta_Frm);
                                }
                            }
                        }
                    }
                }
            }
            else
            {

                CrearGuid();
                //creamos un nuevo registro en la table ventas con el guid generado
                bool nuevo = await NuevaVenta();
                if (nuevo == true)
                {
                    await HallarIDVenta();
                    await BuscarPedido();

                    int boton_ventaCliente;
                    int idr;
                    /* verificamos si la venta tiene ralacion con el cleinte del pedido */
                    R_VentaCliente ventaCliente = new R_VentaCliente();
                    ventaCliente =await controladorRVentaCleinte.ConsultarRelacion(IdVenta_Frm);
                    if (ventaCliente != null)
                    {
                        idr = ventaCliente.id;
                        boton_ventaCliente = 1;
                    }
                    else
                    {
                        ventaCliente = new R_VentaCliente();
                        boton_ventaCliente = 0;
                        idr = 0;
                    }
                    ventaCliente.id = idr;
                    ventaCliente.idVenta = IdVenta_Frm;
                    ventaCliente.idCliente = idcliente;
                    ventaCliente.idSede = VariablesPublicas.IdEmpresaLogueada;
                    RespuestaCRUD respuestaCRUD = await controladorRVentaCleinte.Crud(ventaCliente, boton_ventaCliente);
                    if (respuestaCRUD.estado)
                    {
                        /* en esta parte enviamos a imprimir la factura */
                        VariablesPublicas.nombreVendedor = nombreVendedor;
                    }


                    Vender();
                    if (await Guardar())
                    {
                        Pedidos pedidos = new Pedidos();
                        pedidos =await controladorPedidos.Consultar_guid(guidPedido);
                        if (pedidos != null)
                        {
                            pedidos.idEstadoPedido = 2;
                            var resosql= await controladorPedidos.Crud(pedidos, 1);
                            if(resosql.estado == false)
                            {
                                return false;
                            }
                            else
                            {
                                VariablesPublicas.nombreVendedor = nombreVendedor;
                                return await ClassImprimirDirecto.FacturaVentaCarta(2, IdVenta_Frm);
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                   return false;
                }
            }
            return true;
        }
        private async Task<bool> Guardar()
        {
            if (IdCliente != 0)
            {
                int Boton;
                int IdRelacion;
                //en esta parte creamos la relacion de venta cliente
                R_VentaCliente objRVC = new R_VentaCliente();
                objRVC =await controladorRVentaCleinte.ConsultarRelacion(IdVenta_Frm);
                if (objRVC != null)
                {
                    Boton = 1;
                    IdRelacion = objRVC.id;
                }
                else
                {
                    Boton = 0;
                    IdRelacion = 0;
                }
                //ahora creamos la relacion
                objRVC = new R_VentaCliente();
                objRVC.id = IdRelacion;
                objRVC.idVenta = IdVenta_Frm;
                objRVC.idCliente = IdCliente;
                objRVC.idSede = VariablesPublicas.IdEmpresaLogueada;
                RespuestaCRUD sqlRelacion =await controladorRVentaCleinte.Crud(objRVC, Boton);
            }

            //en esta parte hallamos el consecutivo de recivo
            NumeroFacturaRecibo =await HallarConsecutivoRecibo();
            if (NumeroFacturaRecibo == 0)
            {
                NumeroFacturaRecibo =await HallarConsecutivoRecibo();
            }
            //creamos un objeto para la tabla venta
            TablaVentas objVenta = new TablaVentas();
            objVenta =await ControladorVenta.ConsultaX_id(IdVenta_Frm);
            if (objVenta != null)
            {
                objVenta.fechaVenta = DateTime.Now;
                objVenta.tipoFactura = "RECIBO";
                objVenta.numeroVenta = NumeroFacturaRecibo;
                objVenta.descuentoVenta = Descuento;
                objVenta.ivaVenta = 0;
                objVenta.efectivoVenta = Efectivo;
                objVenta.cambioVenta = Cambio;
                objVenta.tipoVenta = "CONTADO";
                objVenta.estadoVenta = "CANCELADO";
                objVenta.tipoPago = "EFECTIVO";
                objVenta.numeroReferenciaPago = "0";
                objVenta.idBaseCaja = VariablesPublicas.IdBaseActiva;
                objVenta.diasCredito = 0;
                objVenta.fechaVencimiento = Convert.ToDateTime(objVenta.fechaVenta).AddDays(30).ToShortDateString();
                objVenta.observacionVenta = VariablesPublicas.ObservacionFactura;
                objVenta.IdSede = VariablesPublicas.IdEmpresaLogueada;    
                objVenta.abonoTarjeta = 0;
                //enbiamos el objeto al controlador
                bool Respuesta =await ControladorVenta.Crud(objVenta, 1);
                if (Respuesta == true)
                {
                    if (!await FinalizarVenta())
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        private async Task<int> HallarConsecutivoRecibo()
        {
            //en esta parte hallamos el consecutivo de recivo
            ConsecutivoRecibo consecutivoRecibo = new ConsecutivoRecibo();
            consecutivoRecibo =await controladorNumeracionRecibo.Consultar_x_IdVenta(IdVenta_Frm);
            if (consecutivoRecibo != null)
            {
                return consecutivoRecibo.id;
            }
            else
            {
                consecutivoRecibo = new ConsecutivoRecibo();
                consecutivoRecibo.id = 0;
                consecutivoRecibo.idVenta = IdVenta_Frm;
                RespuestaCRUD crud =await controladorNumeracionRecibo.crud(consecutivoRecibo, 0);
                if (crud.estado == true)
                {
                    return 0;
                }
                return 0;
            }
        }
        private async Task<bool> FinalizarVenta()
        {
            try
            {
                //cambiamos el estado de la relacion venta usuario
                R_VentaUsuario objRVU = new R_VentaUsuario();
                objRVU =await controladorRVentarUsuario.Consultar_IdUsuario_IdVenta(VariablesPublicas.IdUsuarioLogueado, IdVenta_Frm, 1);
                if (objRVU != null)
                {
                    objRVU.estado = 0;
                    RespuestaCRUD sqlRVU =await controladorRVentarUsuario.CrearEditarEliminarR_VentaUsuario(objRVU, 1);
                    return true;
                }
                else
                {
                    objRVU = new R_VentaUsuario { id = 0, estado = 0, idUsuario = VariablesPublicas.IdUsuarioLogueado, idVenta = IdVenta_Frm };
                    RespuestaCRUD sqlRVU = await controladorRVentarUsuario.CrearEditarEliminarR_VentaUsuario(objRVU, 0);
                    return true;
                }
            }
            catch(Exception e)
            {
                string error=e.Message;
                return false;
            }
        }
        DateTime Fecha;
        string FacturaRecibo;
        string ContadoCreditoDomicilio;
        int NumeroFacturaRecibo;
        int SubTotal;
        int Descuento;
        int Total;
        string EfectivoTargeta;
        int Efectivo;
        int Cambio;
        int IdCliente;
        string NombreCliente;
        string IdentificacionCliente;
        string TelefonoCliente;
        string DireccionCliente;
        private async Task SeleccionarVenta(int Consecutivo)
        {
            V_TablaVentas objTV = new V_TablaVentas();
            objTV =await ControladorVenta.ConsultaX_V_id(IdVenta_Frm);
            if (objTV != null)
            {

                IdVenta_Frm = objTV.id;
                Fecha = Convert.ToDateTime(objTV.fechaVenta);
                FacturaRecibo = objTV.tipoFactura;
                ContadoCreditoDomicilio = objTV.tipoVenta;
                NumeroFacturaRecibo = Convert.ToInt32(objTV.numeroVenta);
                SubTotal = Convert.ToInt32(objTV.subtotalVenta);
                Descuento = Convert.ToInt32(objTV.descuentoVenta);
                Total = Convert.ToInt32(objTV.totalVenta);
                EfectivoTargeta = objTV.tipoPago;
                Efectivo = Convert.ToInt32(objTV.efectivoVenta);
                Cambio = Convert.ToInt32(objTV.cambioVenta);

                if (ContadoCreditoDomicilio != "CONTADO" || FacturaRecibo == "FACTURA")
                {
                    R_VentaCliente objRVC = new R_VentaCliente();
                    objRVC =await controladorRVentaCleinte.ConsultarRelacion(IdVenta_Frm);
                    if (objRVC != null)
                    {
                        IdCliente = objRVC.idCliente;
                    }

                    Clientes objCliente = new Clientes();
                    objCliente =await ControladorClienteTienda.ConsultarX_ID(IdCliente);
                    if (objCliente != null)
                    {
                        NombreCliente = objCliente.nombreCliente;
                        IdentificacionCliente = objCliente.documentoCliente;
                        TelefonoCliente = objCliente.telefonoCliente;
                        DireccionCliente = objCliente.direccionCliente;
                    }
                }
            }
        }
        private void Vender()
        {
            VariablesPublicas.ObservacionFactura = "...";
        }
        private async Task NuevaCaja()
        {
            //generamos el guid de la venta a usar
            CrearGuid();
            //creamos un nuevo registro en la table ventas con el guid generado
            bool nuevo = await NuevaVenta();
            if (nuevo == false)
            {
                return;
            }
            //hallamos el idde la venta
            HallarIDVenta();
            //ahora creamos la relacion de la venta con el cajero
            bool relacion =await CrearR_VentaUsuario();
            if (relacion == false)
            {
                return;
            }
        }
        private async Task<bool> CrearR_VentaUsuario()
        {
            try
            {
                R_VentaUsuario objRVU = new R_VentaUsuario();
                objRVU.id = 0;
                objRVU.idVenta = IdVenta_Frm;
                objRVU.idUsuario = VariablesPublicas.IdUsuarioLogueado;
                objRVU.estado = 1;
                RespuestaCRUD sqlR =await controladorRVentarUsuario.CrearEditarEliminarR_VentaUsuario(objRVU, 0);
                if (sqlR.estado == true)
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }

        }
        private async Task HallarIDVenta()
        {
            TablaVentas objventas = new TablaVentas();
            objventas =await ControladorVenta.ConsultaX_guid(guidVenta_frm);
            if (objventas != null)
            {
                IdVenta_Frm = objventas.id;
            }
        }
        private async Task<bool> NuevaVenta()
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
                objventa.abonoTarjeta = 0;

                
                bool sqlNueva =await ControladorVenta.Crud(objventa, 0);
                if (sqlNueva == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
        Guid guidVenta_frm;
        private void CrearGuid()
        {
            guidVenta_frm = Guid.NewGuid();
        }
        int IdVenta_Frm=0;
        private async Task<bool> ConsultarVentaActiva()
        {
            try
            {
                R_VentaUsuario objR = new R_VentaUsuario();
                objR =await controladorRVentarUsuario.Consultar_IdUsuario_Estado(VariablesPublicas.IdUsuarioLogueado, 1);
                if (objR != null)
                {
                    IdVenta_Frm = objR.idVenta;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
        private async Task BuscarPedido()
        {
            //lo primero que devemos hacer es crear la relacion entre el id de la venta con el guid del pedido
            //para eso consultamos el id de la venta y guid del pedido en la table de V_Pedidos
            V_Pedido v_Pedido = new V_Pedido();
            v_Pedido =await controladorPedidoVenta.Consultar_giaPedido(GuiaPedido);
            if (v_Pedido != null)
            {
                VariablesPublicas.IdCliente = v_Pedido.idCliente;

                VariablesPublicas.GuidPedido = v_Pedido.guidPedido;
                VariablesPublicas.giaPedido = v_Pedido.guiaPedido;

                R_PedidoVenta r_Pedido = new R_PedidoVenta();
                r_Pedido =await controladorPedidoVenta.Consultar_IdVenta(IdVenta_Frm);
                if (r_Pedido == null)
                {
                    //abtes de crear la relacion verificamos que el guid del pedido tambien este libre
                    R_PedidoVenta pedidoVenta = new R_PedidoVenta();
                    pedidoVenta =await controladorR_PedidoVenta.Consultar_GuidPedido(v_Pedido.guidPedido);
                    if (pedidoVenta == null)
                    {
                        r_Pedido = new R_PedidoVenta();
                        r_Pedido.id = 0;
                        r_Pedido.idVenta = IdVenta_Frm;
                        r_Pedido.guidPedido = v_Pedido.guidPedido;
                        RespuestaCRUD crud =await controladorR_PedidoVenta.Crud(r_Pedido, 0);
                        if (crud.estado == true)
                        {
                            try
                            {
                                var query = $"exec EliminarDetalleVEnta {IdVenta_Frm}";
                                var resp = await Conection_SQL.ConsultaSQLServer(query,false,true);
                            }
                            catch (Exception ex)
                            {
                                string error = ex.Message;
                            }
                            CargarDetallePedido();
                        }
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
                        await CargarDetallePedido();
                    }
                }
            }
        }
        private async Task<bool> CargarDetallePedido()
        {
            try
            {
                var query = $"exec FacturarPedido {IdVenta_Frm},N'{VariablesPublicas.GuidPedido}'";
                var respu=await Conection_SQL.ConsultaSQLServer(query, false, true);
                if (respu != null)
                {
                    var ressql = JsonConvert.DeserializeObject<RespuestaCRUD>(respu);
                    return ressql.estado;
                }
                else
                {
                    return false;
                }
 
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }

        }
        private void cbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnAlistamiento_Click(object sender, EventArgs e)
        {
            frm_alistamiento frm = new frm_alistamiento();
            AddOwnedForm(frm);
            frm.idVendedor_frm = Convert.ToInt32(cbVendedor.SelectedValue);
            frm.idEstadoPedido_frm = Convert.ToInt32(cbEstado.SelectedValue);
            frm.nombreVendedor_frm = cbVendedor.Text;
            frm.fecha = dtDia.Value;
            frm.txtVendedor.Text = cbVendedor.Text;
            frm.txtTotal.Text = txtTotalPedidos.Text;
            frm.ShowDialog();
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (cbVendedor.Text != "")
            {
                int suma =await controladorPedidos.PedidosPendientes(Convert.ToInt32(cbVendedor.SelectedValue), Convert.ToInt32(cbEstado.SelectedValue) ,dtDia.Value);
                decimal sumaTotalPedidos =await controladorPedidos.sumarTotalPedido(Convert.ToInt32(cbVendedor.SelectedValue), Convert.ToInt32(cbEstado.SelectedValue), dtDia.Value);
                txtTotalPedidos.Text=sumaTotalPedidos.ToString("C");
                txtPedidosPendientes.Text = Convert.ToString(suma);
                if (suma > 0)
                {
                    btnAlistamiento.Enabled = true;
                }
                else
                {
                    btnAlistamiento.Enabled = false;
                }
                await Cargar_dgPedidos(Convert.ToInt32(cbEstado.SelectedValue), Convert.ToInt32(cbVendedor.SelectedValue),dtDia.Value);

            }
        }

        private async void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            await frm.ListaPedidos( 1, Convert.ToInt32(cbVendedor.SelectedValue),cbVendedor.Text, dtDia.Value, txtTotalPedidos.Text);
            frm.ShowDialog();
        }

        private async void btnImp1_Click(object sender, EventArgs e)
        {
            SeleccionarPedido();
            foreach (V_Pedido v_Pedido in FiltroPedidos)
            {
                if (v_Pedido.guidPedido == GuidPedido)
                {
                    await Facturar(v_Pedido.idCliente, v_Pedido.guidPedido, v_Pedido.guiaPedido, v_Pedido.nombreVendedor);
                }
            }
        }

        private async void btnReImprimir1_Click(object sender, EventArgs e)
        {
            SeleccionarPedido();
            foreach (V_Pedido v_Pedido in FiltroPedidos)
            {
                if (v_Pedido.guidPedido == GuidPedido)
                {
                    R_PedidoVenta pv = new R_PedidoVenta();
                    pv =await controladorR_PedidoVenta.Consultar_GuidPedido(v_Pedido.guidPedido);
                    if(pv != null)
                    {
                        VariablesPublicas.nombreVendedor = v_Pedido.nombreVendedor;
                        await ClassImprimirDirecto.FacturaVentaCarta(2, pv.idVenta);
                    }
                }
            }
        }

        private async void btnReImprimirGrupo_Click(object sender, EventArgs e)
        {
            int contador = 0;

            FrmLoading loading = null;
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    loading = FrmLoading.ShowLoading(this, "Cargarndo...");
                    // inicio


                    var pedidosSeleccionados = new List<V_Pedido>();
                    foreach (DataGridViewRow row in dgPedidos.SelectedRows)
                    {
                        if (row.IsNewRow) continue;

                        if (row.DataBoundItem is V_Pedido pedido)
                        {
                            pedidosSeleccionados.Add(pedido);
                        }
                    }

                    if (pedidosSeleccionados.Count == 0)
                    {
                        MessageBox.Show("No se han seleccionado pedidos para facturar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    foreach (var obj in pedidosSeleccionados)
                    {
                        contador++;
                        R_PedidoVenta pv = new R_PedidoVenta();
                        pv = await controladorR_PedidoVenta.Consultar_GuidPedido(obj.guidPedido);
                        if (pv != null)
                        {
                            VariablesPublicas.nombreVendedor = obj.nombreVendedor;
                            await ClassImprimirDirecto.FacturaVentaCarta(2, pv.idVenta);
                        }
                    }

                    // fin
                    FrmLoading.CloseLoading(this, loading);
                }
            }
            catch (Exception ex)
            {
                FrmLoading.CloseLoading(this, loading);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                FrmLoading.CloseLoading(this, loading);
                MessageBox.Show($"se imprimio {contador} facturas con éxito.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnFiltrar.PerformClick();
            }


            foreach (V_Pedido v_Pedido in FiltroPedidos)
            {
                R_PedidoVenta pv = new R_PedidoVenta();
                pv =await controladorR_PedidoVenta.Consultar_GuidPedido(v_Pedido.guidPedido);
                if (pv != null)
                {
                    VariablesPublicas.nombreVendedor = v_Pedido.nombreVendedor;
                    await ClassImprimirDirecto.FacturaVentaCarta(2, pv.idVenta);
                }
            }
        }

        private void dgPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

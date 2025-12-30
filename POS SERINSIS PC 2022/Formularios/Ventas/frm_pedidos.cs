using DAL.Controlador;
using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using Invenpol_Parqueadero_Motos.Procesos;
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

        private void frm_pedidos_Load(object sender, EventArgs e)
        {
            //Cargar_dgPedidos(1);
            CargarEstado();
            Cargar_cbVendedor();
            txtPedidosPendientes.Text = "0";
            btnAlistamiento.Enabled = false;
        }
        private void Cargar_cbVendedor()
        {
            cbVendedor.ValueMember = "id";
            cbVendedor.DisplayMember = "nombreVendedor";
            cbVendedor.DataSource = controladorVendedor.Lista_Completa();
            cbVendedor.SelectedIndex = -1;
        }
        private void Cargar_dgPedidos(int estado,int idVendedor_frm,DateTime fecha)
        {
            FiltroPedidos= controladorPedidos.Filtrar_estado(estado, idVendedor_frm, fecha);
            dgPedidos.DataSource = FiltroPedidos;
        }
        private void CargarEstado()
        {
            cbEstado.ValueMember = "id";
            cbEstado.DisplayMember = "nombreEstadoPedido";
            cbEstado.DataSource = controladorEstadoPedido.ListaCompleta();
            cbEstado.SelectedIndex = 0;
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEstado.Text != "")
            {
                Cargar_dgPedidos(1,Convert.ToInt32(cbEstado.SelectedValue),dtDia.Value) ;
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
        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            SeleccionarPedido();
            frmListaDetallePedido frm = new frmListaDetallePedido();
            AddOwnedForm(frm);
            frm.dgDetallePedido.DataSource = controladorDetallePedido.Filtrar_guiPedido(GuidPedido);
            frm.ShowDialog();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            int contador = 0;
            foreach (V_Pedido v_Pedido in FiltroPedidos)
            {
                contador++;
                Facturar(v_Pedido.idCliente,v_Pedido.guidPedido,v_Pedido.guiaPedido,v_Pedido.nombreVendedor);
            }
        }
        private void Facturar(int idcliente,Guid guidPedido,string guiaPedido,string nombreVendedor)
        {
           
            IdCliente = idcliente;
            VariablesPublicas.IdCliente = idcliente;
            VariablesPublicas.GuidPedido = guidPedido;
            VariablesPublicas.giaPedido = guiaPedido;
            GuidPedido = guidPedido;
            GuiaPedido = guiaPedido;

            /* lo primero es verificar si el gud del pedido tiene relacion con alguventa */
            R_PedidoVenta pedidoVenta = new R_PedidoVenta();
            pedidoVenta = controladorR_PedidoVenta.Consultar_GuidPedido(guidPedido);
            if (pedidoVenta != null)
            {
                /* aca hallamos que el pevido ya tiene una relacion con el id de una venta 
                 ahora verificamos si esa venta existe */
                TablaVentas tablaVentas = new TablaVentas();
                tablaVentas = ControladorVenta.ConsultaX_id(pedidoVenta.idVenta);
                if (tablaVentas != null)
                {
                    guidVenta_frm = tablaVentas.guidVenta;
                    IdVenta_Frm = tablaVentas.id;

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
                    CargarDetallePedido();

                    if (tablaVentas.numeroVenta > 0)
                    {
                        int boton_ventaCliente;
                        int idr;
                        /* verificamos si la venta tiene ralacion con el cleinte del pedido */
                        R_VentaCliente ventaCliente = new R_VentaCliente();
                        ventaCliente = controladorRVentaCleinte.ConsultarRelacion(pedidoVenta.idVenta);
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
                        if (controladorRVentaCleinte.CrearEditarEliminar_R_VentaCleinte(ventaCliente, boton_ventaCliente))
                        {
                            /* en esta parte enviamos a imprimir la factura */
                            VariablesPublicas.nombreVendedor = nombreVendedor;
                            ClassImprimirDirecto.FacturaVentaCarta(2, pedidoVenta.idVenta);
                        }
                    }
                    else
                    {
                        Vender();
                        if (Guardar())
                        {
                            /* en esta parte cambiemos el estado del pedido */
                            Pedidos pedidos = new Pedidos();
                            pedidos = controladorPedidos.Consultar_guid(guidPedido);
                            if (pedidos != null)
                            {
                                pedidos.idEstadoPedido = 2;
                                controladorPedidos.Crud(pedidos, 1);
                            }
                            VariablesPublicas.nombreVendedor = nombreVendedor;
                            ClassImprimirDirecto.FacturaVentaCarta(2, IdVenta_Frm);
                        }
                    }
                }
            }
            else
            {

                CrearGuid();
                //creamos un nuevo registro en la table ventas con el guid generado
                bool nuevo = NuevaVenta();
                if (nuevo == true)
                {
                    HallarIDVenta();
                    BuscarPedido();

                    int boton_ventaCliente;
                    int idr;
                    /* verificamos si la venta tiene ralacion con el cleinte del pedido */
                    R_VentaCliente ventaCliente = new R_VentaCliente();
                    ventaCliente = controladorRVentaCleinte.ConsultarRelacion(IdVenta_Frm);
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
                    if (controladorRVentaCleinte.CrearEditarEliminar_R_VentaCleinte(ventaCliente, boton_ventaCliente))
                    {
                        /* en esta parte enviamos a imprimir la factura */
                        VariablesPublicas.nombreVendedor = nombreVendedor;
                    }


                    Vender();
                    if (Guardar())
                    {
                        Pedidos pedidos = new Pedidos();
                        pedidos = controladorPedidos.Consultar_guid(guidPedido);
                        if (pedidos != null)
                        {
                            pedidos.idEstadoPedido = 2;
                            controladorPedidos.Crud(pedidos, 1);
                        }
                        VariablesPublicas.nombreVendedor = nombreVendedor;
                        ClassImprimirDirecto.FacturaVentaCarta(2, IdVenta_Frm);
                    }
                }

            }
        }
        private bool Guardar()
        {
            if (IdCliente != 0)
            {
                int Boton;
                int IdRelacion;
                //en esta parte creamos la relacion de venta cliente
                R_VentaCliente objRVC = new R_VentaCliente();
                objRVC = controladorRVentaCleinte.ConsultarRelacion(IdVenta_Frm);
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
                bool sqlRelacion = controladorRVentaCleinte.CrearEditarEliminar_R_VentaCleinte(objRVC, Boton);
            }

            //en esta parte hallamos el consecutivo de recivo
            NumeroFacturaRecibo = HallarConsecutivoRecibo();
            if (NumeroFacturaRecibo == 0)
            {
                NumeroFacturaRecibo = HallarConsecutivoRecibo();
            }
            //creamos un objeto para la tabla venta
            TablaVentas objVenta = new TablaVentas();
            objVenta = ControladorVenta.ConsultaX_id(IdVenta_Frm);
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
                bool Respuesta = ControladorVenta.Crud(objVenta, 1);
                if (Respuesta == true)
                {
                    if (!FinalizarVenta())
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
        private int HallarConsecutivoRecibo()
        {
            //en esta parte hallamos el consecutivo de recivo
            ConsecutivoRecibo consecutivoRecibo = new ConsecutivoRecibo();
            consecutivoRecibo = controladorNumeracionRecibo.Consultar_x_IdVenta(IdVenta_Frm);
            if (consecutivoRecibo != null)
            {
                return consecutivoRecibo.id;
            }
            else
            {
                consecutivoRecibo = new ConsecutivoRecibo();
                consecutivoRecibo.id = 0;
                consecutivoRecibo.idVenta = IdVenta_Frm;
                bool crud = controladorNumeracionRecibo.crud(consecutivoRecibo, 0);
                if (crud == true)
                {
                    return 0;
                }
                return 0;
            }
        }
        private bool FinalizarVenta()
        {
            try
            {
                //cambiamos el estado de la relacion venta usuario
                R_VentaUsuario objRVU = new R_VentaUsuario();
                objRVU = controladorRVentarUsuario.Consultar_IdUsuario_IdVenta(VariablesPublicas.IdUsuarioLogueado, IdVenta_Frm, 1);
                if (objRVU != null)
                {
                    objRVU.estado = 0;
                    bool sqlRVU = controladorRVentarUsuario.CrearEditarEliminarR_VentaUsuario(objRVU, 1);
                }
                return true;
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
        private void SeleccionarVenta(int Consecutivo)
        {
            V_TablaVentas objTV = new V_TablaVentas();
            objTV = ControladorVenta.ConsultaX_V_id(IdVenta_Frm);
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
                    objRVC = controladorRVentaCleinte.ConsultarRelacion(IdVenta_Frm);
                    if (objRVC != null)
                    {
                        IdCliente = objRVC.idCliente;
                    }

                    Clientes objCliente = new Clientes();
                    objCliente = ControladorClienteTienda.ConsultarX_ID(IdCliente);
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
            catch (Exception ex)
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
                objventa.abonoTarjeta = 0;
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
        private bool ConsultarVentaActiva()
        {
            try
            {
                R_VentaUsuario objR = new R_VentaUsuario();
                objR = controladorRVentarUsuario.Consultar_IdUsuario_Estado(VariablesPublicas.IdUsuarioLogueado, 1);
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
        private void BuscarPedido()
        {
            //lo primero que devemos hacer es crear la relacion entre el id de la venta con el guid del pedido
            //para eso consultamos el id de la venta y guid del pedido en la table de V_Pedidos
            V_Pedido v_Pedido = new V_Pedido();
            v_Pedido = controladorPedidoVenta.Consultar_giaPedido(GuiaPedido);
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
                    R_PedidoVenta pedidoVenta = new R_PedidoVenta();
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
                        CargarDetallePedido();
                    }
                }
            }
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (cbVendedor.Text != "")
            {
                int suma = controladorPedidos.PedidosPendientes(Convert.ToInt32(cbVendedor.SelectedValue), Convert.ToInt32(cbEstado.SelectedValue) ,dtDia.Value);
                decimal sumaTotalPedidos = controladorPedidos.sumarTotalPedido(Convert.ToInt32(cbVendedor.SelectedValue), Convert.ToInt32(cbEstado.SelectedValue), dtDia.Value);
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
                Cargar_dgPedidos(Convert.ToInt32(cbEstado.SelectedValue), Convert.ToInt32(cbVendedor.SelectedValue),dtDia.Value);

            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            frm.ListaPedidos( 1, Convert.ToInt32(cbVendedor.SelectedValue),cbVendedor.Text, dtDia.Value, txtTotalPedidos.Text);
            frm.ShowDialog();
        }

        private void btnImp1_Click(object sender, EventArgs e)
        {
            SeleccionarPedido();
            foreach (V_Pedido v_Pedido in FiltroPedidos)
            {
                if (v_Pedido.guidPedido == GuidPedido)
                {
                    Facturar(v_Pedido.idCliente, v_Pedido.guidPedido, v_Pedido.guiaPedido, v_Pedido.nombreVendedor);
                }
            }
        }

        private void btnReImprimir1_Click(object sender, EventArgs e)
        {
            SeleccionarPedido();
            foreach (V_Pedido v_Pedido in FiltroPedidos)
            {
                if (v_Pedido.guidPedido == GuidPedido)
                {
                    R_PedidoVenta pv = new R_PedidoVenta();
                    pv = controladorR_PedidoVenta.Consultar_GuidPedido(v_Pedido.guidPedido);
                    if(pv != null)
                    {
                        VariablesPublicas.nombreVendedor = v_Pedido.nombreVendedor;
                        ClassImprimirDirecto.FacturaVentaCarta(2, pv.idVenta);
                    }
                }
            }
        }

        private void btnReImprimirGrupo_Click(object sender, EventArgs e)
        {
            foreach (V_Pedido v_Pedido in FiltroPedidos)
            {
                R_PedidoVenta pv = new R_PedidoVenta();
                pv = controladorR_PedidoVenta.Consultar_GuidPedido(v_Pedido.guidPedido);
                if (pv != null)
                {
                    VariablesPublicas.nombreVendedor = v_Pedido.nombreVendedor;
                    ClassImprimirDirecto.FacturaVentaCarta(2, pv.idVenta);
                }
            }
        }
    }
}

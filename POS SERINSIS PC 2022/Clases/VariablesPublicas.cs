using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invenpol_Parqueadero_Motos.Clases
{
    public class VariablesPublicas
    {
        public static string version = "1.3";

        public static string nombreVendedor = "";
        public static bool Gramera = false;

        public static decimal cantidadKilogramo = 0;


        public static bool FE_Enviada = false;
        public static string cufeFE = "";
        public static string prefijoFE = "";
        public static string resolucionFE = "";
        public static string fechaAutorizcionFE = "";
        public static string rangoFE = "";

        public static bool FacturarPedido = false;
        public static int IdCliente = 0;
        public static Guid GuidPedido;
        public static string giaPedido = "";
        public static bool Mensualidad = false;
        public static string TipoFactura;
        public static string Resolucion = "";
        public static string FechaResolucion = "";
        public static string RangoResolucion = "";
        public static string PrefijoResolucion = "";
        public static bool FacturaElectronica = false;
        public static bool ErrorConexion = false;
        public static int VentasEnNegativo = 0;
        public static int EditarPrecioVentaProducto = 0;
        public static string ReporteImprimir;
        public static string CorreoAdmin2= "sistemas@serinsispc.com";
        public static string CorreoAdmin1="";
        public static bool Programador = false;
        public static int TipoCodigoImpresora;
        public static string ObservacionFactura;
        public static int IdTipoUsuario;
        public static int BodegaActiva;
        public static string ObservacionIngreso;
        public static string Serial;
        public static string Modelo;
        public static string TipoArticulo;
        public static string DesciopcionTraslado;
        public static string TipoServicio;
        public static string OrdenTraslado;
        public static string NumeroOrdenServicio;
        public static bool AlPorMayor;
        public static bool TiendaOnline;
        public static int UltimaCajaActiva;
        public static string CorreoElectronico;
        public static int IdBaseActiva;
        public static decimal SaldoCaja;
        public static decimal SaldoBanco;
        public static decimal SaldoCajaMenor;
        public static decimal SaldoTotal;
        public static string CodigoCajonMonesero;
        public static int CantidadProductoFRMPC;
        public static string TelefonoCliente;
        public static string RecibidoTraslado;
        public static string DireccionCliente;
        public static string DocumentoCliente;
        public static string NombreCliente;
        public static string EnvioTraslado;
        public static string FacturaRecibo;
        public static string EfectivoTarjeta;
        public static int TipoCajaRegistradora;
        public static string RutaImagenes;
        public static string RutaConsultaImagen;
        public static bool CajonMonedero;
        public static int IdVentaTienda = 0;
        //creamos una variable que se encarga de guardar el tipo de reporte
        public static string TipoReporte = "";
        //creamos una variable la cual se encarga de guardar el tipo de filtro (Año, Mes, Dia)
        public static string TipoFiltroReporte = "";
        //creamos uanvariable que se encargue de guardar la fecha de reporte
        public static DateTime FechaReporte;

        public static int TipoDeSoftware; //esta varable guarda eltipo de programa si es completo o basico
        public static int IdUsuarioLogueado;
        public static string NombreUsuarioActivo;
        public static string TipoUsuarioLogueado;
        public static int IdEmpresaLogueada;
        public static int IdMensualidadPublico;
        public static int idEstadoMensualidadPublico;
        public static string PlacaPublica;
        public static string NombreEmpresa;
        public static string RepresentanteLegal;
        public static string CC_NIT;
        public static string Regimen;
        public static string Direccion;
        public static string Telefono;
        public static string Celular;
        public static string NumeroTicket;
        public static string Cascos;
        public static string HoraIngreso;
        public static string FechaIngreso;
        public static string NombreImpresora;
        public static string DiasParqueo;
        public static int TamañaPapel;
        public static string HoraSalida;
        public static string FechaSalida;
        public static string TiempoTotal;
        public static string SubTotal;
        public static string Descuento;
        public static string Total;
        public static string Efectivo;
        public static string Cambio;
        public static DateTime FechaInicio;
        public static DateTime FechaAviso;
        public static DateTime FechaFin;
        public static string PlacaMensual;
        public static string ClienteMensual;
        public static int ValorPagado;
        public static int Saldo;
        public static DateTime HoraInicio;
        public static DateTime HoraFin;
        public static int Total_RMensualidad;
        public static int Total_RVehiculosDiarios;
        public static int Total_RUsuario;
        public static int ClientesActivos;
        public static int TotalActivos;
        public static int PuestoParqueo;
        public static string TipoVehiculo;
        public static Image CodigoBarraTiket;
        public static string LeyendaTiketPOS;       
        public static string LeyendaCarta2;
        public static bool CobrarPlaca = false;
        public static bool PuestosPorVehiculo = false;
        public static bool DescuentoVendedor = false; //recorcar activar o desactivar segun el cleinte
        public static bool ClienteOcasional = false;
        //variables para la tienda
        public static string CodigoBarraProducto;
        public static string PlUProducto;
        public static string DescripcionPruducto;
        public static int CostoProducto;
        public static int PresioProducto;
        public static int GananciaProducto;
        public static int FiltroProducto;
        //variables para el recibo de caja ventas
        public static int NumeroReciboVenta;
        public static int TotalVenta;
        public static int EfectivoVenta;
        public static int CambioVenta;
        public static DateTime FechaVenta;
        //variables para el reporte de tienda
        public static int Compras_Tienda;
        public static int Ventas_Tienda;
        public static int Ganancia_Tienda;
        public static int TotalPagosCredito = 0;
        public static int TotalPendienteCredito = 0;
        //variables para el reporte general
        public static int Gastos_General;
        public static int Egresos_General;
        public static int Ingresos_General;
        public static int Ganancia_General;

        public static string TipoImpresora = "";

        public static string NitEmpresa;
        public static string RepresentanteEmpresa;
        public static string RegimenEmpresa;
        public static string DireccionEmpresa;
        public static string TelefonoEmpresa;

        public static string NumeroFactura;
        public static string SubTotalFactura;
        public static string DescuentoFactura;
        public static string TotalFactura;
        public static string EfectivoFactura;
        public static string CambioFactura;
        public static string NumeroMesaFactura;
        public static string CajeroFactura;
        public static string MeseroFactura;

        public static string RutaApllicacionActualizacion;
        public static string RutaCarpetaActualizacion;
        public static string NombreCarpetaActualizacion;
        public static string NombreEquipoLocal;
        public static string RutaTutoriales;
    }
}

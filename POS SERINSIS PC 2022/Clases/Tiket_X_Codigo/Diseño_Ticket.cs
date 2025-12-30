using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winRdlc2;

namespace Invenpol_Parqueadero_Motos.Clases
{
    public class Diseño_Ticket
    {
        //Creamos la varables a ulilizar
        public string NombreEmpresa = "";
        public string RepresentanteLegal = "";
        public string CC_NIT = "";
        public string Regimen = "";
        public string Direccion = "";
        public string Telefono = "";
        public string Celular = "";
        public string Placa = "";
        public string NumeroTicket = "";
        public string Cascos = "";
        public string HoraIngreso = "";
        public string FechaIngreso = "";
        public string HoraSalida = "";
        public string FechaSalida = "";
        public string TiempoParqueo= "";
        public string SubTotal;
        public string Descuanto;
        public string Total ;
        public string Efectivo;
        public string Cambio;
        public string Cajero = "";
        public string NombreImpresora;
        public String DiasParqueo;
        public string NombreCliente;
        public DateTime FechaInicio;
        public DateTime FechaAviso;
        public DateTime FechaFin;
        public string Saldo;
        public DateTime Hora1;
        public DateTime Hora2;
        public int ValorMensual = 0;
        public int ValorDiario = 0;
        public int ValorTotal = 0;
        public DateTime FechaReporte;
        public int ClientesActivos = 0;
        public int TotalActivos = 0;
        public string TipoReporte;
        public DateTime FechaVenta;
        public int NumeroResibo = 0;
        //variables para reporte general y tienda
        public int Gastos = 0;
        public int ComprasTienda = 0;
        public int VentasTienda = 0;
        public int GananciaTienda = 0;
        public int Egresos = 0;
        public int Ingresos = 0;
        public int GananciaGeneral = 0;

        public void CajonMonedero(int codigo)
        {
            //creamos una instancia de la clase crearTicket
            CrearTiket ticket = new Clases.CrearTiket();
            ticket.AbreCajon(codigo);
            //ticket.CortaTicket();
            //envimos a imprimir
            string Impresora = Impresor.ImpresoraPredeterminada();
            ticket.ImprimirTicket(Impresora);
        }
        public void DiseñarTicket()
        {

            ////igualamos las variables locales con la variables publicas
            NombreEmpresa = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.NombreEmpresa;
            RepresentanteLegal = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.RepresentanteLegal;
            CC_NIT = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.CC_NIT;
            Regimen = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Regimen;
            Direccion = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Direccion;
            Telefono = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Telefono;
            Celular = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Celular;
            //NombreImpresora = "POS80";

            Placa = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.PlacaPublica;
            NumeroTicket = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.NumeroTicket;
            Cascos = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Cascos;
            HoraIngreso = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.HoraIngreso;
            FechaIngreso = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.FechaIngreso;
            

            //creamos una instancia de la clase crearTicket
            CrearTiket ticket = new Clases.CrearTiket();
            //creamos el diseño del ticket
            ticket.TextoCentro(NombreEmpresa);
            ticket.TextoCentro(RepresentanteLegal);
            ticket.TextoCentro("NIT: " + CC_NIT);
            ticket.TextoCentro("Regimen " + Regimen);
            ticket.TextoCentro(Direccion);
            ticket.TextoCentro("Tel: "+ Telefono + " - "+ Celular);
            ticket.lineasGio();
            ticket.TextoCentro("Ticket: " + NumeroTicket + "    Placa: " + Placa + "    Cascos: " + Cascos);
            //ticket.TextoCentro("Placa: " + Placa);
            //ticket.TextoCentro("Cascos: " + Cascos);
            //ticket.TextoCentro("Hora Ingreso: " + HoraIngreso);
            ticket.TextoCentro("Fecha Hora Ingreso: " + FechaIngreso + " / " +  HoraIngreso );
            ticket.lineasGio();
            ticket.TextoCentro("estimado cliente, presente este ticket al");
            ticket.TextoCentro("momento de retirar su vehiculo del parqueadero");
            ticket.TextoCentro("gracias.");
            ticket.lineasGio();
            ticket.TextoCentro("Software creado por Emiliano Polania Cuellar");
            ticket.TextoCentro("Cel:3144628361");
            ticket.lineasGio();
            //envimos a imprimir
            string Impresora=Impresor.ImpresoraPredeterminada();
            ticket.ImprimirTicket(Impresora);
        }
        /// <summary>
        /// ahora diseñamos el recibo
        /// </summary>
        public void DiseñarRecibo()
        {
            ////igualamos las variables locales con la variables publicas
            NombreEmpresa = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.NombreEmpresa;
            RepresentanteLegal = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.RepresentanteLegal;
            CC_NIT = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.CC_NIT;
            Regimen = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Regimen;
            Direccion = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Direccion;
            Telefono = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Telefono;
            Celular = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Celular;
            Placa = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.PlacaPublica;
            NumeroTicket = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.NumeroTicket;
            Cascos = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Cascos;
            HoraIngreso = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.HoraIngreso;
            FechaIngreso = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.FechaIngreso;
            HoraSalida = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.HoraSalida;
            FechaSalida = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.FechaSalida;
            TiempoParqueo = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.TiempoTotal;
            DiasParqueo = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.DiasParqueo;
            SubTotal=Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.SubTotal;
            Descuanto = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Descuento;
            Total = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Total;
            Efectivo = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Efectivo;
            Cambio = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Cambio;

            SubTotal = "$" + string.Format("{0:#,##0.##}", Convert.ToDouble(Convert.ToInt32(SubTotal)));
            Descuanto = "$" + string.Format("{0:#,##0.##}", Convert.ToDouble(Convert.ToInt32(Descuanto)));
            Total = "$" + string.Format("{0:#,##0.##}", Convert.ToDouble(Convert.ToInt32(Total)));
            Efectivo = "$" + string.Format("{0:#,##0.##}", Convert.ToDouble(Convert.ToInt32(Efectivo)));
            Cambio = "$" + string.Format("{0:#,##0.##}", Convert.ToDouble(Convert.ToInt32(Cambio)));

            Cajero = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.NombreUsuarioActivo;

           // NombreImpresora = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.NombreImpresora;

            //creamos una instancia de la clase crearTicket
            CrearTiket ticket = new Clases.CrearTiket();
            //creamos el diseño del ticket
            ticket.TextoCentro(NombreEmpresa);
            ticket.TextoCentro(RepresentanteLegal);
            ticket.TextoCentro("NIT: " + CC_NIT);
            ticket.TextoCentro("Regimen " + Regimen);
            ticket.TextoCentro(Direccion);
            ticket.TextoCentro("Tel: " + Telefono + " - " + Celular);
            ticket.lineasGio();
            ticket.TextoCentro("Resibo: " + NumeroTicket + "       Placa: " + Placa);
            //ticket.TextoCentro("Placa: " + Placa);
            //ticket.TextoCentro("Cascos: " + Cascos);
            //ticket.TextoCentro("Hora Ingreso: " + HoraIngreso);
            ticket.TextoIzquierda(" Fecha Hora Ingreso: " + FechaIngreso + " / " + HoraIngreso);
            ticket.TextoIzquierda("  Fecha Hora Salida: " + FechaSalida + " / " + HoraSalida);
            ticket.TextoIzquierda("   Tiempo Parqueado: " + TiempoParqueo + " - Dias: " + DiasParqueo);
            ticket.lineasGio();
            ticket.AgregarTotales(" SubTotal: ", SubTotal);
            ticket.AgregarTotales("Descuento: ", Descuanto);
            ticket.AgregarTotales("    Total: ", Total);
            ticket.AgregarTotales(" Efectivo: ", Efectivo);
            ticket.AgregarTotales("   Cambio: ", Cambio);
            ticket.lineasGio();
            ticket.TextoCentro("Atendido por: " + Cajero);
            ticket.TextoCentro("gracias por su visita.");
            ticket.lineasGio();
            ticket.TextoCentro("Software creado por Emiliano Polania Cuellar");
            ticket.TextoCentro("Cel:3144628361");
            ticket.TextoCentro(" ");
            ticket.TextoCentro(" ");
            ticket.TextoCentro(" ");
            ticket.TextoCentro(" ");
            ticket.CortaTicket();
            //ticket.AbreCajon();
            //envimos a imprimir
            string Impresora=Impresor.ImpresoraPredeterminada();
            ticket.ImprimirTicket(Impresora);  
        }
        /// <summary>
        /// ahora diseñamos el recibo
        /// </summary>
        public void DiseñarReciboMensualidad()
        {
            ////igualamos las variables locales con la variables publicas
            NombreEmpresa = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.NombreEmpresa;
            RepresentanteLegal = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.RepresentanteLegal;
            CC_NIT = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.CC_NIT;
            Regimen = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Regimen;
            Direccion = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Direccion;
            Telefono = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Telefono;
            Celular = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Celular;

            Placa = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.PlacaMensual;
            NombreCliente = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.ClienteMensual;

            FechaInicio =Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.FechaInicio;
            string Inicio=string.Format("{0:d}", FechaInicio);
            FechaAviso =Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.FechaAviso;
            string Aviso = string.Format("{0:d}", FechaAviso);
            FechaFin = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.FechaFin;
            string Fin = string.Format("{0:d}", FechaFin);

            Total = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Total;
            Total="$" + string.Format("{0:#,##0.##}",Convert.ToString(Total));
            Efectivo= Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Efectivo;
            Efectivo = "$" + string.Format("{0:#,##0.##}", Convert.ToString(Convert.ToInt32(Efectivo)));
            Cambio= Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Cambio;
            Cambio = "$" + string.Format("{0:#,##0.##}", Convert.ToString(Convert.ToInt32(Cambio)));
            Saldo=Convert.ToString(Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Saldo);
            Saldo = "$" + string.Format("{0:#,##0.##}", Convert.ToString(Convert.ToInt32(Saldo)));

            Cajero = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.NombreUsuarioActivo;

            //NombreImpresora = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.NombreImpresora;

            //creamos una instancia de la clase crearTicket
            CrearTiket ticket = new Clases.CrearTiket();
            //creamos el diseño del ticket
            ticket.TextoCentro(NombreEmpresa);
            ticket.TextoCentro(RepresentanteLegal);
            ticket.TextoCentro("NIT: " + CC_NIT);
            ticket.TextoCentro("Regimen " + Regimen);
            ticket.TextoCentro(Direccion);
            ticket.TextoCentro("Tel: " + Telefono + " - " + Celular);
            ticket.lineasGio();

            ticket.TextoCentro("Placa: " + Placa);
            ticket.TextoCentro("Cliente: " + NombreCliente);
            ticket.TextoIzquierda("       Fecha Inicio: " + Inicio);
            ticket.TextoIzquierda("        Fecha Aviso: " + Aviso);
            ticket.TextoIzquierda("          Fecha Fin: " + Fin);
            ticket.lineasGio();

            ticket.AgregarTotales("   Total: ", Total);
            ticket.AgregarTotales("Efectivo: ", Efectivo);
            ticket.AgregarTotales("  Cambio: ", Cambio);
            ticket.AgregarTotales("   Saldo: ", Saldo);
            ticket.lineasGio();

            ticket.TextoCentro("Atendido por: " + Cajero);
             ticket.lineasGio();

            ticket.TextoCentro("Software creado por Emiliano Polania Cuellar");
            ticket.TextoCentro("Cel:3144628361");
            ticket.TextoCentro(" ");
            ticket.TextoCentro(" ");
            ticket.TextoCentro(" ");
            ticket.TextoCentro(" ");
            ticket.CortaTicket();
            //envimos a imprimir
            string Impresora = Impresor.ImpresoraPredeterminada();
            ticket.ImprimirTicket(Impresora);
        }
        /// <summary>
        /// ahora diseñamos el recibo
        /// </summary>
        public void DiseñarReporteUsuario()
        {
            ////igualamos las variables locales con la variables publicas
            NombreEmpresa = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.NombreEmpresa;
            RepresentanteLegal = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.RepresentanteLegal;
            CC_NIT = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.CC_NIT;
            Regimen = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Regimen;
            Direccion = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Direccion;
            Telefono = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Telefono;
            Celular = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Celular;

            FechaInicio = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.FechaInicio;
            string Inicio = string.Format("{0:d}", FechaInicio);
            Hora1 = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.HoraInicio;
            string Hinicio = Convert.ToString(Hora1.TimeOfDay);
            FechaFin = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.FechaFin;
            string Fin = string.Format("{0:d}", FechaFin);
            Hora2 = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.HoraFin;
            string Hfin = Convert.ToString(Hora2.TimeOfDay);
            ValorDiario = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Total_RVehiculosDiarios;
            string VMensual = "$ " + string.Format("{0:##,##0.##}", ValorDiario);
            ValorMensual = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Total_RMensualidad;
            string Vdiario = "$ " + string.Format("{0:##,##0.##}", ValorMensual);
            ValorTotal = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Total_RUsuario;
            string Total = "$ " + string.Format("{0:##,##0.##}", ValorTotal);

            Cajero = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.NombreUsuarioActivo;

            NombreImpresora = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.NombreImpresora;

            //creamos una instancia de la clase crearTicket
            CrearTiket ticket = new Clases.CrearTiket();
            //creamos el diseño del ticket
            ticket.TextoCentro(NombreEmpresa);
            ticket.TextoCentro(RepresentanteLegal);
            ticket.TextoCentro("NIT: " + CC_NIT);
            ticket.TextoCentro("Regimen " + Regimen);
            ticket.TextoCentro(Direccion);
            ticket.TextoCentro("Tel: " + Telefono + " - " + Celular);
            ticket.lineasGio();

            ticket.TextoCentro("Reporte Ingreso Usuario");
            ticket.TextoCentro( Cajero);
            ticket.TextoIzquierda("      Inicio: " + Inicio + " - " + Hinicio);
            ticket.TextoIzquierda("         Fin: " + Fin + " - " + Hfin);
            ticket.TextoIzquierda("      Vehículos Diarios:" + VMensual);
            ticket.TextoIzquierda("    Vehículos Mensuales:" + Vdiario);
            ticket.TextoIzquierda("          Reporte Total:" + Total);
            ticket.lineasGio();

            ticket.TextoCentro("Software creado por Emiliano Polania Cuellar");
            ticket.TextoCentro("Cel:3144628361");
            ticket.TextoCentro(" ");
            ticket.TextoCentro(" ");
            ticket.TextoCentro(" ");
            ticket.TextoCentro(" ");
            ticket.CortaTicket();
            //envimos a imprimir
            string Impresora = Impresor.ImpresoraPredeterminada();
            ticket.ImprimirTicket(Impresora);
        }
        /// <summary>
        /// ahora diseñamos el recibo
        /// </summary>
        public void DiseñarReporteGeneral()
        {
            ////igualamos las variables locales con la variables publicas
            NombreEmpresa = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.NombreEmpresa;
            RepresentanteLegal = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.RepresentanteLegal;
            CC_NIT = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.CC_NIT;
            Regimen = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Regimen;
            Direccion = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Direccion;
            Telefono = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Telefono;
            Celular = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Celular;

            TipoReporte = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.TipoReporte;

            FechaReporte = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.FechaReporte;
            string FReporte = string.Format("{0:d}", FechaReporte);
            ValorDiario = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Total_RVehiculosDiarios;
            string Vdiario = "$ " + string.Format("{0:##,##0.##}", ValorDiario);
            ValorMensual = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Total_RMensualidad;
            string VMensual = "$ " + string.Format("{0:##,##0.##}", ValorMensual);
            ValorTotal = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Total_RUsuario;
            string Total = "$ " + string.Format("{0:##,##0.##}", ValorTotal);
            ClientesActivos = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.ClientesActivos;
            string CActivos = Convert.ToString(ClientesActivos);
            TotalActivos = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.TotalActivos;
            string TActivos = "$ " + string.Format("{0:##,##0.##}", TotalActivos);
            //reporte de tienda
            ComprasTienda = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Compras_Tienda;
            string FComprasTienda = "$ " + string.Format("{0:##,##0.##}", ComprasTienda);
            VentasTienda = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Ventas_Tienda;
            string FVentasTienda = "$ " + string.Format("{0:##,##0.##}", VentasTienda);
            GananciaTienda = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Ganancia_Tienda;
            string FGananciaTienda = "$ " + string.Format("{0:##,##0.##}", GananciaTienda);
            //reporte general
            Gastos = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Gastos_General;
            string FGastos = "$ " + string.Format("{0:##,##0.##}", Gastos);
            Egresos = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Egresos_General;
            string FEgresos = "$ " + string.Format("{0:##,##0.##}", Egresos);
            Ingresos = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Ingresos_General;
            string FIngresos = "$ " + string.Format("{0:##,##0.##}", Ingresos);
            GananciaGeneral = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.Ganancia_General;
            string FGanancia = "$ " + string.Format("{0:##,##0.##}", GananciaGeneral);

            Cajero = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.NombreUsuarioActivo;

           // NombreImpresora = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.NombreImpresora;

            //creamos una instancia de la clase crearTicket
            CrearTiket ticket = new Clases.CrearTiket();
            //creamos el diseño del ticket
            ticket.TextoCentro(NombreEmpresa);
            ticket.TextoCentro(RepresentanteLegal);
            ticket.TextoCentro("NIT: " + CC_NIT);
            ticket.TextoCentro("Regimen " + Regimen);
            ticket.TextoCentro(Direccion);
            ticket.TextoCentro("Tel: " + Telefono + " - " + Celular);
            ticket.lineasGio();

            ticket.TextoCentro("Reporte Ingreso General");
            ticket.TextoIzquierda("          Fecha reporte: " + FReporte + " - " + TipoReporte);
            ticket.TextoIzquierda("      Vehículos Diarios: " + Vdiario);
            ticket.TextoIzquierda("    Vehículos Mensuales: " + VMensual);
            ticket.TextoIzquierda("          Reporte Total: " + Total);
            ticket.TextoIzquierda("  Mensualidades activas: " + CActivos);
            ticket.TextoIzquierda("    Total Mensualidades: " + TActivos);
            ticket.lineasGio();

            ticket.TextoCentro("Reporte Tienda");
            ticket.TextoIzquierda("         Compras Tienda: " + FComprasTienda);
            ticket.TextoIzquierda("          Ventas Tienda: " + FVentasTienda);
            ticket.TextoIzquierda("        Ganancia Tienda: " + FGananciaTienda);
            ticket.lineasGio();

            ticket.TextoCentro("Reporte Generalde ingresos y egresos");
            ticket.TextoIzquierda("                 Gastos: " + FGastos);
            ticket.TextoIzquierda("                Egresos: " + FEgresos);
            ticket.TextoIzquierda("               Ingresos: " + FIngresos);
            ticket.TextoIzquierda("       Ganancia General: " + FGanancia);
            ticket.lineasGio();

            ticket.TextoCentro("Software creado por Emiliano Polania Cuellar");
            ticket.TextoCentro("Cel:3144628361");
            ticket.TextoCentro(" ");
            ticket.TextoCentro(" ");
            ticket.TextoCentro(" ");
            ticket.TextoCentro(" ");
            ticket.CortaTicket();
            //envimos a imprimir
            string Impresora = Impresor.ImpresoraPredeterminada();
            ticket.ImprimirTicket(Impresora);
        }
        
    }
}

using DAL.Controladores;
using DAL.Controladores.Version_Software;
using DAL.Modelo;
using SERINSI_PC.Clases;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Invenpol_Parqueadero_Motos.Clases.Servicios
{
    public class Class_Informacion
    {
        public static async Task CargarInformaionEmpresa()
        {
            //ahor igualamos las variables con la informacion necesaria
            Sede objconf = new Sede();
            objconf = await ControladorSede.ConsultaXIdEmpresa(VariablesPublicas.IdEmpresaLogueada);
            if (objconf != null)
            {
                VariablesPublicas.NombreEmpresa = objconf.nombreSede;
                VariablesPublicas.CC_NIT = objconf.nit;
                VariablesPublicas.RepresentanteLegal = objconf.reprecentante;
                VariablesPublicas.Regimen = objconf.regimen;
                VariablesPublicas.Direccion = objconf.direccion;
                VariablesPublicas.Telefono = objconf.telefono;
                VariablesPublicas.Celular = objconf.celular;
                VariablesPublicas.TamañaPapel = Convert.ToInt32(objconf.tamañoPapel);
                //VariablesPublicas.LeyendaTiketPOS = objconf.;
                VariablesPublicas.LeyendaCarta2 = objconf.leyenda1;
                VariablesPublicas.NombreImpresora = objconf.impresora;
                VariablesPublicas.TipoImpresora = objconf.tipoImpresora;
                VariablesPublicas.TipoCodigoImpresora =Convert.ToInt32(objconf.codigoImpresora);
                VariablesPublicas.CodigoCajonMonesero = objconf.codigoCajon;
                VariablesPublicas.CorreoAdmin1 = objconf.correoAdmin1;
                if (objconf.tiendaOnline == "si")
                {
                    VariablesPublicas.TiendaOnline = true;
                }
                else
                {
                    VariablesPublicas.TiendaOnline = false;
                }
                if (objconf.editarPrecioVentaProducto == 0)
                {
                    VariablesPublicas.EditarPrecioVentaProducto = 0;
                }
                else
                {
                    VariablesPublicas.EditarPrecioVentaProducto = 1;
                }
                if (objconf.ventasEnNegativo == 0)
                {
                    VariablesPublicas.VentasEnNegativo = 0;
                }
                else
                {
                    VariablesPublicas.VentasEnNegativo = 1;
                }
                VariablesPublicas.Resolucion = objconf.resolucion;
                VariablesPublicas.FechaResolucion = objconf.fechaResolucion;
                VariablesPublicas.PrefijoResolucion = objconf.prefijoFectura;
                VariablesPublicas.RangoResolucion = objconf.rangoResolucion;
                VariablesPublicas.TipoFactura = objconf.tipoFactura;
                VariablesPublicas.TipoCajaRegistradora =Convert.ToInt32(objconf.id_tipoCaja);
                if (objconf.gramera == 0)
                {
                    VariablesPublicas.Gramera = false;
                }
                else
                {
                    VariablesPublicas.Gramera = true;
                }
                if (objconf.cajon_monedero == "si")
                {
                    VariablesPublicas.CajonMonedero = true;
                }
                else
                {
                    VariablesPublicas.Gramera = false;
                }
            }

            RutaActualizacionEquipo objRutas = new RutaActualizacionEquipo();
            objRutas =await ControladorRutas.ConsultarX_NombreEquipo(VariablesPublicas.NombreEquipoLocal);
            if (objRutas != null)
            {
                VariablesPublicas.RutaImagenes = objRutas.rutaImagen;
            }
        }
    }
}

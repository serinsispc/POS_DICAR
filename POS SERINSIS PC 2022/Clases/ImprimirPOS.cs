using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAPOS_Tienda.Clases
{
    public class ImprimirPOS
    {
       
        public static Form MdiParent { get; private set; }

        public static async Task CargarInformacionEmpresa()
        {
            Sede objInfo = new Sede();
            objInfo =await ControladorSede.ConsultaXIdEmpresa(1);
            if (objInfo != null)
            {

                VariablesPublicas.NombreEmpresa = objInfo.nombreSede;
                VariablesPublicas.NitEmpresa = objInfo.nit;
                VariablesPublicas.RepresentanteEmpresa = objInfo.reprecentante;
                VariablesPublicas.RegimenEmpresa = objInfo.regimen;
                VariablesPublicas.DireccionEmpresa = objInfo.direccion;
                VariablesPublicas.TelefonoEmpresa = objInfo.telefono;
            }
        }
    }
}

using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winRdlc2;
using static System.Windows.Forms.LinkLabel;

namespace Invenpol_Parqueadero_Motos.Procesos
{
    public class ProcesosGlobal
    {
        public static void AbreCajon(int codigo)
        {
                //VariablesPublicas.NombreImpresora = objImpre.nombre_impresora;
                Diseño_Ticket obj = new Diseño_Ticket();
                obj.CajonMonedero(codigo);
            
        }
    }
}

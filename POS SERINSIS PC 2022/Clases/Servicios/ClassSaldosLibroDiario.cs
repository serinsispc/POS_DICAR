using DAL.Controladores.Contabilidad;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERINSI_PC.Clases.Servicios
{
    public class ClassSaldosLibroDiario
    {
        public  static void hallasUltimoSaldoLibro()
        {
            int UltimoID = ControladorLibroDiario.hallarUltimoSaldo();
            LibroDiario objLibro = new LibroDiario();
            objLibro = ControladorLibroDiario.consultarID(UltimoID);
            if (objLibro != null)
            {
                VariablesPublicas.SaldoCaja =Convert.ToDecimal(objLibro.saldoCaja);
                VariablesPublicas.SaldoBanco = Convert.ToDecimal(objLibro.saldoBanco);
                VariablesPublicas.SaldoCajaMenor = Convert.ToDecimal(objLibro.saldoCajaMenor);
                VariablesPublicas.SaldoTotal= Convert.ToDecimal(objLibro.saldoTotal);
            }
            else
            {
                VariablesPublicas.SaldoCaja = 0;
                VariablesPublicas.SaldoBanco = 0;
                VariablesPublicas.SaldoCajaMenor = 0;
                VariablesPublicas.SaldoTotal = 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;

namespace SERINSI_PC.Clases
{
    public class ClassProcedure
    {
        public static void ActualizarEstadoInventario()
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    //cn.ImventarioEstadoAgotado();
                    //cn.ImventarioEstadoFull();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
        }
    }
}

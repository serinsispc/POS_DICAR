using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public  class controladorSemana
    {
        public static List<Semana> ListaCompleta()
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.Semana.AsNoTracking().ToList();
                }
            }
            catch( Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

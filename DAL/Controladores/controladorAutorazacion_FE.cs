using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controladores
{
    public class controladorAutorazacion_FE
    {
        public static  AutorizacionFacturacionElectronica consultarAutorizacion(int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    return cn.AutorizacionFacturacionElectronica.AsNoTracking().Where(x => x.idEmpresa == IdSede).FirstOrDefault();
                 }

            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}

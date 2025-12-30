using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;
using System.Windows.Forms;

namespace DAL.Controladores
{
    public class ControladorClienteTienda
    {
        public static bool Crear_Editar_Elimnar_ClienteTienda(Clientes objCT,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.Clientes.Add(objCT);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objCT).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objCT).State = System.Data.Entity.EntityState.Deleted;
                    }
                    cn.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
        public static List<V_Cliente> ListaCompleta()
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.V_Cliente.AsNoTracking().OrderBy(x=>x.ciudadCliente).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public static List<V_CuentasPC> FiltarX_Pendiente(int IdSede)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_CuentasPC.AsNoTracking().Where(x =>
                    x.idSede==IdSede &&
                    x.saldoCC > 0).OrderBy(x => x.nombreClienteCC).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static List<V_Cliente> FiltarX_Nombre(string Nombre)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.V_Cliente.AsNoTracking().Where(x=>x.nombreCliente.Contains(Nombre)).OrderBy(x => x.nombreCliente).ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static Clientes ConsultarX_Nombre(string Nombre)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.Clientes.AsNoTracking().Where(x => x.nombreCliente == Nombre).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static Clientes ConsultarX_ID(int ID)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.Clientes.AsNoTracking().Where(x => x.id == ID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static Clientes ConsultarX_NIT(string NIT)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.Clientes.AsNoTracking().Where(x => x.documentoCliente == NIT).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public static int SumarTotalCreditosPendientes()
        {
            try
            {
                using (SistemaPOSEntities cn = new SistemaPOSEntities())
                {
                    int? Suma = cn.V_CuentasPC.AsNoTracking().Sum(x => (int?)x.saldoCC);
                    if (Suma == null)
                    {
                        Suma = 0;
                    }
                    return Convert.ToInt32(Suma);
                }
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                return 0;
            }
        }
        public static List<V_Cliente> BuscadorCliente(string buscar)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    return cn.V_Cliente.AsNoTracking().Where(x => x.nombreCliente.Contains(buscar)
                    || x.razonSocialCliente.Contains(buscar)).ToList();

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

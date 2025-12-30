using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Modelo;
using System.Windows.Forms;

namespace DAL.Controladores.Tienda
{
    public class ControladorBodega
    {
        public static bool Crear_Editar_Eliminar_DivisionInventario(Bodega objDivisionInventario,int Boton)
        {
            try
            {
                using(SistemaPOSEntities cn=new SistemaPOSEntities())
                {
                    if(Boton == 0)
                    {
                        cn.Bodega.Add(objDivisionInventario);
                    }
                    if(Boton == 1)
                    {
                        cn.Entry(objDivisionInventario).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (Boton == 2)
                    {
                        cn.Entry(objDivisionInventario).State = System.Data.Entity.EntityState.Modified;
                    }
                    cn.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static List<Bodega>listaCompleta()
        {
            try
            {
                using(SistemaPOSEntities cn =new Modelo.SistemaPOSEntities())
                {
                    return cn.Bodega.AsNoTracking().ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static Bodega ConsultarX_IdVidision(int IdDivision)
        {
            try
            {
                using(SistemaPOSEntities cn=new Modelo.SistemaPOSEntities())
                {
                    return cn.Bodega.AsNoTracking().Where(x => x.id == IdDivision).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static List<Bodega> FiltroX_Division(string Division)
        {
            try
            {
                using (SistemaPOSEntities cn = new Modelo.SistemaPOSEntities())
                {
                    return cn.Bodega.AsNoTracking().Where(x => x.nombreBodega.Contains(Division)).ToList();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

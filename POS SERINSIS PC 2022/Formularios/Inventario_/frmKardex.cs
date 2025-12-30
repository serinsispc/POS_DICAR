using DAL;
using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace SERINSI_PC.Formularios.Inventario
{
    public partial class frmKardex : Form
    {
        public frmKardex()
        {
            InitializeComponent();
        }

        private void frmKardex_Load(object sender, EventArgs e)
        {

        }
        private void CargarDG(string fecha1,string fecha2)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand command = ConexionSQL.connection.CreateCommand();
                command.CommandText =
               "select " +
"pro.id, " +
"pro.codigoProducto, " +
"pro.descripcionProducto, " +

"isnull( " +
"(select SUM(cantidad) from InformeCompraProducto as compra where pro.id = compra.idProducto and " +
"compra.fechaCompra BETWEEN @fecha1 and @fecha2),0)as compras, " +

"isnull( " +
"(select SUM(cantidadDetalle) from InformeVentaProducto as venta where pro.id = venta.idProducto and " +
"venta.fechaVenta BETWEEN @fecha1 and @fecha2),0)as ventas, " +

"ISNULL( " +
"                isnull( " +
                "(select SUM(cantidad) from InformeCompraProducto as compra where pro.id = compra.idProducto and " +
"compra.fechaCompra BETWEEN @fecha1 and @fecha2), 0) - " +

"isnull( " +
"(select SUM(cantidadDetalle) from InformeVentaProducto as venta where pro.id = venta.idProducto and " +
"venta.fechaVenta BETWEEN @fecha1 and @fecha2),0) " +
",0)as saldo " +

"from Producto as pro ";
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
        }

        private void bgtnFiltrar_Click(object sender, EventArgs e)
        {
            if (dtFecha1.Value.Date == dtFecha2.Value.Date)
            {
                dtFecha2.Value = dtFecha2.Value.AddDays(1);
            }
            //CargarDG();
        }
    }
}

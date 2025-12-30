using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using SERINSI_PC.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Inventario
{
    public partial class frmDestaparCaja : Form
    {
        public frmDestaparCaja()
        {
            InitializeComponent();
        }
        string ProductoASurtir;
        string letraTipoMedidaSurtir;
        public int MedidaDestapar;
        public string CodigoP;
        int CantidadADestapar = 0;
        public int CantidadMedida=0;
        int CantidadTotal = 0;
        int TotalASurtir = 0;
        int CantidadMeditaASurtir = 0;
        int IdProductoASurtir = 0;
        public int IdProductoDestapar = 0;
        private void frmDestaparCaja_Load(object sender, EventArgs e)
        {
            texCantidadDestapar.Text = Convert.ToString(CantidadADestapar);
            texTotalUnidad.Text = Convert.ToString(CantidadTotal);
            texTotalASurtir.Text = Convert.ToString(TotalASurtir);

            //dgProducto.DataSource = classObjeto.objListaVistaProductos.Where(x => x.codigoProducto_v == CodigoP && x.cantidadUnidad_v < CantidadMedida).ToList();
        }

        private void btnSumarProducto_Click(object sender, EventArgs e)
        {
            CantidadADestapar = CantidadADestapar + 1;
            CantidadTotal = CantidadADestapar * CantidadMedida;
            texCantidadDestapar.Text = Convert.ToString(CantidadADestapar);
            texTotalUnidad.Text = Convert.ToString(CantidadTotal);
            SeleccionarProducto();
        }

        private void btnRestarProducto_Click(object sender, EventArgs e)
        {
            if (CantidadADestapar > 0)
            {
                CantidadADestapar = CantidadADestapar - 1;
                CantidadTotal = CantidadADestapar * CantidadMedida;
                texCantidadDestapar.Text = Convert.ToString(CantidadADestapar);
                texTotalUnidad.Text = Convert.ToString(CantidadTotal);
                SeleccionarProducto();
            }
        }

        private void dgProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarProducto();
        }
        private void SeleccionarProducto()
        {
            if (dgProducto.RowCount > 0 && dgProducto.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgProducto.Rows[dgProducto.CurrentRow.Index];
                IdProductoASurtir = Convert.ToInt32(fila.Cells["idVistaProducto"].Value);
                pbImagenSurtir.Image = ClassRuta.CargarProductoCategoria(VariablesPublicas.RutaImagenes,"\\Producto\\",IdProductoASurtir + ".png");
                CantidadMeditaASurtir = Convert.ToInt32(fila.Cells["cantidadUnidad"].Value);
                ProductoASurtir = Convert.ToString(fila.Cells["descripcionProducto"].Value);
                letraTipoMedidaSurtir = Convert.ToString(fila.Cells["letraTipoMedida"].Value);
                TotalASurtir = CantidadTotal / CantidadMeditaASurtir;
                texTotalASurtir.Text = Convert.ToString(TotalASurtir);
            }
        }

        private void btnTrasladar_Click(object sender, EventArgs e)
        {
            SeleccionarProducto();
            if (TotalASurtir > 0)
            {
                //ahora guardamos el moviemnto en la base de datos 
                DestapeProducto objDP = new DestapeProducto();
                objDP.id = 0;
                objDP.idUsuarioDestape = VariablesPublicas.IdUsuarioLogueado;
                objDP.fechaDestapeProducto = DateTime.Today;
                objDP.horaDestapeProducto = DateTime.Now.TimeOfDay;
                objDP.idProductoDestapar = IdProductoDestapar;
                objDP.cantidadDestapar = CantidadADestapar;
                objDP.idProductoSurtir = IdProductoASurtir;
                objDP.cantidadSurtir = TotalASurtir;
                bool sql = ControladorDestapeCaja.CrearEditarEliminarDestapeCaja(objDP, 0);
                if (sql == true)
                {
                    GestionarProducto(0, IdProductoDestapar);
                    GestionarProducto(1, IdProductoASurtir);
                }
            }
            else
            {
                Cerrar();
            }
        }
        private void GestionarProducto(int Boton,int ProductoId)
        {

        }
        private void Cerrar()
        {
            frmProduct frm = Owner as frmProduct;
            ClassProcedure.ActualizarEstadoInventario();
            frm.LimpiarFormulario();
            this.Close();
        }
    }
}

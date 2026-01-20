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

namespace SERINSI_PC.Formularios.Ventas
{
    public partial class frmDetalleFacturaCredito : Form
    {
        public int IDVenta_frm = 0;
        public int NumeroVenta=0;
        public bool HistorialVentas = false;
        int IdDetalle = 0;
        string DescripcionProducto_frm = "";
        int IdInventario_frm = 0;
        int IdProducto = 0;
        int CantidadAnterior = 0;
        int CantidadARetornar = 0;
        int CantidadActual = 0;
        decimal PrecioDetalle = 0;
        decimal TotalDetalle_frm = 0;
        public frmDetalleFacturaCredito()
        {
            InitializeComponent();
        }

        private async void frmDetalleFacturaCredito_Load(object sender, EventArgs e)
        {
            dgDetalleVenta.DataSource =await ControladorDetalleVenta.ListaDetalleVenta(IDVenta_frm);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async Task SeleccionarProducto()
        {
            if (dgDetalleVenta.RowCount > 0 && dgDetalleVenta.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgDetalleVenta.Rows[dgDetalleVenta.CurrentRow.Index];
                IdDetalle = Convert.ToInt32(fila.Cells["id"].Value);
                IdInventario_frm= Convert.ToInt32(fila.Cells["idInventario"].Value);
                //hallamos el id del producto
                DAL.Modelo.Inventario objInventario = new DAL.Modelo.Inventario();
                objInventario =await controladorInventario.ConsultarId(IdInventario_frm);
                if (objInventario != null)
                {
                    IdProducto = objInventario.idProducto;
                } 
                DescripcionProducto_frm = Convert.ToString(fila.Cells["descripcionProducto"].Value);
                PrecioDetalle= Convert.ToDecimal(fila.Cells["precioDetalleVentaV"].Value);
                TotalDetalle_frm = Convert.ToDecimal(fila.Cells["totalDetalle"].Value);
                CantidadAnterior = Convert.ToInt32(fila.Cells["cantidadDetalle"].Value);
                CantidadARetornar = CantidadAnterior;
                CantidadActual = CantidadAnterior;
                texCantidad.Text = Convert.ToString(CantidadARetornar);
            }
        }

        private void dgDetalleVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarProducto();
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            if (CantidadARetornar > 0)
            {
                if (CantidadAnterior > CantidadARetornar)
                {
                    CantidadARetornar = CantidadARetornar + 1;
                    texCantidad.Text = Convert.ToString(CantidadARetornar);
                }
            }
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            if (CantidadARetornar > 1)
            {
                CantidadARetornar = CantidadARetornar -1;
                texCantidad.Text = Convert.ToString(CantidadARetornar);
            }
        }

        private async void btnAnular_Click(object sender, EventArgs e)
        {
            CantidadActual = CantidadAnterior - CantidadARetornar;
            TotalDetalle_frm = PrecioDetalle * CantidadActual;
            if (MessageBox.Show("Esta seguro de retornar ( " + CantidadARetornar + " ) unidades del producto ( " + DescripcionProducto_frm + " )", "Retornar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DetalleVenta objDetalle = new DetalleVenta();
                objDetalle = await ControladorDetalleVenta.ConsultarX_IDDetalle(IdDetalle);
                if (objDetalle != null)
                {
                    objDetalle.cantidadDetalle = CantidadActual;
                    //objDetalle.totalDetalle = TotalDetalle_frm;
                    RespuestaCRUD sql =await ControladorDetalleVenta.GuardarEditarEliminar(objDetalle, 1);
                    if (sql.estado == true)
                    {
                        //en esta parte retornamos la cantidad anulada al inventario
                        bool retornar = RetornarInventario(CantidadARetornar);
                        if(retornar==true)
                        {
                            MessageBox.Show("Producto retornado correctamente.", "Retornado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmHistorialVentas frm = Owner as frmHistorialVentas;
                            frm.CargarDGCompleto();
                            this.Close();
                        }
                    }
                }
            }
        }
        private bool RetornarInventario(int cantidad)
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "Update Inventario set inventarioActual = inventarioActual + " + cantidad+" where idProducto="+IdProducto;
                cmd.ExecuteNonQuery();
                ConexionSQL.CerrarConexion();
                return true;
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }

    }
}

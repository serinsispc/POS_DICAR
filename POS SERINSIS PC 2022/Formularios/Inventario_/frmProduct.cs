using DAL;
using DAL.Controladores;
using DAL.Controladores.Administrador;
using DAL.Controladores.Tienda;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using POS_SERINSIS_PC_2022.Reportes;
using SERINSI_PC.Clases;
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

namespace SERINSI_PC.Formularios.Inventario
{
    public partial class frmProduct : Form
    {
        //em esta parte creamos las variables
        int IdProducto_frm;
        public frmProduct()
        {
            InitializeComponent();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dgProductos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgLista.Rows[e.RowIndex].Cells["Item"].Value = (e.RowIndex + 1).ToString();
        }

        private async void frmProduct_Load(object sender, EventArgs e)
        {
            await LlenarCMB();
            CargarGD(0);
        }
        private void CargarGD(int elimi)
        {
            dgLista.DataSource = ControladorProducto.listaCompleta(elimi);
        }
        public async Task LlenarCMB()
        {
            cmbCategoria.DataSource = null;
            cmbCategoria.ValueMember = "id";
            cmbCategoria.DisplayMember = "nombreCategoria";
            cmbCategoria.DataSource =await ControladorCategoriaProducto.ListaCompleta();
        }

        public void LimpiarFormulario()
        {
            IdProducto_frm = 0;
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
        }
        /// <summary>
        /// funcion que cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar.PerformClick();
            }
        }
        /// <summary>
        /// Evento para imrprimir la lista de producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            frm.ReporteInventario(0);
            frm.ShowDialog();
        }
        /// <summary>
        /// evento para Crear un nuevo Producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (VariablesPublicas.TipoUsuarioLogueado == "Vendedor")
            {
                return;
            }
            btn_Nuevo();
         }
        private void btn_Nuevo()
        {
            frmGestionarProducto frm = new frmGestionarProducto();
            AddOwnedForm(frm);
            frm.TipoEvento = 0;
            frm.guidProducto = Guid.NewGuid();
            frm.txtTituloFormulario.Text = "Nuevo Producto";
            frm.IdProducto = 0;
            frm.IdTipoMedida = 0;
            frm.IdEstadoProdcuto = 0;
            frm.ShowDialog();

            CargarGD(0);
        }
        /// <summary>
        /// Funcion para cambiar el estado del producto
        /// </summary>
        /// <param name="stado"></param>
        /// <param name="IdEstado"></param>
        private bool GestionarEstado(string stado,int IdEstado)
        {
            if (IdEstado == 1)
            {
                IdEstado = 2;
            }
            else if (IdEstado == 2)
            {
                IdEstado = 1;
            }
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "update Producto set idEstadoAI=" + IdEstado + " where id=" + IdProducto_frm;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            CargarGD(0);
            txtCodigo.Focus();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodigo.Text != "")
                {
                    dgLista.DataSource = ControladorProducto.FiltrarCodigo(txtCodigo.Text);
                }
                else
                {
                    CargarGD(0);
                }
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.Text != "")
            {
                dgLista.DataSource = ControladorProducto.FiltralCategoria(Convert.ToInt32(cmbCategoria.SelectedValue));
            }
            
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDescripcion.Text != "")
                {
                    dgLista.DataSource = ControladorProducto.FiltralDescripcion(txtDescripcion.Text);
                }
                else
                {
                    CargarGD(0);
                }
            }
        }

        private async void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (VariablesPublicas.TipoUsuarioLogueado == "Vendedor")
            {
                return;
            }
            if (dgLista.RowCount > 0 && dgLista.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgLista.Rows[dgLista.CurrentRow.Index];
                IdProducto_frm = Convert.ToInt32(fila.Cells["id"].Value);

                frmGestionarProducto frm = new frmGestionarProducto();
                AddOwnedForm(frm);
                frm.TipoEvento = 1;
                frm.IdProducto = IdProducto_frm;
                frm.txtTituloFormulario.Text = "Editar Producto";
                frm.txtCodigo.Text = Convert.ToString(fila.Cells["codigoProducto"].Value);
                frm.txtDescripcion.Text = Convert.ToString(fila.Cells["descripcionProducto"].Value);
                frm.IdTipoMedida = Convert.ToInt32(fila.Cells["idTipoMedida"].Value);
                frm.IdCategoria = Convert.ToInt32(fila.Cells["idCategoria"].Value);
                frm.IdEstadoProdcuto = Convert.ToInt32(fila.Cells["idEstadoAI"].Value);
                int grmaera = Convert.ToInt32(fila.Cells["gramera"].Value);
                if (Convert.ToInt32(fila.Cells["gramera"].Value) == 1)
                {
                    frm.cbGramera.Checked = true;
                }
                else
                {
                    frm.cbGramera.Checked = false;
                }
                //cargamos el guid
                Producto objpro = new Producto();
                objpro =await ControladorProducto.consultarIdProducto(IdProducto_frm);
                if (objpro != null)
                {
                    frm.guidProducto =(Guid)objpro.guidProducto;

                }
                frm.pbImagenProducto.Image = ClassRuta.CargarProductoCategoria(VariablesPublicas.RutaImagenes, "\\Productos\\",Convert.ToString(objpro.guidProducto) + ".png");
                frm.ShowDialog();
                CargarGD(0);
            }
        }

        private void btnEstadoProducto_Click(object sender, EventArgs e)
        {
            if (VariablesPublicas.TipoUsuarioLogueado == "Vendedor")
            {
                return;
            }
            if (dgLista.RowCount > 0 && dgLista.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgLista.Rows[dgLista.CurrentRow.Index];
                IdProducto_frm = Convert.ToInt32(fila.Cells["id"].Value);
                bool estado = GestionarEstado(Convert.ToString(fila.Cells["nombreEstadoAi"].Value), Convert.ToInt32(fila.Cells["idEstadoAI"].Value));
                if (estado == true)
                {
                    MessageBox.Show("El estado fue editado correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGD(0);
                }
                else
                {
                    MessageBox.Show("El estado no fue editado correctamente.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_InventarioProducto()
        {
            if (dgLista.RowCount > 0 && dgLista.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgLista.Rows[dgLista.CurrentRow.Index];

                IdProducto_frm = Convert.ToInt32(fila.Cells["id"].Value);

                frmGestionarInventario frm = new frmGestionarInventario();
                AddOwnedForm(frm);
                frm.IdProducto_frm = IdProducto_frm;
                frm.tituloFormulario.Text = Convert.ToString(fila.Cells["descripcionProducto"].Value);
                frm.tipoMedida_frm = Convert.ToString(fila.Cells["nombreTipoMedida"].Value);
                frm.ShowDialog();

            }
        }
        private void btnInventarioProducto_Click(object sender, EventArgs e)
        {
            if (VariablesPublicas.TipoUsuarioLogueado == "Vendedor")
            {
                return;
            }
            btn_InventarioProducto();
        }

        private void btnCodigoProducto_Click(object sender, EventArgs e)
        {
            if (dgLista.RowCount > 0 && dgLista.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgLista.Rows[dgLista.CurrentRow.Index];
                IdProducto_frm = Convert.ToInt32(fila.Cells["id"].Value);
                frmCodigoBarra frm = new frmCodigoBarra();
                AddOwnedForm(frm);
                frm.pbCodigo.Image = CrearCodigoBarra.GenerarCodigoBarra(Convert.ToString(fila.Cells["codigoProducto"].Value));
                frm.DescripcionCodigo = Convert.ToString(fila.Cells["descripcionProducto"].Value);
                //en esta prte hallamos el precio del producto
                frm.PrecioCodigo = ConsultarPrecioProducto();
                frm.ShowDialog();
            }
        }
        private decimal ConsultarPrecioProducto()
        {
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                cmd.CommandText = "select *from v_productoVenta where id="+IdProducto_frm+" and idSede="+VariablesPublicas.IdEmpresaLogueada;
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                ConexionSQL.CerrarConexion();
                if (dt.Rows.Count > 0)
                {
                    if(dt.Rows.Count > 1)
                    {
                        MessageBox.Show("El producto "+descripcionProducto+" tiene más de una presentación por lo tanto el código se generará sin precio.", "¡Alerta!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        return 0;
                    }
                    foreach(DataRow rows in dt.Rows)
                    {
                        return (decimal)rows["PrecioVenta"];
                    }
                }
 
                    return 0;
                
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return 0;
            }
        }

        private async void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (VariablesPublicas.TipoUsuarioLogueado == "Vendedor")
            {
                return;
            }
            if (dgLista.RowCount > 0 && dgLista.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgLista.Rows[dgLista.CurrentRow.Index];
                IdProducto_frm = Convert.ToInt32(fila.Cells["id"].Value);
                InventarioTotal inventarioTotal = new InventarioTotal();
                inventarioTotal =await controladorInventarioTotal.ConsultarIdProducto(IdProducto_frm,VariablesPublicas.IdEmpresaLogueada);
                if (inventarioTotal != null)
                {
                    RespuestaCRUD sqlEliminar =await controladorInventarioTotal.CrearEditarEliminarInventarioTotal(inventarioTotal,2);
                }
                //cargamos el guid
                Producto objpro = new Producto();
                objpro =await ControladorProducto.consultarIdProducto(IdProducto_frm);
                if (objpro != null)
                {
                    objpro.eliminado = 1;
                    await ControladorProducto.GuardarEditarEliminarProducto(objpro,1);
                    RespuestaCRUD sql =await ControladorProducto.GuardarEditarEliminarProducto(objpro,2);
                    if (sql.estado == true)
                    {
                        CargarGD(0);
                    }
                }
                MessageBox.Show("¡Producto eliminado correctamente.!","¡Ok!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void frmProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btn_Nuevo();
            }
            if (e.KeyCode == Keys.F4)
            {
                btn_InventarioProducto();
            }
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cbEliminados_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEliminados.Checked == true)
            {
                CargarGD(1);
            }
            else
            {
                CargarGD(0);
            }
        }

        private async void btnListaPrecios_Click(object sender, EventArgs e)
        {
            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            await frm.ListaPrecios();
            frm.ShowDialog();
        }

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            await frm.ListaCostoIventario();
            frm.ShowDialog();
        }
    }
}

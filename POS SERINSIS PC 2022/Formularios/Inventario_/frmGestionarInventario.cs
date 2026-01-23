using DAL;
using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using POS_SERINSIS_PC_2022.Formularios;
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
    public partial class frmGestionarInventario : Form
    {
        public frmGestionarInventario()
        {
            InitializeComponent();
        }
        //declaramos las variables a usar
        public int IdProducto_frm = 0;
        int IdInventario_frm = 0;
        public string tipoMedida_frm = "";

        decimal porcentajeUtilidad_frm = 0;
        decimal porcentajeIVA_frm = 0;
        decimal costo_frm = 0;
        decimal precioPublico_frm = 0;
        decimal valorUtilidad_frm = 0;
        Guid guidInventario_frm;
        decimal cantidadTotalUnidad_frm = 0;
        decimal contenidoPresentacion_frm = 0;
        decimal stock_frm = 0;
        private void MostarValores()
        {
            int p_Utilidad =Convert.ToInt32(porcentajeUtilidad_frm);
            int p_iva = Convert.ToInt32(porcentajeIVA_frm);
            int costo = Convert.ToInt32(costo_frm);
            int precioPublico = Convert.ToInt32(precioPublico_frm);
            int valorUtilidad = Convert.ToInt32(valorUtilidad_frm);

            txtPorcentajeUtilidad.Text =Convert.ToString(p_Utilidad);
            txtPorcentajeIVA.Text = Convert.ToString(p_iva);
            txtCosto.Text = Convert.ToString(costo);
            txtPrecioPublico.Text = Convert.ToString(precioPublico);
            txtValorUtilidad.Text = Convert.ToString(valorUtilidad);

        }
        private async void frmGestionarInventario_Load(object sender, EventArgs e)
        {
            FrmLoading loading = null;
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    loading = FrmLoading.ShowLoading(this, "Cargarndo...");
                    // inicio


                    await CargarDG();
                    await CargarPresentacion();
                    GestionarBotones(0);
                    await CargarListaPrecio();

                    await SeleccionarInventario();
                    await CargarDGPrecios();


                    // fin
                    FrmLoading.CloseLoading(this, loading);
                }
            }
            catch (Exception ex)
            {
                FrmLoading.CloseLoading(this, loading);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtPrecioPublico.Focus();
            }


            
        }
        private async Task CargarListaPrecio()
        {
            cmbListaPrecios.DataSource = null;
            cmbListaPrecios.ValueMember = "id";
            cmbListaPrecios.DisplayMember = "nombreLista";
            cmbListaPrecios.DataSource =await controladorListaPrecios.ListaCompleta();
        }
        private async Task CargarPresentacion()
        {
            cmbPresentacion.DataSource = null;
            cmbPresentacion.ValueMember = "id";
            cmbPresentacion.DisplayMember = "nombrePresentacion";
            cmbPresentacion.DataSource =await controladorPresentacion.ListaCompleta();
        }
        private async void lbAgregarPresentacion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPresentacion frm = new frmPresentacion();
            AddOwnedForm(frm);
            frm.tituloFormulario.Text = "Gestionar Presentación";
            frm.ShowDialog();
            await CargarPresentacion();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarCampos()
        {
            if(cmbPresentacion.Text!="" &&
               txtContenido.Text!=""&&
               txtInventarioPresentacion.Text!=""&&
               txtPorcentajeUtilidad.Text!=""&&
               txtPorcentajeIVA.Text!=""&&
               txtCosto.Text!=""&&
               cmbListaPrecios.Text!=""&&
               txtPrecioPublico.Text!=""&&
               txtValorUtilidad.Text!=""&&
               txtPorcentajeDescuento.Text!="")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtContenido_KeyPress(object sender, KeyPressEventArgs e)

        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtContenido.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtInventarioPresentacion.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private async Task SeleccionarInventario()
        {
            try
            {
                if (dgPrecentaciones.RowCount > 0 && dgPrecentaciones.CurrentRow.Index >= 0)
                {
                    DataGridViewRow fila = dgPrecentaciones.Rows[dgPrecentaciones.CurrentRow.Index];
                    IdInventario_frm = Convert.ToInt32(fila.Cells["id"].Value);
                    IdProducto_frm = Convert.ToInt32(fila.Cells["idProducto"].Value);
                    cmbPresentacion.SelectedValue = Convert.ToInt32(fila.Cells["idPresentacion"].Value);
                    txtContenido.Text = Convert.ToString(fila.Cells["contenidoPresentacion"].Value);
                    contenidoPresentacion_frm = Convert.ToDecimal(fila.Cells["contenidoPresentacion"].Value);

                   

                    //en esta parte hallamos el inventario total
                    InventarioTotal inventarioTotal = new InventarioTotal();
                    inventarioTotal =await controladorInventarioTotal.ConsultarIdProducto(IdProducto_frm,VariablesPublicas.IdEmpresaLogueada);
                    if (inventarioTotal != null)
                    {
                        cantidadTotalUnidad_frm =Convert.ToDecimal(inventarioTotal.inventarioInical);
                        stock_frm = Convert.ToDecimal(inventarioTotal.stockInvetario)/ contenidoPresentacion_frm;
                        porcentajeIVA_frm =Convert.ToDecimal(inventarioTotal.porcentajeIVA);
                        costo_frm = Convert.ToDecimal(inventarioTotal.costoUnidad)*contenidoPresentacion_frm;
                        txtPorcentajeDescuento.Text = Convert.ToString(inventarioTotal.porcentajeDescuento);
                    }

                    decimal xx = Convert.ToDecimal(cantidadTotalUnidad_frm) / Convert.ToDecimal(contenidoPresentacion_frm);

                    txtInventarioPresentacion.Text = Convert.ToString(xx);
                    txtStock.Text = Convert.ToString(stock_frm);
                    txtINVTotal.Text = Convert.ToString(cantidadTotalUnidad_frm);

                    //consultamos Precios por el idInventario
                    Precios objPrecios = new Precios();
                    objPrecios =await controladorPrecio.ConsultarIdInventario(IdInventario_frm);
                    if (objPrecios != null)
                    {
                        cmbListaPrecios.SelectedValue = Convert.ToInt32(objPrecios.idListaPrecios);
                        precioPublico_frm =Convert.ToDecimal(objPrecios.PrecioVenta);
                        valorUtilidad_frm =Convert.ToDecimal(objPrecios.utilidad);
                    }
                    MostarValores();
                    GestionarBotones(1);
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }

        }
        private void GestionarBotones(int Boton)
        {
            if (Boton == 0)
            {
                btnGuardar.Text = "Crear";
                btnEliminar.Enabled = false;
            }
            else
            {
                btnGuardar.Text = "Editar";
                btnEliminar.Enabled = true;
            }
        }
        private async Task GestionarInventarioTotal(int Boton)
        {
            //primero verificamos que el produco no tenga inventario total
            InventarioTotal inventarioTotal = new InventarioTotal();
            inventarioTotal =await controladorInventarioTotal.ConsultarIdProducto(IdProducto_frm, VariablesPublicas.IdEmpresaLogueada);
            if (inventarioTotal == null)
            {
                inventarioTotal = new InventarioTotal();
                inventarioTotal.id = 0;
                inventarioTotal.idSede = VariablesPublicas.IdEmpresaLogueada;
                inventarioTotal.idProducto = IdProducto_frm;
                inventarioTotal.costoUnidad = Convert.ToDecimal(txtCosto.Text) / Convert.ToDecimal(txtContenido.Text);
                inventarioTotal.porcentajeIVA = Convert.ToDecimal(txtPorcentajeIVA.Text);
                inventarioTotal.stockInvetario = Convert.ToDecimal(txtStock.Text)* Convert.ToDecimal(txtContenido.Text);
                inventarioTotal.inventarioInical = Convert.ToDecimal(txtINVTotal.Text);
                inventarioTotal.porcentajeDescuento =Convert.ToDecimal(txtPorcentajeDescuento.Text);
            }
            else
            {
                Boton = 1;
                if (MessageBox.Show("¿desea reemplazar inventario?", "¡Reemplezar!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    inventarioTotal.costoUnidad = Convert.ToDecimal(txtCosto.Text) / Convert.ToDecimal(txtContenido.Text);
                    inventarioTotal.porcentajeIVA = Convert.ToDecimal(txtPorcentajeIVA.Text);                
                    inventarioTotal.inventarioInical = Convert.ToDecimal(txtINVTotal.Text);
                }
                else
                {
                    inventarioTotal.inventarioInical = inventarioTotal.inventarioInical+Convert.ToDecimal(txtINVTotal.Text);
                    inventarioTotal.costoUnidad = Convert.ToDecimal(txtCosto.Text) / Convert.ToDecimal(txtContenido.Text);
                }
                inventarioTotal.porcentajeDescuento = Convert.ToDecimal(txtPorcentajeDescuento.Text);
                inventarioTotal.stockInvetario = Convert.ToDecimal(txtStock.Text) * Convert.ToDecimal(txtContenido.Text);
            }
            RespuestaCRUD crudInvnetarioTotal =await controladorInventarioTotal.CrearEditarEliminarInventarioTotal(inventarioTotal,Boton);
            if (crudInvnetarioTotal.estado == false)
            {
                MessageBox.Show("El producto " + tituloFormulario.Text + " no se pudo agregar.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await GestionarInventario(Boton);
        }
        private async Task GestionarInventario(int Boton)
        {
            //hora gestionamos la tabla inventario 
            DAL.Modelo.Inventario objInventario = new DAL.Modelo.Inventario();
            objInventario =await controladorInventario.ConsultarIdProducto_IdPresentacion(IdProducto_frm, Convert.ToInt32(cmbPresentacion.SelectedValue), VariablesPublicas.IdEmpresaLogueada);
            if (objInventario != null)
            {
                if (Boton == 0)
                {
                    Boton = 1;
                }

                IdInventario_frm = objInventario.id;
            }
            else
            {
                Boton = 0;
            }
            if (Boton == 0)
            {
                guidInventario_frm = Guid.NewGuid();
                IdInventario_frm = 0;
                objInventario = new DAL.Modelo.Inventario();
            }
            objInventario.id = IdInventario_frm;
            objInventario.idProducto = IdProducto_frm;
            objInventario.idPresentacion = Convert.ToInt32(cmbPresentacion.SelectedValue);
            objInventario.contenidoPresentacion = Convert.ToDecimal(txtContenido.Text);
            objInventario.idSede = VariablesPublicas.IdEmpresaLogueada;
            objInventario.guidInventario = guidInventario_frm;
            RespuestaCRUD sql =await controladorInventario.CrearEditarEliminarInventario(objInventario, Boton);
            if (sql.estado == true)
            {
                if (Boton == 2)
                {
                    await CargarDG();
                    LimpiarFormulario();
                    GestionarBotones(0);
                    return;
                }
                ////consultamos el id del nventario con el guid
                //DAL.Modelo.Inventario objINV = new DAL.Modelo.Inventario();
                //objINV = controladorInventario.ConsultarGuid( IdProducto_frm, VariablesPublicas.IdEmpresaLogueada);
                //if (objINV != null)
                //{
                //    IdInventario_frm = objINV.id;
                //}

                await GestionarPrecios();
            }
            else
            {
                MessageBox.Show("A ocurrido un error inesperado y no se guardó el inventario.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task GestionarPrecios()
        {
            int Boton = 0;
            int IdPrecios = 0;
            Precios objPrecios = new Precios();
            objPrecios =await controladorPrecio.Consultar_IdProducto_IdINventario_IdListaPrecios(IdProducto_frm,IdInventario_frm,Convert.ToInt32(cmbListaPrecios.SelectedValue));
            if (objPrecios != null)
            {
                Boton = 1;
                IdPrecios = objPrecios.id;
            }
            else
            {
                Boton = 0;
                objPrecios = new Precios();
            }
            objPrecios.id = IdPrecios;
            objPrecios.idProducto = IdProducto_frm;
            objPrecios.idInventario = IdInventario_frm;
            objPrecios.idListaPrecios = Convert.ToInt32(cmbListaPrecios.SelectedValue);
            objPrecios.utilidad = valorUtilidad_frm;
            objPrecios.PrecioVenta = precioPublico_frm;
            objPrecios.porcentajeUtilidad = porcentajeUtilidad_frm;
            RespuestaCRUD sql =await controladorPrecio.CrearEditarEliminarCostoPrecio(objPrecios,Boton);
            if (sql.estado == true)
            {
                await CargarDG();
                LimpiarFormulario();
                GestionarBotones(0);
            }
        }
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            bool campos = ValidarCampos();
            if (campos == true)
            {
                await GestionarInventario(2);
                await CargarDG();
                LimpiarFormulario();
                GestionarBotones(0);
            }
        }
        private async Task btn_Guardar()
        {
            bool campos = ValidarCampos();
            if (campos == true)
            {
                if (btnGuardar.Text == "Editar")
                {
                    await GestionarInventarioTotal(1);
                }
                else
                {
                    await GestionarInventarioTotal(0);
                }
                await SeleccionarInventario();
                await CargarDGPrecios();

                txtPrecioPublico.Focus();
            }
            else
            {
                MessageBox.Show("¡Aún hay campos vacíos...!", "¡Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            await btn_Guardar();
        }
        private async Task CargarDG()
        {
            dgProducto.DataSource =await controladorInventarioTotal.Filtrar_IdSede_IdProducto(VariablesPublicas.IdEmpresaLogueada,IdProducto_frm);
            dgPrecentaciones.DataSource =await controladorInventario.ListaCompleta(IdProducto_frm,VariablesPublicas.IdEmpresaLogueada);
        }

        private async void dgInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            await SeleccionarInventario();
            await CargarDGPrecios();
        }
        private async Task CargarDGPrecios()
        {
            dgPrecios.DataSource =await controladorPrecio.ListaCompleta(IdInventario_frm,VariablesPublicas.IdEmpresaLogueada);
        }
        private void LimpiarFormulario()
        {
            cmbPresentacion.SelectedIndex = -1;
            cmbListaPrecios.SelectedIndex = -1;
            txtPorcentajeDescuento.Text = "";
            txtContenido.Text = "";
            txtInventarioPresentacion.Text = "";
            txtPorcentajeUtilidad.Text = "";
            txtPorcentajeIVA.Text = "";
            txtCosto.Text = "";
            cmbListaPrecios.SelectedIndex = 0;
            txtPrecioPublico.Text = "";
            txtValorUtilidad.Text = "";

            IdInventario_frm = 0;
            porcentajeUtilidad_frm = 0;
            porcentajeIVA_frm = 0;
            costo_frm = 0;
            precioPublico_frm = 0;
            valorUtilidad_frm = 0;

            GestionarBotones(0);

        }

        private void frmGestionarInventario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                LimpiarFormulario();
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar.PerformClick();
            }
            if (e.KeyCode == Keys.F12)
            {
                btn_Guardar();
            }
        }

        private void txtContenido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode==Keys.Tab)
            {
                txtInventarioPresentacion.Focus();
            }
        }

        private void txtInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtInventarioPresentacion.Focus();
            }
        }

        private void txtMaximo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtPorcentajeUtilidad.Focus();
            }
        }

        private void txtPorcentajeUtilidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtPrecioPublico.Focus();
            }
        }

        private void cmbUtilidadAplicada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtPorcentajeIVA.Focus();
            }
        }

        private void txtPorcentajeIVA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtCosto.Focus();
            }
        }

        private void txtValorUtilidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnGuardar.Focus();
            }
        }

        private void lbAgregarLista_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmListaPrecios frm = new frmListaPrecios();
            AddOwnedForm(frm);
            frm.tituloFormulario.Text = "Gestionar Lista de Precios";
            frm.ShowDialog();
            CargarListaPrecio();
        }

        private void txtCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtPorcentajeUtilidad.Focus();
            }
        }

        private void txtPorcentajeUtilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtPorcentajeUtilidad.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtPorcentajeIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtPorcentajeIVA.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtCosto.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtPrecioPublico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtPrecioPublico.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtValorUtilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (txtValorUtilidad.Text.Contains(",") == true && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void btnCalcularPorcentage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnCalcularPrecio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CalcularPrecioPublico();
        }
        private void CalcularPrecioPublico()
        {
            if (txtCosto.Text != "")
            {
                costo_frm = Convert.ToDecimal(txtCosto.Text);
                if (txtPrecioPublico.Text != "")
                {
                    precioPublico_frm = Convert.ToDecimal(txtPrecioPublico.Text);
                    valorUtilidad_frm = precioPublico_frm - costo_frm;
                    if (costo_frm == 0)
                    {
                        porcentajeUtilidad_frm = 100;
                    }
                    else
                    {
                        porcentajeUtilidad_frm = (valorUtilidad_frm * 100) / costo_frm;
                    }

                    if (txtPorcentajeIVA.Text != "" && txtPrecioPublico.Text != "")
                    {
                        porcentajeIVA_frm = Convert.ToDecimal(txtPorcentajeIVA.Text);
                        string x = "1," + txtPorcentajeIVA.Text;
                        decimal p1 = Convert.ToDecimal(txtPrecioPublico.Text) / Convert.ToDecimal(x);
                        decimal iva = Convert.ToDecimal(txtPrecioPublico.Text) - p1;
                        txtValorIva.Text = Convert.ToString(Convert.ToInt32(iva));
                    }

                    MostarValores();
                }
                else
                {
                    MessageBox.Show("Para poder calcular el precio venta debe de ingresar el precio venta", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrecioPublico.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Para poder calcular el precio venta debe de ingresar el costo unitario", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgPrecios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgPrecios.RowCount > 0 && e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgPrecios.Rows[e.RowIndex];
                cmbListaPrecios.SelectedValue = Convert.ToInt32(fila.Cells["idListaPrecios_v"].Value);
                precioPublico_frm = Convert.ToDecimal(fila.Cells["PrecioVenta_v"].Value);
                valorUtilidad_frm = Convert.ToDecimal(fila.Cells["utilidad_v"].Value);
                porcentajeUtilidad_frm = Convert.ToDecimal(fila.Cells["porcentajeUtilidad_v"].Value);

                MostarValores();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CargarDG();
            LimpiarFormulario();
            GestionarBotones(0);
        }

        private void dgPrecios_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnCalcularPorcentageIVA_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCosto.Text != "")
            {
                costo_frm =Convert.ToDecimal(txtCosto.Text);
                if (txtPorcentajeUtilidad.Text != "")
                {
                    porcentajeUtilidad_frm = Convert.ToDecimal(txtPorcentajeUtilidad.Text);
                    valorUtilidad_frm = (porcentajeUtilidad_frm * costo_frm) / 100;
                    int UtilidadEntero = Convert.ToInt32(valorUtilidad_frm);
                    valorUtilidad_frm = Convert.ToDecimal(UtilidadEntero);

                    precioPublico_frm = costo_frm + valorUtilidad_frm;
                    int precioEntero = Convert.ToInt32(precioPublico_frm);
                    precioPublico_frm = Convert.ToDecimal(precioEntero);

                    MostarValores();
                }
            }
            else
            {
                MessageBox.Show("Para poder calcular el porcentaje utilidad debe de ingresar el costo unitario", "¡Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void cmbPresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtContenido.Focus();
        }

        private void txtInventarioPresentacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtStock.Focus();
            }
        }

        private void txtINVTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPorcentajeIVA.Focus();
            }
        }

        private void txtStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtINVTotal.Focus();
            }
        }

        private void btnCalcularTotalUnidad_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtContenido.Text) > 0 && Convert.ToDecimal(txtInventarioPresentacion.Text)>=0)
                {
                    decimal totalUnidad=Convert.ToDecimal(txtContenido.Text) * Convert.ToDecimal(txtInventarioPresentacion.Text);
                    txtINVTotal.Text = Convert.ToString(totalUnidad);
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
        }

        private async void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿está seguro de eliminar el precio seleccionado?", "¡Eliminar!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (dgPrecios.RowCount > 0 && dgPrecios.CurrentRow.Index >= 0)
                {
                    DataGridViewRow fila = dgPrecios.Rows[dgPrecios.CurrentRow.Index];
                    int idPrecio = Convert.ToInt32(fila.Cells["id_v"].Value);
                    cmbListaPrecios.SelectedValue = Convert.ToInt32(fila.Cells["idListaPrecios_v"].Value);
                    precioPublico_frm = Convert.ToDecimal(fila.Cells["PrecioVenta_v"].Value);
                    valorUtilidad_frm = Convert.ToDecimal(fila.Cells["utilidad_v"].Value);

                    MostarValores();

                    Precios objPrecios = new Precios();
                    objPrecios =await controladorPrecio.ConsultarId(idPrecio);
                    if (objPrecios != null)
                    {
                        RespuestaCRUD sql =await controladorPrecio.CrearEditarEliminarCostoPrecio(objPrecios, 2);
                        if (sql.estado == true)
                        {
                            await CargarDGPrecios();
                        }
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtPrecioPublico_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (txtPrecioPublico.Text != "")
                {
                    CalcularPrecioPublico();
                    btnGuardar.PerformClick();
                }
            }
        }
    }
}

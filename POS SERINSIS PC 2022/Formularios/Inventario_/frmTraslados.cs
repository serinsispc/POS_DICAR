using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using POS_SERINSIS_PC_2022.Reportes;
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
    public partial class frmTraslados : Form
    {
        int IdProducto = 0;
        int IdSalida = 0;
        int IdEntrada = 0;
        string GuidTex = "";
        string TipoTraslado = "";
        int IdDetalle = 0;
        int IdTraslado = 0;
        public frmTraslados()
        {
            InitializeComponent();
        }
      
        private void frmTraslados_Load(object sender, EventArgs e)
        {
            CargarCMB();
            ConsultarGuidActivo();
            CargarFormulario();
            CargarBuscador();
        }
        private void CargarCMB()
        {
            cmbSedes.DataSource = null;
            cmbSedes.ValueMember = "id_configuracion";
            cmbSedes.DisplayMember = "nombre_empresa";
            cmbSedes.DataSource = ControladorSede.listaCompleta();
        }
        private void ConsultarGuidActivo()
        {
            GuidTraslados objGui = new GuidTraslados();
            objGui = controladorGuidTraslado.Consultar_IdSede_Estado(VariablesPublicas.IdEmpresaLogueada,1);
            if (objGui != null)
            {
                GuidTex = objGui.guidTex;
            }
            else
            {
                //lo primero que hacemos es generar el Guid
                var guid = Guid.NewGuid();
                GuidTex = Convert.ToString(guid).ToUpper();
                objGui = new GuidTraslados();
                objGui.id = 0;
                objGui.idSedeTraslado = VariablesPublicas.IdEmpresaLogueada;
                objGui.guidTex = GuidTex;
                objGui.estadoGuidTraslado = 1;
                bool sql = controladorGuidTraslado.CrearEditarEliminar_GuidTraslado(objGui, 0);
            }
        }
        private void CargarFormulario()
        {
            CargarDGDetalle();

            Traslados objTraslado = new Traslados();
            objTraslado = controladorTraslado.ConsultarGuid(GuidTex);
            if (objTraslado != null)
            {
                if (objTraslado.tipoTraslado == "ingreso")
                {
                    cbIngresarProducto.Checked = true;
                    cbRetirarProducto.Checked = false;
                }
                else
                {
                    cbIngresarProducto.Checked = false;
                    cbRetirarProducto.Checked = true;
                }
                txtDescripcionTraslado.Text = objTraslado.descripcionTraslado;

                IdTraslado = objTraslado.id;
            }
        }
        private void cbIngresarProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIngresarProducto.Checked == true)
            {
                cbRetirarProducto.Checked = false;
            }
            else
            {
                cbRetirarProducto.Checked = true;
            }
        }

        private void txtBuscadorProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscadorProducto.Text != "")
            {
               //dgBuscarProducto.DataSource = ControladorProducto.filtrar_codigo_descripcion(txtBuscadorProducto.Text,VariablesPublicas.IdEmpresaLogueada);
            }
            else
            {
                CargarBuscador();
            }
        }
        private void CargarBuscador()
        {
            //dgBuscarProducto.DataSource= ControladorProducto.ListaCompletaBuscador(VariablesPublicas.IdEmpresaLogueada);
        }

        private void cbRetirarProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRetirarProducto.Checked == true)
            {
                cbIngresarProducto.Checked = false;
                leyendaRetiro.Visible = true;
                leyendaIngreso.Visible = false;
                //cmbSedes.Visible = true;
            }
            else
            {
                cbIngresarProducto.Checked = true;
                leyendaRetiro.Visible = false;
                leyendaIngreso.Visible = true;
                //cmbSedes.Visible = false;
            }
        }

        private void btnCargarProducto_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                errorProvider1.SetError(txtCantidad, "");
                SeleccionarProducto();
                if (IdProducto > 0)
                {
                    errorProvider1.SetError(dgBuscarProducto, "");
                    if (cbRetirarProducto.Checked==true || cbIngresarProducto.Checked == true)
                    {
                        errorProvider1.SetError(cbIngresarProducto, "");
                        if (cbIngresarProducto.Checked == true)TipoTraslado = "ingreso";
                        if (cbRetirarProducto.Checked == true)TipoTraslado = "retiro";
                        //en esta parte llamamos la funcion que se encarga de Gestionar el Detalle del traslado
                        bool detalle = GestionarDetalleTraslado(0);
                        if (detalle == true)
                        {
                            if(TipoTraslado== "ingreso")
                            {
                                ActualizarInventario(1,Convert.ToInt32(txtCantidad.Text));
                            }
                            else
                            {
                                ActualizarInventario(0, Convert.ToInt32(txtCantidad.Text));
                            }
                            CargarDGDetalle();
                            CargarBuscador();
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(cbIngresarProducto, "Debe seleccionar una de las dos opciones.");
                    }
                }
                else
                {
                    errorProvider1.SetError(dgBuscarProducto, "Debe seleccionar un producto.");
                }
            }
            else
            {
                errorProvider1.SetError(txtCantidad, "Debe de escribir la cantidad que desea trasladar.");
                txtCantidad.Focus();
            }
        }
        private void ActualizarInventario(int Boton,int Cantidad)
        {
            Producto objProducto = new Producto();
            objProducto = ControladorProducto.consultarIdProducto(IdProducto);
            if (objProducto != null)
            {

                bool sql = ControladorProducto.GuardarEditarEliminarProducto(objProducto,1);
            }
        }
        private bool GestionarDetalleTraslado(int Boton)
        {
            DetalleTraslado objDetalle = new DetalleTraslado();
            objDetalle = controladorDetalleTraslado.consultar_IdDetalle(IdDetalle);
            if (objDetalle != null)
            {
                if(Boton == 0)
                {
                    errorProvider1.SetError(btnCargarProducto, "el detalle que desea agregar ya existe.");
                    return false;
                }
            }
            if(Boton == 0)
            {
                objDetalle = new DetalleTraslado();
                IdDetalle = 0;
            }
            if (Boton != 2)
            {
                objDetalle.id = IdDetalle;
                objDetalle.guidDetalleTraslado = GuidTex;
                objDetalle.idProductoTraslado = IdProducto;
                objDetalle.cantidadproductoTraslado = Convert.ToInt32(txtCantidad.Text);
            }
            bool sql = controladorDetalleTraslado.CrearEditarEliminar_DetalleTraslado(objDetalle,Boton);
            if (sql == true)
            {
                errorProvider1.SetError(btnCargarProducto, "");
                return true;
            }
            else
            {
                errorProvider1.SetError(btnCargarProducto, "El proceso no se puco completar correctamente.");
                return false;
            }
        }
        private void SeleccionarDetalle()
        {
            if(dgDetalleTraslado.RowCount>0 && dgDetalleTraslado.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgDetalleTraslado.Rows[dgDetalleTraslado.CurrentRow.Index];

                IdDetalle = Convert.ToInt32(fila.Cells["v_id"].Value);
                IdProducto = Convert.ToInt32(fila.Cells["v_idProductoTraslado"].Value);
                txtCantidad.Text = Convert.ToString(fila.Cells["v_cantidadproductoTraslado"].Value);
                btnEliminarProducto.Enabled = true;
            }
        }
        private void CargarDGDetalle()
        {
            dgDetalleTraslado.DataSource = controladorDetalleTraslado.Filtrar_Guid(GuidTex);
        }
        private void SeleccionarProducto()
        {
            if (dgBuscarProducto.RowCount > 0 &&
               dgBuscarProducto.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgBuscarProducto.Rows[dgBuscarProducto.CurrentRow.Index];
                IdProducto = Convert.ToInt32(fila.Cells["id_buscador"].Value);
            }
        }
        private void GestionarProductoTraslado()
        {

        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void txtBuscadorProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down &&
                dgBuscarProducto.RowCount > 0 &&
                dgBuscarProducto.CurrentRow.Index >= 0) dgBuscarProducto.Focus();
            if (e.KeyCode == Keys.Enter &&
                dgBuscarProducto.RowCount>0 &&
                dgBuscarProducto.CurrentRow.Index>=0) txtCantidad.Focus();
            if (e.KeyCode == Keys.Tab) txtCantidad.Focus();
        }

        private void dgBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter &&
                dgBuscarProducto.RowCount > 0 &&
                dgBuscarProducto.CurrentRow.Index >= 0) txtCantidad.Focus();
            if (e.KeyCode == Keys.Tab) txtCantidad.Focus();
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter ||
                e.KeyCode==Keys.Tab) btnCargarProducto.Focus();
           
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if(dgDetalleTraslado.RowCount>0 && dgDetalleTraslado.CurrentRow.Index >= 0)
            {
                if (IdDetalle > 0)
                {
                    //en esta parte eliminar el producto de la lista de detalle
                    GestionarDetalleTraslado(2);
                    if (IdProducto > 0)
                    {
                        if (cbIngresarProducto.Checked == true ||
                           cbRetirarProducto.Checked == true)
                        {
                            errorProvider1.SetError(btnEliminarProducto, "");
                            if (cbIngresarProducto.Checked == true) ActualizarInventario(0, Convert.ToInt32(txtCantidad.Text));
                            if (cbRetirarProducto.Checked == true) ActualizarInventario(1, Convert.ToInt32(txtCantidad.Text));

                            LimpiarFormulario();
                            CargarBuscador();
                        }
                        else
                        {
                            errorProvider1.SetError(btnEliminarProducto, "Debe de seleccionar si el traslado es un retiro o un ingreso.");
                        }
                    }
                }
            }
        }
        private void LimpiarFormulario()
        {
            IdDetalle = 0;
            IdProducto = 0;
            txtCantidad.Text = "";
            txtDescripcionTraslado.Text = "";

            CargarFormulario();
        }

        private void dgDetalleTraslado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarDetalle();
        }

        private void btnGuardarTraslado_Click(object sender, EventArgs e)
        {
            if (dgDetalleTraslado.RowCount <= 0)
            {
                errorProvider1.SetError(btnGuardarTraslado, "No se han encontrado productos agregados.");
                return;
            }
            else
            {
                errorProvider1.SetError(btnGuardarTraslado, "");
            }
            if (txtDescripcionTraslado.Text == "")
            {
                errorProvider1.SetError(txtDescripcionTraslado, "Debe diligenciar el campo de descripción traslado.");
                txtDescripcionTraslado.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtDescripcionTraslado, "");
            }
            if (cbRetirarProducto.Checked == true)
            {
                if (cmbSedes.Text == "")
                {
                    errorProvider1.SetError(cmbSedes, "Debe de seleccionar una sede o bodega.");
                    return;
                }
                else
                {
                    errorProvider1.SetError(cmbSedes, "");
                }
            }
            Traslados objtraslados = new Traslados();
            objtraslados = controladorTraslado.ConsultarGuid(GuidTex);
            if (objtraslados != null)
            {
                errorProvider1.SetError(btnGuardarTraslado, "El traslado que se desea hacer ya existe.");
                return;
            }
            else
            {
                errorProvider1.SetError(btnGuardarTraslado, "");
            }
            objtraslados = new Traslados();
            objtraslados.id = IdTraslado;
            objtraslados.fechaTraslado = DateTime.Now;
            objtraslados.idusuarioTraslado = VariablesPublicas.IdUsuarioLogueado;
            objtraslados.idSedeTraslado = VariablesPublicas.IdEmpresaLogueada;
            objtraslados.tipoTraslado = TipoTraslado;
            objtraslados.guidTraslado = GuidTex;
            objtraslados.descripcionTraslado = txtDescripcionTraslado.Text;
            if (cbRetirarProducto.Checked == true)
            {
                objtraslados.sedeEnvio = VariablesPublicas.NombreEmpresa;
                objtraslados.sedeRecibido = cmbSedes.Text;
                objtraslados.tipoTraslado = "Retiro";
            }
            else
            {
                objtraslados.sedeEnvio = cmbSedes.Text;
                objtraslados.sedeRecibido = VariablesPublicas.NombreEmpresa;
                objtraslados.tipoTraslado = "Ingreso";
            }
            bool sql = controladorTraslado.CrearEditarEliminarTraslado(objtraslados,0);
            if (sql == true)
            {
                errorProvider1.SetError(btnGuardarTraslado, "");
                GuidTraslados objGui = new GuidTraslados();
                objGui = controladorGuidTraslado.Consultar_Guid(GuidTex);
                if (objGui != null)
                {
                    if (objGui.estadoGuidTraslado == 1)
                    {
                        objGui.estadoGuidTraslado = 0;

                        bool tras = controladorGuidTraslado.CrearEditarEliminar_GuidTraslado(objGui, 1);
                        if (tras == true)
                        {
                            if (cbRetirarProducto.Checked == true)
                            {
                                string guidCorto = GuidTex.Substring(0, 5);
                                VariablesPublicas.OrdenTraslado = guidCorto;
                                VariablesPublicas.DesciopcionTraslado = txtDescripcionTraslado.Text;
                                VariablesPublicas.EnvioTraslado = VariablesPublicas.NombreEmpresa;
                                VariablesPublicas.RecibidoTraslado = cmbSedes.Text;
                                frmReporte frm = new frmReporte();
                                AddOwnedForm(frm);
                                frm.GuidTexto = GuidTex;
                                frm.ReporteAImprimir = "OrdenTraslado";
                                frm.ShowDialog();
                            }

                            GuidTex = "";
                            LimpiarFormulario();
                            ConsultarGuidActivo();
                            CargarFormulario();
                            CargarBuscador();
                        }
                    }
                }
            }
            else
            {
                errorProvider1.SetError(btnGuardarTraslado, "El traslado no se completó correctamente.");
            }
        }

        private void dgBuscarProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCantidad.Focus();
        }
    }
}

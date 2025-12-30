using DAL.Controladores;
using DAL.Controladores.Orden_Servicio;
using DAL.Controladores.OrdenServicio;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using POS_SERINSIS_PC_2022.Reportes;
using SERINSI_PC.Clases;
using SERINSI_PC.Formularios.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Orden_de_Servicio
{
    public partial class frmOrdenServicio : Form
    {
        string CedulaCliente;
        public decimal PrecioServicio;
        int consecutivoVenta = 0;
        int IdCliente = 0;
        int IdOrdenServicio = 0;
        string estado = "";
        int NumeroOrden = 0;
        string ResponsableOrden = "";
        public string FactuarOrden="--";
        public frmOrdenServicio()
        {
            InitializeComponent();
        }
        private void GestionarBotones(int Boton)
        {
            if(Boton == 0)
            {
                btnGuardar.Text = "Crear Orden";
                btnEliminar.Enabled = false;
                btnCerrarOrden.Enabled = false;
            }
            else
            {
                btnGuardar.Text = "Editar orden";
                btnEliminar.Enabled = true;
                btnCerrarOrden.Enabled = true;
            }
        }
        private void LimpiarFormulario()
        {
            IdOrdenServicio = 0;
            IdCliente = 0;
            txtNombreCliente.Text = "";
            txtTelefonoCliente.Text = "";
            txtDireccionCliente.Text = "";
            cboServicio.SelectedIndex = -1;
            cboArticulo.SelectedIndex = -1;
            txtOtro.Text = "";
            txtModelo.Text = "";
            txtSerial.Text = "";
            txtObservicioIngreso.Text = "";
            txtDescripcionServicio.Text = "";
            NumeroOrden = 0;

            HallarNumeroOrden();
            GestionarBotones(0);
            GestionarEstado(0);
            CargarDGCompleto();
        }
        private void frmOrdenServicio_Load(object sender, EventArgs e)
        {
            CargarCBO();
            CargarDGCompleto();
            HallarNumeroOrden();
            GestionarBotones(0);
            GestionarEstado(0);
    

            txtOtro.Enabled = false;
            txtNombreCliente.Focus();
        }
        private void HallarNumeroOrden()
        {
            NumeroOrden = controladorOrdenServicio.HallarConsecutivo();
        }
        private void CargarCBO()
        {
            cboServicio.ValueMember = "id";
            cboServicio.DisplayMember = "nombreTipoServicio";
            cboServicio.DataSource = controladorTipoServicio.ListaCompleta();
            cboServicio.SelectedIndex = -1;

            cboArticulo.ValueMember = "id";
            cboArticulo.DisplayMember = "nombreTipoArticulo";
            cboArticulo.DataSource = contorladorArticuloServicio.ListaCompleta();
            cboArticulo.SelectedIndex = -1;
        }
        private void GestionarEstado(int estado)
        {
            if (estado == 0)
            {
                texEstado.BackColor = Color.Black;
                texEstado.ForeColor = Color.White;
                texEstado.Text = "Estado Orden";
            }
            if (estado == 1)
            {
                texEstado.BackColor = Color.Green;
                texEstado.ForeColor = Color.White;
                texEstado.Text = "Orden Activa";
            }
            if (estado == 2)
            {
                texEstado.BackColor = Color.Red;
                texEstado.ForeColor = Color.White;
                texEstado.Text = "Estado Cerrada";
            }
        }
        private bool BalidarCampos()
        {
            if(txtNombreCliente.Text!=""&&
               txtTelefonoCliente.Text!=""&&
               txtDireccionCliente.Text!=""&&
               cboServicio.Text!=""&&
               cboArticulo.Text!=""&&
               txtModelo.Text!=""&&
               txtSerial.Text!=""&&
               txtObservicioIngreso.Text!="")
            {
                if(cboArticulo.Text=="- OTRO")
                {
                    if (txtOtro.Text == "")
                    {
                        return false;
                    }
                }
                else
                {
                    txtOtro.Text = "--";
                }
                if (txtDescripcionServicio.Text == "")
                {
                    txtDescripcionServicio.Text = "--";
                }
                if (txtAccsesorios.Text == "")
                {
                    txtAccsesorios.Text = "--";
                }
                return true;
            }
            else
            {
                return false;
            }          
        }

        private void txtNombreCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtNombreCliente.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SeleccionarCleinte();
                }
                if (e.KeyCode == Keys.Down)
                {
                    dgClientes.Focus();
                }
            }

        }
        private void txtTelefonoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDireccionCliente.Focus();
            }
        }
        private void txtDireccionCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboServicio.Focus();
            }
        }

        private void cboServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboServicio.Text != "")
            {
                cboArticulo.Focus();
            }
        }

        private void cboArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboArticulo.Text != "")
            {
                if(cboArticulo.Text== "- OTRO")
                {
                    txtOtro.Enabled = true;
                    txtOtro.Focus();
                }
                else
                {
                    txtOtro.Enabled = false;
                    txtModelo.Focus();
                }
            }
        }
        private void txtOtro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtModelo.Focus();
            }
        }
        private void txtModelo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSerial.Focus();
            }
        }
        private void txtSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtObservicioIngreso.Focus();
            }
        }
        private void txtObservicioIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAccsesorios.Focus();
            }
        }
        private void txtAccsesorios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescripcionServicio.Focus();
            }
        }
        private void txtDescripcionServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar.Focus();
            }
        }

        private void dgOrdenServicio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgOrdenServicio.RowCount>0&& e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgOrdenServicio.Rows[e.RowIndex];
                IdOrdenServicio = Convert.ToInt32(fila.Cells["v_id"].Value);
                NumeroOrden = Convert.ToInt32(fila.Cells["v_numeroOrdenServicio"].Value);
                IdCliente = Convert.ToInt32(fila.Cells["v_idCleinte"].Value);
                txtNombreCliente.Text = Convert.ToString(fila.Cells["v_nombreCliente"].Value);
                txtTelefonoCliente.Text = Convert.ToString(fila.Cells["v_telefonoCliente"].Value);
                txtDireccionCliente.Text = Convert.ToString(fila.Cells["v_direccionCliente"].Value);
                cboServicio.SelectedValue = Convert.ToInt32(fila.Cells["v_idServicio"].Value);
                cboArticulo.SelectedValue = Convert.ToInt32(fila.Cells["v_idArticulo"].Value);
                txtOtro.Text = Convert.ToString(fila.Cells["v_otro"].Value);
                txtModelo.Text = Convert.ToString(fila.Cells["v_modeloArticulo"].Value);
                txtSerial.Text = Convert.ToString(fila.Cells["v_serialArticulo"].Value);
                txtObservicioIngreso.Text = Convert.ToString(fila.Cells["v_observiacioIngreso"].Value);
                txtDescripcionServicio.Text = Convert.ToString(fila.Cells["v_descripcionServicio"].Value);
                estado = Convert.ToString(fila.Cells["estadoOrdenServicio"].Value);


                if (estado == "Abierta")
                {
                    GestionarEstado(1);
                }
                else if(estado=="Cerrada")
                {
                    GestionarEstado(2);
                }
                else
                {
                    GestionarEstado(0);
                }
                GestionarBotones(1);
                dgClientes.Visible = false;
                txtNombreCliente.Focus();
            }
        }
        private void CargarDGCompleto()
        {
            //dgOrdenServicio.DataSource = controladorOrdenServicio.Lista_V_Conpleta();
        }
        private void GestionarOrdenServicio(int Boton)
        {
            OrdenServicio objOrden = new OrdenServicio();
            objOrden = controladorOrdenServicio.consultar_ID(IdOrdenServicio);
            if (objOrden != null)
            {
                if(Boton == 0)
                {
                    MessageBox.Show("La orden que desea crea ya existe.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            if(Boton == 0)
            {
                objOrden = new OrdenServicio();
                IdOrdenServicio = 0;
                objOrden.usuarioIngreso = ResponsableOrden;
                objOrden.usuarioRetiro = ResponsableOrden;
            }
            else
            {
                objOrden.usuarioRetiro = ResponsableOrden;
            }
            objOrden.id = IdOrdenServicio;
            objOrden.numeroOrdenServicio = NumeroOrden;
            objOrden.idCleinte = IdCliente;
            if(Boton == 0)
            {
                objOrden.fechaIngreso = DateTime.Now;
                objOrden.fechaRetiro = DateTime.Now;
            }
            else
            {
                objOrden.fechaRetiro = DateTime.Now;
            }
            objOrden.idTipoServicio = Convert.ToInt32(cboServicio.SelectedValue);
            objOrden.idArticulo = Convert.ToInt32(cboArticulo.SelectedValue);
            objOrden.descriopcionOtro = txtOtro.Text;
            objOrden.modeloArticulo = txtModelo.Text;
            objOrden.serialArticulo = txtSerial.Text;
            objOrden.accesoriosArticulo = txtAccsesorios.Text;
            objOrden.observacionIngreso = txtObservicioIngreso.Text;
            objOrden.descripcionServicio = txtDescripcionServicio.Text;
            objOrden.estadoOrdenServicio = estado;
            bool sql = controladorOrdenServicio.CrearEditarEliminarOrden(objOrden,Boton);
            if (sql == true)
            {
                if (FactuarOrden == "si")
                {
                    //bool orden = GestionarFacturarOrden();
                    //if (orden == true)
                    //{
                    //    MessageBox.Show("la orden de servicio fue gestionada correctamente.", "Orden Servicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    button1.PerformClick();
                    //    LimpiarFormulario();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Ha ocurrido un error y no fue posible facturar la orden automáticamente debe de facturar manual.", "Orden Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    button1.PerformClick();
                    //    LimpiarFormulario();
                    //}
                }
                else
                {
                    MessageBox.Show("la orden de servicio fue gestionada correctamente.", "Orden Servicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button1.PerformClick();
                    LimpiarFormulario();
                }
            }
        }

        private bool GestionarDetalleVenta(int idOtro)
        {
            DetalleVenta objDetalle = new DetalleVenta();
            objDetalle.id = 0;
            objDetalle.idVenta = consecutivoVenta;
            objDetalle.descripcionProducto = txtDescripcionServicio.Text;
            objDetalle.cantidadDetalle = 1;
            //objDetalle.totalDetalle = PrecioServicio;
            objDetalle.precioVenta = PrecioServicio;
            bool sql = ControladorDetalleVenta.GuardarEditarEliminar(objDetalle,0);
            if (sql == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool campos = BalidarCampos();
            if (campos == true)
            {
                if (btnGuardar.Text == "Crear Orden")
                {
                    ResponsableOrden = VariablesPublicas.NombreUsuarioActivo;
                    estado = "Abierta";
                    GestionarOrdenServicio(0);
                }
                else
                {
                    GestionarOrdenServicio(1);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool campos = BalidarCampos();
            if (campos == true)
            {
                GestionarOrdenServicio(2);
            }
        }

        private void btnCerrarOrden_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de hacer el cierre de la orden seleccionar.", "Cerrar Orden", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool campos = BalidarCampos();
                if (campos == true)
                {
                    FactuarOrden = "--";
                    frmCierreOrdenServicio frm = new Orden_de_Servicio.frmCierreOrdenServicio();
                    AddOwnedForm(frm);
                    frm.ShowDialog();

                    if (FactuarOrden == "si")
                    {
                        ResponsableOrden = VariablesPublicas.NombreUsuarioActivo;
                        estado = "Cerrada";
                        GestionarOrdenServicio(1);

                    }
                    else if (FactuarOrden == "no")
                    {
                        ResponsableOrden = VariablesPublicas.NombreUsuarioActivo;
                        estado = "Cerrada";
                        txtDescripcionServicio.Text = txtDescripcionServicio.Text + " -- (Nota: el artículo fue retirado sin realizar ningún procedimiento de reparación o mantenimiento.)";
                        GestionarOrdenServicio(1);
                    }
                }
            }
        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtNombreCliente.Text != "")
            {
                dgClientes.Visible = true;
                dgClientes.DataSource = ControladorClienteTienda.FiltarX_Nombre(txtNombreCliente.Text);
            }
            else
            {
                dgClientes.Visible = false;
            }
        }
        private void SeleccionarCleinte()
        {
            if (dgClientes.RowCount > 0 && dgClientes.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgClientes.Rows[dgClientes.CurrentRow.Index];
                IdCliente = Convert.ToInt32(fila.Cells["id_cliente_tienda"].Value);
                CedulaCliente = Convert.ToString(fila.Cells["cc_nit_cliente_tienda"].Value);
                txtTelefonoCliente.Text = Convert.ToString(fila.Cells["telefono_cliente_tienda"].Value);
                txtDireccionCliente.Text = Convert.ToString(fila.Cells["direccion_cleinte"].Value);
                txtNombreCliente.Text = Convert.ToString(fila.Cells["nombre_cliente_tienda"].Value);
                dgClientes.Visible = false;

                cboServicio.Focus();
            }
        }

        private void dgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarCleinte();
        }

        private void dgClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarCleinte();
            }
        }

        private void btnCrearCliente_Click(object sender, EventArgs e)
        {
            frmClienteTienda frm = new frmClienteTienda();
            AddOwnedForm(frm);
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VariablesPublicas.NumeroOrdenServicio =Convert.ToString(NumeroOrden);
            VariablesPublicas.NombreCliente = txtNombreCliente.Text;
            VariablesPublicas.TelefonoCliente = txtTelefonoCliente.Text;
            VariablesPublicas.TipoServicio = cboServicio.Text;
            VariablesPublicas.TipoArticulo = cboArticulo.Text;
            VariablesPublicas.Modelo = txtModelo.Text;
            VariablesPublicas.Serial = txtSerial.Text;
            VariablesPublicas.ObservacionIngreso = txtObservicioIngreso.Text;

            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            frm.ReporteAImprimir = "OrdenServicio";
            frm.ShowDialog();
        }
    }
}

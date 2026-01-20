using DAL.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Modelo;
using DAL;
namespace SERINSI_PC.Formularios.Fabrica
{
    public partial class frmGestionOrdenFabrica : Form
    {
        public int Dias;
        public int IdOrdenFabricacion;
        public int NumeroOrden;
        public string EstadoOrden;
        public frmGestionOrdenFabrica()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtResponsable.Focus();
            }
        }

        private void txtResponsable_KeyDown(object sender, KeyEventArgs e)
        {
            if (lbResponsableOrden.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SeleccionarResponsable();
                }
                if (e.KeyCode == Keys.Down)
                {
                    lbResponsableOrden.Focus();
                }
            }
        }
        private void SeleccionarResponsable()
        {
            if (lbResponsableOrden.Text != "")
            {
                txtResponsable.Text = lbResponsableOrden.Text;
                lbResponsableOrden.Visible = false;
                txtValorOrden.Focus();
            }
        }
        private void SeleccionarCliente()
        {
            if (lbCliente.Text != "")
            {
                txtClienteOrden.Text = lbCliente.Text;
                lbCliente.Visible = false;
                txtDescripcionOrden.Focus();
            }
        }
        private void txtValorOrden_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtManoObra.Focus();
            }
        }

        private void txtClienteOrden_KeyDown(object sender, KeyEventArgs e)
        {
            if (lbCliente.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SeleccionarCliente();
                }
                if (e.KeyCode == Keys.Down)
                {
                    lbCliente.Focus();
                }
            }
        }

        private void txtManoObra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtClienteOrden.Focus();
            }
        }

        private void frmGestionOrdenFabrica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar.PerformClick();
            }
        }

        private void txtValorOrden_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtManoObra_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dtFechaEntrega_ValueChanged(object sender, EventArgs e)
        {
            HallarDias(dtFechaInicio.Value, dtFechaEntrega.Value);
            if (Dias < -1)
            {
                txtDias.Text = "";
                MessageBox.Show("La fecha de entrega no puede ser menor a la fecha de inicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtDias.Text = Convert.ToString(Dias + 2);
                txtResponsable.Focus();
            }

        }
        private void HallarDias(DateTime fecha1, DateTime fecha2)
        {
            TimeSpan ts = fecha2.Subtract(fecha1);
            double diasDouble = Convert.ToDouble(ts.TotalDays);
            Dias = Convert.ToInt32(Math.Floor(diasDouble));
            //HorasInt = ts.Hours;
            //MinutosInt = ts.Minutes;
            //segundosint = ts.Seconds;
        }

        private void dtFechaInicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtResponsable_TextChanged(object sender, EventArgs e)
        {
            if (txtResponsable.Text != "")
            {
                lbResponsableOrden.Visible = true;
                lbResponsableOrden.ValueMember = "id";
                lbResponsableOrden.DisplayMember = "nombreResponsableOrdenFabrica";
                lbResponsableOrden.DataSource = controladorResponsableOrdenFabricacion.filtroNombre(txtResponsable.Text);
            }
            else
            {
                lbResponsableOrden.Visible = false;
            }
        }

        private void lbResponsableOrden_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lbResponsableOrden.Text != "")
                {
                    SeleccionarResponsable();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDias.Text == "" ||
                txtResponsable.Text == "" ||
                txtValorOrden.Text == "" ||
                txtManoObra.Text == "" ||
                txtClienteOrden.Text == "")
            {
                MessageBox.Show("Hay campos vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (btnGuardar.Text == "Guardar")
                {
                    GestionarOrdenFabrica(0);
                }
                else
                {
                    GestionarOrdenFabrica(1);
                }
            }
        }
        private async Task GestionarOrdenFabrica(int Boton)
        {
            //antes de empesar a gestionar la orden vamos a verificar el responsable y el cleinte
            VerificarResponsable();
            VerificarCliente();
            //ahora si empesamos a gestionas la orden de fabricación
            OrdenFabrica objOF = new OrdenFabrica();
            objOF =await controladorOrdenFabrica.consultarID(IdOrdenFabricacion);
            if (objOF != null)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("la orden que desea agregar ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (Boton == 0)
            {
                objOF = new OrdenFabrica();
                IdOrdenFabricacion = 0;
                objOF.costoOrdenInsumo = 0;
                EstadoOrden = "Fabricación";
            }
            objOF.id = IdOrdenFabricacion;
            objOF.numeroOrdenFabrica = NumeroOrden;
            objOF.fechaInicioOrden = dtFechaInicio.Value;
            objOF.fechaEntregaIrden = dtFechaEntrega.Value;
            objOF.diasOrden = Convert.ToInt32(txtDias.Text);
            objOF.responsableOrden = txtResponsable.Text;
            objOF.descripcionProductoOrden = txtDescripcionOrden.Text;
            objOF.costoOrdenManoObra = Convert.ToDecimal(txtManoObra.Text);
            objOF.totalConstoOren = objOF.costoOrdenInsumo + objOF.costoOrdenManoObra;
            objOF.ValorFinalOrden = Convert.ToDecimal(txtValorOrden.Text);
            objOF.Producido = objOF.ValorFinalOrden - objOF.totalConstoOren;
            objOF.clienteOrden = txtClienteOrden.Text;
            objOF.estadoOrdenFabricacion = EstadoOrden;
            RespuestaCRUD sql =await controladorOrdenFabrica.CrearEditarElimminarOrdenFabrica(objOF, Boton);
            if (sql.estado == true)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("la orden fue creada correctamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Boton == 1)
                {
                    MessageBox.Show("la orden fue editada correctamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                frmFabrica frm = Owner as frmFabrica;
                frm.llenarDGCOmpleta();
                btnCerrar.PerformClick();
            }
        }
        private async Task VerificarResponsable()
        {
            ResponsableOrdenFabrica objROF = new ResponsableOrdenFabrica();
            objROF =await controladorResponsableOrdenFabricacion.consultarNombre(txtResponsable.Text);
            if (objROF == null)
            {
                objROF = new ResponsableOrdenFabrica();
                objROF.id = 0;
                objROF.nombreResponsableOrdenFabrica = txtResponsable.Text;
                RespuestaCRUD sql =await controladorResponsableOrdenFabricacion.Crud(objROF, 0);
            }
        }
        private void VerificarCliente()
        {
            //ClienteTienda objCliente = new ClienteTienda();
            //objCliente = ControladorClienteTienda.ConsultarX_Nombre(txtClienteOrden.Text);
            //if (objCliente == null)
            //{
            //    objCliente = new ClienteTienda();
            //    objCliente.id_cliente_tienda = 0;
            //    objCliente.cc_nit_cliente_tienda = "--";
            //    objCliente.nombre_cliente_tienda = txtClienteOrden.Text;
            //    objCliente.telefono_cliente_tienda = "--";
            //    objCliente.direccion_cleinte = "--";
            //    bool sql = ControladorClienteTienda.Crear_Editar_Elimnar_ClienteTienda(objCliente, 0);
            //}
        }

        private void txtClienteOrden_TextChanged(object sender, EventArgs e)
        {
            if (txtClienteOrden.Text != "")
            {
                lbCliente.Visible = true;
                lbCliente.ValueMember = "id_cliente_tienda";
                lbCliente.DisplayMember = "nombre_cliente_tienda";
                lbCliente.DataSource = ControladorClienteTienda.FiltarX_Nombre(txtClienteOrden.Text);
            }
            else
            {
                lbCliente.Visible = false;
            }
        }

        private void lbResponsableOrden_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbResponsableOrden.Text != "")
            {
                SeleccionarResponsable();
            }
        }

        private void lbCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (lbCliente.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SeleccionarCliente();
                }
            }
        }

        private void lbCliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbCliente.Text != "")
            {
                SeleccionarCliente();

            }
        }

        private async void frmGestionOrdenFabrica_Load(object sender, EventArgs e)
        {
            if (btnGuardar.Text == "Editar")
            {
                lbCliente.Visible = false;
                lbResponsableOrden.Visible = false;
            }
            else
            {
                await HallarConsecutivoOrden();
            }
        }
        private async Task HallarConsecutivoOrden()
        {
            NumeroOrden =await controladorOrdenFabrica.Consecutivo();
        }
    }
}

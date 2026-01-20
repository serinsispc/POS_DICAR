using DAL;
using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using SERINSI_PC.Formularios.Contabilidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invenpol_Parqueadero_Motos.Formularios
{
    public partial class frmGastos : Form
    {
        //Variables 
        public int IdGasto = 0;
        public int Total = 0;
        public frmGastos()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Evento load del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void frmGastos_Load_1(object sender, EventArgs e)
        {
            cargarBolsillo();
            await CargarTipoGasto();
            LLenarDataGrid();
            GestionarBotones(0);
            await TotalGastos();
        }
        private async Task CargarTipoGasto()
        {
            cmbTipoGasto.DataSource = null;
            cmbTipoGasto.ValueMember = "id";
            cmbTipoGasto.DisplayMember = "nombreTipoGasto";
            cmbTipoGasto.DataSource =await controladorTipoGasto.ListaCompleta();
        }
        private void cargarBolsillo()
        {
            cmbBolsillo.ValueMember = "id";
            cmbBolsillo.DisplayMember = "nombreBolsillo";
            cmbBolsillo.DataSource = ControladorBilsillo.listaCompleta();
        }
        private void LLenarDataGrid()
        {
            dataGridGastosarqueadero.DataSource = ControladorGastos.ConsultaTodosLosGastos(VariablesPublicas.IdEmpresaLogueada);
        }
        /// <summary>
        /// Evento click del boton cerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Evento click delboton minimizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// Funcion para definir que tarea a hacer 
        /// </summary>
        private async Task GestionarGasto(int boton)
        {
            if(txtConcepto.Text == "" || txtValor.Text ==""||cmbBolsillo.Text=="")
            {
                return;
            }
            else
            {
                Gastos objGastop = new Gastos();
                objGastop =await ControladorGastos.ConsultaGastoXId(IdGasto);
                
                if(boton == 0)
                {
                    if(objGastop != null)
                    {
                        MessageBox.Show("El gasto ya existe.");
                        return;
                    }
                    objGastop = new Gastos();

                    
                }
                objGastop.id = IdGasto;
                objGastop.fecha = dtFecha.Value;
                objGastop.idTipoGasto = Convert.ToInt32(cmbTipoGasto.SelectedValue);
                objGastop.concepto = txtConcepto.Text;
                objGastop.valor = Convert.ToInt32(txtValor.Text);
                objGastop.idBolsillo = Convert.ToInt32(cmbBolsillo.SelectedValue);
                objGastop.idBasecaja = VariablesPublicas.IdBaseActiva;
                objGastop.idSede = VariablesPublicas.IdEmpresaLogueada;
                RespuestaCRUD Respuesta =await ControladorGastos.Guardar_Editar_Eliminar_Gasto(objGastop, boton);
                if(Respuesta.estado == true)
                {
                    if (boton == 0)
                    {
                        MessageBox.Show("Gasto Creado Correctamente.");
                    }
                    if(boton == 1)
                    {
                        MessageBox.Show("Gasto Modificado Correctamente.");
                    }
                    if(boton == 2)
                    {
                        MessageBox.Show("Gasto Emilinado.");
                    }
                    LLenarDataGrid();
                    LimpiarFormulario();
                    TotalGastos();
                    txtConcepto.Focus();
                }
            }            
        }
        /// <summary>
        /// Funcion para activar odesactivar los botones dependiendo el evento
        /// </summary>
        private void GestionarBotones(int boton)
        {
            if(boton == 0)
            {
                btnCrear.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            if(boton == 1)
            {
                btnCrear.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }
        /// <summary>
        /// Evento Click del boton crear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnCrear_Click(object sender, EventArgs e)
        {
            await GestionarGasto(0);
        }
        private void LimpiarFormulario()
        {
            txtConcepto.Text = "";
            txtValor.Text = "";
            IdGasto = 0;
        }
        /// <summary>
        /// Evento click del boton Limpiar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            GestionarBotones(0);
            LLenarDataGrid();
            await TotalGastos();
        }
        /// <summary>
        /// Evento select click de el dataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridGastosarqueadero_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarGasto();
        }
        private void SeleccionarGasto()
        {
            if (dataGridGastosarqueadero.RowCount > 0 && dataGridGastosarqueadero.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dataGridGastosarqueadero.Rows[dataGridGastosarqueadero.CurrentRow.Index];
                DateTime Fecha = Convert.ToDateTime(fila.Cells["fecha"].Value);
                IdGasto = Convert.ToInt32(fila.Cells["id"].Value);
                txtConcepto.Text = Convert.ToString(fila.Cells["concepto"].Value);
                txtValor.Text = Convert.ToString(fila.Cells["valor"].Value);
                cmbBolsillo.SelectedValue = Convert.ToInt32(fila.Cells["VidBolsillo"].Value);
                dtFecha.Value= Convert.ToDateTime(fila.Cells["fecha"].Value);
                GestionarBotones(1);
            }
        }
        /// <summary>
        /// Evento click del boton editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            await GestionarGasto(1);
        }
        /// <summary>
        /// Evento click del boton Eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            await GestionarGasto(2);
        }
        /// <summary>
        /// Evento click delboton filtro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnFiltro_Click(object sender, EventArgs e)
        {
            dataGridGastosarqueadero.DataSource = ControladorGastos.ConsultaGastoXFecha(dtFecha.Value);
            Total =await ControladorGastos.HallarTotalGastosDia(dtFecha.Value,VariablesPublicas.IdEmpresaLogueada);
            txtTotal.Text = String.Format("{0:C}", Total);
        }
        private async Task TotalGastos()
        {
            Total =await ControladorGastos.HallarTotalGastoFull(VariablesPublicas.IdEmpresaLogueada);
            txtTotal.Text = String.Format("{0:C}", Total);
        }
        /// <summary>
        /// Evento al precionar una tecla en el txtValor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtConcepto_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtConcepto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtValor.Focus();
            }
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCrear.Focus();
            }
        }

        private void frmGastos_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnNuevoTipoGasto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTipoGAsto frm = new frmTipoGAsto();
            AddOwnedForm(frm);
            frm.ShowDialog();
            CargarTipoGasto();
        }
    }
}

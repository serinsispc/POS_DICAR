using DAL;
using DAL.Controladores;
using DAL.Modelo;
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

namespace POS_SERINSIS_PC_2022.Formularios.Configuracion
{
    public partial class frmBuscardorCliente : Form
    {
        public frmBuscardorCliente()
        {
            InitializeComponent();
        }
        //declaramos el objeto lista para la tabla de los cleintes
        public List<V_Cliente> ListaCliente = new List<V_Cliente>();
        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtCliente.Text != "")
            {
                txtBuscarCiudad.Text = "";
                txtBuscarBarrio.Text = "";
                dgBuscarCliente.DataSource = ListaCliente.Where(x =>
                x.nombreCliente.Contains(txtCliente.Text) ||
                x.razonSocialCliente.Contains(txtCliente.Text) ).ToList();

                int totalFiltro = dgBuscarCliente.RowCount;
                txtTotalFiltro.Text = Convert.ToString(totalFiltro);
            }

        }
        int IdCliente = 0;
        string NombreCliente = "";
        string Documento = "";
        string Telefono = "";
        public int idVendedor_frm = 0;
        public int idSemana_frm = 0;

        private void SeleccionarDG()
        {
            if (dgBuscarCliente.RowCount > 0 && dgBuscarCliente.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgBuscarCliente.Rows[dgBuscarCliente.CurrentRow.Index];
                IdCliente = Convert.ToInt32(fila.Cells["id"].Value);
                NombreCliente = Convert.ToString(fila.Cells["nombreCliente"].Value);
                Documento = Convert.ToString(fila.Cells["documentoCliente"].Value);
                Telefono = Convert.ToString(fila.Cells["telefonoCliente"].Value);
            }
        }
        private void CerrarFormulario()
        {
            frmRutero frm = Owner as frmRutero;
            frm.txtCliente.Text = NombreCliente;
            frm.txtDocumento.Text = Documento;
            frm.txtTelefonoCliente.Text = Telefono;
            frm.IdCliente_frm = IdCliente;
            this.Close();
        }
        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            SeleccionarDG();
            CerrarFormulario();
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCliente.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //dgBuscarCliente.DataSource = ControladorClienteTienda.BuscadorCliente(txtCliente.Text);
                    SeleccionarDG();
                    CerrarFormulario();
                }
            }
        }

        private void frmBuscardorCliente_Load(object sender, EventArgs e)
        {


        }

        private void txtBuscarCiudad_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarCiudad.Text != "")
            {
                txtCliente.Text = "";
                txtBuscarBarrio.Text = "";
                dgBuscarCliente.DataSource = ListaCliente.Where(x =>
                x.ciudadCliente.Contains(txtBuscarCiudad.Text)).ToList();

                int totalFiltro = dgBuscarCliente.RowCount;
                txtTotalFiltro.Text = Convert.ToString(totalFiltro);
            }
        }

        private void txtBuscarBarrio_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarBarrio.Text != "")
            {
                txtCliente.Text = "";
                txtBuscarCiudad.Text = "";
                dgBuscarCliente.DataSource = ListaCliente.Where(x =>
                x.barrioCliente.Contains(txtBuscarBarrio.Text)).ToList();

                int totalFiltro = dgBuscarCliente.RowCount;
                txtTotalFiltro.Text = Convert.ToString(totalFiltro);
            }
        }
        int TipoFiltro = 0;
        private void btnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            if (idVendedor_frm > 0 &&
                idSemana_frm > 0 &&
                Convert.ToInt32(txtTotalFiltro.Text) > 0)
            {
                try
                {
                    string consulta = "";

                    ConexionSQL.AbrirConexion();
                    SqlCommand commandon = ConexionSQL.connection.CreateCommand();
                    consulta="insert into R_ClienteVendedor " +
                        "(idCliente,idVendedor,idSemana) " +
                        "select V_Cliente.id," + idVendedor_frm + "," + idSemana_frm + " from V_Cliente where ";
                    if (txtCliente.Text!="")
                    {
                        consulta = consulta+"nombreCliente like '%" + txtCliente.Text + "%'";
                    }
                    if (txtBuscarCiudad.Text != "")
                    {
                        consulta = consulta + "ciudadCliente like '%" + txtBuscarCiudad.Text + "%' ";
                    }
                    if (txtBuscarBarrio.Text != "")
                    {
                        consulta = consulta + "barrioCliente like '%" + txtBuscarBarrio.Text + "%'";
                    }

                    
                    commandon.CommandText = consulta;

                    commandon.ExecuteNonQuery();
                    ConexionSQL.CerrarConexion();
                    MessageBox.Show("¡Rutero creado correctamente con " + txtTotalFiltro.Text + " clientes...!", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CerrarFormulario();
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
            }
            else
            {
                MessageBox.Show("¡Para cargar el rutero con varios registros debe seleccionar el vendedor y el día de la semana.!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}

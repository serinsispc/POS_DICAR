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
using DAL.Controladores.Version_Software;
using Invenpol_Parqueadero_Motos.Clases;

using DAL.Controladores;
using APP_PADRE_ARTURO.Servicios;

namespace SERINSI_PC.Formularios.Facturas_Software
{
    public partial class frmFacturas : Form
    {
        public frmFacturas()
        {
            InitializeComponent();
        }

        private void frmFacturas_Load(object sender, EventArgs e)
        {
            dgFacturaSoftware.DataSource = ControladorFacturaSoftware.ListaCompleta();
        }

        private async void btnDescargar_Click(object sender, EventArgs e)
        {
            if (dgFacturaSoftware.RowCount > 0 && dgFacturaSoftware.CurrentRow.Index >= 0)
            {
                //En esta parte lo primero que debemos hacer es traer la ruta de las facturas que corresponde al equipo local donde se está corriendo la aplicación
                RutaActualizacionEquipo objRuta = new RutaActualizacionEquipo();
                objRuta =await ControladorRutas.ConsultarX_NombreEquipo(VariablesPublicas.NombreEquipoLocal);
                if (objRuta != null)
                {
                    DataGridViewRow FIla = dgFacturaSoftware.Rows[dgFacturaSoftware.CurrentRow.Index];
                    string ruta = objRuta.ruta_facturas;
                    string Nombrerchivo = Convert.ToString(FIla.Cells["nombre_factura"].Value);
                    ClassServicios.AbrirArchovo(ruta, Nombrerchivo);
                }
            }
        }
    }
}

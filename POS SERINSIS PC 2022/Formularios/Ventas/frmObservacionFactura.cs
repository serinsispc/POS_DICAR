using Invenpol_Parqueadero_Motos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Ventas
{
    public partial class frmObservacionFactura : Form
    {
        public frmObservacionFactura()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtObservacion.Text != "")
            {
                VariablesPublicas.ObservacionFactura = txtObservacion.Text;
            }
            else
            {
                VariablesPublicas.ObservacionFactura = "";
            }
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (txtObservacion.Text != "")
            {
                VariablesPublicas.ObservacionFactura = txtObservacion.Text;
            }
            else
            {
                VariablesPublicas.ObservacionFactura = "";
            }
            this.Close();
        }

        private void frmObservacionFactura_Load(object sender, EventArgs e)
        {

        }
    }
}



using POS_SERINSIS_PC_2022.Reportes;
using System;

using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Inventario
{
    public partial class frmAgotados : Form
    {
        public frmAgotados()
        {
            InitializeComponent();
        }

        private void frmAgotados_Load(object sender, EventArgs e)
        {
            //dgAgotados.DataSource = ControladorProducto.listaAgotados(VariablesPublicas.IdEmpresaLogueada);
        }

        private void btnImprimirRGeneral_Click(object sender, EventArgs e)
        {
            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            frm.ReporteAImprimir = "ListaAgotados";
            frm.ShowDialog();
        }
    }
}

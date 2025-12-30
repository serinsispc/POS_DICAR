using DAL.Controladores.Contabilidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Contabilidad
{
    public partial class frmLibroDiario : Form
    {
        public frmLibroDiario()
        {
            InitializeComponent();
        }

        private void frmLibroDiario_Load(object sender, EventArgs e)
        {
            cargarDG();
            rbDia.Checked = true;
        }
        public void cargarDG()
        {
            dgLibroDiario.DataSource = ControladorLibroDiario.listaCompleta();
            rbAño.Checked = false;
            rbMes.Checked = false;
            rbDia.Checked = false;
        }

        private void btnEliminarFiltro_Click(object sender, EventArgs e)
        {
            cargarDG();
        }

        private void rbDia_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDia.Checked == true)
            {
                dgLibroDiario.DataSource = ControladorLibroDiario.filtroDia(dtFecha.Value);
            }
        }

        private void rbMes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMes.Checked == true)
            {
                dgLibroDiario.DataSource = ControladorLibroDiario.filtroMes(dtFecha.Value);
            }
        }

        private void rbAño_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAño.Checked == true)
            {
                dgLibroDiario.DataSource = ControladorLibroDiario.filtroAño(dtFecha.Value);
            }
        }

        private void btnTraslado_Click(object sender, EventArgs e)
        {
            frmTrasladoDinero frm = new frmTrasladoDinero();
            AddOwnedForm(frm);
            frm.ShowDialog();
        }

        private void btnBase_Click(object sender, EventArgs e)
        {
            frmBaseLibroDiario frm = new Contabilidad.frmBaseLibroDiario();
            AddOwnedForm(frm);
            frm.ShowDialog();
        }
    }
}

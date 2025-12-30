using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Formularios.Tiemda;
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
    public partial class frmReferenciaTargeta : Form
    {
        public frmReferenciaTargeta()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtReferencia.Text != "")
            {
                frmPagoCreditos frm = Owner as frmPagoCreditos;
                frm.ReferenciaVenta = txtReferencia.Text;
                this.Close();
            }
        }
    }
}

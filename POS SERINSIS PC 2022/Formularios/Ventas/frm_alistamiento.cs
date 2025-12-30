using DAL;
using DAL.Modelo;
using POS_SERINSIS_PC_2022.Reportes;
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

namespace POS_SERINSIS_PC_2022.Formularios.Ventas
{
    public partial class frm_alistamiento : Form
    {
        public frm_alistamiento()
        {
            InitializeComponent();
        }
        public int idVendedor_frm = 0;
        public int idEstadoPedido_frm = 0;
        public string nombreVendedor_frm = "";
        public DateTime fecha;
        private void frm_alistamiento_Load(object sender, EventArgs e)
        {
            try
            {
                using(SistemaPOSEntities cn =new SistemaPOSEntities())
                {           
                    dgAlistamiento.DataSource = cn.SelectAlistamiento(idVendedor_frm, idEstadoPedido_frm,fecha.Day,fecha.Month,fecha.Year);
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
        }
        List<DataTable> dataTable = new List<DataTable>();
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            frm.Alistamiento(idVendedor_frm, idEstadoPedido_frm, nombreVendedor_frm,fecha,txtTotal.Text);
            frm.ShowDialog();
        }
    }
}

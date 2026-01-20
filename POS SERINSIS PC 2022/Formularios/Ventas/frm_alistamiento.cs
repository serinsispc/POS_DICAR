using DAL;
using DAL.Modelo;
using DAL.SQL;
using Newtonsoft.Json;
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
        List<SelectAlistamiento_Result> lista = new List<SelectAlistamiento_Result>();
        private async void frm_alistamiento_Load(object sender, EventArgs e)
        {
            try
            {

                var query = $"exec SelectAlistamiento {idVendedor_frm},{idEstadoPedido_frm},{fecha.Day},{fecha.Month},{fecha.Year}";
                var respuest=await Conection_SQL.ConsultaSQLServer(query, true, true);
                if (respuest == null) lista= null;
                lista=JsonConvert.DeserializeObject<List<SelectAlistamiento_Result>>(respuest);
                dgAlistamiento.DataSource = lista;
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
        }
        List<DataTable> dataTable = new List<DataTable>();
        private async void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporte frm = new frmReporte();
            AddOwnedForm(frm);
            await frm.Alistamiento(lista,idVendedor_frm, idEstadoPedido_frm, nombreVendedor_frm,fecha,txtTotal.Text);
            frm.ShowDialog();
        }
    }
}

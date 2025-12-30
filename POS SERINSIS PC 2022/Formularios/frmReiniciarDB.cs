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

namespace SERINSI_PC.Formularios
{
    public partial class frmReiniciarDB : Form
    {
        public frmReiniciarDB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Qwerty2020")
            {
                try
                {
                    using(SistemaPOSEntities cn =new SistemaPOSEntities())
                    {
                        cn.V_ReiniciarDB();
                    }
                }
                catch(Exception ex)
                {
                    string error = ex.Message;
                }
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}

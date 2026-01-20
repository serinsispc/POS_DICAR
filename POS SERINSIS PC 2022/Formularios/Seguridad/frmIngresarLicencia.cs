using DAL;
using DAL.Controladores;
using DAL.Modelo;
using SERINSI_PC.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Seguridad
{
    public partial class frmIngresarLicencia : Form
    {
        public string LicenciaSoftware;
        public frmIngresarLicencia()
        {
            InitializeComponent();
        }

        private void frmIngresarLicencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
                this.Close();
            }
        }

        private async void btnConfigurar_Click(object sender, EventArgs e)
        {
            string LicenciaIngresada = textBox1.Text + "-" + textBox2.Text + "-" + textBox3.Text;
            if (LicenciaIngresada == LicenciaSoftware)
            {
                Licencia objLicencia = new Licencia();
                objLicencia =await ControladorLicenciaSoftware.ConsultarLicencia(LicenciaIngresada);
                if (objLicencia == null)
                {
                    objLicencia = new Licencia();
                    objLicencia.id = 0;
                    objLicencia.clave = LicenciaIngresada;
                    RespuestaCRUD sql =await ControladorLicenciaSoftware.Crear_Editar_Eliminar_LicenciaSoftware(objLicencia, 0);
                    if (sql.estado == true)
                    {
                        MessageBox.Show("La licencia fue registrada correctamente.", "Producto Activado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Clave incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }
    }
}

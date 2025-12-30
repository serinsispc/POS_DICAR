using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using Invenpol_Parqueadero_Motos.Clases;

namespace POS_SERINSIS_PC_2022.Formularios
{
    public partial class frm_prueba_balanza : Form
    {
        public decimal precioUnidad = 0;
        private delegate void DelegadoAcceso(string accion);

        public frm_prueba_balanza()
        {
            InitializeComponent();
        }

        private void frm_prueba_balanza_Load(object sender, EventArgs e)
        {
            try
            {
                serialPort1 = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
                serialPort1.Handshake = Handshake.None;
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                //serialPort1.ReadTimeout = 500;
                //serialPort1.WriteTimeout = 500;
                serialPort1.Open();
                serialPort1.Write("0P");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    if (this.Enabled == true)
                    {
                        Thread.Sleep(500);
                        string data = serialPort1.ReadExisting();
                        this.BeginInvoke(new DelegadoAcceso(si_DataReceived), new object[] { data });
                    }
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message+ "  sp_DataReceived");
            }

        }
        int contador = 0;
        string peso = "";
        private void si_DataReceived(string accion)
        {
            try
            {
                string DATOS = accion;
                decimal precio = 0;
                //label2.Text = DATOS.Substring(4,6);
                string condicion = DATOS.Substring(12, 1);
                //MessageBox.Show("Peso correcto","Ok");
                peso = DATOS.Substring(4, 6);
                precio = Convert.ToDecimal(peso.Replace(".", ",")) * precioUnidad;

                label2.Text = peso;

                label3.Text = Convert.ToString(precio.ToString("C"));
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //MessageBox.Show(ex.Message+ "  si_DataReceived");
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                VariablesPublicas.cantidadKilogramo = Convert.ToDecimal(peso.Replace(".", ","));

                serialPort1.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
               // MessageBox.Show(ex.Message + "    button1_Click");
            }

        }
    }
}

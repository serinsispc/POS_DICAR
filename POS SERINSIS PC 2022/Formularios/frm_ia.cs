using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_SERINSIS_PC_2022.Formularios
{
    public partial class frm_ia : Form
    {
        public frm_ia()
        {
            InitializeComponent();
            // Configurar los TextBox para que solo acepten números
            txtNumero1.KeyPress += TextBox_KeyPress;
            txtNumero2.KeyPress += TextBox_KeyPress;
            txtNumero1.TextChanged += TextBox_TextChanged;
            txtNumero2.TextChanged += TextBox_TextChanged;
        }

        private void frm_ia_Load(object sender, EventArgs e)
        {
            // El formulario se carga aquí si se necesita alguna configuración adicional
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            
            // Verificar si el texto contiene caracteres no numéricos
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                string textoValido = "";
                foreach (char c in textBox.Text)
                {
                    if (char.IsDigit(c))
                    {
                        textoValido += c;
                    }
                }
                
                // Si el texto cambió, actualizarlo
                if (textoValido != textBox.Text)
                {
                    int cursorPosition = textBox.SelectionStart;
                    textBox.Text = textoValido;
                    // Restaurar la posición del cursor
                    if (cursorPosition > textoValido.Length)
                        cursorPosition = textoValido.Length;
                    textBox.SelectionStart = cursorPosition;
                }
            }
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que ambos campos tengan valores
                if (string.IsNullOrWhiteSpace(txtNumero1.Text) || string.IsNullOrWhiteSpace(txtNumero2.Text))
                {
                    MessageBox.Show("Por favor, ingrese valores en ambos campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Convertir los valores a números decimales
                decimal numero1 = Convert.ToDecimal(txtNumero1.Text);
                decimal numero2 = Convert.ToDecimal(txtNumero2.Text);

                // Realizar la suma
                decimal resultado = numero1 + numero2;

                // Mostrar el resultado
                txtResultado.Text = resultado.ToString();

                // Mostrar mensaje de finalización
                MessageBox.Show("¡Proceso de suma finalizado correctamente!", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese solo números válidos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResultado.Text = "";
            }
            catch (OverflowException)
            {
                MessageBox.Show("El número es demasiado grande o demasiado pequeño.", "Error de desbordamiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResultado.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResultado.Text = "";
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_ia_KeyDown(object sender, KeyEventArgs e)
        {
            // Permitir cerrar el formulario con la tecla Escape
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}
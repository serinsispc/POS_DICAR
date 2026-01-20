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
    public partial class FrmLoading : Form
    {
        public FrmLoading(string mensaje = "Procesando, por favor espere...")
        {
            InitializeComponent();
            ConstruirUI(mensaje);
        }

        private Label lblMensaje;
        private ProgressBar progress;

        private void ConstruirUI(string mensaje)
        {
            // Form
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.BackColor = Color.Black;
            this.Opacity = 0.70;
            this.ControlBox = false;

            // Panel central (tarjeta)
            var panel = new Panel
            {
                Size = new Size(420, 140),
                BackColor = Color.White,
            };
            panel.Paint += (s, e) =>
            {
                // bordes redondeados simples (efecto)
                using (var pen = new Pen(Color.Gainsboro, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            };

            // ProgressBar
            progress = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30,
                Size = new Size(360, 20),
                Location = new Point(30, 70)
            };

            // Label
            lblMensaje = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = mensaje,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(25, 25, 25),
                Size = new Size(360, 40),
                Location = new Point(30, 20)
            };

            panel.Controls.Add(lblMensaje);
            panel.Controls.Add(progress);
            this.Controls.Add(panel);

            // Centrar panel
            panel.Location = new Point(
                (this.Width - panel.Width) / 2,
                (this.Height - panel.Height) / 2
            );

            this.Resize += (s, e) =>
            {
                panel.Location = new Point(
                    (this.Width - panel.Width) / 2,
                    (this.Height - panel.Height) / 2
                );
            };
        }

        public void SetMensaje(string mensaje)
        {
            if (lblMensaje == null) return;

            if (this.InvokeRequired)
                this.Invoke(new Action(() => lblMensaje.Text = mensaje));
            else
                lblMensaje.Text = mensaje;
        }

        public static FrmLoading ShowLoading(Form owner, string mensaje = "Procesando, por favor espere...")
        {
            var f = new FrmLoading(mensaje);

            // Overlay exacto sobre el form dueño
            f.Size = owner.Size;
            f.Location = owner.PointToScreen(Point.Empty);

            // Para que quede encima de owner
            owner.Enabled = false;

            f.Show(owner);
            f.BringToFront();
            f.Refresh();
            Application.DoEvents();

            return f;
        }

        public static void CloseLoading(Form owner, FrmLoading loading)
        {
            try
            {
                if (loading != null && !loading.IsDisposed)
                    loading.Close();
            }
            catch { }

            if (owner != null && !owner.IsDisposed)
                owner.Enabled = true;
        }

        private void FrmLoading_Load(object sender, EventArgs e)
        {

        }
    }
}

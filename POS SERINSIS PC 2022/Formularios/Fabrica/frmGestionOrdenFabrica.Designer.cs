namespace SERINSI_PC.Formularios.Fabrica
{
    partial class frmGestionOrdenFabrica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.txtTituloFormulario = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.txtDias = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResponsable = new System.Windows.Forms.TextBox();
            this.lbResponsableOrden = new System.Windows.Forms.ListBox();
            this.txtClienteOrden = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCliente = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValorOrden = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescripcionOrden = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtManoObra = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.txtTituloFormulario);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 23);
            this.panel1.TabIndex = 14;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Location = new System.Drawing.Point(614, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(23, 23);
            this.btnMinimizar.TabIndex = 27;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            // 
            // txtTituloFormulario
            // 
            this.txtTituloFormulario.AutoSize = true;
            this.txtTituloFormulario.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTituloFormulario.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTituloFormulario.ForeColor = System.Drawing.Color.White;
            this.txtTituloFormulario.Location = new System.Drawing.Point(0, 0);
            this.txtTituloFormulario.Name = "txtTituloFormulario";
            this.txtTituloFormulario.Size = new System.Drawing.Size(24, 18);
            this.txtTituloFormulario.TabIndex = 11;
            this.txtTituloFormulario.Text = "--";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.cerrar_blanco;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(637, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(23, 23);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // txtDias
            // 
            this.txtDias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDias.Enabled = false;
            this.txtDias.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDias.Location = new System.Drawing.Point(288, 54);
            this.txtDias.Name = "txtDias";
            this.txtDias.Size = new System.Drawing.Size(48, 26);
            this.txtDias.TabIndex = 2;
            this.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDias.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDias_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "Fecha inicio";
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Font = new System.Drawing.Font("Consolas", 12F);
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(12, 54);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(132, 26);
            this.dtFechaInicio.TabIndex = 0;
            this.dtFechaInicio.ValueChanged += new System.EventHandler(this.dtFechaInicio_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(153, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "Fecha entrega";
            // 
            // dtFechaEntrega
            // 
            this.dtFechaEntrega.Font = new System.Drawing.Font("Consolas", 12F);
            this.dtFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaEntrega.Location = new System.Drawing.Point(150, 54);
            this.dtFechaEntrega.Name = "dtFechaEntrega";
            this.dtFechaEntrega.Size = new System.Drawing.Size(132, 26);
            this.dtFechaEntrega.TabIndex = 1;
            this.dtFechaEntrega.ValueChanged += new System.EventHandler(this.dtFechaEntrega_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(291, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 21;
            this.label3.Text = "Días";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(345, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 19);
            this.label4.TabIndex = 22;
            this.label4.Text = "Responsable Orden";
            // 
            // txtResponsable
            // 
            this.txtResponsable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtResponsable.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResponsable.Location = new System.Drawing.Point(342, 54);
            this.txtResponsable.Name = "txtResponsable";
            this.txtResponsable.Size = new System.Drawing.Size(302, 26);
            this.txtResponsable.TabIndex = 3;
            this.txtResponsable.TextChanged += new System.EventHandler(this.txtResponsable_TextChanged);
            this.txtResponsable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResponsable_KeyDown);
            // 
            // lbResponsableOrden
            // 
            this.lbResponsableOrden.FormattingEnabled = true;
            this.lbResponsableOrden.Location = new System.Drawing.Point(342, 78);
            this.lbResponsableOrden.Name = "lbResponsableOrden";
            this.lbResponsableOrden.Size = new System.Drawing.Size(302, 95);
            this.lbResponsableOrden.TabIndex = 24;
            this.lbResponsableOrden.Visible = false;
            this.lbResponsableOrden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbResponsableOrden_KeyDown);
            this.lbResponsableOrden.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbResponsableOrden_MouseDoubleClick);
            // 
            // txtClienteOrden
            // 
            this.txtClienteOrden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClienteOrden.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteOrden.Location = new System.Drawing.Point(342, 105);
            this.txtClienteOrden.Name = "txtClienteOrden";
            this.txtClienteOrden.Size = new System.Drawing.Size(302, 26);
            this.txtClienteOrden.TabIndex = 6;
            this.txtClienteOrden.TextChanged += new System.EventHandler(this.txtClienteOrden_TextChanged);
            this.txtClienteOrden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClienteOrden_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(345, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 19);
            this.label5.TabIndex = 25;
            this.label5.Text = "Cliente";
            // 
            // lbCliente
            // 
            this.lbCliente.FormattingEnabled = true;
            this.lbCliente.Location = new System.Drawing.Point(342, 129);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Size = new System.Drawing.Size(302, 95);
            this.lbCliente.TabIndex = 27;
            this.lbCliente.Visible = false;
            this.lbCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbCliente_KeyDown);
            this.lbCliente.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbCliente_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 19);
            this.label6.TabIndex = 28;
            this.label6.Text = "Precio Orden";
            // 
            // txtValorOrden
            // 
            this.txtValorOrden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorOrden.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorOrden.Location = new System.Drawing.Point(12, 105);
            this.txtValorOrden.Name = "txtValorOrden";
            this.txtValorOrden.Size = new System.Drawing.Size(153, 26);
            this.txtValorOrden.TabIndex = 4;
            this.txtValorOrden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorOrden_KeyDown);
            this.txtValorOrden.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorOrden_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 19);
            this.label7.TabIndex = 30;
            this.label7.Text = "Desripción Orden";
            // 
            // txtDescripcionOrden
            // 
            this.txtDescripcionOrden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcionOrden.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionOrden.Location = new System.Drawing.Point(12, 156);
            this.txtDescripcionOrden.Multiline = true;
            this.txtDescripcionOrden.Name = "txtDescripcionOrden";
            this.txtDescripcionOrden.Size = new System.Drawing.Size(632, 153);
            this.txtDescripcionOrden.TabIndex = 7;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(273, 315);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(115, 31);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtManoObra
            // 
            this.txtManoObra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtManoObra.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManoObra.Location = new System.Drawing.Point(171, 105);
            this.txtManoObra.Name = "txtManoObra";
            this.txtManoObra.Size = new System.Drawing.Size(153, 26);
            this.txtManoObra.TabIndex = 5;
            this.txtManoObra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtManoObra_KeyDown);
            this.txtManoObra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtManoObra_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(171, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 19);
            this.label8.TabIndex = 33;
            this.label8.Text = "Mano de Obra";
            // 
            // frmGestionOrdenFabrica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(660, 356);
            this.Controls.Add(this.txtManoObra);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lbCliente);
            this.Controls.Add(this.lbResponsableOrden);
            this.Controls.Add(this.txtDescripcionOrden);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtValorOrden);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtClienteOrden);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtResponsable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtFechaEntrega);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtFechaInicio);
            this.Controls.Add(this.txtDias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmGestionOrdenFabrica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGestionOrdenFabrica";
            this.Load += new System.EventHandler(this.frmGestionOrdenFabrica_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGestionOrdenFabrica_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMinimizar;
        public System.Windows.Forms.Label txtTituloFormulario;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DateTimePicker dtFechaInicio;
        public System.Windows.Forms.DateTimePicker dtFechaEntrega;
        public System.Windows.Forms.TextBox txtResponsable;
        public System.Windows.Forms.TextBox txtClienteOrden;
        public System.Windows.Forms.TextBox txtValorOrden;
        public System.Windows.Forms.TextBox txtDescripcionOrden;
        public System.Windows.Forms.TextBox txtDias;
        public System.Windows.Forms.TextBox txtManoObra;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button btnGuardar;
        protected System.Windows.Forms.ListBox lbResponsableOrden;
        protected System.Windows.Forms.ListBox lbCliente;
    }
}
namespace SERINSI_PC.Formularios.Contabilidad
{
    partial class frmLibroDiario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.rbAño = new System.Windows.Forms.RadioButton();
            this.rbMes = new System.Windows.Forms.RadioButton();
            this.rbDia = new System.Windows.Forms.RadioButton();
            this.dgLibroDiario = new System.Windows.Forms.DataGridView();
            this.btnTraslado = new System.Windows.Forms.Button();
            this.btnEliminarFiltro = new System.Windows.Forms.Button();
            this.btnBase = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idBolsillo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreBolsillo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motivoMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.haber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoCajaMenor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgLibroDiario)).BeginInit();
            this.SuspendLayout();
            // 
            // dtFecha
            // 
            this.dtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(12, 12);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(136, 26);
            this.dtFecha.TabIndex = 0;
            // 
            // rbAño
            // 
            this.rbAño.AutoSize = true;
            this.rbAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAño.Location = new System.Drawing.Point(166, 14);
            this.rbAño.Name = "rbAño";
            this.rbAño.Size = new System.Drawing.Size(59, 24);
            this.rbAño.TabIndex = 1;
            this.rbAño.TabStop = true;
            this.rbAño.Text = "Año";
            this.rbAño.UseVisualStyleBackColor = true;
            this.rbAño.CheckedChanged += new System.EventHandler(this.rbAño_CheckedChanged);
            // 
            // rbMes
            // 
            this.rbMes.AutoSize = true;
            this.rbMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMes.Location = new System.Drawing.Point(247, 15);
            this.rbMes.Name = "rbMes";
            this.rbMes.Size = new System.Drawing.Size(60, 24);
            this.rbMes.TabIndex = 2;
            this.rbMes.TabStop = true;
            this.rbMes.Text = "Mes";
            this.rbMes.UseVisualStyleBackColor = true;
            this.rbMes.CheckedChanged += new System.EventHandler(this.rbMes_CheckedChanged);
            // 
            // rbDia
            // 
            this.rbDia.AutoSize = true;
            this.rbDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDia.Location = new System.Drawing.Point(331, 15);
            this.rbDia.Name = "rbDia";
            this.rbDia.Size = new System.Drawing.Size(54, 24);
            this.rbDia.TabIndex = 3;
            this.rbDia.TabStop = true;
            this.rbDia.Text = "Día";
            this.rbDia.UseVisualStyleBackColor = true;
            this.rbDia.CheckedChanged += new System.EventHandler(this.rbDia_CheckedChanged);
            // 
            // dgLibroDiario
            // 
            this.dgLibroDiario.AllowUserToAddRows = false;
            this.dgLibroDiario.AllowUserToDeleteRows = false;
            this.dgLibroDiario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgLibroDiario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgLibroDiario.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgLibroDiario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgLibroDiario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLibroDiario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fechaMovimiento,
            this.idUsuario,
            this.nombre_usuario,
            this.idBolsillo,
            this.nombreBolsillo,
            this.motivoMovimiento,
            this.debe,
            this.haber,
            this.saldoTotal,
            this.saldoCaja,
            this.saldoBanco,
            this.saldoCajaMenor});
            this.dgLibroDiario.Location = new System.Drawing.Point(12, 45);
            this.dgLibroDiario.Name = "dgLibroDiario";
            this.dgLibroDiario.ReadOnly = true;
            this.dgLibroDiario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLibroDiario.Size = new System.Drawing.Size(559, 312);
            this.dgLibroDiario.TabIndex = 4;
            // 
            // btnTraslado
            // 
            this.btnTraslado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTraslado.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_actualizar_100;
            this.btnTraslado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTraslado.FlatAppearance.BorderSize = 0;
            this.btnTraslado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraslado.Location = new System.Drawing.Point(479, 5);
            this.btnTraslado.Name = "btnTraslado";
            this.btnTraslado.Size = new System.Drawing.Size(43, 34);
            this.btnTraslado.TabIndex = 6;
            this.btnTraslado.UseVisualStyleBackColor = true;
            this.btnTraslado.Click += new System.EventHandler(this.btnTraslado_Click);
            // 
            // btnEliminarFiltro
            // 
            this.btnEliminarFiltro.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_eliminar_filtros_100;
            this.btnEliminarFiltro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminarFiltro.FlatAppearance.BorderSize = 0;
            this.btnEliminarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFiltro.Location = new System.Drawing.Point(400, 5);
            this.btnEliminarFiltro.Name = "btnEliminarFiltro";
            this.btnEliminarFiltro.Size = new System.Drawing.Size(43, 34);
            this.btnEliminarFiltro.TabIndex = 5;
            this.btnEliminarFiltro.UseVisualStyleBackColor = true;
            this.btnEliminarFiltro.Click += new System.EventHandler(this.btnEliminarFiltro_Click);
            // 
            // btnBase
            // 
            this.btnBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBase.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_bloquear_base_de_datos_100;
            this.btnBase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBase.FlatAppearance.BorderSize = 0;
            this.btnBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBase.Location = new System.Drawing.Point(528, 4);
            this.btnBase.Name = "btnBase";
            this.btnBase.Size = new System.Drawing.Size(43, 34);
            this.btnBase.TabIndex = 7;
            this.btnBase.UseVisualStyleBackColor = true;
            this.btnBase.Click += new System.EventHandler(this.btnBase_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 46;
            // 
            // fechaMovimiento
            // 
            this.fechaMovimiento.DataPropertyName = "fechaMovimiento";
            this.fechaMovimiento.HeaderText = "Fecha";
            this.fechaMovimiento.Name = "fechaMovimiento";
            this.fechaMovimiento.ReadOnly = true;
            this.fechaMovimiento.Width = 76;
            // 
            // idUsuario
            // 
            this.idUsuario.DataPropertyName = "idUsuario";
            this.idUsuario.HeaderText = "idUsuario";
            this.idUsuario.Name = "idUsuario";
            this.idUsuario.ReadOnly = true;
            this.idUsuario.Visible = false;
            // 
            // nombre_usuario
            // 
            this.nombre_usuario.DataPropertyName = "nombre_usuario";
            this.nombre_usuario.HeaderText = "Usuario";
            this.nombre_usuario.Name = "nombre_usuario";
            this.nombre_usuario.ReadOnly = true;
            this.nombre_usuario.Visible = false;
            this.nombre_usuario.Width = 87;
            // 
            // idBolsillo
            // 
            this.idBolsillo.DataPropertyName = "idBolsillo";
            this.idBolsillo.HeaderText = "idBolsillo";
            this.idBolsillo.Name = "idBolsillo";
            this.idBolsillo.ReadOnly = true;
            this.idBolsillo.Visible = false;
            this.idBolsillo.Width = 98;
            // 
            // nombreBolsillo
            // 
            this.nombreBolsillo.DataPropertyName = "nombreBolsillo";
            this.nombreBolsillo.HeaderText = "Bolsillo";
            this.nombreBolsillo.Name = "nombreBolsillo";
            this.nombreBolsillo.ReadOnly = true;
            this.nombreBolsillo.Width = 85;
            // 
            // motivoMovimiento
            // 
            this.motivoMovimiento.DataPropertyName = "motivoMovimiento";
            this.motivoMovimiento.HeaderText = "Detalle";
            this.motivoMovimiento.Name = "motivoMovimiento";
            this.motivoMovimiento.ReadOnly = true;
            this.motivoMovimiento.Width = 83;
            // 
            // debe
            // 
            this.debe.DataPropertyName = "debe";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.Format = "c0";
            this.debe.DefaultCellStyle = dataGridViewCellStyle2;
            this.debe.HeaderText = "Igreso";
            this.debe.Name = "debe";
            this.debe.ReadOnly = true;
            this.debe.Width = 77;
            // 
            // haber
            // 
            this.haber.DataPropertyName = "haber";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Format = "c0";
            this.haber.DefaultCellStyle = dataGridViewCellStyle3;
            this.haber.HeaderText = "Egreso";
            this.haber.Name = "haber";
            this.haber.ReadOnly = true;
            this.haber.Width = 83;
            // 
            // saldoTotal
            // 
            this.saldoTotal.DataPropertyName = "saldoTotal";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.Format = "c0";
            this.saldoTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.saldoTotal.HeaderText = "Saldo Total";
            this.saldoTotal.Name = "saldoTotal";
            this.saldoTotal.ReadOnly = true;
            this.saldoTotal.Width = 114;
            // 
            // saldoCaja
            // 
            this.saldoCaja.DataPropertyName = "saldoCaja";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Format = "c0";
            this.saldoCaja.DefaultCellStyle = dataGridViewCellStyle5;
            this.saldoCaja.HeaderText = "Saldo Caja";
            this.saldoCaja.Name = "saldoCaja";
            this.saldoCaja.ReadOnly = true;
            this.saldoCaja.Width = 110;
            // 
            // saldoBanco
            // 
            this.saldoBanco.DataPropertyName = "saldoBanco";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle6.Format = "c0";
            this.saldoBanco.DefaultCellStyle = dataGridViewCellStyle6;
            this.saldoBanco.HeaderText = "Saldo Banco";
            this.saldoBanco.Name = "saldoBanco";
            this.saldoBanco.ReadOnly = true;
            this.saldoBanco.Width = 112;
            // 
            // saldoCajaMenor
            // 
            this.saldoCajaMenor.DataPropertyName = "saldoCajaMenor";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle7.Format = "c0";
            this.saldoCajaMenor.DefaultCellStyle = dataGridViewCellStyle7;
            this.saldoCajaMenor.HeaderText = "Saldo Caja Menor";
            this.saldoCajaMenor.Name = "saldoCajaMenor";
            this.saldoCajaMenor.ReadOnly = true;
            this.saldoCajaMenor.Width = 143;
            // 
            // frmLibroDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 369);
            this.Controls.Add(this.btnBase);
            this.Controls.Add(this.btnTraslado);
            this.Controls.Add(this.btnEliminarFiltro);
            this.Controls.Add(this.dgLibroDiario);
            this.Controls.Add(this.rbDia);
            this.Controls.Add(this.rbMes);
            this.Controls.Add(this.rbAño);
            this.Controls.Add(this.dtFecha);
            this.Name = "frmLibroDiario";
            this.Text = "frmLibroDiario";
            this.Load += new System.EventHandler(this.frmLibroDiario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLibroDiario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.RadioButton rbAño;
        private System.Windows.Forms.RadioButton rbMes;
        private System.Windows.Forms.RadioButton rbDia;
        private System.Windows.Forms.Button btnEliminarFiltro;
        private System.Windows.Forms.Button btnTraslado;
        public System.Windows.Forms.DataGridView dgLibroDiario;
        private System.Windows.Forms.Button btnBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBolsillo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreBolsillo;
        private System.Windows.Forms.DataGridViewTextBoxColumn motivoMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn debe;
        private System.Windows.Forms.DataGridViewTextBoxColumn haber;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoCajaMenor;
    }
}
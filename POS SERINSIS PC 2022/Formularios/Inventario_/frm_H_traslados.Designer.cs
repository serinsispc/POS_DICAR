namespace SERINSI_PC.Formularios.Inventario
{
    partial class frm_H_traslados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_H_traslados));
            this.dgHTraslados = new System.Windows.Forms.DataGridView();
            this.v_idTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_guidTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_fechaTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_idusuarioTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_NombreusuarioTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_idSedeTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_tipoTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_descripcionTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_SedeEnvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_SedeRecibido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminarFiltro = new System.Windows.Forms.Button();
            this.rbDia = new System.Windows.Forms.RadioButton();
            this.rbMes = new System.Windows.Forms.RadioButton();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.btnImrpimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgHTraslados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgHTraslados
            // 
            this.dgHTraslados.AllowUserToAddRows = false;
            this.dgHTraslados.AllowUserToDeleteRows = false;
            this.dgHTraslados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgHTraslados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgHTraslados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgHTraslados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgHTraslados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHTraslados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.v_idTraslado,
            this.v_guidTraslado,
            this.v_fechaTraslado,
            this.v_idusuarioTraslado,
            this.v_NombreusuarioTraslado,
            this.v_idSedeTraslado,
            this.v_tipoTraslado,
            this.v_descripcionTraslado,
            this.v_SedeEnvio,
            this.v_SedeRecibido});
            this.dgHTraslados.Location = new System.Drawing.Point(11, 81);
            this.dgHTraslados.Name = "dgHTraslados";
            this.dgHTraslados.ReadOnly = true;
            this.dgHTraslados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHTraslados.Size = new System.Drawing.Size(561, 250);
            this.dgHTraslados.TabIndex = 79;
            // 
            // v_idTraslado
            // 
            this.v_idTraslado.DataPropertyName = "v_idTraslado";
            this.v_idTraslado.HeaderText = "v_idTraslado";
            this.v_idTraslado.Name = "v_idTraslado";
            this.v_idTraslado.ReadOnly = true;
            this.v_idTraslado.Visible = false;
            this.v_idTraslado.Width = 114;
            // 
            // v_guidTraslado
            // 
            this.v_guidTraslado.DataPropertyName = "v_guidTraslado";
            this.v_guidTraslado.HeaderText = "v_guidTraslado";
            this.v_guidTraslado.Name = "v_guidTraslado";
            this.v_guidTraslado.ReadOnly = true;
            this.v_guidTraslado.Visible = false;
            this.v_guidTraslado.Width = 130;
            // 
            // v_fechaTraslado
            // 
            this.v_fechaTraslado.DataPropertyName = "v_fechaTraslado";
            this.v_fechaTraslado.HeaderText = "Fecha";
            this.v_fechaTraslado.Name = "v_fechaTraslado";
            this.v_fechaTraslado.ReadOnly = true;
            this.v_fechaTraslado.Width = 71;
            // 
            // v_idusuarioTraslado
            // 
            this.v_idusuarioTraslado.DataPropertyName = "v_idusuarioTraslado";
            this.v_idusuarioTraslado.HeaderText = "v_idusuarioTraslado";
            this.v_idusuarioTraslado.Name = "v_idusuarioTraslado";
            this.v_idusuarioTraslado.ReadOnly = true;
            this.v_idusuarioTraslado.Visible = false;
            this.v_idusuarioTraslado.Width = 162;
            // 
            // v_NombreusuarioTraslado
            // 
            this.v_NombreusuarioTraslado.DataPropertyName = "v_NombreusuarioTraslado";
            this.v_NombreusuarioTraslado.HeaderText = "Usuario";
            this.v_NombreusuarioTraslado.Name = "v_NombreusuarioTraslado";
            this.v_NombreusuarioTraslado.ReadOnly = true;
            this.v_NombreusuarioTraslado.Width = 82;
            // 
            // v_idSedeTraslado
            // 
            this.v_idSedeTraslado.DataPropertyName = "v_idSedeTraslado";
            this.v_idSedeTraslado.HeaderText = "v_idSedeTraslado";
            this.v_idSedeTraslado.Name = "v_idSedeTraslado";
            this.v_idSedeTraslado.ReadOnly = true;
            this.v_idSedeTraslado.Visible = false;
            this.v_idSedeTraslado.Width = 147;
            // 
            // v_tipoTraslado
            // 
            this.v_tipoTraslado.DataPropertyName = "v_tipoTraslado";
            this.v_tipoTraslado.HeaderText = "Tipo";
            this.v_tipoTraslado.Name = "v_tipoTraslado";
            this.v_tipoTraslado.ReadOnly = true;
            this.v_tipoTraslado.Width = 60;
            // 
            // v_descripcionTraslado
            // 
            this.v_descripcionTraslado.DataPropertyName = "v_descripcionTraslado";
            this.v_descripcionTraslado.HeaderText = "Descripcion";
            this.v_descripcionTraslado.Name = "v_descripcionTraslado";
            this.v_descripcionTraslado.ReadOnly = true;
            this.v_descripcionTraslado.Width = 108;
            // 
            // v_SedeEnvio
            // 
            this.v_SedeEnvio.DataPropertyName = "v_SedeEnvio";
            this.v_SedeEnvio.HeaderText = "Enviado desde";
            this.v_SedeEnvio.Name = "v_SedeEnvio";
            this.v_SedeEnvio.ReadOnly = true;
            this.v_SedeEnvio.Width = 115;
            // 
            // v_SedeRecibido
            // 
            this.v_SedeRecibido.DataPropertyName = "v_SedeRecibido";
            this.v_SedeRecibido.HeaderText = "Recibido en";
            this.v_SedeRecibido.Name = "v_SedeRecibido";
            this.v_SedeRecibido.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(578, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 34);
            this.label5.TabIndex = 78;
            this.label5.Text = "Ver Detalle";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(578, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 19);
            this.label8.TabIndex = 74;
            this.label8.Text = "Imprimir";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEliminarFiltro);
            this.groupBox1.Controls.Add(this.rbDia);
            this.groupBox1.Controls.Add(this.rbMes);
            this.groupBox1.Controls.Add(this.dtFecha);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 68);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar";
            // 
            // btnEliminarFiltro
            // 
            this.btnEliminarFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarFiltro.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_eliminar_filtros_100;
            this.btnEliminarFiltro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarFiltro.FlatAppearance.BorderSize = 0;
            this.btnEliminarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFiltro.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarFiltro.Location = new System.Drawing.Point(581, 12);
            this.btnEliminarFiltro.Name = "btnEliminarFiltro";
            this.btnEliminarFiltro.Size = new System.Drawing.Size(66, 50);
            this.btnEliminarFiltro.TabIndex = 67;
            this.btnEliminarFiltro.UseVisualStyleBackColor = true;
            this.btnEliminarFiltro.Click += new System.EventHandler(this.btnEliminarFiltro_Click);
            // 
            // rbDia
            // 
            this.rbDia.AutoSize = true;
            this.rbDia.Location = new System.Drawing.Point(195, 28);
            this.rbDia.Name = "rbDia";
            this.rbDia.Size = new System.Drawing.Size(46, 19);
            this.rbDia.TabIndex = 4;
            this.rbDia.TabStop = true;
            this.rbDia.Text = "Día";
            this.rbDia.UseVisualStyleBackColor = true;
            this.rbDia.CheckedChanged += new System.EventHandler(this.rbDia_CheckedChanged);
            // 
            // rbMes
            // 
            this.rbMes.AutoSize = true;
            this.rbMes.Location = new System.Drawing.Point(143, 28);
            this.rbMes.Name = "rbMes";
            this.rbMes.Size = new System.Drawing.Size(46, 19);
            this.rbMes.TabIndex = 3;
            this.rbMes.TabStop = true;
            this.rbMes.Text = "Mes";
            this.rbMes.UseVisualStyleBackColor = true;
            this.rbMes.CheckedChanged += new System.EventHandler(this.rbMes_CheckedChanged);
            // 
            // dtFecha
            // 
            this.dtFecha.CalendarFont = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(15, 37);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(114, 23);
            this.dtFecha.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            // 
            // btnDetalle
            // 
            this.btnDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetalle.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_ver_detalles_100;
            this.btnDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetalle.FlatAppearance.BorderSize = 0;
            this.btnDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalle.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.Location = new System.Drawing.Point(579, 154);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(66, 50);
            this.btnDetalle.TabIndex = 77;
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // btnImrpimir
            // 
            this.btnImrpimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImrpimir.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_imprimir_100;
            this.btnImrpimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImrpimir.FlatAppearance.BorderSize = 0;
            this.btnImrpimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImrpimir.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImrpimir.Location = new System.Drawing.Point(579, 79);
            this.btnImrpimir.Name = "btnImrpimir";
            this.btnImrpimir.Size = new System.Drawing.Size(66, 50);
            this.btnImrpimir.TabIndex = 73;
            this.btnImrpimir.UseVisualStyleBackColor = true;
            this.btnImrpimir.Click += new System.EventHandler(this.btnImrpimir_Click);
            // 
            // frm_H_traslados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 336);
            this.Controls.Add(this.dgHTraslados);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnImrpimir);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_H_traslados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Traslado";
            this.Load += new System.EventHandler(this.frm_H_traslados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgHTraslados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgHTraslados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button btnImrpimir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDia;
        private System.Windows.Forms.RadioButton rbMes;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminarFiltro;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_idTraslado;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_guidTraslado;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_fechaTraslado;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_idusuarioTraslado;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_NombreusuarioTraslado;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_idSedeTraslado;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_tipoTraslado;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_descripcionTraslado;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_SedeEnvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_SedeRecibido;
    }
}
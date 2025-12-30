namespace SERINSI_PC.Formularios.Configuracion
{
    partial class frmAsignarSede
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSede = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.dgSedeAsignada = new System.Windows.Forms.DataGridView();
            this.v_idSAsignacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_idSedeAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_idusuarioAsignado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_nombreusuarioAsignado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_nombre_empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSedeAsignada)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 23);
            this.panel1.TabIndex = 11;
            this.panel1.Visible = false;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Location = new System.Drawing.Point(448, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(23, 23);
            this.btnMinimizar.TabIndex = 27;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Asignar sede";
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
            this.btnCerrar.Location = new System.Drawing.Point(474, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(23, 23);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(16, 48);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(455, 26);
            this.cmbUsuario.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.Location = new System.Drawing.Point(12, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 18);
            this.label4.TabIndex = 32;
            this.label4.Text = "Usuario";
            // 
            // cmbSede
            // 
            this.cmbSede.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSede.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSede.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbSede.FormattingEnabled = true;
            this.cmbSede.Location = new System.Drawing.Point(17, 99);
            this.cmbSede.Name = "cmbSede";
            this.cmbSede.Size = new System.Drawing.Size(455, 26);
            this.cmbSede.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(13, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 34;
            this.label2.Text = "Sede";
            // 
            // btnAsignar
            // 
            this.btnAsignar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignar.Location = new System.Drawing.Point(17, 131);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(454, 35);
            this.btnAsignar.TabIndex = 36;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // dgSedeAsignada
            // 
            this.dgSedeAsignada.AllowUserToAddRows = false;
            this.dgSedeAsignada.AllowUserToDeleteRows = false;
            this.dgSedeAsignada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSedeAsignada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgSedeAsignada.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSedeAsignada.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgSedeAsignada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSedeAsignada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.v_idSAsignacion,
            this.v_idSedeAsignada,
            this.v_idusuarioAsignado,
            this.v_nombreusuarioAsignado,
            this.v_nombre_empresa});
            this.dgSedeAsignada.Location = new System.Drawing.Point(17, 172);
            this.dgSedeAsignada.Name = "dgSedeAsignada";
            this.dgSedeAsignada.ReadOnly = true;
            this.dgSedeAsignada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSedeAsignada.Size = new System.Drawing.Size(454, 209);
            this.dgSedeAsignada.TabIndex = 37;
            this.dgSedeAsignada.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSedeAsignada_CellDoubleClick);
            // 
            // v_idSAsignacion
            // 
            this.v_idSAsignacion.DataPropertyName = "v_idSAsignacion";
            this.v_idSAsignacion.HeaderText = "v_idSAsignacion";
            this.v_idSAsignacion.Name = "v_idSAsignacion";
            this.v_idSAsignacion.ReadOnly = true;
            this.v_idSAsignacion.Visible = false;
            this.v_idSAsignacion.Width = 149;
            // 
            // v_idSedeAsignada
            // 
            this.v_idSedeAsignada.DataPropertyName = "v_idSedeAsignada";
            this.v_idSedeAsignada.HeaderText = "v_idSedeAsignada";
            this.v_idSedeAsignada.Name = "v_idSedeAsignada";
            this.v_idSedeAsignada.ReadOnly = true;
            this.v_idSedeAsignada.Visible = false;
            this.v_idSedeAsignada.Width = 165;
            // 
            // v_idusuarioAsignado
            // 
            this.v_idusuarioAsignado.DataPropertyName = "v_idusuarioAsignado";
            this.v_idusuarioAsignado.HeaderText = "v_idusuarioAsignado";
            this.v_idusuarioAsignado.Name = "v_idusuarioAsignado";
            this.v_idusuarioAsignado.ReadOnly = true;
            this.v_idusuarioAsignado.Visible = false;
            this.v_idusuarioAsignado.Width = 179;
            // 
            // v_nombreusuarioAsignado
            // 
            this.v_nombreusuarioAsignado.DataPropertyName = "v_nombreusuarioAsignado";
            this.v_nombreusuarioAsignado.HeaderText = "Usuario";
            this.v_nombreusuarioAsignado.Name = "v_nombreusuarioAsignado";
            this.v_nombreusuarioAsignado.ReadOnly = true;
            this.v_nombreusuarioAsignado.Width = 87;
            // 
            // v_nombre_empresa
            // 
            this.v_nombre_empresa.DataPropertyName = "v_nombre_empresa";
            this.v_nombre_empresa.HeaderText = "Sede";
            this.v_nombre_empresa.Name = "v_nombre_empresa";
            this.v_nombre_empresa.ReadOnly = true;
            this.v_nombre_empresa.Width = 70;
            // 
            // frmAsignarSede
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 393);
            this.Controls.Add(this.dgSedeAsignada);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.cmbSede);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAsignarSede";
            this.Text = "frmAsignarSede";
            this.Load += new System.EventHandler(this.frmAsignarSede_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSedeAsignada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSede;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.DataGridView dgSedeAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_idSAsignacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_idSedeAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_idusuarioAsignado;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_nombreusuarioAsignado;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_nombre_empresa;
    }
}
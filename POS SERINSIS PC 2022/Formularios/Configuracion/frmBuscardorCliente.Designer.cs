namespace POS_SERINSIS_PC_2022.Formularios.Configuracion
{
    partial class frmBuscardorCliente
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnSeleccionarCliente = new FontAwesome.Sharp.IconButton();
            this.dgBuscarCliente = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudadCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barrioCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSeleccionarTodos = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalFiltro = new System.Windows.Forms.TextBox();
            this.txtBuscarCiudad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuscarBarrio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgBuscarCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Buscar Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCliente.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(15, 28);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(114, 24);
            this.txtCliente.TabIndex = 55;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown);
            // 
            // btnSeleccionarCliente
            // 
            this.btnSeleccionarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarCliente.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnSeleccionarCliente.IconColor = System.Drawing.Color.Black;
            this.btnSeleccionarCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSeleccionarCliente.IconSize = 40;
            this.btnSeleccionarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarCliente.Location = new System.Drawing.Point(649, 9);
            this.btnSeleccionarCliente.Name = "btnSeleccionarCliente";
            this.btnSeleccionarCliente.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnSeleccionarCliente.Size = new System.Drawing.Size(139, 45);
            this.btnSeleccionarCliente.TabIndex = 56;
            this.btnSeleccionarCliente.Text = "Seleccionar Cliente";
            this.btnSeleccionarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeleccionarCliente.UseVisualStyleBackColor = true;
            this.btnSeleccionarCliente.Click += new System.EventHandler(this.btnSeleccionarCliente_Click);
            // 
            // dgBuscarCliente
            // 
            this.dgBuscarCliente.AllowUserToAddRows = false;
            this.dgBuscarCliente.AllowUserToDeleteRows = false;
            this.dgBuscarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBuscarCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBuscarCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgBuscarCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBuscarCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.codigoCliente,
            this.nombreCliente,
            this.razonSocialCliente,
            this.documentoCliente,
            this.direccionCliente,
            this.telefonoCliente,
            this.ciudadCliente,
            this.barrioCliente,
            this.idSede});
            this.dgBuscarCliente.Location = new System.Drawing.Point(15, 58);
            this.dgBuscarCliente.Name = "dgBuscarCliente";
            this.dgBuscarCliente.ReadOnly = true;
            this.dgBuscarCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBuscarCliente.Size = new System.Drawing.Size(773, 380);
            this.dgBuscarCliente.TabIndex = 57;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 40;
            // 
            // codigoCliente
            // 
            this.codigoCliente.DataPropertyName = "codigoCliente";
            this.codigoCliente.HeaderText = "Código";
            this.codigoCliente.Name = "codigoCliente";
            this.codigoCliente.ReadOnly = true;
            this.codigoCliente.Width = 82;
            // 
            // nombreCliente
            // 
            this.nombreCliente.DataPropertyName = "nombreCliente";
            this.nombreCliente.HeaderText = "Cliente";
            this.nombreCliente.Name = "nombreCliente";
            this.nombreCliente.ReadOnly = true;
            this.nombreCliente.Width = 80;
            // 
            // razonSocialCliente
            // 
            this.razonSocialCliente.DataPropertyName = "razonSocialCliente";
            this.razonSocialCliente.HeaderText = "Razon Social";
            this.razonSocialCliente.Name = "razonSocialCliente";
            this.razonSocialCliente.ReadOnly = true;
            this.razonSocialCliente.Width = 114;
            // 
            // documentoCliente
            // 
            this.documentoCliente.DataPropertyName = "documentoCliente";
            this.documentoCliente.HeaderText = "Documento";
            this.documentoCliente.Name = "documentoCliente";
            this.documentoCliente.ReadOnly = true;
            this.documentoCliente.Width = 110;
            // 
            // direccionCliente
            // 
            this.direccionCliente.DataPropertyName = "direccionCliente";
            this.direccionCliente.HeaderText = "Dirección";
            this.direccionCliente.Name = "direccionCliente";
            this.direccionCliente.ReadOnly = true;
            this.direccionCliente.Width = 98;
            // 
            // telefonoCliente
            // 
            this.telefonoCliente.DataPropertyName = "telefonoCliente";
            this.telefonoCliente.HeaderText = "Teléfono";
            this.telefonoCliente.Name = "telefonoCliente";
            this.telefonoCliente.ReadOnly = true;
            this.telefonoCliente.Width = 94;
            // 
            // ciudadCliente
            // 
            this.ciudadCliente.DataPropertyName = "ciudadCliente";
            this.ciudadCliente.HeaderText = "Ciudad";
            this.ciudadCliente.Name = "ciudadCliente";
            this.ciudadCliente.ReadOnly = true;
            this.ciudadCliente.Width = 81;
            // 
            // barrioCliente
            // 
            this.barrioCliente.DataPropertyName = "barrioCliente";
            this.barrioCliente.HeaderText = "Barrio";
            this.barrioCliente.Name = "barrioCliente";
            this.barrioCliente.ReadOnly = true;
            this.barrioCliente.Width = 74;
            // 
            // idSede
            // 
            this.idSede.DataPropertyName = "idSede";
            this.idSede.HeaderText = "idSede";
            this.idSede.Name = "idSede";
            this.idSede.ReadOnly = true;
            this.idSede.Visible = false;
            this.idSede.Width = 65;
            // 
            // btnSeleccionarTodos
            // 
            this.btnSeleccionarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionarTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarTodos.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnSeleccionarTodos.IconColor = System.Drawing.Color.Black;
            this.btnSeleccionarTodos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSeleccionarTodos.IconSize = 40;
            this.btnSeleccionarTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarTodos.Location = new System.Drawing.Point(504, 9);
            this.btnSeleccionarTodos.Name = "btnSeleccionarTodos";
            this.btnSeleccionarTodos.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnSeleccionarTodos.Size = new System.Drawing.Size(139, 45);
            this.btnSeleccionarTodos.TabIndex = 58;
            this.btnSeleccionarTodos.Text = "Seleccionar Totos";
            this.btnSeleccionarTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeleccionarTodos.UseVisualStyleBackColor = true;
            this.btnSeleccionarTodos.Click += new System.EventHandler(this.btnSeleccionarTodos_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(416, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 59;
            this.label2.Text = "Total Filtro";
            // 
            // txtTotalFiltro
            // 
            this.txtTotalFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalFiltro.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtTotalFiltro.Enabled = false;
            this.txtTotalFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalFiltro.Location = new System.Drawing.Point(419, 28);
            this.txtTotalFiltro.Name = "txtTotalFiltro";
            this.txtTotalFiltro.Size = new System.Drawing.Size(79, 24);
            this.txtTotalFiltro.TabIndex = 60;
            this.txtTotalFiltro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBuscarCiudad
            // 
            this.txtBuscarCiudad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarCiudad.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtBuscarCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCiudad.Location = new System.Drawing.Point(135, 30);
            this.txtBuscarCiudad.Name = "txtBuscarCiudad";
            this.txtBuscarCiudad.Size = new System.Drawing.Size(136, 24);
            this.txtBuscarCiudad.TabIndex = 62;
            this.txtBuscarCiudad.TextChanged += new System.EventHandler(this.txtBuscarCiudad_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(132, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 61;
            this.label3.Text = "Buscar Ciudad";
            // 
            // txtBuscarBarrio
            // 
            this.txtBuscarBarrio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarBarrio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarBarrio.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtBuscarBarrio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarBarrio.Location = new System.Drawing.Point(277, 30);
            this.txtBuscarBarrio.Name = "txtBuscarBarrio";
            this.txtBuscarBarrio.Size = new System.Drawing.Size(136, 24);
            this.txtBuscarBarrio.TabIndex = 64;
            this.txtBuscarBarrio.TextChanged += new System.EventHandler(this.txtBuscarBarrio_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(274, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 63;
            this.label4.Text = "Buscar Barrio";
            // 
            // frmBuscardorCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.txtBuscarBarrio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBuscarCiudad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalFiltro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSeleccionarTodos);
            this.Controls.Add(this.dgBuscarCliente);
            this.Controls.Add(this.btnSeleccionarCliente);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label1);
            this.Name = "frmBuscardorCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBuscardorCliente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBuscardorCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBuscarCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private FontAwesome.Sharp.IconButton btnSeleccionarCliente;
        private System.Windows.Forms.DataGridView dgBuscarCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudadCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn barrioCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSede;
        private FontAwesome.Sharp.IconButton btnSeleccionarTodos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalFiltro;
        private System.Windows.Forms.TextBox txtBuscarCiudad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBuscarBarrio;
        private System.Windows.Forms.Label label4;
    }
}
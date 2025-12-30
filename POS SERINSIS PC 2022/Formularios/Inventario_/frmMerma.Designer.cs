namespace SERINSI_PC.Formularios.Inventario
{
    partial class frmMerma
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoMerma = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFechaMerma = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcionProducto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtBuscarCodigo = new System.Windows.Forms.TextBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgMerma = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaMerma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoMerma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreTipoMerma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInventarioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrePresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contenidoPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadMerma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgMerma)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Merma";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Observación";
            // 
            // cmbTipoMerma
            // 
            this.cmbTipoMerma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMerma.FormattingEnabled = true;
            this.cmbTipoMerma.Location = new System.Drawing.Point(15, 30);
            this.cmbTipoMerma.Name = "cmbTipoMerma";
            this.cmbTipoMerma.Size = new System.Drawing.Size(152, 21);
            this.cmbTipoMerma.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(173, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha";
            // 
            // dtFechaMerma
            // 
            this.dtFechaMerma.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaMerma.Location = new System.Drawing.Point(176, 31);
            this.dtFechaMerma.Name = "dtFechaMerma";
            this.dtFechaMerma.Size = new System.Drawing.Size(103, 20);
            this.dtFechaMerma.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(282, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Codigo Producto";
            // 
            // txtDescripcionProducto
            // 
            this.txtDescripcionProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcionProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcionProducto.Enabled = false;
            this.txtDescripcionProducto.Location = new System.Drawing.Point(416, 30);
            this.txtDescripcionProducto.Name = "txtDescripcionProducto";
            this.txtDescripcionProducto.Size = new System.Drawing.Size(392, 20);
            this.txtDescripcionProducto.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(413, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Descripción Producto ";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(813, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 40);
            this.label10.TabIndex = 11;
            this.label10.Text = "Guardar Merma";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(809, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 40);
            this.label6.TabIndex = 13;
            this.label6.Text = "Eliminar Merma";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCantidad.Location = new System.Drawing.Point(813, 96);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(70, 20);
            this.txtCantidad.TabIndex = 17;
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(812, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "Cantidad";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(64, 54);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(103, 13);
            this.linkLabel1.TabIndex = 19;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Agregar Tipo Merma";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtBuscarCodigo
            // 
            this.txtBuscarCodigo.Location = new System.Drawing.Point(285, 31);
            this.txtBuscarCodigo.Name = "txtBuscarCodigo";
            this.txtBuscarCodigo.Size = new System.Drawing.Size(125, 20);
            this.txtBuscarCodigo.TabIndex = 20;
            this.txtBuscarCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarCodigo_KeyDown);
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarProducto.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_ver_archivo_96;
            this.btnBuscarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarProducto.FlatAppearance.BorderSize = 0;
            this.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProducto.Location = new System.Drawing.Point(817, 9);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(62, 59);
            this.btnBuscarProducto.TabIndex = 18;
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.eliminarPNG;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(817, 239);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(62, 59);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnEliminar.Enter += new System.EventHandler(this.btnEliminar_Enter);
            this.btnEliminar.Leave += new System.EventHandler(this.btnEliminar_Leave);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.iconoGuardar;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(817, 134);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(62, 59);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnGuardar.Enter += new System.EventHandler(this.btnGuardar_Enter);
            this.btnGuardar.Leave += new System.EventHandler(this.btnGuardar_Leave);
            // 
            // dgMerma
            // 
            this.dgMerma.AllowUserToAddRows = false;
            this.dgMerma.AllowUserToDeleteRows = false;
            this.dgMerma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMerma.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMerma.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgMerma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMerma.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fechaMerma,
            this.idSede,
            this.idTipoMerma,
            this.nombreTipoMerma,
            this.idUsuario,
            this.nombreUsuario,
            this.idInventarioTotal,
            this.idInventario,
            this.codigoProducto,
            this.descripcionProducto,
            this.nombrePresentacion,
            this.contenidoPresentacion,
            this.cantidadMerma,
            this.cantidadUnidad,
            this.observacion});
            this.dgMerma.Location = new System.Drawing.Point(12, 122);
            this.dgMerma.Name = "dgMerma";
            this.dgMerma.ReadOnly = true;
            this.dgMerma.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMerma.Size = new System.Drawing.Size(796, 318);
            this.dgMerma.TabIndex = 22;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // fechaMerma
            // 
            this.fechaMerma.DataPropertyName = "fechaMerma";
            this.fechaMerma.HeaderText = "Fecha";
            this.fechaMerma.Name = "fechaMerma";
            this.fechaMerma.ReadOnly = true;
            this.fechaMerma.Width = 71;
            // 
            // idSede
            // 
            this.idSede.DataPropertyName = "idSede";
            this.idSede.HeaderText = "idSede";
            this.idSede.Name = "idSede";
            this.idSede.ReadOnly = true;
            this.idSede.Visible = false;
            // 
            // idTipoMerma
            // 
            this.idTipoMerma.DataPropertyName = "idTipoMerma";
            this.idTipoMerma.HeaderText = "idTipoMerma";
            this.idTipoMerma.Name = "idTipoMerma";
            this.idTipoMerma.ReadOnly = true;
            this.idTipoMerma.Visible = false;
            // 
            // nombreTipoMerma
            // 
            this.nombreTipoMerma.DataPropertyName = "nombreTipoMerma";
            this.nombreTipoMerma.HeaderText = "Tipo";
            this.nombreTipoMerma.Name = "nombreTipoMerma";
            this.nombreTipoMerma.ReadOnly = true;
            this.nombreTipoMerma.Width = 60;
            // 
            // idUsuario
            // 
            this.idUsuario.DataPropertyName = "idUsuario";
            this.idUsuario.HeaderText = "idUsuario";
            this.idUsuario.Name = "idUsuario";
            this.idUsuario.ReadOnly = true;
            this.idUsuario.Visible = false;
            // 
            // nombreUsuario
            // 
            this.nombreUsuario.DataPropertyName = "nombreUsuario";
            this.nombreUsuario.HeaderText = "Responsable";
            this.nombreUsuario.Name = "nombreUsuario";
            this.nombreUsuario.ReadOnly = true;
            this.nombreUsuario.Width = 116;
            // 
            // idInventarioTotal
            // 
            this.idInventarioTotal.DataPropertyName = "idInventarioTotal";
            this.idInventarioTotal.HeaderText = "idInventarioTotal";
            this.idInventarioTotal.Name = "idInventarioTotal";
            this.idInventarioTotal.ReadOnly = true;
            this.idInventarioTotal.Visible = false;
            // 
            // idInventario
            // 
            this.idInventario.DataPropertyName = "idInventario";
            this.idInventario.HeaderText = "idInventario";
            this.idInventario.Name = "idInventario";
            this.idInventario.ReadOnly = true;
            this.idInventario.Visible = false;
            // 
            // codigoProducto
            // 
            this.codigoProducto.DataPropertyName = "codigoProducto";
            this.codigoProducto.HeaderText = "Código";
            this.codigoProducto.Name = "codigoProducto";
            this.codigoProducto.ReadOnly = true;
            this.codigoProducto.Width = 77;
            // 
            // descripcionProducto
            // 
            this.descripcionProducto.DataPropertyName = "descripcionProducto";
            this.descripcionProducto.HeaderText = "Producto";
            this.descripcionProducto.Name = "descripcionProducto";
            this.descripcionProducto.ReadOnly = true;
            this.descripcionProducto.Width = 89;
            // 
            // nombrePresentacion
            // 
            this.nombrePresentacion.DataPropertyName = "nombrePresentacion";
            this.nombrePresentacion.HeaderText = "Presentación";
            this.nombrePresentacion.Name = "nombrePresentacion";
            this.nombrePresentacion.ReadOnly = true;
            this.nombrePresentacion.Width = 116;
            // 
            // contenidoPresentacion
            // 
            this.contenidoPresentacion.DataPropertyName = "contenidoPresentacion";
            this.contenidoPresentacion.HeaderText = "contenidoPresentacion";
            this.contenidoPresentacion.Name = "contenidoPresentacion";
            this.contenidoPresentacion.ReadOnly = true;
            this.contenidoPresentacion.Visible = false;
            // 
            // cantidadMerma
            // 
            this.cantidadMerma.DataPropertyName = "cantidadMerma";
            this.cantidadMerma.HeaderText = "Cantidad";
            this.cantidadMerma.Name = "cantidadMerma";
            this.cantidadMerma.ReadOnly = true;
            this.cantidadMerma.Width = 89;
            // 
            // cantidadUnidad
            // 
            this.cantidadUnidad.DataPropertyName = "cantidadUnidad";
            this.cantidadUnidad.HeaderText = "cantidadUnidad";
            this.cantidadUnidad.Name = "cantidadUnidad";
            this.cantidadUnidad.ReadOnly = true;
            this.cantidadUnidad.Visible = false;
            // 
            // observacion
            // 
            this.observacion.DataPropertyName = "observacion";
            this.observacion.HeaderText = "Observación";
            this.observacion.Name = "observacion";
            this.observacion.ReadOnly = true;
            this.observacion.Width = 111;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservacion.Location = new System.Drawing.Point(15, 96);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(793, 20);
            this.txtObservacion.TabIndex = 23;
            // 
            // frmMerma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 452);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.dgMerma);
            this.Controls.Add(this.txtBuscarCodigo);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnBuscarProducto);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDescripcionProducto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtFechaMerma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTipoMerma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(624, 388);
            this.Name = "frmMerma";
            this.Text = "frmMerma";
            this.Load += new System.EventHandler(this.frmMerma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMerma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFechaMerma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBuscarProducto;
        public System.Windows.Forms.TextBox txtDescripcionProducto;
        private System.Windows.Forms.LinkLabel linkLabel1;
        public System.Windows.Forms.TextBox txtBuscarCodigo;
        public System.Windows.Forms.ComboBox cmbTipoMerma;
        private System.Windows.Forms.DataGridView dgMerma;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaMerma;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSede;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoMerma;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreTipoMerma;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInventarioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrePresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn contenidoPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadMerma;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion;
        private System.Windows.Forms.TextBox txtObservacion;
    }
}
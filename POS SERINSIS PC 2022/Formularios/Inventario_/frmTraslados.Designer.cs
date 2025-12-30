namespace SERINSI_PC.Formularios.Inventario
{
    partial class frmTraslados
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCargarProducto = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscadorProducto = new System.Windows.Forms.TextBox();
            this.cbRetirarProducto = new System.Windows.Forms.CheckBox();
            this.cbIngresarProducto = new System.Windows.Forms.CheckBox();
            this.dgDetalleTraslado = new System.Windows.Forms.DataGridView();
            this.v_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_guidCorto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_guidDetalleTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_idProductoTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_codigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_descripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_cantidadproductoTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBuscarProducto = new System.Windows.Forms.DataGridView();
            this.id_buscador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_buscador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion_buscador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventarioActual_buscador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSede_buscador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardarTraslado = new System.Windows.Forms.Button();
            this.txtDescripcionTraslado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.cmbSedes = new System.Windows.Forms.ComboBox();
            this.leyendaRetiro = new System.Windows.Forms.Label();
            this.leyendaIngreso = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleTraslado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBuscarProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCantidad
            // 
            this.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtCantidad.Location = new System.Drawing.Point(17, 248);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(69, 20);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "Cantidad";
            // 
            // btnCargarProducto
            // 
            this.btnCargarProducto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCargarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarProducto.Location = new System.Drawing.Point(190, 230);
            this.btnCargarProducto.Name = "btnCargarProducto";
            this.btnCargarProducto.Size = new System.Drawing.Size(217, 38);
            this.btnCargarProducto.TabIndex = 4;
            this.btnCargarProducto.Text = "Agregar Producto";
            this.btnCargarProducto.UseVisualStyleBackColor = true;
            this.btnCargarProducto.Click += new System.EventHandler(this.btnCargarProducto_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(328, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Buscar Producto por Código o Descripción";
            // 
            // txtBuscadorProducto
            // 
            this.txtBuscadorProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscadorProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscadorProducto.Location = new System.Drawing.Point(12, 71);
            this.txtBuscadorProducto.Name = "txtBuscadorProducto";
            this.txtBuscadorProducto.Size = new System.Drawing.Size(920, 20);
            this.txtBuscadorProducto.TabIndex = 0;
            this.txtBuscadorProducto.TextChanged += new System.EventHandler(this.txtBuscadorProducto_TextChanged);
            this.txtBuscadorProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscadorProducto_KeyDown);
            // 
            // cbRetirarProducto
            // 
            this.cbRetirarProducto.AutoSize = true;
            this.cbRetirarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRetirarProducto.Location = new System.Drawing.Point(13, 12);
            this.cbRetirarProducto.Name = "cbRetirarProducto";
            this.cbRetirarProducto.Size = new System.Drawing.Size(247, 35);
            this.cbRetirarProducto.TabIndex = 27;
            this.cbRetirarProducto.Text = "Retirar Producto";
            this.cbRetirarProducto.UseVisualStyleBackColor = true;
            this.cbRetirarProducto.CheckedChanged += new System.EventHandler(this.cbRetirarProducto_CheckedChanged);
            // 
            // cbIngresarProducto
            // 
            this.cbIngresarProducto.AutoSize = true;
            this.cbIngresarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIngresarProducto.Location = new System.Drawing.Point(283, 12);
            this.cbIngresarProducto.Name = "cbIngresarProducto";
            this.cbIngresarProducto.Size = new System.Drawing.Size(266, 35);
            this.cbIngresarProducto.TabIndex = 28;
            this.cbIngresarProducto.Text = "Ingresar Producto";
            this.cbIngresarProducto.UseVisualStyleBackColor = true;
            this.cbIngresarProducto.CheckedChanged += new System.EventHandler(this.cbIngresarProducto_CheckedChanged);
            // 
            // dgDetalleTraslado
            // 
            this.dgDetalleTraslado.AllowUserToAddRows = false;
            this.dgDetalleTraslado.AllowUserToDeleteRows = false;
            this.dgDetalleTraslado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDetalleTraslado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgDetalleTraslado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDetalleTraslado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDetalleTraslado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetalleTraslado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.v_id,
            this.v_guidCorto,
            this.v_guidDetalleTraslado,
            this.v_idProductoTraslado,
            this.v_codigoProducto,
            this.v_descripcionProducto,
            this.v_cantidadproductoTraslado});
            this.dgDetalleTraslado.Location = new System.Drawing.Point(12, 345);
            this.dgDetalleTraslado.Name = "dgDetalleTraslado";
            this.dgDetalleTraslado.ReadOnly = true;
            this.dgDetalleTraslado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDetalleTraslado.Size = new System.Drawing.Size(923, 107);
            this.dgDetalleTraslado.TabIndex = 22;
            this.dgDetalleTraslado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetalleTraslado_CellClick);
            // 
            // v_id
            // 
            this.v_id.DataPropertyName = "v_id";
            this.v_id.HeaderText = "v_id";
            this.v_id.Name = "v_id";
            this.v_id.ReadOnly = true;
            this.v_id.Visible = false;
            this.v_id.Width = 62;
            // 
            // v_guidCorto
            // 
            this.v_guidCorto.DataPropertyName = "v_guidCorto";
            this.v_guidCorto.HeaderText = "ID Traslado";
            this.v_guidCorto.Name = "v_guidCorto";
            this.v_guidCorto.ReadOnly = true;
            this.v_guidCorto.Width = 105;
            // 
            // v_guidDetalleTraslado
            // 
            this.v_guidDetalleTraslado.DataPropertyName = "v_guidDetalleTraslado";
            this.v_guidDetalleTraslado.HeaderText = "v_guidDetalleTraslado";
            this.v_guidDetalleTraslado.Name = "v_guidDetalleTraslado";
            this.v_guidDetalleTraslado.ReadOnly = true;
            this.v_guidDetalleTraslado.Visible = false;
            this.v_guidDetalleTraslado.Width = 192;
            // 
            // v_idProductoTraslado
            // 
            this.v_idProductoTraslado.DataPropertyName = "v_idProductoTraslado";
            this.v_idProductoTraslado.HeaderText = "v_idProductoTraslado";
            this.v_idProductoTraslado.Name = "v_idProductoTraslado";
            this.v_idProductoTraslado.ReadOnly = true;
            this.v_idProductoTraslado.Visible = false;
            this.v_idProductoTraslado.Width = 187;
            // 
            // v_codigoProducto
            // 
            this.v_codigoProducto.DataPropertyName = "v_codigoProducto";
            this.v_codigoProducto.HeaderText = "Código Producto";
            this.v_codigoProducto.Name = "v_codigoProducto";
            this.v_codigoProducto.ReadOnly = true;
            this.v_codigoProducto.Width = 136;
            // 
            // v_descripcionProducto
            // 
            this.v_descripcionProducto.DataPropertyName = "v_descripcionProducto";
            this.v_descripcionProducto.HeaderText = "Descripcion Producto";
            this.v_descripcionProducto.Name = "v_descripcionProducto";
            this.v_descripcionProducto.ReadOnly = true;
            this.v_descripcionProducto.Width = 166;
            // 
            // v_cantidadproductoTraslado
            // 
            this.v_cantidadproductoTraslado.DataPropertyName = "v_cantidadproductoTraslado";
            this.v_cantidadproductoTraslado.HeaderText = "Cantidad";
            this.v_cantidadproductoTraslado.Name = "v_cantidadproductoTraslado";
            this.v_cantidadproductoTraslado.ReadOnly = true;
            this.v_cantidadproductoTraslado.Width = 95;
            // 
            // dgBuscarProducto
            // 
            this.dgBuscarProducto.AllowUserToAddRows = false;
            this.dgBuscarProducto.AllowUserToDeleteRows = false;
            this.dgBuscarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBuscarProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgBuscarProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBuscarProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_buscador,
            this.codigo_buscador,
            this.descripcion_buscador,
            this.inventarioActual_buscador,
            this.idSede_buscador});
            this.dgBuscarProducto.Location = new System.Drawing.Point(12, 92);
            this.dgBuscarProducto.Name = "dgBuscarProducto";
            this.dgBuscarProducto.ReadOnly = true;
            this.dgBuscarProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBuscarProducto.Size = new System.Drawing.Size(920, 132);
            this.dgBuscarProducto.TabIndex = 29;
            this.dgBuscarProducto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBuscarProducto_CellClick);
            this.dgBuscarProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgBuscarProducto_KeyDown);
            // 
            // id_buscador
            // 
            this.id_buscador.DataPropertyName = "id_buscador";
            this.id_buscador.HeaderText = "id_buscador";
            this.id_buscador.Name = "id_buscador";
            this.id_buscador.ReadOnly = true;
            this.id_buscador.Visible = false;
            this.id_buscador.Width = 111;
            // 
            // codigo_buscador
            // 
            this.codigo_buscador.DataPropertyName = "codigo_buscador";
            this.codigo_buscador.HeaderText = "Código";
            this.codigo_buscador.Name = "codigo_buscador";
            this.codigo_buscador.ReadOnly = true;
            this.codigo_buscador.Width = 77;
            // 
            // descripcion_buscador
            // 
            this.descripcion_buscador.DataPropertyName = "descripcion_buscador";
            this.descripcion_buscador.HeaderText = "Descripción";
            this.descripcion_buscador.Name = "descripcion_buscador";
            this.descripcion_buscador.ReadOnly = true;
            this.descripcion_buscador.Width = 500;
            // 
            // inventarioActual_buscador
            // 
            this.inventarioActual_buscador.DataPropertyName = "inventarioActual_buscador";
            this.inventarioActual_buscador.HeaderText = "INV";
            this.inventarioActual_buscador.Name = "inventarioActual_buscador";
            this.inventarioActual_buscador.ReadOnly = true;
            this.inventarioActual_buscador.Width = 54;
            // 
            // idSede_buscador
            // 
            this.idSede_buscador.DataPropertyName = "idSede_buscador";
            this.idSede_buscador.HeaderText = "idSedeProducto";
            this.idSede_buscador.Name = "idSede_buscador";
            this.idSede_buscador.ReadOnly = true;
            this.idSede_buscador.Visible = false;
            this.idSede_buscador.Width = 134;
            // 
            // btnGuardarTraslado
            // 
            this.btnGuardarTraslado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuardarTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarTraslado.Location = new System.Drawing.Point(425, 230);
            this.btnGuardarTraslado.Name = "btnGuardarTraslado";
            this.btnGuardarTraslado.Size = new System.Drawing.Size(217, 38);
            this.btnGuardarTraslado.TabIndex = 30;
            this.btnGuardarTraslado.Text = "Guardar Traslado";
            this.btnGuardarTraslado.UseVisualStyleBackColor = true;
            this.btnGuardarTraslado.Click += new System.EventHandler(this.btnGuardarTraslado_Click);
            // 
            // txtDescripcionTraslado
            // 
            this.txtDescripcionTraslado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcionTraslado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcionTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDescripcionTraslado.Location = new System.Drawing.Point(17, 292);
            this.txtDescripcionTraslado.Multiline = true;
            this.txtDescripcionTraslado.Name = "txtDescripcionTraslado";
            this.txtDescripcionTraslado.Size = new System.Drawing.Size(918, 47);
            this.txtDescripcionTraslado.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 18);
            this.label1.TabIndex = 32;
            this.label1.Text = "Descripcion Traslado";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEliminarProducto.Enabled = false;
            this.btnEliminarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarProducto.Location = new System.Drawing.Point(653, 230);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(217, 38);
            this.btnEliminarProducto.TabIndex = 33;
            this.btnEliminarProducto.Text = "Eliminar Producto";
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // cmbSedes
            // 
            this.cmbSedes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSedes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSedes.FormattingEnabled = true;
            this.cmbSedes.Location = new System.Drawing.Point(571, 44);
            this.cmbSedes.Name = "cmbSedes";
            this.cmbSedes.Size = new System.Drawing.Size(359, 21);
            this.cmbSedes.TabIndex = 34;
            // 
            // leyendaRetiro
            // 
            this.leyendaRetiro.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leyendaRetiro.Location = new System.Drawing.Point(568, 4);
            this.leyendaRetiro.Name = "leyendaRetiro";
            this.leyendaRetiro.Size = new System.Drawing.Size(362, 37);
            this.leyendaRetiro.TabIndex = 35;
            this.leyendaRetiro.Text = "Seleccionar la sede o bodega a donde se va a enviar el traslado.";
            this.leyendaRetiro.Visible = false;
            // 
            // leyendaIngreso
            // 
            this.leyendaIngreso.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leyendaIngreso.Location = new System.Drawing.Point(570, 4);
            this.leyendaIngreso.Name = "leyendaIngreso";
            this.leyendaIngreso.Size = new System.Drawing.Size(362, 37);
            this.leyendaIngreso.TabIndex = 36;
            this.leyendaIngreso.Text = "Seleccionar la sede o bodega de donde se envió el traslado.";
            this.leyendaIngreso.Visible = false;
            // 
            // frmTraslados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 464);
            this.Controls.Add(this.leyendaIngreso);
            this.Controls.Add(this.leyendaRetiro);
            this.Controls.Add(this.cmbSedes);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.txtDescripcionTraslado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuardarTraslado);
            this.Controls.Add(this.dgBuscarProducto);
            this.Controls.Add(this.cbIngresarProducto);
            this.Controls.Add(this.cbRetirarProducto);
            this.Controls.Add(this.dgDetalleTraslado);
            this.Controls.Add(this.btnCargarProducto);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBuscadorProducto);
            this.Controls.Add(this.label4);
            this.MinimumSize = new System.Drawing.Size(600, 503);
            this.Name = "frmTraslados";
            this.Text = "frmTraslados";
            this.Load += new System.EventHandler(this.frmTraslados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleTraslado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBuscarProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCargarProducto;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtBuscadorProducto;
        private System.Windows.Forms.CheckBox cbRetirarProducto;
        private System.Windows.Forms.CheckBox cbIngresarProducto;
        private System.Windows.Forms.DataGridView dgDetalleTraslado;
        private System.Windows.Forms.DataGridView dgBuscarProducto;
        private System.Windows.Forms.Button btnGuardarTraslado;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_buscador;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_buscador;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_buscador;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventarioActual_buscador;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSede_buscador;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_guidCorto;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_guidDetalleTraslado;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_idProductoTraslado;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_codigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_descripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_cantidadproductoTraslado;
        public System.Windows.Forms.TextBox txtDescripcionTraslado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Label leyendaRetiro;
        private System.Windows.Forms.ComboBox cmbSedes;
        private System.Windows.Forms.Label leyendaIngreso;
    }
}
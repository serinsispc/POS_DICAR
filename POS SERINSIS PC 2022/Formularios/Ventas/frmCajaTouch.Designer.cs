namespace SERINSI_PC.Formularios.Ventas
{
    partial class frmCajaTouch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCajaTouch));
            this.dgListaDetalleCompra = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPrecios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrePresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDetalleVentaV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInventarioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contenidoPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentageIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuentoDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recargoDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotalDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSubTotal = new System.Windows.Forms.Label();
            this.flPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.txtCodigoBarra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flPanelCajas = new System.Windows.Forms.FlowLayoutPanel();
            this.btnVender = new FontAwesome.Sharp.IconButton();
            this.btnNuevaCaja = new FontAwesome.Sharp.IconButton();
            this.btnBuscarPedido = new FontAwesome.Sharp.IconButton();
            this.txtGuidPedido = new System.Windows.Forms.TextBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgListaDetalleCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // dgListaDetalleCompra
            // 
            this.dgListaDetalleCompra.AllowUserToAddRows = false;
            this.dgListaDetalleCompra.AllowUserToDeleteRows = false;
            this.dgListaDetalleCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgListaDetalleCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgListaDetalleCompra.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgListaDetalleCompra.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgListaDetalleCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgListaDetalleCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListaDetalleCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idVenta,
            this.idPrecios,
            this.idInventario,
            this.idSede,
            this.descripcionProducto,
            this.nombrePresentacion,
            this.cantidadDetalle,
            this.costoUnidad,
            this.costoTotal,
            this.precioDetalleVentaV,
            this.totalDetalle,
            this.idInventarioTotal,
            this.contenidoPresentacion,
            this.porcentageIVA,
            this.valorIva,
            this.codigoProducto,
            this.descuentoDetalle,
            this.recargoDetalle,
            this.baseIva,
            this.subTotalDetalle});
            this.dgListaDetalleCompra.Location = new System.Drawing.Point(361, 78);
            this.dgListaDetalleCompra.Name = "dgListaDetalleCompra";
            this.dgListaDetalleCompra.ReadOnly = true;
            this.dgListaDetalleCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgListaDetalleCompra.Size = new System.Drawing.Size(646, 294);
            this.dgListaDetalleCompra.TabIndex = 17;
            this.dgListaDetalleCompra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgListaDetalleCompra_CellClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 52;
            // 
            // idVenta
            // 
            this.idVenta.DataPropertyName = "idVenta";
            this.idVenta.HeaderText = "idVenta";
            this.idVenta.Name = "idVenta";
            this.idVenta.ReadOnly = true;
            this.idVenta.Visible = false;
            this.idVenta.Width = 97;
            // 
            // idPrecios
            // 
            this.idPrecios.DataPropertyName = "idPrecios";
            this.idPrecios.HeaderText = "idPrecios";
            this.idPrecios.Name = "idPrecios";
            this.idPrecios.ReadOnly = true;
            this.idPrecios.Visible = false;
            this.idPrecios.Width = 115;
            // 
            // idInventario
            // 
            this.idInventario.DataPropertyName = "idInventario";
            this.idInventario.HeaderText = "idInventario";
            this.idInventario.Name = "idInventario";
            this.idInventario.ReadOnly = true;
            this.idInventario.Visible = false;
            this.idInventario.Width = 142;
            // 
            // idSede
            // 
            this.idSede.DataPropertyName = "idSede";
            this.idSede.HeaderText = "idSede";
            this.idSede.Name = "idSede";
            this.idSede.ReadOnly = true;
            this.idSede.Visible = false;
            this.idSede.Width = 88;
            // 
            // descripcionProducto
            // 
            this.descripcionProducto.DataPropertyName = "descripcionProducto";
            this.descripcionProducto.HeaderText = "Producto";
            this.descripcionProducto.Name = "descripcionProducto";
            this.descripcionProducto.ReadOnly = true;
            this.descripcionProducto.Width = 106;
            // 
            // nombrePresentacion
            // 
            this.nombrePresentacion.DataPropertyName = "nombrePresentacion";
            this.nombrePresentacion.HeaderText = "Presentación";
            this.nombrePresentacion.Name = "nombrePresentacion";
            this.nombrePresentacion.ReadOnly = true;
            this.nombrePresentacion.Width = 142;
            // 
            // cantidadDetalle
            // 
            this.cantidadDetalle.DataPropertyName = "cantidadDetalle";
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.cantidadDetalle.DefaultCellStyle = dataGridViewCellStyle3;
            this.cantidadDetalle.HeaderText = "CANT";
            this.cantidadDetalle.Name = "cantidadDetalle";
            this.cantidadDetalle.ReadOnly = true;
            this.cantidadDetalle.Width = 70;
            // 
            // costoUnidad
            // 
            this.costoUnidad.DataPropertyName = "costoUnidad";
            this.costoUnidad.HeaderText = "costoUnidad";
            this.costoUnidad.Name = "costoUnidad";
            this.costoUnidad.ReadOnly = true;
            this.costoUnidad.Visible = false;
            this.costoUnidad.Width = 133;
            // 
            // costoTotal
            // 
            this.costoTotal.DataPropertyName = "costoTotal";
            this.costoTotal.HeaderText = "costoTotal";
            this.costoTotal.Name = "costoTotal";
            this.costoTotal.ReadOnly = true;
            this.costoTotal.Visible = false;
            this.costoTotal.Width = 124;
            // 
            // precioDetalleVentaV
            // 
            this.precioDetalleVentaV.DataPropertyName = "precioDetalleVentaV";
            dataGridViewCellStyle4.Format = "C0";
            dataGridViewCellStyle4.NullValue = null;
            this.precioDetalleVentaV.DefaultCellStyle = dataGridViewCellStyle4;
            this.precioDetalleVentaV.HeaderText = "Precio";
            this.precioDetalleVentaV.Name = "precioDetalleVentaV";
            this.precioDetalleVentaV.ReadOnly = true;
            this.precioDetalleVentaV.Width = 88;
            // 
            // totalDetalle
            // 
            this.totalDetalle.DataPropertyName = "totalDetalle";
            dataGridViewCellStyle5.Format = "C0";
            dataGridViewCellStyle5.NullValue = null;
            this.totalDetalle.DefaultCellStyle = dataGridViewCellStyle5;
            this.totalDetalle.HeaderText = "Total";
            this.totalDetalle.Name = "totalDetalle";
            this.totalDetalle.ReadOnly = true;
            this.totalDetalle.Width = 79;
            // 
            // idInventarioTotal
            // 
            this.idInventarioTotal.DataPropertyName = "idInventarioTotal";
            this.idInventarioTotal.HeaderText = "idInventarioTotal";
            this.idInventarioTotal.Name = "idInventarioTotal";
            this.idInventarioTotal.ReadOnly = true;
            this.idInventarioTotal.Visible = false;
            this.idInventarioTotal.Width = 187;
            // 
            // contenidoPresentacion
            // 
            this.contenidoPresentacion.DataPropertyName = "contenidoPresentacion";
            this.contenidoPresentacion.HeaderText = "contenidoPresentacion";
            this.contenidoPresentacion.Name = "contenidoPresentacion";
            this.contenidoPresentacion.ReadOnly = true;
            this.contenidoPresentacion.Visible = false;
            this.contenidoPresentacion.Width = 223;
            // 
            // porcentageIVA
            // 
            this.porcentageIVA.DataPropertyName = "porcentageIVA";
            this.porcentageIVA.HeaderText = "porcentageIVA";
            this.porcentageIVA.Name = "porcentageIVA";
            this.porcentageIVA.ReadOnly = true;
            this.porcentageIVA.Visible = false;
            this.porcentageIVA.Width = 151;
            // 
            // valorIva
            // 
            this.valorIva.DataPropertyName = "valorIva";
            this.valorIva.HeaderText = "valorIva";
            this.valorIva.Name = "valorIva";
            this.valorIva.ReadOnly = true;
            this.valorIva.Visible = false;
            this.valorIva.Width = 106;
            // 
            // codigoProducto
            // 
            this.codigoProducto.DataPropertyName = "codigoProducto";
            this.codigoProducto.HeaderText = "codigoProducto";
            this.codigoProducto.Name = "codigoProducto";
            this.codigoProducto.ReadOnly = true;
            this.codigoProducto.Visible = false;
            this.codigoProducto.Width = 160;
            // 
            // descuentoDetalle
            // 
            this.descuentoDetalle.DataPropertyName = "descuentoDetalle";
            this.descuentoDetalle.HeaderText = "descuentoDetalle";
            this.descuentoDetalle.Name = "descuentoDetalle";
            this.descuentoDetalle.ReadOnly = true;
            this.descuentoDetalle.Visible = false;
            this.descuentoDetalle.Width = 178;
            // 
            // recargoDetalle
            // 
            this.recargoDetalle.DataPropertyName = "recargoDetalle";
            this.recargoDetalle.HeaderText = "recargoDetalle";
            this.recargoDetalle.Name = "recargoDetalle";
            this.recargoDetalle.ReadOnly = true;
            this.recargoDetalle.Visible = false;
            this.recargoDetalle.Width = 160;
            // 
            // baseIva
            // 
            this.baseIva.DataPropertyName = "baseIva";
            this.baseIva.HeaderText = "baseIva";
            this.baseIva.Name = "baseIva";
            this.baseIva.ReadOnly = true;
            this.baseIva.Visible = false;
            this.baseIva.Width = 97;
            // 
            // subTotalDetalle
            // 
            this.subTotalDetalle.DataPropertyName = "subTotalDetalle";
            this.subTotalDetalle.HeaderText = "subTotalDetalle";
            this.subTotalDetalle.Name = "subTotalDetalle";
            this.subTotalDetalle.ReadOnly = true;
            this.subTotalDetalle.Visible = false;
            this.subTotalDetalle.Width = 169;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.txtSubTotal.Font = new System.Drawing.Font("Consolas", 48F, System.Drawing.FontStyle.Bold);
            this.txtSubTotal.ForeColor = System.Drawing.Color.White;
            this.txtSubTotal.Location = new System.Drawing.Point(362, 375);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(645, 67);
            this.txtSubTotal.TabIndex = 69;
            this.txtSubTotal.Text = "$ 0";
            this.txtSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flPanel
            // 
            this.flPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flPanel.AutoScroll = true;
            this.flPanel.BackColor = System.Drawing.Color.White;
            this.flPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flPanel.Location = new System.Drawing.Point(17, 92);
            this.flPanel.Name = "flPanel";
            this.flPanel.Size = new System.Drawing.Size(338, 347);
            this.flPanel.TabIndex = 1;
            // 
            // txtCodigoBarra
            // 
            this.txtCodigoBarra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoBarra.Location = new System.Drawing.Point(110, 12);
            this.txtCodigoBarra.Name = "txtCodigoBarra";
            this.txtCodigoBarra.Size = new System.Drawing.Size(246, 29);
            this.txtCodigoBarra.TabIndex = 17;
            this.txtCodigoBarra.TextChanged += new System.EventHandler(this.txtCodigoBarra_TextChanged);
            this.txtCodigoBarra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoBarra_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 70;
            this.label1.Text = "Código";
            // 
            // flPanelCajas
            // 
            this.flPanelCajas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flPanelCajas.AutoScroll = true;
            this.flPanelCajas.AutoSize = true;
            this.flPanelCajas.BackColor = System.Drawing.Color.White;
            this.flPanelCajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flPanelCajas.Location = new System.Drawing.Point(362, 12);
            this.flPanelCajas.Name = "flPanelCajas";
            this.flPanelCajas.Size = new System.Drawing.Size(379, 60);
            this.flPanelCajas.TabIndex = 72;
            // 
            // btnVender
            // 
            this.btnVender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVender.IconChar = FontAwesome.Sharp.IconChar.DollarSign;
            this.btnVender.IconColor = System.Drawing.Color.Black;
            this.btnVender.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVender.IconSize = 40;
            this.btnVender.Location = new System.Drawing.Point(877, 12);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(130, 60);
            this.btnVender.TabIndex = 75;
            this.btnVender.Text = "Cobrar Pedido";
            this.btnVender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVender.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // btnNuevaCaja
            // 
            this.btnNuevaCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaCaja.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnNuevaCaja.IconColor = System.Drawing.Color.Black;
            this.btnNuevaCaja.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevaCaja.IconSize = 40;
            this.btnNuevaCaja.Location = new System.Drawing.Point(747, 12);
            this.btnNuevaCaja.Name = "btnNuevaCaja";
            this.btnNuevaCaja.Size = new System.Drawing.Size(124, 60);
            this.btnNuevaCaja.TabIndex = 76;
            this.btnNuevaCaja.Text = "Nueva Caja";
            this.btnNuevaCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevaCaja.UseVisualStyleBackColor = true;
            this.btnNuevaCaja.Click += new System.EventHandler(this.btnNuevaCaja_Click);
            // 
            // btnBuscarPedido
            // 
            this.btnBuscarPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscarPedido.Enabled = false;
            this.btnBuscarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPedido.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarPedido.IconColor = System.Drawing.Color.Black;
            this.btnBuscarPedido.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarPedido.IconSize = 40;
            this.btnBuscarPedido.Location = new System.Drawing.Point(181, 394);
            this.btnBuscarPedido.Name = "btnBuscarPedido";
            this.btnBuscarPedido.Size = new System.Drawing.Size(175, 48);
            this.btnBuscarPedido.TabIndex = 77;
            this.btnBuscarPedido.Text = "Buscar Pedido";
            this.btnBuscarPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarPedido.UseVisualStyleBackColor = true;
            this.btnBuscarPedido.Visible = false;
            this.btnBuscarPedido.Click += new System.EventHandler(this.btnBuscarPedido_Click);
            // 
            // txtGuidPedido
            // 
            this.txtGuidPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGuidPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGuidPedido.Enabled = false;
            this.txtGuidPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuidPedido.Location = new System.Drawing.Point(12, 402);
            this.txtGuidPedido.Name = "txtGuidPedido";
            this.txtGuidPedido.Size = new System.Drawing.Size(162, 29);
            this.txtGuidPedido.TabIndex = 78;
            this.txtGuidPedido.Visible = false;
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(24, 47);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(332, 39);
            this.cboCategoria.TabIndex = 79;
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            // 
            // frmCajaTouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1019, 451);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.txtGuidPedido);
            this.Controls.Add(this.btnBuscarPedido);
            this.Controls.Add(this.btnNuevaCaja);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.flPanelCajas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoBarra);
            this.Controls.Add(this.dgListaDetalleCompra);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.flPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(818, 490);
            this.Name = "frmCajaTouch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAJA REGISTRADORA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCajaTouch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCajaTouch_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgListaDetalleCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProductoDetalle;
        public System.Windows.Forms.DataGridView dgListaDetalleCompra;
        private System.Windows.Forms.Label txtSubTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flPanelCajas;
        public System.Windows.Forms.TextBox txtCodigoBarra;
        private FontAwesome.Sharp.IconButton btnVender;
        private FontAwesome.Sharp.IconButton btnNuevaCaja;
        private FontAwesome.Sharp.IconButton btnBuscarPedido;
        public System.Windows.Forms.TextBox txtGuidPedido;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPrecios;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSede;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrePresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDetalleVentaV;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInventarioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn contenidoPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentageIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuentoDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn recargoDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotalDetalle;
    }
}
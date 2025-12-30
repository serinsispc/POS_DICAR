namespace SERINSI_PC.Formularios.Inventario
{
    partial class frmBuscarProductoCompra
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
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.dgProductos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPrecios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreSede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guidProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.letraTipoMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrePresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contenidoPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnidadIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeIVAIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventarioActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreLista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idListaPrecios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInventarioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockInvetario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeUtilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.utilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventarioPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarProducto = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(12, 20);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(217, 31);
            this.txtDescripcion.TabIndex = 0;
            this.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
            // 
            // dgProductos
            // 
            this.dgProductos.AllowUserToAddRows = false;
            this.dgProductos.AllowUserToDeleteRows = false;
            this.dgProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idSede,
            this.idTipoMedida,
            this.idCategoria,
            this.idInventario,
            this.idPrecios,
            this.nombreSede,
            this.nombreCategoria,
            this.guidProducto,
            this.codigoProducto,
            this.descripcionProducto,
            this.letraTipoMedida,
            this.idPresentacion,
            this.nombrePresentacion,
            this.contenidoPresentacion,
            this.costoUnidadIT,
            this.porcentajeIVAIT,
            this.PrecioVenta,
            this.inventarioActual,
            this.nombreLista,
            this.idListaPrecios,
            this.idEstadoAI,
            this.idInventarioTotal,
            this.stockInvetario,
            this.estadoInventario,
            this.porcentajeUtilidad,
            this.utilidad,
            this.inventarioPresentacion,
            this.porcentajeDescuento,
            this.costoPresentacion});
            this.dgProductos.Location = new System.Drawing.Point(12, 64);
            this.dgProductos.Name = "dgProductos";
            this.dgProductos.ReadOnly = true;
            this.dgProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProductos.Size = new System.Drawing.Size(362, 234);
            this.dgProductos.TabIndex = 1;
            this.dgProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProductos_KeyDown);
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
            // idSede
            // 
            this.idSede.DataPropertyName = "idSede";
            this.idSede.HeaderText = "idSede";
            this.idSede.Name = "idSede";
            this.idSede.ReadOnly = true;
            this.idSede.Visible = false;
            this.idSede.Width = 83;
            // 
            // idTipoMedida
            // 
            this.idTipoMedida.DataPropertyName = "idTipoMedida";
            this.idTipoMedida.HeaderText = "idTipoMedida";
            this.idTipoMedida.Name = "idTipoMedida";
            this.idTipoMedida.ReadOnly = true;
            this.idTipoMedida.Visible = false;
            this.idTipoMedida.Width = 130;
            // 
            // idCategoria
            // 
            this.idCategoria.DataPropertyName = "idCategoria";
            this.idCategoria.HeaderText = "idCategoria";
            this.idCategoria.Name = "idCategoria";
            this.idCategoria.ReadOnly = true;
            this.idCategoria.Visible = false;
            this.idCategoria.Width = 114;
            // 
            // idInventario
            // 
            this.idInventario.DataPropertyName = "idInventario";
            this.idInventario.HeaderText = "idInventario";
            this.idInventario.Name = "idInventario";
            this.idInventario.ReadOnly = true;
            this.idInventario.Visible = false;
            this.idInventario.Width = 114;
            // 
            // idPrecios
            // 
            this.idPrecios.DataPropertyName = "idPrecios";
            this.idPrecios.HeaderText = "idPrecios";
            this.idPrecios.Name = "idPrecios";
            this.idPrecios.ReadOnly = true;
            this.idPrecios.Visible = false;
            this.idPrecios.Width = 99;
            // 
            // nombreSede
            // 
            this.nombreSede.DataPropertyName = "nombreSede";
            this.nombreSede.HeaderText = "nombreSede";
            this.nombreSede.Name = "nombreSede";
            this.nombreSede.ReadOnly = true;
            this.nombreSede.Visible = false;
            this.nombreSede.Width = 122;
            // 
            // nombreCategoria
            // 
            this.nombreCategoria.DataPropertyName = "nombreCategoria";
            this.nombreCategoria.HeaderText = "nombreCategoria";
            this.nombreCategoria.Name = "nombreCategoria";
            this.nombreCategoria.ReadOnly = true;
            this.nombreCategoria.Visible = false;
            this.nombreCategoria.Width = 153;
            // 
            // guidProducto
            // 
            this.guidProducto.DataPropertyName = "guidProducto";
            this.guidProducto.HeaderText = "guidProducto";
            this.guidProducto.Name = "guidProducto";
            this.guidProducto.ReadOnly = true;
            this.guidProducto.Visible = false;
            this.guidProducto.Width = 125;
            // 
            // codigoProducto
            // 
            this.codigoProducto.DataPropertyName = "codigoProducto";
            this.codigoProducto.HeaderText = "Código";
            this.codigoProducto.Name = "codigoProducto";
            this.codigoProducto.ReadOnly = true;
            this.codigoProducto.Width = 82;
            // 
            // descripcionProducto
            // 
            this.descripcionProducto.DataPropertyName = "descripcionProducto";
            this.descripcionProducto.HeaderText = "Descripción";
            this.descripcionProducto.Name = "descripcionProducto";
            this.descripcionProducto.ReadOnly = true;
            this.descripcionProducto.Width = 115;
            // 
            // letraTipoMedida
            // 
            this.letraTipoMedida.DataPropertyName = "letraTipoMedida";
            this.letraTipoMedida.HeaderText = "Medida";
            this.letraTipoMedida.Name = "letraTipoMedida";
            this.letraTipoMedida.ReadOnly = true;
            this.letraTipoMedida.Width = 84;
            // 
            // idPresentacion
            // 
            this.idPresentacion.DataPropertyName = "idPresentacion";
            this.idPresentacion.HeaderText = "idPresentacion";
            this.idPresentacion.Name = "idPresentacion";
            this.idPresentacion.ReadOnly = true;
            this.idPresentacion.Visible = false;
            this.idPresentacion.Width = 137;
            // 
            // nombrePresentacion
            // 
            this.nombrePresentacion.DataPropertyName = "nombrePresentacion";
            this.nombrePresentacion.HeaderText = "Presentacion";
            this.nombrePresentacion.Name = "nombrePresentacion";
            this.nombrePresentacion.ReadOnly = true;
            this.nombrePresentacion.Width = 123;
            // 
            // contenidoPresentacion
            // 
            this.contenidoPresentacion.DataPropertyName = "contenidoPresentacion";
            dataGridViewCellStyle2.Format = "n0";
            this.contenidoPresentacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.contenidoPresentacion.HeaderText = "Contenido";
            this.contenidoPresentacion.Name = "contenidoPresentacion";
            this.contenidoPresentacion.ReadOnly = true;
            this.contenidoPresentacion.Width = 102;
            // 
            // costoUnidadIT
            // 
            this.costoUnidadIT.DataPropertyName = "costoUnidadIT";
            dataGridViewCellStyle3.Format = "C0";
            dataGridViewCellStyle3.NullValue = null;
            this.costoUnidadIT.DefaultCellStyle = dataGridViewCellStyle3;
            this.costoUnidadIT.HeaderText = "Costo";
            this.costoUnidadIT.Name = "costoUnidadIT";
            this.costoUnidadIT.ReadOnly = true;
            this.costoUnidadIT.Visible = false;
            this.costoUnidadIT.Width = 73;
            // 
            // porcentajeIVAIT
            // 
            this.porcentajeIVAIT.DataPropertyName = "porcentajeIVAIT";
            this.porcentajeIVAIT.HeaderText = "Iva";
            this.porcentajeIVAIT.Name = "porcentajeIVAIT";
            this.porcentajeIVAIT.ReadOnly = true;
            this.porcentajeIVAIT.Visible = false;
            this.porcentajeIVAIT.Width = 54;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.DataPropertyName = "PrecioVenta";
            this.PrecioVenta.HeaderText = "Precio";
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            this.PrecioVenta.Visible = false;
            this.PrecioVenta.Width = 78;
            // 
            // inventarioActual
            // 
            this.inventarioActual.DataPropertyName = "inventarioActual";
            this.inventarioActual.HeaderText = "inventarioActual";
            this.inventarioActual.Name = "inventarioActual";
            this.inventarioActual.ReadOnly = true;
            this.inventarioActual.Visible = false;
            this.inventarioActual.Width = 144;
            // 
            // nombreLista
            // 
            this.nombreLista.DataPropertyName = "nombreLista";
            this.nombreLista.HeaderText = "nombreLista";
            this.nombreLista.Name = "nombreLista";
            this.nombreLista.ReadOnly = true;
            this.nombreLista.Visible = false;
            this.nombreLista.Width = 118;
            // 
            // idListaPrecios
            // 
            this.idListaPrecios.DataPropertyName = "idListaPrecios";
            this.idListaPrecios.HeaderText = "idListaPrecios";
            this.idListaPrecios.Name = "idListaPrecios";
            this.idListaPrecios.ReadOnly = true;
            this.idListaPrecios.Visible = false;
            this.idListaPrecios.Width = 132;
            // 
            // idEstadoAI
            // 
            this.idEstadoAI.DataPropertyName = "idEstadoAI";
            this.idEstadoAI.HeaderText = "idEstadoAI";
            this.idEstadoAI.Name = "idEstadoAI";
            this.idEstadoAI.ReadOnly = true;
            this.idEstadoAI.Visible = false;
            this.idEstadoAI.Width = 109;
            // 
            // idInventarioTotal
            // 
            this.idInventarioTotal.DataPropertyName = "idInventarioTotal";
            this.idInventarioTotal.HeaderText = "idInventarioTotal";
            this.idInventarioTotal.Name = "idInventarioTotal";
            this.idInventarioTotal.ReadOnly = true;
            this.idInventarioTotal.Visible = false;
            this.idInventarioTotal.Width = 150;
            // 
            // stockInvetario
            // 
            this.stockInvetario.DataPropertyName = "stockInvetario";
            this.stockInvetario.HeaderText = "stockInvetario";
            this.stockInvetario.Name = "stockInvetario";
            this.stockInvetario.ReadOnly = true;
            this.stockInvetario.Visible = false;
            this.stockInvetario.Width = 130;
            // 
            // estadoInventario
            // 
            this.estadoInventario.DataPropertyName = "estadoInventario";
            this.estadoInventario.HeaderText = "estadoInventario";
            this.estadoInventario.Name = "estadoInventario";
            this.estadoInventario.ReadOnly = true;
            this.estadoInventario.Visible = false;
            this.estadoInventario.Width = 149;
            // 
            // porcentajeUtilidad
            // 
            this.porcentajeUtilidad.DataPropertyName = "porcentajeUtilidad";
            this.porcentajeUtilidad.HeaderText = "porcentajeUtilidad";
            this.porcentajeUtilidad.Name = "porcentajeUtilidad";
            this.porcentajeUtilidad.ReadOnly = true;
            this.porcentajeUtilidad.Visible = false;
            this.porcentajeUtilidad.Width = 161;
            // 
            // utilidad
            // 
            this.utilidad.DataPropertyName = "utilidad";
            this.utilidad.HeaderText = "utilidad";
            this.utilidad.Name = "utilidad";
            this.utilidad.ReadOnly = true;
            this.utilidad.Visible = false;
            this.utilidad.Width = 84;
            // 
            // inventarioPresentacion
            // 
            this.inventarioPresentacion.DataPropertyName = "inventarioPresentacion";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.inventarioPresentacion.DefaultCellStyle = dataGridViewCellStyle4;
            this.inventarioPresentacion.HeaderText = "Cantidad";
            this.inventarioPresentacion.Name = "inventarioPresentacion";
            this.inventarioPresentacion.ReadOnly = true;
            this.inventarioPresentacion.Width = 94;
            // 
            // porcentajeDescuento
            // 
            this.porcentajeDescuento.DataPropertyName = "porcentajeDescuento";
            dataGridViewCellStyle5.Format = "n0";
            this.porcentajeDescuento.DefaultCellStyle = dataGridViewCellStyle5;
            this.porcentajeDescuento.HeaderText = "% Descuento";
            this.porcentajeDescuento.Name = "porcentajeDescuento";
            this.porcentajeDescuento.ReadOnly = true;
            this.porcentajeDescuento.Width = 113;
            // 
            // costoPresentacion
            // 
            this.costoPresentacion.DataPropertyName = "costoPresentacion";
            this.costoPresentacion.HeaderText = "costoPresentacion";
            this.costoPresentacion.Name = "costoPresentacion";
            this.costoPresentacion.ReadOnly = true;
            this.costoPresentacion.Visible = false;
            this.costoPresentacion.Width = 162;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnAgregarProducto.IconColor = System.Drawing.Color.Black;
            this.btnAgregarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregarProducto.IconSize = 40;
            this.btnAgregarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarProducto.Location = new System.Drawing.Point(235, 12);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnAgregarProducto.Size = new System.Drawing.Size(139, 45);
            this.btnAgregarProducto.TabIndex = 57;
            this.btnAgregarProducto.Text = "Seleccionar";
            this.btnAgregarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // frmBuscarProductoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 310);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.dgProductos);
            this.Controls.Add(this.txtDescripcion);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscarProductoCompra";
            this.Text = "Buscar Producto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBuscarProductoCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.DataGridView dgProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSede;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPrecios;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreSede;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn guidProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn letraTipoMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrePresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn contenidoPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnidadIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeIVAIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventarioActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn idListaPrecios;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInventarioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockInvetario;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeUtilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn utilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventarioPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoPresentacion;
        private FontAwesome.Sharp.IconButton btnAgregarProducto;
    }
}
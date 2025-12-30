namespace SERINSI_PC.Formularios.Ventas
{
    partial class frmProductosXCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductosXCategoria));
            this.label8 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.dgProductosXCategoria = new System.Windows.Forms.DataGridView();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
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
            this.nombrePresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnidadIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeIVAIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventarioActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventarioPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreLista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idListaPrecios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeUtilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.utilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInventarioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contenidoPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockInvetario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gramera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductosXCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(360, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(201, 29);
            this.label8.TabIndex = 66;
            this.label8.Text = "Agregar";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_comprar_96;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(398, 279);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(135, 122);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pbImagen
            // 
            this.pbImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbImagen.Location = new System.Drawing.Point(12, 218);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(294, 203);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagen.TabIndex = 0;
            this.pbImagen.TabStop = false;
            // 
            // dgProductosXCategoria
            // 
            this.dgProductosXCategoria.AllowUserToAddRows = false;
            this.dgProductosXCategoria.AllowUserToDeleteRows = false;
            this.dgProductosXCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgProductosXCategoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgProductosXCategoria.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgProductosXCategoria.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProductosXCategoria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProductosXCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductosXCategoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.nombrePresentacion,
            this.costoUnidadIT,
            this.costoPresentacion,
            this.porcentajeIVAIT,
            this.PrecioVenta,
            this.inventarioActual,
            this.inventarioPresentacion,
            this.nombreLista,
            this.idListaPrecios,
            this.idEstadoAI,
            this.idPresentacion,
            this.porcentajeUtilidad,
            this.utilidad,
            this.idInventarioTotal,
            this.contenidoPresentacion,
            this.stockInvetario,
            this.estadoInventario,
            this.porcentajeDescuento,
            this.gramera});
            this.dgProductosXCategoria.Location = new System.Drawing.Point(12, 47);
            this.dgProductosXCategoria.Name = "dgProductosXCategoria";
            this.dgProductosXCategoria.ReadOnly = true;
            this.dgProductosXCategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProductosXCategoria.Size = new System.Drawing.Size(548, 165);
            this.dgProductosXCategoria.TabIndex = 0;
            this.dgProductosXCategoria.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProductosXCategoria_CellClick);
            this.dgProductosXCategoria.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProductosXCategoria_CellEnter);
            this.dgProductosXCategoria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProductosXCategoria_KeyDown);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(12, 12);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(548, 29);
            this.txtDescripcion.TabIndex = 0;
            this.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 52;
            // 
            // idSede
            // 
            this.idSede.DataPropertyName = "idSede";
            this.idSede.HeaderText = "idSede";
            this.idSede.Name = "idSede";
            this.idSede.ReadOnly = true;
            this.idSede.Visible = false;
            this.idSede.Width = 101;
            // 
            // idTipoMedida
            // 
            this.idTipoMedida.DataPropertyName = "idTipoMedida";
            this.idTipoMedida.HeaderText = "idTipoMedida";
            this.idTipoMedida.Name = "idTipoMedida";
            this.idTipoMedida.ReadOnly = true;
            this.idTipoMedida.Visible = false;
            this.idTipoMedida.Width = 163;
            // 
            // idCategoria
            // 
            this.idCategoria.DataPropertyName = "idCategoria";
            this.idCategoria.HeaderText = "idCategoria";
            this.idCategoria.Name = "idCategoria";
            this.idCategoria.ReadOnly = true;
            this.idCategoria.Visible = false;
            this.idCategoria.Width = 141;
            // 
            // idInventario
            // 
            this.idInventario.DataPropertyName = "idInventario";
            this.idInventario.HeaderText = "idInventario";
            this.idInventario.Name = "idInventario";
            this.idInventario.ReadOnly = true;
            this.idInventario.Visible = false;
            this.idInventario.Width = 143;
            // 
            // idPrecios
            // 
            this.idPrecios.DataPropertyName = "idPrecios";
            this.idPrecios.HeaderText = "idPrecios";
            this.idPrecios.Name = "idPrecios";
            this.idPrecios.ReadOnly = true;
            this.idPrecios.Visible = false;
            this.idPrecios.Width = 122;
            // 
            // nombreSede
            // 
            this.nombreSede.DataPropertyName = "nombreSede";
            this.nombreSede.HeaderText = "nombreSede";
            this.nombreSede.Name = "nombreSede";
            this.nombreSede.ReadOnly = true;
            this.nombreSede.Visible = false;
            this.nombreSede.Width = 156;
            // 
            // nombreCategoria
            // 
            this.nombreCategoria.DataPropertyName = "nombreCategoria";
            this.nombreCategoria.HeaderText = "nombreCategoria";
            this.nombreCategoria.Name = "nombreCategoria";
            this.nombreCategoria.ReadOnly = true;
            this.nombreCategoria.Visible = false;
            this.nombreCategoria.Width = 196;
            // 
            // guidProducto
            // 
            this.guidProducto.DataPropertyName = "guidProducto";
            this.guidProducto.HeaderText = "guidProducto";
            this.guidProducto.Name = "guidProducto";
            this.guidProducto.ReadOnly = true;
            this.guidProducto.Visible = false;
            this.guidProducto.Width = 160;
            // 
            // codigoProducto
            // 
            this.codigoProducto.DataPropertyName = "codigoProducto";
            this.codigoProducto.HeaderText = "Código";
            this.codigoProducto.Name = "codigoProducto";
            this.codigoProducto.ReadOnly = true;
            this.codigoProducto.Width = 102;
            // 
            // descripcionProducto
            // 
            this.descripcionProducto.DataPropertyName = "descripcionProducto";
            this.descripcionProducto.HeaderText = "Descripción";
            this.descripcionProducto.Name = "descripcionProducto";
            this.descripcionProducto.ReadOnly = true;
            this.descripcionProducto.Width = 146;
            // 
            // letraTipoMedida
            // 
            this.letraTipoMedida.DataPropertyName = "letraTipoMedida";
            this.letraTipoMedida.HeaderText = "letraTipoMedida";
            this.letraTipoMedida.Name = "letraTipoMedida";
            this.letraTipoMedida.ReadOnly = true;
            this.letraTipoMedida.Visible = false;
            this.letraTipoMedida.Width = 186;
            // 
            // nombrePresentacion
            // 
            this.nombrePresentacion.DataPropertyName = "nombrePresentacion";
            this.nombrePresentacion.HeaderText = "Presentación";
            this.nombrePresentacion.Name = "nombrePresentacion";
            this.nombrePresentacion.ReadOnly = true;
            this.nombrePresentacion.Width = 157;
            // 
            // costoUnidadIT
            // 
            this.costoUnidadIT.DataPropertyName = "costoUnidadIT";
            this.costoUnidadIT.HeaderText = "costoUnidad";
            this.costoUnidadIT.Name = "costoUnidadIT";
            this.costoUnidadIT.ReadOnly = true;
            this.costoUnidadIT.Visible = false;
            this.costoUnidadIT.Width = 151;
            // 
            // costoPresentacion
            // 
            this.costoPresentacion.DataPropertyName = "costoPresentacion";
            this.costoPresentacion.HeaderText = "costoPresentacion";
            this.costoPresentacion.Name = "costoPresentacion";
            this.costoPresentacion.ReadOnly = true;
            this.costoPresentacion.Visible = false;
            this.costoPresentacion.Width = 207;
            // 
            // porcentajeIVAIT
            // 
            this.porcentajeIVAIT.DataPropertyName = "porcentajeIVAIT";
            this.porcentajeIVAIT.HeaderText = "porcentajeIVA";
            this.porcentajeIVAIT.Name = "porcentajeIVAIT";
            this.porcentajeIVAIT.ReadOnly = true;
            this.porcentajeIVAIT.Visible = false;
            this.porcentajeIVAIT.Width = 167;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.DataPropertyName = "PrecioVenta";
            dataGridViewCellStyle2.Format = "C0";
            this.PrecioVenta.DefaultCellStyle = dataGridViewCellStyle2;
            this.PrecioVenta.HeaderText = "Precio ";
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            this.PrecioVenta.Width = 101;
            // 
            // inventarioActual
            // 
            this.inventarioActual.DataPropertyName = "inventarioActual";
            dataGridViewCellStyle3.Format = "N0";
            this.inventarioActual.DefaultCellStyle = dataGridViewCellStyle3;
            this.inventarioActual.HeaderText = "Inventario Actual";
            this.inventarioActual.Name = "inventarioActual";
            this.inventarioActual.ReadOnly = true;
            this.inventarioActual.Visible = false;
            this.inventarioActual.Width = 190;
            // 
            // inventarioPresentacion
            // 
            this.inventarioPresentacion.DataPropertyName = "inventarioPresentacion";
            this.inventarioPresentacion.HeaderText = "inventarioPresentacion";
            this.inventarioPresentacion.Name = "inventarioPresentacion";
            this.inventarioPresentacion.ReadOnly = true;
            this.inventarioPresentacion.Visible = false;
            this.inventarioPresentacion.Width = 248;
            // 
            // nombreLista
            // 
            this.nombreLista.DataPropertyName = "nombreLista";
            this.nombreLista.HeaderText = "nombreLista";
            this.nombreLista.Name = "nombreLista";
            this.nombreLista.ReadOnly = true;
            this.nombreLista.Visible = false;
            this.nombreLista.Width = 149;
            // 
            // idListaPrecios
            // 
            this.idListaPrecios.DataPropertyName = "idListaPrecios";
            this.idListaPrecios.HeaderText = "idListaPrecios";
            this.idListaPrecios.Name = "idListaPrecios";
            this.idListaPrecios.ReadOnly = true;
            this.idListaPrecios.Visible = false;
            this.idListaPrecios.Width = 164;
            // 
            // idEstadoAI
            // 
            this.idEstadoAI.DataPropertyName = "idEstadoAI";
            this.idEstadoAI.HeaderText = "idEstadoAI";
            this.idEstadoAI.Name = "idEstadoAI";
            this.idEstadoAI.ReadOnly = true;
            this.idEstadoAI.Visible = false;
            this.idEstadoAI.Width = 135;
            // 
            // idPresentacion
            // 
            this.idPresentacion.DataPropertyName = "idPresentacion";
            this.idPresentacion.HeaderText = "idPresentacion";
            this.idPresentacion.Name = "idPresentacion";
            this.idPresentacion.ReadOnly = true;
            this.idPresentacion.Visible = false;
            this.idPresentacion.Width = 174;
            // 
            // porcentajeUtilidad
            // 
            this.porcentajeUtilidad.DataPropertyName = "porcentajeUtilidad";
            this.porcentajeUtilidad.HeaderText = "porcentajeUtilidad";
            this.porcentajeUtilidad.Name = "porcentajeUtilidad";
            this.porcentajeUtilidad.ReadOnly = true;
            this.porcentajeUtilidad.Visible = false;
            this.porcentajeUtilidad.Width = 203;
            // 
            // utilidad
            // 
            this.utilidad.DataPropertyName = "utilidad";
            this.utilidad.HeaderText = "utilidad";
            this.utilidad.Name = "utilidad";
            this.utilidad.ReadOnly = true;
            this.utilidad.Visible = false;
            this.utilidad.Width = 102;
            // 
            // idInventarioTotal
            // 
            this.idInventarioTotal.DataPropertyName = "idInventarioTotal";
            this.idInventarioTotal.HeaderText = "idInventarioTotal";
            this.idInventarioTotal.Name = "idInventarioTotal";
            this.idInventarioTotal.ReadOnly = true;
            this.idInventarioTotal.Visible = false;
            this.idInventarioTotal.Width = 189;
            // 
            // contenidoPresentacion
            // 
            this.contenidoPresentacion.DataPropertyName = "contenidoPresentacion";
            this.contenidoPresentacion.HeaderText = "contenidoPresentacion";
            this.contenidoPresentacion.Name = "contenidoPresentacion";
            this.contenidoPresentacion.ReadOnly = true;
            this.contenidoPresentacion.Visible = false;
            this.contenidoPresentacion.Width = 250;
            // 
            // stockInvetario
            // 
            this.stockInvetario.DataPropertyName = "stockInvetario";
            this.stockInvetario.HeaderText = "stockInvetario";
            this.stockInvetario.Name = "stockInvetario";
            this.stockInvetario.ReadOnly = true;
            this.stockInvetario.Visible = false;
            this.stockInvetario.Width = 162;
            // 
            // estadoInventario
            // 
            this.estadoInventario.DataPropertyName = "estadoInventario";
            this.estadoInventario.HeaderText = "estadoInventario";
            this.estadoInventario.Name = "estadoInventario";
            this.estadoInventario.ReadOnly = true;
            this.estadoInventario.Visible = false;
            this.estadoInventario.Width = 188;
            // 
            // porcentajeDescuento
            // 
            this.porcentajeDescuento.DataPropertyName = "porcentajeDescuento";
            this.porcentajeDescuento.HeaderText = "porcentajeDescuento";
            this.porcentajeDescuento.Name = "porcentajeDescuento";
            this.porcentajeDescuento.ReadOnly = true;
            this.porcentajeDescuento.Visible = false;
            this.porcentajeDescuento.Width = 234;
            // 
            // gramera
            // 
            this.gramera.DataPropertyName = "gramera";
            this.gramera.HeaderText = "gramera";
            this.gramera.Name = "gramera";
            this.gramera.ReadOnly = true;
            this.gramera.Visible = false;
            this.gramera.Width = 112;
            // 
            // frmProductosXCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 433);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.dgProductosXCategoria);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAgregar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductosXCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categorias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProductosXCategoria_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductosXCategoria_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductosXCategoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAgregar;
        public System.Windows.Forms.DataGridView dgProductosXCategoria;
        private System.Windows.Forms.TextBox txtDescripcion;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrePresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnidadIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeIVAIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventarioActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventarioPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn idListaPrecios;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeUtilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn utilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInventarioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn contenidoPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockInvetario;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn gramera;
    }
}
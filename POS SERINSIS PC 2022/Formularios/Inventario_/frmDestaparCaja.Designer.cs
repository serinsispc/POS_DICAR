namespace SERINSI_PC.Formularios.Inventario
{
    partial class frmDestaparCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDestaparCaja));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.texTotalUnidad = new System.Windows.Forms.Label();
            this.btnSumarProducto = new System.Windows.Forms.Button();
            this.btnRestarProducto = new System.Windows.Forms.Button();
            this.texCantidadDestapar = new System.Windows.Forms.Label();
            this.texProducto = new System.Windows.Forms.Label();
            this.pbImagenDestapar = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.texTotalASurtir = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTrasladar = new System.Windows.Forms.Button();
            this.dgProducto = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.letraTipoMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventarioInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventarioActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.utilidadProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idBodega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreBodega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreEstaoInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreEstadoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbImagenSurtir = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenDestapar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenSurtir)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.texTotalUnidad);
            this.groupBox1.Controls.Add(this.btnSumarProducto);
            this.groupBox1.Controls.Add(this.btnRestarProducto);
            this.groupBox1.Controls.Add(this.texCantidadDestapar);
            this.groupBox1.Controls.Add(this.texProducto);
            this.groupBox1.Controls.Add(this.pbImagenDestapar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producto A Destapar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(545, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 18);
            this.label3.TabIndex = 72;
            this.label3.Text = "Total UND";
            // 
            // texTotalUnidad
            // 
            this.texTotalUnidad.BackColor = System.Drawing.Color.LightSteelBlue;
            this.texTotalUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.texTotalUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texTotalUnidad.Location = new System.Drawing.Point(561, 108);
            this.texTotalUnidad.Name = "texTotalUnidad";
            this.texTotalUnidad.Size = new System.Drawing.Size(60, 25);
            this.texTotalUnidad.TabIndex = 70;
            this.texTotalUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSumarProducto
            // 
            this.btnSumarProducto.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_añadir_1001;
            this.btnSumarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSumarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSumarProducto.FlatAppearance.BorderSize = 0;
            this.btnSumarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSumarProducto.Location = new System.Drawing.Point(436, 100);
            this.btnSumarProducto.Name = "btnSumarProducto";
            this.btnSumarProducto.Size = new System.Drawing.Size(42, 43);
            this.btnSumarProducto.TabIndex = 69;
            this.btnSumarProducto.UseVisualStyleBackColor = true;
            this.btnSumarProducto.Click += new System.EventHandler(this.btnSumarProducto_Click);
            // 
            // btnRestarProducto
            // 
            this.btnRestarProducto.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_menos_100;
            this.btnRestarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRestarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestarProducto.FlatAppearance.BorderSize = 0;
            this.btnRestarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestarProducto.Location = new System.Drawing.Point(322, 100);
            this.btnRestarProducto.Name = "btnRestarProducto";
            this.btnRestarProducto.Size = new System.Drawing.Size(42, 43);
            this.btnRestarProducto.TabIndex = 68;
            this.btnRestarProducto.UseVisualStyleBackColor = true;
            this.btnRestarProducto.Click += new System.EventHandler(this.btnRestarProducto_Click);
            // 
            // texCantidadDestapar
            // 
            this.texCantidadDestapar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.texCantidadDestapar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.texCantidadDestapar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texCantidadDestapar.Location = new System.Drawing.Point(370, 108);
            this.texCantidadDestapar.Name = "texCantidadDestapar";
            this.texCantidadDestapar.Size = new System.Drawing.Size(60, 25);
            this.texCantidadDestapar.TabIndex = 1;
            this.texCantidadDestapar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // texProducto
            // 
            this.texProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.texProducto.Location = new System.Drawing.Point(245, 18);
            this.texProducto.Name = "texProducto";
            this.texProducto.Size = new System.Drawing.Size(387, 48);
            this.texProducto.TabIndex = 1;
            this.texProducto.Text = "--";
            // 
            // pbImagenDestapar
            // 
            this.pbImagenDestapar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbImagenDestapar.Location = new System.Drawing.Point(3, 18);
            this.pbImagenDestapar.Name = "pbImagenDestapar";
            this.pbImagenDestapar.Size = new System.Drawing.Size(236, 136);
            this.pbImagenDestapar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagenDestapar.TabIndex = 0;
            this.pbImagenDestapar.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.texTotalASurtir);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnTrasladar);
            this.groupBox2.Controls.Add(this.dgProducto);
            this.groupBox2.Controls.Add(this.pbImagenSurtir);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(638, 266);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Producto A Surtir";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(281, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 74;
            this.label2.Text = "Total A Surtir";
            // 
            // texTotalASurtir
            // 
            this.texTotalASurtir.BackColor = System.Drawing.Color.LightSteelBlue;
            this.texTotalASurtir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.texTotalASurtir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texTotalASurtir.Location = new System.Drawing.Point(392, 235);
            this.texTotalASurtir.Name = "texTotalASurtir";
            this.texTotalASurtir.Size = new System.Drawing.Size(60, 25);
            this.texTotalASurtir.TabIndex = 73;
            this.texTotalASurtir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(518, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 71;
            this.label1.Text = "Trasladar";
            // 
            // btnTrasladar
            // 
            this.btnTrasladar.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_17387_0_73139_actualizar_izquierda_32_flechas_100;
            this.btnTrasladar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTrasladar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrasladar.FlatAppearance.BorderSize = 0;
            this.btnTrasladar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrasladar.Location = new System.Drawing.Point(508, 148);
            this.btnTrasladar.Name = "btnTrasladar";
            this.btnTrasladar.Size = new System.Drawing.Size(86, 87);
            this.btnTrasladar.TabIndex = 70;
            this.btnTrasladar.UseVisualStyleBackColor = true;
            this.btnTrasladar.Click += new System.EventHandler(this.btnTrasladar_Click);
            // 
            // dgProducto
            // 
            this.dgProducto.AllowUserToAddRows = false;
            this.dgProducto.AllowUserToDeleteRows = false;
            this.dgProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgProducto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.codigoProducto,
            this.letraTipoMedida,
            this.idTipoMedida,
            this.descripcionProducto,
            this.inventarioInicial,
            this.inventarioActual,
            this.stockInventario,
            this.costoProducto,
            this.precioProducto,
            this.utilidadProducto,
            this.idProveedor,
            this.idCategoria,
            this.idBodega,
            this.idEstadoProducto,
            this.idEstadoInventario,
            this.nombreBodega,
            this.nombreCategoria,
            this.nombreProveedor,
            this.nombreEstaoInventario,
            this.nombreEstadoProducto,
            this.cantidadUnidad});
            this.dgProducto.Location = new System.Drawing.Point(3, 18);
            this.dgProducto.Name = "dgProducto";
            this.dgProducto.ReadOnly = true;
            this.dgProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProducto.Size = new System.Drawing.Size(449, 214);
            this.dgProducto.TabIndex = 2;
            this.dgProducto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProducto_CellClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // codigoProducto
            // 
            this.codigoProducto.DataPropertyName = "codigoProducto";
            this.codigoProducto.HeaderText = "codigoProducto";
            this.codigoProducto.Name = "codigoProducto";
            this.codigoProducto.ReadOnly = true;
            this.codigoProducto.Visible = false;
            // 
            // letraTipoMedida
            // 
            this.letraTipoMedida.DataPropertyName = "letraTipoMedida";
            this.letraTipoMedida.HeaderText = "Medida";
            this.letraTipoMedida.Name = "letraTipoMedida";
            this.letraTipoMedida.ReadOnly = true;
            this.letraTipoMedida.Width = 85;
            // 
            // idTipoMedida
            // 
            this.idTipoMedida.DataPropertyName = "idTipoMedida";
            this.idTipoMedida.HeaderText = "idTipoMedida";
            this.idTipoMedida.Name = "idTipoMedida";
            this.idTipoMedida.ReadOnly = true;
            this.idTipoMedida.Visible = false;
            // 
            // descripcionProducto
            // 
            this.descripcionProducto.DataPropertyName = "descripcionProducto";
            this.descripcionProducto.HeaderText = "Producto";
            this.descripcionProducto.Name = "descripcionProducto";
            this.descripcionProducto.ReadOnly = true;
            this.descripcionProducto.Width = 95;
            // 
            // inventarioInicial
            // 
            this.inventarioInicial.DataPropertyName = "inventarioInicial";
            this.inventarioInicial.HeaderText = "inventarioInicial";
            this.inventarioInicial.Name = "inventarioInicial";
            this.inventarioInicial.ReadOnly = true;
            this.inventarioInicial.Visible = false;
            // 
            // inventarioActual
            // 
            this.inventarioActual.DataPropertyName = "inventarioActual";
            this.inventarioActual.HeaderText = "inventarioActual";
            this.inventarioActual.Name = "inventarioActual";
            this.inventarioActual.ReadOnly = true;
            this.inventarioActual.Visible = false;
            // 
            // stockInventario
            // 
            this.stockInventario.DataPropertyName = "stockInventario";
            this.stockInventario.HeaderText = "stockInventario";
            this.stockInventario.Name = "stockInventario";
            this.stockInventario.ReadOnly = true;
            this.stockInventario.Visible = false;
            // 
            // costoProducto
            // 
            this.costoProducto.DataPropertyName = "costoProducto";
            this.costoProducto.HeaderText = "costoProducto";
            this.costoProducto.Name = "costoProducto";
            this.costoProducto.ReadOnly = true;
            this.costoProducto.Visible = false;
            // 
            // precioProducto
            // 
            this.precioProducto.DataPropertyName = "precioProducto";
            this.precioProducto.HeaderText = "precioProducto";
            this.precioProducto.Name = "precioProducto";
            this.precioProducto.ReadOnly = true;
            this.precioProducto.Visible = false;
            // 
            // utilidadProducto
            // 
            this.utilidadProducto.DataPropertyName = "utilidadProducto";
            this.utilidadProducto.HeaderText = "utilidadProducto";
            this.utilidadProducto.Name = "utilidadProducto";
            this.utilidadProducto.ReadOnly = true;
            this.utilidadProducto.Visible = false;
            // 
            // idProveedor
            // 
            this.idProveedor.DataPropertyName = "idProveedor";
            this.idProveedor.HeaderText = "idProveedor";
            this.idProveedor.Name = "idProveedor";
            this.idProveedor.ReadOnly = true;
            this.idProveedor.Visible = false;
            // 
            // idCategoria
            // 
            this.idCategoria.DataPropertyName = "idCategoria";
            this.idCategoria.HeaderText = "idCategoria";
            this.idCategoria.Name = "idCategoria";
            this.idCategoria.ReadOnly = true;
            this.idCategoria.Visible = false;
            // 
            // idBodega
            // 
            this.idBodega.DataPropertyName = "idBodega";
            this.idBodega.HeaderText = "idBodega";
            this.idBodega.Name = "idBodega";
            this.idBodega.ReadOnly = true;
            this.idBodega.Visible = false;
            // 
            // idEstadoProducto
            // 
            this.idEstadoProducto.DataPropertyName = "idEstadoProducto";
            this.idEstadoProducto.HeaderText = "idEstadoProducto";
            this.idEstadoProducto.Name = "idEstadoProducto";
            this.idEstadoProducto.ReadOnly = true;
            this.idEstadoProducto.Visible = false;
            // 
            // idEstadoInventario
            // 
            this.idEstadoInventario.DataPropertyName = "idEstadoInventario";
            this.idEstadoInventario.HeaderText = "idEstadoInventario";
            this.idEstadoInventario.Name = "idEstadoInventario";
            this.idEstadoInventario.ReadOnly = true;
            this.idEstadoInventario.Visible = false;
            // 
            // nombreBodega
            // 
            this.nombreBodega.DataPropertyName = "nombreBodega";
            this.nombreBodega.HeaderText = "nombreBodega";
            this.nombreBodega.Name = "nombreBodega";
            this.nombreBodega.ReadOnly = true;
            this.nombreBodega.Visible = false;
            // 
            // nombreCategoria
            // 
            this.nombreCategoria.DataPropertyName = "nombreCategoria";
            this.nombreCategoria.HeaderText = "nombreCategoria";
            this.nombreCategoria.Name = "nombreCategoria";
            this.nombreCategoria.ReadOnly = true;
            this.nombreCategoria.Visible = false;
            // 
            // nombreProveedor
            // 
            this.nombreProveedor.DataPropertyName = "nombreProveedor";
            this.nombreProveedor.HeaderText = "nombreProveedor";
            this.nombreProveedor.Name = "nombreProveedor";
            this.nombreProveedor.ReadOnly = true;
            this.nombreProveedor.Visible = false;
            // 
            // nombreEstaoInventario
            // 
            this.nombreEstaoInventario.DataPropertyName = "nombreEstaoInventario";
            this.nombreEstaoInventario.HeaderText = "nombreEstaoInventario";
            this.nombreEstaoInventario.Name = "nombreEstaoInventario";
            this.nombreEstaoInventario.ReadOnly = true;
            this.nombreEstaoInventario.Visible = false;
            // 
            // nombreEstadoProducto
            // 
            this.nombreEstadoProducto.DataPropertyName = "nombreEstadoProducto";
            this.nombreEstadoProducto.HeaderText = "nombreEstadoProducto";
            this.nombreEstadoProducto.Name = "nombreEstadoProducto";
            this.nombreEstadoProducto.ReadOnly = true;
            this.nombreEstadoProducto.Visible = false;
            // 
            // cantidadUnidad
            // 
            this.cantidadUnidad.DataPropertyName = "cantidadUnidad";
            this.cantidadUnidad.HeaderText = "cantidadUnidad";
            this.cantidadUnidad.Name = "cantidadUnidad";
            this.cantidadUnidad.ReadOnly = true;
            this.cantidadUnidad.Visible = false;
            // 
            // pbImagenSurtir
            // 
            this.pbImagenSurtir.Location = new System.Drawing.Point(458, 6);
            this.pbImagenSurtir.Name = "pbImagenSurtir";
            this.pbImagenSurtir.Size = new System.Drawing.Size(180, 136);
            this.pbImagenSurtir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagenSurtir.TabIndex = 1;
            this.pbImagenSurtir.TabStop = false;
            // 
            // frmDestaparCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 423);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDestaparCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Destapar Producto";
            this.Load += new System.EventHandler(this.frmDestaparCaja_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenDestapar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenSurtir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label texCantidadDestapar;
        private System.Windows.Forms.Button btnRestarProducto;
        private System.Windows.Forms.Button btnSumarProducto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbImagenSurtir;
        private System.Windows.Forms.Button btnTrasladar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label texTotalUnidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label texTotalASurtir;
        public System.Windows.Forms.Label texProducto;
        public System.Windows.Forms.PictureBox pbImagenDestapar;
        protected System.Windows.Forms.DataGridView dgProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn letraTipoMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventarioInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventarioActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn utilidadProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBodega;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreBodega;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreEstaoInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreEstadoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadUnidad;
    }
}
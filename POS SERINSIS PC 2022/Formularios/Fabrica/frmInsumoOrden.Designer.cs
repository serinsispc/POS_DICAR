namespace SERINSI_PC.Formularios.Fabrica
{
    partial class frmInsumoOrden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInsumoOrden));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.txtTituloFormulario = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.txtBuscadorInsumo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgListaBuscadorImsumo = new System.Windows.Forms.DataGridView();
            this.idVistaProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionProducto_v = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.letraTipoMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventarioInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventarioActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.utilidadProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idBodega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreBodega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreEstaoInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreEstadoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCantidadActualInsumo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCostoInsumo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoINsumo = new System.Windows.Forms.TextBox();
            this.txtDescripcionInsumo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCostoTotalINsumo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgDetalleOrden = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOrdenDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInsumoOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionInsumoOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadInsumoOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoInsumoUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoTotalInsumoOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarOrden = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAgregarINsumo = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.totalText = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListaBuscadorImsumo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleOrden)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.txtTituloFormulario);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 23);
            this.panel1.TabIndex = 15;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Location = new System.Drawing.Point(768, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(23, 23);
            this.btnMinimizar.TabIndex = 27;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            // 
            // txtTituloFormulario
            // 
            this.txtTituloFormulario.AutoSize = true;
            this.txtTituloFormulario.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTituloFormulario.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTituloFormulario.ForeColor = System.Drawing.Color.White;
            this.txtTituloFormulario.Location = new System.Drawing.Point(0, 0);
            this.txtTituloFormulario.Name = "txtTituloFormulario";
            this.txtTituloFormulario.Size = new System.Drawing.Size(112, 18);
            this.txtTituloFormulario.TabIndex = 11;
            this.txtTituloFormulario.Text = "Lista Insumos";
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
            this.btnCerrar.Location = new System.Drawing.Point(791, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(23, 23);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // txtBuscadorInsumo
            // 
            this.txtBuscadorInsumo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscadorInsumo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscadorInsumo.Location = new System.Drawing.Point(16, 48);
            this.txtBuscadorInsumo.Name = "txtBuscadorInsumo";
            this.txtBuscadorInsumo.Size = new System.Drawing.Size(437, 26);
            this.txtBuscadorInsumo.TabIndex = 18;
            this.txtBuscadorInsumo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscadorInsumo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscadorInsumo_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Buscar Insumo por Código o descripción";
            // 
            // dgListaBuscadorImsumo
            // 
            this.dgListaBuscadorImsumo.AllowUserToAddRows = false;
            this.dgListaBuscadorImsumo.AllowUserToDeleteRows = false;
            this.dgListaBuscadorImsumo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgListaBuscadorImsumo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgListaBuscadorImsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListaBuscadorImsumo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idVistaProducto,
            this.codigoProducto,
            this.descripcionProducto_v,
            this.letraTipoMedida,
            this.inventarioInicial,
            this.inventarioActual,
            this.stockInventario,
            this.costoProducto,
            this.precioProducto,
            this.utilidadProducto,
            this.idProveedor,
            this.idCategoria,
            this.idBodega,
            this.idTipoMedida,
            this.idEstadoProducto,
            this.idEstadoInventario,
            this.nombreBodega,
            this.nombreCategoria,
            this.nombreProveedor,
            this.nombreEstaoInventario,
            this.nombreEstadoProducto,
            this.cantidadUnidad});
            this.dgListaBuscadorImsumo.Location = new System.Drawing.Point(16, 73);
            this.dgListaBuscadorImsumo.Name = "dgListaBuscadorImsumo";
            this.dgListaBuscadorImsumo.ReadOnly = true;
            this.dgListaBuscadorImsumo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgListaBuscadorImsumo.Size = new System.Drawing.Size(695, 144);
            this.dgListaBuscadorImsumo.TabIndex = 20;
            this.dgListaBuscadorImsumo.Visible = false;
            this.dgListaBuscadorImsumo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgListaBuscadorImsumo_CellDoubleClick);
            this.dgListaBuscadorImsumo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgListaBuscadorImsumo_KeyDown);
            // 
            // idVistaProducto
            // 
            this.idVistaProducto.DataPropertyName = "idVistaProducto";
            this.idVistaProducto.HeaderText = "idVistaProducto";
            this.idVistaProducto.Name = "idVistaProducto";
            this.idVistaProducto.ReadOnly = true;
            this.idVistaProducto.Visible = false;
            // 
            // codigoProducto
            // 
            this.codigoProducto.DataPropertyName = "codigoProducto";
            this.codigoProducto.HeaderText = "Codigo";
            this.codigoProducto.Name = "codigoProducto";
            this.codigoProducto.ReadOnly = true;
            this.codigoProducto.Width = 77;
            // 
            // descripcionProducto_v
            // 
            this.descripcionProducto_v.DataPropertyName = "descripcionProducto_v";
            this.descripcionProducto_v.HeaderText = "Descripción";
            this.descripcionProducto_v.Name = "descripcionProducto_v";
            this.descripcionProducto_v.ReadOnly = true;
            this.descripcionProducto_v.Width = 108;
            // 
            // letraTipoMedida
            // 
            this.letraTipoMedida.DataPropertyName = "letraTipoMedida";
            this.letraTipoMedida.HeaderText = "Medida";
            this.letraTipoMedida.Name = "letraTipoMedida";
            this.letraTipoMedida.ReadOnly = true;
            this.letraTipoMedida.Width = 80;
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
            this.inventarioActual.HeaderText = "Cantidad";
            this.inventarioActual.Name = "inventarioActual";
            this.inventarioActual.ReadOnly = true;
            this.inventarioActual.Width = 89;
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
            this.costoProducto.HeaderText = "Costo";
            this.costoProducto.Name = "costoProducto";
            this.costoProducto.ReadOnly = true;
            this.costoProducto.Width = 68;
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
            // idTipoMedida
            // 
            this.idTipoMedida.DataPropertyName = "idTipoMedida";
            this.idTipoMedida.HeaderText = "idTipoMedida";
            this.idTipoMedida.Name = "idTipoMedida";
            this.idTipoMedida.ReadOnly = true;
            this.idTipoMedida.Visible = false;
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
            // txtCantidadActualInsumo
            // 
            this.txtCantidadActualInsumo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCantidadActualInsumo.Enabled = false;
            this.txtCantidadActualInsumo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadActualInsumo.Location = new System.Drawing.Point(584, 48);
            this.txtCantidadActualInsumo.Name = "txtCantidadActualInsumo";
            this.txtCantidadActualInsumo.Size = new System.Drawing.Size(80, 26);
            this.txtCantidadActualInsumo.TabIndex = 26;
            this.txtCantidadActualInsumo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(580, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 19);
            this.label4.TabIndex = 25;
            this.label4.Text = "Actual";
            // 
            // txtCostoInsumo
            // 
            this.txtCostoInsumo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCostoInsumo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoInsumo.Location = new System.Drawing.Point(670, 48);
            this.txtCostoInsumo.Name = "txtCostoInsumo";
            this.txtCostoInsumo.Size = new System.Drawing.Size(132, 26);
            this.txtCostoInsumo.TabIndex = 28;
            this.txtCostoInsumo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCostoInsumo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCostoInsumo_KeyDown);
            this.txtCostoInsumo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostoInsumo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(666, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 27;
            this.label5.Text = "Costo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(455, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "Codigo";
            // 
            // txtCodigoINsumo
            // 
            this.txtCodigoINsumo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoINsumo.Enabled = false;
            this.txtCodigoINsumo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoINsumo.Location = new System.Drawing.Point(459, 48);
            this.txtCodigoINsumo.Name = "txtCodigoINsumo";
            this.txtCodigoINsumo.Size = new System.Drawing.Size(119, 26);
            this.txtCodigoINsumo.TabIndex = 22;
            this.txtCodigoINsumo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescripcionInsumo
            // 
            this.txtDescripcionInsumo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcionInsumo.Enabled = false;
            this.txtDescripcionInsumo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionInsumo.Location = new System.Drawing.Point(16, 99);
            this.txtDescripcionInsumo.Name = "txtDescripcionInsumo";
            this.txtDescripcionInsumo.Size = new System.Drawing.Size(575, 26);
            this.txtDescripcionInsumo.TabIndex = 30;
            this.txtDescripcionInsumo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 19);
            this.label3.TabIndex = 29;
            this.label3.Text = "Descripción Insumo";
            // 
            // txtCantidad
            // 
            this.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCantidad.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(597, 99);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(77, 26);
            this.txtCantidad.TabIndex = 32;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(593, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 19);
            this.label6.TabIndex = 31;
            this.label6.Text = "Cantidad";
            // 
            // txtCostoTotalINsumo
            // 
            this.txtCostoTotalINsumo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCostoTotalINsumo.Enabled = false;
            this.txtCostoTotalINsumo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoTotalINsumo.Location = new System.Drawing.Point(683, 99);
            this.txtCostoTotalINsumo.Name = "txtCostoTotalINsumo";
            this.txtCostoTotalINsumo.Size = new System.Drawing.Size(119, 26);
            this.txtCostoTotalINsumo.TabIndex = 34;
            this.txtCostoTotalINsumo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(679, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 19);
            this.label7.TabIndex = 33;
            this.label7.Text = "Costo Total";
            // 
            // dgDetalleOrden
            // 
            this.dgDetalleOrden.AllowUserToAddRows = false;
            this.dgDetalleOrden.AllowUserToDeleteRows = false;
            this.dgDetalleOrden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDetalleOrden.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgDetalleOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetalleOrden.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idOrdenDetalle,
            this.idInsumoOrden,
            this.descripcionInsumoOrden,
            this.cantidadInsumoOrden,
            this.costoInsumoUnidad,
            this.costoTotalInsumoOrden});
            this.dgDetalleOrden.Location = new System.Drawing.Point(16, 131);
            this.dgDetalleOrden.Name = "dgDetalleOrden";
            this.dgDetalleOrden.ReadOnly = true;
            this.dgDetalleOrden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDetalleOrden.Size = new System.Drawing.Size(695, 383);
            this.dgDetalleOrden.TabIndex = 36;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 44;
            // 
            // idOrdenDetalle
            // 
            this.idOrdenDetalle.DataPropertyName = "idOrdenDetalle";
            this.idOrdenDetalle.HeaderText = "idOrdenDetalle";
            this.idOrdenDetalle.Name = "idOrdenDetalle";
            this.idOrdenDetalle.ReadOnly = true;
            this.idOrdenDetalle.Visible = false;
            this.idOrdenDetalle.Width = 129;
            // 
            // idInsumoOrden
            // 
            this.idInsumoOrden.DataPropertyName = "idInsumoOrden";
            this.idInsumoOrden.HeaderText = "idInsumoOrden";
            this.idInsumoOrden.Name = "idInsumoOrden";
            this.idInsumoOrden.ReadOnly = true;
            this.idInsumoOrden.Visible = false;
            this.idInsumoOrden.Width = 130;
            // 
            // descripcionInsumoOrden
            // 
            this.descripcionInsumoOrden.DataPropertyName = "descripcionInsumoOrden";
            this.descripcionInsumoOrden.HeaderText = "Descripción Insumo";
            this.descripcionInsumoOrden.Name = "descripcionInsumoOrden";
            this.descripcionInsumoOrden.ReadOnly = true;
            this.descripcionInsumoOrden.Width = 145;
            // 
            // cantidadInsumoOrden
            // 
            this.cantidadInsumoOrden.DataPropertyName = "cantidadInsumoOrden";
            this.cantidadInsumoOrden.HeaderText = "Cantidad";
            this.cantidadInsumoOrden.Name = "cantidadInsumoOrden";
            this.cantidadInsumoOrden.ReadOnly = true;
            this.cantidadInsumoOrden.Width = 89;
            // 
            // costoInsumoUnidad
            // 
            this.costoInsumoUnidad.DataPropertyName = "costoInsumoUnidad";
            dataGridViewCellStyle3.Format = "c0";
            this.costoInsumoUnidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.costoInsumoUnidad.HeaderText = "Costo Unidad";
            this.costoInsumoUnidad.Name = "costoInsumoUnidad";
            this.costoInsumoUnidad.ReadOnly = true;
            this.costoInsumoUnidad.Width = 108;
            // 
            // costoTotalInsumoOrden
            // 
            this.costoTotalInsumoOrden.DataPropertyName = "costoTotalInsumoOrden";
            dataGridViewCellStyle4.Format = "c0";
            this.costoTotalInsumoOrden.DefaultCellStyle = dataGridViewCellStyle4;
            this.costoTotalInsumoOrden.HeaderText = "Costo Total";
            this.costoTotalInsumoOrden.Name = "costoTotalInsumoOrden";
            this.costoTotalInsumoOrden.ReadOnly = true;
            this.costoTotalInsumoOrden.Width = 96;
            // 
            // btnEliminarOrden
            // 
            this.btnEliminarOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarOrden.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.error;
            this.btnEliminarOrden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarOrden.FlatAppearance.BorderSize = 0;
            this.btnEliminarOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarOrden.Location = new System.Drawing.Point(730, 250);
            this.btnEliminarOrden.Name = "btnEliminarOrden";
            this.btnEliminarOrden.Size = new System.Drawing.Size(62, 59);
            this.btnEliminarOrden.TabIndex = 44;
            this.btnEliminarOrden.UseVisualStyleBackColor = true;
            this.btnEliminarOrden.Click += new System.EventHandler(this.btnEliminarOrden_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(718, 312);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 40);
            this.label12.TabIndex = 45;
            this.label12.Text = "Eliminar Insumo";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(718, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 42);
            this.label8.TabIndex = 47;
            this.label8.Text = "Agregra Insumo";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAgregarINsumo
            // 
            this.btnAgregarINsumo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarINsumo.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_añadir_100;
            this.btnAgregarINsumo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarINsumo.FlatAppearance.BorderSize = 0;
            this.btnAgregarINsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarINsumo.Location = new System.Drawing.Point(730, 143);
            this.btnAgregarINsumo.Name = "btnAgregarINsumo";
            this.btnAgregarINsumo.Size = new System.Drawing.Size(62, 59);
            this.btnAgregarINsumo.TabIndex = 46;
            this.btnAgregarINsumo.UseVisualStyleBackColor = true;
            this.btnAgregarINsumo.Click += new System.EventHandler(this.btnAgregarINsumo_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(734, 377);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 48;
            this.label9.Text = "Total";
            // 
            // totalText
            // 
            this.totalText.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalText.Location = new System.Drawing.Point(717, 396);
            this.totalText.Name = "totalText";
            this.totalText.Size = new System.Drawing.Size(87, 59);
            this.totalText.TabIndex = 51;
            this.totalText.Text = "label10";
            this.totalText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmInsumoOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(814, 526);
            this.Controls.Add(this.totalText);
            this.Controls.Add(this.dgListaBuscadorImsumo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAgregarINsumo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnEliminarOrden);
            this.Controls.Add(this.dgDetalleOrden);
            this.Controls.Add(this.txtCostoTotalINsumo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescripcionInsumo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCostoInsumo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCantidadActualInsumo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodigoINsumo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBuscadorInsumo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInsumoOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInsumoOrden";
            this.Load += new System.EventHandler(this.frmInsumoOrden_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListaBuscadorImsumo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleOrden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMinimizar;
        public System.Windows.Forms.Label txtTituloFormulario;
        private System.Windows.Forms.Button btnCerrar;
        public System.Windows.Forms.TextBox txtBuscadorInsumo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgListaBuscadorImsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVistaProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionProducto_v;
        private System.Windows.Forms.DataGridViewTextBoxColumn letraTipoMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventarioInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventarioActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn utilidadProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBodega;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreBodega;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreEstaoInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreEstadoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadUnidad;
        public System.Windows.Forms.TextBox txtCantidadActualInsumo;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtCostoInsumo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtCodigoINsumo;
        public System.Windows.Forms.TextBox txtDescripcionInsumo;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtCostoTotalINsumo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgDetalleOrden;
        private System.Windows.Forms.Button btnEliminarOrden;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAgregarINsumo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrdenDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInsumoOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionInsumoOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadInsumoOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoInsumoUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoTotalInsumoOrden;
        private System.Windows.Forms.Label totalText;
    }
}
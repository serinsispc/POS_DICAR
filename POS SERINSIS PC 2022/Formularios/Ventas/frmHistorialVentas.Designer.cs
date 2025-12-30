namespace SERINSI_PC.Formularios.Ventas
{
    partial class frmHistorialVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminarFiltro = new System.Windows.Forms.Button();
            this.txtNumeroVenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbDia = new System.Windows.Forms.RadioButton();
            this.rbMes = new System.Windows.Forms.RadioButton();
            this.rbAño = new System.Windows.Forms.RadioButton();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgVentas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuentoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotalVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivaVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.efectivoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cambioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPagadoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPendienteVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroReferenciaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diasCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdSede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacionVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoTotalVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.utilidadTotalVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guidVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idBaseCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonoTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnImrpimir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVentas)).BeginInit();
            this.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEliminarFiltro);
            this.groupBox1.Controls.Add(this.txtNumeroVenta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbDia);
            this.groupBox1.Controls.Add(this.rbMes);
            this.groupBox1.Controls.Add(this.rbAño);
            this.groupBox1.Controls.Add(this.dtFecha);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 68);
            this.groupBox1.TabIndex = 1;
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
            this.btnEliminarFiltro.Location = new System.Drawing.Point(425, 12);
            this.btnEliminarFiltro.Name = "btnEliminarFiltro";
            this.btnEliminarFiltro.Size = new System.Drawing.Size(66, 50);
            this.btnEliminarFiltro.TabIndex = 67;
            this.btnEliminarFiltro.UseVisualStyleBackColor = true;
            this.btnEliminarFiltro.Click += new System.EventHandler(this.btnEliminarFiltro_Click);
            // 
            // txtNumeroVenta
            // 
            this.txtNumeroVenta.Location = new System.Drawing.Point(319, 37);
            this.txtNumeroVenta.Name = "txtNumeroVenta";
            this.txtNumeroVenta.Size = new System.Drawing.Size(100, 23);
            this.txtNumeroVenta.TabIndex = 6;
            this.txtNumeroVenta.TextChanged += new System.EventHandler(this.txtNumeroVenta_TextChanged);
            this.txtNumeroVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroVenta_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(316, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Número Venta";
            // 
            // rbDia
            // 
            this.rbDia.AutoSize = true;
            this.rbDia.Location = new System.Drawing.Point(252, 28);
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
            this.rbMes.Location = new System.Drawing.Point(200, 28);
            this.rbMes.Name = "rbMes";
            this.rbMes.Size = new System.Drawing.Size(46, 19);
            this.rbMes.TabIndex = 3;
            this.rbMes.TabStop = true;
            this.rbMes.Text = "Mes";
            this.rbMes.UseVisualStyleBackColor = true;
            this.rbMes.CheckedChanged += new System.EventHandler(this.rbMes_CheckedChanged);
            // 
            // rbAño
            // 
            this.rbAño.AutoSize = true;
            this.rbAño.Location = new System.Drawing.Point(148, 28);
            this.rbAño.Name = "rbAño";
            this.rbAño.Size = new System.Drawing.Size(46, 19);
            this.rbAño.TabIndex = 2;
            this.rbAño.TabStop = true;
            this.rbAño.Text = "Año";
            this.rbAño.UseVisualStyleBackColor = true;
            this.rbAño.CheckedChanged += new System.EventHandler(this.rbAño_CheckedChanged);
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
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(578, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 19);
            this.label8.TabIndex = 66;
            this.label8.Text = "Imprimir";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(578, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 34);
            this.label4.TabIndex = 68;
            this.label4.Text = "Anular Venta";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(578, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 34);
            this.label5.TabIndex = 70;
            this.label5.Text = "Ver Detalle";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgVentas
            // 
            this.dgVentas.AllowUserToAddRows = false;
            this.dgVentas.AllowUserToDeleteRows = false;
            this.dgVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgVentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fechaVenta,
            this.tipoFactura,
            this.numeroVenta,
            this.nombreCliente,
            this.descuentoVenta,
            this.subtotalVenta,
            this.ivaVenta,
            this.totalVenta,
            this.efectivoVenta,
            this.cambioVenta,
            this.tipoVenta,
            this.totalPagadoVenta,
            this.totalPendienteVenta,
            this.estadoVenta,
            this.tipoPago,
            this.numeroReferenciaPago,
            this.diasCredito,
            this.fechaVencimiento,
            this.IdSede,
            this.observacionVenta,
            this.costoTotalVenta,
            this.utilidadTotalVenta,
            this.guidVenta,
            this.idBaseCaja,
            this.abonoTarjeta});
            this.dgVentas.Location = new System.Drawing.Point(12, 74);
            this.dgVentas.Name = "dgVentas";
            this.dgVentas.ReadOnly = true;
            this.dgVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVentas.Size = new System.Drawing.Size(561, 334);
            this.dgVentas.TabIndex = 71;
            this.dgVentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVentas_CellContentClick);
            this.dgVentas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgVentas_CellFormatting);
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
            // fechaVenta
            // 
            this.fechaVenta.DataPropertyName = "fechaVenta";
            this.fechaVenta.HeaderText = "Fecha";
            this.fechaVenta.Name = "fechaVenta";
            this.fechaVenta.ReadOnly = true;
            this.fechaVenta.Width = 71;
            // 
            // tipoFactura
            // 
            this.tipoFactura.DataPropertyName = "tipoFactura";
            this.tipoFactura.HeaderText = "Factura / Recibo";
            this.tipoFactura.Name = "tipoFactura";
            this.tipoFactura.ReadOnly = true;
            this.tipoFactura.Width = 85;
            // 
            // numeroVenta
            // 
            this.numeroVenta.DataPropertyName = "numeroVenta";
            this.numeroVenta.HeaderText = "Numero";
            this.numeroVenta.Name = "numeroVenta";
            this.numeroVenta.ReadOnly = true;
            this.numeroVenta.Width = 83;
            // 
            // nombreCliente
            // 
            this.nombreCliente.DataPropertyName = "nombreCliente";
            this.nombreCliente.HeaderText = "Cliente";
            this.nombreCliente.Name = "nombreCliente";
            this.nombreCliente.ReadOnly = true;
            this.nombreCliente.Width = 77;
            // 
            // descuentoVenta
            // 
            this.descuentoVenta.DataPropertyName = "descuentoVenta";
            this.descuentoVenta.HeaderText = "Descuento";
            this.descuentoVenta.Name = "descuentoVenta";
            this.descuentoVenta.ReadOnly = true;
            // 
            // subtotalVenta
            // 
            this.subtotalVenta.DataPropertyName = "subtotalVenta";
            dataGridViewCellStyle2.Format = "C0";
            dataGridViewCellStyle2.NullValue = null;
            this.subtotalVenta.DefaultCellStyle = dataGridViewCellStyle2;
            this.subtotalVenta.HeaderText = "SubTotal";
            this.subtotalVenta.Name = "subtotalVenta";
            this.subtotalVenta.ReadOnly = true;
            this.subtotalVenta.Width = 89;
            // 
            // ivaVenta
            // 
            this.ivaVenta.DataPropertyName = "ivaVenta";
            this.ivaVenta.HeaderText = "IVA";
            this.ivaVenta.Name = "ivaVenta";
            this.ivaVenta.ReadOnly = true;
            this.ivaVenta.Width = 52;
            // 
            // totalVenta
            // 
            this.totalVenta.DataPropertyName = "totalVenta";
            dataGridViewCellStyle3.Format = "C0";
            this.totalVenta.DefaultCellStyle = dataGridViewCellStyle3;
            this.totalVenta.HeaderText = "Total";
            this.totalVenta.Name = "totalVenta";
            this.totalVenta.ReadOnly = true;
            this.totalVenta.Width = 64;
            // 
            // efectivoVenta
            // 
            this.efectivoVenta.DataPropertyName = "efectivoVenta";
            dataGridViewCellStyle4.Format = "C0";
            this.efectivoVenta.DefaultCellStyle = dataGridViewCellStyle4;
            this.efectivoVenta.HeaderText = "Efectivo";
            this.efectivoVenta.Name = "efectivoVenta";
            this.efectivoVenta.ReadOnly = true;
            this.efectivoVenta.Width = 82;
            // 
            // cambioVenta
            // 
            this.cambioVenta.DataPropertyName = "cambioVenta";
            dataGridViewCellStyle5.Format = "C0";
            this.cambioVenta.DefaultCellStyle = dataGridViewCellStyle5;
            this.cambioVenta.HeaderText = "Cambio";
            this.cambioVenta.Name = "cambioVenta";
            this.cambioVenta.ReadOnly = true;
            this.cambioVenta.Width = 81;
            // 
            // tipoVenta
            // 
            this.tipoVenta.DataPropertyName = "tipoVenta";
            this.tipoVenta.HeaderText = "Tipo";
            this.tipoVenta.Name = "tipoVenta";
            this.tipoVenta.ReadOnly = true;
            this.tipoVenta.Width = 60;
            // 
            // totalPagadoVenta
            // 
            this.totalPagadoVenta.DataPropertyName = "totalPagadoVenta";
            dataGridViewCellStyle6.Format = "C0";
            this.totalPagadoVenta.DefaultCellStyle = dataGridViewCellStyle6;
            this.totalPagadoVenta.HeaderText = "Total Pagado";
            this.totalPagadoVenta.Name = "totalPagadoVenta";
            this.totalPagadoVenta.ReadOnly = true;
            this.totalPagadoVenta.Width = 107;
            // 
            // totalPendienteVenta
            // 
            this.totalPendienteVenta.DataPropertyName = "totalPendienteVenta";
            dataGridViewCellStyle7.Format = "C0";
            this.totalPendienteVenta.DefaultCellStyle = dataGridViewCellStyle7;
            this.totalPendienteVenta.HeaderText = "Pendiente";
            this.totalPendienteVenta.Name = "totalPendienteVenta";
            this.totalPendienteVenta.ReadOnly = true;
            this.totalPendienteVenta.Width = 97;
            // 
            // estadoVenta
            // 
            this.estadoVenta.DataPropertyName = "estadoVenta";
            this.estadoVenta.HeaderText = "Estado";
            this.estadoVenta.Name = "estadoVenta";
            this.estadoVenta.ReadOnly = true;
            this.estadoVenta.Width = 76;
            // 
            // tipoPago
            // 
            this.tipoPago.DataPropertyName = "tipoPago";
            this.tipoPago.HeaderText = "Tipo Pago";
            this.tipoPago.Name = "tipoPago";
            this.tipoPago.ReadOnly = true;
            this.tipoPago.Width = 89;
            // 
            // numeroReferenciaPago
            // 
            this.numeroReferenciaPago.DataPropertyName = "numeroReferenciaPago";
            this.numeroReferenciaPago.HeaderText = "Referencia Pago";
            this.numeroReferenciaPago.Name = "numeroReferenciaPago";
            this.numeroReferenciaPago.ReadOnly = true;
            this.numeroReferenciaPago.Width = 127;
            // 
            // diasCredito
            // 
            this.diasCredito.DataPropertyName = "diasCredito";
            this.diasCredito.HeaderText = "Dias";
            this.diasCredito.Name = "diasCredito";
            this.diasCredito.ReadOnly = true;
            this.diasCredito.Width = 61;
            // 
            // fechaVencimiento
            // 
            this.fechaVencimiento.DataPropertyName = "fechaVencimiento";
            this.fechaVencimiento.HeaderText = "Vencimiento";
            this.fechaVencimiento.Name = "fechaVencimiento";
            this.fechaVencimiento.ReadOnly = true;
            this.fechaVencimiento.Width = 111;
            // 
            // IdSede
            // 
            this.IdSede.DataPropertyName = "IdSede";
            this.IdSede.HeaderText = "IdSede";
            this.IdSede.Name = "IdSede";
            this.IdSede.ReadOnly = true;
            this.IdSede.Visible = false;
            this.IdSede.Width = 77;
            // 
            // observacionVenta
            // 
            this.observacionVenta.DataPropertyName = "observacionVenta";
            this.observacionVenta.HeaderText = "Observación";
            this.observacionVenta.Name = "observacionVenta";
            this.observacionVenta.ReadOnly = true;
            this.observacionVenta.Width = 111;
            // 
            // costoTotalVenta
            // 
            this.costoTotalVenta.DataPropertyName = "costoTotalVenta";
            this.costoTotalVenta.HeaderText = "costoTotalVenta";
            this.costoTotalVenta.Name = "costoTotalVenta";
            this.costoTotalVenta.ReadOnly = true;
            this.costoTotalVenta.Visible = false;
            this.costoTotalVenta.Width = 134;
            // 
            // utilidadTotalVenta
            // 
            this.utilidadTotalVenta.DataPropertyName = "utilidadTotalVenta";
            this.utilidadTotalVenta.HeaderText = "utilidadTotalVenta";
            this.utilidadTotalVenta.Name = "utilidadTotalVenta";
            this.utilidadTotalVenta.ReadOnly = true;
            this.utilidadTotalVenta.Visible = false;
            this.utilidadTotalVenta.Width = 148;
            // 
            // guidVenta
            // 
            this.guidVenta.DataPropertyName = "guidVenta";
            this.guidVenta.HeaderText = "guidVenta";
            this.guidVenta.Name = "guidVenta";
            this.guidVenta.ReadOnly = true;
            this.guidVenta.Visible = false;
            this.guidVenta.Width = 96;
            // 
            // idBaseCaja
            // 
            this.idBaseCaja.DataPropertyName = "idBaseCaja";
            this.idBaseCaja.HeaderText = "idBaseCaja";
            this.idBaseCaja.Name = "idBaseCaja";
            this.idBaseCaja.ReadOnly = true;
            this.idBaseCaja.Visible = false;
            this.idBaseCaja.Width = 105;
            // 
            // abonoTarjeta
            // 
            this.abonoTarjeta.DataPropertyName = "abonoTarjeta";
            this.abonoTarjeta.HeaderText = "abonoTarjeta";
            this.abonoTarjeta.Name = "abonoTarjeta";
            this.abonoTarjeta.ReadOnly = true;
            this.abonoTarjeta.Visible = false;
            this.abonoTarjeta.Width = 117;
            // 
            // btnDetalle
            // 
            this.btnDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetalle.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_ver_detalles_100;
            this.btnDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetalle.FlatAppearance.BorderSize = 0;
            this.btnDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalle.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.Location = new System.Drawing.Point(579, 149);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(66, 50);
            this.btnDetalle.TabIndex = 69;
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnular.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_eliminar_archivo_100;
            this.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnular.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.Location = new System.Drawing.Point(579, 239);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(66, 50);
            this.btnAnular.TabIndex = 67;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnImrpimir
            // 
            this.btnImrpimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImrpimir.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_imprimir_100;
            this.btnImrpimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImrpimir.FlatAppearance.BorderSize = 0;
            this.btnImrpimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImrpimir.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImrpimir.Location = new System.Drawing.Point(579, 74);
            this.btnImrpimir.Name = "btnImrpimir";
            this.btnImrpimir.Size = new System.Drawing.Size(66, 50);
            this.btnImrpimir.TabIndex = 65;
            this.btnImrpimir.UseVisualStyleBackColor = true;
            this.btnImrpimir.Click += new System.EventHandler(this.btnImrpimir_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(580, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 34);
            this.label3.TabIndex = 73;
            this.label3.Text = "Eliminar Venta";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.eliminarPNG;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(581, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 50);
            this.button1.TabIndex = 72;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmHistorialVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 420);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgVentas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnImrpimir);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(675, 375);
            this.Name = "frmHistorialVentas";
            this.Text = "frmHistorialVentas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHistorialVentas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNumeroVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbDia;
        private System.Windows.Forms.RadioButton rbMes;
        private System.Windows.Forms.RadioButton rbAño;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.DataGridView dgVentas;
        private System.Windows.Forms.Button btnEliminarFiltro;
        public System.Windows.Forms.Button btnImrpimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuentoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotalVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivaVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn efectivoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cambioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPagadoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPendienteVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroReferenciaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn diasCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSede;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacionVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoTotalVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn utilidadTotalVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn guidVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBaseCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonoTarjeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}
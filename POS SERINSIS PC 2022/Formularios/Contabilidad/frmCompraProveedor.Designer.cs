namespace SERINSI_PC.Formularios.Inventario
{
    partial class frmCompraProveedor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbTipoBosillo = new System.Windows.Forms.ComboBox();
            this.Bolsillo = new System.Windows.Forms.Label();
            this.dgPagos = new System.Windows.Forms.DataGridView();
            this.idVPagoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consecutivoVPagoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVPagoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facturaVPagoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedorVPagoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalVPagoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPagadoVPagoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagoActualVPagoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoVPagoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idBolsillo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreBolsillo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idBaseCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdSedePagoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPagar = new System.Windows.Forms.Button();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.txtValorAPagar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.dgListaCompras = new System.Windows.Forms.DataGridView();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.idV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facturaCompraV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCompraV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProveedorV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoProveedorV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSedeCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreProveedorV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotalCompraV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivaCompraV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCompraV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorPagadoCompraV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoCompraV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgListaCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbTipoBosillo);
            this.panel1.Controls.Add(this.Bolsillo);
            this.panel1.Controls.Add(this.dgPagos);
            this.panel1.Controls.Add(this.btnPagar);
            this.panel1.Controls.Add(this.txtSaldo);
            this.panel1.Controls.Add(this.txtValorAPagar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 256);
            this.panel1.TabIndex = 0;
            // 
            // cmbTipoBosillo
            // 
            this.cmbTipoBosillo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoBosillo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoBosillo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbTipoBosillo.FormattingEnabled = true;
            this.cmbTipoBosillo.Location = new System.Drawing.Point(537, 34);
            this.cmbTipoBosillo.Name = "cmbTipoBosillo";
            this.cmbTipoBosillo.Size = new System.Drawing.Size(168, 28);
            this.cmbTipoBosillo.TabIndex = 60;
            // 
            // Bolsillo
            // 
            this.Bolsillo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bolsillo.AutoSize = true;
            this.Bolsillo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bolsillo.Location = new System.Drawing.Point(533, 11);
            this.Bolsillo.Name = "Bolsillo";
            this.Bolsillo.Size = new System.Drawing.Size(105, 20);
            this.Bolsillo.TabIndex = 59;
            this.Bolsillo.Text = "Valor a Pagar";
            // 
            // dgPagos
            // 
            this.dgPagos.AllowUserToAddRows = false;
            this.dgPagos.AllowUserToDeleteRows = false;
            this.dgPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPagos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPagos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idVPagoCompra,
            this.consecutivoVPagoCompra,
            this.FechaVPagoCompra,
            this.facturaVPagoCompra,
            this.proveedorVPagoCompra,
            this.totalVPagoCompra,
            this.totalPagadoVPagoCompra,
            this.pagoActualVPagoCompra,
            this.saldoVPagoCompra,
            this.idBolsillo,
            this.nombreBolsillo,
            this.idBaseCaja,
            this.IdSedePagoCompra});
            this.dgPagos.Location = new System.Drawing.Point(12, 34);
            this.dgPagos.Name = "dgPagos";
            this.dgPagos.ReadOnly = true;
            this.dgPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPagos.Size = new System.Drawing.Size(515, 210);
            this.dgPagos.TabIndex = 58;
            // 
            // idVPagoCompra
            // 
            this.idVPagoCompra.DataPropertyName = "idVPagoCompra";
            this.idVPagoCompra.HeaderText = "idVPagoCompra";
            this.idVPagoCompra.Name = "idVPagoCompra";
            this.idVPagoCompra.ReadOnly = true;
            this.idVPagoCompra.Visible = false;
            this.idVPagoCompra.Width = 135;
            // 
            // consecutivoVPagoCompra
            // 
            this.consecutivoVPagoCompra.DataPropertyName = "consecutivoVPagoCompra";
            this.consecutivoVPagoCompra.HeaderText = "idCompra";
            this.consecutivoVPagoCompra.Name = "consecutivoVPagoCompra";
            this.consecutivoVPagoCompra.ReadOnly = true;
            this.consecutivoVPagoCompra.Visible = false;
            this.consecutivoVPagoCompra.Width = 94;
            // 
            // FechaVPagoCompra
            // 
            this.FechaVPagoCompra.DataPropertyName = "FechaVPagoCompra";
            this.FechaVPagoCompra.HeaderText = "Fecha";
            this.FechaVPagoCompra.Name = "FechaVPagoCompra";
            this.FechaVPagoCompra.ReadOnly = true;
            this.FechaVPagoCompra.Width = 71;
            // 
            // facturaVPagoCompra
            // 
            this.facturaVPagoCompra.DataPropertyName = "facturaVPagoCompra";
            this.facturaVPagoCompra.HeaderText = "Factura";
            this.facturaVPagoCompra.Name = "facturaVPagoCompra";
            this.facturaVPagoCompra.ReadOnly = true;
            this.facturaVPagoCompra.Width = 80;
            // 
            // proveedorVPagoCompra
            // 
            this.proveedorVPagoCompra.DataPropertyName = "proveedorVPagoCompra";
            this.proveedorVPagoCompra.HeaderText = "proveedorVPagoCompra";
            this.proveedorVPagoCompra.Name = "proveedorVPagoCompra";
            this.proveedorVPagoCompra.ReadOnly = true;
            this.proveedorVPagoCompra.Visible = false;
            this.proveedorVPagoCompra.Width = 187;
            // 
            // totalVPagoCompra
            // 
            this.totalVPagoCompra.DataPropertyName = "totalVPagoCompra";
            this.totalVPagoCompra.HeaderText = "totalVPagoCompra";
            this.totalVPagoCompra.Name = "totalVPagoCompra";
            this.totalVPagoCompra.ReadOnly = true;
            this.totalVPagoCompra.Visible = false;
            this.totalVPagoCompra.Width = 151;
            // 
            // totalPagadoVPagoCompra
            // 
            this.totalPagadoVPagoCompra.DataPropertyName = "totalPagadoVPagoCompra";
            this.totalPagadoVPagoCompra.HeaderText = "totalPagadoVPagoCompra";
            this.totalPagadoVPagoCompra.Name = "totalPagadoVPagoCompra";
            this.totalPagadoVPagoCompra.ReadOnly = true;
            this.totalPagadoVPagoCompra.Visible = false;
            this.totalPagadoVPagoCompra.Width = 200;
            // 
            // pagoActualVPagoCompra
            // 
            this.pagoActualVPagoCompra.DataPropertyName = "pagoActualVPagoCompra";
            dataGridViewCellStyle2.Format = "c0";
            this.pagoActualVPagoCompra.DefaultCellStyle = dataGridViewCellStyle2;
            this.pagoActualVPagoCompra.HeaderText = "Valor";
            this.pagoActualVPagoCompra.Name = "pagoActualVPagoCompra";
            this.pagoActualVPagoCompra.ReadOnly = true;
            this.pagoActualVPagoCompra.Width = 65;
            // 
            // saldoVPagoCompra
            // 
            this.saldoVPagoCompra.DataPropertyName = "saldoVPagoCompra";
            dataGridViewCellStyle3.Format = "c0";
            this.saldoVPagoCompra.DefaultCellStyle = dataGridViewCellStyle3;
            this.saldoVPagoCompra.HeaderText = "Saldo";
            this.saldoVPagoCompra.Name = "saldoVPagoCompra";
            this.saldoVPagoCompra.ReadOnly = true;
            this.saldoVPagoCompra.Width = 69;
            // 
            // idBolsillo
            // 
            this.idBolsillo.DataPropertyName = "idBolsillo";
            this.idBolsillo.HeaderText = "idBolsillo";
            this.idBolsillo.Name = "idBolsillo";
            this.idBolsillo.ReadOnly = true;
            this.idBolsillo.Visible = false;
            this.idBolsillo.Width = 92;
            // 
            // nombreBolsillo
            // 
            this.nombreBolsillo.DataPropertyName = "nombreBolsillo";
            this.nombreBolsillo.HeaderText = "Bolsillo";
            this.nombreBolsillo.Name = "nombreBolsillo";
            this.nombreBolsillo.ReadOnly = true;
            this.nombreBolsillo.Width = 80;
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
            // IdSedePagoCompra
            // 
            this.IdSedePagoCompra.DataPropertyName = "IdSedePagoCompra";
            this.IdSedePagoCompra.HeaderText = "IdSedePagoCompra";
            this.IdSedePagoCompra.Name = "IdSedePagoCompra";
            this.IdSedePagoCompra.ReadOnly = true;
            this.IdSedePagoCompra.Visible = false;
            this.IdSedePagoCompra.Width = 160;
            // 
            // btnPagar
            // 
            this.btnPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Location = new System.Drawing.Point(537, 172);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(168, 69);
            this.btnPagar.TabIndex = 57;
            this.btnPagar.Text = "Agregar Pago";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // txtSaldo
            // 
            this.txtSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSaldo.Enabled = false;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.Location = new System.Drawing.Point(537, 140);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(168, 26);
            this.txtSaldo.TabIndex = 56;
            this.txtSaldo.TextChanged += new System.EventHandler(this.txtSaldo_TextChanged);
            // 
            // txtValorAPagar
            // 
            this.txtValorAPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorAPagar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorAPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorAPagar.Location = new System.Drawing.Point(537, 88);
            this.txtValorAPagar.Name = "txtValorAPagar";
            this.txtValorAPagar.Size = new System.Drawing.Size(168, 26);
            this.txtValorAPagar.TabIndex = 55;
            this.txtValorAPagar.Text = "0";
            this.txtValorAPagar.TextChanged += new System.EventHandler(this.txtValorAPagar_TextChanged);
            this.txtValorAPagar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorAPagar_KeyDown);
            this.txtValorAPagar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorAPagar_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(533, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 53;
            this.label3.Text = "Valor a Pagar";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(533, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 54;
            this.label4.Text = "Saldo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "Lista de Pagos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar Proveedor por nombre o NIT:";
            // 
            // txtBuscador
            // 
            this.txtBuscador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscador.Location = new System.Drawing.Point(284, 9);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(426, 26);
            this.txtBuscador.TabIndex = 1;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
            this.txtBuscador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscador_KeyDown);
            // 
            // dgListaCompras
            // 
            this.dgListaCompras.AllowUserToAddRows = false;
            this.dgListaCompras.AllowUserToDeleteRows = false;
            this.dgListaCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgListaCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgListaCompras.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgListaCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgListaCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListaCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idV,
            this.facturaCompraV,
            this.fechaCompraV,
            this.idProveedorV,
            this.documentoProveedorV,
            this.idSedeCompra,
            this.nombreProveedorV,
            this.subtotalCompraV,
            this.ivaCompraV,
            this.totalCompraV,
            this.valorPagadoCompraV,
            this.saldoCompraV,
            this.idEstadoAI});
            this.dgListaCompras.Location = new System.Drawing.Point(12, 41);
            this.dgListaCompras.Name = "dgListaCompras";
            this.dgListaCompras.ReadOnly = true;
            this.dgListaCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgListaCompras.Size = new System.Drawing.Size(645, 145);
            this.dgListaCompras.TabIndex = 2;
            this.dgListaCompras.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgListaCompras_CellClick);
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerDetalle.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_ver_detalles_100;
            this.btnVerDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVerDetalle.FlatAppearance.BorderSize = 0;
            this.btnVerDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerDetalle.Location = new System.Drawing.Point(667, 68);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(42, 43);
            this.btnVerDetalle.TabIndex = 68;
            this.btnVerDetalle.UseVisualStyleBackColor = true;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(664, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 70;
            this.label5.Text = "Detalle";
            // 
            // idV
            // 
            this.idV.DataPropertyName = "idV";
            this.idV.HeaderText = "idV";
            this.idV.Name = "idV";
            this.idV.ReadOnly = true;
            this.idV.Visible = false;
            this.idV.Width = 52;
            // 
            // facturaCompraV
            // 
            this.facturaCompraV.DataPropertyName = "facturaCompraV";
            this.facturaCompraV.HeaderText = "Factura";
            this.facturaCompraV.Name = "facturaCompraV";
            this.facturaCompraV.ReadOnly = true;
            this.facturaCompraV.Width = 80;
            // 
            // fechaCompraV
            // 
            this.fechaCompraV.DataPropertyName = "fechaCompraV";
            this.fechaCompraV.HeaderText = "Fecha";
            this.fechaCompraV.Name = "fechaCompraV";
            this.fechaCompraV.ReadOnly = true;
            this.fechaCompraV.Width = 71;
            // 
            // idProveedorV
            // 
            this.idProveedorV.DataPropertyName = "idProveedorV";
            this.idProveedorV.HeaderText = "idProveedorV";
            this.idProveedorV.Name = "idProveedorV";
            this.idProveedorV.ReadOnly = true;
            this.idProveedorV.Visible = false;
            this.idProveedorV.Width = 117;
            // 
            // documentoProveedorV
            // 
            this.documentoProveedorV.DataPropertyName = "documentoProveedorV";
            this.documentoProveedorV.HeaderText = "NIT";
            this.documentoProveedorV.Name = "documentoProveedorV";
            this.documentoProveedorV.ReadOnly = true;
            this.documentoProveedorV.Width = 54;
            // 
            // idSedeCompra
            // 
            this.idSedeCompra.DataPropertyName = "idSedeCompra";
            this.idSedeCompra.HeaderText = "idSedeCompra";
            this.idSedeCompra.Name = "idSedeCompra";
            this.idSedeCompra.ReadOnly = true;
            this.idSedeCompra.Visible = false;
            this.idSedeCompra.Width = 127;
            // 
            // nombreProveedorV
            // 
            this.nombreProveedorV.DataPropertyName = "nombreProveedorV";
            this.nombreProveedorV.HeaderText = "Proveedor";
            this.nombreProveedorV.Name = "nombreProveedorV";
            this.nombreProveedorV.ReadOnly = true;
            this.nombreProveedorV.Width = 97;
            // 
            // subtotalCompraV
            // 
            this.subtotalCompraV.DataPropertyName = "subtotalCompraV";
            dataGridViewCellStyle5.Format = "c0";
            this.subtotalCompraV.DefaultCellStyle = dataGridViewCellStyle5;
            this.subtotalCompraV.HeaderText = "SubTotal";
            this.subtotalCompraV.Name = "subtotalCompraV";
            this.subtotalCompraV.ReadOnly = true;
            this.subtotalCompraV.Width = 89;
            // 
            // ivaCompraV
            // 
            this.ivaCompraV.DataPropertyName = "ivaCompraV";
            dataGridViewCellStyle6.Format = "c0";
            this.ivaCompraV.DefaultCellStyle = dataGridViewCellStyle6;
            this.ivaCompraV.HeaderText = "IVA";
            this.ivaCompraV.Name = "ivaCompraV";
            this.ivaCompraV.ReadOnly = true;
            this.ivaCompraV.Width = 52;
            // 
            // totalCompraV
            // 
            this.totalCompraV.DataPropertyName = "totalCompraV";
            dataGridViewCellStyle7.Format = "c0";
            this.totalCompraV.DefaultCellStyle = dataGridViewCellStyle7;
            this.totalCompraV.HeaderText = "Total";
            this.totalCompraV.Name = "totalCompraV";
            this.totalCompraV.ReadOnly = true;
            this.totalCompraV.Width = 64;
            // 
            // valorPagadoCompraV
            // 
            this.valorPagadoCompraV.DataPropertyName = "valorPagadoCompraV";
            dataGridViewCellStyle8.Format = "c0";
            this.valorPagadoCompraV.DefaultCellStyle = dataGridViewCellStyle8;
            this.valorPagadoCompraV.HeaderText = "Valor Pagado";
            this.valorPagadoCompraV.Name = "valorPagadoCompraV";
            this.valorPagadoCompraV.ReadOnly = true;
            this.valorPagadoCompraV.Width = 108;
            // 
            // saldoCompraV
            // 
            this.saldoCompraV.DataPropertyName = "saldoCompraV";
            dataGridViewCellStyle9.Format = "c0";
            this.saldoCompraV.DefaultCellStyle = dataGridViewCellStyle9;
            this.saldoCompraV.HeaderText = "Saldo";
            this.saldoCompraV.Name = "saldoCompraV";
            this.saldoCompraV.ReadOnly = true;
            this.saldoCompraV.Width = 69;
            // 
            // idEstadoAI
            // 
            this.idEstadoAI.DataPropertyName = "idEstadoAI";
            this.idEstadoAI.HeaderText = "idEstadoAI";
            this.idEstadoAI.Name = "idEstadoAI";
            this.idEstadoAI.ReadOnly = true;
            this.idEstadoAI.Visible = false;
            // 
            // frmCompraProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 448);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnVerDetalle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgListaCompras);
            this.Controls.Add(this.txtBuscador);
            this.Controls.Add(this.panel1);
            this.Name = "frmCompraProveedor";
            this.Text = "frmCompraProveedor";
            this.Load += new System.EventHandler(this.frmCompraProveedor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgListaCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.TextBox txtValorAPagar;
        private System.Windows.Forms.DataGridView dgPagos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.DataGridView dgListaCompras;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTipoBosillo;
        private System.Windows.Forms.Label Bolsillo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVPagoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn consecutivoVPagoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVPagoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn facturaVPagoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorVPagoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalVPagoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPagadoVPagoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagoActualVPagoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoVPagoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBolsillo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreBolsillo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBaseCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSedePagoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn idV;
        private System.Windows.Forms.DataGridViewTextBoxColumn facturaCompraV;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCompraV;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedorV;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoProveedorV;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSedeCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProveedorV;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotalCompraV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivaCompraV;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCompraV;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorPagadoCompraV;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoCompraV;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoAI;
    }
}
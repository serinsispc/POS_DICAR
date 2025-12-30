namespace Invenpol_Parqueadero_Motos.Formularios.Tiemda
{
    partial class frmPagoCreditos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagoCreditos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotalCreditoPendiente = new System.Windows.Forms.Label();
            this.dgBuscadroCliente = new System.Windows.Forms.DataGridView();
            this.txtBuscadorCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgFacturasCargadas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPagadoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPendienteVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.Label();
            this.txtTotalCredito = new System.Windows.Forms.Label();
            this.txtTotalPagado = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalPendiente = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPagarCredito = new System.Windows.Forms.Button();
            this.txtCambio = new System.Windows.Forms.Label();
            this.txtValorAPagar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbBolsillo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.idClienteCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoClienteCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreClienteCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoClienteCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionClienteCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagadoCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBuscadroCliente)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturasCargadas)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTotalCreditoPendiente);
            this.groupBox1.Controls.Add(this.dgBuscadroCliente);
            this.groupBox1.Controls.Add(this.txtBuscadorCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clientes Pendientes";
            // 
            // txtTotalCreditoPendiente
            // 
            this.txtTotalCreditoPendiente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalCreditoPendiente.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCreditoPendiente.Location = new System.Drawing.Point(433, 16);
            this.txtTotalCreditoPendiente.Name = "txtTotalCreditoPendiente";
            this.txtTotalCreditoPendiente.Size = new System.Drawing.Size(250, 18);
            this.txtTotalCreditoPendiente.TabIndex = 3;
            this.txtTotalCreditoPendiente.Text = "--";
            this.txtTotalCreditoPendiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgBuscadroCliente
            // 
            this.dgBuscadroCliente.AllowUserToAddRows = false;
            this.dgBuscadroCliente.AllowUserToDeleteRows = false;
            this.dgBuscadroCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBuscadroCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgBuscadroCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBuscadroCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idClienteCC,
            this.documentoClienteCC,
            this.nombreClienteCC,
            this.telefonoClienteCC,
            this.direccionClienteCC,
            this.TotalCC,
            this.pagadoCC,
            this.saldoCC,
            this.idSede});
            this.dgBuscadroCliente.Location = new System.Drawing.Point(9, 43);
            this.dgBuscadroCliente.Name = "dgBuscadroCliente";
            this.dgBuscadroCliente.ReadOnly = true;
            this.dgBuscadroCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBuscadroCliente.Size = new System.Drawing.Size(671, 153);
            this.dgBuscadroCliente.TabIndex = 2;
            this.dgBuscadroCliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBuscadroCliente_CellClick);
            this.dgBuscadroCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgBuscadroCliente_KeyDown);
            // 
            // txtBuscadorCliente
            // 
            this.txtBuscadorCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscadorCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscadorCliente.Location = new System.Drawing.Point(166, 15);
            this.txtBuscadorCliente.Name = "txtBuscadorCliente";
            this.txtBuscadorCliente.Size = new System.Drawing.Size(258, 22);
            this.txtBuscadorCliente.TabIndex = 1;
            this.txtBuscadorCliente.TextChanged += new System.EventHandler(this.txtBuscadorCliente_TextChanged);
            this.txtBuscadorCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscadorCliente_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar cliente por nombre:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgFacturasCargadas);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 285);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Facturas Cargadas";
            // 
            // dgFacturasCargadas
            // 
            this.dgFacturasCargadas.AllowUserToAddRows = false;
            this.dgFacturasCargadas.AllowUserToDeleteRows = false;
            this.dgFacturasCargadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgFacturasCargadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFacturasCargadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idVenta,
            this.idCliente,
            this.fechaVenta,
            this.tipoFactura,
            this.numeroVenta,
            this.totalVenta,
            this.totalPagadoVenta,
            this.totalPendienteVenta,
            this.estadoVenta});
            this.dgFacturasCargadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFacturasCargadas.Location = new System.Drawing.Point(3, 18);
            this.dgFacturasCargadas.Name = "dgFacturasCargadas";
            this.dgFacturasCargadas.ReadOnly = true;
            this.dgFacturasCargadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFacturasCargadas.Size = new System.Drawing.Size(372, 264);
            this.dgFacturasCargadas.TabIndex = 2;
            this.dgFacturasCargadas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProductosCargados_CellClick);
            this.dgFacturasCargadas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFacturasCargadas_CellDoubleClick);
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
            // idVenta
            // 
            this.idVenta.DataPropertyName = "idVenta";
            this.idVenta.HeaderText = "idVenta";
            this.idVenta.Name = "idVenta";
            this.idVenta.ReadOnly = true;
            this.idVenta.Visible = false;
            this.idVenta.Width = 86;
            // 
            // idCliente
            // 
            this.idCliente.DataPropertyName = "idCliente";
            this.idCliente.HeaderText = "idCliente";
            this.idCliente.Name = "idCliente";
            this.idCliente.ReadOnly = true;
            this.idCliente.Visible = false;
            this.idCliente.Width = 94;
            // 
            // fechaVenta
            // 
            this.fechaVenta.DataPropertyName = "fechaVenta";
            this.fechaVenta.HeaderText = "Fecha";
            this.fechaVenta.Name = "fechaVenta";
            this.fechaVenta.ReadOnly = true;
            this.fechaVenta.Width = 76;
            // 
            // tipoFactura
            // 
            this.tipoFactura.DataPropertyName = "tipoFactura";
            this.tipoFactura.HeaderText = "Tipo";
            this.tipoFactura.Name = "tipoFactura";
            this.tipoFactura.ReadOnly = true;
            this.tipoFactura.Width = 65;
            // 
            // numeroVenta
            // 
            this.numeroVenta.DataPropertyName = "numeroVenta";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.numeroVenta.DefaultCellStyle = dataGridViewCellStyle4;
            this.numeroVenta.HeaderText = "Número";
            this.numeroVenta.Name = "numeroVenta";
            this.numeroVenta.ReadOnly = true;
            this.numeroVenta.Width = 87;
            // 
            // totalVenta
            // 
            this.totalVenta.DataPropertyName = "totalVenta";
            dataGridViewCellStyle5.Format = "c0";
            this.totalVenta.DefaultCellStyle = dataGridViewCellStyle5;
            this.totalVenta.HeaderText = "Total";
            this.totalVenta.Name = "totalVenta";
            this.totalVenta.ReadOnly = true;
            this.totalVenta.Width = 69;
            // 
            // totalPagadoVenta
            // 
            this.totalPagadoVenta.DataPropertyName = "totalPagadoVenta";
            dataGridViewCellStyle6.Format = "c0";
            this.totalPagadoVenta.DefaultCellStyle = dataGridViewCellStyle6;
            this.totalPagadoVenta.HeaderText = "Pagado";
            this.totalPagadoVenta.Name = "totalPagadoVenta";
            this.totalPagadoVenta.ReadOnly = true;
            this.totalPagadoVenta.Width = 88;
            // 
            // totalPendienteVenta
            // 
            this.totalPendienteVenta.DataPropertyName = "totalPendienteVenta";
            dataGridViewCellStyle7.Format = "c0";
            this.totalPendienteVenta.DefaultCellStyle = dataGridViewCellStyle7;
            this.totalPendienteVenta.HeaderText = "Saldo";
            this.totalPendienteVenta.Name = "totalPendienteVenta";
            this.totalPendienteVenta.ReadOnly = true;
            this.totalPendienteVenta.Width = 74;
            // 
            // estadoVenta
            // 
            this.estadoVenta.DataPropertyName = "estadoVenta";
            this.estadoVenta.HeaderText = "Estado";
            this.estadoVenta.Name = "estadoVenta";
            this.estadoVenta.ReadOnly = true;
            this.estadoVenta.Width = 82;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Nombre Cliente";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(586, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Total Credito";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreCliente.AutoSize = true;
            this.txtNombreCliente.Location = new System.Drawing.Point(388, 23);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(13, 13);
            this.txtNombreCliente.TabIndex = 32;
            this.txtNombreCliente.Text = "--";
            // 
            // txtTotalCredito
            // 
            this.txtTotalCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalCredito.AutoSize = true;
            this.txtTotalCredito.Location = new System.Drawing.Point(586, 23);
            this.txtTotalCredito.Name = "txtTotalCredito";
            this.txtTotalCredito.Size = new System.Drawing.Size(13, 13);
            this.txtTotalCredito.TabIndex = 33;
            this.txtTotalCredito.Text = "--";
            // 
            // txtTotalPagado
            // 
            this.txtTotalPagado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPagado.AutoSize = true;
            this.txtTotalPagado.Location = new System.Drawing.Point(387, 56);
            this.txtTotalPagado.Name = "txtTotalPagado";
            this.txtTotalPagado.Size = new System.Drawing.Size(13, 13);
            this.txtTotalPagado.TabIndex = 35;
            this.txtTotalPagado.Text = "--";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Total Pagado";
            // 
            // txtTotalPendiente
            // 
            this.txtTotalPendiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPendiente.AutoSize = true;
            this.txtTotalPendiente.Location = new System.Drawing.Point(586, 56);
            this.txtTotalPendiente.Name = "txtTotalPendiente";
            this.txtTotalPendiente.Size = new System.Drawing.Size(13, 13);
            this.txtTotalPendiente.TabIndex = 37;
            this.txtTotalPendiente.Text = "--";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(586, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Total Pendiente";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldo.BackColor = System.Drawing.Color.Silver;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.ForeColor = System.Drawing.Color.Green;
            this.txtSaldo.Location = new System.Drawing.Point(535, 185);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(139, 35);
            this.txtSaldo.TabIndex = 39;
            this.txtSaldo.Text = "$ 0";
            this.txtSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(578, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 18);
            this.label7.TabIndex = 38;
            this.label7.Text = "Saldo";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(569, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 18);
            this.label8.TabIndex = 40;
            this.label8.Text = "Efectivo";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEfectivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.Location = new System.Drawing.Point(538, 136);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(136, 29);
            this.txtEfectivo.TabIndex = 41;
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEfectivo.TextChanged += new System.EventHandler(this.txtEfectivo_TextChanged);
            this.txtEfectivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEfectivo_KeyDown);
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(426, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 42;
            this.label4.Text = "Cambio";
            // 
            // btnPagarCredito
            // 
            this.btnPagarCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagarCredito.Enabled = false;
            this.btnPagarCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagarCredito.Location = new System.Drawing.Point(519, 223);
            this.btnPagarCredito.Name = "btnPagarCredito";
            this.btnPagarCredito.Size = new System.Drawing.Size(143, 62);
            this.btnPagarCredito.TabIndex = 44;
            this.btnPagarCredito.Text = "Pagar Crédito";
            this.btnPagarCredito.UseVisualStyleBackColor = true;
            this.btnPagarCredito.Click += new System.EventHandler(this.btnPagarCredito_Click);
            // 
            // txtCambio
            // 
            this.txtCambio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCambio.BackColor = System.Drawing.Color.Silver;
            this.txtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCambio.ForeColor = System.Drawing.Color.Green;
            this.txtCambio.Location = new System.Drawing.Point(390, 185);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(139, 35);
            this.txtCambio.TabIndex = 45;
            this.txtCambio.Text = "$ 0";
            this.txtCambio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtValorAPagar
            // 
            this.txtValorAPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorAPagar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorAPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorAPagar.Location = new System.Drawing.Point(390, 136);
            this.txtValorAPagar.Name = "txtValorAPagar";
            this.txtValorAPagar.Size = new System.Drawing.Size(143, 29);
            this.txtValorAPagar.TabIndex = 47;
            this.txtValorAPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorAPagar.TextChanged += new System.EventHandler(this.txtValorAPagar_TextChanged);
            this.txtValorAPagar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorAPagar_KeyDown);
            this.txtValorAPagar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorAPagar_KeyPress);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(406, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 18);
            this.label9.TabIndex = 46;
            this.label9.Text = "Valor A Pagar";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label10.Location = new System.Drawing.Point(415, 246);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 18);
            this.label10.TabIndex = 48;
            this.label10.Text = "Ver Pagos";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbBolsillo);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtValorAPagar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCambio);
            this.panel1.Controls.Add(this.txtNombreCliente);
            this.panel1.Controls.Add(this.btnPagarCredito);
            this.panel1.Controls.Add(this.txtTotalCredito);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtEfectivo);
            this.panel1.Controls.Add(this.txtTotalPagado);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtSaldo);
            this.panel1.Controls.Add(this.txtTotalPendiente);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 199);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 298);
            this.panel1.TabIndex = 49;
            // 
            // cmbBolsillo
            // 
            this.cmbBolsillo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBolsillo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBolsillo.FormattingEnabled = true;
            this.cmbBolsillo.Location = new System.Drawing.Point(481, 87);
            this.cmbBolsillo.Name = "cmbBolsillo";
            this.cmbBolsillo.Size = new System.Drawing.Size(193, 21);
            this.cmbBolsillo.TabIndex = 50;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(406, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 18);
            this.label11.TabIndex = 49;
            this.label11.Text = "Bolsillo:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 199);
            this.panel2.TabIndex = 50;
            // 
            // idClienteCC
            // 
            this.idClienteCC.DataPropertyName = "idClienteCC";
            this.idClienteCC.HeaderText = "idClienteCC";
            this.idClienteCC.Name = "idClienteCC";
            this.idClienteCC.ReadOnly = true;
            this.idClienteCC.Visible = false;
            this.idClienteCC.Width = 114;
            // 
            // documentoClienteCC
            // 
            this.documentoClienteCC.DataPropertyName = "documentoClienteCC";
            this.documentoClienteCC.HeaderText = "Documento";
            this.documentoClienteCC.Name = "documentoClienteCC";
            this.documentoClienteCC.ReadOnly = true;
            this.documentoClienteCC.Width = 111;
            // 
            // nombreClienteCC
            // 
            this.nombreClienteCC.DataPropertyName = "nombreClienteCC";
            this.nombreClienteCC.HeaderText = "Nombre Cliente";
            this.nombreClienteCC.Name = "nombreClienteCC";
            this.nombreClienteCC.ReadOnly = true;
            this.nombreClienteCC.Width = 128;
            // 
            // telefonoClienteCC
            // 
            this.telefonoClienteCC.DataPropertyName = "telefonoClienteCC";
            this.telefonoClienteCC.HeaderText = "Teléfono";
            this.telefonoClienteCC.Name = "telefonoClienteCC";
            this.telefonoClienteCC.ReadOnly = true;
            this.telefonoClienteCC.Width = 95;
            // 
            // direccionClienteCC
            // 
            this.direccionClienteCC.DataPropertyName = "direccionClienteCC";
            this.direccionClienteCC.HeaderText = "Dirección";
            this.direccionClienteCC.Name = "direccionClienteCC";
            this.direccionClienteCC.ReadOnly = true;
            this.direccionClienteCC.Width = 99;
            // 
            // TotalCC
            // 
            this.TotalCC.DataPropertyName = "TotalCC";
            dataGridViewCellStyle1.Format = "c0";
            this.TotalCC.DefaultCellStyle = dataGridViewCellStyle1;
            this.TotalCC.HeaderText = "Total";
            this.TotalCC.Name = "TotalCC";
            this.TotalCC.ReadOnly = true;
            this.TotalCC.Width = 69;
            // 
            // pagadoCC
            // 
            this.pagadoCC.DataPropertyName = "pagadoCC";
            dataGridViewCellStyle2.Format = "c0";
            this.pagadoCC.DefaultCellStyle = dataGridViewCellStyle2;
            this.pagadoCC.HeaderText = "Pagado";
            this.pagadoCC.Name = "pagadoCC";
            this.pagadoCC.ReadOnly = true;
            this.pagadoCC.Width = 88;
            // 
            // saldoCC
            // 
            this.saldoCC.DataPropertyName = "saldoCC";
            dataGridViewCellStyle3.Format = "c0";
            this.saldoCC.DefaultCellStyle = dataGridViewCellStyle3;
            this.saldoCC.HeaderText = "Saldo";
            this.saldoCC.Name = "saldoCC";
            this.saldoCC.ReadOnly = true;
            this.saldoCC.Width = 74;
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
            // frmPagoCreditos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 497);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPagoCreditos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPagoCreditos";
            this.Load += new System.EventHandler(this.frmPagoCreditos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBuscadroCliente)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturasCargadas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBuscadorCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgBuscadroCliente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgFacturasCargadas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtNombreCliente;
        private System.Windows.Forms.Label txtTotalCredito;
        private System.Windows.Forms.Label txtTotalPagado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtTotalPendiente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtSaldo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPagarCredito;
        private System.Windows.Forms.Label txtCambio;
        private System.Windows.Forms.TextBox txtValorAPagar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txtTotalCreditoPendiente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbBolsillo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPagadoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPendienteVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClienteCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoClienteCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreClienteCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoClienteCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionClienteCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagadoCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSede;
    }
}
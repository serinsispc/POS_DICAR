
namespace SERINSI_PC.Formularios.Ventas
{
    partial class frm_pedidos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgPedidos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guidPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guiaPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreEstadoPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diasEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacionPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFacturar = new FontAwesome.Sharp.IconButton();
            this.btnVerDetalle = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarGuia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.btnAlistamiento = new FontAwesome.Sharp.IconButton();
            this.txtPedidosPendientes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbVendedor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFiltrar = new FontAwesome.Sharp.IconButton();
            this.dtDia = new System.Windows.Forms.DateTimePicker();
            this.txtTotalPedidos = new System.Windows.Forms.Label();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnImp1 = new FontAwesome.Sharp.IconButton();
            this.btnReImprimirGrupo = new FontAwesome.Sharp.IconButton();
            this.btnReImprimir1 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidos)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgPedidos
            // 
            this.dgPedidos.AllowUserToAddRows = false;
            this.dgPedidos.AllowUserToDeleteRows = false;
            this.dgPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.guidPedido,
            this.guiaPedido,
            this.idEstadoPedido,
            this.nombreEstadoPedido,
            this.idVendedor,
            this.nombreVendedor,
            this.idCliente,
            this.nombreCliente,
            this.razonSocialCliente,
            this.telefonoCliente,
            this.fechaPedido,
            this.diasEntrega,
            this.fechaEntrega,
            this.totalPedido,
            this.observacionPedido});
            this.dgPedidos.Location = new System.Drawing.Point(12, 98);
            this.dgPedidos.Name = "dgPedidos";
            this.dgPedidos.ReadOnly = true;
            this.dgPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPedidos.Size = new System.Drawing.Size(993, 283);
            this.dgPedidos.TabIndex = 0;
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
            // guidPedido
            // 
            this.guidPedido.DataPropertyName = "guidPedido";
            this.guidPedido.HeaderText = "guidPedido";
            this.guidPedido.Name = "guidPedido";
            this.guidPedido.ReadOnly = true;
            this.guidPedido.Visible = false;
            this.guidPedido.Width = 105;
            // 
            // guiaPedido
            // 
            this.guiaPedido.DataPropertyName = "guiaPedido";
            this.guiaPedido.HeaderText = "Guia";
            this.guiaPedido.Name = "guiaPedido";
            this.guiaPedido.ReadOnly = true;
            this.guiaPedido.Width = 62;
            // 
            // idEstadoPedido
            // 
            this.idEstadoPedido.DataPropertyName = "idEstadoPedido";
            this.idEstadoPedido.HeaderText = "idEstadoPedido";
            this.idEstadoPedido.Name = "idEstadoPedido";
            this.idEstadoPedido.ReadOnly = true;
            this.idEstadoPedido.Visible = false;
            this.idEstadoPedido.Width = 133;
            // 
            // nombreEstadoPedido
            // 
            this.nombreEstadoPedido.DataPropertyName = "nombreEstadoPedido";
            this.nombreEstadoPedido.HeaderText = "Estado";
            this.nombreEstadoPedido.Name = "nombreEstadoPedido";
            this.nombreEstadoPedido.ReadOnly = true;
            this.nombreEstadoPedido.Width = 76;
            // 
            // idVendedor
            // 
            this.idVendedor.DataPropertyName = "idVendedor";
            this.idVendedor.HeaderText = "idVendedor";
            this.idVendedor.Name = "idVendedor";
            this.idVendedor.ReadOnly = true;
            this.idVendedor.Visible = false;
            this.idVendedor.Width = 105;
            // 
            // nombreVendedor
            // 
            this.nombreVendedor.DataPropertyName = "nombreVendedor";
            this.nombreVendedor.HeaderText = "Vendedor";
            this.nombreVendedor.Name = "nombreVendedor";
            this.nombreVendedor.ReadOnly = true;
            this.nombreVendedor.Width = 93;
            // 
            // idCliente
            // 
            this.idCliente.DataPropertyName = "idCliente";
            this.idCliente.HeaderText = "idCliente";
            this.idCliente.Name = "idCliente";
            this.idCliente.ReadOnly = true;
            this.idCliente.Visible = false;
            this.idCliente.Width = 89;
            // 
            // nombreCliente
            // 
            this.nombreCliente.DataPropertyName = "nombreCliente";
            this.nombreCliente.HeaderText = "Cliente";
            this.nombreCliente.Name = "nombreCliente";
            this.nombreCliente.ReadOnly = true;
            this.nombreCliente.Width = 77;
            // 
            // razonSocialCliente
            // 
            this.razonSocialCliente.DataPropertyName = "razonSocialCliente";
            this.razonSocialCliente.HeaderText = "Razon Social";
            this.razonSocialCliente.Name = "razonSocialCliente";
            this.razonSocialCliente.ReadOnly = true;
            this.razonSocialCliente.Width = 107;
            // 
            // telefonoCliente
            // 
            this.telefonoCliente.DataPropertyName = "telefonoCliente";
            this.telefonoCliente.HeaderText = "Teléfono";
            this.telefonoCliente.Name = "telefonoCliente";
            this.telefonoCliente.ReadOnly = true;
            this.telefonoCliente.Width = 88;
            // 
            // fechaPedido
            // 
            this.fechaPedido.DataPropertyName = "fechaPedido";
            this.fechaPedido.HeaderText = "Fecha";
            this.fechaPedido.Name = "fechaPedido";
            this.fechaPedido.ReadOnly = true;
            this.fechaPedido.Width = 71;
            // 
            // diasEntrega
            // 
            this.diasEntrega.DataPropertyName = "diasEntrega";
            this.diasEntrega.HeaderText = "diasEntrega";
            this.diasEntrega.Name = "diasEntrega";
            this.diasEntrega.ReadOnly = true;
            this.diasEntrega.Visible = false;
            this.diasEntrega.Width = 109;
            // 
            // fechaEntrega
            // 
            this.fechaEntrega.DataPropertyName = "fechaEntrega";
            this.fechaEntrega.HeaderText = "fechaEntrega";
            this.fechaEntrega.Name = "fechaEntrega";
            this.fechaEntrega.ReadOnly = true;
            this.fechaEntrega.Visible = false;
            this.fechaEntrega.Width = 117;
            // 
            // totalPedido
            // 
            this.totalPedido.DataPropertyName = "totalPedido";
            dataGridViewCellStyle6.Format = "C0";
            dataGridViewCellStyle6.NullValue = null;
            this.totalPedido.DefaultCellStyle = dataGridViewCellStyle6;
            this.totalPedido.HeaderText = "Total";
            this.totalPedido.Name = "totalPedido";
            this.totalPedido.ReadOnly = true;
            this.totalPedido.Width = 64;
            // 
            // observacionPedido
            // 
            this.observacionPedido.DataPropertyName = "observacionPedido";
            this.observacionPedido.HeaderText = "Observación";
            this.observacionPedido.Name = "observacionPedido";
            this.observacionPedido.ReadOnly = true;
            this.observacionPedido.Width = 111;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFacturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturar.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            this.btnFacturar.IconColor = System.Drawing.Color.Black;
            this.btnFacturar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFacturar.IconSize = 40;
            this.btnFacturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturar.Location = new System.Drawing.Point(1161, 3);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnFacturar.Size = new System.Drawing.Size(142, 45);
            this.btnFacturar.TabIndex = 51;
            this.btnFacturar.Text = "Facturar Grupo";
            this.btnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalle.IconChar = FontAwesome.Sharp.IconChar.FileAlt;
            this.btnVerDetalle.IconColor = System.Drawing.Color.Black;
            this.btnVerDetalle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerDetalle.IconSize = 40;
            this.btnVerDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerDetalle.Location = new System.Drawing.Point(1013, 3);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnVerDetalle.Size = new System.Drawing.Size(142, 45);
            this.btnVerDetalle.TabIndex = 52;
            this.btnVerDetalle.Text = "Ver Detalle";
            this.btnVerDetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerDetalle.UseVisualStyleBackColor = true;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 53;
            this.label1.Text = "Buscar Guia";
            // 
            // txtBuscarGuia
            // 
            this.txtBuscarGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarGuia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarGuia.Location = new System.Drawing.Point(7, 28);
            this.txtBuscarGuia.Name = "txtBuscarGuia";
            this.txtBuscarGuia.Size = new System.Drawing.Size(100, 22);
            this.txtBuscarGuia.TabIndex = 54;
            this.txtBuscarGuia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarGuia_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 55;
            this.label2.Text = "Estado Pedido";
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(9, 28);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(144, 24);
            this.cbEstado.TabIndex = 56;
            this.cbEstado.SelectedIndexChanged += new System.EventHandler(this.cbEstado_SelectedIndexChanged);
            // 
            // btnAlistamiento
            // 
            this.btnAlistamiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlistamiento.Enabled = false;
            this.btnAlistamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlistamiento.IconChar = FontAwesome.Sharp.IconChar.CartFlatbed;
            this.btnAlistamiento.IconColor = System.Drawing.Color.Black;
            this.btnAlistamiento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAlistamiento.IconSize = 40;
            this.btnAlistamiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlistamiento.Location = new System.Drawing.Point(865, 3);
            this.btnAlistamiento.Name = "btnAlistamiento";
            this.btnAlistamiento.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnAlistamiento.Size = new System.Drawing.Size(142, 45);
            this.btnAlistamiento.TabIndex = 57;
            this.btnAlistamiento.Text = "Consolidado";
            this.btnAlistamiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlistamiento.UseVisualStyleBackColor = true;
            this.btnAlistamiento.Click += new System.EventHandler(this.btnAlistamiento_Click);
            // 
            // txtPedidosPendientes
            // 
            this.txtPedidosPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPedidosPendientes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPedidosPendientes.Enabled = false;
            this.txtPedidosPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPedidosPendientes.Location = new System.Drawing.Point(8, 28);
            this.txtPedidosPendientes.Name = "txtPedidosPendientes";
            this.txtPedidosPendientes.Size = new System.Drawing.Size(77, 22);
            this.txtPedidosPendientes.TabIndex = 59;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 58;
            this.label3.Text = "Pedidos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbVendedor
            // 
            this.cbVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVendedor.FormattingEnabled = true;
            this.cbVendedor.Location = new System.Drawing.Point(3, 28);
            this.cbVendedor.Name = "cbVendedor";
            this.cbVendedor.Size = new System.Drawing.Size(239, 24);
            this.cbVendedor.TabIndex = 61;
            this.cbVendedor.SelectedIndexChanged += new System.EventHandler(this.cbVendedor_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "Vendedor";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 16);
            this.label5.TabIndex = 62;
            this.label5.Text = "Día";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.btnFiltrar.IconColor = System.Drawing.Color.Black;
            this.btnFiltrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFiltrar.IconSize = 40;
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Location = new System.Drawing.Point(664, 3);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnFiltrar.Size = new System.Drawing.Size(101, 45);
            this.btnFiltrar.TabIndex = 64;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dtDia
            // 
            this.dtDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDia.Location = new System.Drawing.Point(11, 28);
            this.dtDia.Name = "dtDia";
            this.dtDia.Size = new System.Drawing.Size(103, 20);
            this.dtDia.TabIndex = 65;
            // 
            // txtTotalPedidos
            // 
            this.txtTotalPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPedidos.Location = new System.Drawing.Point(12, 400);
            this.txtTotalPedidos.Name = "txtTotalPedidos";
            this.txtTotalPedidos.Size = new System.Drawing.Size(845, 31);
            this.txtTotalPedidos.TabIndex = 66;
            this.txtTotalPedidos.Text = "$ 0";
            this.txtTotalPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir.IconColor = System.Drawing.Color.Black;
            this.btnImprimir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir.IconSize = 40;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(863, 395);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnImprimir.Size = new System.Drawing.Size(142, 45);
            this.btnImprimir.TabIndex = 67;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.btnFiltrar);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.btnAlistamiento);
            this.flowLayoutPanel1.Controls.Add(this.btnVerDetalle);
            this.flowLayoutPanel1.Controls.Add(this.btnFacturar);
            this.flowLayoutPanel1.Controls.Add(this.btnImp1);
            this.flowLayoutPanel1.Controls.Add(this.btnReImprimirGrupo);
            this.flowLayoutPanel1.Controls.Add(this.btnReImprimir1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1017, 80);
            this.flowLayoutPanel1.TabIndex = 89;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtBuscarGuia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 55);
            this.panel1.TabIndex = 90;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbEstado);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(119, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(157, 55);
            this.panel2.TabIndex = 91;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbVendedor);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(282, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(253, 55);
            this.panel3.TabIndex = 90;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtDia);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(541, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(117, 55);
            this.panel4.TabIndex = 90;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtPedidosPendientes);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(771, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(88, 55);
            this.panel5.TabIndex = 90;
            // 
            // btnImp1
            // 
            this.btnImp1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImp1.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            this.btnImp1.IconColor = System.Drawing.Color.Black;
            this.btnImp1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImp1.IconSize = 40;
            this.btnImp1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImp1.Location = new System.Drawing.Point(1309, 3);
            this.btnImp1.Name = "btnImp1";
            this.btnImp1.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnImp1.Size = new System.Drawing.Size(142, 45);
            this.btnImp1.TabIndex = 90;
            this.btnImp1.Text = "Facturar 1";
            this.btnImp1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImp1.UseVisualStyleBackColor = true;
            this.btnImp1.Click += new System.EventHandler(this.btnImp1_Click);
            // 
            // btnReImprimirGrupo
            // 
            this.btnReImprimirGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReImprimirGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReImprimirGrupo.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnReImprimirGrupo.IconColor = System.Drawing.Color.Black;
            this.btnReImprimirGrupo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReImprimirGrupo.IconSize = 40;
            this.btnReImprimirGrupo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReImprimirGrupo.Location = new System.Drawing.Point(1457, 3);
            this.btnReImprimirGrupo.Name = "btnReImprimirGrupo";
            this.btnReImprimirGrupo.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnReImprimirGrupo.Size = new System.Drawing.Size(142, 45);
            this.btnReImprimirGrupo.TabIndex = 92;
            this.btnReImprimirGrupo.Text = "Imprimir Grupo";
            this.btnReImprimirGrupo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReImprimirGrupo.UseVisualStyleBackColor = true;
            this.btnReImprimirGrupo.Click += new System.EventHandler(this.btnReImprimirGrupo_Click);
            // 
            // btnReImprimir1
            // 
            this.btnReImprimir1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReImprimir1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReImprimir1.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnReImprimir1.IconColor = System.Drawing.Color.Black;
            this.btnReImprimir1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReImprimir1.IconSize = 40;
            this.btnReImprimir1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReImprimir1.Location = new System.Drawing.Point(1605, 3);
            this.btnReImprimir1.Name = "btnReImprimir1";
            this.btnReImprimir1.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnReImprimir1.Size = new System.Drawing.Size(142, 45);
            this.btnReImprimir1.TabIndex = 93;
            this.btnReImprimir1.Text = "Imprimir 1";
            this.btnReImprimir1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReImprimir1.UseVisualStyleBackColor = true;
            this.btnReImprimir1.Click += new System.EventHandler(this.btnReImprimir1_Click);
            // 
            // frm_pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.txtTotalPedidos);
            this.Controls.Add(this.dgPedidos);
            this.MinimumSize = new System.Drawing.Size(1033, 489);
            this.Name = "frm_pedidos";
            this.Text = "frm_pedidos";
            this.Load += new System.EventHandler(this.frm_pedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidos)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPedidos;
        private FontAwesome.Sharp.IconButton btnFacturar;
        private FontAwesome.Sharp.IconButton btnVerDetalle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarGuia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn guidPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn guiaPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreEstadoPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn diasEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacionPedido;
        private FontAwesome.Sharp.IconButton btnAlistamiento;
        private System.Windows.Forms.TextBox txtPedidosPendientes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbVendedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btnFiltrar;
        private System.Windows.Forms.DateTimePicker dtDia;
        private System.Windows.Forms.Label txtTotalPedidos;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private FontAwesome.Sharp.IconButton btnImp1;
        private FontAwesome.Sharp.IconButton btnReImprimirGrupo;
        private FontAwesome.Sharp.IconButton btnReImprimir1;
    }
}
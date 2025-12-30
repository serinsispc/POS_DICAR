namespace POS_SERINSIS_PC_2022.Formularios.Configuracion
{
    partial class frmRutero
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgRutas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudadCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barrioCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSemana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaSemana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscarCliente = new FontAwesome.Sharp.IconButton();
            this.btnBuscarVendedor = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtTelefonoCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelefonoVendedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDia = new System.Windows.Forms.ComboBox();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnEditar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.txtFiltrarRutero = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRefrescar = new FontAwesome.Sharp.IconButton();
            this.cbFiltrarDia = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.btnFiltrar = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.cbVendedor = new System.Windows.Forms.ComboBox();
            this.txtCantidadCleintes = new System.Windows.Forms.Label();
            this.btnEliminarRutero = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgRutas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgRutas
            // 
            this.dgRutas.AllowUserToAddRows = false;
            this.dgRutas.AllowUserToDeleteRows = false;
            this.dgRutas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRutas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRutas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgRutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRutas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idVendedor,
            this.idCliente,
            this.razonSocialCliente,
            this.nombreCliente,
            this.documentoCliente,
            this.telefonoCliente,
            this.direccionCliente,
            this.ciudadCliente,
            this.barrioCliente,
            this.idSemana,
            this.diaSemana,
            this.nombreVendedor,
            this.telefonoVendedor});
            this.dgRutas.Location = new System.Drawing.Point(12, 165);
            this.dgRutas.Name = "dgRutas";
            this.dgRutas.ReadOnly = true;
            this.dgRutas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRutas.Size = new System.Drawing.Size(651, 273);
            this.dgRutas.TabIndex = 0;
            this.dgRutas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRutas_CellClick);
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
            // idVendedor
            // 
            this.idVendedor.DataPropertyName = "idVendedor";
            this.idVendedor.HeaderText = "idVendedor";
            this.idVendedor.Name = "idVendedor";
            this.idVendedor.ReadOnly = true;
            this.idVendedor.Visible = false;
            this.idVendedor.Width = 105;
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
            // razonSocialCliente
            // 
            this.razonSocialCliente.DataPropertyName = "razonSocialCliente";
            this.razonSocialCliente.HeaderText = "Razon Social";
            this.razonSocialCliente.Name = "razonSocialCliente";
            this.razonSocialCliente.ReadOnly = true;
            this.razonSocialCliente.Width = 107;
            // 
            // nombreCliente
            // 
            this.nombreCliente.DataPropertyName = "nombreCliente";
            this.nombreCliente.HeaderText = "Cliente";
            this.nombreCliente.Name = "nombreCliente";
            this.nombreCliente.ReadOnly = true;
            this.nombreCliente.Width = 77;
            // 
            // documentoCliente
            // 
            this.documentoCliente.DataPropertyName = "documentoCliente";
            this.documentoCliente.HeaderText = "Documento";
            this.documentoCliente.Name = "documentoCliente";
            this.documentoCliente.ReadOnly = true;
            this.documentoCliente.Width = 105;
            // 
            // telefonoCliente
            // 
            this.telefonoCliente.DataPropertyName = "telefonoCliente";
            this.telefonoCliente.HeaderText = "Teléfono";
            this.telefonoCliente.Name = "telefonoCliente";
            this.telefonoCliente.ReadOnly = true;
            this.telefonoCliente.Width = 88;
            // 
            // direccionCliente
            // 
            this.direccionCliente.DataPropertyName = "direccionCliente";
            this.direccionCliente.HeaderText = "Dirección";
            this.direccionCliente.Name = "direccionCliente";
            this.direccionCliente.ReadOnly = true;
            this.direccionCliente.Width = 93;
            // 
            // ciudadCliente
            // 
            this.ciudadCliente.DataPropertyName = "ciudadCliente";
            this.ciudadCliente.HeaderText = "Ciudad";
            this.ciudadCliente.Name = "ciudadCliente";
            this.ciudadCliente.ReadOnly = true;
            this.ciudadCliente.Width = 77;
            // 
            // barrioCliente
            // 
            this.barrioCliente.DataPropertyName = "barrioCliente";
            this.barrioCliente.HeaderText = "Barrio";
            this.barrioCliente.Name = "barrioCliente";
            this.barrioCliente.ReadOnly = true;
            this.barrioCliente.Width = 71;
            // 
            // idSemana
            // 
            this.idSemana.DataPropertyName = "idSemana";
            this.idSemana.HeaderText = "idSemana";
            this.idSemana.Name = "idSemana";
            this.idSemana.ReadOnly = true;
            this.idSemana.Visible = false;
            this.idSemana.Width = 97;
            // 
            // diaSemana
            // 
            this.diaSemana.DataPropertyName = "diaSemana";
            this.diaSemana.HeaderText = "Día";
            this.diaSemana.Name = "diaSemana";
            this.diaSemana.ReadOnly = true;
            this.diaSemana.Width = 54;
            // 
            // nombreVendedor
            // 
            this.nombreVendedor.DataPropertyName = "nombreVendedor";
            this.nombreVendedor.HeaderText = "Vendedor";
            this.nombreVendedor.Name = "nombreVendedor";
            this.nombreVendedor.ReadOnly = true;
            this.nombreVendedor.Width = 93;
            // 
            // telefonoVendedor
            // 
            this.telefonoVendedor.DataPropertyName = "telefonoVendedor";
            this.telefonoVendedor.HeaderText = "Telefono Vendedor";
            this.telefonoVendedor.Name = "telefonoVendedor";
            this.telefonoVendedor.ReadOnly = true;
            this.telefonoVendedor.Width = 140;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCliente.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarCliente.IconColor = System.Drawing.Color.Black;
            this.btnBuscarCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarCliente.IconSize = 40;
            this.btnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarCliente.Location = new System.Drawing.Point(12, 12);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnBuscarCliente.Size = new System.Drawing.Size(119, 45);
            this.btnBuscarCliente.TabIndex = 51;
            this.btnBuscarCliente.Text = "Buscar Cliente";
            this.btnBuscarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // btnBuscarVendedor
            // 
            this.btnBuscarVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarVendedor.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarVendedor.IconColor = System.Drawing.Color.Black;
            this.btnBuscarVendedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarVendedor.IconSize = 40;
            this.btnBuscarVendedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarVendedor.Location = new System.Drawing.Point(12, 63);
            this.btnBuscarVendedor.Name = "btnBuscarVendedor";
            this.btnBuscarVendedor.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnBuscarVendedor.Size = new System.Drawing.Size(119, 45);
            this.btnBuscarVendedor.TabIndex = 52;
            this.btnBuscarVendedor.Text = "Buscar Vendedor";
            this.btnBuscarVendedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarVendedor.UseVisualStyleBackColor = true;
            this.btnBuscarVendedor.Click += new System.EventHandler(this.btnBuscarVendedor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 53;
            this.label1.Text = "Nombre Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.Enabled = false;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(140, 31);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(334, 24);
            this.txtCliente.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(477, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 55;
            this.label2.Text = "C.c. / NIT.";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumento.Enabled = false;
            this.txtDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(480, 31);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(151, 24);
            this.txtDocumento.TabIndex = 56;
            // 
            // txtTelefonoCliente
            // 
            this.txtTelefonoCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefonoCliente.Enabled = false;
            this.txtTelefonoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonoCliente.Location = new System.Drawing.Point(637, 31);
            this.txtTelefonoCliente.Name = "txtTelefonoCliente";
            this.txtTelefonoCliente.Size = new System.Drawing.Size(151, 24);
            this.txtTelefonoCliente.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(634, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 57;
            this.label3.Text = "Teléfono";
            // 
            // txtTelefonoVendedor
            // 
            this.txtTelefonoVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefonoVendedor.Enabled = false;
            this.txtTelefonoVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonoVendedor.Location = new System.Drawing.Point(477, 84);
            this.txtTelefonoVendedor.Name = "txtTelefonoVendedor";
            this.txtTelefonoVendedor.Size = new System.Drawing.Size(151, 24);
            this.txtTelefonoVendedor.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(474, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 63;
            this.label4.Text = "Teléfono";
            // 
            // txtVendedor
            // 
            this.txtVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVendedor.Enabled = false;
            this.txtVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendedor.Location = new System.Drawing.Point(137, 84);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(334, 24);
            this.txtVendedor.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(134, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 16);
            this.label6.TabIndex = 59;
            this.label6.Text = "Nombre Vendedor";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(634, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 16);
            this.label5.TabIndex = 65;
            this.label5.Text = "Día";
            // 
            // cbDia
            // 
            this.cbDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDia.FormattingEnabled = true;
            this.cbDia.Location = new System.Drawing.Point(634, 82);
            this.cbDia.Name = "cbDia";
            this.cbDia.Size = new System.Drawing.Size(154, 26);
            this.cbDia.TabIndex = 66;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminar.IconColor = System.Drawing.Color.Black;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 40;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(669, 267);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnEliminar.Size = new System.Drawing.Size(119, 45);
            this.btnEliminar.TabIndex = 67;
            this.btnEliminar.Text = "ELiminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.IconChar = FontAwesome.Sharp.IconChar.FilePen;
            this.btnEditar.IconColor = System.Drawing.Color.Black;
            this.btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar.IconSize = 40;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(669, 216);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnEditar.Size = new System.Drawing.Size(119, 45);
            this.btnEditar.TabIndex = 68;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor = System.Drawing.Color.Black;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 40;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(669, 165);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnGuardar.Size = new System.Drawing.Size(119, 45);
            this.btnGuardar.TabIndex = 69;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtFiltrarRutero
            // 
            this.txtFiltrarRutero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltrarRutero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFiltrarRutero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltrarRutero.Location = new System.Drawing.Point(15, 133);
            this.txtFiltrarRutero.Name = "txtFiltrarRutero";
            this.txtFiltrarRutero.Size = new System.Drawing.Size(233, 24);
            this.txtFiltrarRutero.TabIndex = 71;
            this.txtFiltrarRutero.TextChanged += new System.EventHandler(this.txtFiltrarRutero_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 16);
            this.label7.TabIndex = 70;
            this.label7.Text = "Filtrar Rutero";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefrescar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrescar.IconChar = FontAwesome.Sharp.IconChar.Rotate;
            this.btnRefrescar.IconColor = System.Drawing.Color.Black;
            this.btnRefrescar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRefrescar.IconSize = 40;
            this.btnRefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefrescar.Location = new System.Drawing.Point(669, 366);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnRefrescar.Size = new System.Drawing.Size(119, 45);
            this.btnRefrescar.TabIndex = 72;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // cbFiltrarDia
            // 
            this.cbFiltrarDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFiltrarDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltrarDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFiltrarDia.FormattingEnabled = true;
            this.cbFiltrarDia.Location = new System.Drawing.Point(421, 131);
            this.cbFiltrarDia.Name = "cbFiltrarDia";
            this.cbFiltrarDia.Size = new System.Drawing.Size(119, 26);
            this.cbFiltrarDia.TabIndex = 74;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(421, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 16);
            this.label8.TabIndex = 73;
            this.label8.Text = "Filtrar Día";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir.IconColor = System.Drawing.Color.Black;
            this.btnImprimir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir.IconSize = 40;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(669, 114);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnImprimir.Size = new System.Drawing.Size(119, 45);
            this.btnImprimir.TabIndex = 75;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
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
            this.btnFiltrar.Location = new System.Drawing.Point(546, 114);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnFiltrar.Size = new System.Drawing.Size(119, 45);
            this.btnFiltrar.TabIndex = 76;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(251, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 16);
            this.label9.TabIndex = 77;
            this.label9.Text = "Filtrar Vendedor";
            // 
            // cbVendedor
            // 
            this.cbVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVendedor.FormattingEnabled = true;
            this.cbVendedor.Location = new System.Drawing.Point(254, 131);
            this.cbVendedor.Name = "cbVendedor";
            this.cbVendedor.Size = new System.Drawing.Size(161, 26);
            this.cbVendedor.TabIndex = 78;
            // 
            // txtCantidadCleintes
            // 
            this.txtCantidadCleintes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantidadCleintes.AutoSize = true;
            this.txtCantidadCleintes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadCleintes.Location = new System.Drawing.Point(767, 414);
            this.txtCantidadCleintes.Name = "txtCantidadCleintes";
            this.txtCantidadCleintes.Size = new System.Drawing.Size(21, 24);
            this.txtCantidadCleintes.TabIndex = 79;
            this.txtCantidadCleintes.Text = "0";
            // 
            // btnEliminarRutero
            // 
            this.btnEliminarRutero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarRutero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarRutero.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminarRutero.IconColor = System.Drawing.Color.Black;
            this.btnEliminarRutero.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminarRutero.IconSize = 40;
            this.btnEliminarRutero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarRutero.Location = new System.Drawing.Point(669, 318);
            this.btnEliminarRutero.Name = "btnEliminarRutero";
            this.btnEliminarRutero.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnEliminarRutero.Size = new System.Drawing.Size(119, 45);
            this.btnEliminarRutero.TabIndex = 80;
            this.btnEliminarRutero.Text = "Rutero";
            this.btnEliminarRutero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarRutero.UseVisualStyleBackColor = true;
            this.btnEliminarRutero.Click += new System.EventHandler(this.btnEliminarRutero_Click);
            // 
            // frmRutero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEliminarRutero);
            this.Controls.Add(this.txtCantidadCleintes);
            this.Controls.Add(this.cbVendedor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.cbFiltrarDia);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.txtFiltrarRutero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.cbDia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTelefonoVendedor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtVendedor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTelefonoCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscarVendedor);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.dgRutas);
            this.KeyPreview = true;
            this.Name = "frmRutero";
            this.Text = "frmRutero";
            this.Load += new System.EventHandler(this.frmRutero_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRutero_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgRutas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgRutas;
        private FontAwesome.Sharp.IconButton btnBuscarCliente;
        private FontAwesome.Sharp.IconButton btnBuscarVendedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtCliente;
        public System.Windows.Forms.TextBox txtDocumento;
        public System.Windows.Forms.TextBox txtTelefonoCliente;
        public System.Windows.Forms.TextBox txtTelefonoVendedor;
        public System.Windows.Forms.TextBox txtVendedor;
        public System.Windows.Forms.ComboBox cbDia;
        public FontAwesome.Sharp.IconButton btnEliminar;
        public FontAwesome.Sharp.IconButton btnEditar;
        public FontAwesome.Sharp.IconButton btnGuardar;
        public System.Windows.Forms.TextBox txtFiltrarRutero;
        private System.Windows.Forms.Label label7;
        public FontAwesome.Sharp.IconButton btnRefrescar;
        public System.Windows.Forms.ComboBox cbFiltrarDia;
        private System.Windows.Forms.Label label8;
        public FontAwesome.Sharp.IconButton btnImprimir;
        public FontAwesome.Sharp.IconButton btnFiltrar;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cbVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudadCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn barrioCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSemana;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaSemana;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoVendedor;
        private System.Windows.Forms.Label txtCantidadCleintes;
        public FontAwesome.Sharp.IconButton btnEliminarRutero;
    }
}
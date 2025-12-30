namespace SERINSI_PC.Formularios.Orden_de_Servicio
{
    partial class frmOrdenServicio
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
            this.dgOrdenServicio = new System.Windows.Forms.DataGridView();
            this.v_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_numeroOrdenServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_fechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_fechaEntregaOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_idCleinte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_nombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_telefonoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_direccionCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_idServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_nombreServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_idArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_nombreArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_otro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_modeloArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_serialArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_accesoriosArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_observiacioIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_descripcionServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoOrdenServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_usuarioIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_usuarioRetiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgClientes = new System.Windows.Forms.DataGridView();
            this.id_cliente_tienda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cc_nit_cliente_tienda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_cliente_tienda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono_cliente_tienda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion_cleinte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAccsesorios = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescripcionServicio = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtObservicioIngreso = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDireccionCliente = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTelefonoCliente = new System.Windows.Forms.TextBox();
            this.btnCrearCliente = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOtro = new System.Windows.Forms.TextBox();
            this.lavel = new System.Windows.Forms.Label();
            this.cboArticulo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboServicio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCerrarOrden = new System.Windows.Forms.Button();
            this.texEstado = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrdenServicio)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).BeginInit();
            this.panelTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgOrdenServicio
            // 
            this.dgOrdenServicio.AllowUserToAddRows = false;
            this.dgOrdenServicio.AllowUserToDeleteRows = false;
            this.dgOrdenServicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgOrdenServicio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgOrdenServicio.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgOrdenServicio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgOrdenServicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrdenServicio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.v_id,
            this.v_numeroOrdenServicio,
            this.v_fechaIngreso,
            this.v_fechaEntregaOrden,
            this.v_idCleinte,
            this.v_nombreCliente,
            this.v_telefonoCliente,
            this.v_direccionCliente,
            this.v_idServicio,
            this.v_nombreServicio,
            this.v_idArticulo,
            this.v_nombreArticulo,
            this.v_otro,
            this.v_modeloArticulo,
            this.v_serialArticulo,
            this.v_accesoriosArticulo,
            this.v_observiacioIngreso,
            this.v_descripcionServicio,
            this.estadoOrdenServicio,
            this.v_usuarioIngreso,
            this.v_usuarioRetiro});
            this.dgOrdenServicio.Location = new System.Drawing.Point(12, 223);
            this.dgOrdenServicio.Name = "dgOrdenServicio";
            this.dgOrdenServicio.ReadOnly = true;
            this.dgOrdenServicio.RowTemplate.Height = 30;
            this.dgOrdenServicio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOrdenServicio.Size = new System.Drawing.Size(881, 274);
            this.dgOrdenServicio.TabIndex = 31;
            this.dgOrdenServicio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOrdenServicio_CellClick);
            // 
            // v_id
            // 
            this.v_id.DataPropertyName = "v_id";
            this.v_id.HeaderText = "v_id";
            this.v_id.Name = "v_id";
            this.v_id.ReadOnly = true;
            this.v_id.Visible = false;
            this.v_id.Width = 58;
            // 
            // v_numeroOrdenServicio
            // 
            this.v_numeroOrdenServicio.DataPropertyName = "v_numeroOrdenServicio";
            this.v_numeroOrdenServicio.HeaderText = "N° Orden";
            this.v_numeroOrdenServicio.Name = "v_numeroOrdenServicio";
            this.v_numeroOrdenServicio.ReadOnly = true;
            this.v_numeroOrdenServicio.Width = 84;
            // 
            // v_fechaIngreso
            // 
            this.v_fechaIngreso.DataPropertyName = "v_fechaIngreso";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.v_fechaIngreso.DefaultCellStyle = dataGridViewCellStyle2;
            this.v_fechaIngreso.HeaderText = "Fecha Ingreso";
            this.v_fechaIngreso.Name = "v_fechaIngreso";
            this.v_fechaIngreso.ReadOnly = true;
            this.v_fechaIngreso.Width = 113;
            // 
            // v_fechaEntregaOrden
            // 
            this.v_fechaEntregaOrden.DataPropertyName = "v_fechaEntregaOrden";
            this.v_fechaEntregaOrden.HeaderText = "Fecha entrega";
            this.v_fechaEntregaOrden.Name = "v_fechaEntregaOrden";
            this.v_fechaEntregaOrden.ReadOnly = true;
            this.v_fechaEntregaOrden.Width = 114;
            // 
            // v_idCleinte
            // 
            this.v_idCleinte.DataPropertyName = "v_idCleinte";
            this.v_idCleinte.HeaderText = "v_idCleinte";
            this.v_idCleinte.Name = "v_idCleinte";
            this.v_idCleinte.ReadOnly = true;
            this.v_idCleinte.Visible = false;
            this.v_idCleinte.Width = 103;
            // 
            // v_nombreCliente
            // 
            this.v_nombreCliente.DataPropertyName = "v_nombreCliente";
            this.v_nombreCliente.HeaderText = "Cliente";
            this.v_nombreCliente.Name = "v_nombreCliente";
            this.v_nombreCliente.ReadOnly = true;
            this.v_nombreCliente.Width = 77;
            // 
            // v_telefonoCliente
            // 
            this.v_telefonoCliente.DataPropertyName = "v_telefonoCliente";
            this.v_telefonoCliente.HeaderText = "Telefono";
            this.v_telefonoCliente.Name = "v_telefonoCliente";
            this.v_telefonoCliente.ReadOnly = true;
            this.v_telefonoCliente.Width = 88;
            // 
            // v_direccionCliente
            // 
            this.v_direccionCliente.DataPropertyName = "v_direccionCliente";
            this.v_direccionCliente.HeaderText = "v_direccionCliente";
            this.v_direccionCliente.Name = "v_direccionCliente";
            this.v_direccionCliente.ReadOnly = true;
            this.v_direccionCliente.Visible = false;
            this.v_direccionCliente.Width = 150;
            // 
            // v_idServicio
            // 
            this.v_idServicio.DataPropertyName = "v_idServicio";
            this.v_idServicio.HeaderText = "v_idServicio";
            this.v_idServicio.Name = "v_idServicio";
            this.v_idServicio.ReadOnly = true;
            this.v_idServicio.Visible = false;
            this.v_idServicio.Width = 109;
            // 
            // v_nombreServicio
            // 
            this.v_nombreServicio.DataPropertyName = "v_nombreServicio";
            this.v_nombreServicio.HeaderText = "Servicio";
            this.v_nombreServicio.Name = "v_nombreServicio";
            this.v_nombreServicio.ReadOnly = true;
            this.v_nombreServicio.Width = 83;
            // 
            // v_idArticulo
            // 
            this.v_idArticulo.DataPropertyName = "v_idArticulo";
            this.v_idArticulo.HeaderText = "v_idArticulo";
            this.v_idArticulo.Name = "v_idArticulo";
            this.v_idArticulo.ReadOnly = true;
            this.v_idArticulo.Visible = false;
            this.v_idArticulo.Width = 106;
            // 
            // v_nombreArticulo
            // 
            this.v_nombreArticulo.DataPropertyName = "v_nombreArticulo";
            this.v_nombreArticulo.HeaderText = "Articulo";
            this.v_nombreArticulo.Name = "v_nombreArticulo";
            this.v_nombreArticulo.ReadOnly = true;
            this.v_nombreArticulo.Width = 80;
            // 
            // v_otro
            // 
            this.v_otro.DataPropertyName = "v_otro";
            this.v_otro.HeaderText = "Otro";
            this.v_otro.Name = "v_otro";
            this.v_otro.ReadOnly = true;
            this.v_otro.Width = 59;
            // 
            // v_modeloArticulo
            // 
            this.v_modeloArticulo.DataPropertyName = "v_modeloArticulo";
            this.v_modeloArticulo.HeaderText = "Modelo";
            this.v_modeloArticulo.Name = "v_modeloArticulo";
            this.v_modeloArticulo.ReadOnly = true;
            this.v_modeloArticulo.Width = 80;
            // 
            // v_serialArticulo
            // 
            this.v_serialArticulo.DataPropertyName = "v_serialArticulo";
            this.v_serialArticulo.HeaderText = "Serial";
            this.v_serialArticulo.Name = "v_serialArticulo";
            this.v_serialArticulo.ReadOnly = true;
            this.v_serialArticulo.Width = 70;
            // 
            // v_accesoriosArticulo
            // 
            this.v_accesoriosArticulo.DataPropertyName = "v_accesoriosArticulo";
            this.v_accesoriosArticulo.HeaderText = "Accesorios";
            this.v_accesoriosArticulo.Name = "v_accesoriosArticulo";
            this.v_accesoriosArticulo.ReadOnly = true;
            this.v_accesoriosArticulo.Width = 101;
            // 
            // v_observiacioIngreso
            // 
            this.v_observiacioIngreso.DataPropertyName = "v_observiacioIngreso";
            this.v_observiacioIngreso.HeaderText = "Observacion Ingreso";
            this.v_observiacioIngreso.Name = "v_observiacioIngreso";
            this.v_observiacioIngreso.ReadOnly = true;
            this.v_observiacioIngreso.Width = 149;
            // 
            // v_descripcionServicio
            // 
            this.v_descripcionServicio.DataPropertyName = "v_descripcionServicio";
            this.v_descripcionServicio.HeaderText = "Descripción Servicio";
            this.v_descripcionServicio.Name = "v_descripcionServicio";
            this.v_descripcionServicio.ReadOnly = true;
            this.v_descripcionServicio.Width = 149;
            // 
            // estadoOrdenServicio
            // 
            this.estadoOrdenServicio.DataPropertyName = "estadoOrdenServicio";
            this.estadoOrdenServicio.HeaderText = "Estado Orden";
            this.estadoOrdenServicio.Name = "estadoOrdenServicio";
            this.estadoOrdenServicio.ReadOnly = true;
            this.estadoOrdenServicio.Width = 109;
            // 
            // v_usuarioIngreso
            // 
            this.v_usuarioIngreso.DataPropertyName = "v_usuarioIngreso";
            this.v_usuarioIngreso.HeaderText = "Responsable Ingreso";
            this.v_usuarioIngreso.Name = "v_usuarioIngreso";
            this.v_usuarioIngreso.ReadOnly = true;
            this.v_usuarioIngreso.Width = 153;
            // 
            // v_usuarioRetiro
            // 
            this.v_usuarioRetiro.DataPropertyName = "v_usuarioRetiro";
            this.v_usuarioRetiro.HeaderText = "Responsable Retiro";
            this.v_usuarioRetiro.Name = "v_usuarioRetiro";
            this.v_usuarioRetiro.ReadOnly = true;
            this.v_usuarioRetiro.Width = 145;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgClientes);
            this.panel3.Controls.Add(this.txtAccsesorios);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtDescripcionServicio);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtObservicioIngreso);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtDireccionCliente);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtTelefonoCliente);
            this.panel3.Controls.Add(this.btnCrearCliente);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtNombreCliente);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtSerial);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtModelo);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtOtro);
            this.panel3.Controls.Add(this.lavel);
            this.panel3.Controls.Add(this.cboArticulo);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cboServicio);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(2, 24);
            this.panel3.MaximumSize = new System.Drawing.Size(891, 296);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(891, 193);
            this.panel3.TabIndex = 32;
            // 
            // dgClientes
            // 
            this.dgClientes.AllowUserToAddRows = false;
            this.dgClientes.AllowUserToDeleteRows = false;
            this.dgClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_cliente_tienda,
            this.cc_nit_cliente_tienda,
            this.nombre_cliente_tienda,
            this.telefono_cliente_tienda,
            this.direccion_cleinte});
            this.dgClientes.Location = new System.Drawing.Point(15, 44);
            this.dgClientes.Name = "dgClientes";
            this.dgClientes.ReadOnly = true;
            this.dgClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgClientes.Size = new System.Drawing.Size(713, 150);
            this.dgClientes.TabIndex = 40;
            this.dgClientes.Visible = false;
            this.dgClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgClientes_CellDoubleClick);
            this.dgClientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgClientes_KeyDown);
            // 
            // id_cliente_tienda
            // 
            this.id_cliente_tienda.DataPropertyName = "id_cliente_tienda";
            this.id_cliente_tienda.HeaderText = "id_cliente_tienda";
            this.id_cliente_tienda.Name = "id_cliente_tienda";
            this.id_cliente_tienda.ReadOnly = true;
            this.id_cliente_tienda.Visible = false;
            // 
            // cc_nit_cliente_tienda
            // 
            this.cc_nit_cliente_tienda.DataPropertyName = "cc_nit_cliente_tienda";
            this.cc_nit_cliente_tienda.HeaderText = "Cedula";
            this.cc_nit_cliente_tienda.Name = "cc_nit_cliente_tienda";
            this.cc_nit_cliente_tienda.ReadOnly = true;
            this.cc_nit_cliente_tienda.Visible = false;
            // 
            // nombre_cliente_tienda
            // 
            this.nombre_cliente_tienda.DataPropertyName = "nombre_cliente_tienda";
            this.nombre_cliente_tienda.HeaderText = "Nombre";
            this.nombre_cliente_tienda.Name = "nombre_cliente_tienda";
            this.nombre_cliente_tienda.ReadOnly = true;
            this.nombre_cliente_tienda.Width = 83;
            // 
            // telefono_cliente_tienda
            // 
            this.telefono_cliente_tienda.DataPropertyName = "telefono_cliente_tienda";
            this.telefono_cliente_tienda.HeaderText = "Teléfono";
            this.telefono_cliente_tienda.Name = "telefono_cliente_tienda";
            this.telefono_cliente_tienda.ReadOnly = true;
            this.telefono_cliente_tienda.Width = 88;
            // 
            // direccion_cleinte
            // 
            this.direccion_cleinte.DataPropertyName = "direccion_cleinte";
            this.direccion_cleinte.HeaderText = "Dirección";
            this.direccion_cleinte.Name = "direccion_cleinte";
            this.direccion_cleinte.ReadOnly = true;
            this.direccion_cleinte.Width = 93;
            // 
            // txtAccsesorios
            // 
            this.txtAccsesorios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccsesorios.Location = new System.Drawing.Point(443, 117);
            this.txtAccsesorios.Name = "txtAccsesorios";
            this.txtAccsesorios.Size = new System.Drawing.Size(439, 20);
            this.txtAccsesorios.TabIndex = 41;
            this.txtAccsesorios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccsesorios_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(443, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 18);
            this.label11.TabIndex = 40;
            this.label11.Text = "Accesorios *";
            // 
            // txtDescripcionServicio
            // 
            this.txtDescripcionServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcionServicio.Location = new System.Drawing.Point(15, 161);
            this.txtDescripcionServicio.Name = "txtDescripcionServicio";
            this.txtDescripcionServicio.Size = new System.Drawing.Size(867, 20);
            this.txtDescripcionServicio.TabIndex = 39;
            this.txtDescripcionServicio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcionServicio_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(12, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 18);
            this.label10.TabIndex = 38;
            this.label10.Text = "Descripción Servicio *";
            // 
            // txtObservicioIngreso
            // 
            this.txtObservicioIngreso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservicioIngreso.Location = new System.Drawing.Point(15, 117);
            this.txtObservicioIngreso.Name = "txtObservicioIngreso";
            this.txtObservicioIngreso.Size = new System.Drawing.Size(422, 20);
            this.txtObservicioIngreso.TabIndex = 37;
            this.txtObservicioIngreso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtObservicioIngreso_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(15, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 18);
            this.label9.TabIndex = 36;
            this.label9.Text = "Observación Ingreso *";
            // 
            // txtDireccionCliente
            // 
            this.txtDireccionCliente.Enabled = false;
            this.txtDireccionCliente.Location = new System.Drawing.Point(458, 24);
            this.txtDireccionCliente.Name = "txtDireccionCliente";
            this.txtDireccionCliente.Size = new System.Drawing.Size(269, 20);
            this.txtDireccionCliente.TabIndex = 35;
            this.txtDireccionCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDireccionCliente_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(458, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 18);
            this.label8.TabIndex = 34;
            this.label8.Text = "Dirección *";
            // 
            // txtTelefonoCliente
            // 
            this.txtTelefonoCliente.Enabled = false;
            this.txtTelefonoCliente.Location = new System.Drawing.Point(309, 24);
            this.txtTelefonoCliente.Name = "txtTelefonoCliente";
            this.txtTelefonoCliente.Size = new System.Drawing.Size(143, 20);
            this.txtTelefonoCliente.TabIndex = 33;
            this.txtTelefonoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTelefonoCliente_KeyDown);
            // 
            // btnCrearCliente
            // 
            this.btnCrearCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrearCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnCrearCliente.ForeColor = System.Drawing.Color.Black;
            this.btnCrearCliente.Location = new System.Drawing.Point(733, 9);
            this.btnCrearCliente.Name = "btnCrearCliente";
            this.btnCrearCliente.Size = new System.Drawing.Size(149, 35);
            this.btnCrearCliente.TabIndex = 33;
            this.btnCrearCliente.Text = "Crear Cliente";
            this.btnCrearCliente.UseVisualStyleBackColor = true;
            this.btnCrearCliente.Click += new System.EventHandler(this.btnCrearCliente_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(309, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 18);
            this.label7.TabIndex = 32;
            this.label7.Text = "Teléfono *";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreCliente.Location = new System.Drawing.Point(15, 24);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(288, 20);
            this.txtNombreCliente.TabIndex = 31;
            this.txtNombreCliente.TextChanged += new System.EventHandler(this.txtNombreCliente_TextChanged);
            this.txtNombreCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombreCliente_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 18);
            this.label6.TabIndex = 30;
            this.label6.Text = "Nombre Cliente *";
            // 
            // txtSerial
            // 
            this.txtSerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerial.Location = new System.Drawing.Point(726, 74);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(156, 20);
            this.txtSerial.TabIndex = 29;
            this.txtSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerial_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(726, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 18);
            this.label5.TabIndex = 28;
            this.label5.Text = "Serial *";
            // 
            // txtModelo
            // 
            this.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModelo.Location = new System.Drawing.Point(561, 74);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(156, 20);
            this.txtModelo.TabIndex = 27;
            this.txtModelo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtModelo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(561, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "Modelo *";
            // 
            // txtOtro
            // 
            this.txtOtro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOtro.Enabled = false;
            this.txtOtro.Location = new System.Drawing.Point(339, 74);
            this.txtOtro.Name = "txtOtro";
            this.txtOtro.Size = new System.Drawing.Size(215, 20);
            this.txtOtro.TabIndex = 25;
            this.txtOtro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOtro_KeyDown);
            // 
            // lavel
            // 
            this.lavel.AutoSize = true;
            this.lavel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lavel.ForeColor = System.Drawing.Color.Black;
            this.lavel.Location = new System.Drawing.Point(339, 53);
            this.lavel.Name = "lavel";
            this.lavel.Size = new System.Drawing.Size(128, 18);
            this.lavel.TabIndex = 24;
            this.lavel.Text = "Especifique Otro *";
            // 
            // cboArticulo
            // 
            this.cboArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArticulo.FormattingEnabled = true;
            this.cboArticulo.Location = new System.Drawing.Point(177, 73);
            this.cboArticulo.Name = "cboArticulo";
            this.cboArticulo.Size = new System.Drawing.Size(156, 21);
            this.cboArticulo.TabIndex = 23;
            this.cboArticulo.SelectedIndexChanged += new System.EventHandler(this.cboArticulo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(177, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "Articulo *";
            // 
            // cboServicio
            // 
            this.cboServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServicio.FormattingEnabled = true;
            this.cboServicio.Location = new System.Drawing.Point(15, 72);
            this.cboServicio.Name = "cboServicio";
            this.cboServicio.Size = new System.Drawing.Size(156, 21);
            this.cboServicio.TabIndex = 21;
            this.cboServicio.SelectedIndexChanged += new System.EventHandler(this.cboServicio_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "Servicio *";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Location = new System.Drawing.Point(912, 164);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(149, 35);
            this.btnEliminar.TabIndex = 20;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiar.Location = new System.Drawing.Point(916, 251);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(149, 35);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(916, 89);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(149, 35);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.panelTitulo.Controls.Add(this.btnMinimizar);
            this.panelTitulo.Controls.Add(this.label1);
            this.panelTitulo.Controls.Add(this.btnCerrar);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(1073, 23);
            this.panelTitulo.TabIndex = 30;
            this.panelTitulo.Visible = false;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Location = new System.Drawing.Point(1021, 1);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(23, 23);
            this.btnMinimizar.TabIndex = 28;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tipo Servicio";
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
            this.btnCerrar.Location = new System.Drawing.Point(1050, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(23, 23);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // btnCerrarOrden
            // 
            this.btnCerrarOrden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnCerrarOrden.ForeColor = System.Drawing.Color.Black;
            this.btnCerrarOrden.Location = new System.Drawing.Point(916, 355);
            this.btnCerrarOrden.Name = "btnCerrarOrden";
            this.btnCerrarOrden.Size = new System.Drawing.Size(149, 35);
            this.btnCerrarOrden.TabIndex = 34;
            this.btnCerrarOrden.Text = "Cerrar Orden";
            this.btnCerrarOrden.UseVisualStyleBackColor = true;
            this.btnCerrarOrden.Click += new System.EventHandler(this.btnCerrarOrden_Click);
            // 
            // texEstado
            // 
            this.texEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.texEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texEstado.ForeColor = System.Drawing.Color.Black;
            this.texEstado.Location = new System.Drawing.Point(913, 27);
            this.texEstado.Name = "texEstado";
            this.texEstado.Size = new System.Drawing.Size(148, 33);
            this.texEstado.TabIndex = 35;
            this.texEstado.Text = "Orden Activa";
            this.texEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(916, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 39);
            this.button1.TabIndex = 42;
            this.button1.Text = "Imprimir Orden";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmOrdenServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 509);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.texEstado);
            this.Controls.Add(this.btnCerrarOrden);
            this.Controls.Add(this.dgOrdenServicio);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.MinimumSize = new System.Drawing.Size(1034, 548);
            this.Name = "frmOrdenServicio";
            this.Text = "frmOrdenServicio";
            this.Load += new System.EventHandler(this.frmOrdenServicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrdenServicio)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgOrdenServicio;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboServicio;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox txtTelefonoCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOtro;
        private System.Windows.Forms.Label lavel;
        private System.Windows.Forms.ComboBox cboArticulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDireccionCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCrearCliente;
        private System.Windows.Forms.TextBox txtDescripcionServicio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCerrarOrden;
        private System.Windows.Forms.Label texEstado;
        private System.Windows.Forms.DataGridView dgClientes;
        private System.Windows.Forms.TextBox txtAccsesorios;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtObservicioIngreso;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_cliente_tienda;
        private System.Windows.Forms.DataGridViewTextBoxColumn cc_nit_cliente_tienda;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_cliente_tienda;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono_cliente_tienda;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion_cleinte;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_numeroOrdenServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_fechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_fechaEntregaOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_idCleinte;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_nombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_telefonoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_direccionCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_idServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_nombreServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_idArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_nombreArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_otro;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_modeloArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_serialArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_accesoriosArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_observiacioIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_descripcionServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoOrdenServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_usuarioIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_usuarioRetiro;
    }
}
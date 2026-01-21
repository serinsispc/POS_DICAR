namespace SERINSI_PC.Formularios.Inventario
{
    partial class frmProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduct));
            this.btnLimpiarFiltro = new System.Windows.Forms.Button();
            this.dgLista = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guidProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreTipoMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreEstadoAi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gramera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.cbEliminados = new System.Windows.Forms.CheckBox();
            this.btnNuevo = new FontAwesome.Sharp.IconButton();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.btnEditarProducto = new FontAwesome.Sharp.IconButton();
            this.btnEliminarProducto = new FontAwesome.Sharp.IconButton();
            this.btnInventarioProducto = new FontAwesome.Sharp.IconButton();
            this.btnEstadoProducto = new FontAwesome.Sharp.IconButton();
            this.btnCodigoProducto = new FontAwesome.Sharp.IconButton();
            this.btnListaPrecios = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgLista)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLimpiarFiltro
            // 
            this.btnLimpiarFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiarFiltro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiarFiltro.FlatAppearance.BorderSize = 0;
            this.btnLimpiarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltro.Location = new System.Drawing.Point(1175, 27);
            this.btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            this.btnLimpiarFiltro.Size = new System.Drawing.Size(70, 61);
            this.btnLimpiarFiltro.TabIndex = 33;
            this.btnLimpiarFiltro.UseVisualStyleBackColor = true;
            // 
            // dgLista
            // 
            this.dgLista.AllowUserToAddRows = false;
            this.dgLista.AllowUserToDeleteRows = false;
            this.dgLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgLista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.guidProducto,
            this.codigoProducto,
            this.descripcionProducto,
            this.idTipoMedida,
            this.nombreTipoMedida,
            this.idCategoria,
            this.nombreCategoria,
            this.idEstadoAI,
            this.nombreEstadoAi,
            this.idSede,
            this.gramera,
            this.eliminado});
            this.dgLista.Location = new System.Drawing.Point(12, 78);
            this.dgLista.Name = "dgLista";
            this.dgLista.ReadOnly = true;
            this.dgLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLista.Size = new System.Drawing.Size(701, 423);
            this.dgLista.TabIndex = 35;
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
            // idTipoMedida
            // 
            this.idTipoMedida.DataPropertyName = "idTipoMedida";
            this.idTipoMedida.HeaderText = "idTipoMedida";
            this.idTipoMedida.Name = "idTipoMedida";
            this.idTipoMedida.ReadOnly = true;
            this.idTipoMedida.Visible = false;
            this.idTipoMedida.Width = 130;
            // 
            // nombreTipoMedida
            // 
            this.nombreTipoMedida.DataPropertyName = "nombreTipoMedida";
            this.nombreTipoMedida.HeaderText = "Tipo Medida";
            this.nombreTipoMedida.Name = "nombreTipoMedida";
            this.nombreTipoMedida.ReadOnly = true;
            this.nombreTipoMedida.Width = 120;
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
            // nombreCategoria
            // 
            this.nombreCategoria.DataPropertyName = "nombreCategoria";
            this.nombreCategoria.HeaderText = "Categoria";
            this.nombreCategoria.Name = "nombreCategoria";
            this.nombreCategoria.ReadOnly = true;
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
            // nombreEstadoAi
            // 
            this.nombreEstadoAi.DataPropertyName = "nombreEstadoAi";
            this.nombreEstadoAi.HeaderText = "Estado";
            this.nombreEstadoAi.Name = "nombreEstadoAi";
            this.nombreEstadoAi.ReadOnly = true;
            this.nombreEstadoAi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nombreEstadoAi.Width = 81;
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
            // gramera
            // 
            this.gramera.DataPropertyName = "gramera";
            this.gramera.HeaderText = "gramera";
            this.gramera.Name = "gramera";
            this.gramera.ReadOnly = true;
            this.gramera.Visible = false;
            this.gramera.Width = 91;
            // 
            // eliminado
            // 
            this.eliminado.DataPropertyName = "eliminado";
            this.eliminado.HeaderText = "eliminado";
            this.eliminado.Name = "eliminado";
            this.eliminado.ReadOnly = true;
            this.eliminado.Visible = false;
            this.eliminado.Width = 101;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(16, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 18);
            this.label5.TabIndex = 19;
            this.label5.Text = "Codigo:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1164, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 40);
            this.label4.TabIndex = 26;
            this.label4.Text = "Eliminar Producto";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(12, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 18);
            this.label7.TabIndex = 22;
            this.label7.Text = "Descripción:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Location = new System.Drawing.Point(86, 26);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(172, 20);
            this.txtCodigo.TabIndex = 17;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1167, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 40);
            this.label3.TabIndex = 23;
            this.label3.Text = "Modificar Producto";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 23);
            this.panel1.TabIndex = 34;
            this.panel1.Visible = false;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Location = new System.Drawing.Point(848, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(23, 23);
            this.btnMinimizar.TabIndex = 27;
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
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Productos";
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
            this.btnCerrar.Location = new System.Drawing.Point(871, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(23, 23);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(122, 52);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(354, 20);
            this.txtDescripcion.TabIndex = 25;
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1164, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 40);
            this.label2.TabIndex = 20;
            this.label2.Text = "Crear Producto";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(358, 27);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(118, 21);
            this.cmbCategoria.TabIndex = 27;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(264, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 18);
            this.label6.TabIndex = 26;
            this.label6.Text = "Categoria:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.limpiar;
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(490, 27);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(52, 43);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.eliminarPNG;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(1175, 305);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(62, 59);
            this.btnEliminar.TabIndex = 24;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnCrear
            // 
            this.btnCrear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrear.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.agregarPNG;
            this.btnCrear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrear.FlatAppearance.BorderSize = 0;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Location = new System.Drawing.Point(1175, 95);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(62, 59);
            this.btnCrear.TabIndex = 18;
            this.btnCrear.UseVisualStyleBackColor = true;
            // 
            // cbEliminados
            // 
            this.cbEliminados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEliminados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEliminados.Location = new System.Drawing.Point(719, 286);
            this.cbEliminados.Name = "cbEliminados";
            this.cbEliminados.Size = new System.Drawing.Size(165, 53);
            this.cbEliminados.TabIndex = 49;
            this.cbEliminados.Text = "Filtrar Productos Eliminados";
            this.cbEliminados.UseVisualStyleBackColor = true;
            this.cbEliminados.CheckedChanged += new System.EventHandler(this.cbEliminados_CheckedChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            this.btnNuevo.IconColor = System.Drawing.Color.Black;
            this.btnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo.IconSize = 40;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(717, 31);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnNuevo.Size = new System.Drawing.Size(165, 45);
            this.btnNuevo.TabIndex = 50;
            this.btnNuevo.Text = " Nuevo Producto";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir.IconColor = System.Drawing.Color.Black;
            this.btnImprimir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir.IconSize = 40;
            this.btnImprimir.Location = new System.Drawing.Point(550, 31);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(163, 45);
            this.btnImprimir.TabIndex = 51;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnEditarProducto
            // 
            this.btnEditarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarProducto.IconChar = FontAwesome.Sharp.IconChar.FileEdit;
            this.btnEditarProducto.IconColor = System.Drawing.Color.Black;
            this.btnEditarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditarProducto.IconSize = 40;
            this.btnEditarProducto.Location = new System.Drawing.Point(717, 82);
            this.btnEditarProducto.Name = "btnEditarProducto";
            this.btnEditarProducto.Size = new System.Drawing.Size(165, 45);
            this.btnEditarProducto.TabIndex = 52;
            this.btnEditarProducto.Text = "Editar Producto";
            this.btnEditarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditarProducto.UseVisualStyleBackColor = true;
            this.btnEditarProducto.Click += new System.EventHandler(this.btnEditarProducto_Click);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarProducto.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminarProducto.IconColor = System.Drawing.Color.Black;
            this.btnEliminarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminarProducto.IconSize = 40;
            this.btnEliminarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarProducto.Location = new System.Drawing.Point(717, 235);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(165, 45);
            this.btnEliminarProducto.TabIndex = 53;
            this.btnEliminarProducto.Text = "Eliminar";
            this.btnEliminarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnInventarioProducto
            // 
            this.btnInventarioProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInventarioProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventarioProducto.IconChar = FontAwesome.Sharp.IconChar.BoxesAlt;
            this.btnInventarioProducto.IconColor = System.Drawing.Color.Black;
            this.btnInventarioProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInventarioProducto.IconSize = 40;
            this.btnInventarioProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventarioProducto.Location = new System.Drawing.Point(717, 133);
            this.btnInventarioProducto.Name = "btnInventarioProducto";
            this.btnInventarioProducto.Size = new System.Drawing.Size(165, 45);
            this.btnInventarioProducto.TabIndex = 54;
            this.btnInventarioProducto.Text = "Inventario";
            this.btnInventarioProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInventarioProducto.UseVisualStyleBackColor = true;
            this.btnInventarioProducto.Click += new System.EventHandler(this.btnInventarioProducto_Click);
            // 
            // btnEstadoProducto
            // 
            this.btnEstadoProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEstadoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadoProducto.IconChar = FontAwesome.Sharp.IconChar.ToggleOff;
            this.btnEstadoProducto.IconColor = System.Drawing.Color.Black;
            this.btnEstadoProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEstadoProducto.IconSize = 40;
            this.btnEstadoProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstadoProducto.Location = new System.Drawing.Point(717, 184);
            this.btnEstadoProducto.Name = "btnEstadoProducto";
            this.btnEstadoProducto.Size = new System.Drawing.Size(165, 45);
            this.btnEstadoProducto.TabIndex = 55;
            this.btnEstadoProducto.Text = "Estado";
            this.btnEstadoProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEstadoProducto.UseVisualStyleBackColor = true;
            this.btnEstadoProducto.Click += new System.EventHandler(this.btnEstadoProducto_Click);
            // 
            // btnCodigoProducto
            // 
            this.btnCodigoProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCodigoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCodigoProducto.IconChar = FontAwesome.Sharp.IconChar.Barcode;
            this.btnCodigoProducto.IconColor = System.Drawing.Color.Black;
            this.btnCodigoProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCodigoProducto.IconSize = 40;
            this.btnCodigoProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCodigoProducto.Location = new System.Drawing.Point(719, 345);
            this.btnCodigoProducto.Name = "btnCodigoProducto";
            this.btnCodigoProducto.Size = new System.Drawing.Size(165, 45);
            this.btnCodigoProducto.TabIndex = 56;
            this.btnCodigoProducto.Text = "Códogo";
            this.btnCodigoProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCodigoProducto.UseVisualStyleBackColor = true;
            this.btnCodigoProducto.Click += new System.EventHandler(this.btnCodigoProducto_Click);
            // 
            // btnListaPrecios
            // 
            this.btnListaPrecios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListaPrecios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaPrecios.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnListaPrecios.IconColor = System.Drawing.Color.Black;
            this.btnListaPrecios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnListaPrecios.IconSize = 40;
            this.btnListaPrecios.Location = new System.Drawing.Point(721, 396);
            this.btnListaPrecios.Name = "btnListaPrecios";
            this.btnListaPrecios.Size = new System.Drawing.Size(163, 45);
            this.btnListaPrecios.TabIndex = 57;
            this.btnListaPrecios.Text = "Lista de Precios";
            this.btnListaPrecios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnListaPrecios.UseVisualStyleBackColor = true;
            this.btnListaPrecios.Click += new System.EventHandler(this.btnListaPrecios_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 40;
            this.iconButton1.Location = new System.Drawing.Point(721, 447);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(163, 45);
            this.iconButton1.TabIndex = 58;
            this.iconButton1.Text = "Costo Inventario";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 510);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.btnListaPrecios);
            this.Controls.Add(this.btnCodigoProducto);
            this.Controls.Add(this.btnEstadoProducto);
            this.Controls.Add(this.btnInventarioProducto);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.btnEditarProducto);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.cbEliminados);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLimpiarFiltro);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgLista);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmProduct";
            this.Text = "frmProduct";
            this.Load += new System.EventHandler(this.frmProduct_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProduct_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgLista)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiarFiltro;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLimpiar;
        public System.Windows.Forms.DataGridView dgLista;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbEliminados;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn guidProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreTipoMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreEstadoAi;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSede;
        private System.Windows.Forms.DataGridViewTextBoxColumn gramera;
        private System.Windows.Forms.DataGridViewTextBoxColumn eliminado;
        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private FontAwesome.Sharp.IconButton btnEditarProducto;
        private FontAwesome.Sharp.IconButton btnEliminarProducto;
        private FontAwesome.Sharp.IconButton btnInventarioProducto;
        private FontAwesome.Sharp.IconButton btnEstadoProducto;
        private FontAwesome.Sharp.IconButton btnCodigoProducto;
        private FontAwesome.Sharp.IconButton btnListaPrecios;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}
namespace SERINSI_PC.Formularios.Fabrica
{
    partial class frmFabrica
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFabrica));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label13 = new System.Windows.Forms.Label();
            this.dgOrdenes = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescripcionOrden = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnListaInsumos = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminarOrden = new System.Windows.Forms.Button();
            this.btnEditarOrden = new System.Windows.Forms.Button();
            this.btnCrearOrden = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroOrdenFabrica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaInicioOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaEntregaIrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diasOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionProductoOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoOrdenInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoOrdenManoObra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalConstoOren = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorFinalOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsableOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoOrdenFabricacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(726, 448);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 40);
            this.label13.TabIndex = 58;
            this.label13.Text = "Lista Insumos";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgOrdenes
            // 
            this.dgOrdenes.AllowUserToAddRows = false;
            this.dgOrdenes.AllowUserToDeleteRows = false;
            this.dgOrdenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgOrdenes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrdenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.numeroOrdenFabrica,
            this.fechaInicioOrden,
            this.fechaEntregaIrden,
            this.diasOrden,
            this.descripcionProductoOrden,
            this.costoOrdenInsumo,
            this.costoOrdenManoObra,
            this.totalConstoOren,
            this.ValorFinalOrden,
            this.Producido,
            this.clienteOrden,
            this.responsableOrden,
            this.estadoOrdenFabricacion});
            this.dgOrdenes.Location = new System.Drawing.Point(12, 30);
            this.dgOrdenes.Name = "dgOrdenes";
            this.dgOrdenes.ReadOnly = true;
            this.dgOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOrdenes.Size = new System.Drawing.Size(708, 458);
            this.dgOrdenes.TabIndex = 56;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(726, 343);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 40);
            this.label12.TabIndex = 44;
            this.label12.Text = "Eliminar Orden";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 18);
            this.label7.TabIndex = 48;
            this.label7.Text = "Descripción:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(729, 238);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 40);
            this.label11.TabIndex = 42;
            this.label11.Text = "Modificar Orden";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDescripcionOrden
            // 
            this.txtDescripcionOrden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcionOrden.Location = new System.Drawing.Point(122, 8);
            this.txtDescripcionOrden.Name = "txtDescripcionOrden";
            this.txtDescripcionOrden.Size = new System.Drawing.Size(598, 20);
            this.txtDescripcionOrden.TabIndex = 49;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(726, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 40);
            this.label10.TabIndex = 40;
            this.label10.Text = "Crear Orden";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnListaInsumos
            // 
            this.btnListaInsumos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListaInsumos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnListaInsumos.BackgroundImage")));
            this.btnListaInsumos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnListaInsumos.FlatAppearance.BorderSize = 0;
            this.btnListaInsumos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListaInsumos.Location = new System.Drawing.Point(737, 386);
            this.btnListaInsumos.Name = "btnListaInsumos";
            this.btnListaInsumos.Size = new System.Drawing.Size(62, 59);
            this.btnListaInsumos.TabIndex = 57;
            this.btnListaInsumos.UseVisualStyleBackColor = true;
            this.btnListaInsumos.Click += new System.EventHandler(this.btnListaInsumos_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(732, 7);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(70, 56);
            this.btnLimpiar.TabIndex = 45;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnEliminarOrden
            // 
            this.btnEliminarOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarOrden.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarOrden.BackgroundImage")));
            this.btnEliminarOrden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarOrden.FlatAppearance.BorderSize = 0;
            this.btnEliminarOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarOrden.Location = new System.Drawing.Point(737, 281);
            this.btnEliminarOrden.Name = "btnEliminarOrden";
            this.btnEliminarOrden.Size = new System.Drawing.Size(62, 59);
            this.btnEliminarOrden.TabIndex = 43;
            this.btnEliminarOrden.UseVisualStyleBackColor = true;
            this.btnEliminarOrden.Click += new System.EventHandler(this.btnEliminarOrden_Click);
            // 
            // btnEditarOrden
            // 
            this.btnEditarOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarOrden.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarOrden.BackgroundImage")));
            this.btnEditarOrden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditarOrden.FlatAppearance.BorderSize = 0;
            this.btnEditarOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarOrden.Location = new System.Drawing.Point(737, 176);
            this.btnEditarOrden.Name = "btnEditarOrden";
            this.btnEditarOrden.Size = new System.Drawing.Size(62, 59);
            this.btnEditarOrden.TabIndex = 41;
            this.btnEditarOrden.UseVisualStyleBackColor = true;
            this.btnEditarOrden.Click += new System.EventHandler(this.btnEditarOrden_Click);
            // 
            // btnCrearOrden
            // 
            this.btnCrearOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrearOrden.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCrearOrden.BackgroundImage")));
            this.btnCrearOrden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrearOrden.FlatAppearance.BorderSize = 0;
            this.btnCrearOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearOrden.Location = new System.Drawing.Point(732, 71);
            this.btnCrearOrden.Name = "btnCrearOrden";
            this.btnCrearOrden.Size = new System.Drawing.Size(62, 59);
            this.btnCrearOrden.TabIndex = 39;
            this.btnCrearOrden.Click += new System.EventHandler(this.btnCrearOrden_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.id.Visible = false;
            this.id.Width = 46;
            // 
            // numeroOrdenFabrica
            // 
            this.numeroOrdenFabrica.DataPropertyName = "numeroOrdenFabrica";
            this.numeroOrdenFabrica.HeaderText = "Orden";
            this.numeroOrdenFabrica.Name = "numeroOrdenFabrica";
            this.numeroOrdenFabrica.ReadOnly = true;
            this.numeroOrdenFabrica.Width = 75;
            // 
            // fechaInicioOrden
            // 
            this.fechaInicioOrden.DataPropertyName = "fechaInicioOrden";
            this.fechaInicioOrden.HeaderText = "Inicio";
            this.fechaInicioOrden.Name = "fechaInicioOrden";
            this.fechaInicioOrden.ReadOnly = true;
            this.fechaInicioOrden.Width = 70;
            // 
            // fechaEntregaIrden
            // 
            this.fechaEntregaIrden.DataPropertyName = "fechaEntregaIrden";
            this.fechaEntregaIrden.HeaderText = "Entrega";
            this.fechaEntregaIrden.Name = "fechaEntregaIrden";
            this.fechaEntregaIrden.ReadOnly = true;
            this.fechaEntregaIrden.Width = 87;
            // 
            // diasOrden
            // 
            this.diasOrden.DataPropertyName = "diasOrden";
            this.diasOrden.HeaderText = "Días";
            this.diasOrden.Name = "diasOrden";
            this.diasOrden.ReadOnly = true;
            this.diasOrden.Width = 65;
            // 
            // descripcionProductoOrden
            // 
            this.descripcionProductoOrden.DataPropertyName = "descripcionProductoOrden";
            this.descripcionProductoOrden.HeaderText = "Descripción";
            this.descripcionProductoOrden.Name = "descripcionProductoOrden";
            this.descripcionProductoOrden.ReadOnly = true;
            this.descripcionProductoOrden.Width = 116;
            // 
            // costoOrdenInsumo
            // 
            this.costoOrdenInsumo.DataPropertyName = "costoOrdenInsumo";
            dataGridViewCellStyle8.Format = "c0";
            this.costoOrdenInsumo.DefaultCellStyle = dataGridViewCellStyle8;
            this.costoOrdenInsumo.HeaderText = "Costo Insumo";
            this.costoOrdenInsumo.Name = "costoOrdenInsumo";
            this.costoOrdenInsumo.ReadOnly = true;
            this.costoOrdenInsumo.Width = 115;
            // 
            // costoOrdenManoObra
            // 
            this.costoOrdenManoObra.DataPropertyName = "costoOrdenManoObra";
            dataGridViewCellStyle9.Format = "c0";
            this.costoOrdenManoObra.DefaultCellStyle = dataGridViewCellStyle9;
            this.costoOrdenManoObra.HeaderText = "Mano de Obra";
            this.costoOrdenManoObra.Name = "costoOrdenManoObra";
            this.costoOrdenManoObra.ReadOnly = true;
            this.costoOrdenManoObra.Width = 89;
            // 
            // totalConstoOren
            // 
            this.totalConstoOren.DataPropertyName = "totalConstoOren";
            dataGridViewCellStyle10.Format = "c0";
            this.totalConstoOren.DefaultCellStyle = dataGridViewCellStyle10;
            this.totalConstoOren.HeaderText = "Consto Orden";
            this.totalConstoOren.Name = "totalConstoOren";
            this.totalConstoOren.ReadOnly = true;
            this.totalConstoOren.Width = 116;
            // 
            // ValorFinalOrden
            // 
            this.ValorFinalOrden.DataPropertyName = "ValorFinalOrden";
            dataGridViewCellStyle11.Format = "c0";
            this.ValorFinalOrden.DefaultCellStyle = dataGridViewCellStyle11;
            this.ValorFinalOrden.HeaderText = "Valor Producto";
            this.ValorFinalOrden.Name = "ValorFinalOrden";
            this.ValorFinalOrden.ReadOnly = true;
            this.ValorFinalOrden.Width = 124;
            // 
            // Producido
            // 
            this.Producido.DataPropertyName = "Producido";
            dataGridViewCellStyle12.Format = "c0";
            this.Producido.DefaultCellStyle = dataGridViewCellStyle12;
            this.Producido.HeaderText = "Producido";
            this.Producido.Name = "Producido";
            this.Producido.ReadOnly = true;
            this.Producido.Width = 104;
            // 
            // clienteOrden
            // 
            this.clienteOrden.DataPropertyName = "clienteOrden";
            this.clienteOrden.HeaderText = "Cliente";
            this.clienteOrden.Name = "clienteOrden";
            this.clienteOrden.ReadOnly = true;
            this.clienteOrden.Width = 81;
            // 
            // responsableOrden
            // 
            this.responsableOrden.DataPropertyName = "responsableOrden";
            this.responsableOrden.HeaderText = "Responsable";
            this.responsableOrden.Name = "responsableOrden";
            this.responsableOrden.ReadOnly = true;
            this.responsableOrden.Width = 126;
            // 
            // estadoOrdenFabricacion
            // 
            this.estadoOrdenFabricacion.DataPropertyName = "estadoOrdenFabricacion";
            this.estadoOrdenFabricacion.HeaderText = "Estado";
            this.estadoOrdenFabricacion.Name = "estadoOrdenFabricacion";
            this.estadoOrdenFabricacion.ReadOnly = true;
            this.estadoOrdenFabricacion.Width = 82;
            // 
            // frmFabrica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 492);
            this.Controls.Add(this.btnListaInsumos);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminarOrden);
            this.Controls.Add(this.dgOrdenes);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnEditarOrden);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCrearOrden);
            this.Controls.Add(this.txtDescripcionOrden);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(833, 531);
            this.Name = "frmFabrica";
            this.Text = "frmFabrica";
            this.Load += new System.EventHandler(this.frmFabrica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrdenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminarOrden;
        public System.Windows.Forms.DataGridView dgOrdenes;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnEditarOrden;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCrearOrden;
        private System.Windows.Forms.TextBox txtDescripcionOrden;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnListaInsumos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroOrdenFabrica;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicioOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEntregaIrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn diasOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionProductoOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoOrdenInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoOrdenManoObra;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalConstoOren;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorFinalOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producido;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsableOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoOrdenFabricacion;
    }
}
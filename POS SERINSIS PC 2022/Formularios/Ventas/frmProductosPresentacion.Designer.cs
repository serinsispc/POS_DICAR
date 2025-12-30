namespace SERINSI_PC.Formularios.Ventas
{
    partial class frmProductosPresentacion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.tituloFormulario = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgProductosPresentacion = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCostoPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreSede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guidProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrePresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.letraTipoMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreLista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idListaPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventarioActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gramera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductosPresentacion)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.tituloFormulario);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 23);
            this.panel1.TabIndex = 36;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Location = new System.Drawing.Point(516, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(23, 23);
            this.btnMinimizar.TabIndex = 27;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            // 
            // tituloFormulario
            // 
            this.tituloFormulario.AutoSize = true;
            this.tituloFormulario.Dock = System.Windows.Forms.DockStyle.Left;
            this.tituloFormulario.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
            this.tituloFormulario.ForeColor = System.Drawing.Color.White;
            this.tituloFormulario.Location = new System.Drawing.Point(0, 0);
            this.tituloFormulario.Name = "tituloFormulario";
            this.tituloFormulario.Size = new System.Drawing.Size(24, 18);
            this.tituloFormulario.TabIndex = 11;
            this.tituloFormulario.Text = "--";
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
            this.btnCerrar.Location = new System.Drawing.Point(539, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(23, 23);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgProductosPresentacion
            // 
            this.dgProductosPresentacion.AllowUserToAddRows = false;
            this.dgProductosPresentacion.AllowUserToDeleteRows = false;
            this.dgProductosPresentacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgProductosPresentacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgProductosPresentacion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProductosPresentacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProductosPresentacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductosPresentacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idSede,
            this.idTipoMedida,
            this.idCategoria,
            this.idInventario,
            this.idCostoPrecio,
            this.nombreSede,
            this.nombreCategoria,
            this.guidProducto,
            this.nombrePresentacion,
            this.codigoProducto,
            this.descripcionProducto,
            this.letraTipoMedida,
            this.costo,
            this.porcentajeIva,
            this.nombreLista,
            this.idListaPrecio,
            this.precio,
            this.inventarioActual,
            this.gramera});
            this.dgProductosPresentacion.Location = new System.Drawing.Point(12, 29);
            this.dgProductosPresentacion.Name = "dgProductosPresentacion";
            this.dgProductosPresentacion.ReadOnly = true;
            this.dgProductosPresentacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProductosPresentacion.Size = new System.Drawing.Size(538, 301);
            this.dgProductosPresentacion.TabIndex = 37;
            this.dgProductosPresentacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProductosPresentacion_CellClick);
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
            // idSede
            // 
            this.idSede.DataPropertyName = "idSede";
            this.idSede.HeaderText = "idSede";
            this.idSede.Name = "idSede";
            this.idSede.ReadOnly = true;
            this.idSede.Visible = false;
            this.idSede.Width = 84;
            // 
            // idTipoMedida
            // 
            this.idTipoMedida.DataPropertyName = "idTipoMedida";
            this.idTipoMedida.HeaderText = "idTipoMedida";
            this.idTipoMedida.Name = "idTipoMedida";
            this.idTipoMedida.ReadOnly = true;
            this.idTipoMedida.Visible = false;
            this.idTipoMedida.Width = 133;
            // 
            // idCategoria
            // 
            this.idCategoria.DataPropertyName = "idCategoria";
            this.idCategoria.HeaderText = "idCategoria";
            this.idCategoria.Name = "idCategoria";
            this.idCategoria.ReadOnly = true;
            this.idCategoria.Visible = false;
            this.idCategoria.Width = 119;
            // 
            // idInventario
            // 
            this.idInventario.DataPropertyName = "idInventario";
            this.idInventario.HeaderText = "idInventario";
            this.idInventario.Name = "idInventario";
            this.idInventario.ReadOnly = true;
            this.idInventario.Visible = false;
            this.idInventario.Width = 119;
            // 
            // idCostoPrecio
            // 
            this.idCostoPrecio.DataPropertyName = "idCostoPrecio";
            this.idCostoPrecio.HeaderText = "idCostoPrecio";
            this.idCostoPrecio.Name = "idCostoPrecio";
            this.idCostoPrecio.ReadOnly = true;
            this.idCostoPrecio.Visible = false;
            this.idCostoPrecio.Width = 141;
            // 
            // nombreSede
            // 
            this.nombreSede.DataPropertyName = "nombreSede";
            this.nombreSede.HeaderText = "Sede";
            this.nombreSede.Name = "nombreSede";
            this.nombreSede.ReadOnly = true;
            this.nombreSede.Visible = false;
            this.nombreSede.Width = 71;
            // 
            // nombreCategoria
            // 
            this.nombreCategoria.DataPropertyName = "nombreCategoria";
            this.nombreCategoria.HeaderText = "Categoria";
            this.nombreCategoria.Name = "nombreCategoria";
            this.nombreCategoria.ReadOnly = true;
            this.nombreCategoria.Visible = false;
            this.nombreCategoria.Width = 106;
            // 
            // guidProducto
            // 
            this.guidProducto.DataPropertyName = "guidProducto";
            this.guidProducto.HeaderText = "guidProducto";
            this.guidProducto.Name = "guidProducto";
            this.guidProducto.ReadOnly = true;
            this.guidProducto.Visible = false;
            this.guidProducto.Width = 133;
            // 
            // nombrePresentacion
            // 
            this.nombrePresentacion.DataPropertyName = "nombrePresentacion";
            this.nombrePresentacion.HeaderText = "Presentacion";
            this.nombrePresentacion.Name = "nombrePresentacion";
            this.nombrePresentacion.ReadOnly = true;
            this.nombrePresentacion.Width = 132;
            // 
            // codigoProducto
            // 
            this.codigoProducto.DataPropertyName = "codigoProducto";
            this.codigoProducto.HeaderText = "Código";
            this.codigoProducto.Name = "codigoProducto";
            this.codigoProducto.ReadOnly = true;
            this.codigoProducto.Visible = false;
            this.codigoProducto.Width = 87;
            // 
            // descripcionProducto
            // 
            this.descripcionProducto.DataPropertyName = "descripcionProducto";
            this.descripcionProducto.HeaderText = "Producto";
            this.descripcionProducto.Name = "descripcionProducto";
            this.descripcionProducto.ReadOnly = true;
            this.descripcionProducto.Width = 102;
            // 
            // letraTipoMedida
            // 
            this.letraTipoMedida.DataPropertyName = "letraTipoMedida";
            this.letraTipoMedida.HeaderText = "Medida";
            this.letraTipoMedida.Name = "letraTipoMedida";
            this.letraTipoMedida.ReadOnly = true;
            this.letraTipoMedida.Width = 87;
            // 
            // costo
            // 
            this.costo.DataPropertyName = "costo";
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            this.costo.Visible = false;
            this.costo.Width = 79;
            // 
            // porcentajeIva
            // 
            this.porcentajeIva.DataPropertyName = "porcentajeIva";
            this.porcentajeIva.HeaderText = "Iva";
            this.porcentajeIva.Name = "porcentajeIva";
            this.porcentajeIva.ReadOnly = true;
            this.porcentajeIva.Visible = false;
            this.porcentajeIva.Width = 54;
            // 
            // nombreLista
            // 
            this.nombreLista.DataPropertyName = "nombreLista";
            this.nombreLista.HeaderText = "Lista Precio";
            this.nombreLista.Name = "nombreLista";
            this.nombreLista.ReadOnly = true;
            this.nombreLista.Width = 123;
            // 
            // idListaPrecio
            // 
            this.idListaPrecio.DataPropertyName = "idListaPrecio";
            this.idListaPrecio.HeaderText = "idListaPrecio";
            this.idListaPrecio.Name = "idListaPrecio";
            this.idListaPrecio.ReadOnly = true;
            this.idListaPrecio.Visible = false;
            this.idListaPrecio.Width = 131;
            // 
            // precio
            // 
            this.precio.DataPropertyName = "precio";
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Width = 82;
            // 
            // inventarioActual
            // 
            this.inventarioActual.DataPropertyName = "inventarioActual";
            this.inventarioActual.HeaderText = "Cantidad";
            this.inventarioActual.Name = "inventarioActual";
            this.inventarioActual.ReadOnly = true;
            this.inventarioActual.Width = 99;
            // 
            // gramera
            // 
            this.gramera.DataPropertyName = "gramera";
            this.gramera.HeaderText = "gramera";
            this.gramera.Name = "gramera";
            this.gramera.ReadOnly = true;
            this.gramera.Visible = false;
            this.gramera.Width = 95;
            // 
            // frmProductosPresentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 342);
            this.Controls.Add(this.dgProductosPresentacion);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProductosPresentacion";
            this.Text = "frmProductosPresentacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProductosPresentacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductosPresentacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMinimizar;
        public System.Windows.Forms.Label tituloFormulario;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgProductosPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSede;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCostoPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreSede;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn guidProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrePresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn letraTipoMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn idListaPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventarioActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn gramera;
    }
}
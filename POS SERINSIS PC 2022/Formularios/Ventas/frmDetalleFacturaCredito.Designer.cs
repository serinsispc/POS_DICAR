namespace SERINSI_PC.Formularios.Ventas
{
    partial class frmDetalleFacturaCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleFacturaCredito));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgDetalleVenta = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPrecios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrePresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDetalleVentaV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInventarioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contenidoPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRestar = new System.Windows.Forms.Button();
            this.btnSumar = new System.Windows.Forms.Button();
            this.texCantidad = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAnular = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 23);
            this.panel1.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(144, 18);
            this.label15.TabIndex = 11;
            this.label15.Text = "Detalle Productos";
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
            this.btnCerrar.Location = new System.Drawing.Point(581, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(23, 23);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgDetalleVenta
            // 
            this.dgDetalleVenta.AllowUserToAddRows = false;
            this.dgDetalleVenta.AllowUserToDeleteRows = false;
            this.dgDetalleVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDetalleVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgDetalleVenta.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDetalleVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetalleVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idVenta,
            this.idPrecios,
            this.idInventario,
            this.idSede,
            this.descripcionProducto,
            this.nombrePresentacion,
            this.cantidadDetalle,
            this.costoUnidad,
            this.costoTotal,
            this.precioDetalleVentaV,
            this.totalDetalle,
            this.idInventarioTotal,
            this.contenidoPresentacion});
            this.dgDetalleVenta.Location = new System.Drawing.Point(12, 29);
            this.dgDetalleVenta.Name = "dgDetalleVenta";
            this.dgDetalleVenta.ReadOnly = true;
            this.dgDetalleVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDetalleVenta.Size = new System.Drawing.Size(506, 362);
            this.dgDetalleVenta.TabIndex = 24;
            this.dgDetalleVenta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetalleVenta_CellClick);
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
            // idVenta
            // 
            this.idVenta.DataPropertyName = "idVenta";
            this.idVenta.HeaderText = "idVenta";
            this.idVenta.Name = "idVenta";
            this.idVenta.ReadOnly = true;
            this.idVenta.Visible = false;
            this.idVenta.Width = 80;
            // 
            // idPrecios
            // 
            this.idPrecios.DataPropertyName = "idPrecios";
            this.idPrecios.HeaderText = "idPrecios";
            this.idPrecios.Name = "idPrecios";
            this.idPrecios.ReadOnly = true;
            this.idPrecios.Visible = false;
            this.idPrecios.Width = 92;
            // 
            // idInventario
            // 
            this.idInventario.DataPropertyName = "idInventario";
            this.idInventario.HeaderText = "idInventario";
            this.idInventario.Name = "idInventario";
            this.idInventario.ReadOnly = true;
            this.idInventario.Visible = false;
            this.idInventario.Width = 107;
            // 
            // idSede
            // 
            this.idSede.DataPropertyName = "idSede";
            this.idSede.HeaderText = "idSede";
            this.idSede.Name = "idSede";
            this.idSede.ReadOnly = true;
            this.idSede.Visible = false;
            this.idSede.Width = 77;
            // 
            // descripcionProducto
            // 
            this.descripcionProducto.DataPropertyName = "descripcionProducto";
            this.descripcionProducto.HeaderText = "Producto";
            this.descripcionProducto.Name = "descripcionProducto";
            this.descripcionProducto.ReadOnly = true;
            this.descripcionProducto.Width = 89;
            // 
            // nombrePresentacion
            // 
            this.nombrePresentacion.DataPropertyName = "nombrePresentacion";
            this.nombrePresentacion.HeaderText = "Presentación";
            this.nombrePresentacion.Name = "nombrePresentacion";
            this.nombrePresentacion.ReadOnly = true;
            this.nombrePresentacion.Width = 116;
            // 
            // cantidadDetalle
            // 
            this.cantidadDetalle.DataPropertyName = "cantidadDetalle";
            this.cantidadDetalle.HeaderText = "Cantidad";
            this.cantidadDetalle.Name = "cantidadDetalle";
            this.cantidadDetalle.ReadOnly = true;
            this.cantidadDetalle.Width = 89;
            // 
            // costoUnidad
            // 
            this.costoUnidad.DataPropertyName = "costoUnidad";
            this.costoUnidad.HeaderText = "costoUnidad";
            this.costoUnidad.Name = "costoUnidad";
            this.costoUnidad.ReadOnly = true;
            this.costoUnidad.Visible = false;
            this.costoUnidad.Width = 112;
            // 
            // costoTotal
            // 
            this.costoTotal.DataPropertyName = "costoTotal";
            this.costoTotal.HeaderText = "costoTotal";
            this.costoTotal.Name = "costoTotal";
            this.costoTotal.ReadOnly = true;
            this.costoTotal.Visible = false;
            this.costoTotal.Width = 98;
            // 
            // precioDetalleVentaV
            // 
            this.precioDetalleVentaV.DataPropertyName = "precioDetalleVentaV";
            dataGridViewCellStyle2.Format = "C0";
            this.precioDetalleVentaV.DefaultCellStyle = dataGridViewCellStyle2;
            this.precioDetalleVentaV.HeaderText = "Precio";
            this.precioDetalleVentaV.Name = "precioDetalleVentaV";
            this.precioDetalleVentaV.ReadOnly = true;
            this.precioDetalleVentaV.Width = 73;
            // 
            // totalDetalle
            // 
            this.totalDetalle.DataPropertyName = "totalDetalle";
            dataGridViewCellStyle3.Format = "C0";
            dataGridViewCellStyle3.NullValue = null;
            this.totalDetalle.DefaultCellStyle = dataGridViewCellStyle3;
            this.totalDetalle.HeaderText = "Total";
            this.totalDetalle.Name = "totalDetalle";
            this.totalDetalle.ReadOnly = true;
            this.totalDetalle.Width = 64;
            // 
            // idInventarioTotal
            // 
            this.idInventarioTotal.DataPropertyName = "idInventarioTotal";
            this.idInventarioTotal.HeaderText = "idInventarioTotal";
            this.idInventarioTotal.Name = "idInventarioTotal";
            this.idInventarioTotal.ReadOnly = true;
            this.idInventarioTotal.Visible = false;
            this.idInventarioTotal.Width = 139;
            // 
            // contenidoPresentacion
            // 
            this.contenidoPresentacion.DataPropertyName = "contenidoPresentacion";
            this.contenidoPresentacion.HeaderText = "contenidoPresentacion";
            this.contenidoPresentacion.Name = "contenidoPresentacion";
            this.contenidoPresentacion.ReadOnly = true;
            this.contenidoPresentacion.Visible = false;
            this.contenidoPresentacion.Width = 179;
            // 
            // btnRestar
            // 
            this.btnRestar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestar.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_menos_100;
            this.btnRestar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRestar.FlatAppearance.BorderSize = 0;
            this.btnRestar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestar.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestar.Location = new System.Drawing.Point(534, 99);
            this.btnRestar.Name = "btnRestar";
            this.btnRestar.Size = new System.Drawing.Size(46, 38);
            this.btnRestar.TabIndex = 73;
            this.btnRestar.UseVisualStyleBackColor = true;
            this.btnRestar.Click += new System.EventHandler(this.btnRestar_Click);
            // 
            // btnSumar
            // 
            this.btnSumar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSumar.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_añadir_100;
            this.btnSumar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSumar.FlatAppearance.BorderSize = 0;
            this.btnSumar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSumar.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSumar.Location = new System.Drawing.Point(534, 33);
            this.btnSumar.Name = "btnSumar";
            this.btnSumar.Size = new System.Drawing.Size(46, 38);
            this.btnSumar.TabIndex = 72;
            this.btnSumar.UseVisualStyleBackColor = true;
            this.btnSumar.Click += new System.EventHandler(this.btnSumar_Click);
            // 
            // texCantidad
            // 
            this.texCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.texCantidad.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texCantidad.Location = new System.Drawing.Point(524, 74);
            this.texCantidad.Name = "texCantidad";
            this.texCantidad.Size = new System.Drawing.Size(66, 22);
            this.texCantidad.TabIndex = 71;
            this.texCantidad.Text = "0";
            this.texCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(523, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 34);
            this.label4.TabIndex = 70;
            this.label4.Text = "Retornar Producto";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAnular
            // 
            this.btnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnular.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_actualizar_100;
            this.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnular.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.Location = new System.Drawing.Point(524, 143);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(66, 50);
            this.btnAnular.TabIndex = 69;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // frmDetalleFacturaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 403);
            this.Controls.Add(this.btnRestar);
            this.Controls.Add(this.dgDetalleVenta);
            this.Controls.Add(this.btnSumar);
            this.Controls.Add(this.texCantidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAnular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDetalleFacturaCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDetalleFacturaCredito";
            this.Load += new System.EventHandler(this.frmDetalleFacturaCredito_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleVenta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgDetalleVenta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Label texCantidad;
        private System.Windows.Forms.Button btnRestar;
        private System.Windows.Forms.Button btnSumar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPrecios;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSede;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrePresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDetalleVentaV;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInventarioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn contenidoPresentacion;
    }
}
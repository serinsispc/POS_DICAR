namespace SERINSI_PC.Formularios.Contabilidad
{
    partial class frmVerDetalleCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerDetalleCompra));
            this.dgDetalleCompra = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInventarioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrePresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contenidoPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDetalleCompra
            // 
            this.dgDetalleCompra.AllowUserToAddRows = false;
            this.dgDetalleCompra.AllowUserToDeleteRows = false;
            this.dgDetalleCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgDetalleCompra.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDetalleCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDetalleCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetalleCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idCompra,
            this.idInventarioTotal,
            this.idInventario,
            this.idPresentacion,
            this.codigoProducto,
            this.descripcionProducto,
            this.nombrePresentacion,
            this.contenidoPresentacion,
            this.costoUnidad,
            this.porcentajeIva,
            this.porcentajeDescuento,
            this.valorDescuento,
            this.cantidad,
            this.totalDetalle,
            this.idSede,
            this.precioUnitario});
            this.dgDetalleCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDetalleCompra.Location = new System.Drawing.Point(0, 0);
            this.dgDetalleCompra.Name = "dgDetalleCompra";
            this.dgDetalleCompra.ReadOnly = true;
            this.dgDetalleCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDetalleCompra.Size = new System.Drawing.Size(681, 394);
            this.dgDetalleCompra.TabIndex = 0;
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
            // idCompra
            // 
            this.idCompra.DataPropertyName = "idCompra";
            this.idCompra.HeaderText = "idCompra";
            this.idCompra.Name = "idCompra";
            this.idCompra.ReadOnly = true;
            this.idCompra.Visible = false;
            this.idCompra.Width = 94;
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
            // idInventario
            // 
            this.idInventario.DataPropertyName = "idInventario";
            this.idInventario.HeaderText = "idInventario";
            this.idInventario.Name = "idInventario";
            this.idInventario.ReadOnly = true;
            this.idInventario.Visible = false;
            this.idInventario.Width = 107;
            // 
            // idPresentacion
            // 
            this.idPresentacion.DataPropertyName = "idPresentacion";
            this.idPresentacion.HeaderText = "idPresentacion";
            this.idPresentacion.Name = "idPresentacion";
            this.idPresentacion.ReadOnly = true;
            this.idPresentacion.Visible = false;
            this.idPresentacion.Width = 128;
            // 
            // codigoProducto
            // 
            this.codigoProducto.DataPropertyName = "codigoProducto";
            this.codigoProducto.HeaderText = "Código";
            this.codigoProducto.Name = "codigoProducto";
            this.codigoProducto.ReadOnly = true;
            this.codigoProducto.Width = 77;
            // 
            // descripcionProducto
            // 
            this.descripcionProducto.DataPropertyName = "descripcionProducto";
            this.descripcionProducto.HeaderText = "Descripción";
            this.descripcionProducto.Name = "descripcionProducto";
            this.descripcionProducto.ReadOnly = true;
            this.descripcionProducto.Width = 108;
            // 
            // nombrePresentacion
            // 
            this.nombrePresentacion.DataPropertyName = "nombrePresentacion";
            this.nombrePresentacion.HeaderText = "Presentación";
            this.nombrePresentacion.Name = "nombrePresentacion";
            this.nombrePresentacion.ReadOnly = true;
            this.nombrePresentacion.Width = 116;
            // 
            // contenidoPresentacion
            // 
            this.contenidoPresentacion.DataPropertyName = "contenidoPresentacion";
            this.contenidoPresentacion.HeaderText = "Contenido";
            this.contenidoPresentacion.Name = "contenidoPresentacion";
            this.contenidoPresentacion.ReadOnly = true;
            this.contenidoPresentacion.Width = 97;
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
            // porcentajeIva
            // 
            this.porcentajeIva.DataPropertyName = "porcentajeIva";
            this.porcentajeIva.HeaderText = "porcentajeIva";
            this.porcentajeIva.Name = "porcentajeIva";
            this.porcentajeIva.ReadOnly = true;
            this.porcentajeIva.Visible = false;
            this.porcentajeIva.Width = 118;
            // 
            // porcentajeDescuento
            // 
            this.porcentajeDescuento.DataPropertyName = "porcentajeDescuento";
            this.porcentajeDescuento.HeaderText = "porcentajeDescuento";
            this.porcentajeDescuento.Name = "porcentajeDescuento";
            this.porcentajeDescuento.ReadOnly = true;
            this.porcentajeDescuento.Visible = false;
            this.porcentajeDescuento.Width = 168;
            // 
            // valorDescuento
            // 
            this.valorDescuento.DataPropertyName = "valorDescuento";
            this.valorDescuento.HeaderText = "valorDescuento";
            this.valorDescuento.Name = "valorDescuento";
            this.valorDescuento.ReadOnly = true;
            this.valorDescuento.Visible = false;
            this.valorDescuento.Width = 131;
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantidad";
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 89;
            // 
            // totalDetalle
            // 
            this.totalDetalle.DataPropertyName = "totalDetalle";
            dataGridViewCellStyle2.Format = "c0";
            this.totalDetalle.DefaultCellStyle = dataGridViewCellStyle2;
            this.totalDetalle.HeaderText = "Total";
            this.totalDetalle.Name = "totalDetalle";
            this.totalDetalle.ReadOnly = true;
            this.totalDetalle.Width = 64;
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
            // precioUnitario
            // 
            this.precioUnitario.DataPropertyName = "precioUnitario";
            this.precioUnitario.HeaderText = "precioUnitario";
            this.precioUnitario.Name = "precioUnitario";
            this.precioUnitario.ReadOnly = true;
            this.precioUnitario.Visible = false;
            this.precioUnitario.Width = 123;
            // 
            // frmVerDetalleCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 394);
            this.Controls.Add(this.dgDetalleCompra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(658, 406);
            this.Name = "frmVerDetalleCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Compra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleCompra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dgDetalleCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInventarioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrePresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn contenidoPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSede;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioUnitario;
    }
}
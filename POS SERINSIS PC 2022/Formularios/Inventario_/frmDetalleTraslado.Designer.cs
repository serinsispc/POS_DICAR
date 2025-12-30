namespace SERINSI_PC.Formularios.Inventario
{
    partial class frmDetalleTraslado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleTraslado));
            this.dgDetalleVenta = new System.Windows.Forms.DataGridView();
            this.v_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_guidDetalleTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_guidCorto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_idProductoTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_codigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_descripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_cantidadproductoTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDetalleVenta
            // 
            this.dgDetalleVenta.AllowUserToAddRows = false;
            this.dgDetalleVenta.AllowUserToDeleteRows = false;
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
            this.v_id,
            this.v_guidDetalleTraslado,
            this.v_guidCorto,
            this.v_idProductoTraslado,
            this.v_codigoProducto,
            this.v_descripcionProducto,
            this.v_cantidadproductoTraslado});
            this.dgDetalleVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDetalleVenta.Location = new System.Drawing.Point(0, 0);
            this.dgDetalleVenta.Name = "dgDetalleVenta";
            this.dgDetalleVenta.ReadOnly = true;
            this.dgDetalleVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDetalleVenta.Size = new System.Drawing.Size(631, 323);
            this.dgDetalleVenta.TabIndex = 26;
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
            // v_guidDetalleTraslado
            // 
            this.v_guidDetalleTraslado.DataPropertyName = "v_guidDetalleTraslado";
            this.v_guidDetalleTraslado.HeaderText = "v_guidDetalleTraslado";
            this.v_guidDetalleTraslado.Name = "v_guidDetalleTraslado";
            this.v_guidDetalleTraslado.ReadOnly = true;
            this.v_guidDetalleTraslado.Visible = false;
            this.v_guidDetalleTraslado.Width = 176;
            // 
            // v_guidCorto
            // 
            this.v_guidCorto.DataPropertyName = "v_guidCorto";
            this.v_guidCorto.HeaderText = "v_guidCorto";
            this.v_guidCorto.Name = "v_guidCorto";
            this.v_guidCorto.ReadOnly = true;
            this.v_guidCorto.Visible = false;
            this.v_guidCorto.Width = 108;
            // 
            // v_idProductoTraslado
            // 
            this.v_idProductoTraslado.DataPropertyName = "v_idProductoTraslado";
            this.v_idProductoTraslado.HeaderText = "v_idProductoTraslado";
            this.v_idProductoTraslado.Name = "v_idProductoTraslado";
            this.v_idProductoTraslado.ReadOnly = true;
            this.v_idProductoTraslado.Visible = false;
            this.v_idProductoTraslado.Width = 171;
            // 
            // v_codigoProducto
            // 
            this.v_codigoProducto.DataPropertyName = "v_codigoProducto";
            this.v_codigoProducto.HeaderText = "Código";
            this.v_codigoProducto.Name = "v_codigoProducto";
            this.v_codigoProducto.ReadOnly = true;
            this.v_codigoProducto.Width = 77;
            // 
            // v_descripcionProducto
            // 
            this.v_descripcionProducto.DataPropertyName = "v_descripcionProducto";
            this.v_descripcionProducto.HeaderText = "Producto";
            this.v_descripcionProducto.Name = "v_descripcionProducto";
            this.v_descripcionProducto.ReadOnly = true;
            this.v_descripcionProducto.Width = 89;
            // 
            // v_cantidadproductoTraslado
            // 
            this.v_cantidadproductoTraslado.DataPropertyName = "v_cantidadproductoTraslado";
            this.v_cantidadproductoTraslado.HeaderText = "UND";
            this.v_cantidadproductoTraslado.Name = "v_cantidadproductoTraslado";
            this.v_cantidadproductoTraslado.ReadOnly = true;
            this.v_cantidadproductoTraslado.Width = 62;
            // 
            // frmDetalleTraslado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 323);
            this.Controls.Add(this.dgDetalleVenta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(647, 362);
            this.MinimumSize = new System.Drawing.Size(647, 362);
            this.Name = "frmDetalleTraslado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Traslado";
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleVenta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn v_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_guidDetalleTraslado;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_guidCorto;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_idProductoTraslado;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_codigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_descripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_cantidadproductoTraslado;
        public System.Windows.Forms.DataGridView dgDetalleVenta;
    }
}
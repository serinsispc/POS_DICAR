namespace SERINSI_PC.Formularios.Ventas
{
    partial class frmVerPagosCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerPagosCredito));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgVerPagos = new System.Windows.Forms.DataGridView();
            this.id_pago_credito_tienda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_pago_credito_tienda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_cliente_pago_credito_tienda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_pago_credito_tienda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVentaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idBaseCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idBolsillo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVerPagos)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(654, 23);
            this.panel1.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 18);
            this.label15.TabIndex = 11;
            this.label15.Text = "Pago Créditos";
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
            this.btnCerrar.Location = new System.Drawing.Point(631, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(23, 23);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgVerPagos
            // 
            this.dgVerPagos.AllowUserToAddRows = false;
            this.dgVerPagos.AllowUserToDeleteRows = false;
            this.dgVerPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgVerPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVerPagos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgVerPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVerPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_pago_credito_tienda,
            this.fecha_pago_credito_tienda,
            this.id_cliente_pago_credito_tienda,
            this.valor_pago_credito_tienda,
            this.idVentaPago,
            this.tipoPago,
            this.idBaseCaja,
            this.idBolsillo});
            this.dgVerPagos.Location = new System.Drawing.Point(12, 29);
            this.dgVerPagos.Name = "dgVerPagos";
            this.dgVerPagos.ReadOnly = true;
            this.dgVerPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVerPagos.Size = new System.Drawing.Size(481, 384);
            this.dgVerPagos.TabIndex = 23;
            // 
            // id_pago_credito_tienda
            // 
            this.id_pago_credito_tienda.DataPropertyName = "id_pago_credito_tienda";
            this.id_pago_credito_tienda.HeaderText = "id_pago_credito_tienda";
            this.id_pago_credito_tienda.Name = "id_pago_credito_tienda";
            this.id_pago_credito_tienda.ReadOnly = true;
            this.id_pago_credito_tienda.Visible = false;
            this.id_pago_credito_tienda.Width = 184;
            // 
            // fecha_pago_credito_tienda
            // 
            this.fecha_pago_credito_tienda.DataPropertyName = "fecha_pago_credito_tienda";
            this.fecha_pago_credito_tienda.HeaderText = "Fecha";
            this.fecha_pago_credito_tienda.Name = "fecha_pago_credito_tienda";
            this.fecha_pago_credito_tienda.ReadOnly = true;
            this.fecha_pago_credito_tienda.Width = 71;
            // 
            // id_cliente_pago_credito_tienda
            // 
            this.id_cliente_pago_credito_tienda.DataPropertyName = "id_cliente_pago_credito_tienda";
            this.id_cliente_pago_credito_tienda.HeaderText = "id_cliente_pago_credito_tienda";
            this.id_cliente_pago_credito_tienda.Name = "id_cliente_pago_credito_tienda";
            this.id_cliente_pago_credito_tienda.ReadOnly = true;
            this.id_cliente_pago_credito_tienda.Visible = false;
            this.id_cliente_pago_credito_tienda.Width = 235;
            // 
            // valor_pago_credito_tienda
            // 
            this.valor_pago_credito_tienda.DataPropertyName = "valor_pago_credito_tienda";
            dataGridViewCellStyle2.Format = "c0";
            this.valor_pago_credito_tienda.DefaultCellStyle = dataGridViewCellStyle2;
            this.valor_pago_credito_tienda.HeaderText = "Valor Pagado";
            this.valor_pago_credito_tienda.Name = "valor_pago_credito_tienda";
            this.valor_pago_credito_tienda.ReadOnly = true;
            this.valor_pago_credito_tienda.Width = 108;
            // 
            // idVentaPago
            // 
            this.idVentaPago.DataPropertyName = "idVentaPago";
            this.idVentaPago.HeaderText = "idVentaPago";
            this.idVentaPago.Name = "idVentaPago";
            this.idVentaPago.ReadOnly = true;
            this.idVentaPago.Visible = false;
            this.idVentaPago.Width = 113;
            // 
            // tipoPago
            // 
            this.tipoPago.DataPropertyName = "tipoPago";
            this.tipoPago.HeaderText = "Tipo Pago";
            this.tipoPago.Name = "tipoPago";
            this.tipoPago.ReadOnly = true;
            this.tipoPago.Width = 89;
            // 
            // idBaseCaja
            // 
            this.idBaseCaja.DataPropertyName = "idBaseCaja";
            this.idBaseCaja.HeaderText = "idBaseCaja";
            this.idBaseCaja.Name = "idBaseCaja";
            this.idBaseCaja.ReadOnly = true;
            this.idBaseCaja.Visible = false;
            this.idBaseCaja.Width = 105;
            // 
            // idBolsillo
            // 
            this.idBolsillo.DataPropertyName = "idBolsillo";
            this.idBolsillo.HeaderText = "idBolsillo";
            this.idBolsillo.Name = "idBolsillo";
            this.idBolsillo.ReadOnly = true;
            this.idBolsillo.Visible = false;
            this.idBolsillo.Width = 92;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(499, 29);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(143, 62);
            this.btnEliminar.TabIndex = 45;
            this.btnEliminar.Text = "Eliminar Pago";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmVerPagosCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 425);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgVerPagos);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmVerPagosCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVerPagosCredito";
            this.Load += new System.EventHandler(this.frmVerPagosCredito_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVerPagosCredito_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVerPagos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCerrar;
        public System.Windows.Forms.DataGridView dgVerPagos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_pago_credito_tienda;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_pago_credito_tienda;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_cliente_pago_credito_tienda;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_pago_credito_tienda;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVentaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBaseCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBolsillo;
        private System.Windows.Forms.Button btnEliminar;
    }
}
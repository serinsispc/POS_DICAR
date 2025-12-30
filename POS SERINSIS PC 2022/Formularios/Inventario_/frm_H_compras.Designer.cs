
namespace SERINSI_PC.Formularios.Inventario_
{
    partial class frm_H_compras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNumeroVenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbDia = new System.Windows.Forms.RadioButton();
            this.rbMes = new System.Windows.Forms.RadioButton();
            this.rbAño = new System.Windows.Forms.RadioButton();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgCompras = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnArchivo = new System.Windows.Forms.Button();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.btnEliminarFiltro = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.idV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facturaCompraV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCompraV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProveedorV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoProveedorV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSedeCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreProveedorV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotalCompraV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivaCompraV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCompraV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorPagadoCompraV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoCompraV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumeroVenta
            // 
            this.txtNumeroVenta.Location = new System.Drawing.Point(288, 27);
            this.txtNumeroVenta.Name = "txtNumeroVenta";
            this.txtNumeroVenta.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroVenta.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(285, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 73;
            this.label2.Text = "Número Venta";
            // 
            // rbDia
            // 
            this.rbDia.AutoSize = true;
            this.rbDia.Location = new System.Drawing.Point(239, 27);
            this.rbDia.Name = "rbDia";
            this.rbDia.Size = new System.Drawing.Size(43, 17);
            this.rbDia.TabIndex = 72;
            this.rbDia.TabStop = true;
            this.rbDia.Text = "Día";
            this.rbDia.UseVisualStyleBackColor = true;
            // 
            // rbMes
            // 
            this.rbMes.AutoSize = true;
            this.rbMes.Location = new System.Drawing.Point(187, 27);
            this.rbMes.Name = "rbMes";
            this.rbMes.Size = new System.Drawing.Size(45, 17);
            this.rbMes.TabIndex = 71;
            this.rbMes.TabStop = true;
            this.rbMes.Text = "Mes";
            this.rbMes.UseVisualStyleBackColor = true;
            // 
            // rbAño
            // 
            this.rbAño.AutoSize = true;
            this.rbAño.Location = new System.Drawing.Point(135, 27);
            this.rbAño.Name = "rbAño";
            this.rbAño.Size = new System.Drawing.Size(44, 17);
            this.rbAño.TabIndex = 70;
            this.rbAño.TabStop = true;
            this.rbAño.Text = "Año";
            this.rbAño.UseVisualStyleBackColor = true;
            // 
            // dtFecha
            // 
            this.dtFecha.CalendarFont = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(15, 27);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(114, 20);
            this.dtFecha.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 68;
            this.label1.Text = "Fecha";
            // 
            // dgCompras
            // 
            this.dgCompras.AllowUserToAddRows = false;
            this.dgCompras.AllowUserToDeleteRows = false;
            this.dgCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCompras.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idV,
            this.facturaCompraV,
            this.fechaCompraV,
            this.idProveedorV,
            this.documentoProveedorV,
            this.idSedeCompra,
            this.nombreProveedorV,
            this.subtotalCompraV,
            this.ivaCompraV,
            this.totalCompraV,
            this.valorPagadoCompraV,
            this.saldoCompraV,
            this.idEstadoAI});
            this.dgCompras.Location = new System.Drawing.Point(15, 63);
            this.dgCompras.Name = "dgCompras";
            this.dgCompras.ReadOnly = true;
            this.dgCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCompras.Size = new System.Drawing.Size(700, 375);
            this.dgCompras.TabIndex = 76;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(721, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 34);
            this.label5.TabIndex = 80;
            this.label5.Text = "Ver Detalle";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(720, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 34);
            this.label4.TabIndex = 82;
            this.label4.Text = "descargar Archivo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnArchivo
            // 
            this.btnArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArchivo.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.Descargar;
            this.btnArchivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnArchivo.FlatAppearance.BorderSize = 0;
            this.btnArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchivo.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchivo.Location = new System.Drawing.Point(724, 243);
            this.btnArchivo.Name = "btnArchivo";
            this.btnArchivo.Size = new System.Drawing.Size(66, 50);
            this.btnArchivo.TabIndex = 81;
            this.btnArchivo.UseVisualStyleBackColor = true;
            this.btnArchivo.Click += new System.EventHandler(this.btnArchivo_Click);
            // 
            // btnDetalle
            // 
            this.btnDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetalle.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_ver_detalles_100;
            this.btnDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetalle.FlatAppearance.BorderSize = 0;
            this.btnDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalle.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.Location = new System.Drawing.Point(722, 63);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(66, 50);
            this.btnDetalle.TabIndex = 79;
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // btnEliminarFiltro
            // 
            this.btnEliminarFiltro.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_eliminar_filtros_100;
            this.btnEliminarFiltro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarFiltro.FlatAppearance.BorderSize = 0;
            this.btnEliminarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFiltro.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarFiltro.Location = new System.Drawing.Point(394, 7);
            this.btnEliminarFiltro.Name = "btnEliminarFiltro";
            this.btnEliminarFiltro.Size = new System.Drawing.Size(66, 50);
            this.btnEliminarFiltro.TabIndex = 75;
            this.btnEliminarFiltro.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(720, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 84;
            this.label3.Text = "Eliminar";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.eliminarPNG;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(724, 333);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(66, 50);
            this.btnEliminar.TabIndex = 83;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(720, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 34);
            this.label6.TabIndex = 86;
            this.label6.Text = "Cargar Archivo";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.agregarPNG;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(724, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 50);
            this.button1.TabIndex = 85;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // idV
            // 
            this.idV.DataPropertyName = "idV";
            this.idV.HeaderText = "idV";
            this.idV.Name = "idV";
            this.idV.ReadOnly = true;
            this.idV.Visible = false;
            this.idV.Width = 52;
            // 
            // facturaCompraV
            // 
            this.facturaCompraV.DataPropertyName = "facturaCompraV";
            this.facturaCompraV.HeaderText = "Factura";
            this.facturaCompraV.Name = "facturaCompraV";
            this.facturaCompraV.ReadOnly = true;
            this.facturaCompraV.Width = 80;
            // 
            // fechaCompraV
            // 
            this.fechaCompraV.DataPropertyName = "fechaCompraV";
            this.fechaCompraV.HeaderText = "Fecha";
            this.fechaCompraV.Name = "fechaCompraV";
            this.fechaCompraV.ReadOnly = true;
            this.fechaCompraV.Width = 71;
            // 
            // idProveedorV
            // 
            this.idProveedorV.DataPropertyName = "idProveedorV";
            this.idProveedorV.HeaderText = "idProveedorV";
            this.idProveedorV.Name = "idProveedorV";
            this.idProveedorV.ReadOnly = true;
            this.idProveedorV.Visible = false;
            this.idProveedorV.Width = 117;
            // 
            // documentoProveedorV
            // 
            this.documentoProveedorV.DataPropertyName = "documentoProveedorV";
            this.documentoProveedorV.HeaderText = "Nit";
            this.documentoProveedorV.Name = "documentoProveedorV";
            this.documentoProveedorV.ReadOnly = true;
            this.documentoProveedorV.Width = 50;
            // 
            // idSedeCompra
            // 
            this.idSedeCompra.DataPropertyName = "idSedeCompra";
            this.idSedeCompra.HeaderText = "idSedeCompra";
            this.idSedeCompra.Name = "idSedeCompra";
            this.idSedeCompra.ReadOnly = true;
            this.idSedeCompra.Visible = false;
            this.idSedeCompra.Width = 127;
            // 
            // nombreProveedorV
            // 
            this.nombreProveedorV.DataPropertyName = "nombreProveedorV";
            this.nombreProveedorV.HeaderText = "Proveedor";
            this.nombreProveedorV.Name = "nombreProveedorV";
            this.nombreProveedorV.ReadOnly = true;
            this.nombreProveedorV.Width = 97;
            // 
            // subtotalCompraV
            // 
            this.subtotalCompraV.DataPropertyName = "subtotalCompraV";
            dataGridViewCellStyle2.Format = "c0";
            this.subtotalCompraV.DefaultCellStyle = dataGridViewCellStyle2;
            this.subtotalCompraV.HeaderText = "SubTotal";
            this.subtotalCompraV.Name = "subtotalCompraV";
            this.subtotalCompraV.ReadOnly = true;
            this.subtotalCompraV.Width = 89;
            // 
            // ivaCompraV
            // 
            this.ivaCompraV.DataPropertyName = "ivaCompraV";
            dataGridViewCellStyle3.Format = "c0";
            this.ivaCompraV.DefaultCellStyle = dataGridViewCellStyle3;
            this.ivaCompraV.HeaderText = "IVA";
            this.ivaCompraV.Name = "ivaCompraV";
            this.ivaCompraV.ReadOnly = true;
            this.ivaCompraV.Width = 52;
            // 
            // totalCompraV
            // 
            this.totalCompraV.DataPropertyName = "totalCompraV";
            dataGridViewCellStyle4.Format = "c0";
            this.totalCompraV.DefaultCellStyle = dataGridViewCellStyle4;
            this.totalCompraV.HeaderText = "Total";
            this.totalCompraV.Name = "totalCompraV";
            this.totalCompraV.ReadOnly = true;
            this.totalCompraV.Width = 64;
            // 
            // valorPagadoCompraV
            // 
            this.valorPagadoCompraV.DataPropertyName = "valorPagadoCompraV";
            dataGridViewCellStyle5.Format = "c0";
            this.valorPagadoCompraV.DefaultCellStyle = dataGridViewCellStyle5;
            this.valorPagadoCompraV.HeaderText = "Valor Pagado";
            this.valorPagadoCompraV.Name = "valorPagadoCompraV";
            this.valorPagadoCompraV.ReadOnly = true;
            this.valorPagadoCompraV.Width = 108;
            // 
            // saldoCompraV
            // 
            this.saldoCompraV.DataPropertyName = "saldoCompraV";
            dataGridViewCellStyle6.Format = "c0";
            this.saldoCompraV.DefaultCellStyle = dataGridViewCellStyle6;
            this.saldoCompraV.HeaderText = "Saldo";
            this.saldoCompraV.Name = "saldoCompraV";
            this.saldoCompraV.ReadOnly = true;
            this.saldoCompraV.Width = 69;
            // 
            // idEstadoAI
            // 
            this.idEstadoAI.DataPropertyName = "idEstadoAI";
            this.idEstadoAI.HeaderText = "idEstadoAI";
            this.idEstadoAI.Name = "idEstadoAI";
            this.idEstadoAI.ReadOnly = true;
            this.idEstadoAI.Visible = false;
            // 
            // frm_H_compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnArchivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.dgCompras);
            this.Controls.Add(this.btnEliminarFiltro);
            this.Controls.Add(this.txtNumeroVenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbDia);
            this.Controls.Add(this.rbMes);
            this.Controls.Add(this.rbAño);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.label1);
            this.Name = "frm_H_compras";
            this.Text = "frm_H_compras";
            this.Load += new System.EventHandler(this.frm_H_compras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminarFiltro;
        private System.Windows.Forms.TextBox txtNumeroVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbDia;
        private System.Windows.Forms.RadioButton rbMes;
        private System.Windows.Forms.RadioButton rbAño;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgCompras;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnArchivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idV;
        private System.Windows.Forms.DataGridViewTextBoxColumn facturaCompraV;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCompraV;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedorV;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoProveedorV;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSedeCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProveedorV;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotalCompraV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivaCompraV;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCompraV;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorPagadoCompraV;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoCompraV;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoAI;
    }
}
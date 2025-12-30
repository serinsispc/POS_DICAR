namespace SERINSI_PC.Formularios.Facturas_Software
{
    partial class frmFacturas
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
            this.btnDescargar = new System.Windows.Forms.Button();
            this.dgFacturaSoftware = new System.Windows.Forms.DataGridView();
            this.id_factura_software = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ruta_factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturaSoftware)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDescargar
            // 
            this.btnDescargar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDescargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargar.Location = new System.Drawing.Point(299, 392);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(118, 34);
            this.btnDescargar.TabIndex = 56;
            this.btnDescargar.Text = "Descargar";
            this.btnDescargar.UseVisualStyleBackColor = true;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // dgFacturaSoftware
            // 
            this.dgFacturaSoftware.AllowUserToAddRows = false;
            this.dgFacturaSoftware.AllowUserToDeleteRows = false;
            this.dgFacturaSoftware.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFacturaSoftware.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFacturaSoftware.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgFacturaSoftware.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFacturaSoftware.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_factura_software,
            this.factura,
            this.nombre_factura,
            this.ruta_factura});
            this.dgFacturaSoftware.Location = new System.Drawing.Point(12, 10);
            this.dgFacturaSoftware.Name = "dgFacturaSoftware";
            this.dgFacturaSoftware.ReadOnly = true;
            this.dgFacturaSoftware.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFacturaSoftware.Size = new System.Drawing.Size(689, 376);
            this.dgFacturaSoftware.TabIndex = 55;
            // 
            // id_factura_software
            // 
            this.id_factura_software.DataPropertyName = "id_factura_software";
            this.id_factura_software.HeaderText = "id_factura_software";
            this.id_factura_software.Name = "id_factura_software";
            this.id_factura_software.ReadOnly = true;
            this.id_factura_software.Visible = false;
            this.id_factura_software.Width = 158;
            // 
            // factura
            // 
            this.factura.DataPropertyName = "factura";
            this.factura.HeaderText = "Descripción Factura ";
            this.factura.Name = "factura";
            this.factura.ReadOnly = true;
            this.factura.Width = 150;
            // 
            // nombre_factura
            // 
            this.nombre_factura.DataPropertyName = "nombre_factura";
            this.nombre_factura.HeaderText = "Factura";
            this.nombre_factura.Name = "nombre_factura";
            this.nombre_factura.ReadOnly = true;
            this.nombre_factura.Width = 80;
            // 
            // ruta_factura
            // 
            this.ruta_factura.DataPropertyName = "ruta_factura";
            this.ruta_factura.HeaderText = "ruta_factura";
            this.ruta_factura.Name = "ruta_factura";
            this.ruta_factura.ReadOnly = true;
            this.ruta_factura.Visible = false;
            this.ruta_factura.Width = 109;
            // 
            // frmFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 437);
            this.Controls.Add(this.btnDescargar);
            this.Controls.Add(this.dgFacturaSoftware);
            this.Name = "frmFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturas";
            this.Load += new System.EventHandler(this.frmFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturaSoftware)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.DataGridView dgFacturaSoftware;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_factura_software;
        private System.Windows.Forms.DataGridViewTextBoxColumn factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn ruta_factura;
    }
}
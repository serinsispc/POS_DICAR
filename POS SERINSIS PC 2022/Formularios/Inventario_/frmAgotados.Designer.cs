namespace SERINSI_PC.Formularios.Inventario
{
    partial class frmAgotados
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
            this.dgAgotados = new System.Windows.Forms.DataGridView();
            this.btnImprimirRGeneral = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreSede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guidProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.letraTipoMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrePresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventarioActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgAgotados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgAgotados
            // 
            this.dgAgotados.AllowUserToAddRows = false;
            this.dgAgotados.AllowUserToDeleteRows = false;
            this.dgAgotados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAgotados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgAgotados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAgotados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgAgotados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAgotados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idSede,
            this.idTipoMedida,
            this.idCategoria,
            this.idInventario,
            this.nombreSede,
            this.nombreCategoria,
            this.guidProducto,
            this.codigoProducto,
            this.descripcionProducto,
            this.letraTipoMedida,
            this.nombrePresentacion,
            this.inventarioActual,
            this.idEstadoInventario,
            this.idEstadoAI,
            this.stockMinimo});
            this.dgAgotados.Location = new System.Drawing.Point(12, 12);
            this.dgAgotados.Name = "dgAgotados";
            this.dgAgotados.ReadOnly = true;
            this.dgAgotados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAgotados.Size = new System.Drawing.Size(595, 366);
            this.dgAgotados.TabIndex = 0;
            // 
            // btnImprimirRGeneral
            // 
            this.btnImprimirRGeneral.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImprimirRGeneral.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimirRGeneral.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_imprimir_100;
            this.btnImprimirRGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimirRGeneral.FlatAppearance.BorderSize = 0;
            this.btnImprimirRGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirRGeneral.Location = new System.Drawing.Point(250, 384);
            this.btnImprimirRGeneral.Name = "btnImprimirRGeneral";
            this.btnImprimirRGeneral.Size = new System.Drawing.Size(112, 52);
            this.btnImprimirRGeneral.TabIndex = 50;
            this.btnImprimirRGeneral.UseVisualStyleBackColor = false;
            this.btnImprimirRGeneral.Click += new System.EventHandler(this.btnImprimirRGeneral_Click);
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
            // idSede
            // 
            this.idSede.DataPropertyName = "idSede";
            this.idSede.HeaderText = "idSede";
            this.idSede.Name = "idSede";
            this.idSede.ReadOnly = true;
            this.idSede.Visible = false;
            this.idSede.Width = 77;
            // 
            // idTipoMedida
            // 
            this.idTipoMedida.DataPropertyName = "idTipoMedida";
            this.idTipoMedida.HeaderText = "idTipoMedida";
            this.idTipoMedida.Name = "idTipoMedida";
            this.idTipoMedida.ReadOnly = true;
            this.idTipoMedida.Visible = false;
            this.idTipoMedida.Width = 120;
            // 
            // idCategoria
            // 
            this.idCategoria.DataPropertyName = "idCategoria";
            this.idCategoria.HeaderText = "idCategoria";
            this.idCategoria.Name = "idCategoria";
            this.idCategoria.ReadOnly = true;
            this.idCategoria.Visible = false;
            this.idCategoria.Width = 106;
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
            // nombreSede
            // 
            this.nombreSede.DataPropertyName = "nombreSede";
            this.nombreSede.HeaderText = "nombreSede";
            this.nombreSede.Name = "nombreSede";
            this.nombreSede.ReadOnly = true;
            this.nombreSede.Visible = false;
            this.nombreSede.Width = 114;
            // 
            // nombreCategoria
            // 
            this.nombreCategoria.DataPropertyName = "nombreCategoria";
            this.nombreCategoria.HeaderText = "Categoria";
            this.nombreCategoria.Name = "nombreCategoria";
            this.nombreCategoria.ReadOnly = true;
            this.nombreCategoria.Width = 94;
            // 
            // guidProducto
            // 
            this.guidProducto.DataPropertyName = "guidProducto";
            this.guidProducto.HeaderText = "guidProducto";
            this.guidProducto.Name = "guidProducto";
            this.guidProducto.ReadOnly = true;
            this.guidProducto.Visible = false;
            this.guidProducto.Width = 117;
            // 
            // codigoProducto
            // 
            this.codigoProducto.DataPropertyName = "codigoProducto";
            this.codigoProducto.HeaderText = "Codígo";
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
            // letraTipoMedida
            // 
            this.letraTipoMedida.DataPropertyName = "letraTipoMedida";
            this.letraTipoMedida.HeaderText = "Medida";
            this.letraTipoMedida.Name = "letraTipoMedida";
            this.letraTipoMedida.ReadOnly = true;
            this.letraTipoMedida.Width = 80;
            // 
            // nombrePresentacion
            // 
            this.nombrePresentacion.DataPropertyName = "nombrePresentacion";
            this.nombrePresentacion.HeaderText = "Presentación";
            this.nombrePresentacion.Name = "nombrePresentacion";
            this.nombrePresentacion.ReadOnly = true;
            this.nombrePresentacion.Width = 116;
            // 
            // inventarioActual
            // 
            this.inventarioActual.DataPropertyName = "inventarioActual";
            this.inventarioActual.HeaderText = "Inv. Actual";
            this.inventarioActual.Name = "inventarioActual";
            this.inventarioActual.ReadOnly = true;
            this.inventarioActual.Width = 97;
            // 
            // idEstadoInventario
            // 
            this.idEstadoInventario.DataPropertyName = "idEstadoInventario";
            this.idEstadoInventario.HeaderText = "idEstadoInventario";
            this.idEstadoInventario.Name = "idEstadoInventario";
            this.idEstadoInventario.ReadOnly = true;
            this.idEstadoInventario.Visible = false;
            this.idEstadoInventario.Width = 151;
            // 
            // idEstadoAI
            // 
            this.idEstadoAI.DataPropertyName = "idEstadoAI";
            this.idEstadoAI.HeaderText = "idEstadoAI";
            this.idEstadoAI.Name = "idEstadoAI";
            this.idEstadoAI.ReadOnly = true;
            this.idEstadoAI.Visible = false;
            // 
            // stockMinimo
            // 
            this.stockMinimo.DataPropertyName = "stockMinimo";
            this.stockMinimo.HeaderText = "Stock Minimo";
            this.stockMinimo.Name = "stockMinimo";
            this.stockMinimo.ReadOnly = true;
            this.stockMinimo.Width = 109;
            // 
            // frmAgotados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 443);
            this.Controls.Add(this.btnImprimirRGeneral);
            this.Controls.Add(this.dgAgotados);
            this.Name = "frmAgotados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgotados";
            this.Load += new System.EventHandler(this.frmAgotados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAgotados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgAgotados;
        private System.Windows.Forms.Button btnImprimirRGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSede;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreSede;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn guidProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn letraTipoMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrePresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventarioActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockMinimo;
    }
}
namespace POS_SERINSIS_PC_2022.Formularios.Configuracion
{
    partial class frmBuscadorVendedor
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
            this.dgBuscarVendedor = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.claveVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSeleccionarCliente = new FontAwesome.Sharp.IconButton();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgBuscarVendedor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgBuscarVendedor
            // 
            this.dgBuscarVendedor.AllowUserToAddRows = false;
            this.dgBuscarVendedor.AllowUserToDeleteRows = false;
            this.dgBuscarVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBuscarVendedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBuscarVendedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgBuscarVendedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBuscarVendedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombreVendedor,
            this.telefonoVendedor,
            this.claveVendedor});
            this.dgBuscarVendedor.Location = new System.Drawing.Point(15, 61);
            this.dgBuscarVendedor.Name = "dgBuscarVendedor";
            this.dgBuscarVendedor.ReadOnly = true;
            this.dgBuscarVendedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBuscarVendedor.Size = new System.Drawing.Size(773, 380);
            this.dgBuscarVendedor.TabIndex = 61;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 45;
            // 
            // nombreVendedor
            // 
            this.nombreVendedor.DataPropertyName = "nombreVendedor";
            this.nombreVendedor.HeaderText = "Vemdedor";
            this.nombreVendedor.Name = "nombreVendedor";
            this.nombreVendedor.ReadOnly = true;
            this.nombreVendedor.Width = 104;
            // 
            // telefonoVendedor
            // 
            this.telefonoVendedor.DataPropertyName = "telefonoVendedor";
            this.telefonoVendedor.HeaderText = "Teléfono";
            this.telefonoVendedor.Name = "telefonoVendedor";
            this.telefonoVendedor.ReadOnly = true;
            this.telefonoVendedor.Width = 94;
            // 
            // claveVendedor
            // 
            this.claveVendedor.DataPropertyName = "claveVendedor";
            this.claveVendedor.HeaderText = "Clave";
            this.claveVendedor.Name = "claveVendedor";
            this.claveVendedor.ReadOnly = true;
            this.claveVendedor.Width = 72;
            // 
            // btnSeleccionarCliente
            // 
            this.btnSeleccionarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarCliente.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnSeleccionarCliente.IconColor = System.Drawing.Color.Black;
            this.btnSeleccionarCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSeleccionarCliente.IconSize = 40;
            this.btnSeleccionarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarCliente.Location = new System.Drawing.Point(649, 10);
            this.btnSeleccionarCliente.Name = "btnSeleccionarCliente";
            this.btnSeleccionarCliente.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnSeleccionarCliente.Size = new System.Drawing.Size(139, 45);
            this.btnSeleccionarCliente.TabIndex = 60;
            this.btnSeleccionarCliente.Text = "Seleccionar Vendedor";
            this.btnSeleccionarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeleccionarCliente.UseVisualStyleBackColor = true;
            this.btnSeleccionarCliente.Click += new System.EventHandler(this.btnSeleccionarCliente_Click);
            // 
            // txtVendedor
            // 
            this.txtVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVendedor.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendedor.Location = new System.Drawing.Point(15, 31);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(628, 24);
            this.txtVendedor.TabIndex = 59;
            this.txtVendedor.TextChanged += new System.EventHandler(this.txtVendedor_TextChanged);
            this.txtVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVendedor_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 58;
            this.label1.Text = "Buscar Vendedor";
            // 
            // frmBuscadorVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgBuscarVendedor);
            this.Controls.Add(this.btnSeleccionarCliente);
            this.Controls.Add(this.txtVendedor);
            this.Controls.Add(this.label1);
            this.Name = "frmBuscadorVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBuscadorVendedor";
            this.Load += new System.EventHandler(this.frmBuscadorVendedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBuscarVendedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgBuscarVendedor;
        private FontAwesome.Sharp.IconButton btnSeleccionarCliente;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn claveVendedor;
    }
}
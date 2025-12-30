namespace SERINSI_PC.Formularios
{
    partial class frmTutoriales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTutoriales));
            this.dgTutoriales = new System.Windows.Forms.DataGridView();
            this.id_tutorial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_tutorial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionTutorial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgTutoriales)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTutoriales
            // 
            this.dgTutoriales.AllowUserToAddRows = false;
            this.dgTutoriales.AllowUserToDeleteRows = false;
            this.dgTutoriales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTutoriales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgTutoriales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTutoriales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTutoriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTutoriales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_tutorial,
            this.nombre_tutorial,
            this.descripcionTutorial});
            this.dgTutoriales.Name = "dgTutoriales";
            this.dgTutoriales.ReadOnly = true;
            this.dgTutoriales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTutoriales.Size = new System.Drawing.Size(635, 465);
            this.dgTutoriales.TabIndex = 14;
            this.dgTutoriales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTutoriales_CellClick);
            // 
            // id_tutorial
            // 
            this.id_tutorial.DataPropertyName = "id_tutorial";
            this.id_tutorial.HeaderText = "id_tutorial";
            this.id_tutorial.Name = "id_tutorial";
            this.id_tutorial.ReadOnly = true;
            this.id_tutorial.Visible = false;
            this.id_tutorial.Width = 97;
            // 
            // nombre_tutorial
            // 
            this.nombre_tutorial.DataPropertyName = "nombre_tutorial";
            this.nombre_tutorial.HeaderText = "Tutorial";
            this.nombre_tutorial.Name = "nombre_tutorial";
            this.nombre_tutorial.ReadOnly = true;
            this.nombre_tutorial.Width = 81;
            // 
            // descripcionTutorial
            // 
            this.descripcionTutorial.DataPropertyName = "descripcionTutorial";
            this.descripcionTutorial.HeaderText = "Descripción";
            this.descripcionTutorial.Name = "descripcionTutorial";
            this.descripcionTutorial.ReadOnly = true;
            this.descripcionTutorial.Width = 108;
            // 
            // frmTutoriales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 489);
            this.Controls.Add(this.dgTutoriales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmTutoriales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTutoriales";
            this.Load += new System.EventHandler(this.frmTutoriales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTutoriales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgTutoriales;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_tutorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_tutorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionTutorial;
    }
}
namespace SERINSI_PC.Formularios.Inventario
{
    partial class frmCodigoBarra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCodigoBarra));
            this.btnIMprimir = new System.Windows.Forms.Button();
            this.pbCodigo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCodigo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIMprimir
            // 
            this.btnIMprimir.BackgroundImage = global::POS_SERINSIS_PC_2022.Properties.Resources.icons8_imprimir_100;
            this.btnIMprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIMprimir.FlatAppearance.BorderSize = 0;
            this.btnIMprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIMprimir.Location = new System.Drawing.Point(77, 133);
            this.btnIMprimir.Name = "btnIMprimir";
            this.btnIMprimir.Size = new System.Drawing.Size(89, 59);
            this.btnIMprimir.TabIndex = 39;
            this.btnIMprimir.UseVisualStyleBackColor = true;
            this.btnIMprimir.Click += new System.EventHandler(this.btnIMprimir_Click);
            // 
            // pbCodigo
            // 
            this.pbCodigo.Location = new System.Drawing.Point(10, 12);
            this.pbCodigo.Name = "pbCodigo";
            this.pbCodigo.Size = new System.Drawing.Size(232, 115);
            this.pbCodigo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCodigo.TabIndex = 0;
            this.pbCodigo.TabStop = false;
            // 
            // frmCodigoBarra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 199);
            this.Controls.Add(this.btnIMprimir);
            this.Controls.Add(this.pbCodigo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(270, 238);
            this.MinimumSize = new System.Drawing.Size(270, 238);
            this.Name = "frmCodigoBarra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Codigo de Barra";
            this.Load += new System.EventHandler(this.frmCodigoBarra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCodigo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnIMprimir;
        public System.Windows.Forms.PictureBox pbCodigo;
    }
}
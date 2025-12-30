namespace SERINSI_PC.Formularios.Contabilidad
{
    partial class frmBaseLibroDiario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseLibroDiario));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBaseCajaMenor = new System.Windows.Forms.TextBox();
            this.txtBaseBanco = new System.Windows.Forms.TextBox();
            this.btnCargarBAse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base Caja Menor";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Base Banco";
            // 
            // txtBaseCajaMenor
            // 
            this.txtBaseCajaMenor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBaseCajaMenor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBaseCajaMenor.Location = new System.Drawing.Point(14, 32);
            this.txtBaseCajaMenor.Name = "txtBaseCajaMenor";
            this.txtBaseCajaMenor.Size = new System.Drawing.Size(210, 26);
            this.txtBaseCajaMenor.TabIndex = 2;
            this.txtBaseCajaMenor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBaseCajaMenor_KeyPress);
            // 
            // txtBaseBanco
            // 
            this.txtBaseBanco.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBaseBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBaseBanco.Location = new System.Drawing.Point(14, 84);
            this.txtBaseBanco.Name = "txtBaseBanco";
            this.txtBaseBanco.Size = new System.Drawing.Size(210, 26);
            this.txtBaseBanco.TabIndex = 3;
            this.txtBaseBanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBaseBanco_KeyPress);
            // 
            // btnCargarBAse
            // 
            this.btnCargarBAse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCargarBAse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarBAse.Location = new System.Drawing.Point(44, 116);
            this.btnCargarBAse.Name = "btnCargarBAse";
            this.btnCargarBAse.Size = new System.Drawing.Size(150, 48);
            this.btnCargarBAse.TabIndex = 4;
            this.btnCargarBAse.Text = "Cargar Base";
            this.btnCargarBAse.UseVisualStyleBackColor = true;
            this.btnCargarBAse.Click += new System.EventHandler(this.btnCargarBAse_Click);
            // 
            // frmBaseLibroDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 177);
            this.Controls.Add(this.btnCargarBAse);
            this.Controls.Add(this.txtBaseBanco);
            this.Controls.Add(this.txtBaseCajaMenor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(251, 216);
            this.MinimumSize = new System.Drawing.Size(251, 216);
            this.Name = "frmBaseLibroDiario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Base Libro Diario";
            this.Load += new System.EventHandler(this.frmBaseLibroDiario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBaseCajaMenor;
        private System.Windows.Forms.TextBox txtBaseBanco;
        private System.Windows.Forms.Button btnCargarBAse;
    }
}
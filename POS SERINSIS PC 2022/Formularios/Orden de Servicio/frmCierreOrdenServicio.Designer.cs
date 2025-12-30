namespace SERINSI_PC.Formularios.Orden_de_Servicio
{
    partial class frmCierreOrdenServicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCierreOrdenServicio));
            this.label1 = new System.Windows.Forms.Label();
            this.btnRetirarArticulo = new System.Windows.Forms.Button();
            this.btnFacturarOrden = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "A continuación, selecciono la opción que desea";
            // 
            // btnRetirarArticulo
            // 
            this.btnRetirarArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirarArticulo.Location = new System.Drawing.Point(98, 65);
            this.btnRetirarArticulo.Name = "btnRetirarArticulo";
            this.btnRetirarArticulo.Size = new System.Drawing.Size(204, 36);
            this.btnRetirarArticulo.TabIndex = 1;
            this.btnRetirarArticulo.Text = "Retirar Articulo";
            this.btnRetirarArticulo.UseVisualStyleBackColor = true;
            this.btnRetirarArticulo.Click += new System.EventHandler(this.btnRetirarArticulo_Click);
            // 
            // btnFacturarOrden
            // 
            this.btnFacturarOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturarOrden.Location = new System.Drawing.Point(98, 131);
            this.btnFacturarOrden.Name = "btnFacturarOrden";
            this.btnFacturarOrden.Size = new System.Drawing.Size(204, 36);
            this.btnFacturarOrden.TabIndex = 2;
            this.btnFacturarOrden.Text = "Facturar Orden";
            this.btnFacturarOrden.UseVisualStyleBackColor = true;
            this.btnFacturarOrden.Click += new System.EventHandler(this.btnFacturarOrden_Click);
            // 
            // frmCierreOrdenServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 191);
            this.Controls.Add(this.btnFacturarOrden);
            this.Controls.Add(this.btnRetirarArticulo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(429, 230);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(429, 230);
            this.Name = "frmCierreOrdenServicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cierre de Orden";
            this.Load += new System.EventHandler(this.frmCierreOrdenServicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRetirarArticulo;
        private System.Windows.Forms.Button btnFacturarOrden;
    }
}
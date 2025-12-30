namespace SERINSI_PC.Formularios.Inventario
{
    partial class frmCostoPrecios
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
            this.txtProducido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPOrcentaje = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgCostos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idListaPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreLista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aproximado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbAgregarLista = new System.Windows.Forms.LinkLabel();
            this.cmbListaPrecios = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.tituloFormulario = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.cbAproxomar = new System.Windows.Forms.CheckBox();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancularPrecio = new System.Windows.Forms.LinkLabel();
            this.btnCalcularPorcentage = new System.Windows.Forms.LinkLabel();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgCostos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProducido
            // 
            this.txtProducido.Enabled = false;
            this.txtProducido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducido.Location = new System.Drawing.Point(380, 53);
            this.txtProducido.Name = "txtProducido";
            this.txtProducido.Size = new System.Drawing.Size(97, 22);
            this.txtProducido.TabIndex = 66;
            this.txtProducido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProducido_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(377, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 18);
            this.label5.TabIndex = 65;
            this.label5.Text = "Ganancia";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(486, 53);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(115, 22);
            this.txtPrecio.TabIndex = 64;
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(483, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 63;
            this.label4.Text = "Precio";
            // 
            // txtPOrcentaje
            // 
            this.txtPOrcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPOrcentaje.Location = new System.Drawing.Point(294, 53);
            this.txtPOrcentaje.Name = "txtPOrcentaje";
            this.txtPOrcentaje.Size = new System.Drawing.Size(80, 22);
            this.txtPOrcentaje.TabIndex = 62;
            this.txtPOrcentaje.TextChanged += new System.EventHandler(this.txtPOrcentaje_TextChanged);
            this.txtPOrcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPOrcentaje_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(291, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 18);
            this.label3.TabIndex = 61;
            this.label3.Text = "%";
            // 
            // txtCosto
            // 
            this.txtCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Location = new System.Drawing.Point(188, 53);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(100, 22);
            this.txtCosto.TabIndex = 60;
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCosto_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(185, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 18);
            this.label2.TabIndex = 59;
            this.label2.Text = "Costo";
            // 
            // dgCostos
            // 
            this.dgCostos.AllowUserToAddRows = false;
            this.dgCostos.AllowUserToDeleteRows = false;
            this.dgCostos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCostos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCostos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCostos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCostos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idInventario,
            this.idListaPrecio,
            this.nombreLista,
            this.costo,
            this.porcentaje,
            this.precio,
            this.producido,
            this.porcentajeIva,
            this.aproximado});
            this.dgCostos.Location = new System.Drawing.Point(15, 133);
            this.dgCostos.Name = "dgCostos";
            this.dgCostos.ReadOnly = true;
            this.dgCostos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCostos.Size = new System.Drawing.Size(586, 260);
            this.dgCostos.TabIndex = 58;
            this.dgCostos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCostos_CellClick);
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
            // idInventario
            // 
            this.idInventario.DataPropertyName = "idInventario";
            this.idInventario.HeaderText = "idInventario";
            this.idInventario.Name = "idInventario";
            this.idInventario.ReadOnly = true;
            this.idInventario.Visible = false;
            this.idInventario.Width = 107;
            // 
            // idListaPrecio
            // 
            this.idListaPrecio.DataPropertyName = "idListaPrecio";
            this.idListaPrecio.HeaderText = "idListaPrecio";
            this.idListaPrecio.Name = "idListaPrecio";
            this.idListaPrecio.ReadOnly = true;
            this.idListaPrecio.Visible = false;
            this.idListaPrecio.Width = 116;
            // 
            // nombreLista
            // 
            this.nombreLista.DataPropertyName = "nombreLista";
            this.nombreLista.HeaderText = "Lista Precios";
            this.nombreLista.Name = "nombreLista";
            this.nombreLista.ReadOnly = true;
            this.nombreLista.Width = 106;
            // 
            // costo
            // 
            this.costo.DataPropertyName = "costo";
            dataGridViewCellStyle2.Format = "C0";
            dataGridViewCellStyle2.NullValue = null;
            this.costo.DefaultCellStyle = dataGridViewCellStyle2;
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            this.costo.Width = 68;
            // 
            // porcentaje
            // 
            this.porcentaje.DataPropertyName = "porcentaje";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.porcentaje.DefaultCellStyle = dataGridViewCellStyle3;
            this.porcentaje.HeaderText = "%";
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.ReadOnly = true;
            this.porcentaje.Width = 44;
            // 
            // precio
            // 
            this.precio.DataPropertyName = "precio";
            dataGridViewCellStyle4.Format = "C0";
            this.precio.DefaultCellStyle = dataGridViewCellStyle4;
            this.precio.HeaderText = "Venta";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Width = 68;
            // 
            // producido
            // 
            this.producido.DataPropertyName = "producido";
            dataGridViewCellStyle5.Format = "C0";
            this.producido.DefaultCellStyle = dataGridViewCellStyle5;
            this.producido.HeaderText = "Gaancia";
            this.producido.Name = "producido";
            this.producido.ReadOnly = true;
            this.producido.Width = 85;
            // 
            // porcentajeIva
            // 
            this.porcentajeIva.DataPropertyName = "porcentajeIva";
            dataGridViewCellStyle6.Format = "N2";
            this.porcentajeIva.DefaultCellStyle = dataGridViewCellStyle6;
            this.porcentajeIva.HeaderText = "% Iva";
            this.porcentajeIva.Name = "porcentajeIva";
            this.porcentajeIva.ReadOnly = true;
            this.porcentajeIva.Width = 61;
            // 
            // aproximado
            // 
            this.aproximado.DataPropertyName = "aproximado";
            this.aproximado.HeaderText = "aproximado";
            this.aproximado.Name = "aproximado";
            this.aproximado.ReadOnly = true;
            this.aproximado.Visible = false;
            this.aproximado.Width = 108;
            // 
            // lbAgregarLista
            // 
            this.lbAgregarLista.AutoSize = true;
            this.lbAgregarLista.Location = new System.Drawing.Point(12, 80);
            this.lbAgregarLista.Name = "lbAgregarLista";
            this.lbAgregarLista.Size = new System.Drawing.Size(69, 13);
            this.lbAgregarLista.TabIndex = 57;
            this.lbAgregarLista.TabStop = true;
            this.lbAgregarLista.Text = "Agregar Lista";
            this.lbAgregarLista.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbAgregarLista_LinkClicked);
            // 
            // cmbListaPrecios
            // 
            this.cmbListaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListaPrecios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbListaPrecios.FormattingEnabled = true;
            this.cmbListaPrecios.Location = new System.Drawing.Point(15, 53);
            this.cmbListaPrecios.Name = "cmbListaPrecios";
            this.cmbListaPrecios.Size = new System.Drawing.Size(163, 24);
            this.cmbListaPrecios.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 55;
            this.label1.Text = "Lista Precios";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.tituloFormulario);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 23);
            this.panel1.TabIndex = 54;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Location = new System.Drawing.Point(568, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(23, 23);
            this.btnMinimizar.TabIndex = 27;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            // 
            // tituloFormulario
            // 
            this.tituloFormulario.AutoSize = true;
            this.tituloFormulario.Dock = System.Windows.Forms.DockStyle.Left;
            this.tituloFormulario.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
            this.tituloFormulario.ForeColor = System.Drawing.Color.White;
            this.tituloFormulario.Location = new System.Drawing.Point(0, 0);
            this.tituloFormulario.Name = "tituloFormulario";
            this.tituloFormulario.Size = new System.Drawing.Size(24, 18);
            this.tituloFormulario.TabIndex = 11;
            this.tituloFormulario.Text = "--";
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
            this.btnCerrar.Location = new System.Drawing.Point(591, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(23, 23);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // cbAproxomar
            // 
            this.cbAproxomar.AutoSize = true;
            this.cbAproxomar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAproxomar.Location = new System.Drawing.Point(15, 108);
            this.cbAproxomar.Name = "cbAproxomar";
            this.cbAproxomar.Size = new System.Drawing.Size(136, 19);
            this.cbAproxomar.TabIndex = 73;
            this.cbAproxomar.Text = "Aproximar Precio";
            this.cbAproxomar.UseVisualStyleBackColor = true;
            this.cbAproxomar.CheckedChanged += new System.EventHandler(this.cbAproxomar_CheckedChanged);
            // 
            // txtIva
            // 
            this.txtIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIva.Location = new System.Drawing.Point(188, 104);
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(100, 22);
            this.txtIva.TabIndex = 75;
            this.txtIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIva_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(185, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 18);
            this.label6.TabIndex = 74;
            this.label6.Text = "% Iva";
            // 
            // btnCancularPrecio
            // 
            this.btnCancularPrecio.AutoSize = true;
            this.btnCancularPrecio.Location = new System.Drawing.Point(553, 37);
            this.btnCancularPrecio.Name = "btnCancularPrecio";
            this.btnCancularPrecio.Size = new System.Drawing.Size(45, 13);
            this.btnCancularPrecio.TabIndex = 76;
            this.btnCancularPrecio.TabStop = true;
            this.btnCancularPrecio.Text = "Calcular";
            this.btnCancularPrecio.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCancularPrecio_LinkClicked);
            // 
            // btnCalcularPorcentage
            // 
            this.btnCalcularPorcentage.AutoSize = true;
            this.btnCalcularPorcentage.Location = new System.Drawing.Point(326, 37);
            this.btnCalcularPorcentage.Name = "btnCalcularPorcentage";
            this.btnCalcularPorcentage.Size = new System.Drawing.Size(45, 13);
            this.btnCalcularPorcentage.TabIndex = 77;
            this.btnCalcularPorcentage.TabStop = true;
            this.btnCalcularPorcentage.Text = "Calcular";
            this.btnCalcularPorcentage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCalcularPorcentage_LinkClicked);
            // 
            // btnGuardar
            // 
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnGuardar.IconColor = System.Drawing.Color.Black;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.Location = new System.Drawing.Point(486, 87);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(114, 38);
            this.btnGuardar.TabIndex = 78;
            this.btnGuardar.Text = "iconButton1";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnEliminar.IconColor = System.Drawing.Color.Black;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.Location = new System.Drawing.Point(353, 83);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(82, 26);
            this.btnEliminar.TabIndex = 79;
            this.btnEliminar.Text = "iconButton2";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // frmCostoPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(614, 399);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCalcularPorcentage);
            this.Controls.Add(this.btnCancularPrecio);
            this.Controls.Add(this.txtIva);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbAproxomar);
            this.Controls.Add(this.txtProducido);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPOrcentaje);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgCostos);
            this.Controls.Add(this.lbAgregarLista);
            this.Controls.Add(this.cmbListaPrecios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(614, 399);
            this.MinimumSize = new System.Drawing.Size(614, 399);
            this.Name = "frmCostoPrecios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCostoPrecios";
            this.Load += new System.EventHandler(this.frmCostoPrecios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCostos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProducido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPOrcentaje;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgCostos;
        private System.Windows.Forms.LinkLabel lbAgregarLista;
        private System.Windows.Forms.ComboBox cmbListaPrecios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMinimizar;
        public System.Windows.Forms.Label tituloFormulario;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.CheckBox cbAproxomar;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel btnCancularPrecio;
        private System.Windows.Forms.LinkLabel btnCalcularPorcentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idListaPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn producido;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn aproximado;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnEliminar;
    }
}
namespace SistemaGym.Formularios
{
    partial class FrmPagos
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
            lblMonto = new Label();
            txtMonto = new TextBox();
            lblMembresia = new Label();
            lblSocio = new Label();
            cmbMembresia = new ComboBox();
            cmbSocio = new ComboBox();
            dgvPagos = new DataGridView();
            btnGuardar = new Button();
            btnAnular = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            SuspendLayout();
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(243, 184);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(54, 19);
            lblMonto.TabIndex = 0;
            lblMonto.Text = "Monto:";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(355, 181);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(100, 26);
            txtMonto.TabIndex = 1;
            // 
            // lblMembresia
            // 
            lblMembresia.AutoSize = true;
            lblMembresia.Location = new Point(243, 237);
            lblMembresia.Name = "lblMembresia";
            lblMembresia.Size = new Size(77, 19);
            lblMembresia.TabIndex = 2;
            lblMembresia.Text = "Membresia";
            // 
            // lblSocio
            // 
            lblSocio.AutoSize = true;
            lblSocio.Location = new Point(243, 289);
            lblSocio.Name = "lblSocio";
            lblSocio.Size = new Size(41, 19);
            lblSocio.TabIndex = 3;
            lblSocio.Text = "Socio";
            // 
            // cmbMembresia
            // 
            cmbMembresia.FormattingEnabled = true;
            cmbMembresia.Location = new Point(355, 229);
            cmbMembresia.Name = "cmbMembresia";
            cmbMembresia.Size = new Size(121, 27);
            cmbMembresia.TabIndex = 4;
            cmbMembresia.SelectedIndexChanged += cmbMembresia_SelectedIndexChanged_1;
            // 
            // cmbSocio
            // 
            cmbSocio.FormattingEnabled = true;
            cmbSocio.Location = new Point(355, 281);
            cmbSocio.Name = "cmbSocio";
            cmbSocio.Size = new Size(121, 27);
            cmbSocio.TabIndex = 5;
            // 
            // dgvPagos
            // 
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(175, 28);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.Size = new Size(423, 129);
            dgvPagos.TabIndex = 6;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(150, 389);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnAnular
            // 
            btnAnular.Location = new Point(323, 389);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(75, 23);
            btnAnular.TabIndex = 8;
            btnAnular.Text = "Anular";
            btnAnular.UseVisualStyleBackColor = true;
            btnAnular.Click += btnAnular_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(492, 389);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 9;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FrmPagos
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCerrar);
            Controls.Add(btnAnular);
            Controls.Add(btnGuardar);
            Controls.Add(dgvPagos);
            Controls.Add(cmbSocio);
            Controls.Add(cmbMembresia);
            Controls.Add(lblSocio);
            Controls.Add(lblMembresia);
            Controls.Add(txtMonto);
            Controls.Add(lblMonto);
            Name = "FrmPagos";
            Text = "FrmPagos";
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMonto;
        private TextBox txtMonto;
        private Label lblMembresia;
        private Label lblSocio;
        private ComboBox cmbMembresia;
        private ComboBox cmbSocio;
        private DataGridView dgvPagos;
        private Button btnGuardar;
        private Button btnAnular;
        private Button btnCerrar;
    }
}
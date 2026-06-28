namespace SistemaGym.Formularios
{
    partial class FrmInscripciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInscripciones));
            btnCerrar = new Button();
            btnDesactivar = new Button();
            btnGuardar = new Button();
            dgvInscripciones = new DataGridView();
            cmbSocio = new ComboBox();
            cmbClase = new ComboBox();
            lblSocio = new Label();
            lblClase = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).BeginInit();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(606, 394);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 19;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnDesactivar
            // 
            btnDesactivar.Location = new Point(437, 394);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(75, 23);
            btnDesactivar.TabIndex = 18;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = true;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(264, 394);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 17;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // dgvInscripciones
            // 
            dgvInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInscripciones.Location = new Point(23, 12);
            dgvInscripciones.Name = "dgvInscripciones";
            dgvInscripciones.Size = new Size(408, 314);
            dgvInscripciones.TabIndex = 16;
            // 
            // cmbSocio
            // 
            cmbSocio.FormattingEnabled = true;
            cmbSocio.Location = new Point(606, 210);
            cmbSocio.Name = "cmbSocio";
            cmbSocio.Size = new Size(121, 27);
            cmbSocio.TabIndex = 15;
            // 
            // cmbClase
            // 
            cmbClase.FormattingEnabled = true;
            cmbClase.Location = new Point(606, 158);
            cmbClase.Name = "cmbClase";
            cmbClase.Size = new Size(121, 27);
            cmbClase.TabIndex = 14;
            // 
            // lblSocio
            // 
            lblSocio.AutoSize = true;
            lblSocio.Location = new Point(494, 218);
            lblSocio.Name = "lblSocio";
            lblSocio.Size = new Size(41, 19);
            lblSocio.TabIndex = 13;
            lblSocio.Text = "Socio";
            // 
            // lblClase
            // 
            lblClase.AutoSize = true;
            lblClase.Location = new Point(494, 166);
            lblClase.Name = "lblClase";
            lblClase.Size = new Size(44, 19);
            lblClase.TabIndex = 12;
            lblClase.Text = "Clase:";
            // 
            // FrmInscripciones
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCerrar);
            Controls.Add(btnDesactivar);
            Controls.Add(btnGuardar);
            Controls.Add(dgvInscripciones);
            Controls.Add(cmbSocio);
            Controls.Add(cmbClase);
            Controls.Add(lblSocio);
            Controls.Add(lblClase);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmInscripciones";
            Text = "FrmInscripciones";
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCerrar;
        private Button btnDesactivar;
        private Button btnGuardar;
        private DataGridView dgvInscripciones;
        private ComboBox cmbSocio;
        private ComboBox cmbClase;
        private Label lblSocio;
        private Label lblClase;
    }
}
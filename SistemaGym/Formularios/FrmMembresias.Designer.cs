namespace SistemaGym.Formularios
{
    partial class FrmMembresias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMembresias));
            dgvMembresias = new DataGridView();
            lblNombre = new Label();
            txtNombre = new TextBox();
            btnGuardar = new Button();
            btnCerrar = new Button();
            txtDuracion = new TextBox();
            lblDuracion = new Label();
            txtPrecio = new TextBox();
            lblPrecio = new Label();
            btnDesactivar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).BeginInit();
            SuspendLayout();
            // 
            // dgvMembresias
            // 
            dgvMembresias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembresias.Location = new Point(159, -1);
            dgvMembresias.Name = "dgvMembresias";
            dgvMembresias.Size = new Size(426, 150);
            dgvMembresias.TabIndex = 0;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(252, 209);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(59, 19);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(345, 205);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 26);
            txtNombre.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(172, 396);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(431, 396);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // txtDuracion
            // 
            txtDuracion.Location = new Point(345, 265);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.Size = new Size(100, 26);
            txtDuracion.TabIndex = 6;
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Location = new Point(252, 268);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(64, 19);
            lblDuracion.TabIndex = 5;
            lblDuracion.Text = "Duracion";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(345, 321);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 26);
            txtPrecio.TabIndex = 8;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(252, 324);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(46, 19);
            lblPrecio.TabIndex = 7;
            lblPrecio.Text = "Precio";
            // 
            // btnDesactivar
            // 
            btnDesactivar.Location = new Point(299, 396);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(75, 23);
            btnDesactivar.TabIndex = 9;
            btnDesactivar.Text = "Dar de Baja";
            btnDesactivar.UseVisualStyleBackColor = true;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // FrmMembresias
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDesactivar);
            Controls.Add(txtPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(txtDuracion);
            Controls.Add(lblDuracion);
            Controls.Add(btnCerrar);
            Controls.Add(btnGuardar);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(dgvMembresias);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMembresias";
            Text = "FrmMembresias";
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMembresias;
        private Label lblNombre;
        private TextBox txtNombre;
        private Button btnGuardar;
        private Button btnCerrar;
        private TextBox txtDuracion;
        private Label lblDuracion;
        private TextBox txtPrecio;
        private Label lblPrecio;
        private Button btnDesactivar;
    }
}
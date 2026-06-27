namespace SistemaGym.Formularios
{
    partial class FrmEntrenadores
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            btnCerrar = new Button();
            cmbTurno = new ComboBox();
            txtTelefono = new TextBox();
            lblEspecialidad = new Label();
            lblTelefono = new Label();
            txtEspecialidad = new TextBox();
            label4 = new Label();
            lblTurno = new Label();
            btnGuardar = new Button();
            dgvEntrenadores = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvEntrenadores).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(233, 171);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(59, 19);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(348, 171);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 26);
            txtNombre.TabIndex = 1;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(195, 415);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // cmbTurno
            // 
            cmbTurno.FormattingEnabled = true;
            cmbTurno.Location = new Point(348, 345);
            cmbTurno.Name = "cmbTurno";
            cmbTurno.Size = new Size(121, 27);
            cmbTurno.TabIndex = 3;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(348, 284);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 26);
            txtTelefono.TabIndex = 5;
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Location = new Point(233, 225);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(82, 19);
            lblEspecialidad.TabIndex = 4;
            lblEspecialidad.Text = "Especialidad";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(233, 284);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(60, 19);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Telefono";
            // 
            // txtEspecialidad
            // 
            txtEspecialidad.Location = new Point(348, 222);
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.Size = new Size(100, 26);
            txtEspecialidad.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(233, 345);
            label4.Name = "label4";
            label4.Size = new Size(0, 19);
            label4.TabIndex = 8;
            // 
            // lblTurno
            // 
            lblTurno.AutoSize = true;
            lblTurno.Location = new Point(233, 345);
            lblTurno.Name = "lblTurno";
            lblTurno.Size = new Size(56, 19);
            lblTurno.TabIndex = 10;
            lblTurno.Text = "Turno : ";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(432, 415);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // dgvEntrenadores
            // 
            dgvEntrenadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntrenadores.Location = new Point(149, 12);
            dgvEntrenadores.Name = "dgvEntrenadores";
            dgvEntrenadores.Size = new Size(438, 130);
            dgvEntrenadores.TabIndex = 13;
            // 
            // FrmEntrenadores
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvEntrenadores);
            Controls.Add(btnGuardar);
            Controls.Add(lblTurno);
            Controls.Add(txtEspecialidad);
            Controls.Add(label4);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblEspecialidad);
            Controls.Add(cmbTurno);
            Controls.Add(btnCerrar);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Name = "FrmEntrenadores";
            Text = "Entrenadores";
            ((System.ComponentModel.ISupportInitialize)dgvEntrenadores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtNombre;
        private Button btnCerrar;
        private ComboBox cmbTurno;
        private TextBox txtTelefono;
        private Label lblEspecialidad;
        private Label lblTelefono;
        private TextBox txtEspecialidad;
        private Label label4;
        private Label lblTurno;
        private Button btnGuardar;
        private DataGridView dgvEntrenadores;
    }
}
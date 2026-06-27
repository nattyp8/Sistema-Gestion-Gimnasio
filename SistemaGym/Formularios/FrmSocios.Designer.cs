namespace SistemaGym.Formularios
{
    partial class FrmSocios
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
            dgvSocios = new DataGridView();
            btnGuardar = new Button();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtCedula = new TextBox();
            lblCedula = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtCorreo = new TextBox();
            lblCorreo = new Label();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(166, 199);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(59, 19);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(245, 199);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 26);
            txtNombre.TabIndex = 1;
            // 
            // dgvSocios
            // 
            dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSocios.Location = new Point(152, 12);
            dgvSocios.Name = "dgvSocios";
            dgvSocios.Size = new Size(423, 150);
            dgvSocios.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(245, 396);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(463, 199);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 26);
            txtApellido.TabIndex = 5;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(396, 202);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(58, 19);
            lblApellido.TabIndex = 4;
            lblApellido.Text = "Apellido";
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(245, 254);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(100, 26);
            txtCedula.TabIndex = 7;
            // 
            // lblCedula
            // 
            lblCedula.AutoSize = true;
            lblCedula.Location = new Point(166, 261);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(51, 19);
            lblCedula.TabIndex = 6;
            lblCedula.Text = "Cedula";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(473, 244);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 26);
            txtTelefono.TabIndex = 9;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(396, 251);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(71, 19);
            lblTelefono.TabIndex = 8;
            lblTelefono.Text = "Telefono : ";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(245, 326);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(100, 26);
            txtCorreo.TabIndex = 11;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(166, 326);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(58, 19);
            lblCorreo.TabIndex = 10;
            lblCorreo.Text = "Correo :";
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(422, 396);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 12;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click_1;
            // 
            // FrmSocios
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCerrar);
            Controls.Add(txtCorreo);
            Controls.Add(lblCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtCedula);
            Controls.Add(lblCedula);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(btnGuardar);
            Controls.Add(dgvSocios);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Name = "FrmSocios";
            Text = "FrmSocios";
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtNombre;
        private DataGridView dgvSocios;
        private Button btnGuardar;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtCedula;
        private Label lblCedula;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtCorreo;
        private Label lblCorreo;
        private Button btnCerrar;
    }
}
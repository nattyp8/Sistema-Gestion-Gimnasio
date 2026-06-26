namespace SistemaGym.Formularios
{
    partial class FrmLogin
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
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            lblContraseña = new Label();
            txtContrasena = new TextBox();
            btnIngresar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(380, 99);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(132, 26);
            txtUsuario.TabIndex = 0;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(238, 99);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(56, 19);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Location = new Point(238, 189);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(79, 19);
            lblContraseña.TabIndex = 3;
            lblContraseña.Text = "Contraseña";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(380, 189);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(132, 26);
            txtContrasena.TabIndex = 2;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(238, 289);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(107, 35);
            btnIngresar.TabIndex = 4;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(405, 289);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(107, 35);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnIngresar);
            Controls.Add(lblContraseña);
            Controls.Add(txtContrasena);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Name = "FrmLogin";
            Text = "FrmLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsuario;
        private Label lblUsuario;
        private Label lblContraseña;
        private TextBox txtContrasena;
        private Button btnIngresar;
        private Button btnSalir;
    }
}
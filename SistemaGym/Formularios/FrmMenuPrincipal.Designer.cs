namespace SistemaGym.Formularios
{
    partial class FrmMenuPrincipal
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
            btnSocios = new Button();
            bntEntrenadores = new Button();
            SuspendLayout();
            // 
            // btnSocios
            // 
            btnSocios.Location = new Point(248, 57);
            btnSocios.Name = "btnSocios";
            btnSocios.Size = new Size(169, 49);
            btnSocios.TabIndex = 0;
            btnSocios.Text = "Gestion de socios";
            btnSocios.UseVisualStyleBackColor = true;
            btnSocios.Click += btnSocios_Click;
            // 
            // bntEntrenadores
            // 
            bntEntrenadores.Location = new Point(248, 160);
            bntEntrenadores.Name = "bntEntrenadores";
            bntEntrenadores.Size = new Size(169, 49);
            bntEntrenadores.TabIndex = 1;
            bntEntrenadores.Text = "Gestion de entrenadores";
            bntEntrenadores.UseVisualStyleBackColor = true;
            bntEntrenadores.Click += bntEntrenadores_Click;
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bntEntrenadores);
            Controls.Add(btnSocios);
            Name = "FrmMenuPrincipal";
            Text = "Sistema de Gestión de Gimnasio";
            ResumeLayout(false);
        }

        #endregion

        private Button btnSocios;
        private Button bntEntrenadores;
    }
}
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
            btnMembresias = new Button();
            btnClases = new Button();
            btnPagos = new Button();
            btnInscripcion = new Button();
            SuspendLayout();
            // 
            // btnSocios
            // 
            btnSocios.Location = new Point(136, 41);
            btnSocios.Name = "btnSocios";
            btnSocios.Size = new Size(169, 49);
            btnSocios.TabIndex = 0;
            btnSocios.Text = "Gestion de socios";
            btnSocios.UseVisualStyleBackColor = true;
            btnSocios.Click += btnSocios_Click;
            // 
            // bntEntrenadores
            // 
            bntEntrenadores.Location = new Point(136, 122);
            bntEntrenadores.Name = "bntEntrenadores";
            bntEntrenadores.Size = new Size(169, 49);
            bntEntrenadores.TabIndex = 1;
            bntEntrenadores.Text = "Gestion de entrenadores";
            bntEntrenadores.UseVisualStyleBackColor = true;
            bntEntrenadores.Click += bntEntrenadores_Click;
            // 
            // btnMembresias
            // 
            btnMembresias.Location = new Point(136, 198);
            btnMembresias.Name = "btnMembresias";
            btnMembresias.Size = new Size(169, 49);
            btnMembresias.TabIndex = 2;
            btnMembresias.Text = "Gestion de Membresias";
            btnMembresias.UseVisualStyleBackColor = true;
            btnMembresias.Click += btnMembresias_Click;
            // 
            // btnClases
            // 
            btnClases.Location = new Point(136, 272);
            btnClases.Name = "btnClases";
            btnClases.Size = new Size(169, 49);
            btnClases.TabIndex = 3;
            btnClases.Text = "Gestion de Clases";
            btnClases.UseVisualStyleBackColor = true;
            btnClases.Click += btnClases_Click;
            // 
            // btnPagos
            // 
            btnPagos.Location = new Point(433, 41);
            btnPagos.Name = "btnPagos";
            btnPagos.Size = new Size(169, 49);
            btnPagos.TabIndex = 4;
            btnPagos.Text = "Gestion de pagos";
            btnPagos.UseVisualStyleBackColor = true;
            btnPagos.Click += btnPagos_Click;
            // 
            // btnInscripcion
            // 
            btnInscripcion.Location = new Point(433, 122);
            btnInscripcion.Name = "btnInscripcion";
            btnInscripcion.Size = new Size(169, 49);
            btnInscripcion.TabIndex = 5;
            btnInscripcion.Text = "Gestion de inscripciones";
            btnInscripcion.UseVisualStyleBackColor = true;
            btnInscripcion.Click += btnInscripcion_Click;
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnInscripcion);
            Controls.Add(btnPagos);
            Controls.Add(btnClases);
            Controls.Add(btnMembresias);
            Controls.Add(bntEntrenadores);
            Controls.Add(btnSocios);
            Name = "FrmMenuPrincipal";
            Text = "Sistema de Gestión de Gimnasio";
            ResumeLayout(false);
        }

        #endregion

        private Button btnSocios;
        private Button bntEntrenadores;
        private Button btnMembresias;
        private Button btnClases;
        private Button btnPagos;
        private Button btnInscripcion;
    }
}
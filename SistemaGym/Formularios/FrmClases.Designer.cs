namespace SistemaGym.Formularios
{
    partial class FrmClases
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
            lblNombreClase = new Label();
            txtNombreClase = new TextBox();
            txtCupo = new TextBox();
            lblCupo = new Label();
            txtHorario = new TextBox();
            lblHorario = new Label();
            txtDiasSemana = new TextBox();
            lblDiasSemana = new Label();
            dgvClases = new DataGridView();
            cmbEntrenador = new ComboBox();
            lblEntrenador = new Label();
            btnGuardar = new Button();
            btnCerrar = new Button();
            btnDesactivar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClases).BeginInit();
            SuspendLayout();
            // 
            // lblNombreClase
            // 
            lblNombreClase.AutoSize = true;
            lblNombreClase.Location = new Point(21, 75);
            lblNombreClase.Name = "lblNombreClase";
            lblNombreClase.Size = new Size(91, 19);
            lblNombreClase.TabIndex = 0;
            lblNombreClase.Text = "NombreClase";
            // 
            // txtNombreClase
            // 
            txtNombreClase.Location = new Point(133, 68);
            txtNombreClase.Name = "txtNombreClase";
            txtNombreClase.Size = new Size(100, 26);
            txtNombreClase.TabIndex = 1;
            // 
            // txtCupo
            // 
            txtCupo.Location = new Point(133, 113);
            txtCupo.Name = "txtCupo";
            txtCupo.Size = new Size(100, 26);
            txtCupo.TabIndex = 3;
            // 
            // lblCupo
            // 
            lblCupo.AutoSize = true;
            lblCupo.Location = new Point(55, 113);
            lblCupo.Name = "lblCupo";
            lblCupo.Size = new Size(39, 19);
            lblCupo.TabIndex = 2;
            lblCupo.Text = "cupo";
            // 
            // txtHorario
            // 
            txtHorario.Location = new Point(133, 163);
            txtHorario.Name = "txtHorario";
            txtHorario.Size = new Size(100, 26);
            txtHorario.TabIndex = 5;
            // 
            // lblHorario
            // 
            lblHorario.AutoSize = true;
            lblHorario.Location = new Point(55, 166);
            lblHorario.Name = "lblHorario";
            lblHorario.Size = new Size(53, 19);
            lblHorario.TabIndex = 4;
            lblHorario.Text = "horario";
            // 
            // txtDiasSemana
            // 
            txtDiasSemana.Location = new Point(133, 215);
            txtDiasSemana.Name = "txtDiasSemana";
            txtDiasSemana.Size = new Size(100, 26);
            txtDiasSemana.TabIndex = 7;
            // 
            // lblDiasSemana
            // 
            lblDiasSemana.AutoSize = true;
            lblDiasSemana.Location = new Point(55, 222);
            lblDiasSemana.Name = "lblDiasSemana";
            lblDiasSemana.Size = new Size(117, 19);
            lblDiasSemana.TabIndex = 6;
            lblDiasSemana.Text = "dias de la semana";
            // 
            // dgvClases
            // 
            dgvClases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClases.Location = new Point(310, 68);
            dgvClases.Name = "dgvClases";
            dgvClases.Size = new Size(426, 192);
            dgvClases.TabIndex = 8;
            // 
            // cmbEntrenador
            // 
            cmbEntrenador.FormattingEnabled = true;
            cmbEntrenador.Location = new Point(133, 278);
            cmbEntrenador.Name = "cmbEntrenador";
            cmbEntrenador.Size = new Size(121, 27);
            cmbEntrenador.TabIndex = 9;
            // 
            // lblEntrenador
            // 
            lblEntrenador.AutoSize = true;
            lblEntrenador.Location = new Point(35, 286);
            lblEntrenador.Name = "lblEntrenador";
            lblEntrenador.Size = new Size(77, 19);
            lblEntrenador.TabIndex = 10;
            lblEntrenador.Text = "entrenador";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(179, 398);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(554, 398);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 12;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnDesactivar
            // 
            btnDesactivar.Location = new Point(357, 398);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(130, 23);
            btnDesactivar.TabIndex = 13;
            btnDesactivar.Text = "Dar de Baja";
            btnDesactivar.UseVisualStyleBackColor = true;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // FrmClases
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDesactivar);
            Controls.Add(btnCerrar);
            Controls.Add(btnGuardar);
            Controls.Add(lblEntrenador);
            Controls.Add(cmbEntrenador);
            Controls.Add(dgvClases);
            Controls.Add(txtDiasSemana);
            Controls.Add(lblDiasSemana);
            Controls.Add(txtHorario);
            Controls.Add(lblHorario);
            Controls.Add(txtCupo);
            Controls.Add(lblCupo);
            Controls.Add(txtNombreClase);
            Controls.Add(lblNombreClase);
            Name = "FrmClases";
            Text = "FrmClases";
            ((System.ComponentModel.ISupportInitialize)dgvClases).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreClase;
        private TextBox txtNombreClase;
        private TextBox txtCupo;
        private Label lblCupo;
        private TextBox txtHorario;
        private Label lblHorario;
        private TextBox txtDiasSemana;
        private Label lblDiasSemana;
        private DataGridView dgvClases;
        private ComboBox cmbEntrenador;
        private Label lblEntrenador;
        private Button btnGuardar;
        private Button btnCerrar;
        private Button btnDesactivar;
    }
}
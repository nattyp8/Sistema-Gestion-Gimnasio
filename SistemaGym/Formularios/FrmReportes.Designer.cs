namespace SistemaGym.Formularios
{
    partial class FrmReportes
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
            dgvResumen = new DataGridView();
            dgvDetalles = new DataGridView();
            btnDescargarTxt = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvResumen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // dgvResumen
            // 
            dgvResumen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResumen.Location = new Point(65, 58);
            dgvResumen.Name = "dgvResumen";
            dgvResumen.Size = new Size(258, 284);
            dgvResumen.TabIndex = 0;
            dgvResumen.CellClick += dgvResumen_CellClick;
            // 
            // dgvDetalles
            // 
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(455, 58);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.Size = new Size(313, 284);
            dgvDetalles.TabIndex = 1;
            // 
            // btnDescargarTxt
            // 
            btnDescargarTxt.Location = new Point(312, 380);
            btnDescargarTxt.Name = "btnDescargarTxt";
            btnDescargarTxt.Size = new Size(167, 38);
            btnDescargarTxt.TabIndex = 2;
            btnDescargarTxt.Text = "Descargar Reporte";
            btnDescargarTxt.UseVisualStyleBackColor = true;
            btnDescargarTxt.Click += btnDescargarTxt_Click;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDescargarTxt);
            Controls.Add(dgvDetalles);
            Controls.Add(dgvResumen);
            Name = "FrmReportes";
            Text = "FrmReportes";
            ((System.ComponentModel.ISupportInitialize)dgvResumen).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvResumen;
        private DataGridView dgvDetalles;
        private Button btnDescargarTxt;
    }
}
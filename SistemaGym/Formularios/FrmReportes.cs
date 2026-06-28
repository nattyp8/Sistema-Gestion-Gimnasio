using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SistemaGym.DAO;

namespace SistemaGym.Formularios
{
    public partial class FrmReportes : Form
    {
        private ReporteDAO reporteDAO = new ReporteDAO();
        private List<ResumenReporte> datosResumen;

        public FrmReportes()
        {
            InitializeComponent();
            // FORZAMOS LA CARGA DIRECTA AQUÍ POR SI EL LOAD NO ESTÁ VINCULADO
            CargarResumenGenerales();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            CargarResumenGenerales();
        }

        private void CargarResumenGenerales()
        {
            try
            {
                datosResumen = reporteDAO.ObtenerEstadisticasGenerales();
                dgvResumen.DataSource = null;
                dgvResumen.DataSource = datosResumen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estadísticas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ⚡ CAMBIADO A CELLCLICK: Ahora reacciona al tocar cualquier parte de la celda
        private void dgvResumen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string conceptoSeleccionado = dgvResumen.Rows[e.RowIndex].Cells["Concepto"].Value.ToString();

                try
                {
                    var detalle = reporteDAO.ObtenerDetalleConcepto(conceptoSeleccionado);

                    // IMPORTANTE: Asegurate de usar el nombre exacto de tu grilla derecha
                    dgvDetalles.DataSource = null;
                    dgvDetalles.DataSource = detalle;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDescargarTxt_Click(object sender, EventArgs e)
        {
            if (datosResumen == null || datosResumen.Count == 0)
            {
                MessageBox.Show("No hay datos en el resumen para exportar en este momento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string rutaCarpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ReportesGym");
                if (!Directory.Exists(rutaCarpeta)) Directory.CreateDirectory(rutaCarpeta);

                string rutaCompleta = Path.Combine(rutaCarpeta, $"Cierre_Estadistico_{DateTime.Now:yyyyMMdd}.txt");

                using (StreamWriter writer = new StreamWriter(rutaCompleta))
                {
                    writer.WriteLine("========================================");
                    writer.WriteLine("        REPORTE GERENCIAL GIMNASIO      ");
                    writer.WriteLine("========================================");
                    writer.WriteLine($"Fecha Cierre: {DateTime.Now}");
                    writer.WriteLine("----------------------------------------");

                    foreach (var fila in datosResumen)
                    {
                        writer.WriteLine($"{fila.Concepto,-30} : {fila.Total} personas");
                    }

                    writer.WriteLine("========================================");
                }

                MessageBox.Show($"¡Reporte descargado con éxito!\n\nGuardado en: Documentos\\ReportesGym",
                                "Archivo Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el archivo TXT: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
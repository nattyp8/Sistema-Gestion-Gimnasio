using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaGym.DAO;
using SistemaGym.Entidades;

namespace SistemaGym.Formularios
{
    public partial class FrmMembresias : Form
    {
        private readonly MembresiaDAO membresiaDAO = new MembresiaDAO();

        public FrmMembresias()
        {
            InitializeComponent();
            CargarGrilla(); // Cargamos los planes apenas se abre la ventana
        }

        // Método para cargar el DataGridView
        private void CargarGrilla()
        {
            try
            {
                List<Membresia> lista = membresiaDAO.ListarMembresias();
                dgvMembresias.DataSource = null;
                dgvMembresias.DataSource = lista;

                // Cambiamos los nombres de las columnas para la entrega
                if (dgvMembresias.Columns["IdMembresia"] != null) dgvMembresias.Columns["IdMembresia"].HeaderText = "ID";
                if (dgvMembresias.Columns["DuracionDias"] != null) dgvMembresias.Columns["DuracionDias"].HeaderText = "Duración (Días)";
                if (dgvMembresias.Columns["Precio"] != null) dgvMembresias.Columns["Precio"].DefaultCellStyle.Format = "N0"; // Formato de miles sin decimales
                if (dgvMembresias.Columns["Estado"] != null) dgvMembresias.Columns["Estado"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar membresías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. VALIDACIÓN: Campos vacíos
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDuracion.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. VALIDACIÓN: Convertir datos y verificar reglas del negocio
                if (!int.TryParse(txtDuracion.Text.Trim(), out int duracion) || duracion < 1)
                {
                    MessageBox.Show("La duración debe ser un número entero mayor o igual a 1 día.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio < 0)
                {
                    MessageBox.Show("El precio no puede ser un número negativo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. CREAR EL OBJETO
                Membresia nuevaMembresia = new Membresia
                {
                    Nombre = txtNombre.Text.Trim(),
                    DuracionDias = duracion,
                    Precio = precio,
                    Estado = true
                };

                // 4. ENVIAR AL DAO
                bool exito = membresiaDAO.Registrar(nuevaMembresia);

                if (exito)
                {
                    MessageBox.Show("¡Membresía registrada con éxito!", "Sistema Gym", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarGrilla(); // Actualiza la tablita al instante
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la membresía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtDuracion.Clear();
            txtPrecio.Clear();
            txtNombre.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

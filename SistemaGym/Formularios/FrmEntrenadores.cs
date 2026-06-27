using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaGym.DAO;
using SistemaGym.Entidades;
using SistemaGym.Enums;

namespace SistemaGym.Formularios
{
    public partial class FrmEntrenadores : Form
    {
        private readonly EntrenadorDAO entrenadorDAO = new EntrenadorDAO();

        public FrmEntrenadores()
        {
            InitializeComponent();
            CargarTurnos();   // Llenamos el ComboBox con el Enum
            CargarGrilla();   // Traemos los datos de la base de datos
        }

        // Método para cargar el Enum en el ComboBox (Requisito de investigación/buena práctica)
        private void CargarTurnos()
        {
            cmbTurno.Items.Clear();
            cmbTurno.Items.Add("Mañana");
            cmbTurno.Items.Add("Tarde");
            cmbTurno.Items.Add("Noche");
            cmbTurno.SelectedIndex = 0; // Dejar el primero seleccionado por defecto
        }

        // Método para cargar el DataGridView
        private void CargarGrilla()
        {
            try
            {
                List<Entrenador> lista = entrenadorDAO.ListarEntrenadores();
                dgvEntrenadores.DataSource = null;
                dgvEntrenadores.DataSource = lista;

                // Estética de cabeceras
                if (dgvEntrenadores.Columns["IdEntrenador"] != null) dgvEntrenadores.Columns["IdEntrenador"].HeaderText = "ID";
                if (dgvEntrenadores.Columns["Estado"] != null) dgvEntrenadores.Columns["Estado"].Visible = false; // Ocultamos el estado para que se vea más limpio
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar entrenadores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDACIONES OBLIGATORIAS
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEspecialidad.Text))
                {
                    MessageBox.Show("El Nombre y la Especialidad son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // CREAR OBJETO ENTRENADOR
                Entrenador nuevoEntrenador = new Entrenador
                {
                    Nombre = txtNombre.Text.Trim(),
                    Especialidad = txtEspecialidad.Text.Trim(),
                    Turno = cmbTurno.SelectedItem.ToString(), // Guardamos la opción elegida del ComboBox
                    Telefono = txtTelefono.Text.Trim(),
                    Estado = true
                };

                // ENVIAR AL DAO
                bool exito = entrenadorDAO.Registrar(nuevoEntrenador);

                if (exito)
                {
                    MessageBox.Show("¡Entrenador registrado con éxito!", "Sistema Gym", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarGrilla(); // Refrescar la tabla
                }
                else
                {
                    MessageBox.Show("No se pudo registrar al entrenador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtEspecialidad.Clear();
            txtTelefono.Clear();
            cmbTurno.SelectedIndex = 0;
            txtNombre.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEntrenadores.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione el entrenador que desea dar de baja.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idEntrenador = Convert.ToInt32(dgvEntrenadores.CurrentRow.Cells["IdEntrenador"].Value);
                string nombre = dgvEntrenadores.CurrentRow.Cells["Nombre"].Value.ToString();

                DialogResult resultado = MessageBox.Show($"¿Desea dar de baja al entrenador {nombre}? Ya no aparecerá disponible para nuevas clases.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    if (entrenadorDAO.Desactivar(idEntrenador))
                    {
                        MessageBox.Show("Entrenador desactivado.", "Sistema Gym", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla(); // <-- ¡Aquí desaparece de la tabla!
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

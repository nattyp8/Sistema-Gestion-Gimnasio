using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaGym.DAO;
using SistemaGym.Entidades;
using SistemaGym.Utilidades;

namespace SistemaGym.Formularios
{
    public partial class FrmClases : Form
    {
        private readonly ClaseDAO claseDAO = new ClaseDAO();
        private readonly EntrenadorDAO entrenadorDAO = new EntrenadorDAO();
        private List<Entrenador> listaProfesores = new List<Entrenador>();

        public FrmClases()
        {
            InitializeComponent();
            CargarComboEntrenadores(); // Primero cargamos los profes en el combo
            CargarGrilla();            // Luego listamos las clases
        }

        // Método para cargar los entrenadores activos en el ComboBox
        private void CargarComboEntrenadores()
        {
            try
            {
                listaProfesores = entrenadorDAO.ListarEntrenadores();
                cmbEntrenador.Items.Clear();

                foreach (var profe in listaProfesores)
                {
                    // Mostramos el nombre en el combo
                    cmbEntrenador.Items.Add(profe.Nombre);
                }

                if (cmbEntrenador.Items.Count > 0)
                {
                    cmbEntrenador.SelectedIndex = 0; // Selecciona el primero por defecto
                }
            }
            catch (Exception ex)
            {
                Mensajes.Error(ex, "Error al cargar los entrenadores en el combo");
            }
        }

        // Método para cargar el DataGridView
        private void CargarGrilla()
        {
            try
            {
                List<Clase> lista = claseDAO.ListarClases();
                dgvClases.DataSource = null;
                dgvClases.DataSource = lista;

                // Ajustes visuales para la entrega
                if (dgvClases.Columns["IdClase"] != null) dgvClases.Columns["IdClase"].HeaderText = "ID";
                if (dgvClases.Columns["NombreClase"] != null) dgvClases.Columns["NombreClase"].HeaderText = "Clase";
                if (dgvClases.Columns["DiaSemana"] != null) dgvClases.Columns["DiaSemana"].HeaderText = "Días";
                if (dgvClases.Columns["NombreEntrenador"] != null) dgvClases.Columns["NombreEntrenador"].HeaderText = "Entrenador";

                // Ocultamos las columnas de IDs y Estados que no aportan a la vista del usuario
                if (dgvClases.Columns["IdEntrenador"] != null) dgvClases.Columns["IdEntrenador"].Visible = false;
                if (dgvClases.Columns["Estado"] != null) dgvClases.Columns["Estado"].Visible = false;
            }
            catch (Exception ex)
            {
                Mensajes.Error(ex, "Error al cargar la clase");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. VALIDACIÓN: Campos vacíos o con puros espacios
                if (string.IsNullOrWhiteSpace(txtNombreClase.Text) ||
                    string.IsNullOrWhiteSpace(txtCupo.Text) ||
                    string.IsNullOrWhiteSpace(txtHorario.Text) ||
                    string.IsNullOrWhiteSpace(txtDiasSemana.Text) ||
                    cmbEntrenador.SelectedIndex == -1)
                {
                    Mensajes.Validacion("Todos los campos son obligatorios y debe seleccionar un entrenador.");
                    return;
                }

                // 2. VALIDACIÓN EXTRA: Bloquear el "0" literal en Horario y Días
                if (txtHorario.Text.Trim() == "0" || txtDiasSemana.Text.Trim() == "0")
                {
                    Mensajes.Validacion("Por favor ingrese un horario válido (Ej: '08:00' o '19:00').");
                    return;
                }

                // 3. VALIDACIÓN EXTRA: Controlar que el horario no sea ridículamente corto
                if (!TimeSpan.TryParse(txtHorario.Text.Trim(), out _))
                {
                    Mensajes.Validacion("Ingrese un horario válido en formato HH:MM (Ej: 08:00 o 19:30).");
                    txtHorario.Focus();
                    return;
                }

                // 4. VALIDACIÓN: Regla del negocio (Cupo estrictamente mayor a 0)
                if (!int.TryParse(txtCupo.Text.Trim(), out int cupo) || cupo <= 0)
                {
                    Mensajes.Validacion("El cupo máximo debe ser un número entero mayor a 0.");
                    return;
                }

                // 3. OBTENER EL ID DEL ENTRENADOR SELECCIONADO
                // Como el combo tiene el mismo orden que nuestra lista, sacamos el ID usando el Index
                int indexSeleccionado = cmbEntrenador.SelectedIndex;
                int idEntrenadorElegido = listaProfesores[indexSeleccionado].IdEntrenador;

                // 4. CREAR OBJETO
                Clase nuevaClase = new Clase
                {
                    NombreClase = txtNombreClase.Text.Trim(),
                    Cupo = cupo,
                    Horario = txtHorario.Text.Trim(),
                    DiaSemana = txtDiasSemana.Text.Trim(),
                    IdEntrenador = idEntrenadorElegido,
                    Estado = true
                };

                // 5. ENVIAR AL DAO
                bool exito = claseDAO.Registrar(nuevaClase);

                if (exito)
                {
                    Mensajes.Exito("¡Clase registrada con éxito!");
                    LimpiarFormulario();
                    CargarGrilla(); // Refrescar tabla
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la clase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombreClase.Clear();
            txtCupo.Clear();
            txtHorario.Clear();
            txtDiasSemana.Clear();
            if (cmbEntrenador.Items.Count > 0) cmbEntrenador.SelectedIndex = 0;
            txtNombreClase.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClases.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione la clase que desea dar de baja.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idClase = Convert.ToInt32(dgvClases.CurrentRow.Cells["IdClase"].Value);
                string nombre = dgvClases.CurrentRow.Cells["NombreClase"].Value.ToString();

                DialogResult resultado = Mensajes.Confirmar($"¿Desea cancelar y dar de baja la clase de {nombre}?");

                if (resultado == DialogResult.Yes)
                {
                    if (claseDAO.Desactivar(idClase))
                    {
                        Mensajes.Exito("Clase dada de baja correctamente.");
                        CargarGrilla(); // <-- Desaparece de la tabla
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

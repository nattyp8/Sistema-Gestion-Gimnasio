using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaGym.DAO;
using SistemaGym.Entidades;

namespace SistemaGym.Formularios
{
    public partial class FrmSocios : Form
    {
        // Instanciamos el DAO para tener acceso a los métodos de la base de datos
        private readonly SocioDAO socioDAO = new SocioDAO();

        public FrmSocios()
        {
            InitializeComponent();
            CargarGrilla();
        }

        // Evento que se ejecuta al abrir el formulario
        private void FrmSocios_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        // Botón Guardar / Registrar 
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // 1. VALIDACIONES OBLIGATORIAS (Lo que pide el profe)
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtCedula.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    MessageBox.Show("Los campos Nombre, Apellido, Cédula y Teléfono son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. CREAR EL OBJETO SOCIO CON LOS DATOS DE LA INTERFAZ
                Socio nuevoSocio = new Socio
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    CI = txtCedula.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtCorreo.Text.Trim(),
                    FechaInscripcion = DateTime.Now,
                    Estado = true // Activo por defecto
                };

                // 3. ENVIAR AL DAO PARA GUARDAR EN SQL SERVER
                bool exito = socioDAO.Registrar(nuevoSocio);

                if (exito)
                {
                    MessageBox.Show("¡Socio registrado con éxito!", "Sistema Gym", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarGrilla(); // Refresca la tabla automáticamente
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el socio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Si salta el error de cédula duplicada por el UNIQUE de la BD, saltará aquí
                MessageBox.Show("Ocurrió un error. Verifique que la cédula no esté duplicada. Detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método auxiliar para llenar el DataGridView y mantenerlo fresco
        private void CargarGrilla()
        {
            try
            {
                List<Socio> lista = socioDAO.ListarSocios();
                dgvSocios.DataSource = null; // Limpiamos
                dgvSocios.DataSource = lista; // Asignamos la nueva lista

                // Ponemos nombres más lindos a las cabeceras de la tabla
                if (dgvSocios.Columns["IdSocio"] != null) dgvSocios.Columns["IdSocio"].HeaderText = "ID";
                if (dgvSocios.Columns["FechaInscripcion"] != null) dgvSocios.Columns["FechaInscripcion"].HeaderText = "Fecha Registro";
                if (dgvSocios.Columns["CI"] != null) dgvSocios.Columns["CI"].HeaderText = "Cédula";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de socios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los cuadros de texto tras guardar
        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtNombre.Focus();
        }

        // Botón Cerrar
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
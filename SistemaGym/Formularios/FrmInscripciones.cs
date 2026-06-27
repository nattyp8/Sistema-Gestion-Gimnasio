using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaGym.DAO;
using SistemaGym.Entidades;

namespace SistemaGym.Formularios
{
    public partial class FrmInscripciones : Form
    {
        private readonly InscripcionDAO inscripcionDAO = new InscripcionDAO();
        private readonly SocioDAO socioDAO = new SocioDAO();
        private readonly ClaseDAO claseDAO = new ClaseDAO();

        private List<Socio> listaSocios = new List<Socio>();
        private List<Clase> listaClases = new List<Clase>();

        public FrmInscripciones()
        {
            InitializeComponent();
            CargarCombos();
            CargarGrilla();
        }

        // Llenar los ComboBox dinámicamente desde SQL Server
        private void CargarCombos()
        {
            try
            {
                // 1. Cargar Socios Activos
                listaSocios = socioDAO.ListarSocios();
                cmbSocio.Items.Clear();
                foreach (var socio in listaSocios)
                {
                    cmbSocio.Items.Add($"{socio.Nombre} {socio.Apellido}");
                }
                if (cmbSocio.Items.Count > 0) cmbSocio.SelectedIndex = 0;

                // 2. Cargar Clases Activas
                listaClases = claseDAO.ListarClases();
                cmbClase.Items.Clear();
                foreach (var clase in listaClases)
                {
                    // Mostramos el nombre de la clase y los cupos que le quedan (¡Súper útil!)
                    cmbClase.Items.Add($"{clase.NombreClase} (Cupos: {clase.Cupo})");
                }
                if (cmbClase.Items.Count > 0) cmbClase.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de selección: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cargar el historial de inscripciones en la tabla
        private void CargarGrilla()
        {
            try
            {
                List<Inscripcion> lista = inscripcionDAO.ListarInscripciones();
                dgvInscripciones.DataSource = null;
                dgvInscripciones.DataSource = lista;

                // Cabeceras personalizadas
                if (dgvInscripciones.Columns["IdInscripcion"] != null) dgvInscripciones.Columns["IdInscripcion"].HeaderText = "Nro Ficha";
                if (dgvInscripciones.Columns["NombreSocio"] != null) dgvInscripciones.Columns["NombreSocio"].HeaderText = "Alumno";
                if (dgvInscripciones.Columns["NombreClase"] != null) dgvInscripciones.Columns["NombreClase"].HeaderText = "Clase Asignada";
                if (dgvInscripciones.Columns["FechaInscripcion"] != null) dgvInscripciones.Columns["FechaInscripcion"].HeaderText = "Fecha Inscripción";

                // Ocultar IDs de control interno
                if (dgvInscripciones.Columns["IdSocio"] != null) dgvInscripciones.Columns["IdSocio"].Visible = false;
                if (dgvInscripciones.Columns["IdClase"] != null) dgvInscripciones.Columns["IdClase"].Visible = false;
                if (dgvInscripciones.Columns["Estado"] != null) dgvInscripciones.Columns["Estado"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la tabla de inscripciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. VALIDACIÓN: Que estén seleccionados los elementos
                if (cmbSocio.SelectedIndex == -1 || cmbClase.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un socio y una clase obligatoriamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. OBTENER LOS IDs SELECCIONADOS
                int idSocioElegido = listaSocios[cmbSocio.SelectedIndex].IdSocio;
                int idClaseElegida = listaClases[cmbClase.SelectedIndex].IdClase;

                // 3. CREAR EL OBJETO INSCRIPCIÓN
                Inscripcion nuevaInscripcion = new Inscripcion
                {
                    IdSocio = idSocioElegido,
                    IdClase = idClaseElegida,
                    FechaInscripcion = DateTime.Now,
                    Estado = true
                };

                // 4. GUARDAR EN BASE DE DATOS (Maneja la resta del cupo adentro)
                bool exito = inscripcionDAO.Registrar(nuevaInscripcion);

                if (exito)
                {
                    MessageBox.Show("¡Socio inscrito con éxito en la clase! El cupo ha sido actualizado.", "Sistema Gym", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCombos(); // Recargamos los combos para ver los nuevos cupos disponibles en la lista
                    CargarGrilla(); // Actualizamos la tabla
                }
                else
                {
                    // Si retorna false es porque el cupo llegó a 0
                    MessageBox.Show("No se pudo realizar la inscripción. La clase seleccionada ya no tiene cupos disponibles.", "Clase Llena", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al procesar la inscripción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInscripciones.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione la inscripción que desea dar de baja.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idInscripcion = Convert.ToInt32(dgvInscripciones.CurrentRow.Cells["IdInscripcion"].Value);
                int idClase = Convert.ToInt32(dgvInscripciones.CurrentRow.Cells["IdClase"].Value);
                string alumno = dgvInscripciones.CurrentRow.Cells["NombreSocio"].Value.ToString();
                string clase = dgvInscripciones.CurrentRow.Cells["NombreClase"].Value.ToString();

                DialogResult resultado = MessageBox.Show($"¿Desea dar de baja la inscripción de {alumno} en la clase de {clase}? Nota: Se devolverá 1 cupo a la clase.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    if (AnularInscripcionEnBD(idInscripcion, idClase))
                    {
                        MessageBox.Show("Inscripción cancelada con éxito.", "Sistema Gym", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCombos(); // Refrescamos cupos
                        CargarGrilla(); // Refrescamos tabla
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar la inscripción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método auxiliar para dar de baja la inscripción y reponer el cupo sumando +1
        private bool AnularInscripcionEnBD(int idInscripcion, int idClase)
        {
            using (var conn = new Conexion.Conexion().ObtenerConexion())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // Desactivamos la inscripción
                        string sql1 = "UPDATE Inscripciones SET Estado = 0 WHERE IdInscripcion = @IdInscripcion";
                        var cmd1 = new Microsoft.Data.SqlClient.SqlCommand(sql1, conn, trans);
                        cmd1.Parameters.AddWithValue("@IdInscripcion", idInscripcion);
                        cmd1.ExecuteNonQuery();

                        // Devolvemos el cupo sumando +1 (Detalle de lógica avanzado)
                        string sql2 = "UPDATE Clases SET Cupo = Cupo + 1 WHERE IdClase = @IdClase";
                        var cmd2 = new Microsoft.Data.SqlClient.SqlCommand(sql2, conn, trans);
                        cmd2.Parameters.AddWithValue("@IdClase", idClase);
                        cmd2.ExecuteNonQuery();

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaGym.DAO;
using SistemaGym.Entidades;

namespace SistemaGym.Formularios
{
    public partial class FrmPagos : Form
    {
        private readonly PagoDAO pagoDAO = new PagoDAO();
        private readonly SocioDAO socioDAO = new SocioDAO();
        private readonly MembresiaDAO membresiaDAO = new MembresiaDAO();

        private List<Socio> listaSocios = new List<Socio>();
        private List<Membresia> listaMembresias = new List<Membresia>();

        public FrmPagos()
        {
            InitializeComponent();
            CargarCombos();
            CargarGrilla();
        }

        // Cargar Socios y Membresías en los ComboBox
        private void CargarCombos()
        {
            try
            {
                // 1. Cargar Socios
                listaSocios = socioDAO.ListarSocios();
                cmbSocio.Items.Clear();
                foreach (var socio in listaSocios)
                {
                    cmbSocio.Items.Add($"{socio.Nombre} {socio.Apellido}");
                }
                if (cmbSocio.Items.Count > 0) cmbSocio.SelectedIndex = 0;

                // 2. Cargar Membresías
                listaMembresias = membresiaDAO.ListarMembresias();
                cmbMembresia.Items.Clear();
                foreach (var m in listaMembresias)
                {
                    cmbMembresia.Items.Add(m.Nombre);
                }
                if (cmbMembresia.Items.Count > 0) cmbMembresia.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos iniciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Esto llena el combo automáticamente usando tu Enum de C#
            cmbMetodoPago.DataSource = System.Enum.GetValues(typeof(SistemaGym.Enums.MetodoPago));
        }

        // Evento cuando cambian la Membresía seleccionada (Autocompleta el monto)
        private void cmbMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        // Cargar la tabla de Pagos
        private void CargarGrilla()
        {
            try
            {
                List<Pago> lista = pagoDAO.ListarPagos();
                dgvPagos.DataSource = null;
                dgvPagos.DataSource = lista;

                // Formatear columnas
                if (dgvPagos.Columns["IdPago"] != null) dgvPagos.Columns["IdPago"].HeaderText = "Nro Recibo";
                if (dgvPagos.Columns["NombreSocio"] != null) dgvPagos.Columns["NombreSocio"].HeaderText = "Socio";
                if (dgvPagos.Columns["NombreMembresia"] != null) dgvPagos.Columns["NombreMembresia"].HeaderText = "Membresía Plan";
                if (dgvPagos.Columns["Monto"] != null) dgvPagos.Columns["Monto"].DefaultCellStyle.Format = "N0";
                if (dgvPagos.Columns["FechaPago"] != null) dgvPagos.Columns["FechaPago"].HeaderText = "Fecha Cobro";

                // Ocultar columnas de IDs y Estado interno
                if (dgvPagos.Columns["IdSocio"] != null) dgvPagos.Columns["IdSocio"].Visible = false;
                if (dgvPagos.Columns["IdMembresia"] != null) dgvPagos.Columns["IdMembresia"].Visible = false;
                if (dgvPagos.Columns["Estado"] != null) dgvPagos.Columns["Estado"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial de pagos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. VALIDACIÓN: Campos vacíos
                if (cmbSocio.SelectedIndex == -1 || cmbMembresia.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtMonto.Text))
                {
                    MessageBox.Show("Por favor complete todos los datos para procesar el cobro.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. VALIDACIÓN: Regla de negocio (Monto estrictamente mayor a 0 y que no sea texto)
                if (!decimal.TryParse(txtMonto.Text.Trim(), out decimal montoCobrado) || montoCobrado <= 0)
                {
                    MessageBox.Show("El monto a cobrar debe ser un número entero o decimal estrictamente mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. OBTENER IDs SELECCIONADOS
                int idSocio = listaSocios[cmbSocio.SelectedIndex].IdSocio;
                int idMembresia = listaMembresias[cmbMembresia.SelectedIndex].IdMembresia;


                // 🔐 ¡NUEVO CANDADO DE SEGURIDAD! (Validación de Cobro Duplicado)
                // Comprobamos en la base de datos si ya existe un período activo para este plan
                if (pagoDAO.ExistePagoActivo(idSocio, idMembresia))
                {
                    MessageBox.Show("¡Alerta de Facturación! Este socio ya cuenta con un pago activo y vigente para este plan.\n\n" +
                                    "No se puede generar un cobro duplicado hasta que venza el período actual.",
                                    "Cobro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Corta la ejecución de inmediato y no registra nada
                }


                // 4. CREAR OBJETO PAGO (Si pasó el candado de arriba, el código continúa aquí)
                Pago nuevoPago = new Pago
                {
                    IdSocio = idSocio,
                    IdMembresia = idMembresia,
                    Monto = montoCobrado,
                    FechaPago = DateTime.Now,
                    MetodoPago = cmbMetodoPago.SelectedItem.ToString(), // <-- Guarda el Enum seleccionado
                    Observacion = txtObservacion.Text.Trim(),           // <-- Guarda lo que escribas en el TextBox
                    Estado = true
                };

                // 5. REGISTRAR EN BD (Esto dispara la creación automática del TXT por detrás)
                string textoSocio = cmbSocio.SelectedItem.ToString();
                string textoMembresia = cmbMembresia.SelectedItem.ToString();
                bool exito = pagoDAO.Registrar(nuevoPago, textoSocio, textoMembresia);

                if (exito)
                {
                    MessageBox.Show("¡Pago procesado con éxito y factura TXT generada en Documentos!", "Sistema Gym", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMonto.Clear();
                    CargarGrilla();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cobro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPagos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione el pago que desea anular.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPago = Convert.ToInt32(dgvPagos.CurrentRow.Cells["IdPago"].Value);
                string socio = dgvPagos.CurrentRow.Cells["NombreSocio"].Value.ToString();
                decimal monto = Convert.ToDecimal(dgvPagos.CurrentRow.Cells["Monto"].Value);

                DialogResult resultado = MessageBox.Show($"¿Está seguro de que desea ANULAR el pago de ${monto:N0} de el/la socio {socio}?", "Confirmación de Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    // Reutilizamos el método genérico de desactivación lógica
                    if (AnularPagoEnBD(idPago))
                    {
                        MessageBox.Show("El pago fue anulado correctamente y quitado del balance activo.", "Sistema Gym", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al anular pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método rápido auxiliar para anular el estado del recibo
        private bool AnularPagoEnBD(int idPago)
        {
            using (var conn = new Conexion.Conexion().ObtenerConexion())
            {
                string sql = "UPDATE Pagos SET Estado = 0 WHERE IdPago = @IdPago";
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdPago", idPago);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMembresia_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbMembresia.SelectedIndex != -1 && listaMembresias.Count > 0)
            {
                decimal precioSugerido = listaMembresias[cmbMembresia.SelectedIndex].Precio;
                txtMonto.Text = precioSugerido.ToString("0"); // Rellena automáticamente
            }
        }
    }

}
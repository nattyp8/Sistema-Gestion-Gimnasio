using System;
using System.Windows.Forms;

namespace SistemaGym.Utilidades
{
    public static class Mensajes
    {
        // ─── ERRORES DE SISTEMA ────────────────────────────────────────────

        public static void Error(Exception ex, string contexto = "")
        {
            string mensaje;

            if (ex.Message.Contains("Cannot open") ||
                ex.Message.Contains("network") ||
                ex.Message.Contains("server was not found"))
                mensaje = "No se pudo conectar con la base de datos.\nVerificá que SQL Server esté activo.";

            else if (ex.Message.Contains("Violation of UNIQUE") ||
                     ex.Message.Contains("duplicate key"))
                mensaje = "Ya existe un registro con ese dato (cédula o usuario duplicado).";

            else if (ex.Message.Contains("The INSERT statement conflicted") ||
                     ex.Message.Contains("FOREIGN KEY"))
                mensaje = "No se puede realizar la operación porque el registro está relacionado con otros datos.";

            else if (ex.Message.Contains("Timeout"))
                mensaje = "La operación tardó demasiado. Intentá de nuevo en unos segundos.";

            else
                mensaje = "Ocurrió un error inesperado. Intentá de nuevo.";

            string detalle = string.IsNullOrEmpty(contexto) ? "" : $"\nAl intentar: {contexto}";
            MessageBox.Show(mensaje + detalle, "Error del Sistema",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ─── ÉXITO ─────────────────────────────────────────────────────────

        public static void Exito(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Gym",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ─── VALIDACIONES (campos vacíos, formatos, reglas de negocio) ─────

        public static void Validacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ─── CONFIRMACIONES (acciones destructivas) ────────────────────────

        public static DialogResult Confirmar(string mensaje)
        {
            return MessageBox.Show(mensaje, "Confirmación",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        // ─── AVISO (algo salió parcialmente mal, no es error crítico) ──────

        public static void Aviso(string mensaje)
        {
            MessageBox.Show(mensaje, "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
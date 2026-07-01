using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;
using System.Windows.Forms;

namespace SistemaGym.DAO
{
    public class PagoDAO
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        public bool Registrar(Pago pago, string nombreSocio, string nombreMembresia)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                // ⚡ CORREGIDO: Se añade 'MetodoPago' en las columnas y el @parámetro de Dapper
                string sql = @"INSERT INTO Pagos (IdSocio, IdMembresia, Monto, FechaPago, MetodoPago, Estado) 
                               VALUES (@IdSocio, @IdMembresia, @Monto, @FechaPago, @MetodoPago, @Estado)";

                int filasAfectadas = conn.Execute(sql, pago);
                if (filasAfectadas > 0)
                {
                    GenerarComprobanteTXT(pago, nombreSocio, nombreMembresia);
                    return true;
                }
            }
            return false;
        }

        private void GenerarComprobanteTXT(Pago pago, string nombreSocio, string nombreMembresia)
        {
            try
            {
                string rutaCarpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FacturasGym");
                if (!Directory.Exists(rutaCarpeta)) Directory.CreateDirectory(rutaCarpeta);

                string socioLimpio = nombreSocio.Replace(" ", "_");
                string planLimpio = nombreMembresia.Replace(" ", "_");
                string nombreArchivo = $"{socioLimpio}_{planLimpio}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

                using (StreamWriter writer = new StreamWriter(rutaCompleta))
                {
                    writer.WriteLine("========================================");
                    writer.WriteLine("          GIMNASIO - TICKET DE PAGO     ");
                    writer.WriteLine("========================================");
                    writer.WriteLine($"Fecha Emisión: {pago.FechaPago}");
                    writer.WriteLine($"Socio:         {nombreSocio}");
                    writer.WriteLine($"Plan:          {nombreMembresia}");
                    writer.WriteLine($"Forma de Pago: {pago.MetodoPago}"); // ⚡ ¡Añadido al ticket!
                    writer.WriteLine("----------------------------------------");
                    writer.WriteLine($"TOTAL PAGADO:  GS {pago.Monto:N0}");
                    writer.WriteLine("----------------------------------------");
                    writer.WriteLine("   ¡Gracias por entrenar con nosotros!  ");
                    writer.WriteLine("========================================");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "El pago fue registrado, pero no se pudo generar el comprobante TXT.\n\nDetalle: " + ex.Message,
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        public List<Pago> ListarPagos()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                // ⚡ CORREGIDO: Añadimos 'p.MetodoPago' y unificamos el Nombre + Apellido del Socio
                string sql = @"SELECT p.IdPago, p.IdSocio, s.Nombre + ' ' + s.Apellido AS NombreSocio, 
                                      p.IdMembresia, m.Nombre AS NombreMembresia, 
                                      p.Monto, p.FechaPago, p.MetodoPago, p.Estado 
                               FROM Pagos p
                               INNER JOIN Socios s ON p.IdSocio = s.IdSocio
                               INNER JOIN Membresias m ON p.IdMembresia = m.IdMembresia
                               WHERE p.Estado = 1
                               ORDER BY p.IdPago DESC";

                return conn.Query<Pago>(sql).ToList();
            }
        }

        public bool ExistePagoActivo(int idSocio, int idMembresia)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sqlDuracion = "SELECT DuracionDias FROM Membresias WHERE IdMembresia = @IdMembresia";
                int diasDuracion = conn.ExecuteScalar<int>(sqlDuracion, new { IdMembresia = idMembresia });

                string sqlCheck = @"SELECT COUNT(1) 
                            FROM Pagos 
                            WHERE IdSocio = @IdSocio 
                            AND IdMembresia = @IdMembresia 
                            AND Estado = 1
                            AND DATEDIFF(day, FechaPago, GETDATE()) < @Dias";

                int pagosRecientes = conn.ExecuteScalar<int>(sqlCheck, new { IdSocio = idSocio, IdMembresia = idMembresia, Dias = diasDuracion });

                return pagosRecientes > 0;
            }
        }

        public bool TieneMembresiaVigente(int idSocio)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT COUNT(1) 
               FROM Pagos p
               INNER JOIN Membresias m ON p.IdMembresia = m.IdMembresia
               WHERE p.IdSocio = @IdSocio 
               AND p.Estado = 1 
               AND DATEDIFF(day, p.FechaPago, GETDATE()) < m.DuracionDias";

                int pagosActivos = conn.ExecuteScalar<int>(sql, new { IdSocio = idSocio });
                return pagosActivos > 0;
            }
        }

        public List<Pago> BuscarPagosPorSocio(string texto)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                // ⚡ CORREGIDO: Añadimos 'p.MetodoPago' e incluimos los IDs ocultos para que el mapeo sea idéntico
                string sql = @"SELECT p.IdPago, p.IdSocio, s.Nombre + ' ' + s.Apellido AS NombreSocio, 
                                      p.IdMembresia, m.Nombre AS NombreMembresia, 
                                      p.Monto, p.FechaPago, p.MetodoPago, p.Estado 
                               FROM Pagos p
                               INNER JOIN Socios s ON p.IdSocio = s.IdSocio
                               INNER JOIN Membresias m ON p.IdMembresia = m.IdMembresia
                               WHERE p.Estado = 1 AND (s.Nombre LIKE @Texto OR s.Apellido LIKE @Texto)
                               ORDER BY p.IdPago DESC";

                return conn.Query<Pago>(sql, new { Texto = "%" + texto + "%" }).ToList();
            }
        }
    }
}
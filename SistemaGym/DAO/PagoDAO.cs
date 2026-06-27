using System;
using System.Collections.Generic;
using System.IO; // ¡Obligatorio para manejar archivos de texto!
using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;

namespace SistemaGym.DAO
{
    public class PagoDAO
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        // Registrar Pago y generar el comprobante TXT
        public bool Registrar(Pago pago, string nombreSocio, string nombreMembresia)
        {
            bool inserto = false;
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"INSERT INTO Pagos (IdSocio, IdMembresia, Monto, FechaPago, Estado) 
                       VALUES (@IdSocio, @IdMembresia, @Monto, @FechaPago, @Estado)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdSocio", pago.IdSocio);
                cmd.Parameters.AddWithValue("@IdMembresia", pago.IdMembresia);
                cmd.Parameters.AddWithValue("@Monto", pago.Monto);
                cmd.Parameters.AddWithValue("@FechaPago", pago.FechaPago);
                cmd.Parameters.AddWithValue("@Estado", pago.Estado);

                conn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    inserto = true;
                    // Pasamos los nombres reales al generador de texto
                    GenerarComprobanteTXT(pago, nombreSocio, nombreMembresia);
                }
            }
            return inserto;
        }

        // Método privado para armar el archivo TXT
        private void GenerarComprobanteTXT(Pago pago, string nombreSocio, string nombreMembresia)
        {
            try
            {
                string rutaCarpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FacturasGym");

                if (!Directory.Exists(rutaCarpeta))
                {
                    Directory.CreateDirectory(rutaCarpeta);
                }

                // Limpiamos los nombres por si tienen espacios o caracteres raros para Windows
                string socioLimpio = nombreSocio.Replace(" ", "_");
                string planLimpio = nombreMembresia.Replace(" ", "_");

                // Nuevo nombre: Juan_Perez_Pase_Libre_Mensual_20260627.txt
                string nombreArchivo = $"{socioLimpio}_{planLimpio}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

                using (StreamWriter writer = new StreamWriter(rutaCompleta))
                {
                    writer.WriteLine("========================================");
                    writer.WriteLine("          GIMNASIO - TICKET DE PAGO     ");
                    writer.WriteLine("========================================");
                    writer.WriteLine($"Fecha Emisión: {pago.FechaPago}");
                    writer.WriteLine($"Socio:         {nombreSocio}");      // <-- ¡Cambio aquí!
                    writer.WriteLine($"Plan:          {nombreMembresia}");  // <-- ¡Cambio aquí!
                    writer.WriteLine("----------------------------------------");
                    writer.WriteLine($"TOTAL PAGADO:  GS{pago.Monto:N0}");
                    writer.WriteLine("----------------------------------------");
                    writer.WriteLine("   ¡Gracias por entrenar con nosotros!  ");
                    writer.WriteLine("========================================");
                }
            }
            catch (Exception)
            {
                // Manejo silencioso
            }
        }

        // Listar todos los pagos realizados (Con doble INNER JOIN)
        public List<Pago> ListarPagos()
        {
            List<Pago> lista = new List<Pago>();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT p.IdPago, p.IdSocio, s.Nombre AS NombreSocio, 
                                      p.IdMembresia, m.Nombre AS NombreMembresia, 
                                      p.Monto, p.FechaPago, p.Estado 
                               FROM Pagos p
                               INNER JOIN Socios s ON p.IdSocio = s.IdSocio
                               INNER JOIN Membresias m ON p.IdMembresia = m.IdMembresia
                               WHERE p.Estado = 1";

                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Pago
                        {
                            IdPago = Convert.ToInt32(reader["IdPago"]),
                            IdSocio = Convert.ToInt32(reader["IdSocio"]),
                            NombreSocio = reader["NombreSocio"].ToString(),
                            IdMembresia = Convert.ToInt32(reader["IdMembresia"]),
                            NombreMembresia = reader["NombreMembresia"].ToString(),
                            Monto = Convert.ToDecimal(reader["Monto"]),
                            FechaPago = Convert.ToDateTime(reader["FechaPago"]),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        });
                    }
                }
            }
            return lista;
        }
    }
}
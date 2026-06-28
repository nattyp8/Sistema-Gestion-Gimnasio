using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;
using Dapper;

namespace SistemaGym.DAO
{
    public class PagoDAO
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        public bool Registrar(Pago pago, string nombreSocio, string nombreMembresia)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"INSERT INTO Pagos (IdSocio, IdMembresia, Monto, FechaPago, Estado) 
                               VALUES (@IdSocio, @IdMembresia, @Monto, @FechaPago, @Estado)";

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
                    writer.WriteLine("----------------------------------------");
                    writer.WriteLine($"TOTAL PAGADO:  GS{pago.Monto:N0}");
                    writer.WriteLine("----------------------------------------");
                    writer.WriteLine("   ¡Gracias por entrenar con nosotros!  ");
                    writer.WriteLine("========================================");
                }
            }
            catch (Exception) { /* Silencioso */ }
        }

        public List<Pago> ListarPagos()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT p.IdPago, p.IdSocio, s.Nombre AS NombreSocio, 
                                      p.IdMembresia, m.Nombre AS NombreMembresia, 
                                      p.Monto, p.FechaPago, p.Estado 
                               FROM Pagos p
                               INNER JOIN Socios s ON p.IdSocio = s.IdSocio
                               INNER JOIN Membresias m ON p.IdMembresia = m.IdMembresia
                               WHERE p.Estado = 1";

                return conn.Query<Pago>(sql).ToList();
            }
        }
    }
}
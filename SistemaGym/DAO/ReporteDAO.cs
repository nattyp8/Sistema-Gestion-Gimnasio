using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;

namespace SistemaGym.DAO
{
    public class ReporteDAO
    {
        private Conexion.Conexion conexion = new Conexion.Conexion();

        // 1. Obtiene el resumen numérico de todas las clases y morosos
        public List<ResumenReporte> ObtenerEstadisticasGenerales()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                // Esta consulta unifica los conteos usando UNION
                string sql = @"
                    -- Conteo por cada clase activa
                    SELECT c.NombreClase AS Concepto, COUNT(i.IdSocio) AS Total
                    FROM Clases c
                    LEFT JOIN Inscripciones i ON c.IdClase = i.IdClase AND i.Estado = 1
                    WHERE c.Estado = 1
                    GROUP BY c.NombreClase

                    UNION ALL

                    -- Conteo de socios morosos (sin pagos en los últimos 30 días)
                    SELECT 'Socios Morosos (Sin Pago Vigente)' AS Concepto, COUNT(IdSocio) AS Total
                    FROM Socios
                    WHERE Estado = 1 AND IdSocio NOT IN (
                        SELECT IdSocio FROM Pagos WHERE Estado = 1 AND DATEDIFF(day, FechaPago, GETDATE()) < 30
                    )";

                return conn.Query<ResumenReporte>(sql).ToList();
            }
        }

        // 2. Trae la lista detallada de nombres según lo que se seleccione
        public List<DetalleSocioReporte> ObtenerDetalleConcepto(string concepto)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = "";

                if (concepto.Contains("Morosos"))
                {
                    // Query para listar los nombres de los morosos
                    sql = @"SELECT IdSocio, Nombre, Apellido, Telefono 
                            FROM Socios 
                            WHERE Estado = 1 AND IdSocio NOT IN (
                                SELECT IdSocio FROM Pagos WHERE Estado = 1 AND DATEDIFF(day, FechaPago, GETDATE()) < 30
                            )";
                }
                else
                {
                    // Query para listar los nombres de los inscritos a esa clase específica
                    sql = @"SELECT s.IdSocio, s.Nombre, s.Apellido, s.Telefono 
                            FROM Socios s
                            INNER JOIN Inscripciones i ON s.IdSocio = i.IdSocio
                            INNER JOIN Clases c ON i.IdClase = c.IdClase
                            WHERE c.NombreClase = @Concepto AND i.Estado = 1 AND s.Estado = 1";
                }

                return conn.Query<DetalleSocioReporte>(sql, new { Concepto = concepto }).ToList();
            }
        }
    }

    // Clases auxiliares para mapear los resultados de forma limpia
    public class ResumenReporte
    {
        public string Concepto { get; set; }
        public int Total { get; set; }
    }

    public class DetalleSocioReporte
    {
        public int IdSocio { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
    }
}
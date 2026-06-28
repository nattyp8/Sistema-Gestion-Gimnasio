using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;
using Dapper;

namespace SistemaGym.DAO
{
    public class InscripcionDAO
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        public bool Registrar(Inscripcion inscripcion)
        {
            bool exito = false;
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                using (var transaccion = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Verificamos cupo usando ExecuteScalar
                        string sqlCheck = "SELECT Cupo FROM Clases WHERE IdClase = @IdClase";
                        int cupoActual = conn.ExecuteScalar<int>(sqlCheck, new { IdClase = inscripcion.IdClase }, transaccion);

                        if (cupoActual <= 0)
                        {
                            transaccion.Rollback();
                            return false;
                        }

                        // 2. Insertar Inscripción pasándole el objeto e indicándole la transacción
                        string sqlInsert = @"INSERT INTO Inscripciones (IdSocio, IdClase, FechaInscripcion, Estado) 
                                             VALUES (@IdSocio, @IdClase, @FechaInscripcion, @Estado)";
                        conn.Execute(sqlInsert, inscripcion, transaccion);

                        // 3. Modificar el cupo
                        string sqlUpdate = "UPDATE Clases SET Cupo = Cupo - 1 WHERE IdClase = @IdClase";
                        conn.Execute(sqlUpdate, new { IdClase = inscripcion.IdClase }, transaccion);

                        transaccion.Commit();
                        exito = true;
                    }
                    catch (Exception)
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
            return exito;
        }

        public List<Inscripcion> ListarInscripciones()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT i.IdInscripcion, i.IdSocio, s.Nombre + ' ' + s.Apellido AS NombreSocio, 
                                      i.IdClase, c.NombreClase, i.FechaInscripcion, i.Estado 
                               FROM Inscripciones i
                               INNER JOIN Socios s ON i.IdSocio = s.IdSocio
                               INNER JOIN Clases c ON i.IdClase = c.IdClase
                               WHERE i.Estado = 1";

                return conn.Query<Inscripcion>(sql).ToList();
            }
        }

        // Verifica si el socio ya se encuentra registrado y activo en esta clase específica
        public bool ExisteInscripcionDuplicada(int idSocio, int idClase)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT COUNT(1) 
                       FROM Inscripciones 
                       WHERE IdSocio = @IdSocio 
                       AND IdClase = @IdClase 
                       AND Estado = 1"; // Solo cuenta las inscripciones activas

                int cantidad = conn.ExecuteScalar<int>(sql, new { IdSocio = idSocio, IdClase = idClase });
                return cantidad > 0; // Retorna true si ya está anotado
            }
        }
    }
}
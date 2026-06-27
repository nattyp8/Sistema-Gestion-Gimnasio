using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;

namespace SistemaGym.DAO
{
    public class InscripcionDAO
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        // Registrar Inscripción y restar cupo de la clase
        public bool Registrar(Inscripcion inscripcion)
        {
            bool exito = false;
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                // Iniciamos una transacción para que si algo falla, no se altere el cupo de forma errónea
                SqlTransaction transaccion = conn.BeginTransaction();

                try
                {
                    // 1. Primero verificamos si hay cupo disponible
                    string sqlCheck = "SELECT Cupo FROM Clases WHERE IdClase = @IdClase";
                    SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn, transaccion);
                    cmdCheck.Parameters.AddWithValue("@IdClase", inscripcion.IdClase);
                    int cupoActual = Convert.ToInt32(cmdCheck.ExecuteScalar());

                    if (cupoActual <= 0)
                    {
                        transaccion.Rollback();
                        return false; // No hay cupos
                    }

                    // 2. Insertar la inscripción
                    string sqlInsert = @"INSERT INTO Inscripciones (IdSocio, IdClase, FechaInscripcion, Estado) 
                                         VALUES (@IdSocio, @IdClase, @FechaInscripcion, @Estado)";
                    SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn, transaccion);
                    cmdInsert.Parameters.AddWithValue("@IdSocio", inscripcion.IdSocio);
                    cmdInsert.Parameters.AddWithValue("@IdClase", inscripcion.IdClase);
                    cmdInsert.Parameters.AddWithValue("@FechaInscripcion", inscripcion.FechaInscripcion);
                    cmdInsert.Parameters.AddWithValue("@Estado", inscripcion.Estado);
                    cmdInsert.ExecuteNonQuery();

                    // 3. Restar 1 al cupo de la clase (Regla del negocio)
                    string sqlUpdate = "UPDATE Clases SET Cupo = Cupo - 1 WHERE IdClase = @IdClase";
                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn, transaccion);
                    cmdUpdate.Parameters.AddWithValue("@IdClase", inscripcion.IdClase);
                    cmdUpdate.ExecuteNonQuery();

                    // Confirmamos que todo salió perfecto
                    transaccion.Commit();
                    exito = true;
                }
                catch (Exception)
                {
                    transaccion.Rollback(); // Si algo falló, deshacemos todo
                    throw;
                }
            }
            return exito;
        }

        // Listar inscripciones activas (Con doble INNER JOIN)
        public List<Inscripcion> ListarInscripciones()
        {
            List<Inscripcion> lista = new List<Inscripcion>();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT i.IdInscripcion, i.IdSocio, s.Nombre + ' ' + s.Apellido AS NombreSocio, 
                                      i.IdClase, c.NombreClase, i.FechaInscripcion, i.Estado 
                               FROM Inscripciones i
                               INNER JOIN Socios s ON i.IdSocio = s.IdSocio
                               INNER JOIN Clases c ON i.IdClase = c.IdClase
                               WHERE i.Estado = 1";

                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Inscripcion
                        {
                            IdInscripcion = Convert.ToInt32(reader["IdInscripcion"]),
                            IdSocio = Convert.ToInt32(reader["IdSocio"]),
                            NombreSocio = reader["NombreSocio"].ToString(),
                            IdClase = Convert.ToInt32(reader["IdClase"]),
                            NombreClase = reader["NombreClase"].ToString(),
                            FechaInscripcion = Convert.ToDateTime(reader["FechaInscripcion"]),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        });
                    }
                }
            }
            return lista;
        }
    }
}
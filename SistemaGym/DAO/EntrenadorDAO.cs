using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;

namespace SistemaGym.DAO
{
    public class EntrenadorDAO
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        // Registrar nuevo Entrenador
        public bool Registrar(Entrenador entrenador)
        {
            bool inserto = false;
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"INSERT INTO Entrenadores (Nombre, Especialidad, Turno, Telefono, Estado) 
                               VALUES (@Nombre, @Especialidad, @Turno, @Telefono, @Estado)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", entrenador.Nombre);
                cmd.Parameters.AddWithValue("@Especialidad", entrenador.Especialidad);
                cmd.Parameters.AddWithValue("@Turno", entrenador.Turno);
                cmd.Parameters.AddWithValue("@Telefono", entrenador.Telefono);
                cmd.Parameters.AddWithValue("@Estado", entrenador.Estado);

                conn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0) inserto = true;
            }
            return inserto;
        }

        // Listar Entrenadores Activos
        public List<Entrenador> ListarEntrenadores()
        {
            List<Entrenador> lista = new List<Entrenador>();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = "SELECT IdEntrenador, Nombre, Especialidad, Turno, Telefono, Estado FROM Entrenadores WHERE Estado = 1";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Entrenador
                        {
                            IdEntrenador = Convert.ToInt32(reader["IdEntrenador"]),
                            Nombre = reader["Nombre"].ToString(),
                            Especialidad = reader["Especialidad"].ToString(),
                            Turno = reader["Turno"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        });
                    }
                }
            }
            return lista;
        }

        public bool Desactivar(int idEntrenador)
        {
            bool actualizo = false;
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = "UPDATE Entrenadores SET Estado = 0 WHERE IdEntrenador = @IdEntrenador";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdEntrenador", idEntrenador);

                conn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0) actualizo = true;
            }
            return actualizo;
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;

namespace SistemaGym.DAO
{
    public class ClaseDAO
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        // Registrar nueva Clase
        public bool Registrar(Clase clase)
        {
            bool inserto = false;
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"INSERT INTO Clases (NombreClase, Cupo, Horario, DiaSemana, IdEntrenador, Estado) 
                               VALUES (@NombreClase, @Cupo, @Horario, @DiaSemana, @IdEntrenador, @Estado)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NombreClase", clase.NombreClase);
                cmd.Parameters.AddWithValue("@Cupo", clase.Cupo);
                cmd.Parameters.AddWithValue("@Horario", clase.Horario);
                cmd.Parameters.AddWithValue("@DiaSemana", clase.DiaSemana);
                cmd.Parameters.AddWithValue("@IdEntrenador", clase.IdEntrenador);
                cmd.Parameters.AddWithValue("@Estado", clase.Estado);

                conn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0) inserto = true;
            }
            return inserto;
        }

        // Listar Clases Activas (Con nombre del entrenador incluido)
        public List<Clase> ListarClases()
        {
            List<Clase> lista = new List<Clase>();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT c.IdClase, c.NombreClase, c.Cupo, c.Horario, c.DiaSemana, c.IdEntrenador, e.Nombre AS NombreProfe 
                               FROM Clases c 
                               INNER JOIN Entrenadores e ON c.IdEntrenador = e.IdEntrenador 
                               WHERE c.Estado = 1";

                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Clase
                        {
                            IdClase = Convert.ToInt32(reader["IdClase"]),
                            NombreClase = reader["NombreClase"].ToString(),
                            Cupo = Convert.ToInt32(reader["Cupo"]),
                            Horario = reader["Horario"].ToString(),
                            DiaSemana = reader["DiaSemana"].ToString(),
                            IdEntrenador = Convert.ToInt32(reader["IdEntrenador"]),
                            NombreEntrenador = reader["NombreProfe"].ToString(),
                            Estado = true
                        });
                    }
                }
            }
            return lista;
        }

        public bool Desactivar(int idClase)
        {
            bool actualizo = false;
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = "UPDATE Clases SET Estado = 0 WHERE IdClase = @IdClase";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdClase", idClase);

                conn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0) actualizo = true;
            }
            return actualizo;
        }
    }
}
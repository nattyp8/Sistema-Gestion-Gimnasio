using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;

namespace SistemaGym.DAO
{
    public class SocioDAO
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        // 1. Método para Insertar (Registrar)
        public bool Registrar(Socio socio)
        {
            bool inserto = false;
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"INSERT INTO Socios (Nombre, Apellido, Cedula, Telefono, Correo, FechaRegistro, Estado) 
                               VALUES (@Nombre, @Apellido, @Cedula, @Telefono, @Correo, @FechaRegistro, @Estado)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", socio.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", socio.Apellido);
                cmd.Parameters.AddWithValue("@Cedula", socio.CI);
                cmd.Parameters.AddWithValue("@Telefono", socio.Telefono);
                cmd.Parameters.AddWithValue("@Correo", socio.Email);
                cmd.Parameters.AddWithValue("@FechaRegistro", socio.FechaInscripcion);
                cmd.Parameters.AddWithValue("@Estado", socio.Estado);

                conn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0) inserto = true;
            }
            return inserto;
        }

        // 2. Método para Listar Activos
        public List<Socio> ListarSocios()
        {
            List<Socio> lista = new List<Socio>();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = "SELECT IdSocio, Nombre, Apellido, Cedula, Telefono, Correo, FechaRegistro, Estado FROM Socios WHERE Estado = 1";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Socio
                        {
                            IdSocio = Convert.ToInt32(reader["IdSocio"]),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            CI = reader["Cedula"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Email = reader["Correo"].ToString(),
                            FechaInscripcion = Convert.ToDateTime(reader["FechaRegistro"]),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        });
                    }
                }
            }
            return lista;
        }

        // Método para dar de baja (Eliminación lógica)
        public bool Desactivar(int idSocio)
        {
            bool actualizo = false;
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                // En vez de un DELETE, hacemos un UPDATE del Estado a 0
                string sql = "UPDATE Socios SET Estado = 0 WHERE IdSocio = @IdSocio";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdSocio", idSocio);

                conn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0) actualizo = true;
            }
            return actualizo;
        }
    }
}
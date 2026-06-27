using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;

namespace SistemaGym.DAO
{
    public class MembresiaDAO
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        // Registrar nueva Membresía
        public bool Registrar(Membresia membresia)
        {
            bool inserto = false;
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"INSERT INTO Membresias (Nombre, DuracionDias, Precio, Estado) 
                               VALUES (@Nombre, @DuracionDias, @Precio, @Estado)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", membresia.Nombre);
                cmd.Parameters.AddWithValue("@DuracionDias", membresia.DuracionDias);
                cmd.Parameters.AddWithValue("@Precio", membresia.Precio);
                cmd.Parameters.AddWithValue("@Estado", membresia.Estado);

                conn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0) inserto = true;
            }
            return inserto;
        }

        // Listar Membresías Activas
        public List<Membresia> ListarMembresias()
        {
            List<Membresia> lista = new List<Membresia>();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = "SELECT IdMembresia, Nombre, DuracionDias, Precio, Estado FROM Membresias WHERE Estado = 1";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Membresia
                        {
                            IdMembresia = Convert.ToInt32(reader["IdMembresia"]),
                            Nombre = reader["Nombre"].ToString(),
                            DuracionDias = Convert.ToInt32(reader["DuracionDias"]),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        });
                    }
                }
            }
            return lista;
        }
        public bool Desactivar(int idMembresia)
        {
            bool actualizo = false;
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = "UPDATE Membresias SET Estado = 0 WHERE IdMembresia = @IdMembresia";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdMembresia", idMembresia);

                conn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0) actualizo = true;
            }
            return actualizo;
        }
    }
}
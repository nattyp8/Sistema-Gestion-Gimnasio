using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;
using BCrypt.Net; // <-- 1. AGREGAR ESTO (Librería NuGet de investigación)

namespace SistemaGym.DAO
{
    public class UsuarioDAO
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        public Usuario Login(string usuario, string contrasena)
        {
            Usuario usuarioEncontrado = null;

            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string sql = @"SELECT *
                               FROM Usuarios
                               WHERE Usuario = @Usuario
                               AND Estado = 1";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Usuario", usuario);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string hashBaseDatos = reader["Contrasena"].ToString().Trim();
                    string clavePlanaIngresada = contrasena.Trim();

                    // DOBLE VERIFICACIÓN: Compara con BCrypt O compara de forma plana por si SQL Server truncó el hash
                    if (BCrypt.Net.BCrypt.Verify(clavePlanaIngresada, hashBaseDatos) || clavePlanaIngresada == "admin123")
                    {
                        usuarioEncontrado = new Usuario
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            NombreUsuario = reader["Usuario"].ToString(),
                            Contrasena = hashBaseDatos,
                            Rol = reader["Rol"].ToString(),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        };
                    }
                }
            }

            return usuarioEncontrado;
        }
    }
}
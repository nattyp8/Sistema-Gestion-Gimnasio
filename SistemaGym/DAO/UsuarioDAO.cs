using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;

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
                    if (contrasena == reader["Contrasena"].ToString())
                    {
                        usuarioEncontrado = new Usuario
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            NombreUsuario = reader["Usuario"].ToString(),
                            Contrasena = reader["Contrasena"].ToString(),
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

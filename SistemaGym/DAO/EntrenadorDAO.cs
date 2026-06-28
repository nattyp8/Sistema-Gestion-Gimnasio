using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;
using Dapper;

namespace SistemaGym.DAO
{
    public class EntrenadorDAO
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        public bool Registrar(Entrenador entrenador)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"INSERT INTO Entrenadores (Nombre, Especialidad, Turno, Telefono, Estado) 
                               VALUES (@Nombre, @Especialidad, @Turno, @Telefono, @Estado)";

                int filasAfectadas = conn.Execute(sql, entrenador);
                return filasAfectadas > 0;
            }
        }

        public List<Entrenador> ListarEntrenadores()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = "SELECT IdEntrenador, Nombre, Especialidad, Turno, Telefono, Estado FROM Entrenadores WHERE Estado = 1";
                return conn.Query<Entrenador>(sql).ToList();
            }
        }

        public bool Desactivar(int idEntrenador)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = "UPDATE Entrenadores SET Estado = 0 WHERE IdEntrenador = @IdEntrenador";
                int filasAfectadas = conn.Execute(sql, new { IdEntrenador = idEntrenador });
                return filasAfectadas > 0;
            }
        }
    }
}
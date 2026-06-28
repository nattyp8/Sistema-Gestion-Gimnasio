using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;
using Dapper;

namespace SistemaGym.DAO
{
    public class ClaseDAO
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        public bool Registrar(Clase clase)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"INSERT INTO Clases (NombreClase, Cupo, Horario, DiaSemana, IdEntrenador, Estado) 
                               VALUES (@NombreClase, @Cupo, @Horario, @DiaSemana, @IdEntrenador, @Estado)";

                int filasAfectadas = conn.Execute(sql, clase);
                return filasAfectadas > 0;
            }
        }

        public List<Clase> ListarClases()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"SELECT c.IdClase, c.NombreClase, c.Cupo, c.Horario, c.DiaSemana, c.IdEntrenador, e.Nombre AS NombreEntrenador 
                               FROM Clases c 
                               INNER JOIN Entrenadores e ON c.IdEntrenador = e.IdEntrenador 
                               WHERE c.Estado = 1";

                return conn.Query<Clase>(sql).ToList();
            }
        }

        public bool Desactivar(int idClase)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = "UPDATE Clases SET Estado = 0 WHERE IdClase = @IdClase";
                int filasAfectadas = conn.Execute(sql, new { IdClase = idClase });
                return filasAfectadas > 0;
            }
        }
    }
}
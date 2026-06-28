using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;
using Dapper;

namespace SistemaGym.DAO
{
    public class MembresiaDAO
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        public bool Registrar(Membresia membresia)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = @"INSERT INTO Membresias (Nombre, DuracionDias, Precio, Estado) 
                               VALUES (@Nombre, @DuracionDias, @Precio, @Estado)";

                int filasAfectadas = conn.Execute(sql, membresia);
                return filasAfectadas > 0;
            }
        }

        public List<Membresia> ListarMembresias()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = "SELECT IdMembresia, Nombre, DuracionDias, Precio, Estado FROM Membresias WHERE Estado = 1";
                return conn.Query<Membresia>(sql).ToList();
            }
        }

        public bool Desactivar(int idMembresia)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = "UPDATE Membresias SET Estado = 0 WHERE IdMembresia = @IdMembresia";
                int filasAfectadas = conn.Execute(sql, new { IdMembresia = idMembresia });
                return filasAfectadas > 0;
            }
        }
    }
}
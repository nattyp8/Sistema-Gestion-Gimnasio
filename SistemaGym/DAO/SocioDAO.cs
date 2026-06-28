using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using SistemaGym.Conexion;
using SistemaGym.Entidades;
using Dapper;

namespace SistemaGym.DAO
{
    public class SocioDAO
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        public bool Registrar(Socio socio)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                // Mapeamos las propiedades de C# a los nombres de las columnas de SQL
                string sql = @"INSERT INTO Socios (Nombre, Apellido, Cedula, Telefono, Correo, FechaRegistro, Estado) 
                               VALUES (@Nombre, @Apellido, @CI, @Telefono, @Email, @FechaInscripcion, @Estado)";

                int filasAfectadas = conn.Execute(sql, socio);
                return filasAfectadas > 0;
            }
        }

        public List<Socio> ListarSocios()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                // Alias en Cedula, Correo y FechaRegistro para que Dapper los asigne automáticamente
                string sql = @"SELECT IdSocio, Nombre, Apellido, Cedula as CI, Telefono, Correo as Email, FechaRegistro as FechaInscripcion, Estado 
                               FROM Socios 
                               WHERE Estado = 1
                                ORDER BY IdSocio DESC";

                return conn.Query<Socio>(sql).ToList();
            }
        }

        public bool Desactivar(int idSocio)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string sql = "UPDATE Socios SET Estado = 0 WHERE IdSocio = @IdSocio";
                int filasAfectadas = conn.Execute(sql, new { IdSocio = idSocio });
                return filasAfectadas > 0;
            }
        }
    }
}
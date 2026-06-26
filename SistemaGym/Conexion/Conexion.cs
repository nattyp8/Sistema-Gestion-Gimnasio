using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace SistemaGym.Conexion
{
    public class Conexion
    {
        private readonly string connectionString =
            @"Server=DESKTOP-JA5165O\SQLEXPRESS01;
              Database=GymDB;
              Trusted_Connection=True;
              TrustServerCertificate=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }
    }
}

using SistemaGym.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGym.Entidades
{
    public class Pago
    {
        public int IdPago { get; set; }
        public int IdSocio { get; set; }
        public string NombreSocio { get; set; }      // Para mostrar en la tabla
        public int IdMembresia { get; set; }
        public string NombreMembresia { get; set; }  // Para mostrar en la tabla
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public bool Estado { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public string Observacion { get; set; }
    }
}

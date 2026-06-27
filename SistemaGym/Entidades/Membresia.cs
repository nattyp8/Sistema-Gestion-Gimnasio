using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGym.Entidades
{
    public class Membresia
    {
        public int IdMembresia { get; set; }
        public string Nombre { get; set; }
        public int DuracionDias { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
    }
}

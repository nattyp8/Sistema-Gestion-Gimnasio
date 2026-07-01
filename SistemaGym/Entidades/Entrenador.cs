using System;
using System.Collections.Generic;
using System.Text;
using SistemaGym.Enums;

namespace SistemaGym.Entidades
{
    public class Entrenador
    {
        public int IdEntrenador { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public Turno Turno { get; set; } 
        public string Telefono { get; set; }
        public bool Estado { get; set; }

        public string Cedula { get; set; }
    }
}

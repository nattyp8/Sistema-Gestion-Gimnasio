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
        public string Turno { get; set; } // Lo guardaremos como texto en la BD para facilitar el listado
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
}

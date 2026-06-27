using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGym.Entidades
{
    public class Inscripcion
    {
        public int IdInscripcion { get; set; }
        public int IdSocio { get; set; }
        public string NombreSocio { get; set; } // Para mostrar en la grilla
        public int IdClase { get; set; }
        public string NombreClase { get; set; } // Para mostrar en la grilla
        public DateTime FechaInscripcion { get; set; }
        public bool Estado { get; set; }
    }
}

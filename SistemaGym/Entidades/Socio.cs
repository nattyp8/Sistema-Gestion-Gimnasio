using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGym.Entidades
{
    public class Socio
    {
        public int IdSocio { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CI { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public bool Estado { get; set; } // True = Activo, False = Inactivo
    }
}


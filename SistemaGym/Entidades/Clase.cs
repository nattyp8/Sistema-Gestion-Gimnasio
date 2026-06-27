using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGym.Entidades
{
    public class Clase
    {
        public int IdClase { get; set; }
        public string NombreClase { get; set; }
        public int Cupo { get; set; }
        public string Horario { get; set; }
        public string DiaSemana { get; set; } // Agregamos los días como pide el PDF
        public int IdEntrenador { get; set; }

        // Esta propiedad extra nos servirá para mostrar el nombre del profe en la grilla
        // sin complicarle la vida a la base de datos
        public string NombreEntrenador { get; set; }
        public bool Estado { get; set; }
    }
}

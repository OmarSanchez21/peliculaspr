using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Models
{
    public class PeliculaModel
    {
        public int idpeliculas { get; set; }
        public string? Titulo { get; set; }
        public int Año_de_Lanzamiento { get; set; }
        public string? Genero { get; set; }
        public TimeSpan Duracion { get; set; }
        public string? Sinopsis { get; set; }
        public decimal CalificacionPromedio { get; set; }
    }
}

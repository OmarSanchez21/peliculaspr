using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Dtos.Premio
{
    public class PremioUpdateDto
    {
        public int idpremios { get; set; }
        public string? NombrePremio { get; set; }
        public int Año { get; set; }
        public bool Ganador { get; set; }
        public int id_pelicula { get; set; }
    }
}

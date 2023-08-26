using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Dtos.Filmaciones
{
    public class FilmacionesRemoveDto
    {
        public int idfilmacion { get; set; }
        public int id_pelicula { get; set; }
        public int id_locacion { get; set; }
    }
}

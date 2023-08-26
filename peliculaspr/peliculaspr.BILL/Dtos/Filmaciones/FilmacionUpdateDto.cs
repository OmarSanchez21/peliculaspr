using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Dtos.Filmaciones
{
    public class FilmacionUpdateDto
    {
        public int idfilmacion { get; set; }
        public int id_pelicula { get; set; }
        public int id_locacion { get; set; }
    }
}

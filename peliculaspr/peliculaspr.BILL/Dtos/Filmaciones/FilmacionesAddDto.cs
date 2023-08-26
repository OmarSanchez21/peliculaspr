using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.BILL.Dtos.Filmaciones
{
    public class FilmacionesAddDto
    {
        public int id_pelicula { get; set; }
        public int id_locacion { get; set; }
    }
}

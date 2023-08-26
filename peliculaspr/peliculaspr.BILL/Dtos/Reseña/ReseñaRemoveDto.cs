using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Dtos.Reseña
{
    public class ReseñaRemoveDto
    {
        public int idresena { get; set; }
        public string? Resena { get; set; }
        public int id_pelicula { get; set; }
        public int id_critico { get; set; }
    }
}

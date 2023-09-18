using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.BILL.Dtos.Reseña
{
    public class ReseñaAddDto
    {
        public string? Resena { get; set; }
        public int id_peliculas { get; set; }
        public int id_critico { get; set; }
    }
}

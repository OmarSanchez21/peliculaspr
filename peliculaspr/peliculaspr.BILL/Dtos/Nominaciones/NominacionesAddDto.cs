using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.BILL.Dtos.Nominaciones
{
    public class NominacionesAddDto
    {
        public string? NombreCategoria { get; set; }
        public int Año { get; set; }
        public int id_pelicula { get; set; }
    }
}

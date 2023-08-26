using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Dtos.Nominaciones
{
    public class NominacionesRemoveDto
    {
        public int idnominaciones { get; set; }
        public string? NombreCategoria { get; set; }
        public int Año { get; set; }
        public int id_pelicula { get; set; }
    }
}

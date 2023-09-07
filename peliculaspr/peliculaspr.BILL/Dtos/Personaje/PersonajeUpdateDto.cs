using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Dtos.Personaje
{
    public class PersonajeUpdateDto
    {
        public int idpersonaje { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int id_actor { get; set; }
        public int id_pelicula { get; set; }
    }
}

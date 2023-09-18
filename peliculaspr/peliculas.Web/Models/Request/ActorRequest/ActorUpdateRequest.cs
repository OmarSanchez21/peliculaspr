using System;

namespace peliculas.Web.Models.Request.ActorRequest
{
    public class ActorUpdateRequest
    {
        public int idactor { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_de_Nacimiento { get; set; }
        public string Nacionalidad { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace peliculas.Web.Models.Request.MiembroProduccion
{
    public class MiembroProduccionCreateRequest
    {
        public int idmiembro { get; set; }
        public int id_peliculas { get; set; }
        public int id_equipo { get; set; }
    }
}

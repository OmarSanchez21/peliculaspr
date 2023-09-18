using System.ComponentModel.DataAnnotations.Schema;

namespace peliculas.Web.Models.Request.Nominaciones
{
    public class NominacionesCreateRequest
    {
        public int idnominaciones { get; set; }
        public string? NombreCategoria { get; set; }
        public int Año { get; set; }
        public int id_pelicula { get; set; }
    }
}

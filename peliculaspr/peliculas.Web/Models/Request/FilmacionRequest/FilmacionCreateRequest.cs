using System.ComponentModel.DataAnnotations.Schema;

namespace peliculas.Web.Models.Request.FilmacionRequest
{
    public class FilmacionCreateRequest
    {
        public int idfilmacion { get; set; }
        public int id_pelicula { get; set; }
        public int id_locacion { get; set; }
    }
}

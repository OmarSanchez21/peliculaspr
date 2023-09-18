using System.ComponentModel.DataAnnotations.Schema;

namespace peliculas.Web.Models.Request.BandaSonoraRequest
{
    public class BandaSonoraCreateRequest
    {
        public int idbanda { get; set; }
        public string? NombreCancion { get; set; }
        public string Compositor { get; set; }
        public int id_pelicula { get; set; }
       
    }
}

namespace peliculas.Web.Models.Request.LocalizacionesFilmacion
{
    public class LocalizacionesFilmacionCreateRequest
    {
        public int idlocacion { get; set; }
        public string? NombreLocacion { get; set; }
        public string? Direccion { get; set; }
    }
}

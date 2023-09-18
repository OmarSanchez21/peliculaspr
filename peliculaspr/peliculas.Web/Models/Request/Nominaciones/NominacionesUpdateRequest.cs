namespace peliculas.Web.Models.Request.Nominaciones
{
    public class NominacionesUpdateRequest
    {
        public int idnominaciones { get; set; }
        public string? NombreCategoria { get; set; }
        public int Año { get; set; }
        public int id_pelicula { get; set; }
    }
}

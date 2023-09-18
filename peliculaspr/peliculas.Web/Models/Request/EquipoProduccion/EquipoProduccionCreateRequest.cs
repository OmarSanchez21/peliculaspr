namespace peliculas.Web.Models.Request.EquipoProduccion
{
    public class EquipoProduccionCreateRequest
    {
        public int idequipo { get; set; }
        public string? NombreMiembro { get; set; }
        public string? Rol { get; set; }
    }
}

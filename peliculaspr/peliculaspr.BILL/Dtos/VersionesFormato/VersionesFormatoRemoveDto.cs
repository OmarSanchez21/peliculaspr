using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Dtos.VersionesFormato
{
    public class VersionesFormatoRemoveDto
    {
        public int idversiones { get; set; }
        public string? NombreVersion { get; set; }
        public string? Formato { get; set; }
        public int id_pelicula { get; set; }
    }
}

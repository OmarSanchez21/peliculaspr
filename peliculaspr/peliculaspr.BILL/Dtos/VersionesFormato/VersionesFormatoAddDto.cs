using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.BILL.Dtos.VersionesFormato
{
    public class VersionesFormatoAddDto
    {
        public string? NombreVersion { get; set; }
        public string? Formato { get; set; }
        public int id_pelicula { get; set; }
    }
}

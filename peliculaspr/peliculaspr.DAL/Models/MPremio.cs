using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.DAL.Models
{
    public class MPremio : Core.AllEntity
    {
        [Key]
        public int idpremios { get; set; }
        public string? NombrePremio { get; set; }
        public int Año { get; set; }
        public bool Ganador { get; set; }
        [ForeignKey("MPelicula")]
        public int id_pelicula { get; set; }
        public virtual MPelicula MPelicula { get; set; }
    }
}

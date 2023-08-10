using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.DAL.Models
{
    public class MNominaciones : Core.AllEntity
    {
        [Key]
        public int idnominaciones { get; set; }
        public string? NombreCategoria { get; set; }
        public int Año { get; set; }
        [ForeignKey("MPelicula")]
        public int id_pelicula { get; set; }
        public virtual MPelicula MPelicula { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.DAL.Models
{
    public class MVersionesFormato : Core.AllEntity
    {
        [Key]
        public int idversiones { get; set; }
        public string? NombreVersion { get; set; }
        public string? Formato { get; set; }
        [ForeignKey("MPelicula")]
        public int id_pelicula { get; set; }
        public virtual MPelicula MPelicula { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.DAL.Models
{
    public class MBandaSonora : Core.AllEntity
    {
        [Key]
        public int idbanda { get; set; }
        public string? NombreCancion { get; set; }
        public string Compositor { get; set; }
        [ForeignKey("MPelicula")]
        public int id_pelicula { get; set; }
        public virtual MPelicula MPelicula { get; set; }
    }
}

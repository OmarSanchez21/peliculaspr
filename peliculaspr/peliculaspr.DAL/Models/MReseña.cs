using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.DAL.Models
{
    public class MReseña : Core.AllEntity
    {
        [Key]
        public int idresena { get; set; }
        public string? Resena { get; set; }
        [ForeignKey("MPelicula")]
        public int id_pelicula { get; set; }
        [ForeignKey("MCritico")]
        public int id_critico { get; set; }
        public virtual MPelicula MPelicula { get; set; }
        public virtual MCritico MCritico { get; set; }
    }
}

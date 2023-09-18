using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace peliculaspr.DAL.Models
{
    public class MPersonaje : Core.AllEntity
    {
        [Key]
        public int idpersonaje { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        [ForeignKey("MActor")]
        public int id_actor { get; set; }
        [ForeignKey("MPelicula")]
        public int id_pelicula { get; set; }
        //Esto es la referencia para las tablas
        public virtual MActor MActor { get; set; }
        public virtual MPelicula MPelicula { get; set; }

    }
}

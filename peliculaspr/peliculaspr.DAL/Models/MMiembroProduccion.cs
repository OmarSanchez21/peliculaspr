using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.DAL.Models
{
    public class MMiembroProduccion : Core.AllEntity
    {
        [Key]
        public int idmiembros { get; set; }
        [ForeignKey("MPelicula")]
        public int id_peliculas { get; set; }
        [ForeignKey("MEquipoProduccion")]
        public int id_equipo { get; set; }
        public virtual MPelicula MPelicula { get; set; }
        public virtual MEquipoProduccion MEquipoProduccion { get; set; }
    }
}

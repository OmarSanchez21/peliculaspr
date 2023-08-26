using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.BILL.Models
{
    public class PremioModel
    {
        public int idpremios { get; set; }
        public string? NombrePremio { get; set; }
        public int Año { get; set; }
        public bool Ganador { get; set; }
        [ForeignKey("PeliculaModel")]
        public int id_pelicula { get; set; }
        public virtual PeliculaModel PeliculaModel { get; set; }
    }
}

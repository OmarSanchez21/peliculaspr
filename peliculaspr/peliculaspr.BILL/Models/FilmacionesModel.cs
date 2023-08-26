using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.BILL.Models
{
    public class FilmacionesModel
    {
        public int idfilmacion { get; set; }
        [ForeignKey("PeliculaModel")]
        public int id_pelicula { get; set; }
        [ForeignKey("LocacioneFilmacionesModel")]
        public int id_locacion { get; set; }
        public virtual PeliculaModel PeliculaModel { get; set; }
        public virtual LocacioneFilmacionesModel LocacioneFilmacionesModel { get; set; }

    }
}

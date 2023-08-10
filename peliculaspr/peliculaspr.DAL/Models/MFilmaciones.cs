﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.DAL.Models
{
    public class MFilmaciones : Core.AllEntity
    {
        [Key]
        public int idfilmacion { get; set; }
        [ForeignKey("MPeliculas")]
        public int id_pelicula { get; set; }
        [ForeignKey("MLocacionesFilmacion")]
        public int id_locacion { get; set; }
        public virtual MPelicula MPelicula { get; set; }
        public virtual MLocacionesFilmacion MLocacionesFilmacion { get; set; }

    }
}
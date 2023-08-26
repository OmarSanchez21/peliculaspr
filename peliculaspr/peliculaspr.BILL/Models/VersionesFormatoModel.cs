﻿using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.BILL.Models
{
    public class VersionesFormatoModel
    {
        public int idversiones { get; set; }
        public string? NombreVersion { get; set; }
        public string? Formato { get; set; }
        [ForeignKey("PeliculaModel")]
        public int id_pelicula { get; set; }
        public virtual PeliculaModel PeliculaModel { get; set; }
    }
}

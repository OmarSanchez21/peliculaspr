using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.BILL.Models
{
    public class ReseñaModel
    {
        public int idresena { get; set; }
        public string? Resena { get; set; }
        [ForeignKey("PeliculaModel")]
        public int id_peliculas { get; set; }
        [ForeignKey("CriticoModel")]
        public int id_critico { get; set; }
        public virtual PeliculaModel PeliculaModel { get; set; }
        public virtual CriticoModel CriticoModel { get; set; }
    }
}

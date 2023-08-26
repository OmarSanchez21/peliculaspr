using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.BILL.Models
{
    public class NominacionesModel
    {
        public int idnominaciones { get; set; }
        public string? NombreCategoria { get; set; }
        public int Año { get; set; }
        [ForeignKey("PeliculaModel")]
        public int id_pelicula { get; set; }
        public virtual PeliculaModel PeliculaModel { get; set; }
    }
}

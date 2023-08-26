using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.BILL.Models
{
    public class BandaSonoraModel
    {
        public int idbanda { get; set; }
        public string? NombreCancion { get; set; }
        public string Compositor { get; set; }
        [ForeignKey("PeliculaModel")]
        public int id_pelicula { get; set; }
        public virtual PeliculaModel PeliculaModel{ get; set; }
    }
}

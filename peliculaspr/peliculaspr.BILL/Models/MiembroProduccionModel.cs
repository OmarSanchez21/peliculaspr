using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.BILL.Models
{
    public class MiembroProduccionModel
    {
        public int idmiembros { get; set; }    
        public int id_peliculas { get; set; }
        [ForeignKey("PeliculaModel")]
        public int id_equipo { get; set; }
        [ForeignKey("EquipoProduccionModel ")]
        public virtual PeliculaModel PeliculaModel { get; set; }
        public virtual EquipoProduccionModel EquipoProduccionModel { get; set; }
    }
}

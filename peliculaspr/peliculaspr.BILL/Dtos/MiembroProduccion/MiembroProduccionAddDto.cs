using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.BILL.Dtos.MiembroProduccion
{
    public class MiembroProduccionAddDto
    {
        public int idmiembros { get; set; }
        public int id_peliculas { get; set; }
        public int id_equipo { get; set; }

    }
}

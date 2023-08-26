using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Dtos.MiembroProduccion
{
    public class MiembroProduccionRemoveDto
    {
        public int idmiembros { get; set; }
        public int id_peliculas { get; set; }
        public int id_equipo { get; set; }
    }
}

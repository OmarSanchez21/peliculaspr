using peliculaspr.BILL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.BILL.Dtos.BandaSonora
{
    public class BandaSonoraAddDto
    {
        public string? NombreCancion { get; set; }
        public string Compositor { get; set; }
        public int id_pelicula { get; set; }
    }
}

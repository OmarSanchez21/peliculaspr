using peliculaspr.BILL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace peliculaspr.BILL.Dtos.BandaSonora
{
    public class BandaSonoraUpdateDto
    {
        public int idbanda { get; set; }
        public string? NombreCancion { get; set; }
        public string Compositor { get; set; }

        public int id_pelicula { get; set; }

    }
}

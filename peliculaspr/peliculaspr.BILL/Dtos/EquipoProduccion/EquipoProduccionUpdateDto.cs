using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Dtos.EquipoProduccion
{
    public class EquipoProduccionUpdateDto
    {
        public int idequipo { get; set; }
        public string? NombreMiembro { get; set; }
        public string? Rol { get; set; }
    }
}

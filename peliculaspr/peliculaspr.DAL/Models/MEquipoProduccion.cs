using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace peliculaspr.DAL.Models
{
    public class MEquipoProduccion : Core.AllEntity
    {
        [Key]
        public int idequipo { get; set; }
        public string? NombreMiembro { get; set; }
        public string? Rol { get; set; }

    }
}

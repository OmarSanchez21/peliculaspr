using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace peliculaspr.DAL.Models
{
    public class MActor : Core.AllEntity
    {
        [Key]
        public int idactor { get; set; }
        public string? Nombre { get; set; }
        public DateTime Fecha_de_Nacimiento { get; set; }
        public string? Nacionalidad { get; set; }

    }
}

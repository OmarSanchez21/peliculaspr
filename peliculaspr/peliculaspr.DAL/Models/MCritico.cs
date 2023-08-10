using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace peliculaspr.DAL.Models
{
    public class MCritico : Core.AllEntity
    {
        [Key]
        public int idcritico { get; set; }
        public string? Nombre { get; set; }
        public string? MedioComuncacion { get; set; }
    }
}

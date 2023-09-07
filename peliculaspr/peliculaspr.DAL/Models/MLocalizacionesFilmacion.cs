using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace peliculaspr.DAL.Models
{
    public class MLocalizacionesFilmacion : Core.AllEntity
    {
        [Key]
        public int idlocacion { get; set; }
        public string? NombreLocacion { get; set; }
        public string? Direccion { get; set; }
    }
}

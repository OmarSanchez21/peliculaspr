using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Models
{
    public class PersonajeModel
    {
        public int idpersonaje { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int id_autor { get; set; }
        public int id_pelicula { get; set; }
        //Esto es la referencia para las tablas
        public virtual ActorModel ActorModel { get; set; }
        public virtual PeliculaModel PeliculaModel { get; set; }
    }
}

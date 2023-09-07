using peliculaspr.BILL.Dtos.Personaje;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Extentions
{
    public static class PersonajeExtention
    {
        public static MPersonaje GetPersonajeFromDtoAdd(this PersonajeAddDto addDto)
        {
            MPersonaje mPersonaje = new MPersonaje()
            { 
                Nombre = addDto.Nombre,
                Descripcion = addDto.Descripcion,
                id_actor = addDto.id_actor,
                id_pelicula = addDto.id_pelicula
            };
            return mPersonaje;
        }
    }
}

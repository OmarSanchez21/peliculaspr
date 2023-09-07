using peliculaspr.BILL.Dtos.Filmaciones;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Extentions
{
    public static class FilmacionesExtention
    {
        public static MFilmaciones GetFilmacionFromAddDto(this FilmacionesAddDto addDto) 
        {
            MFilmaciones filmaciones = new MFilmaciones() 
            {
                id_pelicula = addDto.id_pelicula,
                id_locacion = addDto.id_locacion
            };
            return filmaciones;
        }
    }
}

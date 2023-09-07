using peliculaspr.BILL.Dtos.Pelicula;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Extentions
{
    public static class PeliculaExtention
    {
        public static MPelicula GetPeliculaFromDtoSave(this PeliculaAddDto addDto)
        {
            MPelicula mPelicula = new MPelicula()
            {
                Titulo = addDto.Titulo,
                Año_de_Lanzamiento = addDto.Año_de_Lanzamient,
                Genero = addDto.Genero,
                Duracion = addDto.Duracion,
                Sinopsis = addDto.Sinopsis,
                CalificacionPromedio = addDto.CalificacionPromedio
            };
            return mPelicula;
        }
    }
}

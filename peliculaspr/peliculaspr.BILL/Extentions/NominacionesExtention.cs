using peliculaspr.BILL.Dtos.Nominaciones;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Extentions
{
    public static class NominacionesExtention
    {
        public static MNominaciones GetNominacionesFromDtoSave(this NominacionesAddDto nominacionesAddDto)
        { 
            MNominaciones mNominaciones = new MNominaciones()
            { 
                NombreCategoria = nominacionesAddDto.NombreCategoria,
                Año = nominacionesAddDto.Año,
                id_pelicula = nominacionesAddDto.id_pelicula
            };
            return mNominaciones;
        }
    }
}

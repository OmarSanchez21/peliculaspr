using peliculaspr.BILL.Dtos.LocacionesFilmaciones;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Extentions
{
    public static class LocalizacionesFilmacionesExtention
    {
        public static MLocalizacionesFilmacion GetLocacionesFilmacionFromDtoAdd(this LocalizacionesFilmacionesAddDto addDto)
        {
            MLocalizacionesFilmacion mLocacionesFilmacion = new MLocalizacionesFilmacion()
            {
                NombreLocacion = addDto.NombreLocacion,
                Direccion = addDto.Direccion
            };
            return mLocacionesFilmacion;
        }
    }
}

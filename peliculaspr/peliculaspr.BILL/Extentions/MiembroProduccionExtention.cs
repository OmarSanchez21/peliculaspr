using peliculaspr.BILL.Dtos.MiembroProduccion;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Extentions
{
    public static class MiembroProduccionExtention
    {
        public static MMiembroProduccion GetMiembroProduccionFromDtoSave(this MiembroProduccionAddDto addDto)
        {
            MMiembroProduccion mMiembroProduccion = new MMiembroProduccion()
            {
                id_peliculas = addDto.id_peliculas,
                id_equipo = addDto.id_equipo
            };
            return  mMiembroProduccion;
        }
    }
}

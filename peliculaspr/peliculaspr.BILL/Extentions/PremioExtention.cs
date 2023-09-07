using peliculaspr.BILL.Dtos.Premio;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Extentions
{
    public static class PremioExtention
    {
       public static MPremio GetPremioFromDtoSave(this PremioAddDto addDto)
        {
            MPremio mPremio = new MPremio()
            {
                NombrePremio = addDto.NombrePremio,
                Año = addDto.Año,
                Ganador = addDto.Ganador,
                id_pelicula = addDto.id_pelicula
            };
            return mPremio;
        }
    }
}

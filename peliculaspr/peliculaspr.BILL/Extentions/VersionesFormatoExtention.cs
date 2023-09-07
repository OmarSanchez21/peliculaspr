using peliculaspr.BILL.Dtos.VersionesFormato;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Extentions
{
    public static class VersionesFormatoExtention
    {
        public static MVersionesFormato GetVersionesFormatoFromDtoSave(this VersionesFormatoAddDto addDto)
        {
            MVersionesFormato mVersionesFormato = new MVersionesFormato()
            {
                NombreVersion = addDto.NombreVersion,
                Formato = addDto.Formato,
                id_pelicula = addDto.id_pelicula
            };
            return mVersionesFormato;
        }
    }
}

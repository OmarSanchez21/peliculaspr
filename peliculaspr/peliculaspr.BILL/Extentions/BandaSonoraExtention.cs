using peliculaspr.BILL.Dtos.BandaSonora;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Extentions
{
    public static class BandaSonoraExtention
    {
        public static MBandaSonora GetBandaSonoraEntityFromDtoSave(this BandaSonoraAddDto addDto)
        {
            MBandaSonora entity = new MBandaSonora()
            { 
                idbanda = addDto.idbanda,
                NombreCancion = addDto.NombreCancion,
                Compositor = addDto.Compositor,
                id_pelicula = addDto.id_pelicula
            };
            return entity;
        }
    }
}

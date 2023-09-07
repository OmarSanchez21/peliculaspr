using peliculaspr.BILL.Dtos.Reseña;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Extentions
{
    public static class ReseñaExtention
    {
        public static MReseña GetReseñaFromDtoSave(this ReseñaAddDto addDto) 
        {
            MReseña mReseña = new MReseña()
            {
                Resena = addDto.Resena,
                id_pelicula = addDto.id_pelicula,
                id_critico = addDto.id_critico
            };
            return mReseña;
        }
    }
}

using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Pelicula;
using peliculaspr.BILL.Dtos.Personaje;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Contract
{
    public interface IPeliculaService : IBaseService
    {
        ServiceResult AddPelicula(PeliculaAddDto peliculaAddDto);
        ServiceResult UpdatePelicula(PeliculaUpdateDto peliculaUpdateDto);
        ServiceResult RemovePelicula(PeliculaRemoveDto peliculaRemoveDto);
    }
}

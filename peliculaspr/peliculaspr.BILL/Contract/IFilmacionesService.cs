using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Filmaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Contract
{
    public interface IFilmacionesService : IBaseService
    {
        ServiceResult AddFilmaciones(FilmacionesAddDto filmacionesAddDto);
        ServiceResult UpdateFilmaciones(FilmacionUpdateDto filmacionUpdateDto);
        ServiceResult RemoveFilmaciones(FilmacionesRemoveDto filmacionesRemoveDto);
    }
}

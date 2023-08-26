using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.LocacionesFilmaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Contract
{
    public interface ILocaionesFilmaciones : IBaseService
    {
        ServiceResult AddLoacionesFilmaciones(LocacionesFilmacionesAddDto locacionesFilmacionesAddDto);
        ServiceResult UpdateLocacionesFilmaciones(LocacionesFilmacionesUpdateDto locacionesFilmacionesUpdateDto);
        ServiceResult RemoveLocacionesFilmaciones(LocacionesFilmacionesRemoveDto locacionesFilmacionesRemoveDto);
    }
}

using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.LocacionesFilmaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Contract
{
    public interface ILocalizacionesFilmacionesService : IBaseService
    {
        ServiceResult AddLoacionesFilmaciones(LocalizacionesFilmacionesAddDto locacionesFilmacionesAddDto);
        ServiceResult UpdateLocacionesFilmaciones(LocalizacionesFilmacionesUpdateDto locacionesFilmacionesUpdateDto);
        ServiceResult RemoveLocacionesFilmaciones(LocalizacionesFilmacionesRemoveDto locacionesFilmacionesRemoveDto);
    }
}

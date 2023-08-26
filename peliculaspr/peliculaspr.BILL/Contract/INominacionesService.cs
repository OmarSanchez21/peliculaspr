using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Nominaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Contract
{
    public interface INominacionesService : IBaseService
    {
        ServiceResult AddNominaciones(NominacionesAddDto nominacionesAddDto);
        ServiceResult UpdateNominaciones(NominacionesUpdateDto nominacionesUpdateDto);
        ServiceResult RemoveNominaciones(NominacionesRemoveDto nominacionesRemoveDto);
    }
}

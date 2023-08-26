using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Reseña;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Contract
{
    public interface IReseñaService : IBaseService
    {
        ServiceResult AddReseña(ReseñaAddDto reseñaAddDto);
        ServiceResult UpdateReseña(ReseñaUpdateDto reseñaUpdateDto);
        ServiceResult RemoveReseña(ReseñaRemoveDto reseñaRemoveDto);
    }
}

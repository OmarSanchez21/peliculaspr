using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.MiembroProduccion;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Contract
{
    public interface IMiembroProduccionService : IBaseService
    {
        ServiceResult AddMiembroProduccion(MiembroProduccionAddDto miembroProduccionAddDto);
        ServiceResult UpdateMiembroProduccion(MiembroProduccionUpdateDto miembroProduccionUpdateDto);
        ServiceResult RemoveMiembroProduccion(MiembroProduccionRemoveDto miembroProduccionRemoveDto);
    }
}

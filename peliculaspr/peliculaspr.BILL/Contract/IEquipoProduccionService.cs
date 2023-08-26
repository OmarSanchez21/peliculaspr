using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.EquipoProduccion;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Contract
{
    public interface IEquipoProduccionService : IBaseService
    {
        ServiceResult AddEquipoProduccion(EquipoProduccionAddDto equipoProduccionAddDto);
        ServiceResult UpdateEquipoProduccion(EquipoProduccionUpdateDto equipoProduccionUpdateDto);
        ServiceResult RemoveEquipoProduccion(EquipoProduccionRemoveDto equipoProduccionRemoveDto);
    }
}

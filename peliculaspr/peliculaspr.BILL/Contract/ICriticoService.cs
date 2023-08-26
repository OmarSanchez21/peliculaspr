using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Critico;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Contract
{
    public interface ICriticoService : IBaseService
    {
        ServiceResult SaveCritico(CriticoAddDto criticoAddDto);
        ServiceResult UpdateCritico(CriticoUpdateDto criticoUpdateDto);
        ServiceResult RemoveCritico(CriticoRemoveDto criticoRemoveDto);
    }
}

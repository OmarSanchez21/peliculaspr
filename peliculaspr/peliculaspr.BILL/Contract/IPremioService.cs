using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Premio;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Contract
{
    public interface IPremioService : IBaseService
    {
        ServiceResult AddPremio(PremioAddDto premioAddDto);
        ServiceResult UpdatePremio(PremioUpdateDto premioUpdateDto);
        ServiceResult RemovePremio(PremioRemoveDto premioRemoveDto);
    }
}

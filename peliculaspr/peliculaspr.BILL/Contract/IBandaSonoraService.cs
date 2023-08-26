using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.BandaSonora;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Contract
{
    public interface IBandaSonoraService : IBaseService
    {
        ServiceResult SaveBandaSonora(BandaSonoraAddDto bandaSonoraAddDto);
        ServiceResult UpdateBandaSonora(BandaSonoraUpdateDto bandaSonoraUpdateDto);
        ServiceResult RemoveBandaSonora(BandaSonoraRemoveDto bandaSonoraRemoveDto);
    }
}

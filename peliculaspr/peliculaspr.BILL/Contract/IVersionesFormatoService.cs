using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.VersionesFormato;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Contract
{
    public interface IVersionesFormatoService : IBaseService
    {
        ServiceResult AddVersionesFormato(VersionesFormatoAddDto versionesFormatoAddDto);
        ServiceResult UpdateVersionesFormato(VersionesFormatoUpdateDto versionesFormatoUpdateDto);
        ServiceResult RemoveVersionesFormato(VersionesFormatoRemoveDto versionesFormatoRemoveDto);
    }
}

using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Actor;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Contract
{
    public interface IAutorService : IBaseService
    {
        ServiceResult SaveActor(ActorAddDto actorAddDto);
        ServiceResult UpdateActor(ActorUpdateDto actorUpdateDto);
        ServiceResult RemoveActor(ActorRemoveDto actorRemoveDto);
    }
}

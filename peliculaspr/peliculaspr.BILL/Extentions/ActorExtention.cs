using peliculaspr.BILL.Dtos.Actor;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Extentions
{
    public static class ActorExtention
    {
        public static MActor GetMActorEntityFromDtoSave(this ActorAddDto actorAddDto)
        {
            MActor mActor = new MActor()
            {
                Nombre = actorAddDto.Nombre,
                Nacionalidad = actorAddDto.Nacionalidad,
                Fecha_de_Nacimiento = actorAddDto.Fecha_de_Nacimiento
            };
            return mActor;
        }
    }
}

using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Actor;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Validations
{
    public static class ValidationsActor
    {
       public static ServiceResult IsValidActorAdd(ActorAddDto actorAddDto)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(actorAddDto.Nombre))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if(string.IsNullOrEmpty(actorAddDto.Nacionalidad))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if(actorAddDto.Nombre.Length > 255)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if(actorAddDto.Nacionalidad.Length > 100)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            return result;
        }
        public static ServiceResult IsValidActorUpd(ActorUpdateDto actorUpdateDto)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(actorUpdateDto.Nombre))
            {
                result.Success = false;
                result.Message = "Es necesario el nombre";
                return result;
            }
            if (string.IsNullOrEmpty(actorUpdateDto.Nacionalidad))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (actorUpdateDto.Nombre.Length > 255)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if (actorUpdateDto.Nacionalidad.Length > 100)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            return result;
        }
    }
}

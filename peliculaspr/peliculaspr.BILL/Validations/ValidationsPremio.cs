using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Premio;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Validations
{
    public static class ValidationsPremio
    {
        public static ServiceResult ValidationsPremioAdd(PremioAddDto premioAddDto) 
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(premioAddDto.NombrePremio))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if(premioAddDto.NombrePremio.Length >150)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if(premioAddDto.Año == 0000)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNumber;
                return result;
            }
            return result;
        }
        public static ServiceResult ValidationsPremioUp(PremioUpdateDto premioUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(premioUpdateDto.NombrePremio))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (premioUpdateDto.NombrePremio.Length > 150)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if (premioUpdateDto.Año == 0000)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNumber;
                return result;
            }
            return result;
        }
    }
}

using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.VersionesFormato;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Validations
{
    public static class ValidationsVersionesFormato
    {
       
        public static ServiceResult IsValidVersionesAdd(VersionesFormatoAddDto versionesFormatoAddDto)
        {
            ServiceResult result = new ServiceResult();
            if(string.IsNullOrEmpty(versionesFormatoAddDto.NombreVersion))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (string.IsNullOrEmpty(versionesFormatoAddDto.Formato))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if(versionesFormatoAddDto.NombreVersion.Length >50)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if(versionesFormatoAddDto.Formato.Length > 50)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            return result;
        }
        public static ServiceResult IsValidVersionesUpdate(VersionesFormatoUpdateDto versionesFormatoUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(versionesFormatoUpdateDto.NombreVersion))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (string.IsNullOrEmpty(versionesFormatoUpdateDto.Formato))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (versionesFormatoUpdateDto.NombreVersion.Length > 50)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if (versionesFormatoUpdateDto.Formato.Length > 50)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            return result;
        }
    }
}

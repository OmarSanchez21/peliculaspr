using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Nominaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Validations
{
    public static class ValidationsNominaciones
    {
        public static ServiceResult ValidationsNominacionesAdd(NominacionesAddDto nominacionesAddDto)
        {
            ServiceResult result = new ServiceResult();
            if(string.IsNullOrEmpty(nominacionesAddDto.NombreCategoria))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if(nominacionesAddDto.NombreCategoria.Length > 100)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            return result;
        }
        public static ServiceResult ValidationsNominacionesÙp(NominacionesUpdateDto nominacionesUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(nominacionesUpdateDto.NombreCategoria))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (nominacionesUpdateDto.NombreCategoria.Length > 100)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            return result;
        }
    }
}

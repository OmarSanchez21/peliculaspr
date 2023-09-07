using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Actor;
using peliculaspr.BILL.Dtos.BandaSonora;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Validations
{
    public static class ValidationsBandaSonora
    {
        public static ServiceResult IsValidBnadaSonora(BandaSonoraAddDto bandaSonoraAddDto)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(bandaSonoraAddDto.NombreCancion))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if(string.IsNullOrEmpty(bandaSonoraAddDto.Compositor))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if(bandaSonoraAddDto.NombreCancion.Length > 100)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if(bandaSonoraAddDto.Compositor.Length > 100)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            return result;
        }
        public static ServiceResult IsValidBandaSonoraUp(BandaSonoraUpdateDto bandaSonoraUpdateDto)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(bandaSonoraUpdateDto.NombreCancion))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (string.IsNullOrEmpty(bandaSonoraUpdateDto.Compositor))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (bandaSonoraUpdateDto.NombreCancion.Length > 100)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if (bandaSonoraUpdateDto.Compositor.Length > 100)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            return result;
        }
    }
}

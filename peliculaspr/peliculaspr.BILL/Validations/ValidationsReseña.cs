using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Reseña;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Validations
{
    public static class ValidationsReseña
    {
        public static ServiceResult ValidationResenaAdd(ReseñaAddDto reseñaAddDto) 
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(reseñaAddDto.Resena)) 
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            return result;
        } 
        public static ServiceResult ValidationsResenaUp(ReseñaUpdateDto reseñaUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(reseñaUpdateDto.Resena))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            return result;

        }
    }
}

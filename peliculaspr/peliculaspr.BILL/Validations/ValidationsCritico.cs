using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Critico;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Validations
{
    public static class ValidationsCritico
    {
        public static ServiceResult ValidationsCriticoAdd(CriticoAddDto critico)
        {
            ServiceResult result = new ServiceResult();
            if(string.IsNullOrEmpty(critico.Nombre))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if(string.IsNullOrEmpty(critico.MedioComuncacion))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if(critico.Nombre.Length > 255)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if(critico.MedioComuncacion.Length >150)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result; 
            }
            return result;
        }
        public static ServiceResult ValidationsCriticoUp(CriticoUpdateDto critico)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(critico.Nombre))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (string.IsNullOrEmpty(critico.MedioComuncacion))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (critico.Nombre.Length > 255)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if (critico.MedioComuncacion.Length > 150)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            return result;
        }
    }
}

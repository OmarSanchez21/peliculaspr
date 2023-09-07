using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.LocacionesFilmaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Validations
{
    public static class ValidationsLocalizacionesFilmaciones
    {
        public static ServiceResult ValidationsLocacionesAdd(LocalizacionesFilmacionesAddDto locacionesFilmacionesAddDto)
        {
            ServiceResult result = new ServiceResult();
            if(string.IsNullOrEmpty(locacionesFilmacionesAddDto.NombreLocacion))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if(string.IsNullOrEmpty(locacionesFilmacionesAddDto.Direccion))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (locacionesFilmacionesAddDto.NombreLocacion.Length > 150)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if(locacionesFilmacionesAddDto.Direccion.Length > 75)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            return result;
        }

        public static ServiceResult ValidationsLocacionesUp(LocalizacionesFilmacionesUpdateDto locacionesFilmacionesUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(locacionesFilmacionesUpdateDto.NombreLocacion))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (string.IsNullOrEmpty(locacionesFilmacionesUpdateDto.Direccion))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (locacionesFilmacionesUpdateDto.NombreLocacion.Length > 150)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if (locacionesFilmacionesUpdateDto.Direccion.Length > 75)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            return result;
        }
    }
}

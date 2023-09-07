using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Personaje;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Validations
{
    public static class ValidationsPersonaje
    {
        public static ServiceResult ValidationsPersonajeAdd(PersonajeAddDto personajeAddDto)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(personajeAddDto.Nombre))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (personajeAddDto.Nombre.Length > 255)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if (string.IsNullOrEmpty(personajeAddDto.Descripcion))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            return result;
        }
        public static ServiceResult ValidationsPersonajeUp(PersonajeUpdateDto personajeUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(personajeUpdateDto.Nombre))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (personajeUpdateDto.Nombre.Length > 255)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if (string.IsNullOrEmpty(personajeUpdateDto.Descripcion))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            return result;
        }
    }
}
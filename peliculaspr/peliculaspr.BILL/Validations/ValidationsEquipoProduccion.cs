using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.EquipoProduccion;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Validations
{
    public static class ValidationsEquipoProduccion
    {
        public static ServiceResult ValidationsEquipoProduccionAdd(EquipoProduccionAddDto equipoProduccionAddDto)
        {
            ServiceResult result = new ServiceResult();
            if(string.IsNullOrEmpty(equipoProduccionAddDto.NombreMiembro))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (string.IsNullOrEmpty(equipoProduccionAddDto.Rol))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if(equipoProduccionAddDto.NombreMiembro.Length > 150)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if(equipoProduccionAddDto.Rol.Length > 75)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            return result;
        }
        public static ServiceResult ValidationsEquipoProduccionUp(EquipoProduccionUpdateDto equipo)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(equipo.NombreMiembro))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (string.IsNullOrEmpty(equipo.Rol))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (equipo.NombreMiembro.Length > 150)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if (equipo.Rol.Length > 75)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            return result;
        }

    }
}

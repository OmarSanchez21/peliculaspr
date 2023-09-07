using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Pelicula;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Validations
{
    public static class ValidationsPelicula
    {
        public static ServiceResult ValidationsPeliculaAdd(PeliculaAddDto peliculaAddDto)
        {
            ServiceResult result = new ServiceResult();
            if(string.IsNullOrEmpty(peliculaAddDto.Titulo))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (peliculaAddDto.Titulo.Length > 50)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if(string.IsNullOrEmpty(peliculaAddDto.Genero))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            return result;
        }

        public static ServiceResult ValidationsPeliculaUp(PeliculaUpdateDto peliculaUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(peliculaUpdateDto.Titulo))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            if (peliculaUpdateDto.Titulo.Length > 50)
            {
                result.Success = false;
                result.Message = ValidationEntity.validationLength;
                return result;
            }
            if (string.IsNullOrEmpty(peliculaUpdateDto.Genero))
            {
                result.Success = false;
                result.Message = ValidationEntity.validationNull;
                return result;
            }
            return result;
        }
    }
}

using Microsoft.Extensions.Logging;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Nominaciones;
using peliculaspr.BILL.Extentions;
using peliculaspr.BILL.Models;
using peliculaspr.BILL.Validations;
using peliculaspr.DAL.Exceptions;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace peliculaspr.BILL.Services
{
    public class NominacionesService : INominacionesService
    {
        private readonly INominacionesRepository nominacionesRepository;
        private readonly ILogger<NominacionesService> logger;
        public NominacionesService(INominacionesRepository nominacionesRepository, ILogger<NominacionesService> logger)
        {
            this.nominacionesRepository = nominacionesRepository;
            this.logger = logger;
        }

        

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando las nominaciones");
                var nominacion = this.nominacionesRepository.GetEntities()
                                                                .Select(nom => new NominacionesModel()
                                                                {
                                                                    idnominaciones = nom.idnominaciones,
                                                                    NombreCategoria = nom.NombreCategoria,
                                                                    Año = nom.Año,
                                                                    id_pelicula = nom.id_pelicula
                                                                }).ToList();
                result.Data = nominacion;
                this.logger.LogInformation("Se consulto las nominaciones");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error consultando la nominaciones";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultado la nominacion");
                var nominaciones = this.nominacionesRepository.GetEntity(id);
                NominacionesModel nominacionesModel = new NominacionesModel()
                {
                    idnominaciones = nominaciones.idnominaciones,
                    NombreCategoria = nominaciones.NombreCategoria,
                    Año = nominaciones.Año,
                    id_pelicula = nominaciones.id_pelicula
                };
                result.Data = nominacionesModel;
                this.logger.LogInformation("Se consulto la nominacion");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error consultando la nominacion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveNominaciones(NominacionesRemoveDto nominacionesRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MNominaciones mNominaciones = this.nominacionesRepository.GetEntity(nominacionesRemoveDto.idnominaciones);
                mNominaciones.idnominaciones = nominacionesRemoveDto.idnominaciones;
                mNominaciones.IsDeleted = true;

                this.nominacionesRepository.Update(mNominaciones);
                this.nominacionesRepository.SaveChanges();
                result.Message = "Se ha eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error eliminando la nominacion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult AddNominaciones(NominacionesAddDto nominacionesAddDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsNominaciones.ValidationsNominacionesAdd(nominacionesAddDto);
            }
            catch (NominacionesDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            try
            {
                MNominaciones mNominaciones = nominacionesAddDto.GetNominacionesFromDtoSave();
                this.nominacionesRepository.Save(mNominaciones);
                this.nominacionesRepository.SaveChanges();
                result.Message = "Se ha guardado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error guardando";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult UpdateNominaciones(NominacionesUpdateDto nominacionesUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsNominaciones.ValidationsNominacionesÙp(nominacionesUpdateDto);

                MNominaciones mNominaciones = this.nominacionesRepository.GetEntity(nominacionesUpdateDto.idnominaciones);

                mNominaciones.idnominaciones = nominacionesUpdateDto.idnominaciones;
                mNominaciones.NombreCategoria = nominacionesUpdateDto.NombreCategoria;
                mNominaciones.Año = nominacionesUpdateDto.Año;
                mNominaciones.id_pelicula = nominacionesUpdateDto.id_pelicula;

                this.nominacionesRepository.Update(mNominaciones);
                this.nominacionesRepository.SaveChanges();
                result.Message = "La nominacion fue modificada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error modificando";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}

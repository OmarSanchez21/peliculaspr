using Microsoft.Extensions.Logging;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.LocacionesFilmaciones;
using peliculaspr.BILL.Exceptions;
using peliculaspr.BILL.Extentions;
using peliculaspr.BILL.Models;
using peliculaspr.BILL.Validations;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace peliculaspr.BILL.Services
{
    public class LocalizacionesFilmacionesService : ILocalizacionesFilmacionesService
    {
        private readonly ILocalizacionesFilmacionRepository localizacionesFilmacionRepository;
        private readonly ILogger<LocalizacionesFilmacionesService> logger;
        public LocalizacionesFilmacionesService(ILocalizacionesFilmacionRepository localizacionesFilmacionRepository, ILogger<LocalizacionesFilmacionesService> logger)
        {
            this.localizacionesFilmacionRepository = localizacionesFilmacionRepository;
            this.logger = logger;
        }

        

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando las Localizaciones");
                var localizacion = this.localizacionesFilmacionRepository.GetEntities()
                                                                                .Select(loc => new LocalizacioneFilmacionesModel()
                                                                                {
                                                                                    idlocacion = loc.idlocacion,
                                                                                    NombreLocacion = loc.NombreLocacion,
                                                                                    Direccion = loc.Direccion
                                                                                }).ToList();
                result.Data = localizacion;
                this.logger.LogInformation("Se consulto las Localizaciones");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error consultando las localizaciones";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando la localizacion");
                var log = this.localizacionesFilmacionRepository.GetEntity(id);
                LocalizacioneFilmacionesModel localizacioneFilmacionesModel = new LocalizacioneFilmacionesModel()
                { 
                    idlocacion = log.idlocacion,
                    NombreLocacion = log.NombreLocacion,
                    Direccion = log.Direccion
                };
                result.Data = localizacioneFilmacionesModel;
                this.logger.LogInformation("Se consulto la localizacion");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error en la busqueda";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult AddLoacionesFilmaciones(LocalizacionesFilmacionesAddDto locacionesFilmacionesAddDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsLocalizacionesFilmaciones.ValidationsLocacionesAdd(locacionesFilmacionesAddDto);
            }
            catch (LocalizacionesFilmacionesException adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            try
            {
                MLocalizacionesFilmacion mLocalizacionesFilmacion = locacionesFilmacionesAddDto.GetLocacionesFilmacionFromDtoAdd();
                this.localizacionesFilmacionRepository.Save(mLocalizacionesFilmacion);
                this.localizacionesFilmacionRepository.SaveChanges();
                result.Message = "Se ha guardado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error guardando la localizacion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveLocacionesFilmaciones(LocalizacionesFilmacionesRemoveDto locacionesFilmacionesRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MLocalizacionesFilmacion mLocalizacionesFilmacion = this.localizacionesFilmacionRepository.GetEntity(locacionesFilmacionesRemoveDto.idlocacion);
                mLocalizacionesFilmacion.idlocacion = locacionesFilmacionesRemoveDto.idlocacion;
                mLocalizacionesFilmacion.IsDeleted = true;

                localizacionesFilmacionRepository.Update(mLocalizacionesFilmacion);
                localizacionesFilmacionRepository.SaveChanges();
                result.Message = "La Localizacion fue removida correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error removiendo la localizacion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateLocacionesFilmaciones(LocalizacionesFilmacionesUpdateDto locacionesFilmacionesUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsLocalizacionesFilmaciones.ValidationsLocacionesUp(locacionesFilmacionesUpdateDto);

                MLocalizacionesFilmacion mLocalizacionesFilmacion = this.localizacionesFilmacionRepository.GetEntity(locacionesFilmacionesUpdateDto.idlocacion);

                mLocalizacionesFilmacion.idlocacion = locacionesFilmacionesUpdateDto.idlocacion;
                mLocalizacionesFilmacion.NombreLocacion = locacionesFilmacionesUpdateDto.NombreLocacion;
                mLocalizacionesFilmacion.Direccion = locacionesFilmacionesUpdateDto.Direccion;

                this.localizacionesFilmacionRepository.Update(mLocalizacionesFilmacion);
                this.localizacionesFilmacionRepository.SaveChanges();
                result.Message = "La localizacion fue modificada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error modificando la localizacion";
                this.logger.LogError($"{result.Message}", ex.ToString());
                throw;
            }
            return result;
        }
    }
}

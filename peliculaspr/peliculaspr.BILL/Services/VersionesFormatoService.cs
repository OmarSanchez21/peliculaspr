using Microsoft.Extensions.Logging;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.VersionesFormato;
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
    public class VersionesFormatoService : IVersionesFormatoService
    {
        private readonly IVersionesFormatoRepository versionesFormatoRepository;
        private readonly ILogger<VersionesFormatoService> logger;
        public VersionesFormatoService(IVersionesFormatoRepository versionesFormatoRepository, ILogger<VersionesFormatoService> logger)
        {
            this.versionesFormatoRepository = versionesFormatoRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando las versiones de formato");
                var versiones = this.versionesFormatoRepository.GetEntities()
                                                                    .Select(ver => new VersionesFormatoModel()
                                                                    {
                                                                        idversiones = ver.idversiones,
                                                                        NombreVersion = ver.NombreVersion,
                                                                        Formato = ver.Formato,
                                                                        id_pelicula = ver.id_pelicula
                                                                    }).ToList();
                result.Data = versiones;
                this.logger.LogInformation("Se consulto las versiones de formato");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error consultando las versiones de formato";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando la version de formato");
                var version = this.versionesFormatoRepository.GetEntity(id);
                VersionesFormatoModel versionesFormatoModel = new VersionesFormatoModel()
                { 
                    idversiones = version.idversiones,
                    NombreVersion = version.NombreVersion,
                    Formato = version.Formato,
                    id_pelicula = version.id_pelicula
                };
                result.Data = versionesFormatoModel;
                this.logger.LogInformation("Se consulto la version de formato");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error consultando la version de formato";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult AddVersionesFormato(VersionesFormatoAddDto versionesFormatoAddDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsVersionesFormato.IsValidVersionesAdd(versionesFormatoAddDto);
            }
            catch (VersionesFormatoDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            try
            {
                MVersionesFormato mVersionesFormato = versionesFormatoAddDto.GetVersionesFormatoFromDtoSave();
                this.versionesFormatoRepository.Save(mVersionesFormato);
                this.versionesFormatoRepository.SaveChanges();
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

        public ServiceResult RemoveVersionesFormato(VersionesFormatoRemoveDto versionesFormatoRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MVersionesFormato mVersionesFormato = this.versionesFormatoRepository.GetEntity(versionesFormatoRemoveDto.idversiones);
                mVersionesFormato.idversiones = versionesFormatoRemoveDto.idversiones;
                mVersionesFormato.IsDeleted = true;

                this.versionesFormatoRepository.Update(mVersionesFormato);
                this.versionesFormatoRepository.SaveChanges();
                result.Message = "Se ha removido correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error removiendo";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateVersionesFormato(VersionesFormatoUpdateDto versionesFormatoUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsVersionesFormato.IsValidVersionesUpdate(versionesFormatoUpdateDto);

                MVersionesFormato mVersionesFormato = this.versionesFormatoRepository.GetEntity(versionesFormatoUpdateDto.idversiones);

                mVersionesFormato.idversiones = versionesFormatoUpdateDto.idversiones;
                mVersionesFormato.NombreVersion = versionesFormatoUpdateDto.NombreVersion;
                mVersionesFormato.Formato = versionesFormatoUpdateDto.Formato;
                mVersionesFormato.id_pelicula = versionesFormatoUpdateDto.id_pelicula;

                this.versionesFormatoRepository.Update(mVersionesFormato);
                this.versionesFormatoRepository.SaveChanges();
                result.Message = "Se ha modificado correctamente";
            }
            catch (VersionesFormatoDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
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

using Microsoft.Extensions.Logging;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Premio;
using peliculaspr.BILL.Models;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Models;
using System;
using peliculaspr.DAL.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using peliculaspr.BILL.Validations;
using peliculaspr.BILL.Extentions;

namespace peliculaspr.BILL.Services
{
    public class PremioService : IPremioService
    {
        private readonly IPremioRepository premioRepository;
        private readonly ILogger<PremioService> logger;
        public PremioService(IPremioRepository premioRepository,ILogger<PremioService> logger)
        { 
            this.premioRepository = premioRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando los premios registrados");
                var premio = this.premioRepository.GetEntities()
                                                        .Select(pre => new PremioModel()
                                                        { 
                                                            idpremios = pre.idpremios,
                                                            NombrePremio = pre.NombrePremio,
                                                            Año = pre.Año,
                                                            Ganador = pre.Ganador,
                                                            id_pelicula = pre.id_pelicula
                                                        }
                                                        ).ToList();
                result.Data = premio;
                this.logger.LogInformation("Se consulto los premios registrados");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error consultando los premios";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var premio = this.premioRepository.GetEntity(id);
                PremioModel premioModel = new PremioModel()
                {
                    idpremios = premio.idpremios,
                    NombrePremio = premio.NombrePremio,
                    Año = premio.Año,
                    Ganador = premio.Ganador,
                    id_pelicula = premio.id_pelicula
                };
                result.Data = premioModel;
                this.logger.LogInformation("Se consulto el premio");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult AddPremio(PremioAddDto premioAddDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsPremio.ValidationsPremioAdd(premioAddDto);
            }
            catch (PremioDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            try
            {
                MPremio mPremio = premioAddDto.GetPremioFromDtoSave();
                this.premioRepository.Save(mPremio);
                this.premioRepository.SaveChanges();
                result.Message = "Se ha guardado el premio";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error guardando";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult RemovePremio(PremioRemoveDto premioRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MPremio mPremio = this.premioRepository.GetEntity(premioRemoveDto.idpremios);
                mPremio.idpremios = premioRemoveDto.idpremios;
                mPremio.IsDeleted = true;

                this.premioRepository.Update(mPremio);
                this.premioRepository.SaveChanges();
                result.Message = "Ha eliminado el premio correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error obtiendo el premio";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdatePremio(PremioUpdateDto premioUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MPremio mPremio = this.premioRepository.GetEntity(premioUpdateDto.idpremios);

                mPremio.idpremios = premioUpdateDto.idpremios;
                mPremio.NombrePremio = premioUpdateDto.NombrePremio;
                mPremio.Año = premioUpdateDto.Año;
                mPremio.Ganador = premioUpdateDto.Ganador;
                mPremio.id_pelicula = premioUpdateDto.id_pelicula;

                this.premioRepository.Update(mPremio);
                this.premioRepository.SaveChanges();
                result.Message = "Se ha modificado el premio";
            }
            catch(PremioDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error modificando el premio";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}

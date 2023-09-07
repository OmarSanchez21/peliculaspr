using Microsoft.Extensions.Logging;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Critico;
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
    public class CriticoService : ICriticoService
    {
        private readonly ICriticoRepository criticoRepository;
        private readonly ILogger<CriticoService> logger;
        public CriticoService(ICriticoRepository criticoRepository, ILogger<CriticoService> logger)
        {
            this.criticoRepository = criticoRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando los criticos");
                var critico = this.criticoRepository.GetEntities()
                                                        .Select(crit => new CriticoModel()
                                                        {
                                                            idcritico = crit.idcritico,
                                                            Nombre = crit.Nombre,
                                                            MedioComuncacion = crit.MedioComuncacion
                                                        }).ToList();
                result.Data = critico;
                this.logger.LogInformation("Se consulto los criticos");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error obteniendo los critiocs";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando el critico");

                var critico = this.criticoRepository.GetEntity(id);
                CriticoModel model = new CriticoModel()
                { 
                    idcritico = critico.idcritico,
                    Nombre = critico.Nombre,
                    MedioComuncacion = critico.MedioComuncacion
                };
                result.Data = model;
                this.logger.LogInformation("Se consulto el critico");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error consultando el critico";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveCritico(CriticoRemoveDto criticoRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DAL.Models.MCritico critico = this.criticoRepository.GetEntity(criticoRemoveDto.idcritico);

                critico.idcritico = criticoRemoveDto.idcritico;
                critico.IsDeleted = true;

                this.criticoRepository.Update(critico);
                this.criticoRepository.SaveChanges();
                result.Message = "El critico fue removido correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error removiendo el critico";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveCritico(CriticoAddDto criticoAddDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsCritico.ValidationsCriticoAdd(criticoAddDto);
            }
            catch (CriticoDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            try
            {
                MCritico critico = criticoAddDto.GetCriticoFromDtoSave();
                this.criticoRepository.Save(critico);
                this.criticoRepository.SaveChanges();
                result.Message = "El critico fue guardado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error guardando el critico";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateCritico(CriticoUpdateDto criticoUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsCritico.ValidationsCriticoUp(criticoUpdateDto);

                MCritico critico = this.criticoRepository.GetEntity(criticoUpdateDto.idcritico);

                critico.idcritico = criticoUpdateDto.idcritico;
                critico.Nombre = criticoUpdateDto.Nombre;
                critico.MedioComuncacion = criticoUpdateDto.MedioComuncacion;

                this.criticoRepository.Update(critico);
                this.criticoRepository.SaveChanges();
                result.Message = "El critico fue modificado correctamente";
            }
            catch (CriticoDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error modificando el critico";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}

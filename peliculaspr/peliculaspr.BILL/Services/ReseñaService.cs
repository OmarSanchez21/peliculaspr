using Microsoft.Extensions.Logging;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Reseña;
using peliculaspr.BILL.Extentions;
using peliculaspr.BILL.Models;
using peliculaspr.BILL.Validations;
using peliculaspr.DAL.Exceptions;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace peliculaspr.BILL.Services
{
    public class ReseñaService : IReseñaService
    {
        private readonly IReseñaRepository reseñaRepository;
        private readonly ILogger<ReseñaService> logger;
        public ReseñaService(IReseñaRepository reseñaRepository, ILogger<ReseñaService> logger)
        {
            this.reseñaRepository = reseñaRepository;
            this.logger = logger;
        }

        
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando las reseñas");
                var resena = this.reseñaRepository.GetEntities()
                                                        .Select(re => new ReseñaModel()
                                                        {
                                                            idresena = re.idresena,
                                                            Resena = re.Resena,
                                                            id_pelicula = re.id_pelicula,
                                                            id_critico = re.id_critico
                                                        }).ToList();
                result.Data = resena;
                this.logger.LogInformation("Se ha consultado las reseñas");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error consultando la reseña";
                this.logger.LogError($"{result.Message}", ex.ToString());
                throw;
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando la reseña");
                var resena = this.reseñaRepository.GetEntity(id);
                ReseñaModel reseñaModel = new ReseñaModel()
                { 
                    idresena = resena.idresena,
                    Resena = resena.Resena,
                    id_pelicula = resena.id_pelicula,
                    id_critico = resena.id_critico
                };
                result.Data = reseñaModel;
                this.logger.LogInformation("Se consulto la reseña");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error consultando la reseña";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult AddReseña(ReseñaAddDto reseñaAddDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsReseña.ValidationResenaAdd(reseñaAddDto);
            }
            catch (ReseñaDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            try
            {
                MReseña mReseña = reseñaAddDto.GetReseñaFromDtoSave();
                this.reseñaRepository.Save(mReseña);
                this.reseñaRepository.SaveChanges();
                result.Message = "Se ha guardado la Reseña";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error guardando la reseña";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveReseña(ReseñaRemoveDto reseñaRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MReseña mReseña = this.reseñaRepository.GetEntity(reseñaRemoveDto.idresena);
                mReseña.idresena = reseñaRemoveDto.idresena;
                mReseña.IsDeleted = true;

                this.reseñaRepository.Update(mReseña);
                this.reseñaRepository.SaveChanges();
                result.Message = "Se ha eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error eliminando la reseña";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateReseña(ReseñaUpdateDto reseñaUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsReseña.ValidationsResenaUp(reseñaUpdateDto);

                MReseña mReseña = this.reseñaRepository.GetEntity(reseñaUpdateDto.idresena);

                mReseña.idresena = reseñaUpdateDto.idresena;
                mReseña.Resena = reseñaUpdateDto.Resena;
                mReseña.id_pelicula = reseñaUpdateDto.id_pelicula;
                mReseña.id_critico = reseñaUpdateDto.id_critico;

                this.reseñaRepository.Update(mReseña);
                this.reseñaRepository.SaveChanges();
                result.Message = "Se ha modificado correctamente";
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}

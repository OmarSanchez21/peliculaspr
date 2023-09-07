using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Actor;
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
    public class ActorService : IActorService
    {
        private readonly IActorsRepository actorsRepository;
        private readonly ILogger<ActorService> logger;
        public ActorService(IActorsRepository actorsRepository, ILogger<ActorService> logger)
        {
            this.actorsRepository = actorsRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultadno los Actores");
                var actor = this.actorsRepository.GetEntities()
                                                    .Select(act => new ActorModel()
                                                    {
                                                        idactor = act.idactor,
                                                        Nombre = act.Nombre,
                                                        Nacionalidad = act.Nacionalidad,
                                                        Fecha_de_Nacimiento = act.Fecha_de_Nacimiento
                                                    }).ToList();
                result.Data = actor;
                this.logger.LogInformation("Se consulto los Actores");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Hubo un error obteniendo los actores";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando el actor");
                var actor = this.actorsRepository.GetEntity(id);
                ActorModel mActor = new ActorModel()
                {
                    idactor = actor.idactor,
                    Nombre = actor.Nombre,
                    Nacionalidad = actor.Nacionalidad,
                    Fecha_de_Nacimiento = actor.Fecha_de_Nacimiento
                };
                result.Data = mActor;
                this.logger.LogInformation("Se completo la consulta del actor");
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo los actores";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return (result);
        }

        public ServiceResult RemoveActor(ActorRemoveDto actorRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MActor mActor = this.actorsRepository.GetEntity(actorRemoveDto.idactor);
                mActor.idactor = actorRemoveDto.idactor;
                mActor.IsDeleted = true;

                this.actorsRepository.Update(mActor);
                this.actorsRepository.SaveChanges();
                result.Message = "El actor fue removido correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error borrando los actores";
                this.logger.LogError($"{result.Message}", ex.ToString());
                
            }
            return (result);
        }

        public ServiceResult SaveActor(ActorAddDto actorAddDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsActor.IsValidActorAdd(actorAddDto);
            }
            catch (ActorDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            try
            {
                MActor mActor = actorAddDto.GetMActorEntityFromDtoSave();
                this.actorsRepository.Save(mActor);
                this.actorsRepository.SaveChanges();
                result.Message = "El Actor fue ingresado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el actor";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return (result);
        }

        public ServiceResult UpdateActor(ActorUpdateDto actorUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsActor.IsValidActorUpd(actorUpdateDto);
                MActor mActor = this.actorsRepository.GetEntity(actorUpdateDto.idactor);

                mActor.idactor = actorUpdateDto.idactor;
                mActor.Nombre = actorUpdateDto.Nombre;
                mActor.Nacionalidad = actorUpdateDto.Nacionalidad;
                mActor.Fecha_de_Nacimiento = actorUpdateDto.Fecha_de_Nacimiento;
                
                this.actorsRepository.Update(mActor);
                this.actorsRepository.SaveChanges();
                result.Message = "El actor fue modificado correctamente";
            }
            catch(ActorDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError(result.Message, adex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false; 
                result.Message = "Error modificando el actor";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return (result);
        }
    }
}

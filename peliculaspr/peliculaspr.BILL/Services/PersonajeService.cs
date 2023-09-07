using Microsoft.Extensions.Logging;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Personaje;
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
    public class PersonajeService : IPersonajeService
    {
        private readonly IPersonajeRepository personajeRepository;
        private readonly ILogger<PersonajeService> logger;
        public PersonajeService(IPersonajeRepository personajeRepository, ILogger<PersonajeService> logger)
        {
            this.personajeRepository = personajeRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando los Personajes");
                var personaje = this.personajeRepository.GetEntities()
                                                            .Select(per => new PersonajeModel()
                                                            {
                                                                idpersonaje = per.idpersonaje,
                                                                Nombre = per.Nombre,
                                                                Descripcion = per.Descripcion,
                                                                id_actor = per.id_actor,
                                                                id_pelicula = per.id_pelicula
                                                            }).ToList();
                result.Data = personaje;
                this.logger.LogInformation("Se consulto los personajes");
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando el personaje");
                var personaje = this.personajeRepository.GetEntity(id);
                PersonajeModel personajeModel = new PersonajeModel()
                { 
                  idpersonaje = personaje.idpersonaje,
                  Nombre = personaje.Nombre,
                  Descripcion = personaje.Descripcion,
                  id_actor = personaje.id_actor,
                  id_pelicula = personaje.id_pelicula
                };
                result.Data = personajeModel;
                this.logger.LogInformation("Se consulto el personaje");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error obtiendo el personaje";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemovePersonaje(PersonajeRemoveDto personajeRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MPersonaje mPersonaje = this.personajeRepository.GetEntity(personajeRemoveDto.idpersonaje);
                mPersonaje.idpersonaje = personajeRemoveDto.idpersonaje;
                mPersonaje.IsDeleted = true;

                this.personajeRepository.Update(mPersonaje);
                this.personajeRepository.SaveChanges();
                result.Message = "El personaje fue eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error eliminando el personaje";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult AddPersonaje(PersonajeAddDto personajeAddDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsPersonaje.ValidationsPersonajeAdd(personajeAddDto);
            }
            catch (PersonajeDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            try
            {
                MPersonaje mPersonaje = personajeAddDto.GetPersonajeFromDtoAdd();
                this.personajeRepository.Save(mPersonaje);
                this.personajeRepository.SaveChanges();
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

        public ServiceResult UpdatePersonaje(PersonajeUpdateDto personajeUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MPersonaje mPersonaje = this.personajeRepository.GetEntity(personajeUpdateDto.idpersonaje);

                mPersonaje.idpersonaje = personajeUpdateDto.idpersonaje;
                mPersonaje.Nombre = personajeUpdateDto.Nombre;
                mPersonaje.Descripcion = personajeUpdateDto.Descripcion;
                mPersonaje.id_actor = personajeUpdateDto.id_actor;
                mPersonaje.id_pelicula = personajeUpdateDto.id_pelicula;

                this.personajeRepository.Update(mPersonaje);
                this.personajeRepository.SaveChanges();
                result.Message = "Se ha modificado el personaje";
            }
            catch(PersonajeDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error modificando el personaje";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}

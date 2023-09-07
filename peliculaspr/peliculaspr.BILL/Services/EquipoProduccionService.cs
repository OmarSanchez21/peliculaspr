using Microsoft.Extensions.Logging;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.EquipoProduccion;
using peliculaspr.BILL.Extentions;
using peliculaspr.BILL.Models;
using peliculaspr.BILL.Validations;
using peliculaspr.DAL.Exceptions;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Models;
using peliculaspr.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace peliculaspr.BILL.Services
{
    public class EquipoProduccionService : IEquipoProduccionService
    {
        private readonly IEquipoProduccionRepository equipoProduccionRepository;
        private readonly ILogger<EquipoProduccionService> logger;
        public EquipoProduccionService(IEquipoProduccionRepository equipoProduccionRepository, ILogger<EquipoProduccionService> logger)
        {
            this.equipoProduccionRepository = equipoProduccionRepository;
            this.logger = logger;
        }
       

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando los Equipo de Produccion");
                var equipo = this.equipoProduccionRepository.GetEntities()
                                                                .Select(eq => new EquipoProduccionModel()
                                                                {
                                                                    idequipo = eq.idequipo,
                                                                    NombreMiembro = eq.NombreMiembro,
                                                                    Rol = eq.Rol
                                                                }).ToList();
                result.Data = equipo;
                this.logger.LogInformation("Se consulto los Equipos de Produccion");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurridop un error obtniendo los criticos";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consulto el Equipo de Produccion");

                var equipo = this.equipoProduccionRepository.GetEntity(id);

                EquipoProduccionModel produccionModel = new EquipoProduccionModel()
                { 
                    idequipo = equipo.idequipo,
                    NombreMiembro = equipo.NombreMiembro,
                    Rol = equipo.Rol
                };
                result.Data = produccionModel;
                this.logger.LogInformation("Se consulto el Equipo de Produccion");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error en la consulta del Equipo de Produccion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveEquipoProduccion(EquipoProduccionRemoveDto equipoProduccionRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MEquipoProduccion equipo = this.equipoProduccionRepository.GetEntity(equipoProduccionRemoveDto.idequipo);

                equipo.idequipo = equipoProduccionRemoveDto.idequipo;
                equipo.IsDeleted = true;

                this.equipoProduccionRepository.Update(equipo);
                this.equipoProduccionRepository.SaveChanges();
                result.Message = "El Equipo de Produccion fue removido correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error removiendo el Equipo de Produccion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult SaveEquipoProduccion(EquipoProduccionAddDto equipoProduccionAddDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsEquipoProduccion.ValidationsEquipoProduccionAdd(equipoProduccionAddDto);
            }
            catch (EquipoProduccionDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            try
            {
                MEquipoProduccion equipoProduccion = equipoProduccionAddDto.EquipoProduccionFromDtoSave();
                this.equipoProduccionRepository.Save(equipoProduccion);
                this.equipoProduccionRepository.SaveChanges();
                result.Message = "El Equipo de Produccion fue guaradado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error guardando el Equipo de Produccion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return (result);
        }


        public ServiceResult UpdateEquipoProduccion(EquipoProduccionUpdateDto equipoProduccionUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsEquipoProduccion.ValidationsEquipoProduccionUp(equipoProduccionUpdateDto);

                MEquipoProduccion equipo = this.equipoProduccionRepository.GetEntity(equipoProduccionUpdateDto.idequipo);

                equipo.idequipo = equipoProduccionUpdateDto.idequipo;
                equipo.NombreMiembro = equipoProduccionUpdateDto.NombreMiembro;
                equipo.Rol = equipoProduccionUpdateDto.Rol;

                this.equipoProduccionRepository.Update(equipo);
                this.equipoProduccionRepository.SaveChanges();
                result.Message = "El Equipo de Produccion fue modificado correctamente";
            }
            catch(EquipoProduccionDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error modificando el Equipo de Produccion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

       
    }
}

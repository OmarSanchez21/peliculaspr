using Microsoft.Extensions.Logging;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.MiembroProduccion;
using peliculaspr.BILL.Extentions;
using peliculaspr.BILL.Models;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace peliculaspr.BILL.Services
{
    public class MiembroProduccionService : IMiembroProduccionService
    {
        private readonly IMiembroProduccionRepository miembroProduccionRepository;
        private readonly ILogger<MiembroProduccionService> logger;
        public MiembroProduccionService(IMiembroProduccionRepository miembroProduccionRepository, ILogger<MiembroProduccionService> logger)
        {
            this.miembroProduccionRepository = miembroProduccionRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando los miembros de la produccion");
                var miembro = this.miembroProduccionRepository.GetEntities()
                                                                    .Select(miem => new MiembroProduccionModel()
                                                                    {
                                                                        idmiembro = miem.idmiembro,
                                                                        id_peliculas = miem.id_peliculas,
                                                                        id_equipo = miem.id_equipo
                                                                    }).ToList();
                result.Data = miembro;
                this.logger.LogInformation("Se ha consultado los miembros de la produccion");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error consultado los miembros de la produccion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando el miembro de produccion");
                var miembro = this.miembroProduccionRepository.GetEntity(id);
                MiembroProduccionModel model = new MiembroProduccionModel()
                {
                    idmiembro = miembro.idmiembro,
                    id_peliculas = miembro.id_peliculas,
                    id_equipo = miembro.id_equipo
                };
                result.Data = model;
                this.logger.LogInformation("Se consutlo el miembro de produccion");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error consultando el miembro de produccion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveMiembroProduccion(MiembroProduccionRemoveDto miembroProduccionRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MMiembroProduccion mMiembroProduccion = this.miembroProduccionRepository.GetEntity(miembroProduccionRemoveDto.idmiembro);
                mMiembroProduccion.idmiembro = miembroProduccionRemoveDto.idmiembro;
                mMiembroProduccion.IsDeleted = true;

                miembroProduccionRepository.Update(mMiembroProduccion);
                miembroProduccionRepository.SaveChanges();
                result.Message = "Se ha eliminado el miembro de produccion correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error eliminando el miembro de produccion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult AddMiembroProduccion(MiembroProduccionAddDto miembroProduccionAddDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MMiembroProduccion mMiembroProduccion = miembroProduccionAddDto.GetMiembroProduccionFromDtoSave();
                this.miembroProduccionRepository.Save(mMiembroProduccion);
                this.miembroProduccionRepository.SaveChanges();
                result.Message = "El miembro de produccion fue guardado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error guardando el miembro de produccion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult UpdateMiembroProduccion(MiembroProduccionUpdateDto miembroProduccionUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MMiembroProduccion mMiembroProduccion = this.miembroProduccionRepository.GetEntity(miembroProduccionUpdateDto.idmiembro);

                mMiembroProduccion.idmiembro = miembroProduccionUpdateDto.idmiembro;
                mMiembroProduccion.id_peliculas = miembroProduccionUpdateDto.id_peliculas;
                mMiembroProduccion.id_equipo = miembroProduccionUpdateDto.id_equipo;

                this.miembroProduccionRepository.Update(mMiembroProduccion);
                this.miembroProduccionRepository.SaveChanges();
                result.Message = "Se ha actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error actualizando";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}

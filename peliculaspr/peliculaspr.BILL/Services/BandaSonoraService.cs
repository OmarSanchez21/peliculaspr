using Microsoft.Extensions.Logging;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.BandaSonora;
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
    public class BandaSonoraService : IBandaSonoraService
    {
        private readonly IBandaSonoraRepository bandaSonoraRepository;
        private readonly ILogger<BandaSonoraService> logger;
        public BandaSonoraService(IBandaSonoraRepository bandaSonoraRepository, ILogger<BandaSonoraService> logger)
        {
            this.bandaSonoraRepository = bandaSonoraRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando las Banda Sonoras");
                var banda = this.bandaSonoraRepository.GetEntities()
                                                        .Select(ban => new BandaSonoraModel()
                                                        {
                                                            idbanda = ban.idbanda,
                                                            NombreCancion = ban.NombreCancion,
                                                            Compositor = ban.Compositor,
                                                            id_pelicula = ban.id_pelicula
                                                        }).ToList();
                result.Data = banda;
                this.logger.LogInformation("Se consulto las Bandas Sonora");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Hubo un error obteniendo las Banda Sonora";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando las Banda Sonora");
                var band = this.bandaSonoraRepository.GetEntity(id);
                BandaSonoraModel model = new BandaSonoraModel()
                { 
                    idbanda = band.idbanda,
                    NombreCancion = band.NombreCancion,
                    Compositor = band.Compositor,
                    id_pelicula = band.id_pelicula
                };
                result.Data = model;
                this.logger.LogInformation("Se completo la consulta de la Banda Sonora");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Hubo un error obteniendo la Banda Sonora";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return (result);
        }
        
        public ServiceResult RemoveBandaSonora(BandaSonoraRemoveDto bandaSonoraRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MBandaSonora mBanda = this.bandaSonoraRepository.GetEntity(bandaSonoraRemoveDto.idbanda);
                mBanda.idbanda = bandaSonoraRemoveDto.idbanda;
                mBanda.NombreCancion = bandaSonoraRemoveDto.NombreCancion;
                mBanda.Compositor = bandaSonoraRemoveDto.Compositor;
                mBanda.id_pelicula = bandaSonoraRemoveDto.id_pelicula;
                mBanda.IsDeleted = true;

                this.bandaSonoraRepository.Update(mBanda);
                this.bandaSonoraRepository.SaveChanges();
                result.Message = "La Banda Sonora fue removida correctamente";
                
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error removiendo la banda sonora";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return (result);
        }

        public ServiceResult SaveBandaSonora(BandaSonoraAddDto bandaSonoraAddDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsBandaSonora.IsValidBnadaSonora(bandaSonoraAddDto);
            }
            catch (Exception adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            try
            {
                MBandaSonora mBandaSonora = bandaSonoraAddDto.GetBandaSonoraEntityFromDtoSave();
                this.bandaSonoraRepository.Save(mBandaSonora);
                this.bandaSonoraRepository.SaveChanges();
                result.Message = "La banda Sonora fue ingresada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrrido un error guardando la banda sonora";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateBandaSonora(BandaSonoraUpdateDto bandaSonoraUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsBandaSonora.IsValidBandaSonoraUp(bandaSonoraUpdateDto);
                MBandaSonora mBandaSonora = this.bandaSonoraRepository.GetEntity(bandaSonoraUpdateDto.idbanda);

                mBandaSonora.idbanda = bandaSonoraUpdateDto.idbanda;
                mBandaSonora.NombreCancion = bandaSonoraUpdateDto.NombreCancion;
                mBandaSonora.Compositor = bandaSonoraUpdateDto.Compositor;
                mBandaSonora.id_pelicula = bandaSonoraUpdateDto.id_pelicula;

                this.bandaSonoraRepository.Update(mBandaSonora);
                this.bandaSonoraRepository.SaveChanges();
                result.Message = "La Banda Sonora fue modificada correctamente";
            }
            catch (BandaSonoraDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError(result.Message, adex.ToString());
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error modiciando la banda sonora";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return (result);
        }
    }
}

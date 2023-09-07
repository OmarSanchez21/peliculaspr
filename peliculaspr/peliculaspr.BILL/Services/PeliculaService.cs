using Microsoft.Extensions.Logging;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Pelicula;
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
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaRepository peliculaRepository;
        private readonly ILogger<PeliculaService> logger;
        public PeliculaService(IPeliculaRepository peliculaRepository, ILogger<PeliculaService> logger)
        {
            this.peliculaRepository = peliculaRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando las peliculas");
                var peliculas = this.peliculaRepository.GetEntities()
                                                         .Select(pel => new PeliculaModel()
                                                         {
                                                             idpeliculas = pel.idpeliculas,
                                                             Titulo = pel.Titulo,
                                                             Año_de_Lanzamiento = pel.Año_de_Lanzamiento,
                                                             Genero = pel.Genero,
                                                             Duracion = pel.Duracion,
                                                             Sinopsis =  pel.Sinopsis,
                                                             CalificacionPromedio = pel.CalificacionPromedio
                                                         }).ToList();
                result.Data = peliculas;
                this.logger.LogInformation("Se ha consultado las peliculas");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error consultando las peliculas";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultado la pelicula");
                var pelicula = this.peliculaRepository.GetEntity(id);

                PeliculaModel peliculaModel = new PeliculaModel()
                { 
                    idpeliculas = pelicula.idpeliculas,
                    Titulo = pelicula.Titulo,
                    Año_de_Lanzamiento = pelicula.Año_de_Lanzamiento,
                    Genero = pelicula.Genero,
                    Duracion = pelicula.Duracion,
                    Sinopsis = pelicula.Sinopsis,
                    CalificacionPromedio = pelicula.CalificacionPromedio
                };
                result.Data = peliculaModel;
                this.logger.LogInformation("Se ha consultado la pelicula");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error consultado la pelicula";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemovePelicula(PeliculaRemoveDto peliculaRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MPelicula mPelicula = this.peliculaRepository.GetEntity(peliculaRemoveDto.idpeliculas);
                mPelicula.idpeliculas = peliculaRemoveDto.idpeliculas;
                mPelicula.IsDeleted = true;

                this.peliculaRepository.Update(mPelicula);
                this.peliculaRepository.SaveChanges();
                result.Message = "Se ha eliminado correctamente la pelicula";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error eliminando la pelicula";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult AddPelicula(PeliculaAddDto peliculaAddDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ValidationsPelicula.ValidationsPeliculaAdd(peliculaAddDto);
            }
            catch (PeliculaDataExceptions adex)
            {
                result.Success = false;
                result.Message = adex.Message;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            try
            {
                MPelicula mPelicula = peliculaAddDto.GetPeliculaFromDtoSave();
                this.peliculaRepository.Save(mPelicula);
                this.peliculaRepository.SaveChanges();
                result.Message = "Se ha guardado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error guardando la pelicula";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult UpdatePelicula(PeliculaUpdateDto peliculaUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MPelicula mPelicula = this.peliculaRepository.GetEntity(peliculaUpdateDto.idpeliculas);

                mPelicula.idpeliculas = peliculaUpdateDto.idpeliculas;
                mPelicula.Titulo = peliculaUpdateDto.Titulo;
                mPelicula.Año_de_Lanzamiento = peliculaUpdateDto.Año_de_Lanzamient;
                mPelicula.Genero = peliculaUpdateDto.Genero;
                mPelicula.Duracion = peliculaUpdateDto.Duracion;
                mPelicula.Sinopsis = peliculaUpdateDto.Sinopsis;
                mPelicula.CalificacionPromedio = peliculaUpdateDto.CalificacionPromedio;

                this.peliculaRepository.Update(mPelicula);
                this.peliculaRepository.SaveChanges();
                result.Message = "Se ha modificado correctamente";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error modificando la pelicula";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}

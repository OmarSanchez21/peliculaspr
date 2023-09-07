using Microsoft.Extensions.Logging;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Filmaciones;
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
    public class FilmacionesService : IFilmacionesService
    {
        private readonly IFilmacionRepository filmacionRepository;
        private readonly ILogger<FilmacionesService> logger;
        public FilmacionesService(IFilmacionRepository filmacionRepository, ILogger<FilmacionesService> logger)
        {
            this.filmacionRepository = filmacionRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando las Filmaciones");
                var filmaciones = this.filmacionRepository.GetEntities()
                                                                .Select(fil => new FilmacionesModel()
                                                                { 
                                                                    idfilmacion = fil.idfilmacion,
                                                                    id_pelicula = fil.id_pelicula,
                                                                    id_locacion = fil.id_locacion
                                                                }).ToList();
                result.Data = filmaciones;
                this.logger.LogInformation("Se consulto las filmaciones");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error consultando las filmaciones";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando la Filmacion");
                var fil = this.filmacionRepository.GetEntity(id);

                FilmacionesModel filmacionesModel = new FilmacionesModel()
                { 
                    idfilmacion = fil.idfilmacion,
                    id_pelicula = fil.id_pelicula,
                    id_locacion = fil.id_locacion
                };
                result.Data = filmacionesModel;
                this.logger.LogInformation("Se consulto la filmacion");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error consultando la filmacion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveFilmaciones(FilmacionesRemoveDto filmacionesRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MFilmaciones mFilmaciones = this.filmacionRepository.GetEntity(filmacionesRemoveDto.idfilmacion);

                mFilmaciones.idfilmacion = filmacionesRemoveDto.idfilmacion;
                mFilmaciones.IsDeleted = true;

                this.filmacionRepository.Update(mFilmaciones);
                this.filmacionRepository.SaveChanges();
                result.Message = "La Filmacion fue removida correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false; 
                result.Message = "Ha ocurrido un error borrando la filmacion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult AddFilmaciones(FilmacionesAddDto filmacionesAddDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MFilmaciones filmaciones = filmacionesAddDto.GetFilmacionFromAddDto();
                this.filmacionRepository.Save(filmaciones);
                this.filmacionRepository.SaveChanges();
                result.Message = "La Filmacion fue ingresada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error guardando la filmacion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult UpdateFilmaciones(FilmacionUpdateDto filmacionUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MFilmaciones mFilmaciones  = this.filmacionRepository.GetEntity(filmacionUpdateDto.id_locacion);

                mFilmaciones.idfilmacion = filmacionUpdateDto.idfilmacion;
                mFilmaciones.id_pelicula = filmacionUpdateDto.id_pelicula;
                mFilmaciones.id_locacion = filmacionUpdateDto.id_locacion;

                this.filmacionRepository.Update(mFilmaciones);
                this.filmacionRepository.SaveChanges();
                result.Message = "La filmacion fue modificada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error modificando la filmacion";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}

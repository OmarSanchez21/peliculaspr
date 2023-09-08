using Microsoft.AspNetCore.Mvc;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Dtos.LocacionesFilmaciones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace peliculaspr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacionesFilmacionesController : ControllerBase
    {
        private readonly ILocalizacionesFilmacionesService localizacionesFilmacionesService;
        public LocalizacionesFilmacionesController(ILocalizacionesFilmacionesService localizacionesFilmacionesService)
        {
            this.localizacionesFilmacionesService = localizacionesFilmacionesService;
        }

        // GET: api/<LocalizacionesFilmacionesController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.localizacionesFilmacionesService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<LocalizacionesFilmacionesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.localizacionesFilmacionesService.GetById(id);
            return Ok(result);
        }

        // POST api/<LocalizacionesFilmacionesController>
        [HttpPost("SaveLocalizacionesFilmaciones")]
        public IActionResult Post([FromBody] LocalizacionesFilmacionesAddDto localizacionesFilmacionesAddDto)
        {
            var result = this.localizacionesFilmacionesService.AddLoacionesFilmaciones(localizacionesFilmacionesAddDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<LocalizacionesFilmacionesController>/5
        [HttpPut("UpdateLocalizacionesFilmaciones")]
        public IActionResult Put([FromBody] LocalizacionesFilmacionesUpdateDto localizacionesFilmacionesUpdateDto)
        {
            var result = this.localizacionesFilmacionesService.UpdateLocacionesFilmaciones(localizacionesFilmacionesUpdateDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<LocalizacionesFilmacionesController>/5
        [HttpDelete("DeleteLocalizacioneFilmaciones")]
        public IActionResult Delete(LocalizacionesFilmacionesRemoveDto localizacionesFilmacionesRemoveDto)
        {
            var result = this.localizacionesFilmacionesService.RemoveLocacionesFilmaciones(localizacionesFilmacionesRemoveDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}

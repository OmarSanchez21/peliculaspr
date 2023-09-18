using Microsoft.AspNetCore.Mvc;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Dtos.Filmaciones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace peliculaspr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmacionesController : ControllerBase
    {
        private readonly IFilmacionesService filmacionesService;
        public FilmacionesController(IFilmacionesService filmacionesService)
        {
            this.filmacionesService = filmacionesService;
        }
        // GET: api/<FilmacionesController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.filmacionesService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<FilmacionesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var result = this.filmacionesService.GetById(id);
            return Ok(result);
        }

        // POST api/<FilmacionesController>
        [HttpPost("AddFilmaciones")]
        public IActionResult Post([FromBody] FilmacionesAddDto filmacionesAddDto)
        {
            var result = this.filmacionesService.AddFilmaciones(filmacionesAddDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<FilmacionesController>/5
        [HttpPut("UpdateFilmacion")]
        public IActionResult Put( [FromBody] FilmacionUpdateDto filmacionUpdateDto)
        {
            var result = this.filmacionesService.UpdateFilmaciones(filmacionUpdateDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<FilmacionesController>/5
        [HttpDelete("DeleteFilmacion")]
        public IActionResult Delete(FilmacionesRemoveDto filmacionesRemoveDto)
        {
            var result = this.filmacionesService.RemoveFilmaciones(filmacionesRemoveDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}

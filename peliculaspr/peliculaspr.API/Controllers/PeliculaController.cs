using Microsoft.AspNetCore.Mvc;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Dtos.Pelicula;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace peliculaspr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService peliculaservice;
        public PeliculaController(IPeliculaService peliculaservice)
        {
            this.peliculaservice = peliculaservice;
        }

        // GET: api/<PeliculaController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.peliculaservice.GetAll();
            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<PeliculaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.peliculaservice.GetById(id);
            return Ok(result);
        }

        // POST api/<PeliculaController>
        [HttpPost("SavePelicula")]
        public IActionResult Post([FromBody] PeliculaAddDto peliculaAddDto)
        {
            var result = this.peliculaservice.AddPelicula(peliculaAddDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<PeliculaController>/5
        [HttpPut("UpdatePelicula")]
        public IActionResult Put([FromBody] PeliculaUpdateDto peliculaUpdateDto)
        {
            var resuult = this.peliculaservice.UpdatePelicula(peliculaUpdateDto);
            if(resuult.Success)
                return Ok(resuult);
            else
                return BadRequest(resuult);
        }

        // DELETE api/<PeliculaController>/5
        [HttpDelete("DeletePelicula")]
        public IActionResult Delete(PeliculaRemoveDto peliculaRemoveDto)
        {
            var result = this.peliculaservice.RemovePelicula(peliculaRemoveDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}

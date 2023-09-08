using Microsoft.AspNetCore.Mvc;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Dtos.Personaje;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace peliculaspr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajeController : ControllerBase
    {
        private readonly IPersonajeService personajeService;
        public PersonajeController(IPersonajeService personajeService)
        {
            this.personajeService = personajeService;
        }

        // GET: api/<PersonajeController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.personajeService.GetAll();
            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<PersonajeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.personajeService.GetById(id);
            return Ok(result);
        }

        // POST api/<PersonajeController>
        [HttpPost("SavePersonaje")]
        public IActionResult Post([FromBody] PersonajeAddDto personajeAddDto)
        {
            var result = this.personajeService.AddPersonaje(personajeAddDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<PersonajeController>/5
        [HttpPut("UpdatePersonaje")]
        public IActionResult Put([FromBody] PersonajeUpdateDto personajeUpdateDto)
        {
            var result = this.personajeService.UpdatePersonaje(personajeUpdateDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<PersonajeController>/5
        [HttpDelete("{DeletePersonaje")]
        public IActionResult Delete(PersonajeRemoveDto personajeRemoveDto)
        {
            var result = this.personajeService.RemovePersonaje(personajeRemoveDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}

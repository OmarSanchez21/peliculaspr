using Microsoft.AspNetCore.Mvc;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Dtos.Nominaciones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace peliculaspr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NominacionesController : ControllerBase
    {
        private readonly INominacionesService nominacionesService;
        public NominacionesController(INominacionesService nominacionesService)
        {
            this.nominacionesService = nominacionesService;
        }

        // GET: api/<NominacionesController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.nominacionesService.GetAll();
            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<NominacionesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.nominacionesService.GetById(id);
            return Ok(result);
        }

        // POST api/<NominacionesController>
        [HttpPost("SaveNominaciones")]
        public IActionResult Post([FromBody] NominacionesAddDto nominacionesAddDto)
        {
            var result = this.nominacionesService.AddNominaciones(nominacionesAddDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<NominacionesController>/5
        [HttpPut("UpdateNominaciones")]
        public IActionResult Put([FromBody] NominacionesUpdateDto nominacionesUpdateDto)
        {
            var result = this.nominacionesService.UpdateNominaciones(nominacionesUpdateDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<NominacionesController>/5
        [HttpDelete("DeleteNominaciones")]
        public IActionResult Delete(NominacionesRemoveDto nominacionesRemoveDto)
        {
            var result = this.nominacionesService.RemoveNominaciones(nominacionesRemoveDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}

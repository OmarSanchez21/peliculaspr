using Microsoft.AspNetCore.Mvc;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Dtos.Critico;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace peliculaspr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriticoController : ControllerBase
    {
        private readonly ICriticoService criticoService;
        public CriticoController(ICriticoService criticoService)
        {
            this.criticoService = criticoService;
        }
        // GET: api/<CriticoController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.criticoService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<CriticoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.criticoService.GetById(id);
            return Ok(result);
        }

        // POST api/<CriticoController>
        [HttpPost("SaveCritico")]
        public IActionResult Post([FromBody] CriticoAddDto criticoAddDto)
        {
            var result = this.criticoService.SaveCritico(criticoAddDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<CriticoController>/5
        [HttpPut("UpdateCritico")]
        public IActionResult Put([FromBody] CriticoUpdateDto criticoUpdateDto)
        {
            var result = this.criticoService.UpdateCritico(criticoUpdateDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<CriticoController>/5
        [HttpDelete("DeleteCritico")]
        public IActionResult Delete(CriticoRemoveDto criticoRemoveDto)
        {
            var result = this.criticoService.RemoveCritico(criticoRemoveDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}

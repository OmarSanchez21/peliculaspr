using Microsoft.AspNetCore.Mvc;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Dtos.Premio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace peliculaspr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremioController : ControllerBase
    {
        private readonly IPremioService premioService;
        public PremioController(IPremioService premioService)
        {
            this.premioService = premioService;
        }

        // GET: api/<PremioController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.premioService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<PremioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.premioService.GetById(id);
            return Ok(result);
        }

        // POST api/<PremioController>
        [HttpPost("AddPremio")]
        public IActionResult Post([FromBody] PremioAddDto premioAddDto)
        {
            var result = this.premioService.AddPremio(premioAddDto);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<PremioController>/5
        [HttpPut("UpdatePremio")]
        public IActionResult Put([FromBody] PremioUpdateDto premioUpdateDto)
        {
            var result = this.premioService.UpdatePremio(premioUpdateDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<PremioController>/5
        [HttpDelete("DeletePremio")]
        public IActionResult Delete(PremioRemoveDto premioRemoveDto)
        {
            var result = this.premioService.RemovePremio(premioRemoveDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}

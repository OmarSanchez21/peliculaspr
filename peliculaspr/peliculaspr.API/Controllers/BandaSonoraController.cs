using Microsoft.AspNetCore.Mvc;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Dtos.BandaSonora;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace peliculaspr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandaSonoraController : ControllerBase
    {
        private readonly IBandaSonoraService bandaSonoraService;
        public BandaSonoraController(IBandaSonoraService bandaSonoraService)
        {
            this.bandaSonoraService = bandaSonoraService;
        }

        // GET: api/<BandaSonoraController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.bandaSonoraService.GetAll();
            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<BandaSonoraController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.bandaSonoraService.GetById(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/<BandaSonoraController>
        [HttpPost("SaveBandaSonora")]
        public IActionResult Post([FromBody] BandaSonoraAddDto bandaSonoraAddDto)
        {
            var result = this.bandaSonoraService.SaveBandaSonora(bandaSonoraAddDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<BandaSonoraController>/5
        [HttpPut("UpdateBandaSonora")]
        public IActionResult Put([FromBody] BandaSonoraUpdateDto bandaSonoraUpdateDto)
        {
            var result = this.bandaSonoraService.UpdateBandaSonora(bandaSonoraUpdateDto);

            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<BandaSonoraController>/5
        [HttpDelete("DeleteBandaSonora")]
        public IActionResult Delete(BandaSonoraRemoveDto bandaSonoraRemoveDto)
        {
            var result = this.bandaSonoraService.RemoveBandaSonora(bandaSonoraRemoveDto);

            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}

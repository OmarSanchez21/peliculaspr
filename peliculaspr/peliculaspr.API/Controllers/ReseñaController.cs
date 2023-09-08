using Microsoft.AspNetCore.Mvc;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Dtos.Reseña;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace peliculaspr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReseñaController : ControllerBase
    {
        private readonly IReseñaService reseñaService;
        public ReseñaController(IReseñaService reseñaService)
        {
            this.reseñaService = reseñaService;
        }

        // GET: api/<ReseñaController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.reseñaService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<ReseñaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.reseñaService.GetById(id);
            return Ok(result);
        }

        // POST api/<ReseñaController>
        [HttpPost("SaveReseña")]
        public IActionResult Post([FromBody] ReseñaAddDto reseñaAddDto)
        {
            var result = this.reseñaService.AddReseña(reseñaAddDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<ReseñaController>/5
        [HttpPut("UpdateReseña")]
        public IActionResult Put([FromBody] ReseñaUpdateDto reseñaUpdateDto)
        {
            var result = this.reseñaService.UpdateReseña(reseñaUpdateDto);
                if(result.Success)
                    return Ok(result);
                else
                    return BadRequest(result);
        }

        // DELETE api/<ReseñaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(ReseñaRemoveDto reseñaRemoveDto)
        {
            var result = this.reseñaService.RemoveReseña(reseñaRemoveDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}

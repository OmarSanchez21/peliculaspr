using Microsoft.AspNetCore.Mvc;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Dtos.MiembroProduccion;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace peliculaspr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiembroProduccionController : ControllerBase
    {
        private readonly IMiembroProduccionService miembroProduccionService;
        public MiembroProduccionController(IMiembroProduccionService miembroProduccionService)
        {
            this.miembroProduccionService = miembroProduccionService;
        }

        // GET: api/<MiembroProduccionController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.miembroProduccionService.GetAll();
            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<MiembroProduccionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.miembroProduccionService.GetById(id);
            return Ok(result);
        }

        // POST api/<MiembroProduccionController>
        [HttpPost("SaveMiembroProduccion")]
        public IActionResult Post([FromBody] MiembroProduccionAddDto miembroProduccionAddDto)
        {
            var result = this.miembroProduccionService.AddMiembroProduccion(miembroProduccionAddDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<MiembroProduccionController>/5
        [HttpPut("UpdateMiembroProduccion")]
        public IActionResult Put([FromBody] MiembroProduccionUpdateDto miembroProduccionUpdateDto)
        {
            var result = this.miembroProduccionService.UpdateMiembroProduccion(miembroProduccionUpdateDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<MiembroProduccionController>/5
        [HttpDelete("DeleteMiembroProduccion")]
        public IActionResult Delete(MiembroProduccionRemoveDto miembroProduccionRemoveDto)
        {
            var result = this.miembroProduccionService.RemoveMiembroProduccion(miembroProduccionRemoveDto);
            
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}

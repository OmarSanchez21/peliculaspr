using Microsoft.AspNetCore.Mvc;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Dtos.EquipoProduccion;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace peliculaspr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoProduccionController : ControllerBase
    {
        private readonly IEquipoProduccionService equipoProduccionService;
        public EquipoProduccionController(IEquipoProduccionService equipoProduccionService)
        {
            this.equipoProduccionService = equipoProduccionService;
        }

        // GET: api/<EquipoProduccionController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.equipoProduccionService.GetAll();
            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<EquipoProduccionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.equipoProduccionService.GetById(id);
            return Ok(result);
        }

        // POST api/<EquipoProduccionController>
        [HttpPost("SaveEquipoProduccion")]
        public IActionResult Post([FromBody] EquipoProduccionAddDto equipoProduccionAddDto)
        {
            var result = this.equipoProduccionService.SaveEquipoProduccion(equipoProduccionAddDto);
            if(result.Success)
                return Ok(result);
            else 
                return BadRequest(result);
        }

        // PUT api/<EquipoProduccionController>/5
        [HttpPut("UpdateEquipoProduccion")]
        public IActionResult Put([FromBody] EquipoProduccionUpdateDto equipoProduccionUpdateDto)
        {
            var result = this.equipoProduccionService.UpdateEquipoProduccion(equipoProduccionUpdateDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<EquipoProduccionController>/5
        [HttpDelete("DeleteEquipoProduccion")]
        public IActionResult Delete(EquipoProduccionRemoveDto equipoProduccionRemoveDto)
        {
            var result = this.equipoProduccionService.RemoveEquipoProduccion(equipoProduccionRemoveDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}

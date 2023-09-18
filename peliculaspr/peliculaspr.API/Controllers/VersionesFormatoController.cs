using Microsoft.AspNetCore.Mvc;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Dtos.VersionesFormato;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace peliculaspr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionesFormatoController : ControllerBase
    {
        private readonly IVersionesFormatoService versionesFormatoService;
        public VersionesFormatoController(IVersionesFormatoService versionesFormatoService)
        {
            this.versionesFormatoService = versionesFormatoService;
        }

        // GET: api/<VersionesFormatoController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.versionesFormatoService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<VersionesFormatoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.versionesFormatoService.GetById(id);
            return Ok(result);
        }

        // POST api/<VersionesFormatoController>
        [HttpPost("AddVersionesFormato")]
        public IActionResult Post([FromBody] VersionesFormatoAddDto versionesFormatoAddDto)
        {
            var result = this.versionesFormatoService.AddVersionesFormato(versionesFormatoAddDto);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<VersionesFormatoController>/5
        [HttpPut("UpdateVersionesFormato")]
        public IActionResult Put([FromBody] VersionesFormatoUpdateDto versionesFormatoUpdateDto)
        {
            var result = this.versionesFormatoService.UpdateVersionesFormato(versionesFormatoUpdateDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<VersionesFormatoController>/5
        [HttpDelete("DeleteVersionesFormato")]
        public IActionResult Delete(VersionesFormatoRemoveDto versionesFormatoRemoveDto)
        {
            var result = this.versionesFormatoService.RemoveVersionesFormato(versionesFormatoRemoveDto);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Dtos.Actor;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace peliculaspr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService actorService;
        public ActorController(IActorService actorService)
        {
            this.actorService = actorService;
        }

        // GET: api/<ActorController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.actorService.GetAll();
            if (!result.Success)
            
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.actorService.GetById(id);
            return Ok(result);
        }

        // POST api/<ActorController>
        [HttpPost("SaveActor")]
        public IActionResult Post([FromBody] ActorAddDto addDto)
        {
            var result = this.actorService.SaveActor(addDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }


        // PUT api/<ActorController>/5
        [HttpPut("UpdateActor")]
        public IActionResult Put([FromBody] ActorUpdateDto actorUpdateDto)
        {
            var result = this.actorService.UpdateActor(actorUpdateDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("DeleteActor")]
        public IActionResult Delete(ActorRemoveDto actorRemoveDto)
        {
            var result = this.actorService.RemoveActor(actorRemoveDto);

            if(result.Success)
                return Ok(result);  
            else
                return BadRequest(result);
        }
    }
}

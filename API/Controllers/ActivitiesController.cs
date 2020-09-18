using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
//using API.Models;

namespace API.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase {
        private readonly IMediator _mediator;
        public ActivitiesController (IMediator mediator) {
            this._mediator = mediator;
        }

        [HttpGet ("")]
        public async Task<ActionResult<List<Activity>>> List () {

            return await _mediator.Send(new List.Query());

        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<Activity>> Details (Guid id) {
            
            return await _mediator.Send(new Details.Query{Id = id});
            
        }

        // [HttpPost ("")]
        // public async Task<ActionResult<Activity>> PostActivity (Activity model) {
        //     // TODO: Your code here
        //     await Task.Yield ();

        //     return null;
        // }

        // [HttpPut ("{id}")]
        // public async Task<IActionResult> PutActivity (int id, Activity model) {
        //     // TODO: Your code here
        //     await Task.Yield ();

        //     return NoContent ();
        // }

        // [HttpDelete ("{id}")]
        // public async Task<ActionResult<Activity>> DeleteActivityById (int id) {
        //     // TODO: Your code here
        //     await Task.Yield ();

        //     return null;
        // }
    }
}
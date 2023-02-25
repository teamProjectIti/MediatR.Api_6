using Application.Activities;
using Controle.Api.Controllers;
using Domain.Entity.Active;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Api.Area
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet("GetAllActivities")]
        public async Task<ActionResult> GetAllActivities()
        {
            return Ok(await mediator.Send(new List.Query()));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetAllActivities(Guid Id)
        {
            return Ok(await mediator.Send(new Details.Query { Id=Id}));
        }
        
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteActivity(Guid Id)
        {
            return Ok(await mediator.Send(new Delete.Command { Id=Id}));
        }
        
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateActivity(Guid Id,Activity model)
        {
            model.Id=Id;

            return Ok(await mediator.Send(new Edit.command { Activity= model }));
        }
        
        [HttpPost("CreateActivity")]
        public async Task<ActionResult> CreateActivity(Activity model)
        {
            return Ok(await mediator.Send(new Create.command { Activity= model }));
        }
    }
}
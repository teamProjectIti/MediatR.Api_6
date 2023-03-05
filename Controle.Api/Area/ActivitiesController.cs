using Application.Activities;
using Controle.Api.Controllers;
using Domain.Entity.Active;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Api.Area
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet("GetAllActivities")]
        public async Task<IActionResult> GetAllActivities()
        {
            return HandleRequest(await mediator.Send(new List.Query()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetActivity(Guid Id)
        {
            return HandleRequest(await mediator.Send(new Details.Query { Id = Id }));
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteActivity(Guid Id)
        {
            return HandleRequest(await mediator.Send(new Delete.Command { Id=Id}));
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateActivity(Guid Id,Activity model)
        {
            model.Id=Id;
            return HandleRequest(await mediator.Send(new Edit.command { Activity= model }));
        }
        [HttpPost("CreateActivity")]
        public async Task<IActionResult> CreateActivity(Activity model)
        {
            return HandleRequest(await mediator.Send(new Create.command { Activity= model }));
        }
    }
}
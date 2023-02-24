﻿using Application.Activities;
using Controle.Api.Controllers;
using Domain.Entity.Active;
using MediatR;
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
    }
}
﻿

namespace CARAI.API.Controllers
{
    using CARAI.Application.DTOs.RequestToMechanic;
    using CARAI.Application.Queries.RequestsToMechanic;
    using CARAI.Domain.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using static CARAI.Domain.Constants.GenerelApplicationConstrants;

    [Route("/RequestToMechanic")]
    [ApiController]
    public class RequestToMechanicController : ControllerBase
    {
        private readonly IMediator mediator;


        public RequestToMechanicController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("getDetailsForRequestToMechanic")]
        public async Task<ActionResult> GetDetailsForRequestToMechanic([FromQuery] string requestId)
        {
            if (GetTokenAndIdIfExists() == null)
            {
                return BadRequest();
            }


            RequestToMechanicDetailsQuery requestToMechanicDetailsCommand = new RequestToMechanicDetailsQuery();
            requestToMechanicDetailsCommand.RequestToMechanicId = Guid.Parse(requestId);
            requestToMechanicDetailsCommand.UserSenderId = Guid.Parse(GetTokenAndIdIfExists());



            RequestToMechanicBigDto? mechanicBigDto = (RequestToMechanicBigDto?)await mediator.Send(requestToMechanicDetailsCommand);

            if (mechanicBigDto == null)
            {
                return Unauthorized();
            }

            return Ok(mechanicBigDto);

        }


        [HttpPut("updateRequestToMechanic/{requestId}")]
        public async Task<ActionResult> UpdateRequestToMechanic([FromRoute] string requestId)
        {
            if (GetTokenAndIdIfExists() == null)
            {
                return BadRequest(UserNotLoggedErrorMessage);
            }

            RequestToMechanicDetailsQuery requestToMechanicDetailsQuery = new RequestToMechanicDetailsQuery();

            requestToMechanicDetailsQuery.RequestToMechanicId = Guid.Parse(requestId);
            requestToMechanicDetailsQuery.UserSenderId = Guid.Parse(GetTokenAndIdIfExists());

            return Ok(mediator.Send(requestToMechanicDetailsQuery));
        }


        private string GetTokenAndIdIfExists()
        {
            var token = Request.Headers["Authorization"].ToString();


            if (string.IsNullOrWhiteSpace(token))
            {
                return null;
            }



            string id = token.Remove(0, 6).Trim();

            return id;
        }
    }
}

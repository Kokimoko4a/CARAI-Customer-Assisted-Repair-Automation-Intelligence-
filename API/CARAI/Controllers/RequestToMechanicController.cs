

namespace CARAI.API.Controllers
{
    using CARAI.Application.DTOs.RequestToMechanic;
    using CARAI.Application.Queries.RequestsToMechanic;
    using CARAI.Domain.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Route("/RequestToMechanic")]
    [ApiController]
    public class RequestToMechanicController : ControllerBase
    {
        private readonly IMediator mediator;


        public RequestToMechanicController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("getDetailsForRequestToMechanic/{requestId}")]
        public async Task<ActionResult> GetDetailsForRequestToMechanic([FromRoute] string requestId)
        {
            if (GetTokenAndIdIfExists() == null)
            {
                return BadRequest();
            }


            RequestToMechanicDetailsCommand requestToMechanicDetailsCommand = new RequestToMechanicDetailsCommand();
            requestToMechanicDetailsCommand.RequestToMechanicId = Guid.Parse(requestId);
            requestToMechanicDetailsCommand.UserSenderId = Guid.Parse(GetTokenAndIdIfExists());



            RequestToMechanicBigDto? mechanicBigDto = (RequestToMechanicBigDto?)await mediator.Send(requestToMechanicDetailsCommand);

            if (mechanicBigDto == null)
            {
                return Unauthorized();
            }

            return Ok(mechanicBigDto);

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

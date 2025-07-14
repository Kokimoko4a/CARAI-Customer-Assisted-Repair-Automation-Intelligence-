namespace CARAI.Application.Commands.RequestToMechanic
{
    using CARAI.Application.DTOs.RequestToMechanic;
    using MediatR;


    public class CreateRequestToMechanicCommand : IRequest<RequestToMechanicSmallDto>
    {
        public string UserSenderId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}

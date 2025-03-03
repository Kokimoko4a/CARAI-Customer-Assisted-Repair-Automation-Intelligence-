


namespace CARAI.Application.Commands.RequestToMechanic
{
    using CARAI.Domain.Entities;
    using MediatR;


    public class CreateRequestToMechanicCommand : IRequest<bool>
    {
        public string UserSenderId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}

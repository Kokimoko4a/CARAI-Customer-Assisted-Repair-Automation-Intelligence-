


namespace CARAI.Application.Queries.RequestsToMechanic
{
    using CARAI.Application.DTOs.RequestToMechanic;
    using MediatR;

    public class RequestToMechanicDetailsCommand : IRequest<RequestToMechanicBigDto>
    {
        public Guid UserSenderId { get; set; }

        public Guid RequestToMechanicId { get; set; }
    }
}

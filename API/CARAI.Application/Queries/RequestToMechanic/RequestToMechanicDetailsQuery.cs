


namespace CARAI.Application.Queries.RequestsToMechanic
{
    using CARAI.Application.DTOs.RequestToMechanic;
    using MediatR;

    public class RequestToMechanicDetailsQuery : IRequest<RequestToMechanicBigDto>
    {
        public Guid UserSenderId { get; set; }

        public Guid RequestToMechanicId { get; set; }
    }
}

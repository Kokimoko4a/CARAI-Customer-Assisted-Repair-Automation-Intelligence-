

namespace CARAI.Application.Queries.RequestsToMechanic
{
    using CARAI.Application.DTOs.RequestToMechanic;
    using MediatR;

    public class RequestToMechanicQuery : IRequest<ICollection<RequestToMechanicSmallDto>>
    {
        public Guid UserId  { get; set; }
    }
}

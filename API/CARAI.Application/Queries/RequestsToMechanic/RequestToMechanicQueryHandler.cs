




namespace CARAI.Application.Queries.RequestsToMechanic
{
    using CARAI.Application.DTOs.RequestToMechanic;
    using CARAI.Application.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RequestToMechanicQueryHandler : IRequestHandler<RequestToMechanicQuery, ICollection<RequestToMechanicSmallDto>>
    {
        private readonly IRequestToMechanicRepository repo;

        public RequestToMechanicQueryHandler(IRequestToMechanicRepository repo)
        {
            this.repo = repo;
        }

        public async Task<ICollection<RequestToMechanicSmallDto>> Handle(RequestToMechanicQuery request, CancellationToken cancellationToken)
        {
            return await repo.GetAllRequestsToMechanicForUserAsync(request.UserId);
        }
    }
}

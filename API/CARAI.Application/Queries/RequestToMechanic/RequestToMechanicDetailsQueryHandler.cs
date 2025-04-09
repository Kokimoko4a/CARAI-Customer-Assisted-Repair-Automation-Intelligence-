


namespace CARAI.Application.Queries.RequestsToMechanic
{
    using CARAI.Application.DTOs.RequestToMechanic;
    using CARAI.Application.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RequestToMechanicDetailsQueryHandler : IRequestHandler<RequestToMechanicDetailsQuery, RequestToMechanicBigDto>
    {
        private readonly IRequestToMechanicRepository repo;

        public RequestToMechanicDetailsQueryHandler(IRequestToMechanicRepository repo)
        {
            this.repo = repo;
        }

        public async Task<RequestToMechanicBigDto> Handle(RequestToMechanicDetailsQuery request, CancellationToken cancellationToken)
        {
            if (await repo.IsSender(request))
            {
                return await repo.GetDetailsForRequestToMechanic(request);
            }

            return null;
        }
    }
}

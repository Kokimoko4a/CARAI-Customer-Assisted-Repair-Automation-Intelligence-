



namespace CARAI.Application.Interfaces
{
    using CARAI.Application.DTOs.RequestToMechanic;
    using CARAI.Application.Queries.RequestsToMechanic;
    using CARAI.Domain.Entities;

    public interface IRequestToMechanicRepository
    {
        public Task<bool> CreateRequestToMechanic(RequestToMechanic requestToMechanic);

        public Task<ICollection<RequestToMechanicSmallDto>> GetAllRequestsToMechanicForUserAsync(Guid id);

        public Task<bool> IsSender(RequestToMechanicDetailsCommand command);

        public Task<RequestToMechanicBigDto> GetDetailsForRequestToMechanic(RequestToMechanicDetailsCommand command);
    }
}

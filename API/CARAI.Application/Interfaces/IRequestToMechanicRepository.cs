



namespace CARAI.Application.Interfaces
{
    using CARAI.Domain.Entities;

    public interface IRequestToMechanicRepository
    {
        public Task<bool> CreateRequestToMechanic(RequestToMechanic requestToMechanic);
    }
}




namespace CARAI.Infrastructure.Persistence
{
    using CARAI.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using CARAI.Application.Interfaces;

    public class RequestToMechanicRepository : IRequestToMechanicRepository
    {
        private readonly CARAIDbContext data;

        public RequestToMechanicRepository(CARAIDbContext data)
        {
            this.data = data;
        }


        public async Task<bool> CreateRequestToMechanic(RequestToMechanic requestToMechanic)
        {
            await data.RequestToMechanics.AddAsync(requestToMechanic);

            return await data.SaveChangesAsync() > 0;


        }
    }
}




namespace CARAI.Infrastructure.Persistence
{
    using CARAI.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using CARAI.Application.Interfaces;
    using System.Collections.Generic;
    using CARAI.Application.DTOs.RequestToMechanic;
    using System;

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

        public async Task<ICollection<RequestToMechanicSmallDto>> GetAllRequestsToMechanicForUserAsync(Guid id)
        {
            return await data.RequestToMechanics.Where(x => x.SenderId == id)
                    .Select(x => new RequestToMechanicSmallDto()
                    {
                        Description = x.Description,
                        Id = x.Id,
                        Status = x.Status.ToString(),
                        Title = x.Title,
                    }).ToArrayAsync();
        }
    }
}

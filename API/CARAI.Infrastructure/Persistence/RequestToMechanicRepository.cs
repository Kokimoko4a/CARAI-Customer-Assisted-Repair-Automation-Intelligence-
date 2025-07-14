


namespace CARAI.Infrastructure.Persistence
{
    using CARAI.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using CARAI.Application.Interfaces;
    using System.Collections.Generic;
    using CARAI.Application.DTOs.RequestToMechanic;
    using System;
    using CARAI.Application.Queries.RequestsToMechanic;
    using CARAI.Application.Commands.RequestToMechanic;

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

        public async Task<RequestToMechanicBigDto> GetDetailsForRequestToMechanic(RequestToMechanicDetailsQuery command)
        {
            return await data.RequestToMechanics.Include(x => x.MechanicReceiver).Where(x => x.Id == command.RequestToMechanicId)
                 .Select(x => new RequestToMechanicBigDto()
                 {
                     Description = x.Description,
                     Id = x.Id,
                     MechanicReceiver = x.MechanicReceiver,
                     ReceiverId = x.ReceiverId,
                     SenderId = x.SenderId,
                     Status = x.Status.ToString(),
                     Title = x.Title,
                 }).FirstAsync();
        }

        public async Task<bool> IsSender(RequestToMechanicDetailsQuery command)
        {
            RequestToMechanic? request = await data.RequestToMechanics.FirstOrDefaultAsync(x => x.Id == command.RequestToMechanicId);

            ApplicationUser? user = await data.Users.Include(x => x.Requests).FirstOrDefaultAsync(x => x.Id == command.UserSenderId);

            bool isSender = user.Requests.Any(x => x.Id == request.Id);

            return isSender;

        }

        public async Task<RequestToMechanicSmallDto> UpdateRequestToMechanic(UpdateRequestToMechanicCommand updateRequest)
        {
            RequestToMechanic oldRequest = await data.RequestToMechanics.FirstAsync(x => x.Id == updateRequest.Id);

            oldRequest.Description = updateRequest.Description;
            oldRequest.Title = updateRequest.Title;
            oldRequest.Status = updateRequest.Status;


            await data.SaveChangesAsync();

            RequestToMechanicSmallDto requestToMechanicSmallDto  = new RequestToMechanicSmallDto();

            requestToMechanicSmallDto.Status = updateRequest.Status.ToString();
            requestToMechanicSmallDto.Description = updateRequest.Description;
            requestToMechanicSmallDto.Title = updateRequest.Title;
            requestToMechanicSmallDto.Id = updateRequest.Id;
            
            return requestToMechanicSmallDto;

           


        }
    }
}

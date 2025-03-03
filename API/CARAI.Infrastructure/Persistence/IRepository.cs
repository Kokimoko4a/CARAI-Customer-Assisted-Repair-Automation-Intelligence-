﻿



namespace CARAI.Infrastructure.Persistence
{

    using CARAI.Domain.Entities;

    public interface IRepository
    {
        public Task<bool> ExistsByEmail(string email);

        public Task<ApplicationUser> GetUserByEmailAsync(string email);

        public Task<ApplicationUser> GetUserByIdAsync(string id);

        public Task<bool> CreateRequestToMechanic(RequestToMechanic requestToMechanic);
    }
}

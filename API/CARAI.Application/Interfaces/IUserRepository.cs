

namespace CARAI.Application.Interfaces
{


    using CARAI.Domain.Entities;

    public interface IUserRepository
    {
        public Task<bool> ExistsByEmail(string email);

        public Task<ApplicationUser> GetUserByEmailAsync(string email);

        public Task<ApplicationUser> GetUserByIdAsync(string id);
    }
}

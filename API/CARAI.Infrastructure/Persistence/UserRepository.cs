


namespace CARAI.Infrastructure.Persistence
{

    using CARAI.Application.Interfaces;
    using CARAI.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class UserRepository : IUserRepository
    {
        private readonly CARAIDbContext data;

        public UserRepository(CARAIDbContext data)
        {
            this.data = data;
        }

        public async Task<bool> ExistsByEmail(string email)
        {
            return await data.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await data.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string id)
        {
            return await data.Users.FindAsync(Guid.Parse(id));
        }
    }
}

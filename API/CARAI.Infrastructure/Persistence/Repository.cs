


namespace CARAI.Infrastructure.Persistence
{
    using CARAI.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class Repository : IRepository
    {
        private readonly CARAIDbContext data;

        public Repository(CARAIDbContext data)
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

        public async Task<bool> CreateRequestToMechanic(RequestToMechanic requestToMechanic)
        {
            await data.RequestToMechanics.AddAsync(requestToMechanic);

            return await data.SaveChangesAsync() > 0;


        }
    }
}

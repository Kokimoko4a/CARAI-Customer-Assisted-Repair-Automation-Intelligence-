


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


 

    }
}



namespace CARAI.Infrastructure.Persistence
{
    using Domain.Entities;
  
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CARAIDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public CARAIDbContext(DbContextOptions<CARAIDbContext> options) : base(options)
        {
            if (Database.IsRelational())
            {
                Database.EnsureCreated();
            }
        }

        public DbSet<Mechanic> Mechanics { get; set; }

        public DbSet<ResponseFromMechanic> ResponseFromMechanics { get; set; }

        public DbSet<RequestToMechanic> RequestToMechanics { get; set; }
    }
}

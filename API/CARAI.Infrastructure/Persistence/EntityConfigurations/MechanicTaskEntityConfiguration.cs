


namespace CARAI.Infrastructure.Persistence.EntityConfigurations
{

    using CARAI.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MechanicTaskEntityConfiguration : IEntityTypeConfiguration<MechanicTask>
    {
        public void Configure(EntityTypeBuilder<MechanicTask> builder)
        {
            builder.HasKey(x => new { x.RequestId,x.MechanicId });

            builder.HasOne(x => x.Mechanic
            ).WithMany(x => x.MechanicTasks)
            .HasForeignKey(x => x.MechanicId);


                builder.HasOne(x => x.Request)
          .WithOne(x => x.MechanicTask)
          .HasForeignKey<MechanicTask>(x => x.RequestId);


        }
    }
}





namespace CARAI.Infrastructure.Persistence.EntityConfigurations
{
    using CARAI.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


    public class RequestToMechanicEntityConfiguration : IEntityTypeConfiguration<RequestToMechanic>
    {
        public void Configure(EntityTypeBuilder<RequestToMechanic> builder)
        {
            builder.HasOne(x => x.UserSender)
             .WithMany(x => x.Requests)
             .HasForeignKey(x => x.SenderId);

            builder.HasOne(x => x.MechanicReceiver)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.ReceiverId);
        }
    }
}

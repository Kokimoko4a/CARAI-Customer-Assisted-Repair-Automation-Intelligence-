namespace CARAI.Infrastructure.Persistence.EntityConfigurations
{
    using CARAI.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ResponseFromMechanicEntityConfiguration : IEntityTypeConfiguration<ResponseFromMechanic>
    {
        public void Configure(EntityTypeBuilder<ResponseFromMechanic> builder)
        {
            builder.HasOne(x => x.UserReceiver)
               .WithMany(x => x.Responses)
               .HasForeignKey(x => x.ReceiverId);

            builder.HasOne(x => x.MechanicSender)
                .WithMany(x => x.Responses)
                .HasForeignKey(x => x.SenderId);
        }
    }
}

namespace CARAI.Infrastructure.Persistence.EntityConfigurations
{
    using CARAI.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasOne(x => x.UserSender)
            .WithMany(x => x.Bookings)
            .HasForeignKey(x => x.SenderId);

            builder.HasOne(x => x.MechanicReceiver)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.SenderId);
        }
    }
}

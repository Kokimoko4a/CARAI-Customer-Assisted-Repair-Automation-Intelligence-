


namespace CARAI.Domain.Entities
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static CARAI.Domain.Constants.BookingConstanrs;

    public class Booking
    {
        public Booking()
        {
            Id = Guid.NewGuid();    
        }

        [Key]
        [Required]
        public Guid Id { get; set; }


        [ForeignKey(nameof(UserSender))]
        public Guid SenderId { get; set; }

        public ApplicationUser UserSender { get; set; }


        [ForeignKey(nameof(MechanicReceiver))]
        public Guid ReceiverId { get; set; }

        public Mechanic MechanicReceiver { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        public DateTime BookedDate { get; set; }
    }
}

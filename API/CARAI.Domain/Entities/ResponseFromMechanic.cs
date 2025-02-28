namespace CARAI.Domain.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static Domain.Constants.ResponseAndRequestConstants;

    public class ResponseFromMechanic
    {
        public ResponseFromMechanic()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Sender))]
        public string SenderId { get; set; }

        public Mechanic Sender { get; set; }


        [ForeignKey(nameof(Receiver))]
        public string ReceiverId { get; set; }

        public ApplicationUser Receiver { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }
    }
}

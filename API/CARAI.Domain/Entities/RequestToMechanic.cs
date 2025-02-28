namespace CARAI.Domain.Entities
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Domain.Constants.ResponseAndRequestConstants;

    public class RequestToMechanic
    {
        public RequestToMechanic()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }


        [ForeignKey(nameof(Sender))]
        public string SenderId { get; set; }

        public ApplicationUser Sender { get; set; }


        [ForeignKey(nameof(Receiver))]
        public string ReceiverId { get; set; }

        public Mechanic Receiver { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }
    }
}

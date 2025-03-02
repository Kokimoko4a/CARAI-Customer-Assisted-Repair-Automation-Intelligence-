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
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(MechanicSender))]
        public Guid SenderId { get; set; }

        public Mechanic MechanicSender { get; set; }


        [ForeignKey(nameof(UserReceiver))]
        public Guid ReceiverId { get; set; }

        public ApplicationUser UserReceiver { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }
    }
}

namespace CARAI.Domain.Entities
{

    using System.ComponentModel.DataAnnotations;
    using static Domain.Constants.MechanicConstants;

    public class Mechanic
    {
        public Mechanic()
        {
            Id = Guid.NewGuid();
            Requests = new HashSet<RequestToMechanic>();
            Responses = new HashSet<ResponseFromMechanic>();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; }

        [Required]
        [Range(AgeMinValue, AgeMaxValue)]
        public int Age { get; set; }
]

        public ICollection<RequestToMechanic> Requests { get; set; }

        public ICollection<ResponseFromMechanic> Responses { get; set; }

    }
}

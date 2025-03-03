namespace CARAI.Domain.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static CARAI.Domain.Constants.ApplicationUserConstants;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
            Requests = new HashSet<RequestToMechanic>();
            Responses = new HashSet<ResponseFromMechanic>();
            Bookings = new HashSet<Booking>();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength,MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; }


        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [Range(AgeMinValue,AgeMaxValue)]
        public int Age { get; set; }


        public ICollection<RequestToMechanic> Requests { get; set; }


        public ICollection<ResponseFromMechanic> Responses { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}

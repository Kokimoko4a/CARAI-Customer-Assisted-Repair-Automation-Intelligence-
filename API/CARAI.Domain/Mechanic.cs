


namespace CARAI.Domain
{

    using System.ComponentModel.DataAnnotations;

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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
]

        public ICollection<RequestToMechanic> Requests { get; set; }

        public ICollection<ResponseFromMechanic> Responses { get; set; }

    }
}



namespace CARAI.Domain
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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


        public string Title { get; set; }

        public string Description { get; set; }
    }
}

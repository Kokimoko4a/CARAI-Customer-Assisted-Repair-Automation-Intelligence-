
namespace CARAI.Domain
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;


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

        public string Title { get; set; }

        public string Description { get; set; }
    }
}

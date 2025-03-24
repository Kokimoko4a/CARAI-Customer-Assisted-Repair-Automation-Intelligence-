


namespace CARAI.Application.DTOs.RequestToMechanic
{

    using CARAI.Domain.Entities;
    using CARAI.Domain.Entities.Enumerations;

    public class RequestToMechanicBigDto
    {

        public Guid Id { get; set; }


        public Guid SenderId { get; set; }


        public Guid? ReceiverId { get; set; }

        public Mechanic? MechanicReceiver { get; set; }


        public string Title { get; set; }


        public string Description { get; set; }


        public string Status { get; set; }
    }
}

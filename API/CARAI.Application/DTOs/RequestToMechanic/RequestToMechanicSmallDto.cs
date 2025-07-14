namespace CARAI.Application.DTOs.RequestToMechanic
{
    public class RequestToMechanicSmallDto
    {
        public Guid Id { get; set; }

   
        public string Title { get; set; } = null!;


        public string Description { get; set; } = null!;


        public string Status { get; set; }

    }
}

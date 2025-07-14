
using CARAI.Domain.Entities.Enumerations;
using MediatR;
using CARAI.Application.DTOs.RequestToMechanic;

namespace CARAI.Application.Commands.RequestToMechanic
{
    public class UpdateRequestToMechanicCommand : IRequest<RequestToMechanicSmallDto>
    {
      
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public RequestStatusEnum Status { get; set; }
    }
}

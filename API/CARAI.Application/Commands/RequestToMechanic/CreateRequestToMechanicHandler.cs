


namespace CARAI.Application.Commands.RequestToMechanic
{
    using CARAI.Infrastructure.Persistence;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using CARAI.Domain.Entities;

    public class CreateRequestToMechanicHandler : IRequestHandler<CreateRequestToMechanicCommand, bool>
    {
        private readonly IRepository repository;

        public CreateRequestToMechanicHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(CreateRequestToMechanicCommand request, CancellationToken cancellationToken)
        {
            RequestToMechanic requestToMechanic = new RequestToMechanic();

            requestToMechanic.SenderId = Guid.Parse(request.UserSenderId);
            requestToMechanic.UserSender = await repository.GetUserByIdAsync(request.UserSenderId);
            requestToMechanic.Description = request.Description;
            requestToMechanic.Title = request.Title;

            return await repository.CreateRequestToMechanic(requestToMechanic);


        }
    }

}

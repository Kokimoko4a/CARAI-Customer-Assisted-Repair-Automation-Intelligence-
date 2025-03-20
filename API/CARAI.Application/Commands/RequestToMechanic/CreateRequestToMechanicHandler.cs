


namespace CARAI.Application.Commands.RequestToMechanic
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using CARAI.Domain.Entities;
    using CARAI.Application.Interfaces;

    public class CreateRequestToMechanicHandler : IRequestHandler<CreateRequestToMechanicCommand, bool>
    {
        private readonly IRequestToMechanicRepository requestToMechanicRepo;
        private readonly IUserRepository userRepo;

        public CreateRequestToMechanicHandler(IRequestToMechanicRepository requestToMechanicRepo , IUserRepository userRepo )
        {
            this.requestToMechanicRepo = requestToMechanicRepo;
            this.userRepo = userRepo;
        }

        public async Task<bool> Handle(CreateRequestToMechanicCommand request, CancellationToken cancellationToken)
        {
            RequestToMechanic requestToMechanic = new RequestToMechanic();

            requestToMechanic.SenderId = Guid.Parse(request.UserSenderId);
            requestToMechanic.UserSender = await userRepo.GetUserByIdAsync(request.UserSenderId);
            requestToMechanic.Description = request.Description;
            requestToMechanic.Title = request.Title;

            return await requestToMechanicRepo.CreateRequestToMechanic(requestToMechanic);


        }
    }

}



using CARAI.Application.DTOs.RequestToMechanic;
using CARAI.Application.Interfaces;
using CARAI.Application.Queries.RequestsToMechanic;
using MediatR;

namespace CARAI.Application.Commands.RequestToMechanic
{
    public class UpdateRequestToMechanicCommandHandler : IRequestHandler<UpdateRequestToMechanicCommand, RequestToMechanicSmallDto>
    {

        private readonly IRequestToMechanicRepository requestToMechanicRepo;
        private readonly IUserRepository userRepo;

        public  UpdateRequestToMechanicCommandHandler(IRequestToMechanicRepository requestToMechanicRepo, IUserRepository userRepo)
        {
            this.requestToMechanicRepo = requestToMechanicRepo;
            this.userRepo = userRepo;
        }


        public async Task<RequestToMechanicSmallDto> Handle(UpdateRequestToMechanicCommand request, CancellationToken cancellationToken)
        {
            RequestToMechanicDetailsQuery requestToMechanicDetailsQuery = new RequestToMechanicDetailsQuery();
            requestToMechanicDetailsQuery.UserSenderId = request.UserId;
            requestToMechanicDetailsQuery.RequestToMechanicId = request.Id;




            if (await requestToMechanicRepo.IsSender(requestToMechanicDetailsQuery))
            {
                //send to repository to update and return
                return null;
            }

            return null; // the request it not their property punish them as they deserve


        }
    }
}

namespace CARAI.Application.Commands.User
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using CARAI.Domain.Entities;
    using CARAI.Application.Interfaces;

    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, ApplicationUser>
    {
        private readonly IUserRepository data;

        public RegisterAccountCommandHandler(IUserRepository data)
        {
            this.data = data;
        }

        public async Task<ApplicationUser> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            if (await data.ExistsByEmail(request.Email))
            {
                throw new Exception();
            }

            ApplicationUser user = new ApplicationUser();

           
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Age = request.Age;

           

            return user;
        }
    }
}

namespace CARAI.Application.Commands.User
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using CARAI.Infrastructure.Persistence;
    using CARAI.Domain.Entities;

    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, ApplicationUser>
    {
        private readonly IRepository data;

        public RegisterAccountCommandHandler(IRepository data)
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

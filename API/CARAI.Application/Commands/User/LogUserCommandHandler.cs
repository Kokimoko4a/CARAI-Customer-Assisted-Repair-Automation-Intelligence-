

namespace CARAI.Application.Commands.User
{
    using CARAI.Application.Interfaces;
    using CARAI.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class LogUserCommandHandler : IRequestHandler<LogUserCommand, ApplicationUser>
    {
        private readonly IUserRepository data;

        public LogUserCommandHandler(IUserRepository data)
        {
            this.data = data;            
        }

        public async Task<ApplicationUser> Handle(LogUserCommand request, CancellationToken cancellationToken)
        {
            if (await data.ExistsByEmail(request.Email) == false)
            {
                throw new ArgumentException("User does not exist!");
            }

            return await data.GetUserByEmailAsync(request.Email);

        }
    }
}



namespace CARAI.Application.Commands.User
{
    using CARAI.Domain.Entities;
    using CARAI.Infrastructure.Persistence;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class LogUserCommandHandler : IRequestHandler<LogUserCommand, ApplicationUser>
    {
        private readonly IRepository data;

        public LogUserCommandHandler(IRepository data)
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

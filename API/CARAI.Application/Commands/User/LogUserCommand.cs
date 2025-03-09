


namespace CARAI.Application.Commands.User
{

    using CARAI.Domain.Entities;
    using MediatR;

    public class LogUserCommand : IRequest<ApplicationUser>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}







namespace CARAI.Application.Commands.User
{
    using CARAI.Domain.Entities;
    using MediatR;


    public class RegisterAccountCommand : IRequest<ApplicationUser>
    {
        public string Email { get; set; }

        public string Password { get; set; }
     
        public string FirstName { get; set; }
  
        public string LastName { get; set; }
     
        public int Age { get; set; }

    }
}

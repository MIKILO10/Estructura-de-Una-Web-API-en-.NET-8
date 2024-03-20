using Estructura.Software.Web.API.Domain.Entities;
using Estructura.Software.Web.API.Domain.Interfaces.Repositories;
using Estructura.Software.Web.Application.Application.Interfaces.IUsers;

namespace Estructura.Software.Web.API.Application.Services.Users
{
    public class UpdateEmailService : IUpdateEmailService
    {
        private readonly IUserRepository _userRepository;
        public UpdateEmailService(IUserRepository userRepository) => _userRepository = userRepository;

        public User UpdateEmail(string name, string email)
        {
            return _userRepository.UpdateMail(name, email);
        }
    }
}

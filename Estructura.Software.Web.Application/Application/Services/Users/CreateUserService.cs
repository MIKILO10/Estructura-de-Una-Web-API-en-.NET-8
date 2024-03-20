using Estructura.Software.Web.API.Domain.Entities;
using Estructura.Software.Web.API.Domain.Interfaces.Repositories;
using Estructura.Software.Web.API.Domain.Interfaces.Services.Users;

namespace Estructura.Software.Web.API.Application.Services.Users
{
    public class CreateUserService : ICreateUserService
    {
        private readonly IUserRepository _userRepository;

        public CreateUserService(IUserRepository userRepository) => _userRepository = userRepository;

        public User Create(User user)=> _userRepository.Create(user);
    }
}

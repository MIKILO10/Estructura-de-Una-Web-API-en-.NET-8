using Estructura.Software.Web.API.Domain.Entities;
using Estructura.Software.Web.API.Domain.Interfaces.Repositories;
using Estructura.Software.Web.API.Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace Estructura.Software.Web.API.Application.Services.Users
{
    public class CreateUserServices : ICreateUserServices
    {
        private readonly IUserRepository _userRepository;

        public CreateUserServices(IUserRepository userRepository) => _userRepository = userRepository;

        public User Create(User user)=> _userRepository.Create(user);
    }
}

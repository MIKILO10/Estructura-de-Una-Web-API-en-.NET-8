using Estructura.Software.Web.API.Domain.Entities;
using Estructura.Software.Web.API.Domain.Interfaces.Repositories;
using Estructura.Software.Web.Application.Application.Interfaces.IUsers;

namespace Estructura.Software.Web.API.Application.Services.Users
{
    public class GetUserService : IGetUserService
    {
        private readonly IUserRepository _userRepository;
        public GetUserService(IUserRepository userRepository) => _userRepository = userRepository;
        public User Get(string name)
        {
            return _userRepository.Get(name);
        }
    }
}

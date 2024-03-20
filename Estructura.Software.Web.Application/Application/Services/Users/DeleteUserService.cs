using Estructura.Software.Web.API.Domain.Entities;
using Estructura.Software.Web.API.Domain.Interfaces.Repositories;
using Estructura.Software.Web.API.Domain.Interfaces.Services.Users;

namespace Estructura.Software.Web.API.Application.Services.Users
{
    public class DeleteUserService : IDeleteUserService
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserService(IUserRepository userRepository) => _userRepository = userRepository;

        public User delete(string name)
        {
            return _userRepository.Delete(name);
        }
    }
}

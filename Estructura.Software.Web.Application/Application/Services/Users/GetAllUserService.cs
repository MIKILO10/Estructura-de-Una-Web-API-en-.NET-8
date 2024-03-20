using Estructura.Software.Web.API.Domain.Entities;
using Estructura.Software.Web.API.Domain.Interfaces.Repositories;
using Estructura.Software.Web.Application.Application.Interfaces.IUsers;

namespace Estructura.Software.Web.API.Application.Services.Users
{
    public class GetAllUserService : IGetAllUserService
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserService(IUserRepository userRepository) => _userRepository = userRepository;
        public List<User> GetAll() => _userRepository.GetAll();
    }
}
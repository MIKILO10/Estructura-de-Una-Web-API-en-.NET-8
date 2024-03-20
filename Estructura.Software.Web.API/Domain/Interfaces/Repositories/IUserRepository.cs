using Estructura.Software.Web.API.Domain.Entities;

namespace Estructura.Software.Web.API.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Get(string name);
        User Create(User user);
        User UpdateMail(string name, string email);
        User Delete(string name);
    }
}

using Estructura.Software.Web.API.Domain.Entities;

namespace Estructura.Software.Web.API.Domain.Interfaces.Services.Users
{
    public interface ICreateUserServices
    {
        User Create(User user);
    }
}

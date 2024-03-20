using Estructura.Software.Web.API.Domain.Entities;

namespace Estructura.Software.Web.API.Domain.Interfaces.Services.Users
{
    public interface IDeleteUserService
    {
        User delete(string name);
    }
}

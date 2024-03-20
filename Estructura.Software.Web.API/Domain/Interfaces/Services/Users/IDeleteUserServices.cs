using Estructura.Software.Web.API.Domain.Entities;

namespace Estructura.Software.Web.API.Domain.Interfaces.Services.Users
{
    public interface IDeleteUserServices
    {
        User delete(string name);
    }
}

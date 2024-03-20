using Estructura.Software.Web.API.Domain.Entities;

namespace Estructura.Software.Web.Application.Application.Interfaces.IUsers
{
    public interface IGetUserService
    {
        User Get(string name);
    }
}

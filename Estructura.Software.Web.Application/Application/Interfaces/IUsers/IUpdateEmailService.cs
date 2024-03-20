using Estructura.Software.Web.API.Domain.Entities;
namespace Estructura.Software.Web.Application.Application.Interfaces.IUsers
{
    public interface IUpdateEmailService
    {
        User UpdateEmail(string name, string email);
    }
}

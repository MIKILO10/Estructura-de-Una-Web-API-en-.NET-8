using Estructura.Software.Web.API.Domain.Entities;
namespace Estructura.Software.Web.API.Domain.Interfaces.Services.Users
{
    public interface IUpdateEmailService
    {
        User UpdateEmail(string name, string email);
    }
}

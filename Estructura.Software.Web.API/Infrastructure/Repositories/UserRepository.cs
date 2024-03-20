using Estructura.Software.Web.API.Domain.Entities;
using Estructura.Software.Web.API.Domain.Interfaces.Repositories;

namespace Estructura.Software.Web.API.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> Users;
        public UserRepository() => Users = new();


        public User Create(User user)
        {
            if (Users.Any(u => u.UserName.ToLowerInvariant() == user.UserName.ToLowerInvariant()))
                throw new Exception("No se puede crear el usuario porque ya existe");

            Users.Add(user);
            return user;
        }

        public User Delete(string name)
        {
            var user = Get(name);
            if (user == null)
                throw new Exception("No se puede eliminar el usuario porque no existe");
            Users.Remove(user);
            return user;
        }

        public List<User> GetAll() => Users;

        public User Get(string name) => Users.Find(u => u.UserName.ToLowerInvariant() == name.ToLowerInvariant());


        public User UpdateMail(string name, string email)
        {
            var userIndex = Users.FindIndex(u => u.UserName.ToLowerInvariant() == name.ToLowerInvariant());
            if (userIndex == -1)
                throw new Exception("No se puede actualizar el correo porque el usuario no existe");

            Users.ElementAt(userIndex).Email = email;
            return Users.ElementAt(userIndex);
        }
    }
}

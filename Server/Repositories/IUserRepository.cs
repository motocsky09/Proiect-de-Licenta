using Server.Entities;

namespace Server.Repositories
{
    public interface IUserRepository
    {
        public User GetUserById(int userId);
        public List<User> GetUser();

        public void DeleteUser(int userid);
    }
}

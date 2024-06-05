using Server.Entities;

namespace Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ServerDbContext _serverDbContext;

        public UserRepository(ServerDbContext serverDbContext) 
        {
            _serverDbContext = serverDbContext;
        }
        public User GetUserById(int userid) 
        {
            return _serverDbContext.User.FirstOrDefault(x => x.Id == userid);
        }

        public List<User> GetUser()
        {
            return _serverDbContext.User.ToList();
        }

        public void DeleteUser(int userid)
        {
            var userToDelete = _serverDbContext.User.FirstOrDefault(p => p.Id == userid);
            if (userToDelete != null)
            {
                _serverDbContext.User.Remove(userToDelete);
                _serverDbContext.SaveChanges();
            }
        }
    }
}

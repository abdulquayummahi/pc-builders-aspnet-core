using DAL.EF;
using DAL.EF.Tables;

namespace DAL.Repos
{
    public class UserRepo(PcBuildersDbContext dbContext)
    {
        public bool Create(User user)
        {
            dbContext.Users.Add(user);
            return dbContext.SaveChanges() > 0;
        }

        public User? Get(string email, string password)
        {
            return dbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public List<User> Get()
        {
            return dbContext.Users.ToList();
        }

        public User? GetUserRole(string email, string password)
        {
            return dbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        } 
    }
}
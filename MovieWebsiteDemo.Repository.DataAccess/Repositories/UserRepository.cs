using MovieWebsiteDemo.Core.Models;
using MovieWebsiteDemo.Core.Repositories;

namespace MovieWebsiteDemo.Repository.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}

using BlogR.Core.Data.Entities;
using BlogR.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogR.Data.EF
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context)
            : base(context)
        {
        }
    }
}

using System.Data.Entity;
using System.Threading.Tasks;

namespace Spec
{
    internal interface IUserDbContext
    {
        DbSet<UserEntity> Users { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

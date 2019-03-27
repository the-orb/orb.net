using System.Data.Entity;
using System.Threading.Tasks;

namespace Spec
{
    internal interface INameDbContext
    {
        DbSet<Name> Names { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

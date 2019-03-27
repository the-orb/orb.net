using System.Data.Entity;
using System.Threading.Tasks;

namespace Spec
{
    internal interface ILocalDbContext
    {
        DbSet<Domain> Locals { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

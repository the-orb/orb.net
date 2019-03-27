using System.Data.Entity;
using System.Threading.Tasks;

namespace Spec
{
    internal interface IDomainDbContext
    {
        DbSet<Domain> Domains { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

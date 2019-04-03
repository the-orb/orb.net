using System.Data.Entity;
using System.Threading.Tasks;

namespace Spec
{
    internal interface IAddressDbContext
    {
        DbSet<Domain> Addresses { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

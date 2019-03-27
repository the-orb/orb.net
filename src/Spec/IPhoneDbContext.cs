using System.Data.Entity;
using System.Threading.Tasks;

namespace Spec
{
    internal interface IPhoneDbContext
    {
        DbSet<Phone> Phones { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

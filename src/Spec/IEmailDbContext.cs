using System.Data.Entity;
using System.Threading.Tasks;

namespace Spec
{
    internal interface IEmailDbContext
    {
        DbSet<Email> Emails{ get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

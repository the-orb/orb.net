using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    public interface IPasswordDbContext
    {
        DbSet<Phone> Passwords { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

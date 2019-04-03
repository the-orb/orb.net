using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    internal interface IClaimDbContext
    {
        DbSet<ClaimTypeEntity> Claims { get; }

        DbSet<ClaimTypeEntity> ClaimTypes { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

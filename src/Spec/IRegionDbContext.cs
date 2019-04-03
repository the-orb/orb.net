using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    internal interface IRegionDbContext
    {
        DbSet<Domain> Regions { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

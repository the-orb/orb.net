using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class EntityService
    {
        readonly OrbDbContext _context;

        public EntityService(OrbDbContext context)
        {
            _context = context;
        }
    }
}

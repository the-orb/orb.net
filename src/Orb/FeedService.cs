using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class FeedService
    {
        readonly OrbDbContext _context;

        public FeedService(OrbDbContext context)
        {
            _context = context;
        }
    }
}
